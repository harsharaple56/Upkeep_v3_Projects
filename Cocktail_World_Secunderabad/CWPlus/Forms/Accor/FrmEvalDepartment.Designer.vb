<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEvalDepartment
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
        Me.grdEvalDepartment = New System.Windows.Forms.DataGridView()
        Me.imgSave = New System.Windows.Forms.Button()
        Me.imgDelete = New System.Windows.Forms.Button()
        Me.imgClose = New System.Windows.Forms.Button()
        Me.lblid = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.txtDepartment = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.imgNew = New System.Windows.Forms.Button()
        Me.tltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDeptCode = New System.Windows.Forms.TextBox()
        CType(Me.grdEvalDepartment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdEvalDepartment
        '
        Me.grdEvalDepartment.AllowDrop = True
        Me.grdEvalDepartment.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdEvalDepartment.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdEvalDepartment.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdEvalDepartment.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdEvalDepartment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdEvalDepartment.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdEvalDepartment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdEvalDepartment.GridColor = System.Drawing.Color.Black
        Me.grdEvalDepartment.Location = New System.Drawing.Point(0, 0)
        Me.grdEvalDepartment.Name = "grdEvalDepartment"
        Me.grdEvalDepartment.ReadOnly = True
        Me.grdEvalDepartment.Size = New System.Drawing.Size(601, 268)
        Me.grdEvalDepartment.TabIndex = 2
        '
        'imgSave
        '
        Me.imgSave.Image = Global.CWPlus.My.Resources.Resources.save
        Me.imgSave.Location = New System.Drawing.Point(52, 3)
        Me.imgSave.Name = "imgSave"
        Me.imgSave.Size = New System.Drawing.Size(39, 40)
        Me.imgSave.TabIndex = 3
        Me.tltip.SetToolTip(Me.imgSave, "Save")
        Me.imgSave.UseVisualStyleBackColor = True
        '
        'imgDelete
        '
        Me.imgDelete.Image = Global.CWPlus.My.Resources.Resources.button_cancel
        Me.imgDelete.Location = New System.Drawing.Point(96, 3)
        Me.imgDelete.Name = "imgDelete"
        Me.imgDelete.Size = New System.Drawing.Size(41, 40)
        Me.imgDelete.TabIndex = 4
        Me.tltip.SetToolTip(Me.imgDelete, "Delete")
        Me.imgDelete.UseVisualStyleBackColor = True
        '
        'imgClose
        '
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(143, 3)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(45, 40)
        Me.imgClose.TabIndex = 5
        Me.tltip.SetToolTip(Me.imgClose, "Close")
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'lblid
        '
        Me.lblid.AutoSize = True
        Me.lblid.Location = New System.Drawing.Point(332, 20)
        Me.lblid.Name = "lblid"
        Me.lblid.Size = New System.Drawing.Size(0, 13)
        Me.lblid.TabIndex = 1
        Me.lblid.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Department"
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtDeptCode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtDepartment)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblid)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdEvalDepartment)
        Me.SplitContainer1.Size = New System.Drawing.Size(601, 366)
        Me.SplitContainer1.SplitterDistance = 94
        Me.SplitContainer1.TabIndex = 2
        '
        'txtDepartment
        '
        Me.txtDepartment.Location = New System.Drawing.Point(86, 17)
        Me.txtDepartment.Name = "txtDepartment"
        Me.txtDepartment.Size = New System.Drawing.Size(251, 20)
        Me.txtDepartment.TabIndex = 14
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.imgNew)
        Me.Panel1.Controls.Add(Me.imgSave)
        Me.Panel1.Controls.Add(Me.imgDelete)
        Me.Panel1.Controls.Add(Me.imgClose)
        Me.Panel1.Location = New System.Drawing.Point(409, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(192, 46)
        Me.Panel1.TabIndex = 13
        '
        'imgNew
        '
        Me.imgNew.Image = Global.CWPlus.My.Resources.Resources.window_new
        Me.imgNew.Location = New System.Drawing.Point(3, 3)
        Me.imgNew.Name = "imgNew"
        Me.imgNew.Size = New System.Drawing.Size(43, 40)
        Me.imgNew.TabIndex = 10
        Me.tltip.SetToolTip(Me.imgNew, "Add New")
        Me.imgNew.UseVisualStyleBackColor = True
        '
        'tltip
        '
        Me.tltip.IsBalloon = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(42, 43)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Code"
        '
        'txtDeptCode
        '
        Me.txtDeptCode.Location = New System.Drawing.Point(86, 43)
        Me.txtDeptCode.Name = "txtDeptCode"
        Me.txtDeptCode.Size = New System.Drawing.Size(126, 20)
        Me.txtDeptCode.TabIndex = 22
        '
        'FrmEvalDepartment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 366)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmEvalDepartment"
        Me.Text = "Department"
        CType(Me.grdEvalDepartment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdEvalDepartment As System.Windows.Forms.DataGridView
    Friend WithEvents imgSave As System.Windows.Forms.Button
    Friend WithEvents tltip As System.Windows.Forms.ToolTip
    Friend WithEvents imgDelete As System.Windows.Forms.Button
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents lblid As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtDepartment As System.Windows.Forms.TextBox
    Friend WithEvents imgNew As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDeptCode As System.Windows.Forms.TextBox
End Class
