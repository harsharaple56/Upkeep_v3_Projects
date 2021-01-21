<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCocktail
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
        Me.cmbbrand = New System.Windows.Forms.ComboBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtpeg = New System.Windows.Forms.TextBox()
        Me.cmbsize = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtrate = New System.Windows.Forms.TextBox()
        Me.cmbcocktail = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grdcocktail = New System.Windows.Forms.DataGridView()
        Me.Btnrem = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.BrandId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.brandname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SizeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.peg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdcocktail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdcocktail)
        Me.SplitContainer1.Size = New System.Drawing.Size(633, 408)
        Me.SplitContainer1.SplitterDistance = 124
        Me.SplitContainer1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.imgSave)
        Me.Panel1.Controls.Add(Me.imgDelete)
        Me.Panel1.Controls.Add(Me.imgClose)
        Me.Panel1.Location = New System.Drawing.Point(489, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(144, 46)
        Me.Panel1.TabIndex = 13
        '
        'imgSave
        '
        Me.imgSave.Image = Global.CWPlus.My.Resources.Resources.save
        Me.imgSave.Location = New System.Drawing.Point(3, 4)
        Me.imgSave.Name = "imgSave"
        Me.imgSave.Size = New System.Drawing.Size(40, 42)
        Me.imgSave.TabIndex = 8
        Me.tltip.SetToolTip(Me.imgSave, "Save")
        Me.imgSave.UseVisualStyleBackColor = True
        '
        'imgDelete
        '
        Me.imgDelete.Image = Global.CWPlus.My.Resources.Resources.button_cancel
        Me.imgDelete.Location = New System.Drawing.Point(49, 4)
        Me.imgDelete.Name = "imgDelete"
        Me.imgDelete.Size = New System.Drawing.Size(40, 37)
        Me.imgDelete.TabIndex = 9
        Me.tltip.SetToolTip(Me.imgDelete, "Delete")
        Me.imgDelete.UseVisualStyleBackColor = True
        '
        'imgClose
        '
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(95, 4)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(41, 37)
        Me.imgClose.TabIndex = 10
        Me.tltip.SetToolTip(Me.imgClose, "Close")
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbbrand)
        Me.GroupBox1.Controls.Add(Me.btnAdd)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtpeg)
        Me.GroupBox1.Controls.Add(Me.cmbsize)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtrate)
        Me.GroupBox1.Controls.Add(Me.cmbcocktail)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(463, 107)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cocktail"
        '
        'cmbbrand
        '
        Me.cmbbrand.FormattingEnabled = True
        Me.cmbbrand.Location = New System.Drawing.Point(20, 77)
        Me.cmbbrand.Name = "cmbbrand"
        Me.cmbbrand.Size = New System.Drawing.Size(168, 21)
        Me.cmbbrand.TabIndex = 3
        '
        'btnAdd
        '
        Me.btnAdd.Image = Global.CWPlus.My.Resources.Resources.edit_add__1_
        Me.btnAdd.Location = New System.Drawing.Point(409, 68)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(34, 36)
        Me.btnAdd.TabIndex = 6
        Me.btnAdd.TabStop = False
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(330, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Peg/ML"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(203, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Size"
        '
        'txtpeg
        '
        Me.txtpeg.Location = New System.Drawing.Point(333, 77)
        Me.txtpeg.Name = "txtpeg"
        Me.txtpeg.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtpeg.Size = New System.Drawing.Size(59, 20)
        Me.txtpeg.TabIndex = 5
        '
        'cmbsize
        '
        Me.cmbsize.FormattingEnabled = True
        Me.cmbsize.Location = New System.Drawing.Point(206, 77)
        Me.cmbsize.Name = "cmbsize"
        Me.cmbsize.Size = New System.Drawing.Size(121, 21)
        Me.cmbsize.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Brand Name"
        '
        'txtrate
        '
        Me.txtrate.Location = New System.Drawing.Point(331, 24)
        Me.txtrate.Name = "txtrate"
        Me.txtrate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtrate.Size = New System.Drawing.Size(61, 20)
        Me.txtrate.TabIndex = 2
        Me.txtrate.Text = "0"
        '
        'cmbcocktail
        '
        Me.cmbcocktail.FormattingEnabled = True
        Me.cmbcocktail.Location = New System.Drawing.Point(89, 25)
        Me.cmbcocktail.Name = "cmbcocktail"
        Me.cmbcocktail.Size = New System.Drawing.Size(183, 21)
        Me.cmbcocktail.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(291, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Rate"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CocktailName"
        '
        'grdcocktail
        '
        Me.grdcocktail.AllowDrop = True
        Me.grdcocktail.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdcocktail.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdcocktail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdcocktail.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdcocktail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdcocktail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Btnrem, Me.BrandId, Me.brandname, Me.SizeID, Me.Size, Me.peg})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdcocktail.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdcocktail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdcocktail.GridColor = System.Drawing.Color.Black
        Me.grdcocktail.Location = New System.Drawing.Point(0, 0)
        Me.grdcocktail.Name = "grdcocktail"
        Me.grdcocktail.Size = New System.Drawing.Size(633, 280)
        Me.grdcocktail.TabIndex = 7
        '
        'Btnrem
        '
        Me.Btnrem.HeaderText = "Remove"
        Me.Btnrem.Name = "Btnrem"
        Me.Btnrem.Text = "Remove"
        Me.Btnrem.UseColumnTextForButtonValue = True
        '
        'BrandId
        '
        Me.BrandId.HeaderText = "BrandId"
        Me.BrandId.Name = "BrandId"
        Me.BrandId.Visible = False
        '
        'brandname
        '
        Me.brandname.HeaderText = "BrandName"
        Me.brandname.Name = "brandname"
        '
        'SizeID
        '
        Me.SizeID.HeaderText = "SizeID"
        Me.SizeID.Name = "SizeID"
        Me.SizeID.Visible = False
        '
        'Size
        '
        Me.Size.HeaderText = "Alias"
        Me.Size.Name = "Size"
        '
        'peg
        '
        Me.peg.HeaderText = "ML/Peg"
        Me.peg.Name = "peg"
        '
        'tltip
        '
        Me.tltip.IsBalloon = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.AddToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(633, 24)
        Me.MenuStrip1.TabIndex = 23
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.SaveToolStripMenuItem.Text = "Save"
        Me.SaveToolStripMenuItem.Visible = False
        '
        'AddToolStripMenuItem1
        '
        Me.AddToolStripMenuItem1.Name = "AddToolStripMenuItem1"
        Me.AddToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.AddToolStripMenuItem1.Size = New System.Drawing.Size(41, 20)
        Me.AddToolStripMenuItem1.Text = "Add"
        Me.AddToolStripMenuItem1.Visible = False
        '
        'FrmCocktail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(633, 408)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmCocktail"
        Me.Text = "FrmCocktail"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdcocktail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtpeg As System.Windows.Forms.TextBox
    Friend WithEvents cmbsize As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtrate As System.Windows.Forms.TextBox
    Friend WithEvents cmbcocktail As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grdcocktail As System.Windows.Forms.DataGridView
    Friend WithEvents Btnrem As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents BrandId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents brandname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SizeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents peg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmbbrand As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents imgSave As System.Windows.Forms.Button
    Friend WithEvents imgDelete As System.Windows.Forms.Button
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents tltip As System.Windows.Forms.ToolTip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
End Class
