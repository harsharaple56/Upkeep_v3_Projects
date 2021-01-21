<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSaleMst
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.imgSave = New System.Windows.Forms.Button()
        Me.imgClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtBillno = New System.Windows.Forms.TextBox()
        Me.lblid = New System.Windows.Forms.Label()
        Me.Dtdate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.lblbrandName = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.cmbtaxType = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbSize = New System.Windows.Forms.ComboBox()
        Me.cmbBrand = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grdBrand = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.btnCocktailAdd = New System.Windows.Forms.Button()
        Me.cmbCocktailTaxtype = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbCocktail = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.grdCocktail = New System.Windows.Forms.DataGridView()
        Me.CocktailID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cocktail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vTaxTypeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vTaxType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tax = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taxAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.ttlpText = New System.Windows.Forms.ToolTip(Me.components)
        Me.BrandID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Brand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CategorySizeLinkUpID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TaxTypeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Taxtype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TaxPerc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sPegQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sPegRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lPegQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lPegRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BottleQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BottleRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.MenuStrip1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1156, 434)
        Me.SplitContainer1.SplitterDistance = 89
        Me.SplitContainer1.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.AddToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1156, 24)
        Me.MenuStrip1.TabIndex = 21
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.SaveToolStripMenuItem.Text = "Save"
        Me.SaveToolStripMenuItem.Visible = False
        '
        'AddToolStripMenuItem1
        '
        Me.AddToolStripMenuItem1.Name = "AddToolStripMenuItem1"
        Me.AddToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.AddToolStripMenuItem1.Size = New System.Drawing.Size(41, 20)
        Me.AddToolStripMenuItem1.Text = "Add"
        Me.AddToolStripMenuItem1.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.imgSave)
        Me.Panel1.Controls.Add(Me.imgClose)
        Me.Panel1.Location = New System.Drawing.Point(1064, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(92, 43)
        Me.Panel1.TabIndex = 14
        '
        'imgSave
        '
        Me.imgSave.Image = Global.CWPlus.My.Resources.Resources.save
        Me.imgSave.Location = New System.Drawing.Point(3, 3)
        Me.imgSave.Name = "imgSave"
        Me.imgSave.Size = New System.Drawing.Size(39, 37)
        Me.imgSave.TabIndex = 4
        Me.ttlpText.SetToolTip(Me.imgSave, "Save")
        Me.imgSave.UseVisualStyleBackColor = True
        '
        'imgClose
        '
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(48, 3)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(39, 37)
        Me.imgClose.TabIndex = 5
        Me.ttlpText.SetToolTip(Me.imgClose, "Close")
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtBillno)
        Me.GroupBox1.Controls.Add(Me.lblid)
        Me.GroupBox1.Controls.Add(Me.Dtdate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(207, 74)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sale"
        '
        'txtBillno
        '
        Me.txtBillno.Location = New System.Drawing.Point(56, 46)
        Me.txtBillno.Name = "txtBillno"
        Me.txtBillno.Size = New System.Drawing.Size(110, 20)
        Me.txtBillno.TabIndex = 2
        '
        'lblid
        '
        Me.lblid.AutoSize = True
        Me.lblid.Location = New System.Drawing.Point(188, 58)
        Me.lblid.Name = "lblid"
        Me.lblid.Size = New System.Drawing.Size(13, 13)
        Me.lblid.TabIndex = 3
        Me.lblid.Text = "0"
        Me.lblid.Visible = False
        '
        'Dtdate
        '
        Me.Dtdate.CustomFormat = "dd/MM/yyyy"
        Me.Dtdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtdate.Location = New System.Drawing.Point(56, 20)
        Me.Dtdate.Name = "Dtdate"
        Me.Dtdate.Size = New System.Drawing.Size(110, 20)
        Me.Dtdate.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Bill No"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1156, 341)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.SplitContainer2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1148, 315)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Brand"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.IsSplitterFixed = True
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblbrandName)
        Me.SplitContainer2.Panel1.Controls.Add(Me.btnAdd)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cmbtaxType)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cmbSize)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cmbBrand)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label3)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.grdBrand)
        Me.SplitContainer2.Size = New System.Drawing.Size(1142, 309)
        Me.SplitContainer2.SplitterDistance = 43
        Me.SplitContainer2.TabIndex = 0
        '
        'lblbrandName
        '
        Me.lblbrandName.AutoSize = True
        Me.lblbrandName.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbrandName.Location = New System.Drawing.Point(640, 16)
        Me.lblbrandName.Name = "lblbrandName"
        Me.lblbrandName.Size = New System.Drawing.Size(0, 19)
        Me.lblbrandName.TabIndex = 12
        '
        'btnAdd
        '
        Me.btnAdd.Image = Global.CWPlus.My.Resources.Resources.edit_add__1_
        Me.btnAdd.Location = New System.Drawing.Point(580, 8)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(39, 30)
        Me.btnAdd.TabIndex = 8
        Me.ttlpText.SetToolTip(Me.btnAdd, "Add")
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'cmbtaxType
        '
        Me.cmbtaxType.FormattingEnabled = True
        Me.cmbtaxType.Location = New System.Drawing.Point(506, 13)
        Me.cmbtaxType.Name = "cmbtaxType"
        Me.cmbtaxType.Size = New System.Drawing.Size(68, 21)
        Me.cmbtaxType.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(448, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Tax Type"
        '
        'cmbSize
        '
        Me.cmbSize.FormattingEnabled = True
        Me.cmbSize.Location = New System.Drawing.Point(360, 13)
        Me.cmbSize.Name = "cmbSize"
        Me.cmbSize.Size = New System.Drawing.Size(68, 21)
        Me.cmbSize.TabIndex = 3
        '
        'cmbBrand
        '
        Me.cmbBrand.FormattingEnabled = True
        Me.cmbBrand.Location = New System.Drawing.Point(54, 13)
        Me.cmbBrand.Name = "cmbBrand"
        Me.cmbBrand.Size = New System.Drawing.Size(266, 21)
        Me.cmbBrand.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(327, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Size"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Brand"
        '
        'grdBrand
        '
        Me.grdBrand.AllowUserToAddRows = False
        Me.grdBrand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdBrand.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BrandID, Me.Brand, Me.CategorySizeLinkUpID, Me.Size, Me.TaxTypeID, Me.Taxtype, Me.TaxPerc, Me.sPegQty, Me.sPegRate, Me.lPegQty, Me.lPegRate, Me.BottleQty, Me.BottleRate, Me.TotalAmount, Me.Stock})
        Me.grdBrand.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdBrand.Location = New System.Drawing.Point(0, 0)
        Me.grdBrand.Name = "grdBrand"
        Me.grdBrand.Size = New System.Drawing.Size(1142, 262)
        Me.grdBrand.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.SplitContainer3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1148, 315)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Cocktail"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer3.IsSplitterFixed = True
        Me.SplitContainer3.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.btnCocktailAdd)
        Me.SplitContainer3.Panel1.Controls.Add(Me.cmbCocktailTaxtype)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer3.Panel1.Controls.Add(Me.cmbCocktail)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label10)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.grdCocktail)
        Me.SplitContainer3.Size = New System.Drawing.Size(1142, 309)
        Me.SplitContainer3.SplitterDistance = 43
        Me.SplitContainer3.TabIndex = 1
        '
        'btnCocktailAdd
        '
        Me.btnCocktailAdd.Image = Global.CWPlus.My.Resources.Resources.edit_add__1_
        Me.btnCocktailAdd.Location = New System.Drawing.Point(414, 10)
        Me.btnCocktailAdd.Name = "btnCocktailAdd"
        Me.btnCocktailAdd.Size = New System.Drawing.Size(39, 30)
        Me.btnCocktailAdd.TabIndex = 9
        Me.ttlpText.SetToolTip(Me.btnCocktailAdd, "Add")
        Me.btnCocktailAdd.UseVisualStyleBackColor = True
        '
        'cmbCocktailTaxtype
        '
        Me.cmbCocktailTaxtype.FormattingEnabled = True
        Me.cmbCocktailTaxtype.Location = New System.Drawing.Point(287, 10)
        Me.cmbCocktailTaxtype.Name = "cmbCocktailTaxtype"
        Me.cmbCocktailTaxtype.Size = New System.Drawing.Size(121, 21)
        Me.cmbCocktailTaxtype.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(229, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Tax Type"
        '
        'cmbCocktail
        '
        Me.cmbCocktail.FormattingEnabled = True
        Me.cmbCocktail.Location = New System.Drawing.Point(85, 10)
        Me.cmbCocktail.Name = "cmbCocktail"
        Me.cmbCocktail.Size = New System.Drawing.Size(138, 21)
        Me.cmbCocktail.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 13)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(76, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Cocktail Name"
        '
        'grdCocktail
        '
        Me.grdCocktail.AllowUserToAddRows = False
        Me.grdCocktail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCocktail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CocktailID, Me.Cocktail, Me.vTaxTypeID, Me.vTaxType, Me.Rate, Me.Qty, Me.tax, Me.taxAmt, Me.Amount})
        Me.grdCocktail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCocktail.Location = New System.Drawing.Point(0, 0)
        Me.grdCocktail.Name = "grdCocktail"
        Me.grdCocktail.Size = New System.Drawing.Size(1142, 262)
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
        'vTaxTypeID
        '
        Me.vTaxTypeID.HeaderText = "TaxTypeID"
        Me.vTaxTypeID.Name = "vTaxTypeID"
        '
        'vTaxType
        '
        Me.vTaxType.HeaderText = "Tax Type"
        Me.vTaxType.Name = "vTaxType"
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
        'tax
        '
        Me.tax.HeaderText = "Tax %"
        Me.tax.Name = "tax"
        '
        'taxAmt
        '
        Me.taxAmt.HeaderText = "Tax Amount"
        Me.taxAmt.Name = "taxAmt"
        '
        'Amount
        '
        Me.Amount.HeaderText = "Amount"
        Me.Amount.Name = "Amount"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.SplitContainer4)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1148, 315)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Permit Holder"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer4.IsSplitterFixed = True
        Me.SplitContainer4.Location = New System.Drawing.Point(3, 3)
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
        Me.SplitContainer4.Size = New System.Drawing.Size(1142, 309)
        Me.SplitContainer4.SplitterDistance = 43
        Me.SplitContainer4.TabIndex = 2
        '
        'btnPermitAdd
        '
        Me.btnPermitAdd.Image = Global.CWPlus.My.Resources.Resources.edit_add__1_
        Me.btnPermitAdd.Location = New System.Drawing.Point(319, 10)
        Me.btnPermitAdd.Name = "btnPermitAdd"
        Me.btnPermitAdd.Size = New System.Drawing.Size(39, 30)
        Me.btnPermitAdd.TabIndex = 9
        Me.ttlpText.SetToolTip(Me.btnPermitAdd, "Add")
        Me.btnPermitAdd.UseVisualStyleBackColor = True
        '
        'cmbPermitName
        '
        Me.cmbPermitName.FormattingEnabled = True
        Me.cmbPermitName.Location = New System.Drawing.Point(82, 11)
        Me.cmbPermitName.Name = "cmbPermitName"
        Me.cmbPermitName.Size = New System.Drawing.Size(231, 21)
        Me.cmbPermitName.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 14)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 13)
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
        Me.grdPermitName.Name = "grdPermitName"
        Me.grdPermitName.Size = New System.Drawing.Size(1142, 262)
        Me.grdPermitName.TabIndex = 0
        '
        'PermitHolderID
        '
        Me.PermitHolderID.HeaderText = "PermitHolderID"
        Me.PermitHolderID.Name = "PermitHolderID"
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
        '
        'PermitType
        '
        Me.PermitType.HeaderText = "PermitType"
        Me.PermitType.Name = "PermitType"
        '
        'ttlpText
        '
        Me.ttlpText.IsBalloon = True
        '
        'BrandID
        '
        Me.BrandID.HeaderText = "BrandID"
        Me.BrandID.Name = "BrandID"
        Me.BrandID.Visible = False
        '
        'Brand
        '
        Me.Brand.HeaderText = "Brand"
        Me.Brand.Name = "Brand"
        '
        'CategorySizeLinkUpID
        '
        Me.CategorySizeLinkUpID.HeaderText = "SizeID"
        Me.CategorySizeLinkUpID.Name = "CategorySizeLinkUpID"
        Me.CategorySizeLinkUpID.Visible = False
        '
        'Size
        '
        Me.Size.HeaderText = "Size"
        Me.Size.Name = "Size"
        '
        'TaxTypeID
        '
        Me.TaxTypeID.HeaderText = "TaxTypeID"
        Me.TaxTypeID.Name = "TaxTypeID"
        Me.TaxTypeID.Visible = False
        '
        'Taxtype
        '
        Me.Taxtype.HeaderText = "Tax Type"
        Me.Taxtype.Name = "Taxtype"
        '
        'TaxPerc
        '
        Me.TaxPerc.HeaderText = "Tax %"
        Me.TaxPerc.Name = "TaxPerc"
        '
        'sPegQty
        '
        Me.sPegQty.HeaderText = "sPegQty"
        Me.sPegQty.Name = "sPegQty"
        '
        'sPegRate
        '
        Me.sPegRate.HeaderText = "sPegRate"
        Me.sPegRate.Name = "sPegRate"
        '
        'lPegQty
        '
        Me.lPegQty.HeaderText = "lPegQty"
        Me.lPegQty.Name = "lPegQty"
        '
        'lPegRate
        '
        Me.lPegRate.HeaderText = "lPegRate"
        Me.lPegRate.Name = "lPegRate"
        '
        'BottleQty
        '
        Me.BottleQty.HeaderText = "BottleQty"
        Me.BottleQty.Name = "BottleQty"
        '
        'BottleRate
        '
        Me.BottleRate.HeaderText = "BottleRate"
        Me.BottleRate.Name = "BottleRate"
        '
        'TotalAmount
        '
        Me.TotalAmount.HeaderText = "TotalAmount"
        Me.TotalAmount.Name = "TotalAmount"
        '
        'Stock
        '
        Me.Stock.HeaderText = "Stock"
        Me.Stock.Name = "Stock"
        Me.Stock.Width = 150
        '
        'FrmSaleMst
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1156, 434)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmSaleMst"
        Me.Text = "FrmSaleMst"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
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
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblid As System.Windows.Forms.Label
    Friend WithEvents txtBillno As System.Windows.Forms.TextBox
    Friend WithEvents Dtdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents cmbtaxType As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbSize As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBrand As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grdBrand As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents cmbCocktailTaxtype As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbCocktail As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents grdCocktail As System.Windows.Forms.DataGridView
    Friend WithEvents SplitContainer4 As System.Windows.Forms.SplitContainer
    Friend WithEvents cmbPermitName As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents grdPermitName As System.Windows.Forms.DataGridView
    Friend WithEvents lblbrandName As System.Windows.Forms.Label
    Friend WithEvents PermitHolderID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PermitName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PermitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExpDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PermitTypeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PermitType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents imgSave As System.Windows.Forms.Button
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents ttlpText As System.Windows.Forms.ToolTip
    Friend WithEvents btnCocktailAdd As System.Windows.Forms.Button
    Friend WithEvents btnPermitAdd As System.Windows.Forms.Button
    Friend WithEvents CocktailID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cocktail As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vTaxTypeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vTaxType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents taxAmt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BrandID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Brand As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CategorySizeLinkUpID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TaxTypeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Taxtype As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TaxPerc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sPegQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sPegRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lPegQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lPegRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BottleQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BottleRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Stock As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
