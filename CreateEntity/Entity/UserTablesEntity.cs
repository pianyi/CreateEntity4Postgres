using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateEntity.Entity
{
    /// <summary>
    /// ユーザテーブル情報
    /// </summary>
    [Table("pg_stat_user_tables", Schema = "public")]
    public class UserTablesEntity
    {
        ///// <summary>
        ///// ID
        ///// </summary>
        //[Key]
        //[Column("relid", Order = 0)]
        //public UInt32 RelId
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        /// スキーマ名称
        /// </summary>
        [Key]
        [Column("schemaname", Order = 0)]
        public String SchemaName
        {
            get;
            set;
        }

        /// <summary>
        /// テーブル名称
        /// </summary>
        [Key]
        [Column("relname", Order = 2)]
        public String TableName
        {
            get;
            set;
        }
    }
}
