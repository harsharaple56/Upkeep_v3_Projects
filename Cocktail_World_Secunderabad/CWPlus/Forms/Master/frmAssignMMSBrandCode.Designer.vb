<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAssignMMSBrandCode
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
        Me.lblassignbrandcodeid = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbBrandName = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtbottle = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtspeg = New System.Windows.Forms.TextBox()
        Me.cmbSize = New System.Windows.Forms.ComboBox()
        Me.txtlpeg = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.imgClose = New System.Windows.Forms.Button()
        Me.imgSave = New System.Windows.Forms.Button()
        Me.grdAssignBrandCode = New System.Windows.Forms.DataGridView()
        Me.vRemove = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnEdit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.tltipUser = New System.Windows.Forms.ToolTip(Me.components)
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdAssignBrandCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblassignbrandcodeid
        '
        Me.lblassignbrandcodeid.AutoSize = True
        Me.lblassignbrandcodeid.Location = New System.Drawing.Point(500, 16)
        Me.lblassignbrandcodeid.Name = "lblassignbrandcodeid"
        Me.lblassignbrandcodeid.Size = New System.Drawing.Size(13, 13)
        Me.lblassignbrandcodeid.TabIndex = 13
        Me.lblassignbrandcodeid.Text = "0"
        Me.lblassignbrandcodeid.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblassignbrandcodeid)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbBrandName)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtbottle)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtspeg)
        Me.GroupBox1.Controls.Add(Me.cmbSize)
        Me.GroupBox1.Controls.Add(Me.txtlpeg)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 19)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(519, 145)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Assign MMS Code"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Brand"
        '
        'cmbBrandName
        '
        Me.cmbBrandName.FormattingEnabled = True
        Me.cmbBrandName.Location = New System.Drawing.Point(71, 26)
        Me.cmbBrandName.Name = "cmbBrandName"
        Me.cmbBrandName.Size = New System.Drawing.Size(281, 21)
        Me.cmbBrandName.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Bottle"
        '
        'txtbottle
        '
        Me.txtbottle.Location = New System.Drawing.Point(71, 57)
        Me.txtbottle.Name = "txtbottle"
        Me.txtbottle.Size = New System.Drawing.Size(426, 20)
        Me.txtbottle.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(372, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Size"
        '
        'txtspeg
        '
        Me.txtspeg.Location = New System.Drawing.Point(71, 86)
        Me.txtspeg.Name = "txtspeg"
        Me.txtspeg.Size = New System.Drawing.Size(426, 20)
        Me.txtspeg.TabIndex = 4
        '
        'cmbSize
        '
        Me.cmbSize.FormattingEnabled = True
        Me.cmbSize.Location = New System.Drawing.Point(405, 26)
        Me.cmbSize.Name = "cmbSize"
        Me.cmbSize.Size = New System.Drawing.Size(92, 21)
        Me.cmbSize.TabIndex = 2
        '
        'txtlpeg
        '
        Me.txtlpeg.Location = New System.Drawing.Point(71, 112)
        Me.txtlpeg.Name = "txtlpeg"
        Me.txtlpeg.Size = New System.Drawing.Size(426, 20)
        Me.txtlpeg.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "lPeg"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "sPeg"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.imgClose)
        Me.Panel1.Controls.Add(Me.imgSave)
        Me.Panel1.Location = New System.Drawing.Point(559, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(97, 47)
        Me.Panel1.TabIndex = 11
        Me.tltipUser.SetToolTip(Me.Panel1, "Save")
        '
        'imgClose
        '
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(54, 3)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(40, 44)
        Me.imgClose.TabIndex = 8
        Me.tltipUser.SetToolTip(Me.imgClose, "Close")
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'imgSave
        '
        Me.imgSave.Image = Global.CWPlus.My.Resources.Resources.save
        Me.imgSave.Location = New System.Drawing.Point(5, 3)
        Me.imgSave.Name = "imgSave"
        Me.imgSave.Size = New System.Drawing.Size(43, 44)
        Me.imgSave.TabIndex = 7
        Me.tltipUser.SetToolTip(Me.imgSave, "Save")
        Me.imgSave.UseVisualStyleBackColor = True
        '
        'grdAssignBrandCode
        '
        Me.grdAssignBrandCode.AllowDrop = True
        Me.grdAssignBrandCode.AllowUserToAddRows = False
        Me.grdAssignBrandCode.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdAssignBrandCode.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdAssignBrandCode.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdAssignBrandCode.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdAssignBrandCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdAssignBrandCode.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.vRemove, Me.btnEdit})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdAssignBrandCode.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdAssignBrandCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdAssignBrandCode.GridColor = System.Drawing.Color.Black
        Me.grdAssignBrandCode.Location = New System.Drawing.Point(0, 0)
        Me.grdAssignBrandCode.Name = "grdAssignBrandCode"
        Me.grdAssignBrandCode.ReadOnly = True
        Me.grdAssignBrandCode.Size = New System.Drawing.Size(668, 283)
        Me.grdAssignBrandCode.TabIndex = 6
        '
        'vRemove
        '
        Me.vRemove.HeaderText = "Remove"
        Me.vRemove.Name = "vRemove"
        Me.vRemove.ReadOnly = True
        Me.vRemove.Text = "Remove"
        Me.vRemove.UseColumnTextForButtonValue = True
        '
        'btnEdit
        '
        Me.btnEdit.HeaderText = "Edit"
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.ReadOnly = True
        Me.btnEdit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.ToolTipText = "Edit"
        Me.btnEdit.UseColumnTextForButtonValue = True
        Me.btnEdit.Width = 80
        '
        'tltipUser
        '
        Me.tltipUser.IsBalloon = True
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.HeaderText = "Edit"
        Me.DataGridViewImageColumn1.Image = Global.CWPlus.My.Resources.Resources.pencil__3_
        Me.DataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn1.ToolTipText = "Edit"
        Me.DataGridViewImageColumn1.Width = 80
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdAssignBrandCode)
        Me.SplitContainer1.Size = New System.Drawing.Size(668, 455)
        Me.SplitContainer1.SplitterDistance = 168
        Me.SplitContainer1.TabIndex = 12
        '
        'frmAssignMMSBrandCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(668, 455)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmAssignMMSBrandCode"
        Me.Text = "frmAssignMMSBrandCode"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdAssignBrandCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblassignbrandcodeid As System.Windows.Forms.Label
    Friend WithEvents imgSave As System.Windows.Forms.Button
    Friend WithEvents tltipUser As System.Windows.Forms.ToolTip
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtlpeg As System.Windows.Forms.TextBox
    Friend WithEvents txtspeg As System.Windows.Forms.TextBox
    Friend WithEvents txtbottle As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbBrandName As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbSize As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grdAssignBrandCode As System.Windows.Forms.DataGridView
    Friend WithEvents vRemove As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents btnEdit As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
End Class
