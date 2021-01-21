<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaleAutoBill
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnCocktailAdd = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.imgSave = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.imgClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtBottles = New System.Windows.Forms.TextBox()
        Me.lblid = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.RdBottle = New System.Windows.Forms.RadioButton()
        Me.RdAmount = New System.Windows.Forms.RadioButton()
        Me.Dtdate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.lblbrandName = New System.Windows.Forms.Label()
        Me.cmbtaxType = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.cmbSize = New System.Windows.Forms.ComboBox()
        Me.cmbBrand = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grdBrand = New ThemedDataGrid.MKDataGridView()
        Me.BrandID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Brand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CategorySizeLinkUpID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SaleSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taxtypeid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taxtype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taxper = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sPegQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sPegRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lPegQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lPegRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BottleQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BottleRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LpegPermitQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpegPermitQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BottlePermitQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.lblCocktailNumber = New System.Windows.Forms.Label()
        Me.txtNoOfCocktail = New System.Windows.Forms.TextBox()
        Me.cmbCocktail = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.grdCocktail = New System.Windows.Forms.DataGridView()
        Me.CocktailID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cocktail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taxpercetage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cocktailtotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.btnPermitAdd = New System.Windows.Forms.Button()
        Me.cmbPermitName = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.grdPermitName = New System.Windows.Forms.DataGridView()
        Me.PermitHolderID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PermitName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PermitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExpDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PermitTypeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PermitType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tltpText = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.grdBrand, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.grdCocktail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        CType(Me.grdPermitName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCocktailAdd
        '
        Me.btnCocktailAdd.Location = New System.Drawing.Point(558, 16)
        Me.btnCocktailAdd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCocktailAdd.Name = "btnCocktailAdd"
        Me.btnCocktailAdd.Size = New System.Drawing.Size(87, 28)
        Me.btnCocktailAdd.TabIndex = 8
        Me.btnCocktailAdd.Text = "Add"
        Me.btnCocktailAdd.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.MintCream
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(909, 534)
        Me.SplitContainer1.SplitterDistance = 118
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.imgSave)
        Me.Panel1.Controls.Add(Me.btnExport)
        Me.Panel1.Controls.Add(Me.btnImport)
        Me.Panel1.Controls.Add(Me.imgClose)
        Me.Panel1.Location = New System.Drawing.Point(675, 3)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(229, 61)
        Me.Panel1.TabIndex = 22
        '
        'imgSave
        '
        Me.imgSave.Image = Global.CWPlus.My.Resources.Resources.save
        Me.imgSave.Location = New System.Drawing.Point(119, 6)
        Me.imgSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.imgSave.Name = "imgSave"
        Me.imgSave.Size = New System.Drawing.Size(48, 45)
        Me.imgSave.TabIndex = 8
        Me.tltpText.SetToolTip(Me.imgSave, "Save")
        Me.imgSave.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Image = Global.CWPlus.My.Resources.Resources.excel
        Me.btnExport.Location = New System.Drawing.Point(11, 6)
        Me.btnExport.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(48, 45)
        Me.btnExport.TabIndex = 3
        Me.tltpText.SetToolTip(Me.btnExport, "Export")
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'btnImport
        '
        Me.btnImport.Image = Global.CWPlus.My.Resources.Resources.import1
        Me.btnImport.Location = New System.Drawing.Point(65, 6)
        Me.btnImport.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(48, 45)
        Me.btnImport.TabIndex = 4
        Me.tltpText.SetToolTip(Me.btnImport, "Import")
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'imgClose
        '
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(173, 6)
        Me.imgClose.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(48, 45)
        Me.imgClose.TabIndex = 5
        Me.tltpText.SetToolTip(Me.imgClose, "Close")
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtBottles)
        Me.GroupBox1.Controls.Add(Me.lblid)
        Me.GroupBox1.Controls.Add(Me.txtAmount)
        Me.GroupBox1.Controls.Add(Me.RdBottle)
        Me.GroupBox1.Controls.Add(Me.RdAmount)
        Me.GroupBox1.Controls.Add(Me.Dtdate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(14, 10)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(336, 94)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Auto Billing"
        '
        'txtBottles
        '
        Me.txtBottles.Location = New System.Drawing.Point(273, 56)
        Me.txtBottles.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtBottles.Name = "txtBottles"
        Me.txtBottles.Size = New System.Drawing.Size(53, 24)
        Me.txtBottles.TabIndex = 6
        Me.txtBottles.Text = "1"
        Me.txtBottles.Visible = False
        '
        'lblid
        '
        Me.lblid.AutoSize = True
        Me.lblid.Location = New System.Drawing.Point(257, 20)
        Me.lblid.Name = "lblid"
        Me.lblid.Size = New System.Drawing.Size(15, 16)
        Me.lblid.TabIndex = 3
        Me.lblid.Text = "0"
        Me.lblid.Visible = False
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(85, 55)
        Me.txtAmount.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(116, 24)
        Me.txtAmount.TabIndex = 5
        '
        'RdBottle
        '
        Me.RdBottle.AutoSize = True
        Me.RdBottle.Location = New System.Drawing.Point(207, 57)
        Me.RdBottle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RdBottle.Name = "RdBottle"
        Me.RdBottle.Size = New System.Drawing.Size(52, 17)
        Me.RdBottle.TabIndex = 4
        Me.RdBottle.Text = "Bottle"
        Me.RdBottle.UseVisualStyleBackColor = True
        '
        'RdAmount
        '
        Me.RdAmount.AutoSize = True
        Me.RdAmount.Checked = True
        Me.RdAmount.Location = New System.Drawing.Point(11, 57)
        Me.RdAmount.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RdAmount.Name = "RdAmount"
        Me.RdAmount.Size = New System.Drawing.Size(61, 17)
        Me.RdAmount.TabIndex = 3
        Me.RdAmount.TabStop = True
        Me.RdAmount.Text = "Amount"
        Me.RdAmount.UseVisualStyleBackColor = True
        '
        'Dtdate
        '
        Me.Dtdate.CustomFormat = "dd-MMM-yyy"
        Me.Dtdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtdate.Location = New System.Drawing.Point(85, 23)
        Me.Dtdate.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Dtdate.Name = "Dtdate"
        Me.Dtdate.Size = New System.Drawing.Size(116, 24)
        Me.Dtdate.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.ItemSize = New System.Drawing.Size(28, 28)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(909, 411)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.SplitContainer2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 32)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage1.Size = New System.Drawing.Size(901, 375)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Brand"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.IsSplitterFixed = True
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 4)
        Me.SplitContainer2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblbrandName)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cmbtaxType)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer2.Panel1.Controls.Add(Me.btnAdd)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cmbSize)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cmbBrand)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label3)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.grdBrand)
        Me.SplitContainer2.Size = New System.Drawing.Size(895, 367)
        Me.SplitContainer2.SplitterDistance = 43
        Me.SplitContainer2.SplitterWidth = 5
        Me.SplitContainer2.TabIndex = 0
        '
        'lblbrandName
        '
        Me.lblbrandName.AutoSize = True
        Me.lblbrandName.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbrandName.Location = New System.Drawing.Point(728, 11)
        Me.lblbrandName.Name = "lblbrandName"
        Me.lblbrandName.Size = New System.Drawing.Size(54, 19)
        Me.lblbrandName.TabIndex = 11
        Me.lblbrandName.Text = "Label2"
        '
        'cmbtaxType
        '
        Me.cmbtaxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtaxType.FormattingEnabled = True
        Me.cmbtaxType.Location = New System.Drawing.Point(511, 9)
        Me.cmbtaxType.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbtaxType.Name = "cmbtaxType"
        Me.cmbtaxType.Size = New System.Drawing.Size(140, 24)
        Me.cmbtaxType.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(443, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Tax Type"
        '
        'btnAdd
        '
        Me.btnAdd.Image = Global.CWPlus.My.Resources.Resources.edit_add__1_
        Me.btnAdd.Location = New System.Drawing.Point(658, 6)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(36, 31)
        Me.btnAdd.TabIndex = 8
        Me.tltpText.SetToolTip(Me.btnAdd, "Add")
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'cmbSize
        '
        Me.cmbSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSize.FormattingEnabled = True
        Me.cmbSize.Location = New System.Drawing.Point(285, 9)
        Me.cmbSize.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbSize.Name = "cmbSize"
        Me.cmbSize.Size = New System.Drawing.Size(140, 24)
        Me.cmbSize.TabIndex = 3
        '
        'cmbBrand
        '
        Me.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBrand.FormattingEnabled = True
        Me.cmbBrand.Location = New System.Drawing.Point(59, 9)
        Me.cmbBrand.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbBrand.Name = "cmbBrand"
        Me.cmbBrand.Size = New System.Drawing.Size(160, 24)
        Me.cmbBrand.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(246, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Size"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Brand"
        '
        'grdBrand
        '
        Me.grdBrand.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.grdBrand.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdBrand.BackgroundColor = System.Drawing.Color.White
        Me.grdBrand.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(189, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 9.25!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdBrand.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdBrand.ColumnHeadersHeight = 28
        Me.grdBrand.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BrandID, Me.Brand, Me.CategorySizeLinkUpID, Me.SaleSize, Me.taxtypeid, Me.taxtype, Me.taxper, Me.sPegQty, Me.sPegRate, Me.lPegQty, Me.lPegRate, Me.BottleQty, Me.BottleRate, Me.Amt, Me.total, Me.LpegPermitQty, Me.SpegPermitQty, Me.BottlePermitQty})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(158, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(229, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdBrand.DefaultCellStyle = DataGridViewCellStyle3
        Me.grdBrand.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdBrand.EnableHeadersVisualStyles = False
        Me.grdBrand.GridColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.grdBrand.GridTheme = ThemedDataGrid.MKDataGridView.GridThemes.Accent1
        Me.grdBrand.Location = New System.Drawing.Point(0, 0)
        Me.grdBrand.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grdBrand.Name = "grdBrand"
        Me.grdBrand.RowHeadersVisible = False
        Me.grdBrand.RowTemplate.Height = 26
        Me.grdBrand.Size = New System.Drawing.Size(895, 319)
        Me.grdBrand.TabIndex = 0
        '
        'BrandID
        '
        Me.BrandID.HeaderText = "BrandID"
        Me.BrandID.Name = "BrandID"
        Me.BrandID.Visible = False
        Me.BrandID.Width = 92
        '
        'Brand
        '
        Me.Brand.HeaderText = "Brand"
        Me.Brand.Name = "Brand"
        Me.Brand.Width = 76
        '
        'CategorySizeLinkUpID
        '
        Me.CategorySizeLinkUpID.HeaderText = "SizeID"
        Me.CategorySizeLinkUpID.Name = "CategorySizeLinkUpID"
        Me.CategorySizeLinkUpID.Visible = False
        Me.CategorySizeLinkUpID.Width = 79
        '
        'SaleSize
        '
        Me.SaleSize.HeaderText = "Size"
        Me.SaleSize.Name = "SaleSize"
        Me.SaleSize.Width = 63
        '
        'taxtypeid
        '
        Me.taxtypeid.HeaderText = "Taxtypeid"
        Me.taxtypeid.Name = "taxtypeid"
        Me.taxtypeid.Visible = False
        Me.taxtypeid.Width = 105
        '
        'taxtype
        '
        Me.taxtype.HeaderText = "Taxtype"
        Me.taxtype.Name = "taxtype"
        Me.taxtype.Width = 92
        '
        'taxper
        '
        Me.taxper.HeaderText = "Tax %"
        Me.taxper.Name = "taxper"
        Me.taxper.Width = 80
        '
        'sPegQty
        '
        Me.sPegQty.HeaderText = "sPegQty"
        Me.sPegQty.Name = "sPegQty"
        Me.sPegQty.Width = 94
        '
        'sPegRate
        '
        Me.sPegRate.HeaderText = "sPegRate"
        Me.sPegRate.Name = "sPegRate"
        Me.sPegRate.Width = 101
        '
        'lPegQty
        '
        Me.lPegQty.HeaderText = "lPegQty"
        Me.lPegQty.Name = "lPegQty"
        Me.lPegQty.Width = 90
        '
        'lPegRate
        '
        Me.lPegRate.HeaderText = "lPegRate"
        Me.lPegRate.Name = "lPegRate"
        Me.lPegRate.Width = 97
        '
        'BottleQty
        '
        Me.BottleQty.HeaderText = "BottleQty"
        Me.BottleQty.Name = "BottleQty"
        Me.BottleQty.Width = 103
        '
        'BottleRate
        '
        Me.BottleRate.HeaderText = "BottleRate"
        Me.BottleRate.Name = "BottleRate"
        Me.BottleRate.Width = 110
        '
        'Amt
        '
        Me.Amt.HeaderText = "Amount"
        Me.Amt.Name = "Amt"
        Me.Amt.Width = 90
        '
        'total
        '
        Me.total.HeaderText = "Total Amount"
        Me.total.Name = "total"
        Me.total.Width = 130
        '
        'LpegPermitQty
        '
        Me.LpegPermitQty.HeaderText = "LpegPermitQty"
        Me.LpegPermitQty.Name = "LpegPermitQty"
        Me.LpegPermitQty.Visible = False
        Me.LpegPermitQty.Width = 142
        '
        'SpegPermitQty
        '
        Me.SpegPermitQty.HeaderText = "SpegPermitQty"
        Me.SpegPermitQty.Name = "SpegPermitQty"
        Me.SpegPermitQty.Visible = False
        Me.SpegPermitQty.Width = 143
        '
        'BottlePermitQty
        '
        Me.BottlePermitQty.HeaderText = "BottlePermitQty"
        Me.BottlePermitQty.Name = "BottlePermitQty"
        Me.BottlePermitQty.Visible = False
        Me.BottlePermitQty.Width = 151
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.SplitContainer3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 32)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage2.Size = New System.Drawing.Size(1003, 375)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Cocktail"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer3.IsSplitterFixed = True
        Me.SplitContainer3.Location = New System.Drawing.Point(3, 4)
        Me.SplitContainer3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.lblCocktailNumber)
        Me.SplitContainer3.Panel1.Controls.Add(Me.txtNoOfCocktail)
        Me.SplitContainer3.Panel1.Controls.Add(Me.btnCocktailAdd)
        Me.SplitContainer3.Panel1.Controls.Add(Me.cmbCocktail)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label10)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.grdCocktail)
        Me.SplitContainer3.Size = New System.Drawing.Size(997, 367)
        Me.SplitContainer3.SplitterDistance = 43
        Me.SplitContainer3.SplitterWidth = 5
        Me.SplitContainer3.TabIndex = 1
        '
        'lblCocktailNumber
        '
        Me.lblCocktailNumber.AutoSize = True
        Me.lblCocktailNumber.Location = New System.Drawing.Point(281, 21)
        Me.lblCocktailNumber.Name = "lblCocktailNumber"
        Me.lblCocktailNumber.Size = New System.Drawing.Size(119, 16)
        Me.lblCocktailNumber.TabIndex = 2
        Me.lblCocktailNumber.Text = "Number of Cocktail"
        '
        'txtNoOfCocktail
        '
        Me.txtNoOfCocktail.Location = New System.Drawing.Point(401, 17)
        Me.txtNoOfCocktail.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNoOfCocktail.Name = "txtNoOfCocktail"
        Me.txtNoOfCocktail.Size = New System.Drawing.Size(116, 24)
        Me.txtNoOfCocktail.TabIndex = 2
        Me.txtNoOfCocktail.Text = "2"
        '
        'cmbCocktail
        '
        Me.cmbCocktail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCocktail.FormattingEnabled = True
        Me.cmbCocktail.Location = New System.Drawing.Point(99, 12)
        Me.cmbCocktail.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbCocktail.Name = "cmbCocktail"
        Me.cmbCocktail.Size = New System.Drawing.Size(160, 24)
        Me.cmbCocktail.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 16)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Cocktail Name"
        '
        'grdCocktail
        '
        Me.grdCocktail.AllowUserToAddRows = False
        Me.grdCocktail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCocktail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CocktailID, Me.Cocktail, Me.taxpercetage, Me.Rate, Me.Qty, Me.Amount, Me.cocktailtotal})
        Me.grdCocktail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCocktail.Location = New System.Drawing.Point(0, 0)
        Me.grdCocktail.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grdCocktail.Name = "grdCocktail"
        Me.grdCocktail.Size = New System.Drawing.Size(997, 319)
        Me.grdCocktail.TabIndex = 0
        '
        'CocktailID
        '
        Me.CocktailID.HeaderText = "CocktailID"
        Me.CocktailID.Name = "CocktailID"
        Me.CocktailID.Visible = False
        '
        'Cocktail
        '
        Me.Cocktail.HeaderText = "Cocktail"
        Me.Cocktail.Name = "Cocktail"
        '
        'taxpercetage
        '
        Me.taxpercetage.HeaderText = "Tax %"
        Me.taxpercetage.Name = "taxpercetage"
        '
        'Rate
        '
        Me.Rate.HeaderText = "Rate"
        Me.Rate.Name = "Rate"
        '
        'Qty
        '
        Me.Qty.HeaderText = "Qty"
        Me.Qty.Name = "Qty"
        '
        'Amount
        '
        Me.Amount.HeaderText = "Amount"
        Me.Amount.Name = "Amount"
        '
        'cocktailtotal
        '
        Me.cocktailtotal.HeaderText = "Total Amount"
        Me.cocktailtotal.Name = "cocktailtotal"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.SplitContainer4)
        Me.TabPage3.Location = New System.Drawing.Point(4, 32)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage3.Size = New System.Drawing.Size(1003, 375)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Permit Holder"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer4.IsSplitterFixed = True
        Me.SplitContainer4.Location = New System.Drawing.Point(3, 4)
        Me.SplitContainer4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SplitContainer4.Name = "SplitContainer4"
        Me.SplitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.Controls.Add(Me.btnPermitAdd)
        Me.SplitContainer4.Panel1.Controls.Add(Me.cmbPermitName)
        Me.SplitContainer4.Panel1.Controls.Add(Me.Label11)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.grdPermitName)
        Me.SplitContainer4.Size = New System.Drawing.Size(997, 367)
        Me.SplitContainer4.SplitterDistance = 43
        Me.SplitContainer4.SplitterWidth = 5
        Me.SplitContainer4.TabIndex = 2
        '
        'btnPermitAdd
        '
        Me.btnPermitAdd.Location = New System.Drawing.Point(391, 11)
        Me.btnPermitAdd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnPermitAdd.Name = "btnPermitAdd"
        Me.btnPermitAdd.Size = New System.Drawing.Size(87, 28)
        Me.btnPermitAdd.TabIndex = 8
        Me.btnPermitAdd.Text = "Add"
        Me.btnPermitAdd.UseVisualStyleBackColor = True
        '
        'cmbPermitName
        '
        Me.cmbPermitName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPermitName.FormattingEnabled = True
        Me.cmbPermitName.Location = New System.Drawing.Point(96, 14)
        Me.cmbPermitName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbPermitName.Name = "cmbPermitName"
        Me.cmbPermitName.Size = New System.Drawing.Size(269, 24)
        Me.cmbPermitName.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(10, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 16)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Permit Name"
        '
        'grdPermitName
        '
        Me.grdPermitName.AllowUserToAddRows = False
        Me.grdPermitName.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPermitName.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PermitHolderID, Me.PermitName, Me.PermitNo, Me.ExpDate, Me.PermitTypeID, Me.PermitType})
        Me.grdPermitName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPermitName.Location = New System.Drawing.Point(0, 0)
        Me.grdPermitName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grdPermitName.Name = "grdPermitName"
        Me.grdPermitName.Size = New System.Drawing.Size(997, 319)
        Me.grdPermitName.TabIndex = 0
        '
        'PermitHolderID
        '
        Me.PermitHolderID.HeaderText = "PermitHolderID"
        Me.PermitHolderID.Name = "PermitHolderID"
        Me.PermitHolderID.Visible = False
        '
        'PermitName
        '
        Me.PermitName.HeaderText = "PermitName"
        Me.PermitName.Name = "PermitName"
        '
        'PermitNo
        '
        Me.PermitNo.HeaderText = "PermitNo"
        Me.PermitNo.Name = "PermitNo"
        '
        'ExpDate
        '
        Me.ExpDate.HeaderText = "ExpDate"
        Me.ExpDate.Name = "ExpDate"
        '
        'PermitTypeID
        '
        Me.PermitTypeID.HeaderText = "PermitTypeID"
        Me.PermitTypeID.Name = "PermitTypeID"
        Me.PermitTypeID.Visible = False
        '
        'PermitType
        '
        Me.PermitType.HeaderText = "PermitType"
        Me.PermitType.Name = "PermitType"
        '
        'tltpText
        '
        Me.tltpText.IsBalloon = True
        '
        'SaleAutoBill
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MintCream
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "SaleAutoBill"
        Me.Size = New System.Drawing.Size(909, 534)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.grdBrand, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.PerformLayout()
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.grdCocktail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel1.PerformLayout()
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer4.ResumeLayout(False)
        CType(Me.grdPermitName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCocktailAdd As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblid As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents RdBottle As System.Windows.Forms.RadioButton
    Friend WithEvents RdAmount As System.Windows.Forms.RadioButton
    Friend WithEvents Dtdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents cmbSize As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBrand As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grdBrand As ThemedDataGrid.MKDataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents cmbCocktail As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents grdCocktail As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer4 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnPermitAdd As System.Windows.Forms.Button
    Friend WithEvents cmbPermitName As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents grdPermitName As System.Windows.Forms.DataGridView
    Friend WithEvents PermitHolderID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PermitName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PermitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExpDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PermitTypeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PermitType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmbtaxType As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CocktailID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cocktail As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents taxpercetage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cocktailtotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblbrandName As System.Windows.Forms.Label
    Friend WithEvents txtBottles As System.Windows.Forms.TextBox
    Friend WithEvents lblCocktailNumber As System.Windows.Forms.Label
    Friend WithEvents txtNoOfCocktail As System.Windows.Forms.TextBox
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents imgSave As System.Windows.Forms.Button
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents tltpText As System.Windows.Forms.ToolTip
    Friend WithEvents BrandID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Brand As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CategorySizeLinkUpID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SaleSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents taxtypeid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents taxtype As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents taxper As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sPegQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sPegRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lPegQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lPegRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BottleQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BottleRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Amt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LpegPermitQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpegPermitQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BottlePermitQty As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
