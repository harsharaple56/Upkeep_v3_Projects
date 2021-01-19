<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUserLicense
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.imgSave = New System.Windows.Forms.Button()
        Me.imgClose = New System.Windows.Forms.Button()
        Me.grpUserLicense = New System.Windows.Forms.GroupBox()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.cmbUserLicense = New System.Windows.Forms.ComboBox()
        Me.grdUserLicense = New System.Windows.Forms.DataGridView()
        Me.LicenseDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sel = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.licenseID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tltip = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.grpUserLicense.SuspendLayout()
        CType(Me.grdUserLicense, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpUserLicense)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdUserLicense)
        Me.SplitContainer1.Size = New System.Drawing.Size(353, 399)
        Me.SplitContainer1.SplitterDistance = 84
        Me.SplitContainer1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.imgSave)
        Me.Panel1.Controls.Add(Me.imgClose)
        Me.Panel1.Location = New System.Drawing.Point(248, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(105, 45)
        Me.Panel1.TabIndex = 16
        '
        'imgSave
        '
        Me.imgSave.Image = Global.CWPlus.My.Resources.Resources.save
        Me.imgSave.Location = New System.Drawing.Point(3, 3)
        Me.imgSave.Name = "imgSave"
        Me.imgSave.Size = New System.Drawing.Size(45, 40)
        Me.imgSave.TabIndex = 3
        Me.tltip.SetToolTip(Me.imgSave, "Save")
        Me.imgSave.UseVisualStyleBackColor = True
        '
        'imgClose
        '
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(54, 3)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(43, 40)
        Me.imgClose.TabIndex = 4
        Me.tltip.SetToolTip(Me.imgClose, "Close")
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'grpUserLicense
        '
        Me.grpUserLicense.Controls.Add(Me.lblUser)
        Me.grpUserLicense.Controls.Add(Me.cmbUserLicense)
        Me.grpUserLicense.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpUserLicense.Location = New System.Drawing.Point(3, 3)
        Me.grpUserLicense.Name = "grpUserLicense"
        Me.grpUserLicense.Size = New System.Drawing.Size(189, 56)
        Me.grpUserLicense.TabIndex = 0
        Me.grpUserLicense.TabStop = False
        Me.grpUserLicense.Text = "User License"
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(9, 27)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(29, 13)
        Me.lblUser.TabIndex = 1
        Me.lblUser.Text = "User"
        '
        'cmbUserLicense
        '
        Me.cmbUserLicense.FormattingEnabled = True
        Me.cmbUserLicense.Location = New System.Drawing.Point(56, 24)
        Me.cmbUserLicense.Name = "cmbUserLicense"
        Me.cmbUserLicense.Size = New System.Drawing.Size(121, 21)
        Me.cmbUserLicense.TabIndex = 1
        '
        'grdUserLicense
        '
        Me.grdUserLicense.AllowUserToAddRows = False
        Me.grdUserLicense.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdUserLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdUserLicense.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LicenseDesc, Me.sel, Me.licenseID})
        Me.grdUserLicense.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdUserLicense.GridColor = System.Drawing.Color.Black
        Me.grdUserLicense.Location = New System.Drawing.Point(0, 0)
        Me.grdUserLicense.Name = "grdUserLicense"
        Me.grdUserLicense.Size = New System.Drawing.Size(353, 311)
        Me.grdUserLicense.TabIndex = 2
        '
        'LicenseDesc
        '
        Me.LicenseDesc.HeaderText = "License"
        Me.LicenseDesc.Name = "LicenseDesc"
        '
        'sel
        '
        Me.sel.HeaderText = "Select"
        Me.sel.Name = "sel"
        '
        'licenseID
        '
        Me.licenseID.HeaderText = "licenseID"
        Me.licenseID.Name = "licenseID"
        '
        'tltip
        '
        Me.tltip.IsBalloon = True
        '
        'FrmUserLicense
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(353, 399)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmUserLicense"
        Me.Text = "FrmUserLicense"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.grpUserLicense.ResumeLayout(False)
        Me.grpUserLicense.PerformLayout()
        CType(Me.grdUserLicense, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents grpUserLicense As System.Windows.Forms.GroupBox
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents cmbUserLicense As System.Windows.Forms.ComboBox
    Friend WithEvents grdUserLicense As System.Windows.Forms.DataGridView
    Friend WithEvents LicenseDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sel As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents licenseID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents imgSave As System.Windows.Forms.Button
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents tltip As System.Windows.Forms.ToolTip
End Class
