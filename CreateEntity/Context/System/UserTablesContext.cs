using CreateEntity.Entity;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CreateEntity.Context.System
{
    public class UserTablesContext : DbContextBase
    {
        /// <summary>
        /// ログ出力クラス
        /// </summary>
        private ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// ユーザテーブル
        /// </summary>
        public DbSet<UserTablesEntity> UserTablesEntity
        {
            get
            {
                return Set<UserTablesEntity>();
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="ip">接続先IPアドレス(ホスト名)</param>
        /// <param name="port">接続先ポート番号</param>
        /// <param name="dbName">接続先DB名称</param>
        /// <param name="userId">接続ID</param>
        /// <param name="password">接続パスワード</param>
        /// <param name="defaultSchema">接続先スキーマ</param>
        public UserTablesContext(String ip, String port, String dbName, String userId, String password, String defaultSchema = SCHEMA_PUBLIC)
            : base(ip, port, dbName, userId, password, defaultSchema)
        {
        }

        /// <summary>
        /// テーブル情報のDDLを作成します
        /// 拡張子は【スキーマ名_テーブル名.ddl】
        /// </summary>
        /// <param name="ip">接続先IPアドレス</param>
        /// <param name="port">接続先ポート番号</param>
        /// <param name="dbName">接続先データベース名</param>
        /// <param name="userId">接続先ユーザ名</param>
        /// <param name="password">接続先パスワード</param>
        /// <param name="outputPath">出力先のパス</param>
        /// <param name="pgDumpPath">pg_dump.exeの有るフォルダ</param>
        public void CreateDDL(String ip,
                              String port,
                              String dbName,
                              String userId,
                              String password,
                              String outputPath,
                              String pgDumpPath)
        {

            List<UserTablesEntity> entityList = UserTablesEntity.OrderBy(e => e.SchemaName)
                                                                .ThenBy(e => e.TableName).ToList();

            Directory.CreateDirectory(outputPath);

            foreach (UserTablesEntity entity in entityList)
            {
                Process psInfo = new Process();

                ProcessStartInfo startInfo = new ProcessStartInfo();

                startInfo.CreateNoWindow = true; // コンソール・ウィンドウを開かない
                startInfo.RedirectStandardOutput = true; // 標準出力をリダイレクト
                startInfo.RedirectStandardError = true;
                startInfo.UseShellExecute = false; // シェル機能を使用しない

                startInfo.FileName = pgDumpPath;
                //startInfo.Arguments = String.Format(@" -s -t {0}.{1} HikariManager > ""{2}\{0}.{1}.ddl""",
                startInfo.Arguments = String.Format(@" -s -t {0}.{1} -f ""{2}\{0}.{1}.ddl"" -h {3} -p {4} -U {5} -w {6}",
                                                    entity.SchemaName,
                                                    entity.TableName,
                                                    outputPath,
                                                    ip,
                                                    port,
                                                    userId,
                                                    dbName);

                psInfo.StartInfo = startInfo;
                psInfo.Start();

                // エラー情報を取得
                string errorResult = psInfo.StandardError.ReadToEnd();

                psInfo.WaitForExit();
                psInfo.Close();

                if (!String.IsNullOrWhiteSpace(errorResult))
                {
                    throw new Exception(errorResult);
                }
            }
        }
    }
}
