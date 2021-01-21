<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBrandOpening
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLpegRate = New System.Windows.Forms.TextBox()
        Me.txtSPegRate = New System.Windows.Forms.TextBox()
        Me.chkEditBaseQuantity = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.imgSave = New System.Windows.Forms.Button()
        Me.imgClose = New System.Windows.Forms.Button()
        Me.cmbBrandName = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grdBrandOpening = New System.Windows.Forms.DataGridView()
        Me.tltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Sel = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.CategorySizeLinkUpID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OpeningQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OpSpQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BaseQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReorderLevel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OptimumLevel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vRemove = New System.Windows.Forms.DataGridViewButtonColumn()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdBrandOpening, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtLpegRate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtSPegRate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkEditBaseQuantity)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmbBrandName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdBrandOpening)
        Me.SplitContainer1.Size = New System.Drawing.Size(1080, 503)
        Me.SplitContainer1.SplitterDistance = 79
        Me.SplitContainer1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(157, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Lpeg Rate"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Speg Rate"
        '
        'txtLpegRate
        '
        Me.txtLpegRate.Location = New System.Drawing.Point(220, 40)
        Me.txtLpegRate.Name = "txtLpegRate"
        Me.txtLpegRate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtLpegRate.Size = New System.Drawing.Size(66, 20)
        Me.txtLpegRate.TabIndex = 16
        Me.txtLpegRate.Text = "0"
        '
        'txtSPegRate
        '
        Me.txtSPegRate.Location = New System.Drawing.Point(84, 40)
        Me.txtSPegRate.Name = "txtSPegRate"
        Me.txtSPegRate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtSPegRate.Size = New System.Drawing.Size(67, 20)
        Me.txtSPegRate.TabIndex = 15
        Me.txtSPegRate.Text = "0"
        '
        'chkEditBaseQuantity
        '
        Me.chkEditBaseQuantity.AutoSize = True
        Me.chkEditBaseQuantity.Location = New System.Drawing.Point(292, 42)
        Me.chkEditBaseQuantity.Name = "chkEditBaseQuantity"
        Me.chkEditBaseQuantity.Size = New System.Drawing.Size(113, 17)
        Me.chkEditBaseQuantity.TabIndex = 14
        Me.chkEditBaseQuantity.Text = "Edit Base Quantity"
        Me.chkEditBaseQuantity.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.imgSave)
        Me.Panel1.Controls.Add(Me.imgClose)
        Me.Panel1.Location = New System.Drawing.Point(969, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(99, 38)
        Me.Panel1.TabIndex = 13
        '
        'imgSave
        '
        Me.imgSave.Image = Global.CWPlus.My.Resources.Resources.save
        Me.imgSave.Location = New System.Drawing.Point(3, 0)
        Me.imgSave.Name = "imgSave"
        Me.imgSave.Size = New System.Drawing.Size(39, 38)
        Me.imgSave.TabIndex = 3
        Me.tltip.SetToolTip(Me.imgSave, "Save")
        Me.imgSave.UseVisualStyleBackColor = True
        '
        'imgClose
        '
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(48, 0)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(39, 38)
        Me.imgClose.TabIndex = 4
        Me.tltip.SetToolTip(Me.imgClose, "Close")
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'cmbBrandName
        '
        Me.cmbBrandName.FormattingEnabled = True
        Me.cmbBrandName.Location = New System.Drawing.Point(84, 13)
        Me.cmbBrandName.Name = "cmbBrandName"
        Me.cmbBrandName.Size = New System.Drawing.Size(373, 21)
        Me.cmbBrandName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Brand Name"
        '
        'grdBrandOpening
        '
        Me.grdBrandOpening.AllowDrop = True
        Me.grdBrandOpening.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdBrandOpening.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdBrandOpening.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdBrandOpening.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdBrandOpening.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdBrandOpening.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Sel, Me.CategorySizeLinkUpID, Me.Size, Me.OpeningQty, Me.OpSpQty, Me.sRate, Me.BaseQty, Me.ReorderLevel, Me.OptimumLevel, Me.OrdNo, Me.vRemove})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdBrandOpening.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdBrandOpening.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdBrandOpening.GridColor = System.Drawing.Color.Black
        Me.grdBrandOpening.Location = New System.Drawing.Point(0, 0)
        Me.grdBrandOpening.Name = "grdBrandOpening"
        Me.grdBrandOpening.Size = New System.Drawing.Size(1080, 420)
        Me.grdBrandOpening.TabIndex = 2
        '
        'tltip
        '
        Me.tltip.IsBalloon = True
        '
        'Sel
        '
        Me.Sel.HeaderText = "Select"
        Me.Sel.Name = "Sel"
        Me.Sel.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Sel.Width = 50
        '
        'CategorySizeLinkUpID
        '
        Me.CategorySizeLinkUpID.HeaderText = "CategorySizeLinkUpID"
        Me.CategorySizeLinkUpID.Name = "CategorySizeLinkUpID"
        Me.CategorySizeLinkUpID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CategorySizeLinkUpID.Visible = False
        '
        'Size
        '
        Me.Size.HeaderText = "Size"
        Me.Size.Name = "Size"
        '
        'OpeningQty
        '
        Me.OpeningQty.HeaderText = "Bottle Qty"
        Me.OpeningQty.Name = "OpeningQty"
        '
        'OpSpQty
        '
        Me.OpSpQty.HeaderText = "sPeg Qty"
        Me.OpSpQty.Name = "OpSpQty"
        '
        'sRate
        '
        Me.sRate.HeaderText = "Bottle Rate"
        Me.sRate.Name = "sRate"
        '
        'BaseQty
        '
        Me.BaseQty.HeaderText = "BaseQty"
        Me.BaseQty.Name = "BaseQty"
        '
        'ReorderLevel
        '
        Me.ReorderLevel.HeaderText = "Reorder Level"
        Me.ReorderLevel.Name = "ReorderLevel"
        '
        'OptimumLevel
        '
        Me.OptimumLevel.HeaderText = "Optimum Level"
        Me.OptimumLevel.Name = "OptimumLevel"
        '
        'OrdNo
        '
        Me.OrdNo.HeaderText = "OrdNo"
        Me.OrdNo.Name = "OrdNo"
        '
        'vRemove
        '
        Me.vRemove.HeaderText = "Remove"
        Me.vRemove.Name = "vRemove"
        Me.vRemove.Text = "Remove"
        Me.vRemove.ToolTipText = "Click here to remove this item"
        Me.vRemove.UseColumnTextForButtonValue = True
        '
        'frmBrandOpening
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1080, 503)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmBrandOpening"
        Me.Text = "frmOpeningStock"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdBrandOpening, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents grdBrandOpening As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbBrandName As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents imgSave As System.Windows.Forms.Button
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents tltip As System.Windows.Forms.ToolTip
    Friend WithEvents chkEditBaseQuantity As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtLpegRate As System.Windows.Forms.TextBox
    Friend WithEvents txtSPegRate As System.Windows.Forms.TextBox
    Friend WithEvents Sel As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents CategorySizeLinkUpID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OpeningQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OpSpQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BaseQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReorderLevel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OptimumLevel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vRemove As System.Windows.Forms.DataGridViewButtonColumn
End Class
