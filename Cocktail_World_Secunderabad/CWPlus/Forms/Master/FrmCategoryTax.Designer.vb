<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCategoryTax
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblid = New System.Windows.Forms.Label()
        Me.Cmbcategory = New System.Windows.Forms.ComboBox()
        Me.txttaxperce = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txttaxtype = New System.Windows.Forms.TextBox()
        Me.grdcategorytax = New System.Windows.Forms.DataGridView()
        Me.tltip = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdcategorytax, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdcategorytax)
        Me.SplitContainer1.Size = New System.Drawing.Size(464, 421)
        Me.SplitContainer1.SplitterDistance = 126
        Me.SplitContainer1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.imgSave)
        Me.Panel1.Controls.Add(Me.imgDelete)
        Me.Panel1.Controls.Add(Me.imgClose)
        Me.Panel1.Location = New System.Drawing.Point(316, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(142, 44)
        Me.Panel1.TabIndex = 13
        '
        'imgSave
        '
        Me.imgSave.Image = Global.CWPlus.My.Resources.Resources.save
        Me.imgSave.Location = New System.Drawing.Point(3, 3)
        Me.imgSave.Name = "imgSave"
        Me.imgSave.Size = New System.Drawing.Size(42, 41)
        Me.imgSave.TabIndex = 5
        Me.tltip.SetToolTip(Me.imgSave, "Save")
        Me.imgSave.UseVisualStyleBackColor = True
        '
        'imgDelete
        '
        Me.imgDelete.Image = Global.CWPlus.My.Resources.Resources.button_cancel
        Me.imgDelete.Location = New System.Drawing.Point(51, 4)
        Me.imgDelete.Name = "imgDelete"
        Me.imgDelete.Size = New System.Drawing.Size(40, 37)
        Me.imgDelete.TabIndex = 6
        Me.tltip.SetToolTip(Me.imgDelete, "Delete")
        Me.imgDelete.UseVisualStyleBackColor = True
        '
        'imgClose
        '
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(97, 4)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(42, 40)
        Me.imgClose.TabIndex = 7
        Me.tltip.SetToolTip(Me.imgClose, "Close")
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblid)
        Me.GroupBox1.Controls.Add(Me.Cmbcategory)
        Me.GroupBox1.Controls.Add(Me.txttaxperce)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txttaxtype)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(307, 109)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Category Tax"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Category"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(234, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(19, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "%"
        '
        'lblid
        '
        Me.lblid.AutoSize = True
        Me.lblid.Location = New System.Drawing.Point(257, 85)
        Me.lblid.Name = "lblid"
        Me.lblid.Size = New System.Drawing.Size(44, 13)
        Me.lblid.TabIndex = 3
        Me.lblid.Text = "labelid"
        Me.lblid.Visible = False
        '
        'Cmbcategory
        '
        Me.Cmbcategory.FormattingEnabled = True
        Me.Cmbcategory.Location = New System.Drawing.Point(113, 23)
        Me.Cmbcategory.Name = "Cmbcategory"
        Me.Cmbcategory.Size = New System.Drawing.Size(178, 21)
        Me.Cmbcategory.TabIndex = 1
        '
        'txttaxperce
        '
        Me.txttaxperce.Location = New System.Drawing.Point(113, 82)
        Me.txttaxperce.Name = "txttaxperce"
        Me.txttaxperce.Size = New System.Drawing.Size(115, 21)
        Me.txttaxperce.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Tax Type"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Tax Percentage"
        '
        'txttaxtype
        '
        Me.txttaxtype.Location = New System.Drawing.Point(113, 52)
        Me.txttaxtype.Name = "txttaxtype"
        Me.txttaxtype.Size = New System.Drawing.Size(115, 21)
        Me.txttaxtype.TabIndex = 2
        '
        'grdcategorytax
        '
        Me.grdcategorytax.AllowDrop = True
        Me.grdcategorytax.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdcategorytax.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdcategorytax.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdcategorytax.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdcategorytax.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdcategorytax.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdcategorytax.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdcategorytax.GridColor = System.Drawing.Color.Black
        Me.grdcategorytax.Location = New System.Drawing.Point(0, 0)
        Me.grdcategorytax.Name = "grdcategorytax"
        Me.grdcategorytax.ReadOnly = True
        Me.grdcategorytax.Size = New System.Drawing.Size(464, 291)
        Me.grdcategorytax.TabIndex = 4
        '
        'tltip
        '
        Me.tltip.IsBalloon = True
        '
        'FrmCategoryTax
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(464, 421)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FrmCategoryTax"
        Me.Text = "FrmCategoryTax"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdcategorytax, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Cmbcategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblid As System.Windows.Forms.Label
    Friend WithEvents txttaxperce As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txttaxtype As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grdcategorytax As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents imgSave As System.Windows.Forms.Button
    Friend WithEvents imgDelete As System.Windows.Forms.Button
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents tltip As System.Windows.Forms.ToolTip
End Class
