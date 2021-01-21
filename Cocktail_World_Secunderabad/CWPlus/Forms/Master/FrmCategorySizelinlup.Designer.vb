<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCategorySizelinlup
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.imgSave = New System.Windows.Forms.Button()
        Me.imgNew = New System.Windows.Forms.Button()
        Me.imgClose = New System.Windows.Forms.Button()
        Me.grdCategorySizeLinkUp = New System.Windows.Forms.DataGridView()
        Me.Sel = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.categorysizelinkid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SizeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vAlias = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ML = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SPeg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StockIN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.noofspeg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pegsize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vRemove = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.IsValueChanged = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tltip = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdCategorySizeLinkUp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdCategorySizeLinkUp)
        Me.SplitContainer1.Size = New System.Drawing.Size(746, 379)
        Me.SplitContainer1.SplitterDistance = 69
        Me.SplitContainer1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbCategory)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(267, 55)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Category "
        '
        'cmbCategory
        '
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(96, 19)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(161, 21)
        Me.cmbCategory.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(41, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Category"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.imgSave)
        Me.Panel1.Controls.Add(Me.imgNew)
        Me.Panel1.Controls.Add(Me.imgClose)
        Me.Panel1.Location = New System.Drawing.Point(595, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(148, 47)
        Me.Panel1.TabIndex = 12
        '
        'imgSave
        '
        Me.imgSave.Image = Global.CWPlus.My.Resources.Resources.save
        Me.imgSave.Location = New System.Drawing.Point(3, 6)
        Me.imgSave.Name = "imgSave"
        Me.imgSave.Size = New System.Drawing.Size(43, 38)
        Me.imgSave.TabIndex = 3
        Me.tltip.SetToolTip(Me.imgSave, "Save")
        Me.imgSave.UseVisualStyleBackColor = True
        '
        'imgNew
        '
        Me.imgNew.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.imgNew.Image = Global.CWPlus.My.Resources.Resources.window_new
        Me.imgNew.Location = New System.Drawing.Point(52, 6)
        Me.imgNew.Name = "imgNew"
        Me.imgNew.Size = New System.Drawing.Size(44, 38)
        Me.imgNew.TabIndex = 4
        Me.tltip.SetToolTip(Me.imgNew, "Add New")
        Me.imgNew.UseVisualStyleBackColor = True
        '
        'imgClose
        '
        Me.imgClose.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(102, 6)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(38, 38)
        Me.imgClose.TabIndex = 5
        Me.tltip.SetToolTip(Me.imgClose, "Close")
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'grdCategorySizeLinkUp
        '
        Me.grdCategorySizeLinkUp.AllowDrop = True
        Me.grdCategorySizeLinkUp.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdCategorySizeLinkUp.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdCategorySizeLinkUp.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdCategorySizeLinkUp.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdCategorySizeLinkUp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCategorySizeLinkUp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Sel, Me.categorysizelinkid, Me.SizeID, Me.Size, Me.vAlias, Me.ML, Me.SPeg, Me.StockIN, Me.noofspeg, Me.pegsize, Me.vRemove, Me.IsValueChanged})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdCategorySizeLinkUp.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdCategorySizeLinkUp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCategorySizeLinkUp.GridColor = System.Drawing.Color.Black
        Me.grdCategorySizeLinkUp.Location = New System.Drawing.Point(0, 0)
        Me.grdCategorySizeLinkUp.Name = "grdCategorySizeLinkUp"
        Me.grdCategorySizeLinkUp.Size = New System.Drawing.Size(746, 306)
        Me.grdCategorySizeLinkUp.TabIndex = 2
        '
        'Sel
        '
        Me.Sel.HeaderText = "Select"
        Me.Sel.Name = "Sel"
        Me.Sel.Width = 60
        '
        'categorysizelinkid
        '
        Me.categorysizelinkid.HeaderText = "categorysizelinkid"
        Me.categorysizelinkid.Name = "categorysizelinkid"
        Me.categorysizelinkid.Visible = False
        '
        'SizeID
        '
        Me.SizeID.HeaderText = "SizeID"
        Me.SizeID.Name = "SizeID"
        Me.SizeID.Visible = False
        '
        'Size
        '
        Me.Size.HeaderText = "Size"
        Me.Size.Name = "Size"
        '
        'vAlias
        '
        Me.vAlias.HeaderText = "Alias"
        Me.vAlias.Name = "vAlias"
        '
        'ML
        '
        Me.ML.HeaderText = "ML"
        Me.ML.Name = "ML"
        '
        'SPeg
        '
        Me.SPeg.HeaderText = "SPeg"
        Me.SPeg.Name = "SPeg"
        '
        'StockIN
        '
        Me.StockIN.HeaderText = "StockIN"
        Me.StockIN.Name = "StockIN"
        '
        'noofspeg
        '
        Me.noofspeg.HeaderText = "No of sPeg"
        Me.noofspeg.Name = "noofspeg"
        '
        'pegsize
        '
        Me.pegsize.HeaderText = "Peg Size(ML)"
        Me.pegsize.Name = "pegsize"
        '
        'vRemove
        '
        Me.vRemove.HeaderText = "Remove"
        Me.vRemove.Name = "vRemove"
        Me.vRemove.Text = "Remove"
        Me.vRemove.ToolTipText = "Click here to remove this item"
        Me.vRemove.UseColumnTextForButtonValue = True
        '
        'IsValueChanged
        '
        Me.IsValueChanged.HeaderText = "IsValueChanged"
        Me.IsValueChanged.Name = "IsValueChanged"
        Me.IsValueChanged.Visible = False
        '
        'tltip
        '
        Me.tltip.IsBalloon = True
        '
        'FrmCategorySizelinlup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(746, 379)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmCategorySizelinlup"
        Me.Text = "FrmCategorySizeLinkUp"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdCategorySizeLinkUp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents cmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grdCategorySizeLinkUp As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents imgNew As System.Windows.Forms.Button
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tltip As System.Windows.Forms.ToolTip
    Friend WithEvents imgSave As System.Windows.Forms.Button
    Friend WithEvents Sel As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents categorysizelinkid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SizeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vAlias As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ML As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SPeg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StockIN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents noofspeg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pegsize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vRemove As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents IsValueChanged As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
