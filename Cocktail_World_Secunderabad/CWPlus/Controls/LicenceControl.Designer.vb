<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LicenceControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.cmdMultiSelect = New System.Windows.Forms.Button()
        Me.chkLicenseName = New System.Windows.Forms.CheckedListBox()
        Me.cmbLicenseName = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'cmdMultiSelect
        '
        Me.cmdMultiSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdMultiSelect.Location = New System.Drawing.Point(255, 2)
        Me.cmdMultiSelect.Name = "cmdMultiSelect"
        Me.cmdMultiSelect.Size = New System.Drawing.Size(24, 21)
        Me.cmdMultiSelect.TabIndex = 25
        Me.cmdMultiSelect.Text = "M"
        Me.cmdMultiSelect.UseVisualStyleBackColor = True
        '
        'chkLicenseName
        '
        Me.chkLicenseName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkLicenseName.CheckOnClick = True
        Me.chkLicenseName.FormattingEnabled = True
        Me.chkLicenseName.Location = New System.Drawing.Point(6, 26)
        Me.chkLicenseName.Name = "chkLicenseName"
        Me.chkLicenseName.Size = New System.Drawing.Size(246, 199)
        Me.chkLicenseName.TabIndex = 24
        Me.chkLicenseName.Visible = False
        '
        'cmbLicenseName
        '
        Me.cmbLicenseName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbLicenseName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLicenseName.FormattingEnabled = True
        Me.cmbLicenseName.Location = New System.Drawing.Point(5, 2)
        Me.cmbLicenseName.Name = "cmbLicenseName"
        Me.cmbLicenseName.Size = New System.Drawing.Size(247, 21)
        Me.cmbLicenseName.TabIndex = 23
        '
        'LicenceControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdMultiSelect)
        Me.Controls.Add(Me.chkLicenseName)
        Me.Controls.Add(Me.cmbLicenseName)
        Me.Name = "LicenceControl"
        Me.Size = New System.Drawing.Size(284, 234)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdMultiSelect As System.Windows.Forms.Button
    Friend WithEvents chkLicenseName As System.Windows.Forms.CheckedListBox
    Friend WithEvents cmbLicenseName As System.Windows.Forms.ComboBox

End Class
