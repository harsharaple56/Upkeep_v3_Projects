<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFreezDate
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.imgSave = New System.Windows.Forms.Button()
        Me.imgDelete = New System.Windows.Forms.Button()
        Me.imgClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblCurrentDate = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtfreezDate = New System.Windows.Forms.DateTimePicker()
        Me.grdFreezDate = New System.Windows.Forms.DataGridView()
        Me.FreezID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LicenseID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FreezDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsActive = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblID = New System.Windows.Forms.Label()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdFreezDate, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblID)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdFreezDate)
        Me.SplitContainer1.Size = New System.Drawing.Size(507, 266)
        Me.SplitContainer1.SplitterDistance = 65
        Me.SplitContainer1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.imgSave)
        Me.Panel1.Controls.Add(Me.imgDelete)
        Me.Panel1.Controls.Add(Me.imgClose)
        Me.Panel1.Location = New System.Drawing.Point(348, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(159, 49)
        Me.Panel1.TabIndex = 14
        '
        'imgSave
        '
        Me.imgSave.Image = Global.CWPlus.My.Resources.Resources.save
        Me.imgSave.Location = New System.Drawing.Point(3, 3)
        Me.imgSave.Name = "imgSave"
        Me.imgSave.Size = New System.Drawing.Size(45, 43)
        Me.imgSave.TabIndex = 3
        Me.tltip.SetToolTip(Me.imgSave, "Save")
        Me.imgSave.UseVisualStyleBackColor = True
        '
        'imgDelete
        '
        Me.imgDelete.Image = Global.CWPlus.My.Resources.Resources.button_cancel
        Me.imgDelete.Location = New System.Drawing.Point(54, 3)
        Me.imgDelete.Name = "imgDelete"
        Me.imgDelete.Size = New System.Drawing.Size(44, 43)
        Me.imgDelete.TabIndex = 4
        Me.tltip.SetToolTip(Me.imgDelete, "Delete")
        Me.imgDelete.UseVisualStyleBackColor = True
        '
        'imgClose
        '
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(104, 3)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(44, 43)
        Me.imgClose.TabIndex = 5
        Me.tltip.SetToolTip(Me.imgClose, "Close")
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblCurrentDate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtfreezDate)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(316, 57)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Freez "
        '
        'lblCurrentDate
        '
        Me.lblCurrentDate.AutoSize = True
        Me.lblCurrentDate.Location = New System.Drawing.Point(310, 60)
        Me.lblCurrentDate.Name = "lblCurrentDate"
        Me.lblCurrentDate.Size = New System.Drawing.Size(0, 13)
        Me.lblCurrentDate.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Fz.Date"
        '
        'dtfreezDate
        '
        Me.dtfreezDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtfreezDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfreezDate.Location = New System.Drawing.Point(114, 19)
        Me.dtfreezDate.Name = "dtfreezDate"
        Me.dtfreezDate.Size = New System.Drawing.Size(200, 20)
        Me.dtfreezDate.TabIndex = 1
        '
        'grdFreezDate
        '
        Me.grdFreezDate.AllowDrop = True
        Me.grdFreezDate.AllowUserToAddRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdFreezDate.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.grdFreezDate.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdFreezDate.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdFreezDate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdFreezDate.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FreezID, Me.LicenseID, Me.FreezDate, Me.IsActive})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdFreezDate.DefaultCellStyle = DataGridViewCellStyle4
        Me.grdFreezDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFreezDate.GridColor = System.Drawing.Color.Black
        Me.grdFreezDate.Location = New System.Drawing.Point(0, 0)
        Me.grdFreezDate.Name = "grdFreezDate"
        Me.grdFreezDate.Size = New System.Drawing.Size(507, 197)
        Me.grdFreezDate.TabIndex = 2
        '
        'FreezID
        '
        Me.FreezID.HeaderText = "FreezID"
        Me.FreezID.Name = "FreezID"
        '
        'LicenseID
        '
        Me.LicenseID.HeaderText = "LicenseID"
        Me.LicenseID.Name = "LicenseID"
        '
        'FreezDate
        '
        Me.FreezDate.HeaderText = "FreezDate"
        Me.FreezDate.Name = "FreezDate"
        '
        'IsActive
        '
        Me.IsActive.HeaderText = "IsActive"
        Me.IsActive.Name = "IsActive"
        '
        'tltip
        '
        Me.tltip.IsBalloon = True
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(335, 46)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(13, 13)
        Me.lblID.TabIndex = 15
        Me.lblID.Text = "0"
        Me.lblID.Visible = False
        '
        'FrmFreezDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(507, 266)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmFreezDate"
        Me.Text = "FrmFreezDate"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdFreezDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtfreezDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents grdFreezDate As System.Windows.Forms.DataGridView
    Friend WithEvents FreezID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LicenseID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FreezDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsActive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblCurrentDate As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents imgSave As System.Windows.Forms.Button
    Friend WithEvents imgDelete As System.Windows.Forms.Button
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents tltip As System.Windows.Forms.ToolTip
    Friend WithEvents lblID As System.Windows.Forms.Label
End Class
