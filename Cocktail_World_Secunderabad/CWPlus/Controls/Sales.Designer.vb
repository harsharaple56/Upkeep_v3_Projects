<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sales))
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.grdTpNoByLicenseNo = New System.Windows.Forms.DataGridView()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.lblBillingTitle = New System.Windows.Forms.Label()
        Me.btnAmount = New CButtonLib.CButton()
        Me.btnConsumption = New CButtonLib.CButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAutoBill = New CButtonLib.CButton()
        Me.CButton1 = New CButtonLib.CButton()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.autoLine4 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.autoLine3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.autoLine2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.autoLine1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape4 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.SaleAutoBill1 = New CWPlus.SaleAutoBill()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.grdTpNoByLicenseNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
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
        Me.SplitContainer1.Size = New System.Drawing.Size(1055, 556)
        Me.SplitContainer1.SplitterDistance = 140
        Me.SplitContainer1.SplitterWidth = 6
        Me.SplitContainer1.TabIndex = 4
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
        Me.grdTpNoByLicenseNo.Size = New System.Drawing.Size(140, 556)
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
        Me.SplitContainer2.Panel1.Controls.Add(Me.SaleAutoBill1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblBillingTitle)
        Me.SplitContainer2.Panel1.Controls.Add(Me.btnAmount)
        Me.SplitContainer2.Panel1.Controls.Add(Me.btnConsumption)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.btnAutoBill)
        Me.SplitContainer2.Panel1.Controls.Add(Me.CButton1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.ShapeContainer1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.BackColor = System.Drawing.Color.White
        Me.SplitContainer2.Size = New System.Drawing.Size(909, 556)
        Me.SplitContainer2.SplitterDistance = 723
        Me.SplitContainer2.SplitterWidth = 6
        Me.SplitContainer2.TabIndex = 2
        '
        'lblBillingTitle
        '
        Me.lblBillingTitle.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblBillingTitle.AutoSize = True
        Me.lblBillingTitle.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBillingTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblBillingTitle.Location = New System.Drawing.Point(268, 223)
        Me.lblBillingTitle.Name = "lblBillingTitle"
        Me.lblBillingTitle.Size = New System.Drawing.Size(120, 17)
        Me.lblBillingTitle.TabIndex = 15
        Me.lblBillingTitle.Text = "Select Billing Types"
        '
        'btnAmount
        '
        Me.btnAmount.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnAmount.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DesignerRectTracker1.IsActive = False
        DesignerRectTracker1.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker1.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btnAmount.CenterPtTracker = DesignerRectTracker1
        CBlendItems1.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))}
        CBlendItems1.iPoint = New Single() {0.0!, 0.4731183!, 1.0!}
        Me.btnAmount.ColorFillBlend = CBlendItems1
        Me.btnAmount.ColorFillSolid = System.Drawing.SystemColors.Control
        Me.btnAmount.Corners.All = CType(16, Short)
        Me.btnAmount.Corners.LowerLeft = CType(16, Short)
        Me.btnAmount.Corners.LowerRight = CType(16, Short)
        Me.btnAmount.Corners.UpperLeft = CType(16, Short)
        Me.btnAmount.Corners.UpperRight = CType(16, Short)
        Me.btnAmount.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAmount.FillType = CButtonLib.CButton.eFillType.GradientLinear
        Me.btnAmount.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.btnAmount.FocalPoints.CenterPtX = 0.979798!
        Me.btnAmount.FocalPoints.CenterPtY = 0.4864865!
        Me.btnAmount.FocalPoints.FocusPtX = 0.0!
        Me.btnAmount.FocalPoints.FocusPtY = 0.0!
        DesignerRectTracker2.IsActive = False
        DesignerRectTracker2.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker2.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btnAmount.FocusPtTracker = DesignerRectTracker2
        Me.btnAmount.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Bold)
        Me.btnAmount.ForeColor = System.Drawing.Color.DarkRed
        Me.btnAmount.Image = Nothing
        Me.btnAmount.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAmount.ImageIndex = 0
        Me.btnAmount.ImageSize = New System.Drawing.Size(16, 16)
        Me.btnAmount.Location = New System.Drawing.Point(457, 295)
        Me.btnAmount.Name = "btnAmount"
        Me.btnAmount.Shape = CButtonLib.CButton.eShape.Rectangle
        Me.btnAmount.SideImage = Nothing
        Me.btnAmount.SideImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAmount.SideImageSize = New System.Drawing.Size(48, 48)
        Me.btnAmount.Size = New System.Drawing.Size(108, 38)
        Me.btnAmount.TabIndex = 13
        Me.btnAmount.Text = "Amount"
        Me.btnAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAmount.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.btnAmount.TextMargin = New System.Windows.Forms.Padding(2)
        Me.btnAmount.TextShadow = System.Drawing.Color.Black
        Me.btnAmount.TextShadowShow = False
        Me.btnAmount.TextSmoothingMode = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit
        Me.btnAmount.UseMnemonic = True
        '
        'btnConsumption
        '
        Me.btnConsumption.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnConsumption.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DesignerRectTracker3.IsActive = False
        DesignerRectTracker3.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker3.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btnConsumption.CenterPtTracker = DesignerRectTracker3
        CBlendItems2.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))}
        CBlendItems2.iPoint = New Single() {0.0!, 0.4731183!, 1.0!}
        Me.btnConsumption.ColorFillBlend = CBlendItems2
        Me.btnConsumption.ColorFillSolid = System.Drawing.SystemColors.Control
        Me.btnConsumption.Corners.All = CType(16, Short)
        Me.btnConsumption.Corners.LowerLeft = CType(16, Short)
        Me.btnConsumption.Corners.LowerRight = CType(16, Short)
        Me.btnConsumption.Corners.UpperLeft = CType(16, Short)
        Me.btnConsumption.Corners.UpperRight = CType(16, Short)
        Me.btnConsumption.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsumption.FillType = CButtonLib.CButton.eFillType.GradientLinear
        Me.btnConsumption.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.btnConsumption.FocalPoints.CenterPtX = 0.979798!
        Me.btnConsumption.FocalPoints.CenterPtY = 0.4864865!
        Me.btnConsumption.FocalPoints.FocusPtX = 0.0!
        Me.btnConsumption.FocalPoints.FocusPtY = 0.0!
        DesignerRectTracker4.IsActive = False
        DesignerRectTracker4.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker4.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btnConsumption.FocusPtTracker = DesignerRectTracker4
        Me.btnConsumption.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Bold)
        Me.btnConsumption.ForeColor = System.Drawing.Color.DarkRed
        Me.btnConsumption.Image = Nothing
        Me.btnConsumption.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnConsumption.ImageIndex = 0
        Me.btnConsumption.ImageSize = New System.Drawing.Size(16, 16)
        Me.btnConsumption.Location = New System.Drawing.Point(148, 295)
        Me.btnConsumption.Name = "btnConsumption"
        Me.btnConsumption.Shape = CButtonLib.CButton.eShape.Rectangle
        Me.btnConsumption.SideImage = Nothing
        Me.btnConsumption.SideImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsumption.SideImageSize = New System.Drawing.Size(48, 48)
        Me.btnConsumption.Size = New System.Drawing.Size(108, 38)
        Me.btnConsumption.TabIndex = 7
        Me.btnConsumption.Text = "Consumption"
        Me.btnConsumption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnConsumption.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.btnConsumption.TextMargin = New System.Windows.Forms.Padding(2)
        Me.btnConsumption.TextShadow = System.Drawing.Color.Maroon
        Me.btnConsumption.TextShadowShow = False
        Me.btnConsumption.TextSmoothingMode = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit
        Me.btnConsumption.UseMnemonic = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Comic Sans MS", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Olive
        Me.Label1.Location = New System.Drawing.Point(323, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 40)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Sale"
        '
        'btnAutoBill
        '
        Me.btnAutoBill.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnAutoBill.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DesignerRectTracker5.IsActive = False
        DesignerRectTracker5.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker5.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btnAutoBill.CenterPtTracker = DesignerRectTracker5
        CBlendItems3.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(224, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(210, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(179, Byte), Integer))}
        CBlendItems3.iPoint = New Single() {0.0!, 0.5412186!, 1.0!}
        Me.btnAutoBill.ColorFillBlend = CBlendItems3
        Me.btnAutoBill.ColorFillSolid = System.Drawing.SystemColors.Control
        Me.btnAutoBill.Corners.All = CType(16, Short)
        Me.btnAutoBill.Corners.LowerLeft = CType(16, Short)
        Me.btnAutoBill.Corners.LowerRight = CType(16, Short)
        Me.btnAutoBill.Corners.UpperLeft = CType(16, Short)
        Me.btnAutoBill.Corners.UpperRight = CType(16, Short)
        Me.btnAutoBill.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAutoBill.FillType = CButtonLib.CButton.eFillType.GradientLinear
        Me.btnAutoBill.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.btnAutoBill.FocalPoints.CenterPtX = 0.979798!
        Me.btnAutoBill.FocalPoints.CenterPtY = 0.4864865!
        Me.btnAutoBill.FocalPoints.FocusPtX = 0.0!
        Me.btnAutoBill.FocalPoints.FocusPtY = 0.0!
        DesignerRectTracker6.IsActive = False
        DesignerRectTracker6.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker6.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btnAutoBill.FocusPtTracker = DesignerRectTracker6
        Me.btnAutoBill.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnAutoBill.ForeColor = System.Drawing.Color.Black
        Me.btnAutoBill.Image = Nothing
        Me.btnAutoBill.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAutoBill.ImageIndex = 0
        Me.btnAutoBill.ImageSize = New System.Drawing.Size(16, 16)
        Me.btnAutoBill.Location = New System.Drawing.Point(457, 145)
        Me.btnAutoBill.Name = "btnAutoBill"
        Me.btnAutoBill.Shape = CButtonLib.CButton.eShape.Rectangle
        Me.btnAutoBill.SideImage = Nothing
        Me.btnAutoBill.SideImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAutoBill.SideImageSize = New System.Drawing.Size(48, 48)
        Me.btnAutoBill.Size = New System.Drawing.Size(113, 43)
        Me.btnAutoBill.TabIndex = 4
        Me.btnAutoBill.Text = "Autobill"
        Me.btnAutoBill.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAutoBill.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.btnAutoBill.TextMargin = New System.Windows.Forms.Padding(2)
        Me.btnAutoBill.TextShadow = System.Drawing.Color.White
        Me.btnAutoBill.TextShadowShow = False
        Me.btnAutoBill.TextSmoothingMode = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit
        Me.btnAutoBill.UseMnemonic = True
        '
        'CButton1
        '
        Me.CButton1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.CButton1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DesignerRectTracker7.IsActive = False
        DesignerRectTracker7.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker7.TrackerRectangle"), System.Drawing.RectangleF)
        Me.CButton1.CenterPtTracker = DesignerRectTracker7
        CBlendItems4.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(224, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(210, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(179, Byte), Integer))}
        CBlendItems4.iPoint = New Single() {0.0!, 0.5412186!, 1.0!}
        Me.CButton1.ColorFillBlend = CBlendItems4
        Me.CButton1.ColorFillSolid = System.Drawing.SystemColors.Control
        Me.CButton1.Corners.All = CType(16, Short)
        Me.CButton1.Corners.LowerLeft = CType(16, Short)
        Me.CButton1.Corners.LowerRight = CType(16, Short)
        Me.CButton1.Corners.UpperLeft = CType(16, Short)
        Me.CButton1.Corners.UpperRight = CType(16, Short)
        Me.CButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CButton1.FillType = CButtonLib.CButton.eFillType.GradientLinear
        Me.CButton1.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.CButton1.FocalPoints.CenterPtX = 0.979798!
        Me.CButton1.FocalPoints.CenterPtY = 0.4864865!
        Me.CButton1.FocalPoints.FocusPtX = 0.0!
        Me.CButton1.FocalPoints.FocusPtY = 0.0!
        DesignerRectTracker8.IsActive = False
        DesignerRectTracker8.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker8.TrackerRectangle"), System.Drawing.RectangleF)
        Me.CButton1.FocusPtTracker = DesignerRectTracker8
        Me.CButton1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.CButton1.ForeColor = System.Drawing.Color.Black
        Me.CButton1.Image = Nothing
        Me.CButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CButton1.ImageIndex = 0
        Me.CButton1.ImageSize = New System.Drawing.Size(16, 16)
        Me.CButton1.Location = New System.Drawing.Point(153, 145)
        Me.CButton1.Name = "CButton1"
        Me.CButton1.Shape = CButtonLib.CButton.eShape.Rectangle
        Me.CButton1.SideImage = Nothing
        Me.CButton1.SideImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CButton1.SideImageSize = New System.Drawing.Size(48, 48)
        Me.CButton1.Size = New System.Drawing.Size(113, 43)
        Me.CButton1.TabIndex = 3
        Me.CButton1.Text = "Interface"
        Me.CButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.CButton1.TextMargin = New System.Windows.Forms.Padding(2)
        Me.CButton1.TextShadow = System.Drawing.Color.White
        Me.CButton1.TextShadowShow = False
        Me.CButton1.TextSmoothingMode = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit
        Me.CButton1.UseMnemonic = True
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.autoLine4, Me.autoLine3, Me.autoLine2, Me.autoLine1, Me.LineShape4, Me.LineShape3, Me.LineShape2, Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(723, 556)
        Me.ShapeContainer1.TabIndex = 5
        Me.ShapeContainer1.TabStop = False
        '
        'autoLine4
        '
        Me.autoLine4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.autoLine4.Name = "autoLine4"
        Me.autoLine4.X1 = 514
        Me.autoLine4.X2 = 514
        Me.autoLine4.Y1 = 293
        Me.autoLine4.Y2 = 242
        '
        'autoLine3
        '
        Me.autoLine3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.autoLine3.Name = "autoLine3"
        Me.autoLine3.X1 = 201
        Me.autoLine3.X2 = 201
        Me.autoLine3.Y1 = 292
        Me.autoLine3.Y2 = 241
        '
        'autoLine2
        '
        Me.autoLine2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.autoLine2.Name = "autoLine2"
        Me.autoLine2.X1 = 202
        Me.autoLine2.X2 = 514
        Me.autoLine2.Y1 = 241
        Me.autoLine2.Y2 = 241
        '
        'autoLine1
        '
        Me.autoLine1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.autoLine1.Name = "autoLine1"
        Me.autoLine1.X1 = 514
        Me.autoLine1.X2 = 514
        Me.autoLine1.Y1 = 240
        Me.autoLine1.Y2 = 189
        '
        'LineShape4
        '
        Me.LineShape4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LineShape4.Name = "LineShape4"
        Me.LineShape4.X1 = 360
        Me.LineShape4.X2 = 360
        Me.LineShape4.Y1 = 88
        Me.LineShape4.Y2 = 37
        '
        'LineShape3
        '
        Me.LineShape3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LineShape3.Name = "LineShape3"
        Me.LineShape3.X1 = 513
        Me.LineShape3.X2 = 513
        Me.LineShape3.Y1 = 140
        Me.LineShape3.Y2 = 89
        '
        'LineShape2
        '
        Me.LineShape2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 201
        Me.LineShape2.X2 = 513
        Me.LineShape2.Y1 = 88
        Me.LineShape2.Y2 = 88
        '
        'LineShape1
        '
        Me.LineShape1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 201
        Me.LineShape1.X2 = 201
        Me.LineShape1.Y1 = 140
        Me.LineShape1.Y2 = 89
        '
        'SaleAutoBill1
        '
        Me.SaleAutoBill1.BackColor = System.Drawing.Color.MintCream
        Me.SaleAutoBill1.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.SaleAutoBill1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.SaleAutoBill1.gblMlType = Nothing
        Me.SaleAutoBill1.Location = New System.Drawing.Point(64, 370)
        Me.SaleAutoBill1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SaleAutoBill1.Name = "SaleAutoBill1"
        Me.SaleAutoBill1.Size = New System.Drawing.Size(324, 210)
        Me.SaleAutoBill1.TabIndex = 16
        Me.SaleAutoBill1.Visible = False
        '
        'Sales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "Sales"
        Me.Size = New System.Drawing.Size(1055, 556)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.grdTpNoByLicenseNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents grdTpNoByLicenseNo As System.Windows.Forms.DataGridView
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAutoBill As CButtonLib.CButton
    Friend WithEvents CButton1 As CButtonLib.CButton
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape4 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape3 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents btnAmount As CButtonLib.CButton
    Friend WithEvents btnConsumption As CButtonLib.CButton
    Friend WithEvents autoLine4 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents autoLine3 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents autoLine2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents autoLine1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents lblBillingTitle As System.Windows.Forms.Label
    Friend WithEvents SaleAutoBill1 As CWPlus.SaleAutoBill

End Class
