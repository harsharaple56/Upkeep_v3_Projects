<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAssignDiscountv2
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
        Me.grpDiscType = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.drpDiscountType = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.imgSave = New System.Windows.Forms.Button()
        Me.imgClose = New System.Windows.Forms.Button()
        Me.lblRevenueCenterName = New System.Windows.Forms.Label()
        Me.lblBillNo = New System.Windows.Forms.Label()
        Me.grpDiscType.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpDiscType
        '
        Me.grpDiscType.Controls.Add(Me.lblBillNo)
        Me.grpDiscType.Controls.Add(Me.lblRevenueCenterName)
        Me.grpDiscType.Controls.Add(Me.Label1)
        Me.grpDiscType.Controls.Add(Me.txtRemarks)
        Me.grpDiscType.Controls.Add(Me.drpDiscountType)
        Me.grpDiscType.Location = New System.Drawing.Point(12, 12)
        Me.grpDiscType.Name = "grpDiscType"
        Me.grpDiscType.Size = New System.Drawing.Size(296, 213)
        Me.grpDiscType.TabIndex = 24
        Me.grpDiscType.TabStop = False
        Me.grpDiscType.Text = "Select Discount Type"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Remarks"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(17, 130)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(261, 67)
        Me.txtRemarks.TabIndex = 21
        '
        'drpDiscountType
        '
        Me.drpDiscountType.FormattingEnabled = True
        Me.drpDiscountType.Location = New System.Drawing.Point(17, 71)
        Me.drpDiscountType.Name = "drpDiscountType"
        Me.drpDiscountType.Size = New System.Drawing.Size(203, 21)
        Me.drpDiscountType.TabIndex = 20
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.imgSave)
        Me.Panel1.Controls.Add(Me.imgClose)
        Me.Panel1.Location = New System.Drawing.Point(314, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(97, 46)
        Me.Panel1.TabIndex = 26
        '
        'imgSave
        '
        Me.imgSave.Image = Global.CWPlus.My.Resources.Resources.save
        Me.imgSave.Location = New System.Drawing.Point(3, 3)
        Me.imgSave.Name = "imgSave"
        Me.imgSave.Size = New System.Drawing.Size(39, 40)
        Me.imgSave.TabIndex = 3
        Me.imgSave.UseVisualStyleBackColor = True
        '
        'imgClose
        '
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(48, 3)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(45, 40)
        Me.imgClose.TabIndex = 5
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'lblRevenueCenterName
        '
        Me.lblRevenueCenterName.AutoSize = True
        Me.lblRevenueCenterName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRevenueCenterName.Location = New System.Drawing.Point(17, 22)
        Me.lblRevenueCenterName.Name = "lblRevenueCenterName"
        Me.lblRevenueCenterName.Size = New System.Drawing.Size(94, 13)
        Me.lblRevenueCenterName.TabIndex = 23
        Me.lblRevenueCenterName.Text = "Revenuecenter"
        '
        'lblBillNo
        '
        Me.lblBillNo.AutoSize = True
        Me.lblBillNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBillNo.Location = New System.Drawing.Point(17, 47)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(38, 13)
        Me.lblBillNo.TabIndex = 24
        Me.lblBillNo.Text = "Billno"
        '
        'FrmAssignDiscountv2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(423, 237)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grpDiscType)
        Me.Name = "FrmAssignDiscountv2"
        Me.Text = "Select Discount Type"
        Me.grpDiscType.ResumeLayout(False)
        Me.grpDiscType.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpDiscType As System.Windows.Forms.GroupBox
    Friend WithEvents drpDiscountType As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents imgSave As System.Windows.Forms.Button
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblBillNo As System.Windows.Forms.Label
    Friend WithEvents lblRevenueCenterName As System.Windows.Forms.Label
End Class
