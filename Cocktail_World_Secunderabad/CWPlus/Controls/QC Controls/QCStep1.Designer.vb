<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QCStep1
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
        Dim DesignerRectTracker1 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QCStep1))
        Dim CBlendItems1 As CButtonLib.cBlendItems = New CButtonLib.cBlendItems()
        Dim DesignerRectTracker2 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Dim DesignerRectTracker3 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Dim CBlendItems2 As CButtonLib.cBlendItems = New CButtonLib.cBlendItems()
        Dim DesignerRectTracker4 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Dim DesignerRectTracker5 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Dim CBlendItems3 As CButtonLib.cBlendItems = New CButtonLib.cBlendItems()
        Dim DesignerRectTracker6 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rbtnAverageCost = New System.Windows.Forms.RadioButton()
        Me.rbtnMasterCost = New System.Windows.Forms.RadioButton()
        Me.rbtnToatlCost = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnTag1 = New CButtonLib.CButton()
        Me.BtnTag3 = New CButtonLib.CButton()
        Me.Btntag2 = New CButtonLib.CButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblAverageCost = New System.Windows.Forms.Label()
        Me.lblMasterRate = New System.Windows.Forms.Label()
        Me.lblFromDate = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbltext = New System.Windows.Forms.Label()
        Me.lblTotalCost = New System.Windows.Forms.Label()
        Me.grdQuickControl = New ThemedDataGrid.MKDataGridView()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdQuickControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.OldLace
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdQuickControl)
        Me.SplitContainer1.Size = New System.Drawing.Size(591, 477)
        Me.SplitContainer1.SplitterDistance = 154
        Me.SplitContainer1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.rbtnAverageCost)
        Me.Panel2.Controls.Add(Me.rbtnMasterCost)
        Me.Panel2.Controls.Add(Me.rbtnToatlCost)
        Me.Panel2.Location = New System.Drawing.Point(17, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(549, 64)
        Me.Panel2.TabIndex = 1024
        '
        'rbtnAverageCost
        '
        Me.rbtnAverageCost.AutoSize = True
        Me.rbtnAverageCost.Location = New System.Drawing.Point(358, 3)
        Me.rbtnAverageCost.Name = "rbtnAverageCost"
        Me.rbtnAverageCost.Size = New System.Drawing.Size(101, 22)
        Me.rbtnAverageCost.TabIndex = 2
        Me.rbtnAverageCost.Text = "AverageCost"
        Me.rbtnAverageCost.UseVisualStyleBackColor = True
        '
        'rbtnMasterCost
        '
        Me.rbtnMasterCost.AutoSize = True
        Me.rbtnMasterCost.Location = New System.Drawing.Point(167, 3)
        Me.rbtnMasterCost.Name = "rbtnMasterCost"
        Me.rbtnMasterCost.Size = New System.Drawing.Size(94, 22)
        Me.rbtnMasterCost.TabIndex = 1
        Me.rbtnMasterCost.Text = "MasterCost"
        Me.rbtnMasterCost.UseVisualStyleBackColor = True
        '
        'rbtnToatlCost
        '
        Me.rbtnToatlCost.AutoSize = True
        Me.rbtnToatlCost.Location = New System.Drawing.Point(13, 3)
        Me.rbtnToatlCost.Name = "rbtnToatlCost"
        Me.rbtnToatlCost.Size = New System.Drawing.Size(78, 22)
        Me.rbtnToatlCost.TabIndex = 0
        Me.rbtnToatlCost.Text = "FifoCost"
        Me.rbtnToatlCost.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.BtnTag1)
        Me.GroupBox1.Controls.Add(Me.BtnTag3)
        Me.GroupBox1.Controls.Add(Me.Btntag2)
        Me.GroupBox1.Location = New System.Drawing.Point(283, 76)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(293, 66)
        Me.GroupBox1.TabIndex = 1023
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Group By :"
        Me.GroupBox1.Visible = False
        '
        'BtnTag1
        '
        Me.BtnTag1.BackColor = System.Drawing.SystemColors.Control
        Me.BtnTag1.BorderColor = System.Drawing.Color.Green
        DesignerRectTracker1.IsActive = False
        DesignerRectTracker1.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker1.TrackerRectangle"), System.Drawing.RectangleF)
        Me.BtnTag1.CenterPtTracker = DesignerRectTracker1
        CBlendItems1.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(205, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(246, Byte), Integer))}
        CBlendItems1.iPoint = New Single() {0.0!, 1.0!}
        Me.BtnTag1.ColorFillBlend = CBlendItems1
        Me.BtnTag1.ColorFillSolid = System.Drawing.Color.DarkGray
        Me.BtnTag1.Corners.All = CType(9, Short)
        Me.BtnTag1.Corners.LowerLeft = CType(9, Short)
        Me.BtnTag1.Corners.LowerRight = CType(9, Short)
        Me.BtnTag1.Corners.UpperLeft = CType(9, Short)
        Me.BtnTag1.Corners.UpperRight = CType(9, Short)
        Me.BtnTag1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnTag1.FillType = CButtonLib.CButton.eFillType.Solid
        Me.BtnTag1.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal
        Me.BtnTag1.FocalPoints.CenterPtX = 1.0!
        Me.BtnTag1.FocalPoints.CenterPtY = 1.0!
        Me.BtnTag1.FocalPoints.FocusPtX = 0.0!
        Me.BtnTag1.FocalPoints.FocusPtY = 0.0!
        DesignerRectTracker2.IsActive = False
        DesignerRectTracker2.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker2.TrackerRectangle"), System.Drawing.RectangleF)
        Me.BtnTag1.FocusPtTracker = DesignerRectTracker2
        Me.BtnTag1.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTag1.ForeColor = System.Drawing.Color.Black
        Me.BtnTag1.Image = Nothing
        Me.BtnTag1.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BtnTag1.ImageIndex = 0
        Me.BtnTag1.ImageSize = New System.Drawing.Size(16, 16)
        Me.BtnTag1.Location = New System.Drawing.Point(10, 22)
        Me.BtnTag1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnTag1.Name = "BtnTag1"
        Me.BtnTag1.Shape = CButtonLib.CButton.eShape.Rectangle
        Me.BtnTag1.SideImage = Nothing
        Me.BtnTag1.SideImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnTag1.SideImageIsClickable = True
        Me.BtnTag1.SideImageSize = New System.Drawing.Size(40, 40)
        Me.BtnTag1.Size = New System.Drawing.Size(78, 32)
        Me.BtnTag1.TabIndex = 1020
        Me.BtnTag1.Text = "Brand"
        Me.BtnTag1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BtnTag1.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.BtnTag1.TextMargin = New System.Windows.Forms.Padding(2, 2, 4, 2)
        Me.BtnTag1.TextShadow = System.Drawing.Color.Transparent
        Me.BtnTag1.TextSmoothingMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
        Me.BtnTag1.UseMnemonic = True
        '
        'BtnTag3
        '
        Me.BtnTag3.BackColor = System.Drawing.SystemColors.Control
        Me.BtnTag3.BorderColor = System.Drawing.Color.Green
        DesignerRectTracker3.IsActive = False
        DesignerRectTracker3.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker3.TrackerRectangle"), System.Drawing.RectangleF)
        Me.BtnTag3.CenterPtTracker = DesignerRectTracker3
        CBlendItems2.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(205, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(246, Byte), Integer))}
        CBlendItems2.iPoint = New Single() {0.0!, 1.0!}
        Me.BtnTag3.ColorFillBlend = CBlendItems2
        Me.BtnTag3.ColorFillSolid = System.Drawing.Color.Transparent
        Me.BtnTag3.Corners.All = CType(9, Short)
        Me.BtnTag3.Corners.LowerLeft = CType(9, Short)
        Me.BtnTag3.Corners.LowerRight = CType(9, Short)
        Me.BtnTag3.Corners.UpperLeft = CType(9, Short)
        Me.BtnTag3.Corners.UpperRight = CType(9, Short)
        Me.BtnTag3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnTag3.FillType = CButtonLib.CButton.eFillType.Solid
        Me.BtnTag3.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal
        Me.BtnTag3.FocalPoints.CenterPtX = 1.0!
        Me.BtnTag3.FocalPoints.CenterPtY = 1.0!
        Me.BtnTag3.FocalPoints.FocusPtX = 0.0!
        Me.BtnTag3.FocalPoints.FocusPtY = 0.0!
        DesignerRectTracker4.IsActive = False
        DesignerRectTracker4.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker4.TrackerRectangle"), System.Drawing.RectangleF)
        Me.BtnTag3.FocusPtTracker = DesignerRectTracker4
        Me.BtnTag3.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTag3.ForeColor = System.Drawing.Color.Black
        Me.BtnTag3.Image = Nothing
        Me.BtnTag3.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BtnTag3.ImageIndex = 0
        Me.BtnTag3.ImageSize = New System.Drawing.Size(16, 16)
        Me.BtnTag3.Location = New System.Drawing.Point(183, 22)
        Me.BtnTag3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnTag3.Name = "BtnTag3"
        Me.BtnTag3.Shape = CButtonLib.CButton.eShape.Rectangle
        Me.BtnTag3.SideImage = Nothing
        Me.BtnTag3.SideImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnTag3.SideImageIsClickable = True
        Me.BtnTag3.SideImageSize = New System.Drawing.Size(40, 40)
        Me.BtnTag3.Size = New System.Drawing.Size(100, 32)
        Me.BtnTag3.TabIndex = 1021
        Me.BtnTag3.Text = "Sub Category"
        Me.BtnTag3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BtnTag3.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.BtnTag3.TextMargin = New System.Windows.Forms.Padding(2, 2, 4, 2)
        Me.BtnTag3.TextShadow = System.Drawing.Color.Transparent
        Me.BtnTag3.TextSmoothingMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
        Me.BtnTag3.UseMnemonic = True
        '
        'Btntag2
        '
        Me.Btntag2.BackColor = System.Drawing.SystemColors.Control
        Me.Btntag2.BorderColor = System.Drawing.Color.Green
        DesignerRectTracker5.IsActive = False
        DesignerRectTracker5.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker5.TrackerRectangle"), System.Drawing.RectangleF)
        Me.Btntag2.CenterPtTracker = DesignerRectTracker5
        CBlendItems3.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(205, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(246, Byte), Integer))}
        CBlendItems3.iPoint = New Single() {0.0!, 1.0!}
        Me.Btntag2.ColorFillBlend = CBlendItems3
        Me.Btntag2.ColorFillSolid = System.Drawing.Color.Transparent
        Me.Btntag2.Corners.All = CType(9, Short)
        Me.Btntag2.Corners.LowerLeft = CType(9, Short)
        Me.Btntag2.Corners.LowerRight = CType(9, Short)
        Me.Btntag2.Corners.UpperLeft = CType(9, Short)
        Me.Btntag2.Corners.UpperRight = CType(9, Short)
        Me.Btntag2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btntag2.FillType = CButtonLib.CButton.eFillType.Solid
        Me.Btntag2.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal
        Me.Btntag2.FocalPoints.CenterPtX = 1.0!
        Me.Btntag2.FocalPoints.CenterPtY = 1.0!
        Me.Btntag2.FocalPoints.FocusPtX = 0.0!
        Me.Btntag2.FocalPoints.FocusPtY = 0.0!
        DesignerRectTracker6.IsActive = False
        DesignerRectTracker6.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker6.TrackerRectangle"), System.Drawing.RectangleF)
        Me.Btntag2.FocusPtTracker = DesignerRectTracker6
        Me.Btntag2.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btntag2.ForeColor = System.Drawing.Color.Black
        Me.Btntag2.Image = Nothing
        Me.Btntag2.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Btntag2.ImageIndex = 0
        Me.Btntag2.ImageSize = New System.Drawing.Size(16, 16)
        Me.Btntag2.Location = New System.Drawing.Point(94, 22)
        Me.Btntag2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Btntag2.Name = "Btntag2"
        Me.Btntag2.Shape = CButtonLib.CButton.eShape.Rectangle
        Me.Btntag2.SideImage = Nothing
        Me.Btntag2.SideImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btntag2.SideImageIsClickable = True
        Me.Btntag2.SideImageSize = New System.Drawing.Size(40, 40)
        Me.Btntag2.Size = New System.Drawing.Size(83, 32)
        Me.Btntag2.TabIndex = 1022
        Me.Btntag2.Text = "Category"
        Me.Btntag2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Btntag2.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.Btntag2.TextMargin = New System.Windows.Forms.Padding(2, 2, 4, 2)
        Me.Btntag2.TextShadow = System.Drawing.Color.Transparent
        Me.Btntag2.TextSmoothingMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
        Me.Btntag2.UseMnemonic = True
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.lblAverageCost)
        Me.Panel1.Controls.Add(Me.lblMasterRate)
        Me.Panel1.Controls.Add(Me.lblFromDate)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lbltext)
        Me.Panel1.Controls.Add(Me.lblTotalCost)
        Me.Panel1.Location = New System.Drawing.Point(17, 76)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(169, 64)
        Me.Panel1.TabIndex = 2
        '
        'lblAverageCost
        '
        Me.lblAverageCost.AutoSize = True
        Me.lblAverageCost.ForeColor = System.Drawing.Color.Red
        Me.lblAverageCost.Location = New System.Drawing.Point(138, 8)
        Me.lblAverageCost.Name = "lblAverageCost"
        Me.lblAverageCost.Size = New System.Drawing.Size(16, 18)
        Me.lblAverageCost.TabIndex = 6
        Me.lblAverageCost.Text = "0"
        Me.lblAverageCost.Visible = False
        '
        'lblMasterRate
        '
        Me.lblMasterRate.AutoSize = True
        Me.lblMasterRate.ForeColor = System.Drawing.Color.Red
        Me.lblMasterRate.Location = New System.Drawing.Point(116, 8)
        Me.lblMasterRate.Name = "lblMasterRate"
        Me.lblMasterRate.Size = New System.Drawing.Size(16, 18)
        Me.lblMasterRate.TabIndex = 5
        Me.lblMasterRate.Text = "0"
        Me.lblMasterRate.Visible = False
        '
        'lblFromDate
        '
        Me.lblFromDate.AutoSize = True
        Me.lblFromDate.Font = New System.Drawing.Font("Comic Sans MS", 9.75!)
        Me.lblFromDate.ForeColor = System.Drawing.Color.Red
        Me.lblFromDate.Location = New System.Drawing.Point(94, 35)
        Me.lblFromDate.Name = "lblFromDate"
        Me.lblFromDate.Size = New System.Drawing.Size(22, 18)
        Me.lblFromDate.TabIndex = 4
        Me.lblFromDate.Text = "01"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 18)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Period :"
        '
        'lbltext
        '
        Me.lbltext.AutoSize = True
        Me.lbltext.Location = New System.Drawing.Point(10, 8)
        Me.lbltext.Name = "lbltext"
        Me.lbltext.Size = New System.Drawing.Size(78, 18)
        Me.lbltext.TabIndex = 1
        Me.lbltext.Text = "Total Cost :"
        '
        'lblTotalCost
        '
        Me.lblTotalCost.AutoSize = True
        Me.lblTotalCost.ForeColor = System.Drawing.Color.Red
        Me.lblTotalCost.Location = New System.Drawing.Point(94, 8)
        Me.lblTotalCost.Name = "lblTotalCost"
        Me.lblTotalCost.Size = New System.Drawing.Size(16, 18)
        Me.lblTotalCost.TabIndex = 0
        Me.lblTotalCost.Text = "0"
        '
        'grdQuickControl
        '
        Me.grdQuickControl.AllowUserToAddRows = False
        Me.grdQuickControl.BackgroundColor = System.Drawing.Color.White
        Me.grdQuickControl.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(70, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdQuickControl.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdQuickControl.ColumnHeadersHeight = 28
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdQuickControl.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdQuickControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdQuickControl.EnableHeadersVisualStyles = False
        Me.grdQuickControl.GridColor = System.Drawing.Color.Orange
        Me.grdQuickControl.GridTheme = ThemedDataGrid.MKDataGridView.GridThemes.Orange
        Me.grdQuickControl.Location = New System.Drawing.Point(0, 0)
        Me.grdQuickControl.Name = "grdQuickControl"
        Me.grdQuickControl.ReadOnly = True
        Me.grdQuickControl.RowHeadersVisible = False
        Me.grdQuickControl.RowTemplate.Height = 26
        Me.grdQuickControl.Size = New System.Drawing.Size(591, 319)
        Me.grdQuickControl.TabIndex = 0
        '
        'QCStep1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "QCStep1"
        Me.Size = New System.Drawing.Size(591, 477)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.grdQuickControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblTotalCost As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbltext As System.Windows.Forms.Label
    Friend WithEvents lblFromDate As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Btntag2 As CButtonLib.CButton
    Friend WithEvents BtnTag3 As CButtonLib.CButton
    Friend WithEvents BtnTag1 As CButtonLib.CButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rbtnAverageCost As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnMasterCost As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnToatlCost As System.Windows.Forms.RadioButton
    Friend WithEvents lblAverageCost As System.Windows.Forms.Label
    Friend WithEvents lblMasterRate As System.Windows.Forms.Label
    Friend WithEvents grdQuickControl As ThemedDataGrid.MKDataGridView

End Class
