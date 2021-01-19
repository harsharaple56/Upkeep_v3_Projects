<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAssignOfficerv2
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lblCheckId = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.imgDelete = New System.Windows.Forms.Button()
        Me.imgSave = New System.Windows.Forms.Button()
        Me.imgClose = New System.Windows.Forms.Button()
        Me.txtDesignation = New System.Windows.Forms.TextBox()
        Me.chkMultiDesignation = New System.Windows.Forms.CheckBox()
        Me.grdDesignation = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.lblCheckIdAnG = New System.Windows.Forms.Label()
        Me.txtAandG = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ImgDeleteAandG = New System.Windows.Forms.Button()
        Me.ImgSaveAandG = New System.Windows.Forms.Button()
        Me.ImgCloseAandG = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.grdAandG = New System.Windows.Forms.DataGridView()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdDesignation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdAandG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(510, 335)
        Me.TabControl1.TabIndex = 28
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.SplitContainer1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(502, 309)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Non-Promotional"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblCheckId)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtDesignation)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkMultiDesignation)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdDesignation)
        Me.SplitContainer1.Size = New System.Drawing.Size(496, 303)
        Me.SplitContainer1.SplitterDistance = 56
        Me.SplitContainer1.TabIndex = 26
        '
        'lblCheckId
        '
        Me.lblCheckId.AutoSize = True
        Me.lblCheckId.Location = New System.Drawing.Point(229, 12)
        Me.lblCheckId.Name = "lblCheckId"
        Me.lblCheckId.Size = New System.Drawing.Size(47, 13)
        Me.lblCheckId.TabIndex = 25
        Me.lblCheckId.Text = "CheckId"
        Me.lblCheckId.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.imgDelete)
        Me.Panel1.Controls.Add(Me.imgSave)
        Me.Panel1.Controls.Add(Me.imgClose)
        Me.Panel1.Location = New System.Drawing.Point(349, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(142, 46)
        Me.Panel1.TabIndex = 15
        '
        'imgDelete
        '
        Me.imgDelete.Image = Global.CWPlus.My.Resources.Resources.button_cancel
        Me.imgDelete.Location = New System.Drawing.Point(51, 3)
        Me.imgDelete.Name = "imgDelete"
        Me.imgDelete.Size = New System.Drawing.Size(41, 40)
        Me.imgDelete.TabIndex = 14
        Me.imgDelete.UseVisualStyleBackColor = True
        '
        'imgSave
        '
        Me.imgSave.Image = Global.CWPlus.My.Resources.Resources.save
        Me.imgSave.Location = New System.Drawing.Point(3, 3)
        Me.imgSave.Name = "imgSave"
        Me.imgSave.Size = New System.Drawing.Size(42, 40)
        Me.imgSave.TabIndex = 10
        Me.imgSave.UseVisualStyleBackColor = True
        '
        'imgClose
        '
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(98, 3)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(41, 40)
        Me.imgClose.TabIndex = 11
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'txtDesignation
        '
        Me.txtDesignation.Location = New System.Drawing.Point(14, 12)
        Me.txtDesignation.Name = "txtDesignation"
        Me.txtDesignation.Size = New System.Drawing.Size(194, 20)
        Me.txtDesignation.TabIndex = 24
        '
        'chkMultiDesignation
        '
        Me.chkMultiDesignation.AutoSize = True
        Me.chkMultiDesignation.Location = New System.Drawing.Point(14, 38)
        Me.chkMultiDesignation.Name = "chkMultiDesignation"
        Me.chkMultiDesignation.Size = New System.Drawing.Size(121, 17)
        Me.chkMultiDesignation.TabIndex = 23
        Me.chkMultiDesignation.Text = "Multiple Designation"
        Me.chkMultiDesignation.UseVisualStyleBackColor = True
        '
        'grdDesignation
        '
        Me.grdDesignation.AllowUserToAddRows = False
        Me.grdDesignation.AllowUserToDeleteRows = False
        Me.grdDesignation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDesignation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDesignation.Location = New System.Drawing.Point(0, 0)
        Me.grdDesignation.Name = "grdDesignation"
        Me.grdDesignation.ReadOnly = True
        Me.grdDesignation.Size = New System.Drawing.Size(496, 243)
        Me.grdDesignation.TabIndex = 25
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.SplitContainer2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(502, 309)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Promotional"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblCheckIdAnG)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtAandG)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Panel2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtRemarks)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.grdAandG)
        Me.SplitContainer2.Size = New System.Drawing.Size(496, 303)
        Me.SplitContainer2.SplitterDistance = 109
        Me.SplitContainer2.TabIndex = 17
        '
        'lblCheckIdAnG
        '
        Me.lblCheckIdAnG.AutoSize = True
        Me.lblCheckIdAnG.Location = New System.Drawing.Point(385, 71)
        Me.lblCheckIdAnG.Name = "lblCheckIdAnG"
        Me.lblCheckIdAnG.Size = New System.Drawing.Size(47, 13)
        Me.lblCheckIdAnG.TabIndex = 33
        Me.lblCheckIdAnG.Text = "CheckId"
        Me.lblCheckIdAnG.Visible = False
        '
        'txtAandG
        '
        Me.txtAandG.Location = New System.Drawing.Point(79, 11)
        Me.txtAandG.Name = "txtAandG"
        Me.txtAandG.Size = New System.Drawing.Size(249, 20)
        Me.txtAandG.TabIndex = 32
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.ImgDeleteAandG)
        Me.Panel2.Controls.Add(Me.ImgSaveAandG)
        Me.Panel2.Controls.Add(Me.ImgCloseAandG)
        Me.Panel2.Location = New System.Drawing.Point(349, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(142, 46)
        Me.Panel2.TabIndex = 16
        '
        'ImgDeleteAandG
        '
        Me.ImgDeleteAandG.Image = Global.CWPlus.My.Resources.Resources.button_cancel
        Me.ImgDeleteAandG.Location = New System.Drawing.Point(51, 3)
        Me.ImgDeleteAandG.Name = "ImgDeleteAandG"
        Me.ImgDeleteAandG.Size = New System.Drawing.Size(41, 40)
        Me.ImgDeleteAandG.TabIndex = 14
        Me.ImgDeleteAandG.UseVisualStyleBackColor = True
        '
        'ImgSaveAandG
        '
        Me.ImgSaveAandG.Image = Global.CWPlus.My.Resources.Resources.save
        Me.ImgSaveAandG.Location = New System.Drawing.Point(3, 3)
        Me.ImgSaveAandG.Name = "ImgSaveAandG"
        Me.ImgSaveAandG.Size = New System.Drawing.Size(42, 40)
        Me.ImgSaveAandG.TabIndex = 10
        Me.ImgSaveAandG.UseVisualStyleBackColor = True
        '
        'ImgCloseAandG
        '
        Me.ImgCloseAandG.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.ImgCloseAandG.Location = New System.Drawing.Point(98, 3)
        Me.ImgCloseAandG.Name = "ImgCloseAandG"
        Me.ImgCloseAandG.Size = New System.Drawing.Size(41, 40)
        Me.ImgCloseAandG.TabIndex = 11
        Me.ImgCloseAandG.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "A&&G Fields"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Remarks"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(79, 43)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(249, 56)
        Me.txtRemarks.TabIndex = 29
        '
        'grdAandG
        '
        Me.grdAandG.AllowUserToAddRows = False
        Me.grdAandG.AllowUserToDeleteRows = False
        Me.grdAandG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdAandG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdAandG.Location = New System.Drawing.Point(0, 0)
        Me.grdAandG.Name = "grdAandG"
        Me.grdAandG.ReadOnly = True
        Me.grdAandG.Size = New System.Drawing.Size(496, 190)
        Me.grdAandG.TabIndex = 31
        '
        'FrmAssignOfficerv2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(510, 335)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FrmAssignOfficerv2"
        Me.Text = "FrmAssignOfficerv2"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdDesignation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdAandG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents chkMultiDesignation As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents imgDelete As System.Windows.Forms.Button
    Friend WithEvents imgSave As System.Windows.Forms.Button
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ImgDeleteAandG As System.Windows.Forms.Button
    Friend WithEvents ImgSaveAandG As System.Windows.Forms.Button
    Friend WithEvents ImgCloseAandG As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grdDesignation As System.Windows.Forms.DataGridView
    Friend WithEvents txtDesignation As System.Windows.Forms.TextBox
    Friend WithEvents grdAandG As System.Windows.Forms.DataGridView
    Friend WithEvents txtAandG As System.Windows.Forms.TextBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblCheckId As System.Windows.Forms.Label
    Friend WithEvents lblCheckIdAnG As System.Windows.Forms.Label
End Class
