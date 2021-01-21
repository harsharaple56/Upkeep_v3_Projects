<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmpurchaseMst
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
        Me.imgClose = New System.Windows.Forms.Button()
        Me.lblid = New System.Windows.Forms.Label()
        Me.txtGRNForCode = New System.Windows.Forms.TextBox()
        Me.txtdesc = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtchg = New System.Windows.Forms.TextBox()
        Me.txtothchg = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmblicense = New System.Windows.Forms.ComboBox()
        Me.txtInvoiceno = New System.Windows.Forms.TextBox()
        Me.txttpno = New System.Windows.Forms.TextBox()
        Me.cmbSuplier = New System.Windows.Forms.ComboBox()
        Me.Dtdate = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.lblStock = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.cmbsize = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbtaxtype = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbbrand = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.grdpurchase = New System.Windows.Forms.DataGridView()
        Me.btnRem = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.BrandopeningId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Brandname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SizeId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.freeqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sPeg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.box = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.batch = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mfg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taxtypeid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tax = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taxper = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ttlpText = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.grdpurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblid)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtGRNForCode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtdesc)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtchg)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtothchg)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmblicense)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtInvoiceno)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txttpno)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmbSuplier)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Dtdate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.MenuStrip1)
        Me.SplitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainer1.Size = New System.Drawing.Size(1003, 510)
        Me.SplitContainer1.SplitterDistance = 120
        Me.SplitContainer1.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.imgSave)
        Me.Panel1.Controls.Add(Me.imgClose)
        Me.Panel1.Location = New System.Drawing.Point(900, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(99, 54)
        Me.Panel1.TabIndex = 21
        '
        'imgSave
        '
        Me.imgSave.Image = Global.CWPlus.My.Resources.Resources.save
        Me.imgSave.Location = New System.Drawing.Point(3, 3)
        Me.imgSave.Name = "imgSave"
        Me.imgSave.Size = New System.Drawing.Size(43, 44)
        Me.imgSave.TabIndex = 15
        Me.ttlpText.SetToolTip(Me.imgSave, "Save")
        Me.imgSave.UseVisualStyleBackColor = True
        '
        'imgClose
        '
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(52, 3)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(40, 44)
        Me.imgClose.TabIndex = 16
        Me.ttlpText.SetToolTip(Me.imgClose, "Close")
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'lblid
        '
        Me.lblid.AutoSize = True
        Me.lblid.Location = New System.Drawing.Point(560, 15)
        Me.lblid.Name = "lblid"
        Me.lblid.Size = New System.Drawing.Size(13, 13)
        Me.lblid.TabIndex = 18
        Me.lblid.Text = "0"
        Me.lblid.Visible = False
        '
        'txtGRNForCode
        '
        Me.txtGRNForCode.Location = New System.Drawing.Point(470, 38)
        Me.txtGRNForCode.Name = "txtGRNForCode"
        Me.txtGRNForCode.Size = New System.Drawing.Size(58, 20)
        Me.txtGRNForCode.TabIndex = 6
        '
        'txtdesc
        '
        Me.txtdesc.Location = New System.Drawing.Point(340, 43)
        Me.txtdesc.Name = "txtdesc"
        Me.txtdesc.Size = New System.Drawing.Size(66, 20)
        Me.txtdesc.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(429, 41)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "GRN"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(275, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Disc %"
        '
        'txtchg
        '
        Me.txtchg.Location = New System.Drawing.Point(470, 11)
        Me.txtchg.Name = "txtchg"
        Me.txtchg.Size = New System.Drawing.Size(58, 20)
        Me.txtchg.TabIndex = 3
        '
        'txtothchg
        '
        Me.txtothchg.Location = New System.Drawing.Point(340, 13)
        Me.txtothchg.Name = "txtothchg"
        Me.txtothchg.Size = New System.Drawing.Size(66, 20)
        Me.txtothchg.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(429, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(26, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Chg"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(275, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Oth Chg"
        '
        'cmblicense
        '
        Me.cmblicense.FormattingEnabled = True
        Me.cmblicense.Location = New System.Drawing.Point(105, 92)
        Me.cmblicense.Name = "cmblicense"
        Me.cmblicense.Size = New System.Drawing.Size(145, 21)
        Me.cmblicense.TabIndex = 9
        '
        'txtInvoiceno
        '
        Me.txtInvoiceno.Location = New System.Drawing.Point(340, 69)
        Me.txtInvoiceno.Name = "txtInvoiceno"
        Me.txtInvoiceno.Size = New System.Drawing.Size(115, 20)
        Me.txtInvoiceno.TabIndex = 8
        '
        'txttpno
        '
        Me.txttpno.Location = New System.Drawing.Point(105, 65)
        Me.txttpno.Name = "txttpno"
        Me.txttpno.Size = New System.Drawing.Size(145, 20)
        Me.txttpno.TabIndex = 7
        '
        'cmbSuplier
        '
        Me.cmbSuplier.FormattingEnabled = True
        Me.cmbSuplier.Location = New System.Drawing.Point(105, 38)
        Me.cmbSuplier.Name = "cmbSuplier"
        Me.cmbSuplier.Size = New System.Drawing.Size(145, 21)
        Me.cmbSuplier.TabIndex = 4
        '
        'Dtdate
        '
        Me.Dtdate.CustomFormat = "dd/MM/yyyy"
        Me.Dtdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtdate.Location = New System.Drawing.Point(105, 10)
        Me.Dtdate.Name = "Dtdate"
        Me.Dtdate.Size = New System.Drawing.Size(145, 20)
        Me.Dtdate.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "License"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(275, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Invoice No"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "TP No"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Supplier Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.AddToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(999, 24)
        Me.MenuStrip1.TabIndex = 20
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
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.IsSplitterFixed = True
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblStock)
        Me.SplitContainer2.Panel1.Controls.Add(Me.btnAdd)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cmbsize)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label12)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cmbtaxtype)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label11)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cmbbrand)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.grdpurchase)
        Me.SplitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainer2.Size = New System.Drawing.Size(999, 382)
        Me.SplitContainer2.TabIndex = 0
        '
        'lblStock
        '
        Me.lblStock.AutoSize = True
        Me.lblStock.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStock.Location = New System.Drawing.Point(661, 15)
        Me.lblStock.Name = "lblStock"
        Me.lblStock.Size = New System.Drawing.Size(0, 19)
        Me.lblStock.TabIndex = 20
        '
        'btnAdd
        '
        Me.btnAdd.Image = Global.CWPlus.My.Resources.Resources.edit_add__1_
        Me.btnAdd.Location = New System.Drawing.Point(588, 7)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(51, 31)
        Me.btnAdd.TabIndex = 13
        Me.ttlpText.SetToolTip(Me.btnAdd, "Add")
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'cmbsize
        '
        Me.cmbsize.FormattingEnabled = True
        Me.cmbsize.Location = New System.Drawing.Point(382, 15)
        Me.cmbsize.Name = "cmbsize"
        Me.cmbsize.Size = New System.Drawing.Size(68, 21)
        Me.cmbsize.TabIndex = 11
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(349, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(27, 13)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "Size"
        '
        'cmbtaxtype
        '
        Me.cmbtaxtype.FormattingEnabled = True
        Me.cmbtaxtype.Location = New System.Drawing.Point(514, 15)
        Me.cmbtaxtype.Name = "cmbtaxtype"
        Me.cmbtaxtype.Size = New System.Drawing.Size(68, 21)
        Me.cmbtaxtype.TabIndex = 12
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(456, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 13)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Tax Type"
        '
        'cmbbrand
        '
        Me.cmbbrand.FormattingEnabled = True
        Me.cmbbrand.Location = New System.Drawing.Point(82, 15)
        Me.cmbbrand.Name = "cmbbrand"
        Me.cmbbrand.Size = New System.Drawing.Size(261, 21)
        Me.cmbbrand.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Brand Name"
        '
        'grdpurchase
        '
        Me.grdpurchase.AllowDrop = True
        Me.grdpurchase.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdpurchase.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdpurchase.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdpurchase.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdpurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdpurchase.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.btnRem, Me.BrandopeningId, Me.Brandname, Me.SizeId, Me.Size, Me.Qty, Me.rate, Me.freeqty, Me.sPeg, Me.sRate, Me.box, Me.batch, Me.mfg, Me.taxtypeid, Me.tax, Me.taxper, Me.Stock})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdpurchase.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdpurchase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdpurchase.GridColor = System.Drawing.Color.Black
        Me.grdpurchase.Location = New System.Drawing.Point(0, 0)
        Me.grdpurchase.Name = "grdpurchase"
        Me.grdpurchase.Size = New System.Drawing.Size(999, 328)
        Me.grdpurchase.TabIndex = 14
        '
        'btnRem
        '
        Me.btnRem.HeaderText = "Remove"
        Me.btnRem.Name = "btnRem"
        Me.btnRem.Text = "Remove"
        Me.btnRem.ToolTipText = "Remove Current Row"
        Me.btnRem.UseColumnTextForButtonValue = True
        '
        'BrandopeningId
        '
        Me.BrandopeningId.HeaderText = "BrandopeningId"
        Me.BrandopeningId.Name = "BrandopeningId"
        Me.BrandopeningId.Visible = False
        '
        'Brandname
        '
        Me.Brandname.HeaderText = "Brandname"
        Me.Brandname.Name = "Brandname"
        Me.Brandname.Width = 130
        '
        'SizeId
        '
        Me.SizeId.HeaderText = "SizeId"
        Me.SizeId.Name = "SizeId"
        Me.SizeId.Visible = False
        '
        'Size
        '
        Me.Size.HeaderText = "Size"
        Me.Size.Name = "Size"
        Me.Size.Width = 50
        '
        'Qty
        '
        Me.Qty.HeaderText = " Bottle Qty"
        Me.Qty.Name = "Qty"
        Me.Qty.Width = 80
        '
        'rate
        '
        Me.rate.HeaderText = " Bottle Rate"
        Me.rate.Name = "rate"
        '
        'freeqty
        '
        Me.freeqty.HeaderText = "Free Qty"
        Me.freeqty.Name = "freeqty"
        Me.freeqty.Width = 80
        '
        'sPeg
        '
        Me.sPeg.HeaderText = "sPeg"
        Me.sPeg.Name = "sPeg"
        Me.sPeg.Width = 50
        '
        'sRate
        '
        Me.sRate.HeaderText = "sPeg Rate"
        Me.sRate.Name = "sRate"
        '
        'box
        '
        Me.box.HeaderText = "Boxes"
        Me.box.Name = "box"
        Me.box.Width = 50
        '
        'batch
        '
        Me.batch.HeaderText = "Batch"
        Me.batch.Name = "batch"
        Me.batch.Width = 50
        '
        'mfg
        '
        Me.mfg.HeaderText = "Mfg"
        Me.mfg.Name = "mfg"
        Me.mfg.Width = 50
        '
        'taxtypeid
        '
        Me.taxtypeid.HeaderText = "Taxid"
        Me.taxtypeid.Name = "taxtypeid"
        Me.taxtypeid.Visible = False
        '
        'tax
        '
        Me.tax.HeaderText = "Tax"
        Me.tax.Name = "tax"
        Me.tax.Width = 50
        '
        'taxper
        '
        Me.taxper.HeaderText = "Tax %"
        Me.taxper.Name = "taxper"
        Me.taxper.Width = 60
        '
        'Stock
        '
        Me.Stock.HeaderText = "Stock"
        Me.Stock.Name = "Stock"
        Me.Stock.Width = 150
        '
        'FrmpurchaseMst
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1003, 510)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmpurchaseMst"
        Me.Text = "FrmpurchaseMst"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.grdpurchase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblid As System.Windows.Forms.Label
    Friend WithEvents txtGRNForCode As System.Windows.Forms.TextBox
    Friend WithEvents txtdesc As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtchg As System.Windows.Forms.TextBox
    Friend WithEvents txtothchg As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmblicense As System.Windows.Forms.ComboBox
    Friend WithEvents txtInvoiceno As System.Windows.Forms.TextBox
    Friend WithEvents txttpno As System.Windows.Forms.TextBox
    Friend WithEvents cmbSuplier As System.Windows.Forms.ComboBox
    Friend WithEvents Dtdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents cmbsize As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbtaxtype As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbbrand As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grdpurchase As System.Windows.Forms.DataGridView
    Friend WithEvents AddToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblStock As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents imgSave As System.Windows.Forms.Button
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents ttlpText As System.Windows.Forms.ToolTip
    Friend WithEvents btnRem As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents BrandopeningId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Brandname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SizeId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents freeqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sPeg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents box As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents batch As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mfg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents taxtypeid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents taxper As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Stock As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
