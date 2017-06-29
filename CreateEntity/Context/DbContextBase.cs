using log4net;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CreateEntity.Context
{
    /// <summary>
    /// DB接続管理規定クラス
    /// </summary>
    public class DbContextBase : DbContext
    {
        /// <summary>
        /// ログ出力クラス
        /// </summary>
        private static ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 接続先スキーマ名(public)
        /// </summary>
        protected const String SCHEMA_PUBLIC = "public";

        #region 接続プロパティ
        /// <summary>
        /// 参照するスキーマ
        /// </summary>
        public string DefaultSchema
        {
            get;
            private set;
        }
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="ip">接続先IPアドレス(ホスト名)</param>
        /// <param name="port">接続先ポート番号</param>
        /// <param name="dbName">接続先DB名称</param>
        /// <param name="userId">接続ID</param>
        /// <param name="password">接続パスワード</param>
        /// <param name="defaultSchema">接続先スキーマ</param>
        public DbContextBase(String ip, String port, String dbName, String userId, String password, String defaultSchema)
            : base(GetConnecting(ip, port, dbName, userId, password), true)
        {
            // schemaの指定
            DefaultSchema = defaultSchema;

            // 各種設定
            Configuration.ValidateOnSaveEnabled = false;
            Configuration.UseDatabaseNullSemantics = true;

            // ログ出力先の指定
            Database.Log = (log) => logger.Debug(log);
        }
        #endregion

        #region イベント
        /// <summary>
        /// スキーマを指定する
        /// 指定が無いとスキーマ名は『dbo』に設定される
        /// </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(DefaultSchema);
        }
        #endregion

        #region メソッド
        /// <summary>
        /// コネクションの取得
        /// </summary>
        /// <param name="userid">ユーザーID</param>
        /// <param name="password">パスワード</param>
        private static NpgsqlConnection GetConnecting(String ip, String port, String dbName, String userId, String password)
        {
            String connectString = String.Format("server={0};port={1};database={2};user id={3};password={4};",
                                                 ip,
                                                 port,
                                                 dbName,
                                                 userId,
                                                 password);

            logger.Info(connectString);

            return new NpgsqlConnection(connectString);
        }
        #endregion
    }
}
