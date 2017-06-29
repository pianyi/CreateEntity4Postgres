using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateEntity
{
    /// <summary>
    /// テーブルデータの分解データ
    /// </summary>
    public class DdlAttribute
    {
        /// <summary>
        /// カラム名
        /// </summary>
        public String ColumnName
        {
            get;
            private set;
        }

        /// <summary>
        /// データ型名(DB側)
        /// </summary>
        public String DataTypesOriginal
        {
            get;
            private set;
        }

        /// <summary>
        /// データ型名(C#側)
        /// https://github.com/npgsql/npgsql の doc/types/basic.md を参照
        /// </summary>
        public String DataTypes
        {
            get
            {
                switch (DataTypesOriginal.ToLower())
                {
                    case "boolean":
                    return "Boolean";

                    case "smallint":
                    if (NotNull || PrimaryKeyIndex > 0)
                    {
                        return "Int16";
                    }
                    else
                    {
                        return "Int16?";
                    }

                    case "integer":
                    if (NotNull || PrimaryKeyIndex > 0)
                    {
                        return "Int32";
                    }
                    else
                    {
                        return "Int32?";
                    }

                    case "bigint":
                    if (NotNull || PrimaryKeyIndex > 0)
                    {
                        return "Int64";
                    }
                    else
                    {
                        return "Int64?";
                    }

                    case "real":
                    if (NotNull || PrimaryKeyIndex > 0)
                    {
                        return "float";
                    }
                    else
                    {
                        return "float?";
                    }

                    case "double":
                    if (NotNull || PrimaryKeyIndex > 0)
                    {
                        return "Double";
                    }
                    else
                    {
                        return "Double?";
                    }

                    case "numeric":
                    if (NotNull || PrimaryKeyIndex > 0)
                    {
                        return "Decimal";
                    }
                    else
                    {
                        return "Decimal?";
                    }

                    case "money":
                    if (NotNull || PrimaryKeyIndex > 0)
                    {
                        return "Decimal";
                    }
                    else
                    {
                        return "Decimal?";
                    }

                    case "text":
                    return "String";

                    case "varchar":
                    return "String";

                    case "char":
                    return "String";

                    case "citext":
                    return "String";

                    case "json":
                    return "String";

                    case "jsonb":
                    return "String";

                    case "xml":
                    return "String";

                    case "point":
                    return "NpgsqlPoint";

                    case "lseg":
                    return "NpgsqlLSeg";

                    case "path":
                    return "NpgsqlPath";

                    case "polygon":
                    return "NpgsqlPolygon";

                    case "line":
                    return "NpgsqlLine";

                    case "circle":
                    return "NpgsqlCircle";

                    case "box":
                    return "NpgsqlBox";

                    case "bit":
                    return "BitArray";

                    case "varbit":
                    return "BitArray";

                    case "hstore":
                    return "IDictionary<String,String>";

                    case "uuid":
                    return "Guid";

                    case "cidr":
                    return "IPAddress";

                    case "inet":
                    return "IPAddress";

                    case "macaddr":
                    return "PhysicalAddress";

                    case "tsquery":
                    return "NpgsqlTsQuery";

                    case "tsvector":
                    return "NpgsqlTsVector";

                    case "date":
                    if (NotNull || PrimaryKeyIndex > 0)
                    {
                        return "DateTime";
                    }
                    else
                    {
                        return "DateTime?";
                    }

                    case "interval":
                    if (NotNull || PrimaryKeyIndex > 0)
                    {
                        return "TimeSpan";
                    }
                    else
                    {
                        return "TimeSpan?";
                    }

                    case "timestamp":
                    if (NotNull || PrimaryKeyIndex > 0)
                    {
                        return "DateTime";
                    }
                    else
                    {
                        return "DateTime?";
                    }

                    case "timestampTZ":
                    if (NotNull || PrimaryKeyIndex > 0)
                    {
                        return "DateTime";
                    }
                    else
                    {
                        return "DateTime?";
                    }

                    case "time":
                    if (NotNull || PrimaryKeyIndex > 0)
                    {
                        return "TimeSpan";
                    }
                    else
                    {
                        return "TimeSpan?";
                    }

                    case "timeTZ":
                    return "DateTimeOffset";

                    case "bytea":
                    return "byte[]";

                    case "oid":
                    if (NotNull || PrimaryKeyIndex > 0)
                    {
                        return "UInt32";
                    }
                    else
                    {
                        return "UInt32?";
                    }

                    case "xid":
                    if (NotNull || PrimaryKeyIndex > 0)
                    {
                        return "UInt32";
                    }
                    else
                    {
                        return "UInt32?";
                    }

                    case "cid":
                    if (NotNull || PrimaryKeyIndex > 0)
                    {
                        return "UInt32";
                    }
                    else
                    {
                        return "UInt32?";
                    }

                    case "oidvector":
                    return "uint[]";

                    case "name":
                    return "String";

                    case "internalChar":
                    if (NotNull || PrimaryKeyIndex > 0)
                    {
                        return "Byte";
                    }
                    else
                    {
                        return "Byte?";
                    }

                    case "geometry":
                    return "PostgisGeometry";

                    case "composite":
                    return "T";

                    case "range":
                    return "NpgsqlRange<TElement>";

                    case "enum":
                    return "TEnum";

                    case "array":
                    return "Array";

                    // PostGIS独自判断処理
                    case "geometry:linestring":
                    return "NpgsqlLSeg";

                    case "geometry:multilinestring":
                    return "NpgsqlLSeg";

                    case "geometry:point":
                    return "NpgsqlPoint";

                    case "geometry:multipoint":
                    return "NpgsqlPoint";

                    case "geometry:polygon":
                    return "NpgsqlPolygon";

                    case "geometry:multipolygon":
                    return "NpgsqlPolygon";

                    //case "geometry:geometrycollection":
                    //return "PostgisGeometryCollection";

                    default:
                    return "Object";
                }
            }
        }

        /// <summary>
        /// コメント（存在する場合）
        /// </summary>
        public String Comment
        {
            get;
            set;
        }

        /// <summary>
        /// プライマリキーフラグ
        /// </summary>
        public Int32 PrimaryKeyIndex
        {
            get;
            set;
        }

        /// <summary>
        /// NOT NULL制約
        /// </summary>
        public Boolean NotNull
        {
            get;
            set;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="col">カラム名</param>
        /// <param name="type">データ型名</param>
        /// <param name="notNull">Not Null制約</param>
        public DdlAttribute(String col, String type, Boolean notNull = false)
        {
            ColumnName = col;
            DataTypesOriginal = type;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="col">カラム名</param>
        /// <param name="type">データ型名</param>
        public DdlAttribute(String col, String type, String comment)
            : this(col, type)
        {
            Comment = comment;
        }
    }
}
