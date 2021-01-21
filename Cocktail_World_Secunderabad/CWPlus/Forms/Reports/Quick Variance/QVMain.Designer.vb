<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QVMain
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DesignerRectTracker1 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QVMain))
        Dim CBlendItems1 As CButtonLib.cBlendItems = New CButtonLib.cBlendItems()
        Dim DesignerRectTracker2 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.grdQV = New System.Windows.Forms.DataGridView()
        Me.grdVariancesInput = New System.Windows.Forms.DataGridView()
        Me.cmbLicenseName = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.miniToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rdML = New System.Windows.Forms.RadioButton()
        Me.rdsPeg = New System.Windows.Forms.RadioButton()
        Me.btnCalculateVars = New CButtonLib.CButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.lblDate = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.btnQuickControls = New System.Windows.Forms.ToolStripButton()
        Me.btnExport = New System.Windows.Forms.ToolStripButton()
        Me.btnExportFormat = New System.Windows.Forms.ToolStripButton()
        Me.btnImport = New System.Windows.Forms.ToolStripButton()
        Me.BtnSettlePlus = New System.Windows.Forms.ToolStripButton()
        Me.btnSettalment = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.grdQV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVariancesInput, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.SplitContainer2.Panel1.Controls.Add(Me.grdQV)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.BackColor = System.Drawing.Color.White
        Me.SplitContainer2.Panel2.Controls.Add(Me.grdVariancesInput)
        Me.SplitContainer2.Size = New System.Drawing.Size(1061, 434)
        Me.SplitContainer2.SplitterDistance = 798
        Me.SplitContainer2.TabIndex = 1
        '
        'grdQV
        '
        Me.grdQV.AllowUserToAddRows = False
        Me.grdQV.AllowUserToDeleteRows = False
        Me.grdQV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdQV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdQV.Location = New System.Drawing.Point(0, 0)
        Me.grdQV.Name = "grdQV"
        Me.grdQV.Size = New System.Drawing.Size(798, 434)
        Me.grdQV.TabIndex = 0
        '
        'grdVariancesInput
        '
        Me.grdVariancesInput.AllowUserToAddRows = False
        Me.grdVariancesInput.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(77, Byte), Integer))
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(2)
        Me.grdVariancesInput.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdVariancesInput.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdVariancesInput.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdVariancesInput.BackgroundColor = System.Drawing.Color.White
        Me.grdVariancesInput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.grdVariancesInput.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.grdVariancesInput.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdVariancesInput.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdVariancesInput.ColumnHeadersHeight = 30
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = "0"
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdVariancesInput.DefaultCellStyle = DataGridViewCellStyle3
        Me.grdVariancesInput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdVariancesInput.EnableHeadersVisualStyles = False
        Me.grdVariancesInput.Location = New System.Drawing.Point(0, 0)
        Me.grdVariancesInput.Name = "grdVariancesInput"
        Me.grdVariancesInput.RowHeadersVisible = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer))
        DataGridViewCellStyle4.Padding = New System.Windows.Forms.Padding(2)
        Me.grdVariancesInput.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.grdVariancesInput.RowTemplate.Height = 28
        Me.grdVariancesInput.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdVariancesInput.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.grdVariancesInput.Size = New System.Drawing.Size(259, 434)
        Me.grdVariancesInput.TabIndex = 999
        Me.grdVariancesInput.TabStop = False
        '
        'cmbLicenseName
        '
        Me.cmbLicenseName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbLicenseName.BackColor = System.Drawing.Color.Bisque
        Me.cmbLicenseName.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLicenseName.FormattingEnabled = True
        Me.cmbLicenseName.Items.AddRange(New Object() {"License 1", "License 2", "License 3", "License 4", "License 5", "License 6"})
        Me.cmbLicenseName.Location = New System.Drawing.Point(114, 104)
        Me.cmbLicenseName.Name = "cmbLicenseName"
        Me.cmbLicenseName.Size = New System.Drawing.Size(191, 26)
        Me.cmbLicenseName.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Goldenrod
        Me.Label1.Location = New System.Drawing.Point(7, 106)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 19)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Select Licence"
        '
        'miniToolStrip
        '
        Me.miniToolStrip.AutoSize = False
        Me.miniToolStrip.CanOverflow = False
        Me.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.miniToolStrip.Font = New System.Drawing.Font("Comic Sans MS", 9.75!)
        Me.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.miniToolStrip.ImageScalingSize = New System.Drawing.Size(28, 28)
        Me.miniToolStrip.Location = New System.Drawing.Point(152, 8)
        Me.miniToolStrip.Name = "miniToolStrip"
        Me.miniToolStrip.Size = New System.Drawing.Size(916, 35)
        Me.miniToolStrip.TabIndex = 16
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 35)
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.BurlyWood
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(26, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 23)
        Me.Label2.TabIndex = 17
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.PictureBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnCalculateVars)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ToolStrip1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmbLicenseName)
        Me.SplitContainer1.Panel1.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1061, 575)
        Me.SplitContainer1.SplitterDistance = 137
        Me.SplitContainer1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(400, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(203, 82)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Legends"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Comic Sans MS", 9.75!)
        Me.Label5.Location = New System.Drawing.Point(86, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 18)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Actual Stock"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Comic Sans MS", 9.75!)
        Me.Label3.Location = New System.Drawing.Point(86, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 18)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "System Stock"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Brown
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.ForeColor = System.Drawing.Color.Brown
        Me.Label4.Location = New System.Drawing.Point(26, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 23)
        Me.Label4.TabIndex = 19
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.CWPlus.My.Resources.Resources.variance
        Me.PictureBox1.Location = New System.Drawing.Point(8, 41)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(250, 56)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 24
        Me.PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.AutoSize = True
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.rdML)
        Me.Panel2.Controls.Add(Me.rdsPeg)
        Me.Panel2.Location = New System.Drawing.Point(830, 55)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 4)
        Me.Panel2.Size = New System.Drawing.Size(211, 35)
        Me.Panel2.TabIndex = 23
        '
        'rdML
        '
        Me.rdML.AutoSize = True
        Me.rdML.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold)
        Me.rdML.Location = New System.Drawing.Point(12, 4)
        Me.rdML.Name = "rdML"
        Me.rdML.Size = New System.Drawing.Size(90, 20)
        Me.rdML.TabIndex = 21
        Me.rdML.Tag = "M"
        Me.rdML.Text = "Show in ML"
        Me.rdML.UseVisualStyleBackColor = True
        '
        'rdsPeg
        '
        Me.rdsPeg.AutoSize = True
        Me.rdsPeg.Checked = True
        Me.rdsPeg.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold)
        Me.rdsPeg.Location = New System.Drawing.Point(108, 4)
        Me.rdsPeg.Name = "rdsPeg"
        Me.rdsPeg.Size = New System.Drawing.Size(96, 20)
        Me.rdsPeg.TabIndex = 22
        Me.rdsPeg.TabStop = True
        Me.rdsPeg.Tag = "P"
        Me.rdsPeg.Text = "Show in sPeg"
        Me.rdsPeg.UseVisualStyleBackColor = True
        '
        'btnCalculateVars
        '
        Me.btnCalculateVars.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCalculateVars.BorderColor = System.Drawing.Color.Black
        DesignerRectTracker1.IsActive = False
        DesignerRectTracker1.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker1.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btnCalculateVars.CenterPtTracker = DesignerRectTracker1
        CBlendItems1.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))}
        CBlendItems1.iPoint = New Single() {0.0!, 0.4731183!, 1.0!}
        Me.btnCalculateVars.ColorFillBlend = CBlendItems1
        Me.btnCalculateVars.ColorFillSolid = System.Drawing.SystemColors.Control
        Me.btnCalculateVars.Corners.All = CType(9, Short)
        Me.btnCalculateVars.Corners.LowerLeft = CType(9, Short)
        Me.btnCalculateVars.Corners.LowerRight = CType(9, Short)
        Me.btnCalculateVars.Corners.UpperLeft = CType(9, Short)
        Me.btnCalculateVars.Corners.UpperRight = CType(9, Short)
        Me.btnCalculateVars.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCalculateVars.FillType = CButtonLib.CButton.eFillType.GradientLinear
        Me.btnCalculateVars.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.btnCalculateVars.FocalPoints.CenterPtX = 0.979798!
        Me.btnCalculateVars.FocalPoints.CenterPtY = 0.4864865!
        Me.btnCalculateVars.FocalPoints.FocusPtX = 0.0!
        Me.btnCalculateVars.FocalPoints.FocusPtY = 0.0!
        DesignerRectTracker2.IsActive = False
        DesignerRectTracker2.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker2.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btnCalculateVars.FocusPtTracker = DesignerRectTracker2
        Me.btnCalculateVars.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCalculateVars.ForeColor = System.Drawing.Color.Black
        Me.btnCalculateVars.Image = Nothing
        Me.btnCalculateVars.ImageIndex = 0
        Me.btnCalculateVars.ImageSize = New System.Drawing.Size(16, 16)
        Me.btnCalculateVars.Location = New System.Drawing.Point(831, 97)
        Me.btnCalculateVars.Name = "btnCalculateVars"
        Me.btnCalculateVars.Shape = CButtonLib.CButton.eShape.Rectangle
        Me.btnCalculateVars.SideImage = Nothing
        Me.btnCalculateVars.SideImageSize = New System.Drawing.Size(48, 48)
        Me.btnCalculateVars.Size = New System.Drawing.Size(203, 26)
        Me.btnCalculateVars.TabIndex = 20
        Me.btnCalculateVars.Text = "Show / Calculate Variances"
        Me.btnCalculateVars.TextMargin = New System.Windows.Forms.Padding(2)
        Me.btnCalculateVars.TextShadow = System.Drawing.Color.White
        Me.btnCalculateVars.UseMnemonic = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.White
        Me.ToolStrip1.Font = New System.Drawing.Font("Comic Sans MS", 9.75!)
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(28, 28)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDate, Me.ToolStripSeparator1, Me.btnSave, Me.btnQuickControls, Me.btnExport, Me.btnExportFormat, Me.btnImport, Me.BtnSettlePlus, Me.btnSettalment})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1061, 35)
        Me.ToolStrip1.TabIndex = 16
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'lblDate
        '
        Me.lblDate.Image = Global.CWPlus.My.Resources.Resources._date
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(137, 32)
        Me.lblDate.Text = "ToolStripLabel1"
        '
        'btnSave
        '
        Me.btnSave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnSave.Image = Global.CWPlus.My.Resources.Resources.save
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(69, 32)
        Me.btnSave.Text = "&Save"
        '
        'btnQuickControls
        '
        Me.btnQuickControls.Image = Global.CWPlus.My.Resources.Resources.control_panel
        Me.btnQuickControls.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnQuickControls.Name = "btnQuickControls"
        Me.btnQuickControls.Size = New System.Drawing.Size(130, 32)
        Me.btnQuickControls.Text = "Quick Controls"
        '
        'btnExport
        '
        Me.btnExport.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnExport.Image = Global.CWPlus.My.Resources.Resources.pdf
        Me.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(144, 32)
        Me.btnExport.Text = "Export Variances"
        '
        'btnExportFormat
        '
        Me.btnExportFormat.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnExportFormat.Image = Global.CWPlus.My.Resources.Resources.excel
        Me.btnExportFormat.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportFormat.Name = "btnExportFormat"
        Me.btnExportFormat.Size = New System.Drawing.Size(190, 32)
        Me.btnExportFormat.Text = "Export Variances Format"
        '
        'btnImport
        '
        Me.btnImport.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnImport.Image = Global.CWPlus.My.Resources.Resources.excel
        Me.btnImport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(119, 32)
        Me.btnImport.Text = "Import Excel"
        '
        'BtnSettlePlus
        '
        Me.BtnSettlePlus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BtnSettlePlus.Enabled = False
        Me.BtnSettlePlus.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSettlePlus.Name = "BtnSettlePlus"
        Me.BtnSettlePlus.Size = New System.Drawing.Size(97, 32)
        Me.BtnSettlePlus.Text = "Settlement (+)"
        '
        'btnSettalment
        '
        Me.btnSettalment.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnSettalment.Enabled = False
        Me.btnSettalment.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSettalment.Name = "btnSettalment"
        Me.btnSettalment.Size = New System.Drawing.Size(96, 32)
        Me.btnSettalment.Text = "Settlement (-)"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Panel1.Location = New System.Drawing.Point(680, 48)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(213, 29)
        Me.Panel1.TabIndex = 22
        '
        'QVMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1061, 575)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "QVMain"
        Me.Text = "QVMain"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.grdQV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVariancesInput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents grdQV As System.Windows.Forms.DataGridView
    Friend WithEvents grdVariancesInput As System.Windows.Forms.DataGridView
    Friend WithEvents cmbLicenseName As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents miniToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents lblDate As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnCalculateVars As CButtonLib.CButton
    Friend WithEvents btnQuickControls As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents rdML As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rdsPeg As System.Windows.Forms.RadioButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnExportFormat As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnImport As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSettalment As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnSettlePlus As System.Windows.Forms.ToolStripButton
End Class
