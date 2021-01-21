<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBrand
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmbBrand = New System.Windows.Forms.ComboBox()
        Me.txtShortname = New System.Windows.Forms.TextBox()
        Me.txtStrength = New System.Windows.Forms.TextBox()
        Me.txtPurRatePeg = New System.Windows.Forms.TextBox()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.imgSave = New System.Windows.Forms.Button()
        Me.imgDelete = New System.Windows.Forms.Button()
        Me.imgClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblID = New System.Windows.Forms.Label()
        Me.cmbSubCategory = New System.Windows.Forms.ComboBox()
        Me.lblSubCategory = New System.Windows.Forms.Label()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.grdBrand = New System.Windows.Forms.DataGridView()
        Me.SizeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SizeAlias = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BoxQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PurRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ChkBDisable = New System.Windows.Forms.CheckBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdBrand, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbBrand
        '
        Me.cmbBrand.FormattingEnabled = True
        Me.cmbBrand.Location = New System.Drawing.Point(86, 19)
        Me.cmbBrand.Name = "cmbBrand"
        Me.cmbBrand.Size = New System.Drawing.Size(280, 21)
        Me.cmbBrand.TabIndex = 1
        '
        'txtShortname
        '
        Me.txtShortname.Location = New System.Drawing.Point(86, 46)
        Me.txtShortname.MaxLength = 13
        Me.txtShortname.Name = "txtShortname"
        Me.txtShortname.Size = New System.Drawing.Size(137, 20)
        Me.txtShortname.TabIndex = 2
        '
        'txtStrength
        '
        Me.txtStrength.Location = New System.Drawing.Point(86, 76)
        Me.txtStrength.Name = "txtStrength"
        Me.txtStrength.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtStrength.Size = New System.Drawing.Size(137, 20)
        Me.txtStrength.TabIndex = 3
        Me.txtStrength.Text = "0"
        '
        'txtPurRatePeg
        '
        Me.txtPurRatePeg.Location = New System.Drawing.Point(86, 102)
        Me.txtPurRatePeg.Name = "txtPurRatePeg"
        Me.txtPurRatePeg.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPurRatePeg.Size = New System.Drawing.Size(137, 20)
        Me.txtPurRatePeg.TabIndex = 4
        Me.txtPurRatePeg.Text = "0"
        '
        'cmbCategory
        '
        Me.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(86, 131)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(212, 21)
        Me.cmbCategory.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Brand Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Short Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 134)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Category"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Pur Rate Peg"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(33, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Strength"
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdBrand)
        Me.SplitContainer1.Size = New System.Drawing.Size(616, 485)
        Me.SplitContainer1.SplitterDistance = 207
        Me.SplitContainer1.TabIndex = 10
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.imgSave)
        Me.Panel1.Controls.Add(Me.imgDelete)
        Me.Panel1.Controls.Add(Me.imgClose)
        Me.Panel1.Location = New System.Drawing.Point(479, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(134, 46)
        Me.Panel1.TabIndex = 12
        '
        'imgSave
        '
        Me.imgSave.Image = Global.CWPlus.My.Resources.Resources.save
        Me.imgSave.Location = New System.Drawing.Point(3, 3)
        Me.imgSave.Name = "imgSave"
        Me.imgSave.Size = New System.Drawing.Size(39, 40)
        Me.imgSave.TabIndex = 9
        Me.tltip.SetToolTip(Me.imgSave, "Save")
        Me.imgSave.UseVisualStyleBackColor = True
        '
        'imgDelete
        '
        Me.imgDelete.Image = Global.CWPlus.My.Resources.Resources.button_cancel
        Me.imgDelete.Location = New System.Drawing.Point(48, 3)
        Me.imgDelete.Name = "imgDelete"
        Me.imgDelete.Size = New System.Drawing.Size(38, 40)
        Me.imgDelete.TabIndex = 10
        Me.tltip.SetToolTip(Me.imgDelete, "Delete")
        Me.imgDelete.UseVisualStyleBackColor = True
        '
        'imgClose
        '
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(92, 3)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(39, 40)
        Me.imgClose.TabIndex = 11
        Me.tltip.SetToolTip(Me.imgClose, "Close")
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChkBDisable)
        Me.GroupBox1.Controls.Add(Me.lblID)
        Me.GroupBox1.Controls.Add(Me.cmbSubCategory)
        Me.GroupBox1.Controls.Add(Me.lblSubCategory)
        Me.GroupBox1.Controls.Add(Me.btnEdit)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtShortname)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cmbCategory)
        Me.GroupBox1.Controls.Add(Me.cmbBrand)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtPurRatePeg)
        Me.GroupBox1.Controls.Add(Me.txtStrength)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(416, 195)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Brand Details"
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(367, 76)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(13, 13)
        Me.lblID.TabIndex = 12
        Me.lblID.Text = "0"
        Me.lblID.Visible = False
        '
        'cmbSubCategory
        '
        Me.cmbSubCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubCategory.FormattingEnabled = True
        Me.cmbSubCategory.Location = New System.Drawing.Point(86, 164)
        Me.cmbSubCategory.Name = "cmbSubCategory"
        Me.cmbSubCategory.Size = New System.Drawing.Size(212, 21)
        Me.cmbSubCategory.TabIndex = 7
        '
        'lblSubCategory
        '
        Me.lblSubCategory.AutoSize = True
        Me.lblSubCategory.Location = New System.Drawing.Point(15, 167)
        Me.lblSubCategory.Name = "lblSubCategory"
        Me.lblSubCategory.Size = New System.Drawing.Size(71, 13)
        Me.lblSubCategory.TabIndex = 11
        Me.lblSubCategory.Text = "Sub Category"
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(315, 129)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(92, 23)
        Me.btnEdit.TabIndex = 6
        Me.btnEdit.Text = "Edit Category"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(228, 79)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 16)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "(%)"
        '
        'grdBrand
        '
        Me.grdBrand.AllowDrop = True
        Me.grdBrand.AllowUserToAddRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdBrand.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.grdBrand.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdBrand.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdBrand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdBrand.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SizeID, Me.Size, Me.SizeAlias, Me.BoxQty, Me.PurRate})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdBrand.DefaultCellStyle = DataGridViewCellStyle4
        Me.grdBrand.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdBrand.GridColor = System.Drawing.Color.Black
        Me.grdBrand.Location = New System.Drawing.Point(0, 0)
        Me.grdBrand.Name = "grdBrand"
        Me.grdBrand.Size = New System.Drawing.Size(616, 274)
        Me.grdBrand.TabIndex = 8
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
        Me.Size.ReadOnly = True
        '
        'SizeAlias
        '
        Me.SizeAlias.HeaderText = "Alias"
        Me.SizeAlias.Name = "SizeAlias"
        '
        'BoxQty
        '
        Me.BoxQty.HeaderText = "BoxQty"
        Me.BoxQty.Name = "BoxQty"
        '
        'PurRate
        '
        Me.PurRate.HeaderText = "PurRate"
        Me.PurRate.Name = "PurRate"
        '
        'tltip
        '
        Me.tltip.IsBalloon = True
        '
        'ChkBDisable
        '
        Me.ChkBDisable.AutoSize = True
        Me.ChkBDisable.Location = New System.Drawing.Point(315, 168)
        Me.ChkBDisable.Name = "ChkBDisable"
        Me.ChkBDisable.Size = New System.Drawing.Size(92, 17)
        Me.ChkBDisable.TabIndex = 13
        Me.ChkBDisable.Text = "Disable Brand"
        Me.ChkBDisable.UseVisualStyleBackColor = True
        '
        'frmBrand
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(616, 485)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmBrand"
        Me.Text = "frmBrand"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdBrand, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbBrand As System.Windows.Forms.ComboBox
    Friend WithEvents txtShortname As System.Windows.Forms.TextBox
    Friend WithEvents txtStrength As System.Windows.Forms.TextBox
    Friend WithEvents txtPurRatePeg As System.Windows.Forms.TextBox
    Friend WithEvents cmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents grdBrand As System.Windows.Forms.DataGridView
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents cmbSubCategory As System.Windows.Forms.ComboBox
    Friend WithEvents lblSubCategory As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents imgSave As System.Windows.Forms.Button
    Friend WithEvents imgDelete As System.Windows.Forms.Button
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents tltip As System.Windows.Forms.ToolTip
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents SizeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SizeAlias As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChkBDisable As System.Windows.Forms.CheckBox
End Class
