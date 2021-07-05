namespace eFacilito_CW_Migration_Utility.Forms
{
    partial class CW_Migrate_Setup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_DB_Connection_Status = new System.Windows.Forms.Label();
            this.btn_Connect_CW_DB = new System.Windows.Forms.Button();
            this.ddl_cb_Server_Name = new System.Windows.Forms.ComboBox();
            this.ddl_cb_DatabaseList = new System.Windows.Forms.ComboBox();
            this.txt_ServerUsername = new System.Windows.Forms.TextBox();
            this.txt_ServerPassword = new System.Windows.Forms.TextBox();
            this.txt_CWAccount_Password = new System.Windows.Forms.TextBox();
            this.txt_CWAccount_Username = new System.Windows.Forms.TextBox();
            this.btn_Connect_CWAccount = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_ProceedMigration = new System.Windows.Forms.Button();
            this.lbl_DBConnection_Status = new System.Windows.Forms.Label();
            this.lbl_AccountConn_Status = new System.Windows.Forms.Label();
            this.btn_ConnectServer = new System.Windows.Forms.Button();
            this.loadingImage = new System.Windows.Forms.PictureBox();
            this.lbl_ValidationStatus = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_CWAccount_CompanyCode = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(175, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(434, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Cocktail World 4.0 Application Database";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select Server";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Enter Server Username";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Enter Server Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Select Database";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(290, 312);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(215, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Database Connection Status";
            // 
            // lbl_DB_Connection_Status
            // 
            this.lbl_DB_Connection_Status.AutoSize = true;
            this.lbl_DB_Connection_Status.Location = new System.Drawing.Point(392, 304);
            this.lbl_DB_Connection_Status.Name = "lbl_DB_Connection_Status";
            this.lbl_DB_Connection_Status.Size = new System.Drawing.Size(0, 20);
            this.lbl_DB_Connection_Status.TabIndex = 7;
            // 
            // btn_Connect_CW_DB
            // 
            this.btn_Connect_CW_DB.Location = new System.Drawing.Point(16, 304);
            this.btn_Connect_CW_DB.Name = "btn_Connect_CW_DB";
            this.btn_Connect_CW_DB.Size = new System.Drawing.Size(253, 36);
            this.btn_Connect_CW_DB.TabIndex = 8;
            this.btn_Connect_CW_DB.Text = "Connect CW Database";
            this.btn_Connect_CW_DB.UseVisualStyleBackColor = true;
            this.btn_Connect_CW_DB.Click += new System.EventHandler(this.btn_Connect_CW_DB_Click);
            // 
            // ddl_cb_Server_Name
            // 
            this.ddl_cb_Server_Name.FormattingEnabled = true;
            this.ddl_cb_Server_Name.Location = new System.Drawing.Point(223, 118);
            this.ddl_cb_Server_Name.Name = "ddl_cb_Server_Name";
            this.ddl_cb_Server_Name.Size = new System.Drawing.Size(588, 28);
            this.ddl_cb_Server_Name.TabIndex = 9;
            // 
            // ddl_cb_DatabaseList
            // 
            this.ddl_cb_DatabaseList.FormattingEnabled = true;
            this.ddl_cb_DatabaseList.Location = new System.Drawing.Point(223, 262);
            this.ddl_cb_DatabaseList.Name = "ddl_cb_DatabaseList";
            this.ddl_cb_DatabaseList.Size = new System.Drawing.Size(588, 28);
            this.ddl_cb_DatabaseList.TabIndex = 10;
            // 
            // txt_ServerUsername
            // 
            this.txt_ServerUsername.Location = new System.Drawing.Point(223, 153);
            this.txt_ServerUsername.Name = "txt_ServerUsername";
            this.txt_ServerUsername.Size = new System.Drawing.Size(588, 26);
            this.txt_ServerUsername.TabIndex = 11;
            // 
            // txt_ServerPassword
            // 
            this.txt_ServerPassword.Location = new System.Drawing.Point(223, 185);
            this.txt_ServerPassword.Name = "txt_ServerPassword";
            this.txt_ServerPassword.Size = new System.Drawing.Size(588, 26);
            this.txt_ServerPassword.TabIndex = 12;
            this.txt_ServerPassword.TextChanged += new System.EventHandler(this.txt_ServerPassword_TextChanged);
            // 
            // txt_CWAccount_Password
            // 
            this.txt_CWAccount_Password.Location = new System.Drawing.Point(223, 478);
            this.txt_CWAccount_Password.Name = "txt_CWAccount_Password";
            this.txt_CWAccount_Password.Size = new System.Drawing.Size(588, 26);
            this.txt_CWAccount_Password.TabIndex = 24;
            // 
            // txt_CWAccount_Username
            // 
            this.txt_CWAccount_Username.Location = new System.Drawing.Point(223, 446);
            this.txt_CWAccount_Username.Name = "txt_CWAccount_Username";
            this.txt_CWAccount_Username.Size = new System.Drawing.Size(588, 26);
            this.txt_CWAccount_Username.TabIndex = 23;
            // 
            // btn_Connect_CWAccount
            // 
            this.btn_Connect_CWAccount.Location = new System.Drawing.Point(16, 519);
            this.btn_Connect_CWAccount.Name = "btn_Connect_CWAccount";
            this.btn_Connect_CWAccount.Size = new System.Drawing.Size(253, 36);
            this.btn_Connect_CWAccount.TabIndex = 20;
            this.btn_Connect_CWAccount.Text = "Connect CW Web Acount";
            this.btn_Connect_CWAccount.UseVisualStyleBackColor = true;
            this.btn_Connect_CWAccount.Click += new System.EventHandler(this.btn_Connect_CWAccount_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(392, 519);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 20);
            this.label7.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(299, 527);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(204, 20);
            this.label8.TabIndex = 18;
            this.label8.Text = "Account Connection Status";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 481);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 20);
            this.label10.TabIndex = 16;
            this.label10.Text = "Enter Password";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 446);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(126, 20);
            this.label11.TabIndex = 15;
            this.label11.Text = "Enter Username";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 411);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(161, 20);
            this.label12.TabIndex = 14;
            this.label12.Text = "Enter Company Code";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(175, 366);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(451, 24);
            this.label13.TabIndex = 13;
            this.label13.Text = "Connect your efacilito Account for Migrating Data";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(12, 558);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(812, 53);
            this.label9.TabIndex = 25;
            this.label9.Text = "Click below if Both Database Connection Status and Account Connection Status are " +
    "SUCCESSFUL";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_ProceedMigration
            // 
            this.btn_ProceedMigration.BackColor = System.Drawing.Color.Orange;
            this.btn_ProceedMigration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ProceedMigration.Location = new System.Drawing.Point(282, 623);
            this.btn_ProceedMigration.Name = "btn_ProceedMigration";
            this.btn_ProceedMigration.Size = new System.Drawing.Size(253, 36);
            this.btn_ProceedMigration.TabIndex = 26;
            this.btn_ProceedMigration.Text = "PROCEED to MIgration";
            this.btn_ProceedMigration.UseVisualStyleBackColor = false;
            this.btn_ProceedMigration.Click += new System.EventHandler(this.btn_ProceedMigration_Click);
            // 
            // lbl_DBConnection_Status
            // 
            this.lbl_DBConnection_Status.AutoSize = true;
            this.lbl_DBConnection_Status.BackColor = System.Drawing.Color.Yellow;
            this.lbl_DBConnection_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DBConnection_Status.Location = new System.Drawing.Point(520, 312);
            this.lbl_DBConnection_Status.Name = "lbl_DBConnection_Status";
            this.lbl_DBConnection_Status.Size = new System.Drawing.Size(89, 20);
            this.lbl_DBConnection_Status.TabIndex = 27;
            this.lbl_DBConnection_Status.Text = "PENDING";
            // 
            // lbl_AccountConn_Status
            // 
            this.lbl_AccountConn_Status.AutoSize = true;
            this.lbl_AccountConn_Status.BackColor = System.Drawing.Color.Yellow;
            this.lbl_AccountConn_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_AccountConn_Status.Location = new System.Drawing.Point(520, 527);
            this.lbl_AccountConn_Status.Name = "lbl_AccountConn_Status";
            this.lbl_AccountConn_Status.Size = new System.Drawing.Size(89, 20);
            this.lbl_AccountConn_Status.TabIndex = 28;
            this.lbl_AccountConn_Status.Text = "PENDING";
            // 
            // btn_ConnectServer
            // 
            this.btn_ConnectServer.Location = new System.Drawing.Point(78, 220);
            this.btn_ConnectServer.Name = "btn_ConnectServer";
            this.btn_ConnectServer.Size = new System.Drawing.Size(637, 36);
            this.btn_ConnectServer.TabIndex = 29;
            this.btn_ConnectServer.Text = "Click here to get List of all Local Databases. Select Cocktail World 4.0 Database" +
    " below";
            this.btn_ConnectServer.UseVisualStyleBackColor = true;
            this.btn_ConnectServer.Click += new System.EventHandler(this.btb_ConnectServer_Click);
            // 
            // loadingImage
            // 
            this.loadingImage.InitialImage = global::eFacilito_CW_Migration_Utility.Properties.Resources.loading;
            this.loadingImage.Location = new System.Drawing.Point(348, 265);
            this.loadingImage.Name = "loadingImage";
            this.loadingImage.Size = new System.Drawing.Size(155, 140);
            this.loadingImage.TabIndex = 30;
            this.loadingImage.TabStop = false;
            // 
            // lbl_ValidationStatus
            // 
            this.lbl_ValidationStatus.BackColor = System.Drawing.Color.Yellow;
            this.lbl_ValidationStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ValidationStatus.Location = new System.Drawing.Point(12, 670);
            this.lbl_ValidationStatus.Name = "lbl_ValidationStatus";
            this.lbl_ValidationStatus.Size = new System.Drawing.Size(799, 35);
            this.lbl_ValidationStatus.TabIndex = 31;
            this.lbl_ValidationStatus.Text = "Validation Status";
            this.lbl_ValidationStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(27, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(758, 31);
            this.label14.TabIndex = 32;
            this.label14.Text = "Cocktail World 4.0 Migration Utility . Move your account to Cloud";
            // 
            // txt_CWAccount_CompanyCode
            // 
            this.txt_CWAccount_CompanyCode.Location = new System.Drawing.Point(223, 414);
            this.txt_CWAccount_CompanyCode.Name = "txt_CWAccount_CompanyCode";
            this.txt_CWAccount_CompanyCode.Size = new System.Drawing.Size(588, 26);
            this.txt_CWAccount_CompanyCode.TabIndex = 33;
            // 
            // CW_Migrate_Setup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 758);
            this.Controls.Add(this.txt_CWAccount_CompanyCode);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lbl_ValidationStatus);
            this.Controls.Add(this.btn_ConnectServer);
            this.Controls.Add(this.lbl_AccountConn_Status);
            this.Controls.Add(this.lbl_DBConnection_Status);
            this.Controls.Add(this.btn_ProceedMigration);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_CWAccount_Password);
            this.Controls.Add(this.txt_CWAccount_Username);
            this.Controls.Add(this.btn_Connect_CWAccount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txt_ServerPassword);
            this.Controls.Add(this.txt_ServerUsername);
            this.Controls.Add(this.ddl_cb_DatabaseList);
            this.Controls.Add(this.ddl_cb_Server_Name);
            this.Controls.Add(this.btn_Connect_CW_DB);
            this.Controls.Add(this.lbl_DB_Connection_Status);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loadingImage);
            this.Name = "CW_Migrate_Setup";
            this.Text = "CW_Migrate_Setup";
            this.Load += new System.EventHandler(this.CW_Migrate_Setup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_DB_Connection_Status;
        private System.Windows.Forms.Button btn_Connect_CW_DB;
        private System.Windows.Forms.ComboBox ddl_cb_Server_Name;
        private System.Windows.Forms.ComboBox ddl_cb_DatabaseList;
        private System.Windows.Forms.TextBox txt_ServerUsername;
        private System.Windows.Forms.TextBox txt_ServerPassword;
        private System.Windows.Forms.TextBox txt_CWAccount_Password;
        private System.Windows.Forms.TextBox txt_CWAccount_Username;
        private System.Windows.Forms.Button btn_Connect_CWAccount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_ProceedMigration;
        private System.Windows.Forms.Label lbl_DBConnection_Status;
        private System.Windows.Forms.Label lbl_AccountConn_Status;
        private System.Windows.Forms.Button btn_ConnectServer;
        private System.Windows.Forms.PictureBox loadingImage;
        private System.Windows.Forms.Label lbl_ValidationStatus;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txt_CWAccount_CompanyCode;
    }
}