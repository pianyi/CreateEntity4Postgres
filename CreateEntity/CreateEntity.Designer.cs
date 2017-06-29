namespace CreateEntity
{
    partial class CreateEntity
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.buttonSelectOutput = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.lblDBName = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.textBoxIPAddress = new IPAddressControlLib.IPAddressControl();
            this.lblIP = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxPgDump = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Output";
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutput.Location = new System.Drawing.Point(106, 259);
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.Size = new System.Drawing.Size(301, 19);
            this.textBoxOutput.TabIndex = 3;
            // 
            // buttonSelectOutput
            // 
            this.buttonSelectOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectOutput.Location = new System.Drawing.Point(413, 257);
            this.buttonSelectOutput.Name = "buttonSelectOutput";
            this.buttonSelectOutput.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectOutput.TabIndex = 5;
            this.buttonSelectOutput.Text = "参照";
            this.buttonSelectOutput.UseVisualStyleBackColor = true;
            this.buttonSelectOutput.Click += new System.EventHandler(this.buttonSelectOutput_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonStart.Location = new System.Drawing.Point(391, 286);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(97, 47);
            this.buttonStart.TabIndex = 6;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox1.Controls.Add(this.textBoxPassword);
            this.GroupBox1.Controls.Add(this.lblPass);
            this.GroupBox1.Controls.Add(this.textBoxUser);
            this.GroupBox1.Controls.Add(this.lblUser);
            this.GroupBox1.Controls.Add(this.textBoxName);
            this.GroupBox1.Controls.Add(this.lblDBName);
            this.GroupBox1.Controls.Add(this.textBoxPort);
            this.GroupBox1.Controls.Add(this.lblPort);
            this.GroupBox1.Controls.Add(this.textBoxIPAddress);
            this.GroupBox1.Controls.Add(this.lblIP);
            this.GroupBox1.Location = new System.Drawing.Point(14, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(474, 191);
            this.GroupBox1.TabIndex = 14;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Connect DataBase Information";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBoxPassword.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPassword.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBoxPassword.Location = new System.Drawing.Point(102, 157);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(366, 23);
            this.textBoxPassword.TabIndex = 5;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // lblPass
            // 
            this.lblPass.BackColor = System.Drawing.SystemColors.Control;
            this.lblPass.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.lblPass.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblPass.Location = new System.Drawing.Point(7, 157);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(89, 24);
            this.lblPass.TabIndex = 28;
            this.lblPass.Text = "Password";
            this.lblPass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxUser
            // 
            this.textBoxUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBoxUser.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxUser.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBoxUser.Location = new System.Drawing.Point(102, 122);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(366, 23);
            this.textBoxUser.TabIndex = 4;
            // 
            // lblUser
            // 
            this.lblUser.BackColor = System.Drawing.SystemColors.Control;
            this.lblUser.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.lblUser.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblUser.Location = new System.Drawing.Point(7, 122);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(89, 24);
            this.lblUser.TabIndex = 26;
            this.lblUser.Text = "User";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBoxName.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxName.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBoxName.Location = new System.Drawing.Point(102, 87);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(366, 23);
            this.textBoxName.TabIndex = 3;
            // 
            // lblDBName
            // 
            this.lblDBName.BackColor = System.Drawing.SystemColors.Control;
            this.lblDBName.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.lblDBName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblDBName.Location = new System.Drawing.Point(7, 87);
            this.lblDBName.Name = "lblDBName";
            this.lblDBName.Size = new System.Drawing.Size(89, 24);
            this.lblDBName.TabIndex = 24;
            this.lblDBName.Text = "Name";
            this.lblDBName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxPort
            // 
            this.textBoxPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBoxPort.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPort.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBoxPort.Location = new System.Drawing.Point(102, 52);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(366, 23);
            this.textBoxPort.TabIndex = 2;
            // 
            // lblPort
            // 
            this.lblPort.BackColor = System.Drawing.SystemColors.Control;
            this.lblPort.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.lblPort.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblPort.Location = new System.Drawing.Point(7, 52);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(89, 24);
            this.lblPort.TabIndex = 22;
            this.lblPort.Text = "Port";
            this.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxIPAddress
            // 
            this.textBoxIPAddress.AllowInternalTab = false;
            this.textBoxIPAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxIPAddress.AutoHeight = true;
            this.textBoxIPAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBoxIPAddress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textBoxIPAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxIPAddress.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxIPAddress.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBoxIPAddress.Location = new System.Drawing.Point(102, 17);
            this.textBoxIPAddress.MinimumSize = new System.Drawing.Size(111, 23);
            this.textBoxIPAddress.Name = "textBoxIPAddress";
            this.textBoxIPAddress.ReadOnly = false;
            this.textBoxIPAddress.Size = new System.Drawing.Size(366, 23);
            this.textBoxIPAddress.TabIndex = 1;
            this.textBoxIPAddress.Text = "...";
            // 
            // lblIP
            // 
            this.lblIP.BackColor = System.Drawing.SystemColors.Control;
            this.lblIP.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.lblIP.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblIP.Location = new System.Drawing.Point(7, 17);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(89, 24);
            this.lblIP.TabIndex = 20;
            this.lblIP.Text = "IP Address";
            this.lblIP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(413, 222);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "参照";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxPgDump
            // 
            this.textBoxPgDump.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPgDump.Location = new System.Drawing.Point(106, 224);
            this.textBoxPgDump.Name = "textBoxPgDump";
            this.textBoxPgDump.Size = new System.Drawing.Size(301, 19);
            this.textBoxPgDump.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "pg_dump.exe File";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "exe";
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "Execute File|*.exe";
            this.openFileDialog.ReadOnlyChecked = true;
            this.openFileDialog.RestoreDirectory = true;
            this.openFileDialog.Title = "Select pg_dump.exe File.";
            // 
            // CreateEntity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 345);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxPgDump);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonSelectOutput);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.label2);
            this.Name = "CreateEntity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateEntity";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateEntity_FormClosing);
            this.Load += new System.EventHandler(this.CreateEntity_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Button buttonSelectOutput;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        internal System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblDBName;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxPort;
        private IPAddressControlLib.IPAddressControl textBoxIPAddress;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxPgDump;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

