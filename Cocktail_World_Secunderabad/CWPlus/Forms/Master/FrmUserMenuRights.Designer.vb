<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUserMenuRights
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.imgSave = New System.Windows.Forms.Button()
        Me.imgNew = New System.Windows.Forms.Button()
        Me.imgClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtHidden = New System.Windows.Forms.TextBox()
        Me.lblMenu = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.cmbMenu = New System.Windows.Forms.ComboBox()
        Me.cmbUserName = New System.Windows.Forms.ComboBox()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.grdUserLicense = New System.Windows.Forms.DataGridView()
        Me.LicenseDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sel = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.licenseID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblMenuDesc = New System.Windows.Forms.Label()
        Me.grdUSerMenuRights = New System.Windows.Forms.DataGridView()
        Me.Column4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.column3 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.lblUserLicense = New System.Windows.Forms.Label()
        Me.tltip = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.grdUserLicense, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdUSerMenuRights, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(854, 433)
        Me.SplitContainer1.SplitterDistance = 101
        Me.SplitContainer1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.imgSave)
        Me.Panel1.Controls.Add(Me.imgNew)
        Me.Panel1.Controls.Add(Me.imgClose)
        Me.Panel1.Location = New System.Drawing.Point(702, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(152, 51)
        Me.Panel1.TabIndex = 12
        '
        'imgSave
        '
        Me.imgSave.Image = Global.CWPlus.My.Resources.Resources.save
        Me.imgSave.Location = New System.Drawing.Point(3, 3)
        Me.imgSave.Name = "imgSave"
        Me.imgSave.Size = New System.Drawing.Size(44, 42)
        Me.imgSave.TabIndex = 5
        Me.tltip.SetToolTip(Me.imgSave, "Save")
        Me.imgSave.UseVisualStyleBackColor = True
        '
        'imgNew
        '
        Me.imgNew.Image = Global.CWPlus.My.Resources.Resources.window_new
        Me.imgNew.Location = New System.Drawing.Point(53, 3)
        Me.imgNew.Name = "imgNew"
        Me.imgNew.Size = New System.Drawing.Size(43, 42)
        Me.imgNew.TabIndex = 6
        Me.tltip.SetToolTip(Me.imgNew, "Add New")
        Me.imgNew.UseVisualStyleBackColor = True
        '
        'imgClose
        '
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(102, 3)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(45, 42)
        Me.imgClose.TabIndex = 7
        Me.tltip.SetToolTip(Me.imgClose, "Close")
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtHidden)
        Me.GroupBox1.Controls.Add(Me.lblMenu)
        Me.GroupBox1.Controls.Add(Me.lblUserName)
        Me.GroupBox1.Controls.Add(Me.cmbMenu)
        Me.GroupBox1.Controls.Add(Me.cmbUserName)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(226, 77)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "User Menu Rights"
        '
        'txtHidden
        '
        Me.txtHidden.Location = New System.Drawing.Point(231, 14)
        Me.txtHidden.Name = "txtHidden"
        Me.txtHidden.Size = New System.Drawing.Size(30, 21)
        Me.txtHidden.TabIndex = 6
        '
        'lblMenu
        '
        Me.lblMenu.AutoSize = True
        Me.lblMenu.Location = New System.Drawing.Point(17, 54)
        Me.lblMenu.Name = "lblMenu"
        Me.lblMenu.Size = New System.Drawing.Size(37, 13)
        Me.lblMenu.TabIndex = 4
        Me.lblMenu.Text = "Menu"
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Location = New System.Drawing.Point(5, 22)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(66, 13)
        Me.lblUserName.TabIndex = 3
        Me.lblUserName.Text = "UserName"
        '
        'cmbMenu
        '
        Me.cmbMenu.FormattingEnabled = True
        Me.cmbMenu.Location = New System.Drawing.Point(75, 51)
        Me.cmbMenu.Name = "cmbMenu"
        Me.cmbMenu.Size = New System.Drawing.Size(140, 21)
        Me.cmbMenu.TabIndex = 2
        '
        'cmbUserName
        '
        Me.cmbUserName.FormattingEnabled = True
        Me.cmbUserName.Location = New System.Drawing.Point(75, 19)
        Me.cmbUserName.Name = "cmbUserName"
        Me.cmbUserName.Size = New System.Drawing.Size(140, 21)
        Me.cmbUserName.TabIndex = 1
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.IsSplitterFixed = True
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.grdUserLicense)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblMenuDesc)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.grdUSerMenuRights)
        Me.SplitContainer2.Panel2.Controls.Add(Me.lblUserLicense)
        Me.SplitContainer2.Size = New System.Drawing.Size(854, 328)
        Me.SplitContainer2.SplitterDistance = 451
        Me.SplitContainer2.TabIndex = 0
        '
        'grdUserLicense
        '
        Me.grdUserLicense.AllowUserToAddRows = False
        Me.grdUserLicense.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdUserLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdUserLicense.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LicenseDesc, Me.sel, Me.licenseID})
        Me.grdUserLicense.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdUserLicense.GridColor = System.Drawing.Color.Black
        Me.grdUserLicense.Location = New System.Drawing.Point(0, 25)
        Me.grdUserLicense.Name = "grdUserLicense"
        Me.grdUserLicense.Size = New System.Drawing.Size(451, 303)
        Me.grdUserLicense.TabIndex = 3
        '
        'LicenseDesc
        '
        Me.LicenseDesc.HeaderText = "License"
        Me.LicenseDesc.Name = "LicenseDesc"
        '
        'sel
        '
        Me.sel.HeaderText = "Select"
        Me.sel.Name = "sel"
        '
        'licenseID
        '
        Me.licenseID.HeaderText = "licenseID"
        Me.licenseID.Name = "licenseID"
        '
        'lblMenuDesc
        '
        Me.lblMenuDesc.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblMenuDesc.Font = New System.Drawing.Font("Verdana", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMenuDesc.Location = New System.Drawing.Point(0, 0)
        Me.lblMenuDesc.Name = "lblMenuDesc"
        Me.lblMenuDesc.Size = New System.Drawing.Size(451, 25)
        Me.lblMenuDesc.TabIndex = 9
        Me.lblMenuDesc.Text = "LICENSE"
        Me.lblMenuDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grdUSerMenuRights
        '
        Me.grdUSerMenuRights.AllowDrop = True
        Me.grdUSerMenuRights.AllowUserToAddRows = False
        Me.grdUSerMenuRights.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdUSerMenuRights.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdUSerMenuRights.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdUSerMenuRights.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdUSerMenuRights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdUSerMenuRights.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column4, Me.Column1, Me.Column2, Me.column3})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdUSerMenuRights.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdUSerMenuRights.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdUSerMenuRights.GridColor = System.Drawing.Color.Black
        Me.grdUSerMenuRights.Location = New System.Drawing.Point(0, 25)
        Me.grdUSerMenuRights.Name = "grdUSerMenuRights"
        Me.grdUSerMenuRights.Size = New System.Drawing.Size(399, 303)
        Me.grdUSerMenuRights.TabIndex = 4
        '
        'Column4
        '
        Me.Column4.HeaderText = "Check All"
        Me.Column4.Name = "Column4"
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column4.ToolTipText = "u"
        '
        'Column1
        '
        Me.Column1.HeaderText = "New"
        Me.Column1.Name = "Column1"
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Column2
        '
        Me.Column2.HeaderText = "Edit"
        Me.Column2.Name = "Column2"
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'column3
        '
        Me.column3.HeaderText = "Delete"
        Me.column3.Name = "column3"
        Me.column3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'lblUserLicense
        '
        Me.lblUserLicense.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblUserLicense.Font = New System.Drawing.Font("Verdana", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserLicense.Location = New System.Drawing.Point(0, 0)
        Me.lblUserLicense.Name = "lblUserLicense"
        Me.lblUserLicense.Size = New System.Drawing.Size(399, 25)
        Me.lblUserLicense.TabIndex = 2
        Me.lblUserLicense.Text = "MENU"
        Me.lblUserLicense.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'tltip
        '
        Me.tltip.IsBalloon = True
        '
        'FrmUserMenuRights
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(854, 433)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FrmUserMenuRights"
        Me.Text = "FrmUserMenuRights"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.grdUserLicense, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdUSerMenuRights, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblMenu As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents cmbMenu As System.Windows.Forms.ComboBox
    Friend WithEvents cmbUserName As System.Windows.Forms.ComboBox
    Friend WithEvents txtHidden As System.Windows.Forms.TextBox
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblUserLicense As System.Windows.Forms.Label
    Friend WithEvents grdUserLicense As System.Windows.Forms.DataGridView
    Friend WithEvents LicenseDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sel As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents licenseID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents imgSave As System.Windows.Forms.Button
    Friend WithEvents imgNew As System.Windows.Forms.Button
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents tltip As System.Windows.Forms.ToolTip
    Friend WithEvents lblMenuDesc As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grdUSerMenuRights As System.Windows.Forms.DataGridView
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents column3 As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
