<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSendReport
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
        Me.txtserver = New System.Windows.Forms.TextBox()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkEnableSSL = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFrom = New System.Windows.Forms.TextBox()
        Me.txtTo = New System.Windows.Forms.TextBox()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtserver
        '
        Me.txtserver.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtserver.Location = New System.Drawing.Point(115, 22)
        Me.txtserver.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtserver.Name = "txtserver"
        Me.txtserver.Size = New System.Drawing.Size(303, 22)
        Me.txtserver.TabIndex = 0
        '
        'txtUser
        '
        Me.txtUser.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtUser.Location = New System.Drawing.Point(115, 62)
        Me.txtUser.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(303, 22)
        Me.txtUser.TabIndex = 1
        '
        'txtPass
        '
        Me.txtPass.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtPass.Location = New System.Drawing.Point(115, 101)
        Me.txtPass.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(303, 22)
        Me.txtPass.TabIndex = 2
        '
        'txtPort
        '
        Me.txtPort.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtPort.Location = New System.Drawing.Point(115, 141)
        Me.txtPort.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(303, 22)
        Me.txtPort.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(21, 26)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "SMTP Server"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(34, 65)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 14)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "UserName"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(37, 104)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 14)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Password"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(52, 144)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 14)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Port No"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkEnableSSL)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtserver)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtUser)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtPass)
        Me.GroupBox1.Controls.Add(Me.txtPort)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(449, 207)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mail Settings"
        '
        'chkEnableSSL
        '
        Me.chkEnableSSL.AutoSize = True
        Me.chkEnableSSL.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.chkEnableSSL.Location = New System.Drawing.Point(115, 177)
        Me.chkEnableSSL.Name = "chkEnableSSL"
        Me.chkEnableSSL.Size = New System.Drawing.Size(96, 18)
        Me.chkEnableSSL.TabIndex = 8
        Me.chkEnableSSL.Text = "Enable SSL"
        Me.chkEnableSSL.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtFrom)
        Me.GroupBox2.Controls.Add(Me.txtTo)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 230)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(449, 153)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sending Option"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(29, 66)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 14)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "To Mail ID's"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(40, 24)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 14)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "From Mail"
        '
        'txtFrom
        '
        Me.txtFrom.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtFrom.Location = New System.Drawing.Point(115, 21)
        Me.txtFrom.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.Size = New System.Drawing.Size(303, 22)
        Me.txtFrom.TabIndex = 5
        '
        'txtTo
        '
        Me.txtTo.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtTo.Location = New System.Drawing.Point(115, 63)
        Me.txtTo.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtTo.Multiline = True
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(303, 81)
        Me.txtTo.TabIndex = 4
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(127, 393)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(303, 34)
        Me.btnSend.TabIndex = 10
        Me.btnSend.Text = "Save && Send Mail"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'frmSendReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(471, 439)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSendReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Send Report"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtserver As System.Windows.Forms.TextBox
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFrom As System.Windows.Forms.TextBox
    Friend WithEvents txtTo As System.Windows.Forms.TextBox
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents chkEnableSSL As System.Windows.Forms.CheckBox
End Class
