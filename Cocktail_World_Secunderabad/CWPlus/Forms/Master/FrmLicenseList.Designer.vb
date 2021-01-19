<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLicenseList
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.imgSave = New System.Windows.Forms.Button()
        Me.btnImportLicenseKey = New System.Windows.Forms.Button()
        Me.imgNew = New System.Windows.Forms.Button()
        Me.imgClose = New System.Windows.Forms.Button()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.grdLicenseMst = New System.Windows.Forms.DataGridView()
        Me.Store = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.IsRack = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ForFL3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fzdate = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Edit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.FreezDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LicenseID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LicenseDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LicenseNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Add1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Add2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.City = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pincode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Telephone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bst = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cst = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtMMSCode = New System.Windows.Forms.TextBox()
        Me.lblOutLet = New System.Windows.Forms.Label()
        Me.txtOutLet = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAddRow = New System.Windows.Forms.Button()
        Me.lblLicenseCode = New System.Windows.Forms.Label()
        Me.txtLicenseCode = New System.Windows.Forms.TextBox()
        Me.grdLicenseCode = New System.Windows.Forms.DataGridView()
        Me.LicenseCodeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LicenseID1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LicenseCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Outlet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MMSCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tltip = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.grdLicenseMst, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdLicenseCode, System.ComponentModel.ISupportInitialize).BeginInit()
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
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(990, 636)
        Me.SplitContainer1.SplitterDistance = 73
        Me.SplitContainer1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.imgSave)
        Me.Panel1.Controls.Add(Me.btnImportLicenseKey)
        Me.Panel1.Controls.Add(Me.imgNew)
        Me.Panel1.Controls.Add(Me.imgClose)
        Me.Panel1.Location = New System.Drawing.Point(790, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(203, 45)
        Me.Panel1.TabIndex = 12
        '
        'imgSave
        '
        Me.imgSave.Image = Global.CWPlus.My.Resources.Resources.save
        Me.imgSave.Location = New System.Drawing.Point(103, 6)
        Me.imgSave.Name = "imgSave"
        Me.imgSave.Size = New System.Drawing.Size(42, 40)
        Me.imgSave.TabIndex = 7
        Me.tltip.SetToolTip(Me.imgSave, "Save")
        Me.imgSave.UseVisualStyleBackColor = True
        '
        'btnImportLicenseKey
        '
        Me.btnImportLicenseKey.Image = Global.CWPlus.My.Resources.Resources.import1
        Me.btnImportLicenseKey.Location = New System.Drawing.Point(52, 6)
        Me.btnImportLicenseKey.Name = "btnImportLicenseKey"
        Me.btnImportLicenseKey.Size = New System.Drawing.Size(45, 39)
        Me.btnImportLicenseKey.TabIndex = 6
        Me.tltip.SetToolTip(Me.btnImportLicenseKey, "Import")
        Me.btnImportLicenseKey.UseVisualStyleBackColor = True
        '
        'imgNew
        '
        Me.imgNew.Image = Global.CWPlus.My.Resources.Resources.window_new
        Me.imgNew.Location = New System.Drawing.Point(3, 4)
        Me.imgNew.Name = "imgNew"
        Me.imgNew.Size = New System.Drawing.Size(43, 40)
        Me.imgNew.TabIndex = 8
        Me.tltip.SetToolTip(Me.imgNew, "Add New")
        Me.imgNew.UseVisualStyleBackColor = True
        '
        'imgClose
        '
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(151, 6)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(41, 40)
        Me.imgClose.TabIndex = 9
        Me.tltip.SetToolTip(Me.imgClose, "Close")
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.grdLicenseMst)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer2.Size = New System.Drawing.Size(990, 559)
        Me.SplitContainer2.SplitterDistance = 243
        Me.SplitContainer2.TabIndex = 0
        '
        'grdLicenseMst
        '
        Me.grdLicenseMst.AllowUserToAddRows = False
        Me.grdLicenseMst.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdLicenseMst.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdLicenseMst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdLicenseMst.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Store, Me.IsRack, Me.ForFL3, Me.fzdate, Me.Edit, Me.FreezDate, Me.LicenseID, Me.LicenseDesc, Me.LicenseNo, Me.Add1, Me.Add2, Me.City, Me.Pincode, Me.Telephone, Me.Email, Me.Bst, Me.Cst})
        Me.grdLicenseMst.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdLicenseMst.GridColor = System.Drawing.Color.WhiteSmoke
        Me.grdLicenseMst.Location = New System.Drawing.Point(0, 0)
        Me.grdLicenseMst.Name = "grdLicenseMst"
        Me.grdLicenseMst.ReadOnly = True
        Me.grdLicenseMst.Size = New System.Drawing.Size(990, 243)
        Me.grdLicenseMst.TabIndex = 1
        '
        'Store
        '
        Me.Store.HeaderText = "Store"
        Me.Store.Name = "Store"
        Me.Store.ReadOnly = True
        '
        'IsRack
        '
        Me.IsRack.HeaderText = "IsRack"
        Me.IsRack.Name = "IsRack"
        Me.IsRack.ReadOnly = True
        '
        'ForFL3
        '
        Me.ForFL3.HeaderText = "ForFL3"
        Me.ForFL3.Name = "ForFL3"
        Me.ForFL3.ReadOnly = True
        '
        'fzdate
        '
        Me.fzdate.HeaderText = "Fz.Date"
        Me.fzdate.Name = "fzdate"
        Me.fzdate.ReadOnly = True
        Me.fzdate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.fzdate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.fzdate.Text = "Fz.Date"
        Me.fzdate.UseColumnTextForButtonValue = True
        '
        'Edit
        '
        Me.Edit.HeaderText = "Edit"
        Me.Edit.Name = "Edit"
        Me.Edit.ReadOnly = True
        Me.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Edit.Text = "Edit"
        Me.Edit.UseColumnTextForButtonValue = True
        '
        'FreezDate
        '
        Me.FreezDate.HeaderText = "FreezDate"
        Me.FreezDate.Name = "FreezDate"
        Me.FreezDate.ReadOnly = True
        '
        'LicenseID
        '
        Me.LicenseID.HeaderText = "LicenseID"
        Me.LicenseID.Name = "LicenseID"
        Me.LicenseID.ReadOnly = True
        '
        'LicenseDesc
        '
        Me.LicenseDesc.HeaderText = "License Name"
        Me.LicenseDesc.Name = "LicenseDesc"
        Me.LicenseDesc.ReadOnly = True
        '
        'LicenseNo
        '
        Me.LicenseNo.HeaderText = "License Number"
        Me.LicenseNo.Name = "LicenseNo"
        Me.LicenseNo.ReadOnly = True
        '
        'Add1
        '
        Me.Add1.HeaderText = "Address 1"
        Me.Add1.Name = "Add1"
        Me.Add1.ReadOnly = True
        '
        'Add2
        '
        Me.Add2.HeaderText = "Address 2"
        Me.Add2.Name = "Add2"
        Me.Add2.ReadOnly = True
        '
        'City
        '
        Me.City.HeaderText = "City"
        Me.City.Name = "City"
        Me.City.ReadOnly = True
        '
        'Pincode
        '
        Me.Pincode.HeaderText = "Pincode"
        Me.Pincode.Name = "Pincode"
        Me.Pincode.ReadOnly = True
        '
        'Telephone
        '
        Me.Telephone.HeaderText = "Telephone"
        Me.Telephone.Name = "Telephone"
        Me.Telephone.ReadOnly = True
        '
        'Email
        '
        Me.Email.HeaderText = "Email"
        Me.Email.Name = "Email"
        Me.Email.ReadOnly = True
        '
        'Bst
        '
        Me.Bst.HeaderText = "Bst"
        Me.Bst.Name = "Bst"
        Me.Bst.ReadOnly = True
        '
        'Cst
        '
        Me.Cst.HeaderText = "Cst"
        Me.Cst.Name = "Cst"
        Me.Cst.ReadOnly = True
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.grdLicenseCode)
        Me.SplitContainer3.Size = New System.Drawing.Size(990, 312)
        Me.SplitContainer3.SplitterDistance = 64
        Me.SplitContainer3.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtMMSCode)
        Me.GroupBox1.Controls.Add(Me.lblOutLet)
        Me.GroupBox1.Controls.Add(Me.txtOutLet)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnAddRow)
        Me.GroupBox1.Controls.Add(Me.lblLicenseCode)
        Me.GroupBox1.Controls.Add(Me.txtLicenseCode)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(569, 50)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Set License"
        '
        'txtMMSCode
        '
        Me.txtMMSCode.Location = New System.Drawing.Point(256, 21)
        Me.txtMMSCode.Name = "txtMMSCode"
        Me.txtMMSCode.Size = New System.Drawing.Size(100, 20)
        Me.txtMMSCode.TabIndex = 6
        '
        'lblOutLet
        '
        Me.lblOutLet.AutoSize = True
        Me.lblOutLet.Location = New System.Drawing.Point(362, 24)
        Me.lblOutLet.Name = "lblOutLet"
        Me.lblOutLet.Size = New System.Drawing.Size(35, 13)
        Me.lblOutLet.TabIndex = 3
        Me.lblOutLet.Text = "Outlet"
        '
        'txtOutLet
        '
        Me.txtOutLet.Location = New System.Drawing.Point(403, 21)
        Me.txtOutLet.Name = "txtOutLet"
        Me.txtOutLet.Size = New System.Drawing.Size(100, 20)
        Me.txtOutLet.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(190, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "MMS Code"
        '
        'btnAddRow
        '
        Me.btnAddRow.Image = Global.CWPlus.My.Resources.Resources.edit_add__1_
        Me.btnAddRow.Location = New System.Drawing.Point(523, 14)
        Me.btnAddRow.Name = "btnAddRow"
        Me.btnAddRow.Size = New System.Drawing.Size(40, 32)
        Me.btnAddRow.TabIndex = 4
        Me.tltip.SetToolTip(Me.btnAddRow, "Add")
        Me.btnAddRow.UseVisualStyleBackColor = True
        '
        'lblLicenseCode
        '
        Me.lblLicenseCode.AutoSize = True
        Me.lblLicenseCode.Location = New System.Drawing.Point(6, 24)
        Me.lblLicenseCode.Name = "lblLicenseCode"
        Me.lblLicenseCode.Size = New System.Drawing.Size(72, 13)
        Me.lblLicenseCode.TabIndex = 0
        Me.lblLicenseCode.Text = "License Code"
        '
        'txtLicenseCode
        '
        Me.txtLicenseCode.Location = New System.Drawing.Point(84, 21)
        Me.txtLicenseCode.Name = "txtLicenseCode"
        Me.txtLicenseCode.Size = New System.Drawing.Size(100, 20)
        Me.txtLicenseCode.TabIndex = 2
        '
        'grdLicenseCode
        '
        Me.grdLicenseCode.AllowDrop = True
        Me.grdLicenseCode.AllowUserToAddRows = False
        Me.grdLicenseCode.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdLicenseCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdLicenseCode.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LicenseCodeID, Me.LicenseID1, Me.LicenseCode, Me.Outlet, Me.MMSCode})
        Me.grdLicenseCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdLicenseCode.Location = New System.Drawing.Point(0, 0)
        Me.grdLicenseCode.Name = "grdLicenseCode"
        Me.grdLicenseCode.Size = New System.Drawing.Size(990, 244)
        Me.grdLicenseCode.TabIndex = 5
        '
        'LicenseCodeID
        '
        Me.LicenseCodeID.HeaderText = "LicenseCodeID"
        Me.LicenseCodeID.Name = "LicenseCodeID"
        '
        'LicenseID1
        '
        Me.LicenseID1.HeaderText = "LicenseID"
        Me.LicenseID1.Name = "LicenseID1"
        '
        'LicenseCode
        '
        Me.LicenseCode.HeaderText = "LicenseCode"
        Me.LicenseCode.Name = "LicenseCode"
        '
        'Outlet
        '
        Me.Outlet.HeaderText = "OutLet"
        Me.Outlet.Name = "Outlet"
        '
        'MMSCode
        '
        Me.MMSCode.HeaderText = "MMSCode"
        Me.MMSCode.Name = "MMSCode"
        '
        'tltip
        '
        Me.tltip.IsBalloon = True
        '
        'FrmLicenseList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(990, 636)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Name = "FrmLicenseList"
        Me.Text = "FrmLicenseList"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.grdLicenseMst, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdLicenseCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents grdLicenseMst As System.Windows.Forms.DataGridView
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAddRow As System.Windows.Forms.Button
    Friend WithEvents txtOutLet As System.Windows.Forms.TextBox
    Friend WithEvents lblLicenseCode As System.Windows.Forms.Label
    Friend WithEvents txtLicenseCode As System.Windows.Forms.TextBox
    Friend WithEvents lblOutLet As System.Windows.Forms.Label
    Friend WithEvents grdLicenseCode As System.Windows.Forms.DataGridView
    Friend WithEvents btnImportLicenseKey As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents imgSave As System.Windows.Forms.Button
    Friend WithEvents imgNew As System.Windows.Forms.Button
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents tltip As System.Windows.Forms.ToolTip
    Friend WithEvents Store As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents IsRack As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ForFL3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fzdate As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Edit As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents FreezDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LicenseID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LicenseDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LicenseNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Add1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Add2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents City As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pincode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Telephone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Email As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bst As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cst As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtMMSCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LicenseCodeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LicenseID1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LicenseCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Outlet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MMSCode As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
