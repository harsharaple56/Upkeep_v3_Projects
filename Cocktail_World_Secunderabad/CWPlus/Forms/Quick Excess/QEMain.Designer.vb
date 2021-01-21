<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QEMain
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
        Dim DesignerRectTracker1 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QEMain))
        Dim CBlendItems1 As CButtonLib.cBlendItems = New CButtonLib.cBlendItems()
        Dim DesignerRectTracker2 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Dim DesignerRectTracker3 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Dim CBlendItems2 As CButtonLib.cBlendItems = New CButtonLib.cBlendItems()
        Dim DesignerRectTracker4 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Dim DesignerRectTracker5 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Dim CBlendItems3 As CButtonLib.cBlendItems = New CButtonLib.cBlendItems()
        Dim DesignerRectTracker6 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Dim DesignerRectTracker7 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Dim CBlendItems4 As CButtonLib.cBlendItems = New CButtonLib.cBlendItems()
        Dim DesignerRectTracker8 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Dim DesignerRectTracker9 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Dim CBlendItems5 As CButtonLib.cBlendItems = New CButtonLib.cBlendItems()
        Dim DesignerRectTracker10 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Dim DesignerRectTracker11 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Dim CBlendItems6 As CButtonLib.cBlendItems = New CButtonLib.cBlendItems()
        Dim DesignerRectTracker12 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cmbLicenseName = New System.Windows.Forms.ComboBox()
        Me.Step4 = New CButtonLib.CButton()
        Me.Step3 = New CButtonLib.CButton()
        Me.Step2 = New CButtonLib.CButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Step1 = New CButtonLib.CButton()
        Me.btnToggle = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Reports1 = New CWPlus.Reports()
        Me.DecIncSales1 = New CWPlus.DecIncSales()
        Me.Sales1 = New CWPlus.Sales()
        Me.PurchaseControl1 = New CWPlus.PurchaseControl()
        Me.btnPrev = New CButtonLib.CButton()
        Me.btnNext = New CButtonLib.CButton()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.cmbLicenseName)
        Me.Panel1.Controls.Add(Me.Step4)
        Me.Panel1.Controls.Add(Me.Step3)
        Me.Panel1.Controls.Add(Me.Step2)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Step1)
        Me.Panel1.Controls.Add(Me.btnToggle)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1043, 159)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Goldenrod
        Me.Label1.Location = New System.Drawing.Point(742, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 19)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Select Licence"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PictureBox1.Image = Global.CWPlus.My.Resources.Resources.excise
        Me.PictureBox1.Location = New System.Drawing.Point(385, -2)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(269, 62)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'cmbLicenseName
        '
        Me.cmbLicenseName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbLicenseName.BackColor = System.Drawing.Color.Bisque
        Me.cmbLicenseName.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLicenseName.FormattingEnabled = True
        Me.cmbLicenseName.Items.AddRange(New Object() {"License 1", "License 2", "License 3", "License 4", "License 5", "License 6"})
        Me.cmbLicenseName.Location = New System.Drawing.Point(845, 5)
        Me.cmbLicenseName.Name = "cmbLicenseName"
        Me.cmbLicenseName.Size = New System.Drawing.Size(191, 26)
        Me.cmbLicenseName.TabIndex = 10
        '
        'Step4
        '
        Me.Step4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Step4.BorderColor = System.Drawing.Color.Black
        DesignerRectTracker1.IsActive = False
        DesignerRectTracker1.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker1.TrackerRectangle"), System.Drawing.RectangleF)
        Me.Step4.CenterPtTracker = DesignerRectTracker1
        CBlendItems1.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))}
        CBlendItems1.iPoint = New Single() {0.0!, 0.4731183!, 1.0!}
        Me.Step4.ColorFillBlend = CBlendItems1
        Me.Step4.ColorFillSolid = System.Drawing.SystemColors.Control
        Me.Step4.Corners.All = CType(-1, Short)
        Me.Step4.Corners.LowerLeft = CType(0, Short)
        Me.Step4.Corners.LowerRight = CType(17, Short)
        Me.Step4.Corners.UpperLeft = CType(0, Short)
        Me.Step4.Corners.UpperRight = CType(17, Short)
        Me.Step4.FillType = CButtonLib.CButton.eFillType.GradientLinear
        Me.Step4.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.Step4.FocalPoints.CenterPtX = 0.979798!
        Me.Step4.FocalPoints.CenterPtY = 0.4864865!
        Me.Step4.FocalPoints.FocusPtX = 0.0!
        Me.Step4.FocalPoints.FocusPtY = 0.0!
        DesignerRectTracker2.IsActive = False
        DesignerRectTracker2.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker2.TrackerRectangle"), System.Drawing.RectangleF)
        Me.Step4.FocusPtTracker = DesignerRectTracker2
        Me.Step4.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Step4.ForeColor = System.Drawing.Color.Black
        Me.Step4.Image = Nothing
        Me.Step4.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Step4.ImageIndex = 0
        Me.Step4.ImageSize = New System.Drawing.Size(16, 16)
        Me.Step4.Location = New System.Drawing.Point(647, 90)
        Me.Step4.Name = "Step4"
        Me.Step4.Shape = CButtonLib.CButton.eShape.Rectangle
        Me.Step4.SideImage = Nothing
        Me.Step4.SideImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Step4.SideImageSize = New System.Drawing.Size(48, 48)
        Me.Step4.Size = New System.Drawing.Size(96, 35)
        Me.Step4.TabIndex = 9
        Me.Step4.Text = "Step 4"
        Me.Step4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Step4.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.Step4.TextMargin = New System.Windows.Forms.Padding(2)
        Me.Step4.TextShadow = System.Drawing.Color.White
        Me.Step4.TextSmoothingMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
        Me.Step4.UseMnemonic = True
        '
        'Step3
        '
        Me.Step3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Step3.BorderColor = System.Drawing.Color.Black
        DesignerRectTracker3.IsActive = True
        DesignerRectTracker3.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker3.TrackerRectangle"), System.Drawing.RectangleF)
        Me.Step3.CenterPtTracker = DesignerRectTracker3
        CBlendItems2.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))}
        CBlendItems2.iPoint = New Single() {0.0!, 0.4731183!, 1.0!}
        Me.Step3.ColorFillBlend = CBlendItems2
        Me.Step3.ColorFillSolid = System.Drawing.SystemColors.Control
        Me.Step3.Corners.All = CType(-1, Short)
        Me.Step3.Corners.LowerLeft = CType(0, Short)
        Me.Step3.Corners.LowerRight = CType(17, Short)
        Me.Step3.Corners.UpperLeft = CType(0, Short)
        Me.Step3.Corners.UpperRight = CType(17, Short)
        Me.Step3.FillType = CButtonLib.CButton.eFillType.GradientLinear
        Me.Step3.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.Step3.FocalPoints.CenterPtX = 0.979798!
        Me.Step3.FocalPoints.CenterPtY = 0.4864865!
        Me.Step3.FocalPoints.FocusPtX = 0.0!
        Me.Step3.FocalPoints.FocusPtY = 0.0!
        DesignerRectTracker4.IsActive = False
        DesignerRectTracker4.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker4.TrackerRectangle"), System.Drawing.RectangleF)
        Me.Step3.FocusPtTracker = DesignerRectTracker4
        Me.Step3.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Step3.ForeColor = System.Drawing.Color.Black
        Me.Step3.Image = Nothing
        Me.Step3.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Step3.ImageIndex = 0
        Me.Step3.ImageSize = New System.Drawing.Size(16, 16)
        Me.Step3.Location = New System.Drawing.Point(528, 90)
        Me.Step3.Name = "Step3"
        Me.Step3.Shape = CButtonLib.CButton.eShape.Rectangle
        Me.Step3.SideImage = Nothing
        Me.Step3.SideImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Step3.SideImageSize = New System.Drawing.Size(48, 48)
        Me.Step3.Size = New System.Drawing.Size(96, 35)
        Me.Step3.TabIndex = 8
        Me.Step3.Text = "Step 3"
        Me.Step3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Step3.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.Step3.TextMargin = New System.Windows.Forms.Padding(2)
        Me.Step3.TextShadow = System.Drawing.Color.White
        Me.Step3.TextSmoothingMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
        Me.Step3.UseMnemonic = True
        '
        'Step2
        '
        Me.Step2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Step2.BorderColor = System.Drawing.Color.Black
        DesignerRectTracker5.IsActive = False
        DesignerRectTracker5.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker5.TrackerRectangle"), System.Drawing.RectangleF)
        Me.Step2.CenterPtTracker = DesignerRectTracker5
        CBlendItems3.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))}
        CBlendItems3.iPoint = New Single() {0.0!, 0.4731183!, 1.0!}
        Me.Step2.ColorFillBlend = CBlendItems3
        Me.Step2.ColorFillSolid = System.Drawing.SystemColors.Control
        Me.Step2.Corners.All = CType(-1, Short)
        Me.Step2.Corners.LowerLeft = CType(0, Short)
        Me.Step2.Corners.LowerRight = CType(17, Short)
        Me.Step2.Corners.UpperLeft = CType(0, Short)
        Me.Step2.Corners.UpperRight = CType(17, Short)
        Me.Step2.FillType = CButtonLib.CButton.eFillType.GradientLinear
        Me.Step2.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.Step2.FocalPoints.CenterPtX = 0.979798!
        Me.Step2.FocalPoints.CenterPtY = 0.4864865!
        Me.Step2.FocalPoints.FocusPtX = 0.0!
        Me.Step2.FocalPoints.FocusPtY = 0.0!
        DesignerRectTracker6.IsActive = False
        DesignerRectTracker6.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker6.TrackerRectangle"), System.Drawing.RectangleF)
        Me.Step2.FocusPtTracker = DesignerRectTracker6
        Me.Step2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Step2.ForeColor = System.Drawing.Color.Black
        Me.Step2.Image = Nothing
        Me.Step2.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Step2.ImageIndex = 0
        Me.Step2.ImageSize = New System.Drawing.Size(16, 16)
        Me.Step2.Location = New System.Drawing.Point(409, 90)
        Me.Step2.Name = "Step2"
        Me.Step2.Shape = CButtonLib.CButton.eShape.Rectangle
        Me.Step2.SideImage = Nothing
        Me.Step2.SideImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Step2.SideImageSize = New System.Drawing.Size(48, 48)
        Me.Step2.Size = New System.Drawing.Size(96, 35)
        Me.Step2.TabIndex = 7
        Me.Step2.Text = "Step 2"
        Me.Step2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Step2.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.Step2.TextMargin = New System.Windows.Forms.Padding(2)
        Me.Step2.TextShadow = System.Drawing.Color.White
        Me.Step2.TextSmoothingMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
        Me.Step2.UseMnemonic = True
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(200, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(639, 32)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Lets Entry Purchase" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Enter TP no. – Enter Vendor – Choose Brand name – Enter quan" & _
            "tity – Check purchase price, edit if required"
        '
        'Step1
        '
        Me.Step1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Step1.BorderColor = System.Drawing.Color.Black
        DesignerRectTracker7.IsActive = False
        DesignerRectTracker7.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker7.TrackerRectangle"), System.Drawing.RectangleF)
        Me.Step1.CenterPtTracker = DesignerRectTracker7
        CBlendItems4.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))}
        CBlendItems4.iPoint = New Single() {0.0!, 0.4731183!, 1.0!}
        Me.Step1.ColorFillBlend = CBlendItems4
        Me.Step1.ColorFillSolid = System.Drawing.SystemColors.Control
        Me.Step1.Corners.All = CType(-1, Short)
        Me.Step1.Corners.LowerLeft = CType(0, Short)
        Me.Step1.Corners.LowerRight = CType(17, Short)
        Me.Step1.Corners.UpperLeft = CType(0, Short)
        Me.Step1.Corners.UpperRight = CType(17, Short)
        Me.Step1.FillType = CButtonLib.CButton.eFillType.GradientLinear
        Me.Step1.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.Step1.FocalPoints.CenterPtX = 0.979798!
        Me.Step1.FocalPoints.CenterPtY = 0.4864865!
        Me.Step1.FocalPoints.FocusPtX = 0.0!
        Me.Step1.FocalPoints.FocusPtY = 0.0!
        DesignerRectTracker8.IsActive = False
        DesignerRectTracker8.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker8.TrackerRectangle"), System.Drawing.RectangleF)
        Me.Step1.FocusPtTracker = DesignerRectTracker8
        Me.Step1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Step1.ForeColor = System.Drawing.Color.Black
        Me.Step1.Image = Nothing
        Me.Step1.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Step1.ImageIndex = 0
        Me.Step1.ImageSize = New System.Drawing.Size(16, 16)
        Me.Step1.Location = New System.Drawing.Point(290, 90)
        Me.Step1.Name = "Step1"
        Me.Step1.Shape = CButtonLib.CButton.eShape.Rectangle
        Me.Step1.SideImage = Nothing
        Me.Step1.SideImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Step1.SideImageSize = New System.Drawing.Size(48, 48)
        Me.Step1.Size = New System.Drawing.Size(96, 35)
        Me.Step1.TabIndex = 2
        Me.Step1.Text = "Step 1"
        Me.Step1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Step1.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.Step1.TextMargin = New System.Windows.Forms.Padding(2)
        Me.Step1.TextShadow = System.Drawing.Color.White
        Me.Step1.TextSmoothingMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
        Me.Step1.UseMnemonic = True
        '
        'btnToggle
        '
        Me.btnToggle.Cursor = System.Windows.Forms.Cursors.SizeNS
        Me.btnToggle.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnToggle.Font = New System.Drawing.Font("Comic Sans MS", 8.75!, System.Drawing.FontStyle.Bold)
        Me.btnToggle.Image = Global.CWPlus.My.Resources.Resources._1335851911_arrow_sans_up_32
        Me.btnToggle.Location = New System.Drawing.Point(0, 132)
        Me.btnToggle.Margin = New System.Windows.Forms.Padding(0)
        Me.btnToggle.Name = "btnToggle"
        Me.btnToggle.Size = New System.Drawing.Size(1039, 23)
        Me.btnToggle.TabIndex = 0
        Me.btnToggle.Tag = "1"
        Me.btnToggle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnToggle.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 5
        '
        'Timer2
        '
        Me.Timer2.Interval = 5
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 159)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Reports1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DecIncSales1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Sales1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.PurchaseControl1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnPrev)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnNext)
        Me.SplitContainer1.Size = New System.Drawing.Size(1043, 583)
        Me.SplitContainer1.SplitterDistance = 526
        Me.SplitContainer1.TabIndex = 2
        '
        'Reports1
        '
        Me.Reports1.BackColor = System.Drawing.Color.White
        Me.Reports1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Reports1.Location = New System.Drawing.Point(205, 89)
        Me.Reports1.Name = "Reports1"
        Me.Reports1.Size = New System.Drawing.Size(589, 378)
        Me.Reports1.TabIndex = 3
        '
        'DecIncSales1
        '
        Me.DecIncSales1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DecIncSales1.Location = New System.Drawing.Point(88, 6)
        Me.DecIncSales1.Name = "DecIncSales1"
        Me.DecIncSales1.Size = New System.Drawing.Size(855, 438)
        Me.DecIncSales1.TabIndex = 2
        '
        'Sales1
        '
        Me.Sales1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Sales1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Sales1.Location = New System.Drawing.Point(88, 6)
        Me.Sales1.Name = "Sales1"
        Me.Sales1.Size = New System.Drawing.Size(797, 493)
        Me.Sales1.TabIndex = 1
        '
        'PurchaseControl1
        '
        Me.PurchaseControl1.BackColor = System.Drawing.Color.LightGray
        Me.PurchaseControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PurchaseControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PurchaseControl1.Location = New System.Drawing.Point(38, 3)
        Me.PurchaseControl1.Name = "PurchaseControl1"
        Me.PurchaseControl1.PurchaseID = 0.0R
        Me.PurchaseControl1.Size = New System.Drawing.Size(662, 238)
        Me.PurchaseControl1.TabIndex = 0
        '
        'btnPrev
        '
        Me.btnPrev.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnPrev.BorderColor = System.Drawing.Color.Black
        DesignerRectTracker9.IsActive = True
        DesignerRectTracker9.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker9.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btnPrev.CenterPtTracker = DesignerRectTracker9
        CBlendItems5.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))}
        CBlendItems5.iPoint = New Single() {0.0!, 0.2544803!, 0.6953405!, 1.0!}
        Me.btnPrev.ColorFillBlend = CBlendItems5
        Me.btnPrev.ColorFillSolid = System.Drawing.SystemColors.Control
        Me.btnPrev.Corners.All = CType(-1, Short)
        Me.btnPrev.Corners.LowerLeft = CType(21, Short)
        Me.btnPrev.Corners.LowerRight = CType(0, Short)
        Me.btnPrev.Corners.UpperLeft = CType(21, Short)
        Me.btnPrev.Corners.UpperRight = CType(0, Short)
        Me.btnPrev.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrev.FillType = CButtonLib.CButton.eFillType.GradientLinear
        Me.btnPrev.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.btnPrev.FocalPoints.CenterPtX = 0.979798!
        Me.btnPrev.FocalPoints.CenterPtY = 0.4864865!
        Me.btnPrev.FocalPoints.FocusPtX = 0.0!
        Me.btnPrev.FocalPoints.FocusPtY = 0.0!
        DesignerRectTracker10.IsActive = False
        DesignerRectTracker10.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker10.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btnPrev.FocusPtTracker = DesignerRectTracker10
        Me.btnPrev.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnPrev.ForeColor = System.Drawing.Color.Black
        Me.btnPrev.Image = Nothing
        Me.btnPrev.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnPrev.ImageIndex = 0
        Me.btnPrev.ImageSize = New System.Drawing.Size(16, 16)
        Me.btnPrev.Location = New System.Drawing.Point(205, 4)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Shape = CButtonLib.CButton.eShape.Rectangle
        Me.btnPrev.SideImage = Global.CWPlus.My.Resources.Resources.previous
        Me.btnPrev.SideImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrev.SideImageSize = New System.Drawing.Size(45, 38)
        Me.btnPrev.Size = New System.Drawing.Size(52, 43)
        Me.btnPrev.TabIndex = 4
        Me.btnPrev.Text = ""
        Me.btnPrev.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnPrev.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.btnPrev.TextMargin = New System.Windows.Forms.Padding(2)
        Me.btnPrev.TextShadow = System.Drawing.Color.White
        Me.btnPrev.TextSmoothingMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
        Me.btnPrev.UseMnemonic = True
        '
        'btnNext
        '
        Me.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnNext.BorderColor = System.Drawing.Color.Black
        DesignerRectTracker11.IsActive = False
        DesignerRectTracker11.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker11.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btnNext.CenterPtTracker = DesignerRectTracker11
        CBlendItems6.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))}
        CBlendItems6.iPoint = New Single() {0.0!, 0.2544803!, 0.6953405!, 1.0!}
        Me.btnNext.ColorFillBlend = CBlendItems6
        Me.btnNext.ColorFillSolid = System.Drawing.SystemColors.Control
        Me.btnNext.Corners.All = CType(-1, Short)
        Me.btnNext.Corners.LowerLeft = CType(0, Short)
        Me.btnNext.Corners.LowerRight = CType(21, Short)
        Me.btnNext.Corners.UpperLeft = CType(0, Short)
        Me.btnNext.Corners.UpperRight = CType(21, Short)
        Me.btnNext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNext.FillType = CButtonLib.CButton.eFillType.GradientLinear
        Me.btnNext.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.btnNext.FocalPoints.CenterPtX = 0.979798!
        Me.btnNext.FocalPoints.CenterPtY = 0.4864865!
        Me.btnNext.FocalPoints.FocusPtX = 0.0!
        Me.btnNext.FocalPoints.FocusPtY = 0.0!
        DesignerRectTracker12.IsActive = False
        DesignerRectTracker12.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker12.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btnNext.FocusPtTracker = DesignerRectTracker12
        Me.btnNext.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnNext.ForeColor = System.Drawing.Color.Black
        Me.btnNext.Image = Nothing
        Me.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnNext.ImageIndex = 0
        Me.btnNext.ImageSize = New System.Drawing.Size(16, 16)
        Me.btnNext.Location = New System.Drawing.Point(773, 4)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Shape = CButtonLib.CButton.eShape.Rectangle
        Me.btnNext.SideImage = Global.CWPlus.My.Resources.Resources._next
        Me.btnNext.SideImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNext.SideImageSize = New System.Drawing.Size(45, 36)
        Me.btnNext.Size = New System.Drawing.Size(52, 43)
        Me.btnNext.TabIndex = 3
        Me.btnNext.Text = ""
        Me.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.btnNext.TextMargin = New System.Windows.Forms.Padding(2)
        Me.btnNext.TextShadow = System.Drawing.Color.White
        Me.btnNext.TextSmoothingMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
        Me.btnNext.UseMnemonic = True
        '
        'QEMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1043, 742)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "QEMain"
        Me.Text = "Quick Excise"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnToggle As System.Windows.Forms.Button
    Friend WithEvents Step1 As CButtonLib.CButton
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Step4 As CButtonLib.CButton
    Friend WithEvents Step3 As CButtonLib.CButton
    Friend WithEvents Step2 As CButtonLib.CButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents PurchaseControl1 As CWPlus.PurchaseControl
    Friend WithEvents cmbLicenseName As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnNext As CButtonLib.CButton
    Friend WithEvents btnPrev As CButtonLib.CButton
    Friend WithEvents Sales1 As CWPlus.Sales
    Friend WithEvents DecIncSales1 As CWPlus.DecIncSales
    Friend WithEvents Reports1 As CWPlus.Reports

End Class
