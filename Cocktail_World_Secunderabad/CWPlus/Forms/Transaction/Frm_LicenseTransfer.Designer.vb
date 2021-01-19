<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_LicenseTransfer
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.imgSave = New System.Windows.Forms.Button()
        Me.imgClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkCocktail = New System.Windows.Forms.CheckBox()
        Me.chkBrandOpening = New System.Windows.Forms.CheckBox()
        Me.chkCocktailCode = New System.Windows.Forms.CheckBox()
        Me.chkAssignBrandCode = New System.Windows.Forms.CheckBox()
        Me.chkLicenseName = New System.Windows.Forms.CheckedListBox()
        Me.lblLicense = New System.Windows.Forms.Label()
        Me.chkMMSCode = New System.Windows.Forms.CheckBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.chkLicenseName)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblLicense)
        Me.SplitContainer1.Size = New System.Drawing.Size(933, 451)
        Me.SplitContainer1.SplitterDistance = 72
        Me.SplitContainer1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.imgSave)
        Me.Panel1.Controls.Add(Me.imgClose)
        Me.Panel1.Location = New System.Drawing.Point(824, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(106, 51)
        Me.Panel1.TabIndex = 13
        '
        'imgSave
        '
        Me.imgSave.Image = Global.CWPlus.My.Resources.Resources.save
        Me.imgSave.Location = New System.Drawing.Point(3, 3)
        Me.imgSave.Name = "imgSave"
        Me.imgSave.Size = New System.Drawing.Size(44, 42)
        Me.imgSave.TabIndex = 5
        Me.imgSave.UseVisualStyleBackColor = True
        '
        'imgClose
        '
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(53, 3)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(45, 42)
        Me.imgClose.TabIndex = 7
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkMMSCode)
        Me.GroupBox1.Controls.Add(Me.chkCocktail)
        Me.GroupBox1.Controls.Add(Me.chkBrandOpening)
        Me.GroupBox1.Controls.Add(Me.chkCocktailCode)
        Me.GroupBox1.Controls.Add(Me.chkAssignBrandCode)
        Me.GroupBox1.Location = New System.Drawing.Point(398, 19)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(503, 70)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select "
        '
        'chkCocktail
        '
        Me.chkCocktail.AutoSize = True
        Me.chkCocktail.Location = New System.Drawing.Point(239, 28)
        Me.chkCocktail.Name = "chkCocktail"
        Me.chkCocktail.Size = New System.Drawing.Size(64, 17)
        Me.chkCocktail.TabIndex = 31
        Me.chkCocktail.Text = "Cocktail"
        Me.chkCocktail.UseVisualStyleBackColor = True
        '
        'chkBrandOpening
        '
        Me.chkBrandOpening.AutoSize = True
        Me.chkBrandOpening.Location = New System.Drawing.Point(20, 28)
        Me.chkBrandOpening.Name = "chkBrandOpening"
        Me.chkBrandOpening.Size = New System.Drawing.Size(94, 17)
        Me.chkBrandOpening.TabIndex = 1
        Me.chkBrandOpening.Text = "BrandOpening"
        Me.chkBrandOpening.UseVisualStyleBackColor = True
        '
        'chkCocktailCode
        '
        Me.chkCocktailCode.AutoSize = True
        Me.chkCocktailCode.Location = New System.Drawing.Point(307, 28)
        Me.chkCocktailCode.Name = "chkCocktailCode"
        Me.chkCocktailCode.Size = New System.Drawing.Size(92, 17)
        Me.chkCocktailCode.TabIndex = 30
        Me.chkCocktailCode.Text = "Cocktail Code"
        Me.chkCocktailCode.UseVisualStyleBackColor = True
        '
        'chkAssignBrandCode
        '
        Me.chkAssignBrandCode.AutoSize = True
        Me.chkAssignBrandCode.Location = New System.Drawing.Point(117, 28)
        Me.chkAssignBrandCode.Name = "chkAssignBrandCode"
        Me.chkAssignBrandCode.Size = New System.Drawing.Size(116, 17)
        Me.chkAssignBrandCode.TabIndex = 29
        Me.chkAssignBrandCode.Text = "Assign Brand Code"
        Me.chkAssignBrandCode.UseVisualStyleBackColor = True
        '
        'chkLicenseName
        '
        Me.chkLicenseName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkLicenseName.CheckOnClick = True
        Me.chkLicenseName.FormattingEnabled = True
        Me.chkLicenseName.Location = New System.Drawing.Point(95, 19)
        Me.chkLicenseName.Name = "chkLicenseName"
        Me.chkLicenseName.Size = New System.Drawing.Size(246, 139)
        Me.chkLicenseName.TabIndex = 28
        '
        'lblLicense
        '
        Me.lblLicense.AutoSize = True
        Me.lblLicense.Location = New System.Drawing.Point(16, 19)
        Me.lblLicense.Name = "lblLicense"
        Me.lblLicense.Size = New System.Drawing.Size(77, 13)
        Me.lblLicense.TabIndex = 0
        Me.lblLicense.Text = "Select License"
        '
        'chkMMSCode
        '
        Me.chkMMSCode.AutoSize = True
        Me.chkMMSCode.Location = New System.Drawing.Point(405, 28)
        Me.chkMMSCode.Name = "chkMMSCode"
        Me.chkMMSCode.Size = New System.Drawing.Size(79, 17)
        Me.chkMMSCode.TabIndex = 32
        Me.chkMMSCode.Text = "MMS Code"
        Me.chkMMSCode.UseVisualStyleBackColor = True
        '
        'Frm_LicenseTransfer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(933, 451)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "Frm_LicenseTransfer"
        Me.Text = "Frm_LicenseTransfer"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents chkBrandOpening As System.Windows.Forms.CheckBox
    Friend WithEvents lblLicense As System.Windows.Forms.Label
    Friend WithEvents chkLicenseName As System.Windows.Forms.CheckedListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkCocktail As System.Windows.Forms.CheckBox
    Friend WithEvents chkCocktailCode As System.Windows.Forms.CheckBox
    Friend WithEvents chkAssignBrandCode As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents imgSave As System.Windows.Forms.Button
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents chkMMSCode As System.Windows.Forms.CheckBox
End Class
