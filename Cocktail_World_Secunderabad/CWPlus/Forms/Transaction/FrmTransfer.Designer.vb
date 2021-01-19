<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTransfer
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
        Me.btnCallEvent = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.imgSave = New System.Windows.Forms.Button()
        Me.imgClose = New System.Windows.Forms.Button()
        Me.grdTransferDetails = New System.Windows.Forms.GroupBox()
        Me.lblBrandDetailsLable = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtTransferDetailTPno = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblBrandName = New System.Windows.Forms.Label()
        Me.cmbAgainst = New System.Windows.Forms.ComboBox()
        Me.cmbBrandName = New System.Windows.Forms.ComboBox()
        Me.cmbSize = New System.Windows.Forms.ComboBox()
        Me.grdTransferHead = New System.Windows.Forms.GroupBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.lbladdress = New System.Windows.Forms.Label()
        Me.cmbDept = New System.Windows.Forms.ComboBox()
        Me.chkShowExcise = New System.Windows.Forms.CheckBox()
        Me.lblFl4 = New System.Windows.Forms.Label()
        Me.lblTransferHeadID = New System.Windows.Forms.Label()
        Me.lblLicenseID = New System.Windows.Forms.Label()
        Me.lbl = New System.Windows.Forms.Label()
        Me.lblTPno = New System.Windows.Forms.Label()
        Me.txtFLIV = New System.Windows.Forms.TextBox()
        Me.txtInvoiceNo = New System.Windows.Forms.TextBox()
        Me.dtpTransferHead = New System.Windows.Forms.DateTimePicker()
        Me.cmbLicense = New System.Windows.Forms.ComboBox()
        Me.txtTransferHeadTPNo = New System.Windows.Forms.TextBox()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.mnuTransfer = New System.Windows.Forms.MenuStrip()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.grdTransfer = New System.Windows.Forms.DataGridView()
        Me.brandopeningid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.brandname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Against = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TPno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Batch = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mfg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Box = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.spegqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.spegrate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bottleqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bottlerate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ForbrandopningId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BoxHideQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ttlp = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.grdTransferDetails.SuspendLayout()
        Me.grdTransferHead.SuspendLayout()
        Me.mnuTransfer.SuspendLayout()
        CType(Me.grdTransfer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnCallEvent)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grdTransferDetails)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grdTransferHead)
        Me.SplitContainer1.Panel1.Controls.Add(Me.mnuTransfer)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdTransfer)
        Me.SplitContainer1.Size = New System.Drawing.Size(1287, 482)
        Me.SplitContainer1.SplitterDistance = 206
        Me.SplitContainer1.TabIndex = 0
        '
        'btnCallEvent
        '
        Me.btnCallEvent.Image = Global.CWPlus.My.Resources.Resources.edit_add__1_
        Me.btnCallEvent.Location = New System.Drawing.Point(733, 16)
        Me.btnCallEvent.Name = "btnCallEvent"
        Me.btnCallEvent.Size = New System.Drawing.Size(47, 28)
        Me.btnCallEvent.TabIndex = 14
        Me.ttlp.SetToolTip(Me.btnCallEvent, "Add ")
        Me.btnCallEvent.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.imgSave)
        Me.Panel1.Controls.Add(Me.imgClose)
        Me.Panel1.Location = New System.Drawing.Point(1184, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(103, 54)
        Me.Panel1.TabIndex = 0
        '
        'imgSave
        '
        Me.imgSave.Image = Global.CWPlus.My.Resources.Resources.save
        Me.imgSave.Location = New System.Drawing.Point(3, 3)
        Me.imgSave.Name = "imgSave"
        Me.imgSave.Size = New System.Drawing.Size(43, 44)
        Me.imgSave.TabIndex = 13
        Me.ttlp.SetToolTip(Me.imgSave, "Save")
        Me.imgSave.UseVisualStyleBackColor = True
        '
        'imgClose
        '
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(51, 3)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(40, 44)
        Me.imgClose.TabIndex = 14
        Me.ttlp.SetToolTip(Me.imgClose, "Close")
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'grdTransferDetails
        '
        Me.grdTransferDetails.Controls.Add(Me.lblBrandDetailsLable)
        Me.grdTransferDetails.Controls.Add(Me.btnAdd)
        Me.grdTransferDetails.Controls.Add(Me.txtTransferDetailTPno)
        Me.grdTransferDetails.Controls.Add(Me.Label4)
        Me.grdTransferDetails.Controls.Add(Me.lblSize)
        Me.grdTransferDetails.Controls.Add(Me.Label2)
        Me.grdTransferDetails.Controls.Add(Me.lblBrandName)
        Me.grdTransferDetails.Controls.Add(Me.cmbAgainst)
        Me.grdTransferDetails.Controls.Add(Me.cmbBrandName)
        Me.grdTransferDetails.Controls.Add(Me.cmbSize)
        Me.grdTransferDetails.Location = New System.Drawing.Point(12, 119)
        Me.grdTransferDetails.Name = "grdTransferDetails"
        Me.grdTransferDetails.Size = New System.Drawing.Size(698, 82)
        Me.grdTransferDetails.TabIndex = 1
        Me.grdTransferDetails.TabStop = False
        Me.grdTransferDetails.Text = "Brand Details"
        '
        'lblBrandDetailsLable
        '
        Me.lblBrandDetailsLable.AutoSize = True
        Me.lblBrandDetailsLable.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBrandDetailsLable.Location = New System.Drawing.Point(546, 49)
        Me.lblBrandDetailsLable.Name = "lblBrandDetailsLable"
        Me.lblBrandDetailsLable.Size = New System.Drawing.Size(0, 19)
        Me.lblBrandDetailsLable.TabIndex = 12
        '
        'btnAdd
        '
        Me.btnAdd.Image = Global.CWPlus.My.Resources.Resources.edit_add__1_
        Me.btnAdd.Location = New System.Drawing.Point(477, 46)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(47, 28)
        Me.btnAdd.TabIndex = 11
        Me.ttlp.SetToolTip(Me.btnAdd, "Add ")
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtTransferDetailTPno
        '
        Me.txtTransferDetailTPno.Location = New System.Drawing.Point(329, 46)
        Me.txtTransferDetailTPno.Name = "txtTransferDetailTPno"
        Me.txtTransferDetailTPno.Size = New System.Drawing.Size(140, 20)
        Me.txtTransferDetailTPno.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(287, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "TP no"
        '
        'lblSize
        '
        Me.lblSize.AutoSize = True
        Me.lblSize.Location = New System.Drawing.Point(475, 22)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(27, 13)
        Me.lblSize.TabIndex = 0
        Me.lblSize.Text = "Size"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Against "
        '
        'lblBrandName
        '
        Me.lblBrandName.AutoSize = True
        Me.lblBrandName.Location = New System.Drawing.Point(6, 22)
        Me.lblBrandName.Name = "lblBrandName"
        Me.lblBrandName.Size = New System.Drawing.Size(63, 13)
        Me.lblBrandName.TabIndex = 0
        Me.lblBrandName.Text = "BrandName"
        '
        'cmbAgainst
        '
        Me.cmbAgainst.FormattingEnabled = True
        Me.cmbAgainst.Location = New System.Drawing.Point(71, 46)
        Me.cmbAgainst.Name = "cmbAgainst"
        Me.cmbAgainst.Size = New System.Drawing.Size(200, 21)
        Me.cmbAgainst.TabIndex = 9
        '
        'cmbBrandName
        '
        Me.cmbBrandName.FormattingEnabled = True
        Me.cmbBrandName.Location = New System.Drawing.Point(71, 19)
        Me.cmbBrandName.Name = "cmbBrandName"
        Me.cmbBrandName.Size = New System.Drawing.Size(398, 21)
        Me.cmbBrandName.TabIndex = 7
        '
        'cmbSize
        '
        Me.cmbSize.FormattingEnabled = True
        Me.cmbSize.Location = New System.Drawing.Point(508, 19)
        Me.cmbSize.Name = "cmbSize"
        Me.cmbSize.Size = New System.Drawing.Size(68, 21)
        Me.cmbSize.TabIndex = 8
        '
        'grdTransferHead
        '
        Me.grdTransferHead.Controls.Add(Me.txtAddress)
        Me.grdTransferHead.Controls.Add(Me.lbladdress)
        Me.grdTransferHead.Controls.Add(Me.cmbDept)
        Me.grdTransferHead.Controls.Add(Me.chkShowExcise)
        Me.grdTransferHead.Controls.Add(Me.lblFl4)
        Me.grdTransferHead.Controls.Add(Me.lblTransferHeadID)
        Me.grdTransferHead.Controls.Add(Me.lblLicenseID)
        Me.grdTransferHead.Controls.Add(Me.lbl)
        Me.grdTransferHead.Controls.Add(Me.lblTPno)
        Me.grdTransferHead.Controls.Add(Me.txtFLIV)
        Me.grdTransferHead.Controls.Add(Me.txtInvoiceNo)
        Me.grdTransferHead.Controls.Add(Me.dtpTransferHead)
        Me.grdTransferHead.Controls.Add(Me.cmbLicense)
        Me.grdTransferHead.Controls.Add(Me.txtTransferHeadTPNo)
        Me.grdTransferHead.Controls.Add(Me.lblDate)
        Me.grdTransferHead.Location = New System.Drawing.Point(12, 6)
        Me.grdTransferHead.Name = "grdTransferHead"
        Me.grdTransferHead.Size = New System.Drawing.Size(698, 107)
        Me.grdTransferHead.TabIndex = 0
        Me.grdTransferHead.TabStop = False
        Me.grdTransferHead.Text = "Transfer"
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(77, 83)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(200, 20)
        Me.txtAddress.TabIndex = 12
        Me.txtAddress.Visible = False
        '
        'lbladdress
        '
        Me.lbladdress.AutoSize = True
        Me.lbladdress.Location = New System.Drawing.Point(4, 86)
        Me.lbladdress.Name = "lbladdress"
        Me.lbladdress.Size = New System.Drawing.Size(70, 13)
        Me.lbladdress.TabIndex = 11
        Me.lbladdress.Text = "FLIV Address"
        '
        'cmbDept
        '
        Me.cmbDept.FormattingEnabled = True
        Me.cmbDept.Location = New System.Drawing.Point(349, 60)
        Me.cmbDept.Name = "cmbDept"
        Me.cmbDept.Size = New System.Drawing.Size(197, 21)
        Me.cmbDept.TabIndex = 6
        Me.cmbDept.Visible = False
        '
        'chkShowExcise
        '
        Me.chkShowExcise.AutoSize = True
        Me.chkShowExcise.Checked = True
        Me.chkShowExcise.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowExcise.Location = New System.Drawing.Point(347, 40)
        Me.chkShowExcise.Name = "chkShowExcise"
        Me.chkShowExcise.Size = New System.Drawing.Size(98, 17)
        Me.chkShowExcise.TabIndex = 4
        Me.chkShowExcise.Text = "Show in Excise"
        Me.chkShowExcise.UseVisualStyleBackColor = True
        '
        'lblFl4
        '
        Me.lblFl4.AutoSize = True
        Me.lblFl4.Location = New System.Drawing.Point(37, 62)
        Me.lblFl4.Name = "lblFl4"
        Me.lblFl4.Size = New System.Drawing.Size(32, 13)
        Me.lblFl4.TabIndex = 8
        Me.lblFl4.Text = "FL IV"
        '
        'lblTransferHeadID
        '
        Me.lblTransferHeadID.AutoSize = True
        Me.lblTransferHeadID.Location = New System.Drawing.Point(262, 10)
        Me.lblTransferHeadID.Name = "lblTransferHeadID"
        Me.lblTransferHeadID.Size = New System.Drawing.Size(13, 13)
        Me.lblTransferHeadID.TabIndex = 2
        Me.lblTransferHeadID.Text = "0"
        Me.lblTransferHeadID.Visible = False
        '
        'lblLicenseID
        '
        Me.lblLicenseID.AutoSize = True
        Me.lblLicenseID.Location = New System.Drawing.Point(281, 62)
        Me.lblLicenseID.Name = "lblLicenseID"
        Me.lblLicenseID.Size = New System.Drawing.Size(62, 13)
        Me.lblLicenseID.TabIndex = 10
        Me.lblLicenseID.Text = "For License"
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.Location = New System.Drawing.Point(14, 39)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(59, 13)
        Me.lbl.TabIndex = 0
        Me.lbl.Text = "Invoice No"
        '
        'lblTPno
        '
        Me.lblTPno.AutoSize = True
        Me.lblTPno.Location = New System.Drawing.Point(303, 16)
        Me.lblTPno.Name = "lblTPno"
        Me.lblTPno.Size = New System.Drawing.Size(38, 13)
        Me.lblTPno.TabIndex = 0
        Me.lblTPno.Text = "TP No"
        '
        'txtFLIV
        '
        Me.txtFLIV.Location = New System.Drawing.Point(75, 59)
        Me.txtFLIV.Name = "txtFLIV"
        Me.txtFLIV.Size = New System.Drawing.Size(200, 20)
        Me.txtFLIV.TabIndex = 5
        '
        'txtInvoiceNo
        '
        Me.txtInvoiceNo.Location = New System.Drawing.Point(75, 36)
        Me.txtInvoiceNo.Name = "txtInvoiceNo"
        Me.txtInvoiceNo.Size = New System.Drawing.Size(200, 20)
        Me.txtInvoiceNo.TabIndex = 3
        '
        'dtpTransferHead
        '
        Me.dtpTransferHead.CustomFormat = "dd-MMM-yyyy"
        Me.dtpTransferHead.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTransferHead.Location = New System.Drawing.Point(75, 10)
        Me.dtpTransferHead.Name = "dtpTransferHead"
        Me.dtpTransferHead.Size = New System.Drawing.Size(108, 20)
        Me.dtpTransferHead.TabIndex = 1
        '
        'cmbLicense
        '
        Me.cmbLicense.FormattingEnabled = True
        Me.cmbLicense.Location = New System.Drawing.Point(347, 62)
        Me.cmbLicense.Name = "cmbLicense"
        Me.cmbLicense.Size = New System.Drawing.Size(200, 21)
        Me.cmbLicense.TabIndex = 2
        '
        'txtTransferHeadTPNo
        '
        Me.txtTransferHeadTPNo.Location = New System.Drawing.Point(347, 13)
        Me.txtTransferHeadTPNo.Name = "txtTransferHeadTPNo"
        Me.txtTransferHeadTPNo.Size = New System.Drawing.Size(200, 20)
        Me.txtTransferHeadTPNo.TabIndex = 2
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(39, 16)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(30, 13)
        Me.lblDate.TabIndex = 0
        Me.lblDate.Text = "Date"
        '
        'mnuTransfer
        '
        Me.mnuTransfer.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.AddToolStripMenuItem})
        Me.mnuTransfer.Location = New System.Drawing.Point(0, 0)
        Me.mnuTransfer.Name = "mnuTransfer"
        Me.mnuTransfer.Size = New System.Drawing.Size(1287, 24)
        Me.mnuTransfer.TabIndex = 13
        Me.mnuTransfer.Text = "MenuStrip1"
        Me.mnuTransfer.Visible = False
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'grdTransfer
        '
        Me.grdTransfer.AllowDrop = True
        Me.grdTransfer.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdTransfer.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdTransfer.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdTransfer.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdTransfer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdTransfer.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.brandopeningid, Me.brandname, Me.Size, Me.Against, Me.TPno, Me.Batch, Me.Mfg, Me.Box, Me.Remarks, Me.spegqty, Me.spegrate, Me.bottleqty, Me.bottlerate, Me.ForbrandopningId, Me.Stock, Me.BoxHideQty})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdTransfer.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdTransfer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTransfer.GridColor = System.Drawing.Color.Black
        Me.grdTransfer.Location = New System.Drawing.Point(0, 0)
        Me.grdTransfer.Name = "grdTransfer"
        Me.grdTransfer.Size = New System.Drawing.Size(1287, 272)
        Me.grdTransfer.TabIndex = 12
        '
        'brandopeningid
        '
        Me.brandopeningid.Frozen = True
        Me.brandopeningid.HeaderText = "brandopeningid"
        Me.brandopeningid.Name = "brandopeningid"
        Me.brandopeningid.Visible = False
        '
        'brandname
        '
        Me.brandname.Frozen = True
        Me.brandname.HeaderText = "Brand Name"
        Me.brandname.Name = "brandname"
        '
        'Size
        '
        Me.Size.Frozen = True
        Me.Size.HeaderText = "Size"
        Me.Size.Name = "Size"
        '
        'Against
        '
        Me.Against.HeaderText = "Against"
        Me.Against.Name = "Against"
        '
        'TPno
        '
        Me.TPno.HeaderText = "TPNo"
        Me.TPno.Name = "TPno"
        '
        'Batch
        '
        Me.Batch.HeaderText = "Batch"
        Me.Batch.Name = "Batch"
        '
        'Mfg
        '
        Me.Mfg.HeaderText = "Mfg"
        Me.Mfg.Name = "Mfg"
        '
        'Box
        '
        Me.Box.HeaderText = "Box"
        Me.Box.Name = "Box"
        '
        'Remarks
        '
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.Name = "Remarks"
        '
        'spegqty
        '
        Me.spegqty.HeaderText = "spegqty"
        Me.spegqty.Name = "spegqty"
        '
        'spegrate
        '
        Me.spegrate.HeaderText = "spegrate"
        Me.spegrate.Name = "spegrate"
        '
        'bottleqty
        '
        Me.bottleqty.HeaderText = "bottleqty"
        Me.bottleqty.Name = "bottleqty"
        '
        'bottlerate
        '
        Me.bottlerate.HeaderText = "bottlerate"
        Me.bottlerate.Name = "bottlerate"
        '
        'ForbrandopningId
        '
        Me.ForbrandopningId.HeaderText = "ForBrandOpeningID"
        Me.ForbrandopningId.Name = "ForbrandopningId"
        Me.ForbrandopningId.Visible = False
        '
        'Stock
        '
        Me.Stock.HeaderText = "Stock"
        Me.Stock.Name = "Stock"
        Me.Stock.Width = 150
        '
        'BoxHideQty
        '
        Me.BoxHideQty.HeaderText = "BoxHideQty"
        Me.BoxHideQty.Name = "BoxHideQty"
        Me.BoxHideQty.Visible = False
        '
        'ttlp
        '
        Me.ttlp.IsBalloon = True
        '
        'FrmTransfer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1287, 482)
        Me.Controls.Add(Me.SplitContainer1)
        Me.MainMenuStrip = Me.mnuTransfer
        Me.Name = "FrmTransfer"
        Me.Text = "FrmTransfer"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.grdTransferDetails.ResumeLayout(False)
        Me.grdTransferDetails.PerformLayout()
        Me.grdTransferHead.ResumeLayout(False)
        Me.grdTransferHead.PerformLayout()
        Me.mnuTransfer.ResumeLayout(False)
        Me.mnuTransfer.PerformLayout()
        CType(Me.grdTransfer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Public WithEvents grdTransfer As System.Windows.Forms.DataGridView
    Friend WithEvents grdTransferDetails As System.Windows.Forms.GroupBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents txtTransferDetailTPno As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblSize As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblBrandName As System.Windows.Forms.Label
    Friend WithEvents cmbAgainst As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBrandName As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSize As System.Windows.Forms.ComboBox
    Friend WithEvents grdTransferHead As System.Windows.Forms.GroupBox
    Friend WithEvents lblFl4 As System.Windows.Forms.Label
    Friend WithEvents lblLicenseID As System.Windows.Forms.Label
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents lblTPno As System.Windows.Forms.Label
    Friend WithEvents txtFLIV As System.Windows.Forms.TextBox
    Friend WithEvents txtInvoiceNo As System.Windows.Forms.TextBox
    Friend WithEvents dtpTransferHead As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbLicense As System.Windows.Forms.ComboBox
    Friend WithEvents txtTransferHeadTPNo As System.Windows.Forms.TextBox
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblTransferHeadID As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents imgSave As System.Windows.Forms.Button
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents ttlp As System.Windows.Forms.ToolTip
    Friend WithEvents lblBrandDetailsLable As System.Windows.Forms.Label
    Friend WithEvents chkShowExcise As System.Windows.Forms.CheckBox
    Friend WithEvents cmbDept As System.Windows.Forms.ComboBox
    Friend WithEvents mnuTransfer As System.Windows.Forms.MenuStrip
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents lbladdress As System.Windows.Forms.Label
    Friend WithEvents brandopeningid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents brandname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Against As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TPno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Batch As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Mfg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Box As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents spegqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents spegrate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bottleqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bottlerate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ForbrandopningId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Stock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxHideQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnCallEvent As System.Windows.Forms.Button
End Class
