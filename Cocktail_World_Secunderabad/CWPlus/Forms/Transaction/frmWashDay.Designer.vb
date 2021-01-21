<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWashDay
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbLicense = New System.Windows.Forms.ComboBox()
        Me.lblLicenseID = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnWash = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkTransfer = New System.Windows.Forms.CheckBox()
        Me.chkPurchase = New System.Windows.Forms.CheckBox()
        Me.chkSale = New System.Windows.Forms.CheckBox()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbLicense)
        Me.GroupBox1.Controls.Add(Me.lblLicenseID)
        Me.GroupBox1.Controls.Add(Me.btnClose)
        Me.GroupBox1.Controls.Add(Me.btnWash)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.chkTransfer)
        Me.GroupBox1.Controls.Add(Me.chkPurchase)
        Me.GroupBox1.Controls.Add(Me.chkSale)
        Me.GroupBox1.Controls.Add(Me.dtpTo)
        Me.GroupBox1.Controls.Add(Me.dtpFrom)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(362, 142)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Wash Day"
        '
        'cmbLicense
        '
        Me.cmbLicense.FormattingEnabled = True
        Me.cmbLicense.Location = New System.Drawing.Point(155, 72)
        Me.cmbLicense.Name = "cmbLicense"
        Me.cmbLicense.Size = New System.Drawing.Size(197, 21)
        Me.cmbLicense.TabIndex = 11
        '
        'lblLicenseID
        '
        Me.lblLicenseID.AutoSize = True
        Me.lblLicenseID.Location = New System.Drawing.Point(87, 75)
        Me.lblLicenseID.Name = "lblLicenseID"
        Me.lblLicenseID.Size = New System.Drawing.Size(62, 13)
        Me.lblLicenseID.TabIndex = 12
        Me.lblLicenseID.Text = "For License"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(171, 101)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(59, 23)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnWash
        '
        Me.btnWash.Location = New System.Drawing.Point(98, 103)
        Me.btnWash.Name = "btnWash"
        Me.btnWash.Size = New System.Drawing.Size(64, 23)
        Me.btnWash.TabIndex = 7
        Me.btnWash.Text = "&Wash"
        Me.btnWash.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(184, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "To Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "From Date"
        '
        'chkTransfer
        '
        Me.chkTransfer.AutoSize = True
        Me.chkTransfer.Location = New System.Drawing.Point(190, 47)
        Me.chkTransfer.Name = "chkTransfer"
        Me.chkTransfer.Size = New System.Drawing.Size(65, 17)
        Me.chkTransfer.TabIndex = 4
        Me.chkTransfer.Text = "Transfer"
        Me.chkTransfer.UseVisualStyleBackColor = True
        '
        'chkPurchase
        '
        Me.chkPurchase.AutoSize = True
        Me.chkPurchase.Location = New System.Drawing.Point(113, 47)
        Me.chkPurchase.Name = "chkPurchase"
        Me.chkPurchase.Size = New System.Drawing.Size(71, 17)
        Me.chkPurchase.TabIndex = 3
        Me.chkPurchase.Text = "Purchase"
        Me.chkPurchase.UseVisualStyleBackColor = True
        Me.chkPurchase.Visible = False
        '
        'chkSale
        '
        Me.chkSale.AutoSize = True
        Me.chkSale.Location = New System.Drawing.Point(60, 47)
        Me.chkSale.Name = "chkSale"
        Me.chkSale.Size = New System.Drawing.Size(47, 17)
        Me.chkSale.TabIndex = 2
        Me.chkSale.Text = "Sale"
        Me.chkSale.UseVisualStyleBackColor = True
        '
        'dtpTo
        '
        Me.dtpTo.CustomFormat = "dd/MM/yyyy"
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(236, 21)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(109, 20)
        Me.dtpTo.TabIndex = 1
        '
        'dtpFrom
        '
        Me.dtpFrom.CustomFormat = "dd/MM/yyyy"
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(69, 21)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(109, 20)
        Me.dtpFrom.TabIndex = 0
        '
        'frmWashDay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(482, 197)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmWashDay"
        Me.Text = "frmWashDay"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkTransfer As System.Windows.Forms.CheckBox
    Friend WithEvents chkPurchase As System.Windows.Forms.CheckBox
    Friend WithEvents chkSale As System.Windows.Forms.CheckBox
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnWash As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents cmbLicense As System.Windows.Forms.ComboBox
    Friend WithEvents lblLicenseID As System.Windows.Forms.Label
End Class
