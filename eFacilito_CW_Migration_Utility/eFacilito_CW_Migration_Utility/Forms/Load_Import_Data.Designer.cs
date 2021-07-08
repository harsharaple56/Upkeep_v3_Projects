namespace eFacilito_CW_Migration_Utility.Forms
{
    partial class Load_Import_Data
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
            this.dgv_Licenses = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.License_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.License_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_ViewLicenseData = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Licenses)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Licenses
            // 
            this.dgv_Licenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Licenses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.License_No,
            this.License_Name});
            this.dgv_Licenses.Location = new System.Drawing.Point(28, 70);
            this.dgv_Licenses.Name = "dgv_Licenses";
            this.dgv_Licenses.RowTemplate.Height = 28;
            this.dgv_Licenses.Size = new System.Drawing.Size(777, 423);
            this.dgv_Licenses.TabIndex = 0;
            // 
            // Select
            // 
            this.Select.DataPropertyName = "LicenseID";
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            // 
            // License_No
            // 
            this.License_No.DataPropertyName = "LicenseNo";
            this.License_No.HeaderText = "License No";
            this.License_No.Name = "License_No";
            // 
            // License_Name
            // 
            this.License_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.License_Name.DataPropertyName = "LicenseDesc";
            this.License_Name.HeaderText = "License Name";
            this.License_Name.Name = "License_Name";
            this.License_Name.Width = 134;
            // 
            // btn_ViewLicenseData
            // 
            this.btn_ViewLicenseData.Location = new System.Drawing.Point(263, 499);
            this.btn_ViewLicenseData.Name = "btn_ViewLicenseData";
            this.btn_ViewLicenseData.Size = new System.Drawing.Size(296, 34);
            this.btn_ViewLicenseData.TabIndex = 1;
            this.btn_ViewLicenseData.Text = "View Selected Licenses Data";
            this.btn_ViewLicenseData.UseVisualStyleBackColor = true;
            this.btn_ViewLicenseData.Click += new System.EventHandler(this.btn_ViewLicenseData_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(133, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(575, 34);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select the Licenses to Migrate to Cocktail World Web ( eFacilito )";
            // 
            // Load_Import_Data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 758);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_ViewLicenseData);
            this.Controls.Add(this.dgv_Licenses);
            this.Name = "Load_Import_Data";
            this.Text = "Load Import Data";
            this.Load += new System.EventHandler(this.Load_Import_Data_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Licenses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv_Licenses;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn License_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn License_Name;
        private System.Windows.Forms.Button btn_ViewLicenseData;
        private System.Windows.Forms.Label label2;
    }
}