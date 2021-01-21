<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAssignOfficer
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.imgSave = New System.Windows.Forms.Button()
        Me.imgClose = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.imgDelete = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblCheckId = New System.Windows.Forms.Label()
        Me.chkMultiDesignation = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.drpDiscountType = New System.Windows.Forms.ComboBox()
        Me.lblRevenueCenterId = New System.Windows.Forms.Label()
        Me.drpName = New System.Windows.Forms.ComboBox()
        Me.drpDesignation = New System.Windows.Forms.ComboBox()
        Me.lblRevenueCenterName = New System.Windows.Forms.Label()
        Me.lblBillNo = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(558, 134)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name"
        Me.Label1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Designation"
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
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.imgDelete)
        Me.Panel1.Controls.Add(Me.imgSave)
        Me.Panel1.Controls.Add(Me.imgClose)
        Me.Panel1.Location = New System.Drawing.Point(501, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(142, 46)
        Me.Panel1.TabIndex = 12
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtRemarks)
        Me.GroupBox1.Controls.Add(Me.lblCheckId)
        Me.GroupBox1.Controls.Add(Me.chkMultiDesignation)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.drpDiscountType)
        Me.GroupBox1.Controls.Add(Me.lblRevenueCenterId)
        Me.GroupBox1.Controls.Add(Me.drpDesignation)
        Me.GroupBox1.Controls.Add(Me.lblRevenueCenterName)
        Me.GroupBox1.Controls.Add(Me.lblBillNo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(448, 227)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Assign Designation/A&&G Field"
        '
        'lblCheckId
        '
        Me.lblCheckId.AutoSize = True
        Me.lblCheckId.Location = New System.Drawing.Point(170, 17)
        Me.lblCheckId.Name = "lblCheckId"
        Me.lblCheckId.Size = New System.Drawing.Size(47, 13)
        Me.lblCheckId.TabIndex = 7
        Me.lblCheckId.Text = "CheckId"
        Me.lblCheckId.Visible = False
        '
        'chkMultiDesignation
        '
        Me.chkMultiDesignation.AutoSize = True
        Me.chkMultiDesignation.Location = New System.Drawing.Point(96, 98)
        Me.chkMultiDesignation.Name = "chkMultiDesignation"
        Me.chkMultiDesignation.Size = New System.Drawing.Size(121, 17)
        Me.chkMultiDesignation.TabIndex = 23
        Me.chkMultiDesignation.Text = "Multiple Designation"
        Me.chkMultiDesignation.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 130)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "A&&G Fields"
        '
        'drpDiscountType
        '
        Me.drpDiscountType.FormattingEnabled = True
        Me.drpDiscountType.Location = New System.Drawing.Point(96, 127)
        Me.drpDiscountType.Name = "drpDiscountType"
        Me.drpDiscountType.Size = New System.Drawing.Size(334, 21)
        Me.drpDiscountType.TabIndex = 21
        '
        'lblRevenueCenterId
        '
        Me.lblRevenueCenterId.AutoSize = True
        Me.lblRevenueCenterId.Location = New System.Drawing.Point(297, 17)
        Me.lblRevenueCenterId.Name = "lblRevenueCenterId"
        Me.lblRevenueCenterId.Size = New System.Drawing.Size(91, 13)
        Me.lblRevenueCenterId.TabIndex = 4
        Me.lblRevenueCenterId.Text = "RevenueCenterId"
        Me.lblRevenueCenterId.Visible = False
        '
        'drpName
        '
        Me.drpName.FormattingEnabled = True
        Me.drpName.Location = New System.Drawing.Point(599, 134)
        Me.drpName.Name = "drpName"
        Me.drpName.Size = New System.Drawing.Size(36, 21)
        Me.drpName.TabIndex = 8
        Me.drpName.Visible = False
        '
        'drpDesignation
        '
        Me.drpDesignation.FormattingEnabled = True
        Me.drpDesignation.Location = New System.Drawing.Point(96, 62)
        Me.drpDesignation.Name = "drpDesignation"
        Me.drpDesignation.Size = New System.Drawing.Size(334, 21)
        Me.drpDesignation.TabIndex = 7
        '
        'lblRevenueCenterName
        '
        Me.lblRevenueCenterName.AutoSize = True
        Me.lblRevenueCenterName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRevenueCenterName.Location = New System.Drawing.Point(10, 27)
        Me.lblRevenueCenterName.Name = "lblRevenueCenterName"
        Me.lblRevenueCenterName.Size = New System.Drawing.Size(156, 16)
        Me.lblRevenueCenterName.TabIndex = 6
        Me.lblRevenueCenterName.Text = "RevenueCenterName"
        '
        'lblBillNo
        '
        Me.lblBillNo.AutoSize = True
        Me.lblBillNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBillNo.Location = New System.Drawing.Point(241, 30)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(50, 16)
        Me.lblBillNo.TabIndex = 5
        Me.lblBillNo.Text = "BillNo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(466, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(176, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "NOTE : Has View Data (Sales"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(512, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Transaction) updated"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(96, 163)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(334, 56)
        Me.txtRemarks.TabIndex = 29
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 166)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Remarks"
        Me.Label6.Visible = False
        '
        'FrmAssignOfficer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(655, 245)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.drpName)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmAssignOfficer"
        Me.Text = "FrmAssignOfficer"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents imgSave As System.Windows.Forms.Button
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRevenueCenterName As System.Windows.Forms.Label
    Friend WithEvents lblBillNo As System.Windows.Forms.Label
    Friend WithEvents lblRevenueCenterId As System.Windows.Forms.Label
    Friend WithEvents lblCheckId As System.Windows.Forms.Label
    Friend WithEvents drpName As System.Windows.Forms.ComboBox
    Friend WithEvents drpDesignation As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents drpDiscountType As System.Windows.Forms.ComboBox
    Friend WithEvents imgDelete As System.Windows.Forms.Button
    Friend WithEvents chkMultiDesignation As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
End Class
