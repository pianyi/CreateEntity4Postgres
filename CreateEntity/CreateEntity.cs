using CreateEntity.Context.System;
using CreateEntity.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateEntity
{
    public partial class CreateEntity : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CreateEntity()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 画面ロード処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateEntity_Load(object sender, EventArgs e)
        {
            try
            {
                textBoxIPAddress.Text = Settings.Default.IPAddress;
                textBoxPort.Text = Settings.Default.Port;
                textBoxName.Text = Settings.Default.Name;
                textBoxUser.Text = Settings.Default.User;
                textBoxPassword.Text = Settings.Default.Password;
                textBoxOutput.Text = Settings.Default.OutputPath;
                textBoxPgDump.Text = Settings.Default.pgDump;
            }
            catch (Exception)
            {
                // 例外は無視する
            }
        }

        /// <summary>
        /// 画面クローズ処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateEntity_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Settings.Default.IPAddress = textBoxIPAddress.Text;
                Settings.Default.Port = textBoxPort.Text;
                Settings.Default.Name = textBoxName.Text;
                Settings.Default.User = textBoxUser.Text;
                Settings.Default.Password = textBoxPassword.Text;
                Settings.Default.OutputPath = textBoxOutput.Text;
                Settings.Default.pgDump = textBoxPgDump.Text;
                Settings.Default.Save();
            }
            catch (Exception)
            {
                // 例外は無視する
            }
        }

        /// <summary>
        /// pg_dump.exe ファイルの選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Path.GetDirectoryName(textBoxPgDump.Text);
            if (String.IsNullOrWhiteSpace(textBoxPgDump.Text))
            {
                openFileDialog.InitialDirectory = Application.StartupPath;
            }

            DialogResult result = openFileDialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                textBoxPgDump.Text = openFileDialog.FileName;
            }

        }

        /// <summary>
        /// 出力先フォルダ指定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSelectOutput_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.Description = "Entityを出力するフォルダを選択してください";
            folderBrowserDialog.SelectedPath = textBoxOutput.Text;
            if (String.IsNullOrWhiteSpace(textBoxOutput.Text))
            {
                folderBrowserDialog.SelectedPath = Application.StartupPath;
            }

            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                textBoxOutput.Text = folderBrowserDialog.SelectedPath;
            }
        }

        /// <summary>
        /// 処理開始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxOutput.Text))
            {
                MessageBox.Show("フォルダが設定されていません。", "エラー",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (String.IsNullOrWhiteSpace(textBoxPgDump.Text))
            {
                MessageBox.Show("pg_dump.exeファイルが選択されていません。", "エラー",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (String.IsNullOrWhiteSpace(textBoxIPAddress.Text) ||
                String.IsNullOrWhiteSpace(textBoxPort.Text) ||
                String.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("接続先DB情報が入力されていません。", "エラー",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            try
            {

                Cursor.Current = Cursors.WaitCursor;
                Enabled = false;

                // DDLファイルの作成
                String[] files = CreateDdlFiles(textBoxOutput.Text);

                // DDL から Entity ファイルを作成する
                CreateEntityFiles(files);

                MessageBox.Show("処理が完了しました。", "完了",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("処理に失敗しました", "エラー",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                Enabled = true;
            }
        }

        /// <summary>
        /// directory作成
        /// </summary>
        /// <param name="path"></param>
        private void CreateDirectory(String path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        /// <summary>
        /// DDLファイルを作成し、そのファイル一覧を取得します
        /// </summary>
        /// <returns></returns>
        private String[] CreateDdlFiles(String outputPath)
        {
            String ddlPath = outputPath + Path.DirectorySeparatorChar + "ddl";

            using (UserTablesContext context = new UserTablesContext(textBoxIPAddress.Text,
                                                                     textBoxPort.Text,
                                                                     textBoxName.Text,
                                                                     textBoxUser.Text,
                                                                     textBoxPassword.Text))
            {
                context.CreateDDL(textBoxIPAddress.Text,
                                  textBoxPort.Text,
                                  textBoxName.Text,
                                  textBoxUser.Text,
                                  textBoxPassword.Text,
                                  ddlPath,
                                  textBoxPgDump.Text);
            }

            // DDL ファイル一覧を取得
            return Directory.GetFiles(ddlPath, "*.ddl", SearchOption.AllDirectories);
        }

        /// <summary>
        /// Entity ファイル群を作成します
        /// </summary>
        /// <param name="files">ファイルパスのリスト(DDL)</param>
        private void CreateEntityFiles(String[] files)
        {
            Dictionary<String, StringBuilder> dbSet = new Dictionary<string, StringBuilder>();

            // ファイル数分ループ
            foreach (String fileFullPath in files)
            {
                // データ解析
                DdlAttributeManager ddl = new DdlAttributeManager(fileFullPath);

                if (!String.IsNullOrWhiteSpace(ddl.TableName))
                {
                    // データが作成できたら出力する
                    // 出力先フォルダパスを作成
                    String outputPath = textBoxOutput.Text + Path.DirectorySeparatorChar + ddl.DirectoryName;
                    CreateDirectory(outputPath);

                    // Entityファイルの作成
                    File.WriteAllText(outputPath + Path.DirectorySeparatorChar + ddl.TableNameToPascal + ".cs",
                                      ddl.GetEntityString(),
                                      Encoding.Default);

                    StringBuilder tmp;
                    if (!dbSet.TryGetValue(ddl.SchemaName, out tmp))
                    {
                        tmp = new StringBuilder();
                        dbSet.Add(ddl.SchemaName, tmp);
                    }
                    // DbSet 用文字列を作成
                    tmp.Append(ddl.GetDbSetString());
                }
            }

            foreach (String keyName in dbSet.Keys)
            {
                // DbSet 用文字列を出力
                File.WriteAllText(textBoxOutput.Text + Path.DirectorySeparatorChar + "DbSet_" + keyName + ".txt",
                                  dbSet[keyName].ToString());
            }
        }
    }
}
