<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPermitHolderMaster
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
        Me.chkLifeTime = New System.Windows.Forms.CheckBox()
        Me.lblPermitName = New System.Windows.Forms.Label()
        Me.lblPermitType = New System.Windows.Forms.Label()
        Me.lblPermitNumber = New System.Windows.Forms.Label()
        Me.cmbPermitType = New System.Windows.Forms.ComboBox()
        Me.lblPermitExpireDate = New System.Windows.Forms.Label()
        Me.lblErrorMsg = New System.Windows.Forms.Label()
        Me.lblPermitHolderID = New System.Windows.Forms.Label()
        Me.txtPermitNumber = New System.Windows.Forms.TextBox()
        Me.txtPermitHolderName = New System.Windows.Forms.TextBox()
        Me.txtExpiredate = New System.Windows.Forms.DateTimePicker()
        Me.grdPermitHolder = New System.Windows.Forms.DataGridView()
        Me.tltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblCount = New System.Windows.Forms.Label()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdPermitHolder, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdPermitHolder)
        Me.SplitContainer1.Size = New System.Drawing.Size(805, 291)
        Me.SplitContainer1.SplitterDistance = 175
        Me.SplitContainer1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.imgSave)
        Me.Panel1.Controls.Add(Me.imgDelete)
        Me.Panel1.Controls.Add(Me.imgClose)
        Me.Panel1.Location = New System.Drawing.Point(654, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(151, 44)
        Me.Panel1.TabIndex = 12
        '
        'imgSave
        '
        Me.imgSave.Image = Global.CWPlus.My.Resources.Resources.save
        Me.imgSave.Location = New System.Drawing.Point(3, 4)
        Me.imgSave.Name = "imgSave"
        Me.imgSave.Size = New System.Drawing.Size(44, 37)
        Me.imgSave.TabIndex = 7
        Me.tltip.SetToolTip(Me.imgSave, "Save")
        Me.imgSave.UseVisualStyleBackColor = True
        '
        'imgDelete
        '
        Me.imgDelete.Image = Global.CWPlus.My.Resources.Resources.button_cancel
        Me.imgDelete.Location = New System.Drawing.Point(53, 4)
        Me.imgDelete.Name = "imgDelete"
        Me.imgDelete.Size = New System.Drawing.Size(40, 37)
        Me.imgDelete.TabIndex = 8
        Me.tltip.SetToolTip(Me.imgDelete, "Delete")
        Me.imgDelete.UseVisualStyleBackColor = True
        '
        'imgClose
        '
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(99, 4)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(40, 37)
        Me.imgClose.TabIndex = 9
        Me.tltip.SetToolTip(Me.imgClose, "Close")
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblCount)
        Me.GroupBox1.Controls.Add(Me.chkLifeTime)
        Me.GroupBox1.Controls.Add(Me.lblPermitName)
        Me.GroupBox1.Controls.Add(Me.lblPermitType)
        Me.GroupBox1.Controls.Add(Me.lblPermitNumber)
        Me.GroupBox1.Controls.Add(Me.cmbPermitType)
        Me.GroupBox1.Controls.Add(Me.lblPermitExpireDate)
        Me.GroupBox1.Controls.Add(Me.lblErrorMsg)
        Me.GroupBox1.Controls.Add(Me.lblPermitHolderID)
        Me.GroupBox1.Controls.Add(Me.txtPermitNumber)
        Me.GroupBox1.Controls.Add(Me.txtPermitHolderName)
        Me.GroupBox1.Controls.Add(Me.txtExpiredate)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(619, 149)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Permit Holder"
        '
        'chkLifeTime
        '
        Me.chkLifeTime.AutoSize = True
        Me.chkLifeTime.Location = New System.Drawing.Point(137, 130)
        Me.chkLifeTime.Name = "chkLifeTime"
        Me.chkLifeTime.Size = New System.Drawing.Size(74, 17)
        Me.chkLifeTime.TabIndex = 5
        Me.chkLifeTime.Text = "LifeTime"
        Me.chkLifeTime.UseVisualStyleBackColor = True
        '
        'lblPermitName
        '
        Me.lblPermitName.AutoSize = True
        Me.lblPermitName.Location = New System.Drawing.Point(9, 78)
        Me.lblPermitName.Name = "lblPermitName"
        Me.lblPermitName.Size = New System.Drawing.Size(81, 13)
        Me.lblPermitName.TabIndex = 1
        Me.lblPermitName.Text = "Permit Name"
        '
        'lblPermitType
        '
        Me.lblPermitType.AutoSize = True
        Me.lblPermitType.Location = New System.Drawing.Point(9, 22)
        Me.lblPermitType.Name = "lblPermitType"
        Me.lblPermitType.Size = New System.Drawing.Size(76, 13)
        Me.lblPermitType.TabIndex = 12
        Me.lblPermitType.Text = "Permit Type"
        '
        'lblPermitNumber
        '
        Me.lblPermitNumber.AutoSize = True
        Me.lblPermitNumber.Location = New System.Drawing.Point(9, 49)
        Me.lblPermitNumber.Name = "lblPermitNumber"
        Me.lblPermitNumber.Size = New System.Drawing.Size(93, 13)
        Me.lblPermitNumber.TabIndex = 0
        Me.lblPermitNumber.Text = "Permit Number"
        '
        'cmbPermitType
        '
        Me.cmbPermitType.FormattingEnabled = True
        Me.cmbPermitType.Location = New System.Drawing.Point(110, 19)
        Me.cmbPermitType.Name = "cmbPermitType"
        Me.cmbPermitType.Size = New System.Drawing.Size(233, 21)
        Me.cmbPermitType.TabIndex = 1
        '
        'lblPermitExpireDate
        '
        Me.lblPermitExpireDate.AutoSize = True
        Me.lblPermitExpireDate.Location = New System.Drawing.Point(6, 103)
        Me.lblPermitExpireDate.Name = "lblPermitExpireDate"
        Me.lblPermitExpireDate.Size = New System.Drawing.Size(74, 13)
        Me.lblPermitExpireDate.TabIndex = 2
        Me.lblPermitExpireDate.Text = "Expire Date"
        '
        'lblErrorMsg
        '
        Me.lblErrorMsg.AutoSize = True
        Me.lblErrorMsg.Location = New System.Drawing.Point(-14, 120)
        Me.lblErrorMsg.Name = "lblErrorMsg"
        Me.lblErrorMsg.Size = New System.Drawing.Size(0, 13)
        Me.lblErrorMsg.TabIndex = 10
        '
        'lblPermitHolderID
        '
        Me.lblPermitHolderID.AutoSize = True
        Me.lblPermitHolderID.Location = New System.Drawing.Point(-24, 18)
        Me.lblPermitHolderID.Name = "lblPermitHolderID"
        Me.lblPermitHolderID.Size = New System.Drawing.Size(0, 13)
        Me.lblPermitHolderID.TabIndex = 3
        '
        'txtPermitNumber
        '
        Me.txtPermitNumber.Location = New System.Drawing.Point(110, 46)
        Me.txtPermitNumber.Name = "txtPermitNumber"
        Me.txtPermitNumber.Size = New System.Drawing.Size(233, 21)
        Me.txtPermitNumber.TabIndex = 2
        '
        'txtPermitHolderName
        '
        Me.txtPermitHolderName.Location = New System.Drawing.Point(110, 75)
        Me.txtPermitHolderName.Name = "txtPermitHolderName"
        Me.txtPermitHolderName.Size = New System.Drawing.Size(233, 21)
        Me.txtPermitHolderName.TabIndex = 3
        '
        'txtExpiredate
        '
        Me.txtExpiredate.CustomFormat = "dd-MMM-yyy"
        Me.txtExpiredate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtExpiredate.Location = New System.Drawing.Point(110, 103)
        Me.txtExpiredate.Name = "txtExpiredate"
        Me.txtExpiredate.Size = New System.Drawing.Size(233, 21)
        Me.txtExpiredate.TabIndex = 4
        '
        'grdPermitHolder
        '
        Me.grdPermitHolder.AllowDrop = True
        Me.grdPermitHolder.AllowUserToAddRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdPermitHolder.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.grdPermitHolder.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdPermitHolder.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdPermitHolder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdPermitHolder.DefaultCellStyle = DataGridViewCellStyle4
        Me.grdPermitHolder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPermitHolder.GridColor = System.Drawing.Color.Black
        Me.grdPermitHolder.Location = New System.Drawing.Point(0, 0)
        Me.grdPermitHolder.Name = "grdPermitHolder"
        Me.grdPermitHolder.Size = New System.Drawing.Size(805, 112)
        Me.grdPermitHolder.TabIndex = 6
        '
        'tltip
        '
        Me.tltip.IsBalloon = True
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount.Location = New System.Drawing.Point(261, 127)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(0, 18)
        Me.lblCount.TabIndex = 17
        '
        'FrmPermitHolderMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 291)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FrmPermitHolderMaster"
        Me.Text = "FrmPermitHolder"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdPermitHolder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents grdPermitHolder As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkLifeTime As System.Windows.Forms.CheckBox
    Friend WithEvents lblPermitName As System.Windows.Forms.Label
    Friend WithEvents lblPermitType As System.Windows.Forms.Label
    Friend WithEvents lblPermitNumber As System.Windows.Forms.Label
    Friend WithEvents cmbPermitType As System.Windows.Forms.ComboBox
    Friend WithEvents lblPermitExpireDate As System.Windows.Forms.Label
    Friend WithEvents lblErrorMsg As System.Windows.Forms.Label
    Friend WithEvents lblPermitHolderID As System.Windows.Forms.Label
    Friend WithEvents txtPermitNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtPermitHolderName As System.Windows.Forms.TextBox
    Friend WithEvents txtExpiredate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents imgSave As System.Windows.Forms.Button
    Friend WithEvents imgDelete As System.Windows.Forms.Button
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents tltip As System.Windows.Forms.ToolTip
    Friend WithEvents lblCount As System.Windows.Forms.Label
End Class
