<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsumption
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
        Me.imgDelete = New System.Windows.Forms.Button()
        Me.imgClose = New System.Windows.Forms.Button()
        Me.lblConsumptionID = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblQTy = New System.Windows.Forms.Label()
        Me.cmbsize = New System.Windows.Forms.ComboBox()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.cmbcategory = New System.Windows.Forms.ComboBox()
        Me.grdConsumption = New System.Windows.Forms.DataGridView()
        Me.CategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.alias1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.consumptionID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CategoryDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CategorySizeLinkID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tltip = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdConsumption, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblConsumptionID)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdConsumption)
        Me.SplitContainer1.Size = New System.Drawing.Size(453, 419)
        Me.SplitContainer1.SplitterDistance = 152
        Me.SplitContainer1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.imgSave)
        Me.Panel1.Controls.Add(Me.imgDelete)
        Me.Panel1.Controls.Add(Me.imgClose)
        Me.Panel1.Location = New System.Drawing.Point(305, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(148, 47)
        Me.Panel1.TabIndex = 14
        '
        'imgSave
        '
        Me.imgSave.Image = Global.CWPlus.My.Resources.Resources.save
        Me.imgSave.Location = New System.Drawing.Point(3, 3)
        Me.imgSave.Name = "imgSave"
        Me.imgSave.Size = New System.Drawing.Size(44, 41)
        Me.imgSave.TabIndex = 5
        Me.tltip.SetToolTip(Me.imgSave, "Save")
        Me.imgSave.UseVisualStyleBackColor = True
        '
        'imgDelete
        '
        Me.imgDelete.Image = Global.CWPlus.My.Resources.Resources.button_cancel
        Me.imgDelete.Location = New System.Drawing.Point(50, 3)
        Me.imgDelete.Name = "imgDelete"
        Me.imgDelete.Size = New System.Drawing.Size(41, 41)
        Me.imgDelete.TabIndex = 6
        Me.tltip.SetToolTip(Me.imgDelete, "Delete")
        Me.imgDelete.UseVisualStyleBackColor = True
        '
        'imgClose
        '
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(97, 3)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(42, 41)
        Me.imgClose.TabIndex = 7
        Me.tltip.SetToolTip(Me.imgClose, "Close")
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'lblConsumptionID
        '
        Me.lblConsumptionID.AutoSize = True
        Me.lblConsumptionID.Location = New System.Drawing.Point(346, 113)
        Me.lblConsumptionID.Name = "lblConsumptionID"
        Me.lblConsumptionID.Size = New System.Drawing.Size(13, 13)
        Me.lblConsumptionID.TabIndex = 5
        Me.lblConsumptionID.Text = "0"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblQTy)
        Me.GroupBox1.Controls.Add(Me.cmbsize)
        Me.GroupBox1.Controls.Add(Me.lblSize)
        Me.GroupBox1.Controls.Add(Me.txtQty)
        Me.GroupBox1.Controls.Add(Me.lblCategory)
        Me.GroupBox1.Controls.Add(Me.cmbcategory)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(209, 133)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Consumption"
        '
        'lblQTy
        '
        Me.lblQTy.AutoSize = True
        Me.lblQTy.Location = New System.Drawing.Point(31, 111)
        Me.lblQTy.Name = "lblQTy"
        Me.lblQTy.Size = New System.Drawing.Size(23, 13)
        Me.lblQTy.TabIndex = 6
        Me.lblQTy.Text = "Qty"
        '
        'cmbsize
        '
        Me.cmbsize.FormattingEnabled = True
        Me.cmbsize.Location = New System.Drawing.Point(73, 63)
        Me.cmbsize.Name = "cmbsize"
        Me.cmbsize.Size = New System.Drawing.Size(121, 21)
        Me.cmbsize.TabIndex = 2
        '
        'lblSize
        '
        Me.lblSize.AutoSize = True
        Me.lblSize.Location = New System.Drawing.Point(27, 71)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(27, 13)
        Me.lblSize.TabIndex = 4
        Me.lblSize.Text = "Size"
        '
        'txtQty
        '
        Me.txtQty.Location = New System.Drawing.Point(73, 104)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(121, 20)
        Me.txtQty.TabIndex = 3
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Location = New System.Drawing.Point(18, 34)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(49, 13)
        Me.lblCategory.TabIndex = 2
        Me.lblCategory.Text = "Category"
        '
        'cmbcategory
        '
        Me.cmbcategory.FormattingEnabled = True
        Me.cmbcategory.Location = New System.Drawing.Point(73, 26)
        Me.cmbcategory.Name = "cmbcategory"
        Me.cmbcategory.Size = New System.Drawing.Size(121, 21)
        Me.cmbcategory.TabIndex = 1
        '
        'grdConsumption
        '
        Me.grdConsumption.AllowDrop = True
        Me.grdConsumption.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdConsumption.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdConsumption.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdConsumption.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdConsumption.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdConsumption.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CategoryID, Me.alias1, Me.consumptionID, Me.CategoryDesc, Me.CategorySizeLinkID, Me.qty, Me.Size})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdConsumption.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdConsumption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdConsumption.GridColor = System.Drawing.Color.Black
        Me.grdConsumption.Location = New System.Drawing.Point(0, 0)
        Me.grdConsumption.Name = "grdConsumption"
        Me.grdConsumption.Size = New System.Drawing.Size(453, 263)
        Me.grdConsumption.TabIndex = 4
        '
        'CategoryID
        '
        Me.CategoryID.HeaderText = "CategoryID"
        Me.CategoryID.Name = "CategoryID"
        '
        'alias1
        '
        Me.alias1.HeaderText = "Alias"
        Me.alias1.Name = "alias1"
        '
        'consumptionID
        '
        Me.consumptionID.HeaderText = "consumptionID"
        Me.consumptionID.Name = "consumptionID"
        '
        'CategoryDesc
        '
        Me.CategoryDesc.HeaderText = "Category Name"
        Me.CategoryDesc.Name = "CategoryDesc"
        '
        'CategorySizeLinkID
        '
        Me.CategorySizeLinkID.HeaderText = "CategorySizeLinkID"
        Me.CategorySizeLinkID.Name = "CategorySizeLinkID"
        '
        'qty
        '
        Me.qty.HeaderText = "Qty"
        Me.qty.Name = "qty"
        '
        'Size
        '
        Me.Size.HeaderText = "Size"
        Me.Size.Name = "Size"
        '
        'tltip
        '
        Me.tltip.IsBalloon = True
        '
        'FrmConsumption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(453, 419)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmConsumption"
        Me.Text = "FrmConsumption"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdConsumption, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblQTy As System.Windows.Forms.Label
    Friend WithEvents cmbsize As System.Windows.Forms.ComboBox
    Friend WithEvents lblSize As System.Windows.Forms.Label
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents lblCategory As System.Windows.Forms.Label
    Friend WithEvents cmbcategory As System.Windows.Forms.ComboBox
    Friend WithEvents grdConsumption As System.Windows.Forms.DataGridView
    Friend WithEvents lblConsumptionID As System.Windows.Forms.Label
    Friend WithEvents CategoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents alias1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents consumptionID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CategoryDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CategorySizeLinkID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents imgSave As System.Windows.Forms.Button
    Friend WithEvents imgDelete As System.Windows.Forms.Button
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents tltip As System.Windows.Forms.ToolTip
End Class
