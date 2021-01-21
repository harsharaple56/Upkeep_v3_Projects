<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PurchaseControl
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DesignerRectTracker1 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PurchaseControl))
        Dim CBlendItems1 As CButtonLib.cBlendItems = New CButtonLib.cBlendItems()
        Dim DesignerRectTracker2 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Dim DesignerRectTracker3 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Dim CBlendItems2 As CButtonLib.cBlendItems = New CButtonLib.cBlendItems()
        Dim DesignerRectTracker4 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.grdTpNoByLicenseNo = New System.Windows.Forms.DataGridView()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.lblStock = New System.Windows.Forms.Label()
        Me.btnSave = New CButtonLib.CButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnAdd = New CButtonLib.CButton()
        Me.cmbsize = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbtaxtype = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbbrand = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblid = New System.Windows.Forms.Label()
        Me.txtActualdesc = New System.Windows.Forms.TextBox()
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
        Me.grdpurchase1 = New ThemedDataGrid.MKDataGridView()
        Me.btnRem = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.BrandopeningId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Brandname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SizeId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PurSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.grdTpNoByLicenseNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdpurchase1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.grdTpNoByLicenseNo)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1191, 545)
        Me.SplitContainer1.SplitterDistance = 163
        Me.SplitContainer1.SplitterWidth = 6
        Me.SplitContainer1.TabIndex = 3
        '
        'grdTpNoByLicenseNo
        '
        Me.grdTpNoByLicenseNo.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(243, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.grdTpNoByLicenseNo.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdTpNoByLicenseNo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdTpNoByLicenseNo.BackgroundColor = System.Drawing.Color.White
        Me.grdTpNoByLicenseNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdTpNoByLicenseNo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(189, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdTpNoByLicenseNo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdTpNoByLicenseNo.ColumnHeadersHeight = 30
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdTpNoByLicenseNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.grdTpNoByLicenseNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTpNoByLicenseNo.EnableHeadersVisualStyles = False
        Me.grdTpNoByLicenseNo.GridColor = System.Drawing.Color.White
        Me.grdTpNoByLicenseNo.Location = New System.Drawing.Point(0, 0)
        Me.grdTpNoByLicenseNo.Name = "grdTpNoByLicenseNo"
        Me.grdTpNoByLicenseNo.ReadOnly = True
        Me.grdTpNoByLicenseNo.RowHeadersVisible = False
        Me.grdTpNoByLicenseNo.RowHeadersWidth = 51
        Me.grdTpNoByLicenseNo.RowTemplate.DividerHeight = 1
        Me.grdTpNoByLicenseNo.RowTemplate.Height = 28
        Me.grdTpNoByLicenseNo.Size = New System.Drawing.Size(163, 545)
        Me.grdTpNoByLicenseNo.TabIndex = 4
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.SplitContainer3)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.BackColor = System.Drawing.Color.White
        Me.SplitContainer2.Size = New System.Drawing.Size(1022, 545)
        Me.SplitContainer2.SplitterDistance = 800
        Me.SplitContainer2.SplitterWidth = 6
        Me.SplitContainer2.TabIndex = 2
        '
        'SplitContainer3
        '
        Me.SplitContainer3.BackColor = System.Drawing.Color.MintCream
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer3.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitContainer3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.lblStock)
        Me.SplitContainer3.Panel1.Controls.Add(Me.btnSave)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer3.Panel1.Controls.Add(Me.lblid)
        Me.SplitContainer3.Panel1.Controls.Add(Me.txtActualdesc)
        Me.SplitContainer3.Panel1.Controls.Add(Me.txtdesc)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer3.Panel1.Controls.Add(Me.txtchg)
        Me.SplitContainer3.Panel1.Controls.Add(Me.txtothchg)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer3.Panel1.Controls.Add(Me.cmblicense)
        Me.SplitContainer3.Panel1.Controls.Add(Me.txtInvoiceno)
        Me.SplitContainer3.Panel1.Controls.Add(Me.txttpno)
        Me.SplitContainer3.Panel1.Controls.Add(Me.cmbSuplier)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Dtdate)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer3.Panel1.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Bold)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.grdpurchase1)
        Me.SplitContainer3.Size = New System.Drawing.Size(800, 545)
        Me.SplitContainer3.SplitterDistance = 162
        Me.SplitContainer3.TabIndex = 2
        '
        'lblStock
        '
        Me.lblStock.AutoSize = True
        Me.lblStock.Location = New System.Drawing.Point(599, 96)
        Me.lblStock.Name = "lblStock"
        Me.lblStock.Size = New System.Drawing.Size(53, 16)
        Me.lblStock.TabIndex = 40
        Me.lblStock.Text = "Label13"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        DesignerRectTracker1.IsActive = False
        DesignerRectTracker1.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker1.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btnSave.CenterPtTracker = DesignerRectTracker1
        CBlendItems1.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))}
        CBlendItems1.iPoint = New Single() {0.0!, 0.4731183!, 1.0!}
        Me.btnSave.ColorFillBlend = CBlendItems1
        Me.btnSave.ColorFillSolid = System.Drawing.SystemColors.Control
        Me.btnSave.Corners.All = CType(11, Short)
        Me.btnSave.Corners.LowerLeft = CType(11, Short)
        Me.btnSave.Corners.LowerRight = CType(11, Short)
        Me.btnSave.Corners.UpperLeft = CType(11, Short)
        Me.btnSave.Corners.UpperRight = CType(11, Short)
        Me.btnSave.FillType = CButtonLib.CButton.eFillType.GradientLinear
        Me.btnSave.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.btnSave.FocalPoints.CenterPtX = 0.979798!
        Me.btnSave.FocalPoints.CenterPtY = 0.4864865!
        Me.btnSave.FocalPoints.FocusPtX = 0.0!
        Me.btnSave.FocalPoints.FocusPtY = 0.0!
        DesignerRectTracker2.IsActive = False
        DesignerRectTracker2.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker2.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btnSave.FocusPtTracker = DesignerRectTracker2
        Me.btnSave.Font = New System.Drawing.Font("Comic Sans MS", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.Image = Nothing
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnSave.ImageIndex = 0
        Me.btnSave.ImageSize = New System.Drawing.Size(16, 16)
        Me.btnSave.Location = New System.Drawing.Point(720, 7)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Shape = CButtonLib.CButton.eShape.Rectangle
        Me.btnSave.SideImage = Global.CWPlus.My.Resources.Resources.save
        Me.btnSave.SideImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.SideImageIsClickable = True
        Me.btnSave.SideImageSize = New System.Drawing.Size(28, 28)
        Me.btnSave.Size = New System.Drawing.Size(75, 35)
        Me.btnSave.TabIndex = 39
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.btnSave.TextMargin = New System.Windows.Forms.Padding(2, 2, 5, 2)
        Me.btnSave.TextShadow = System.Drawing.Color.White
        Me.btnSave.TextSmoothingMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
        Me.btnSave.UseMnemonic = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Honeydew
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.btnAdd)
        Me.Panel1.Controls.Add(Me.cmbsize)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.cmbtaxtype)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.cmbbrand)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 126)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 36)
        Me.Panel1.TabIndex = 38
        '
        'btnAdd
        '
        Me.btnAdd.BorderColor = System.Drawing.Color.Green
        DesignerRectTracker3.IsActive = True
        DesignerRectTracker3.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker3.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btnAdd.CenterPtTracker = DesignerRectTracker3
        CBlendItems2.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))}
        CBlendItems2.iPoint = New Single() {0.0!, 0.4731183!, 1.0!}
        Me.btnAdd.ColorFillBlend = CBlendItems2
        Me.btnAdd.ColorFillSolid = System.Drawing.SystemColors.Control
        Me.btnAdd.Corners.All = CType(0, Short)
        Me.btnAdd.Corners.LowerLeft = CType(0, Short)
        Me.btnAdd.Corners.LowerRight = CType(0, Short)
        Me.btnAdd.Corners.UpperLeft = CType(0, Short)
        Me.btnAdd.Corners.UpperRight = CType(0, Short)
        Me.btnAdd.FillType = CButtonLib.CButton.eFillType.GradientLinear
        Me.btnAdd.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.btnAdd.FocalPoints.CenterPtX = 0.979798!
        Me.btnAdd.FocalPoints.CenterPtY = 0.4864865!
        Me.btnAdd.FocalPoints.FocusPtX = 0.0!
        Me.btnAdd.FocalPoints.FocusPtY = 0.0!
        DesignerRectTracker4.IsActive = False
        DesignerRectTracker4.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker4.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btnAdd.FocusPtTracker = DesignerRectTracker4
        Me.btnAdd.Font = New System.Drawing.Font("Comic Sans MS", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnAdd.ForeColor = System.Drawing.Color.Black
        Me.btnAdd.Image = Nothing
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAdd.ImageIndex = 0
        Me.btnAdd.ImageSize = New System.Drawing.Size(16, 16)
        Me.btnAdd.Location = New System.Drawing.Point(636, 3)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Shape = CButtonLib.CButton.eShape.Rectangle
        Me.btnAdd.SideImage = Global.CWPlus.My.Resources.Resources.edit_add
        Me.btnAdd.SideImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAdd.SideImageSize = New System.Drawing.Size(28, 25)
        Me.btnAdd.Size = New System.Drawing.Size(32, 27)
        Me.btnAdd.TabIndex = 41
        Me.btnAdd.Text = ""
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.btnAdd.TextMargin = New System.Windows.Forms.Padding(2)
        Me.btnAdd.TextShadow = System.Drawing.Color.White
        Me.btnAdd.TextSmoothingMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
        Me.btnAdd.UseMnemonic = True
        '
        'cmbsize
        '
        Me.cmbsize.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbsize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbsize.FormattingEnabled = True
        Me.cmbsize.Location = New System.Drawing.Point(297, 6)
        Me.cmbsize.Name = "cmbsize"
        Me.cmbsize.Size = New System.Drawing.Size(130, 24)
        Me.cmbsize.TabIndex = 37
        '
        'Label12
        '
        Me.Label12.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(264, 10)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(32, 16)
        Me.Label12.TabIndex = 36
        Me.Label12.Text = "Size"
        '
        'cmbtaxtype
        '
        Me.cmbtaxtype.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbtaxtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtaxtype.FormattingEnabled = True
        Me.cmbtaxtype.Location = New System.Drawing.Point(502, 7)
        Me.cmbtaxtype.Name = "cmbtaxtype"
        Me.cmbtaxtype.Size = New System.Drawing.Size(126, 24)
        Me.cmbtaxtype.TabIndex = 35
        '
        'Label11
        '
        Me.Label11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(433, 10)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 16)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Tax Type"
        '
        'cmbbrand
        '
        Me.cmbbrand.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbbrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbbrand.FormattingEnabled = True
        Me.cmbbrand.Location = New System.Drawing.Point(106, 7)
        Me.cmbbrand.Name = "cmbbrand"
        Me.cmbbrand.Size = New System.Drawing.Size(145, 24)
        Me.cmbbrand.TabIndex = 33
        '
        'Label10
        '
        Me.Label10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 10)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 16)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "Brand Name"
        '
        'lblid
        '
        Me.lblid.AutoSize = True
        Me.lblid.Location = New System.Drawing.Point(702, 11)
        Me.lblid.Name = "lblid"
        Me.lblid.Size = New System.Drawing.Size(15, 16)
        Me.lblid.TabIndex = 37
        Me.lblid.Text = "0"
        Me.lblid.Visible = False
        '
        'txtActualdesc
        '
        Me.txtActualdesc.Location = New System.Drawing.Point(493, 8)
        Me.txtActualdesc.Name = "txtActualdesc"
        Me.txtActualdesc.Size = New System.Drawing.Size(66, 24)
        Me.txtActualdesc.TabIndex = 36
        '
        'txtdesc
        '
        Me.txtdesc.Location = New System.Drawing.Point(379, 34)
        Me.txtdesc.Name = "txtdesc"
        Me.txtdesc.Size = New System.Drawing.Size(66, 24)
        Me.txtdesc.TabIndex = 35
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(452, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 16)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Desc"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(299, 37)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 16)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "Disc %"
        '
        'txtchg
        '
        Me.txtchg.Location = New System.Drawing.Point(379, 88)
        Me.txtchg.Name = "txtchg"
        Me.txtchg.Size = New System.Drawing.Size(66, 24)
        Me.txtchg.TabIndex = 32
        '
        'txtothchg
        '
        Me.txtothchg.Location = New System.Drawing.Point(379, 8)
        Me.txtothchg.Name = "txtothchg"
        Me.txtothchg.Size = New System.Drawing.Size(66, 24)
        Me.txtothchg.TabIndex = 31
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(341, 91)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 16)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Chg"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(299, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Oth Chg"
        '
        'cmblicense
        '
        Me.cmblicense.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmblicense.FormattingEnabled = True
        Me.cmblicense.Location = New System.Drawing.Point(108, 88)
        Me.cmblicense.Name = "cmblicense"
        Me.cmblicense.Size = New System.Drawing.Size(145, 24)
        Me.cmblicense.TabIndex = 28
        '
        'txtInvoiceno
        '
        Me.txtInvoiceno.Location = New System.Drawing.Point(379, 61)
        Me.txtInvoiceno.Name = "txtInvoiceno"
        Me.txtInvoiceno.Size = New System.Drawing.Size(108, 24)
        Me.txtInvoiceno.TabIndex = 27
        '
        'txttpno
        '
        Me.txttpno.Location = New System.Drawing.Point(108, 61)
        Me.txttpno.Name = "txttpno"
        Me.txttpno.Size = New System.Drawing.Size(145, 24)
        Me.txttpno.TabIndex = 26
        '
        'cmbSuplier
        '
        Me.cmbSuplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSuplier.FormattingEnabled = True
        Me.cmbSuplier.Location = New System.Drawing.Point(108, 34)
        Me.cmbSuplier.Name = "cmbSuplier"
        Me.cmbSuplier.Size = New System.Drawing.Size(145, 24)
        Me.cmbSuplier.TabIndex = 25
        '
        'Dtdate
        '
        Me.Dtdate.CustomFormat = "dd/MM/yyyy"
        Me.Dtdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtdate.Location = New System.Drawing.Point(108, 5)
        Me.Dtdate.Name = "Dtdate"
        Me.Dtdate.Size = New System.Drawing.Size(145, 24)
        Me.Dtdate.TabIndex = 24
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 16)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "License"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(299, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 16)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Invoice No"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 16)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "TP No"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 16)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Supplier Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 16)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Date"
        '
        'grdpurchase1
        '
        Me.grdpurchase1.AllowUserToAddRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.grdpurchase1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.grdpurchase1.BackgroundColor = System.Drawing.Color.White
        Me.grdpurchase1.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(189, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdpurchase1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.grdpurchase1.ColumnHeadersHeight = 28
        Me.grdpurchase1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.btnRem, Me.BrandopeningId, Me.Brandname, Me.SizeId, Me.PurSize, Me.Qty, Me.rate, Me.freeqty, Me.sPeg, Me.sRate, Me.box, Me.batch, Me.mfg, Me.taxtypeid, Me.tax, Me.taxper})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(158, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(229, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(60, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdpurchase1.DefaultCellStyle = DataGridViewCellStyle6
        Me.grdpurchase1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdpurchase1.EnableHeadersVisualStyles = False
        Me.grdpurchase1.GridColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.grdpurchase1.GridTheme = ThemedDataGrid.MKDataGridView.GridThemes.Accent1
        Me.grdpurchase1.Location = New System.Drawing.Point(0, 0)
        Me.grdpurchase1.Name = "grdpurchase1"
        Me.grdpurchase1.RowHeadersVisible = False
        Me.grdpurchase1.RowTemplate.Height = 26
        Me.grdpurchase1.Size = New System.Drawing.Size(800, 379)
        Me.grdpurchase1.TabIndex = 7
        '
        'btnRem
        '
        Me.btnRem.HeaderText = "Remove"
        Me.btnRem.Name = "btnRem"
        Me.btnRem.Text = "Remove"
        Me.btnRem.ToolTipText = "Remove Current Row"
        Me.btnRem.UseColumnTextForButtonValue = True
        Me.btnRem.Width = 73
        '
        'BrandopeningId
        '
        Me.BrandopeningId.HeaderText = "BrandopeningId"
        Me.BrandopeningId.Name = "BrandopeningId"
        Me.BrandopeningId.Visible = False
        Me.BrandopeningId.Width = 149
        '
        'Brandname
        '
        Me.Brandname.HeaderText = "Brandname"
        Me.Brandname.Name = "Brandname"
        Me.Brandname.Width = 117
        '
        'SizeId
        '
        Me.SizeId.HeaderText = "SizeId"
        Me.SizeId.Name = "SizeId"
        Me.SizeId.Visible = False
        Me.SizeId.Width = 78
        '
        'PurSize
        '
        Me.PurSize.HeaderText = "Size"
        Me.PurSize.Name = "PurSize"
        Me.PurSize.Width = 63
        '
        'Qty
        '
        Me.Qty.HeaderText = " Bottle Qty"
        Me.Qty.Name = "Qty"
        Me.Qty.Width = 111
        '
        'rate
        '
        Me.rate.HeaderText = " Bottle Rate"
        Me.rate.Name = "rate"
        Me.rate.Width = 118
        '
        'freeqty
        '
        Me.freeqty.HeaderText = "Free Qty"
        Me.freeqty.Name = "freeqty"
        Me.freeqty.Width = 96
        '
        'sPeg
        '
        Me.sPeg.HeaderText = "sPeg"
        Me.sPeg.Name = "sPeg"
        Me.sPeg.Width = 68
        '
        'sRate
        '
        Me.sRate.HeaderText = "sPeg Rate"
        Me.sRate.Name = "sRate"
        Me.sRate.Width = 105
        '
        'box
        '
        Me.box.HeaderText = "Boxes"
        Me.box.Name = "box"
        Me.box.Width = 78
        '
        'batch
        '
        Me.batch.HeaderText = "Batch"
        Me.batch.Name = "batch"
        Me.batch.Width = 75
        '
        'mfg
        '
        Me.mfg.HeaderText = "Mfg"
        Me.mfg.Name = "mfg"
        Me.mfg.Width = 59
        '
        'taxtypeid
        '
        Me.taxtypeid.HeaderText = "Taxid"
        Me.taxtypeid.Name = "taxtypeid"
        Me.taxtypeid.Visible = False
        Me.taxtypeid.Width = 72
        '
        'tax
        '
        Me.tax.HeaderText = "Tax"
        Me.tax.Name = "tax"
        Me.tax.Width = 59
        '
        'taxper
        '
        Me.taxper.HeaderText = "Tax %"
        Me.taxper.Name = "taxper"
        Me.taxper.Width = 80
        '
        'PurchaseControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "PurchaseControl"
        Me.Size = New System.Drawing.Size(1191, 545)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.grdTpNoByLicenseNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.PerformLayout()
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.grdpurchase1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblid As System.Windows.Forms.Label
    Friend WithEvents txtActualdesc As System.Windows.Forms.TextBox
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmbsize As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbtaxtype As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbbrand As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Size2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnSave As CButtonLib.CButton
    Friend WithEvents btnRem As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents BrandopeningId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Brandname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SizeId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurSize As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents lblStock As System.Windows.Forms.Label
    Friend WithEvents btnAdd As CButtonLib.CButton
    Friend WithEvents grdTpNoByLicenseNo As System.Windows.Forms.DataGridView
    Friend WithEvents grdpurchase1 As ThemedDataGrid.MKDataGridView

End Class
