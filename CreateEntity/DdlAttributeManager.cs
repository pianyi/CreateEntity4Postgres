using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CreateEntity
{
    public class DdlAttributeManager
    {
        /// <summary>
        /// クラス作成する固定文字
        /// </summary>
        private const String FixedCharacterClass = @"using NpgsqlTypes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseController.DBConnection.Entity{1}
{{
    /// <summary>
    /// {2}
    /// </summary>
    [Table(""{3}"", Schema = ""{4}"")]
    public class {5}
    {{
{6}
    }}
}}{0}";

        /// <summary>
        /// コメント作成する固定文字
        /// </summary>
        private const String FixedCharacterComment = @"        /// <summary>
        /// {1}
        /// </summary>{0}";

        /// <summary>
        /// プライマリキー作成する固定文字
        /// </summary>
        private const String FixedCharacterPrimaryKey = @"        [Key]{0}";

        /// <summary>
        /// プロパティ(PK無し)作成する固定文字
        /// </summary>
        private const String FixedCharacterProperty = @"        [Column(""{1}"")]
        public {2} {3}
        {{
            get;
            set;
        }}{0}";

        /// <summary>
        /// プロパティ(PKあり)作成する固定文字
        /// </summary>
        private const String FixedCharacterPropertyPK = @"        [Column(""{1}"", Order = {2})]
        public {3} {4}
        {{
            get;
            set;
        }}{0}";

        /// <summary>
        /// DbSet作成する固定文字
        /// </summary>
        private const String FixedCharacterDbSet = @"        /// <summary>
        /// {1}
        /// </summary>
        public DbSet<{2}> {2}
        {{
            get
            {{
                return Set<{2}>();
            }}
        }}{0}";

        /// <summary>
        /// テーブル名称
        /// </summary>
        public String TableName
        {
            get;
            private set;
        }

        /// <summary>
        /// テーブル名をパスカル式にして返します
        /// 主にファイル名に使用します
        /// </summary>
        public String TableNameToPascal
        {
            get
            {
                return ToPascal(TableName);
            }
        }

        /// <summary>
        /// テーブルコメント
        /// </summary>
        public String TableComment
        {
            get;
            private set;
        }

        /// <summary>
        /// 属性情報のリストを取得します
        /// </summary>
        public List<DdlAttribute> Attributes
        {
            get;
            private set;
        }

        /// <summary>
        /// スキーマ名称
        /// </summary>
        public String SchemaName
        {
            get;
            set;
        }

        /// <summary>
        /// 保存先ディレクトリ名称
        /// </summary>
        public String DirectoryName
        {
            get
            {
                return ToPascal(SchemaName + "s");
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        private DdlAttributeManager()
        {
            Attributes = new List<DdlAttribute>();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        public DdlAttributeManager(String filePath)
            : this()
        {
            // ファイル名のみ取得
            String fileName = Path.GetFileNameWithoutExtension(filePath);

            // スキーマ名を取得
            String[] splitFileName = fileName.Split('.');
            SchemaName = splitFileName[0];

            // 1行分ループ
            IEnumerable<String> lines = File.ReadLines(filePath);
            Boolean isTable = false;
            DdlAttribute newAttribute = null;
            foreach (String line in lines)
            {
                if (String.IsNullOrWhiteSpace(line) || line.StartsWith("--"))
                {
                    // 空行または、コメント行の場合は読み飛ばす
                    continue;
                }

                String[] split = line.TrimStart().Split(' ');

                if (line.IndexOf("CREATE TABLE") >= 0 && !isTable)
                {
                    // テーブル名(テーブル情報開始
                    TableName = split[2];
                    isTable = true;
                }
                else if (line.IndexOf(");") >= 0 && isTable)
                {
                    // テーブル作成部分が終わったので処理終了
                    isTable = false;
                }
                else if (isTable)
                {
                    // テーブル属性情報
                    String columnName = split[0];
                    String typeName = split[1];
                    int dotIndex = typeName.IndexOf(".");
                    if (dotIndex >= 0)
                    {
                        // . が存在する場合は、スキーマ名なので削除する
                        typeName = typeName.Substring(dotIndex + 1, typeName.Length - dotIndex - 1);
                    }
                    int parenthesisIndexStart = typeName.IndexOf("(");
                    if (parenthesisIndexStart >= 0)
                    {
                        // ( が存在する場合は、不可情報なので、精査する
                        String type = typeName.Substring(0, parenthesisIndexStart);
                        if (type.ToLower() == "geometry")
                        {
                            // geometry の場合は、line/point/polygon で分ける
                            int parenthesisIndexEnd = typeName.IndexOf(")");
                            String[] geomType = typeName.Substring(parenthesisIndexStart + 1).Split(',');
                            typeName = type + ":" + geomType[0];
                        }
                        else
                        {
                            typeName = type;
                        }
                    }

                    Boolean notNull = false;
                    if (line.IndexOf("NOT NULL") >= 0)
                    {
                        notNull = true;
                    }

                    newAttribute = new DdlAttribute(columnName, typeName.Replace(",", ""), notNull);
                    Attributes.Add(newAttribute);
                }
                else if (line.IndexOf("COMMENT ON TABLE") >= 0 && !isTable)
                {
                    // テーブルコメント情報
                    TableComment = split[5].Replace("'", "").Replace(";", "");
                }
                else if (line.IndexOf("COMMENT ON COLUMN") >= 0 && !isTable)
                {
                    String[] tmp = split[3].Split('.');
                    foreach (DdlAttribute attribute in Attributes)
                    {
                        if (attribute.ColumnName == tmp[1])
                        {
                            // カラムコメント情報
                            attribute.Comment = split[5].Replace("'", "").Replace(";", "");
                            break;
                        }
                    }
                }
                else if (split.Count() >= 4 && split[3] == "PRIMARY" && split[4] == "KEY")
                {
                    int pkIndex = 0;

                    for (int i = 5; i < split.Length; i++)
                    {
                        String tmp = split[i].Replace("(", "").Replace(")", "").Replace(";", "").Replace(",", "");
                        foreach (DdlAttribute attribute in Attributes)
                        {
                            if (attribute.ColumnName == tmp)
                            {
                                // プライマリキー
                                pkIndex++;
                                attribute.PrimaryKeyIndex = pkIndex;
                                break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Entityクラスファイル文字列を取得します
        /// </summary>
        /// <returns>ファイルに出力する文字列</returns>
        public String GetEntityString()
        {
            StringBuilder property = new StringBuilder();

            foreach (DdlAttribute attribute in Attributes)
            {
                if (!String.IsNullOrWhiteSpace(attribute.Comment))
                {
                    // コメントの追記
                    property.AppendFormat(FixedCharacterComment,
                                          Environment.NewLine,
                                          attribute.Comment);
                }
                if (attribute.PrimaryKeyIndex > 0)
                {
                    // キーの追記
                    property.AppendFormat(FixedCharacterPrimaryKey,
                                          Environment.NewLine);
                    // プロパティの追記
                    property.AppendFormat(FixedCharacterPropertyPK
                                       , Environment.NewLine
                                       , attribute.ColumnName
                                       , attribute.PrimaryKeyIndex
                                       , attribute.DataTypes
                                       , ToPascal(attribute.ColumnName));
                }
                else
                {
                    // プロパティの追記
                    property.AppendFormat(FixedCharacterProperty
                                       , Environment.NewLine
                                       , attribute.ColumnName
                                       , attribute.DataTypes
                                       , ToPascal(attribute.ColumnName));
                }
            }

            // 名前空間、クラスの指定
            StringBuilder result = new StringBuilder();
            result.AppendFormat(FixedCharacterClass,
                                Environment.NewLine,
                                "." + DirectoryName,
                                TableComment,
                                TableName,
                                SchemaName,
                                ToPascal(TableName),
                                property);

            return result.ToString();
        }

        /// <summary>
        /// DbSet用文字列を取得します
        /// </summary>
        /// <returns></returns>
        public String GetDbSetString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat(FixedCharacterDbSet,
                               Environment.NewLine,
                               TableComment,
                               ToPascal(TableName));

            return result.ToString();
        }

        /// <summary>
        /// 取得文字列(_区切り文字)
        /// </summary>
        /// <param name="str">返還前文字列(_区切り)</param>
        /// <returns>パスカル形式</returns>
        private String ToPascal(String str)
        {
            if (String.IsNullOrWhiteSpace(str))
            {
                return str;
            }

            return Regex.Replace(str.Replace("_", " "),
                        @"\b[a-z]",
                        match => match.Value.ToUpper()).Replace(" ", "");
        }
    }
}
