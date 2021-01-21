<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMigration_cw2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbVersion = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtDate = New System.Windows.Forms.DateTimePicker()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cmbDataBase = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.grdCocktailBrand = New System.Windows.Forms.DataGridView()
        Me.grdLicenseMst = New System.Windows.Forms.DataGridView()
        Me.LicenseID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LicenseNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LicenseDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnSetOpening = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Edit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.grdCocktailBrand, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdLicenseMst, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbVersion)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DtDate)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.cmbDataBase)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(460, 147)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Connection Settings"
        '
        'cmbVersion
        '
        Me.cmbVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVersion.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.cmbVersion.FormattingEnabled = True
        Me.cmbVersion.Items.AddRange(New Object() {"--Select--", "CW 2.0", "CW 3.0"})
        Me.cmbVersion.Location = New System.Drawing.Point(149, 22)
        Me.cmbVersion.Name = "cmbVersion"
        Me.cmbVersion.Size = New System.Drawing.Size(246, 23)
        Me.cmbVersion.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(60, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 17)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "From Version"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(60, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 17)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Date"
        '
        'DtDate
        '
        Me.DtDate.CustomFormat = "dd-MMM-yyy"
        Me.DtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtDate.Location = New System.Drawing.Point(149, 51)
        Me.DtDate.Name = "DtDate"
        Me.DtDate.Size = New System.Drawing.Size(129, 27)
        Me.DtDate.TabIndex = 9
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.btnSave.Location = New System.Drawing.Point(149, 113)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(225, 28)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "Connect && Transfer Master"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'cmbDataBase
        '
        Me.cmbDataBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDataBase.Enabled = False
        Me.cmbDataBase.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.cmbDataBase.FormattingEnabled = True
        Me.cmbDataBase.Location = New System.Drawing.Point(149, 84)
        Me.cmbDataBase.Name = "cmbDataBase"
        Me.cmbDataBase.Size = New System.Drawing.Size(246, 23)
        Me.cmbDataBase.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label4.Location = New System.Drawing.Point(60, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 17)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Database"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdCocktailBrand)
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdLicenseMst)
        Me.SplitContainer1.Size = New System.Drawing.Size(937, 468)
        Me.SplitContainer1.SplitterDistance = 164
        Me.SplitContainer1.TabIndex = 2
        '
        'grdCocktailBrand
        '
        Me.grdCocktailBrand.AllowUserToAddRows = False
        Me.grdCocktailBrand.AllowUserToDeleteRows = False
        Me.grdCocktailBrand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCocktailBrand.Location = New System.Drawing.Point(565, 0)
        Me.grdCocktailBrand.Name = "grdCocktailBrand"
        Me.grdCocktailBrand.ReadOnly = True
        Me.grdCocktailBrand.Size = New System.Drawing.Size(369, 321)
        Me.grdCocktailBrand.TabIndex = 3
        '
        'grdLicenseMst
        '
        Me.grdLicenseMst.AllowUserToAddRows = False
        Me.grdLicenseMst.AllowUserToDeleteRows = False
        Me.grdLicenseMst.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdLicenseMst.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdLicenseMst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdLicenseMst.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LicenseID, Me.LicenseNo, Me.LicenseDesc, Me.BtnSetOpening, Me.Edit})
        Me.grdLicenseMst.GridColor = System.Drawing.Color.WhiteSmoke
        Me.grdLicenseMst.Location = New System.Drawing.Point(0, 0)
        Me.grdLicenseMst.Name = "grdLicenseMst"
        Me.grdLicenseMst.ReadOnly = True
        Me.grdLicenseMst.Size = New System.Drawing.Size(562, 321)
        Me.grdLicenseMst.TabIndex = 2
        '
        'LicenseID
        '
        Me.LicenseID.HeaderText = "LicenseID"
        Me.LicenseID.Name = "LicenseID"
        Me.LicenseID.ReadOnly = True
        '
        'LicenseNo
        '
        Me.LicenseNo.HeaderText = "License Number"
        Me.LicenseNo.Name = "LicenseNo"
        Me.LicenseNo.ReadOnly = True
        '
        'LicenseDesc
        '
        Me.LicenseDesc.HeaderText = "License Name"
        Me.LicenseDesc.Name = "LicenseDesc"
        Me.LicenseDesc.ReadOnly = True
        '
        'BtnSetOpening
        '
        Me.BtnSetOpening.HeaderText = "Set Opening Stock"
        Me.BtnSetOpening.Name = "BtnSetOpening"
        Me.BtnSetOpening.ReadOnly = True
        Me.BtnSetOpening.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.BtnSetOpening.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.BtnSetOpening.Text = "Set Opening Stock"
        Me.BtnSetOpening.UseColumnTextForButtonValue = True
        '
        'Edit
        '
        Me.Edit.HeaderText = "View Brands"
        Me.Edit.Name = "Edit"
        Me.Edit.ReadOnly = True
        Me.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Edit.Text = "View Brands"
        Me.Edit.UseColumnTextForButtonValue = True
        '
        'FrmMigration_cw2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(937, 468)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmMigration_cw2"
        Me.Text = "FrmMigration_cw2"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.grdCocktailBrand, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdLicenseMst, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents cmbDataBase As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents grdLicenseMst As System.Windows.Forms.DataGridView
    Friend WithEvents LicenseID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LicenseNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LicenseDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnSetOpening As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Edit As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents grdCocktailBrand As System.Windows.Forms.DataGridView
    Friend WithEvents cmbVersion As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
