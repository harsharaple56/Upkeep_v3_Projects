<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenuEngineeringMaster
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
        Me.cmbMethod = New System.Windows.Forms.ComboBox()
        Me.txtChallenge = New System.Windows.Forms.TextBox()
        Me.txtDog = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtStar = New System.Windows.Forms.TextBox()
        Me.txtHorse = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbDefault = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.imgSave = New System.Windows.Forms.Button()
        Me.imgClose = New System.Windows.Forms.Button()
        Me.lblID = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbMethod
        '
        Me.cmbMethod.FormattingEnabled = True
        Me.cmbMethod.Location = New System.Drawing.Point(62, 9)
        Me.cmbMethod.Name = "cmbMethod"
        Me.cmbMethod.Size = New System.Drawing.Size(121, 21)
        Me.cmbMethod.TabIndex = 0
        '
        'txtChallenge
        '
        Me.txtChallenge.Location = New System.Drawing.Point(61, 19)
        Me.txtChallenge.Name = "txtChallenge"
        Me.txtChallenge.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtChallenge.Size = New System.Drawing.Size(63, 20)
        Me.txtChallenge.TabIndex = 1
        Me.txtChallenge.Text = "0"
        '
        'txtDog
        '
        Me.txtDog.Location = New System.Drawing.Point(61, 45)
        Me.txtDog.Name = "txtDog"
        Me.txtDog.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtDog.Size = New System.Drawing.Size(63, 20)
        Me.txtDog.TabIndex = 3
        Me.txtDog.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Method"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(139, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Star"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Dog"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(130, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Horse"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Challenge"
        '
        'txtStar
        '
        Me.txtStar.Location = New System.Drawing.Point(171, 19)
        Me.txtStar.Name = "txtStar"
        Me.txtStar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtStar.Size = New System.Drawing.Size(63, 20)
        Me.txtStar.TabIndex = 11
        Me.txtStar.Text = "0"
        '
        'txtHorse
        '
        Me.txtHorse.Location = New System.Drawing.Point(171, 45)
        Me.txtHorse.Name = "txtHorse"
        Me.txtHorse.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtHorse.Size = New System.Drawing.Size(63, 20)
        Me.txtHorse.TabIndex = 12
        Me.txtHorse.Text = "0"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtChallenge)
        Me.GroupBox1.Controls.Add(Me.txtHorse)
        Me.GroupBox1.Controls.Add(Me.txtDog)
        Me.GroupBox1.Controls.Add(Me.txtStar)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(243, 77)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Menu Engineering"
        '
        'cmbDefault
        '
        Me.cmbDefault.FormattingEnabled = True
        Me.cmbDefault.Location = New System.Drawing.Point(107, 15)
        Me.cmbDefault.Name = "cmbDefault"
        Me.cmbDefault.Size = New System.Drawing.Size(121, 21)
        Me.cmbDefault.TabIndex = 14
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cmbDefault)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 130)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(239, 43)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Default Method"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Default Method"
        '
        'imgSave
        '
        Me.imgSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgSave.Image = Global.CWPlus.My.Resources.Resources.save
        Me.imgSave.Location = New System.Drawing.Point(335, 12)
        Me.imgSave.Name = "imgSave"
        Me.imgSave.Size = New System.Drawing.Size(43, 41)
        Me.imgSave.TabIndex = 16
        Me.imgSave.UseVisualStyleBackColor = True
        '
        'imgClose
        '
        Me.imgClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(384, 12)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(40, 41)
        Me.imgClose.TabIndex = 17
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(206, 12)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(13, 13)
        Me.lblID.TabIndex = 18
        Me.lblID.Text = "0"
        Me.lblID.Visible = False
        '
        'frmMenuEngineeringMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(436, 191)
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.imgSave)
        Me.Controls.Add(Me.imgClose)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbMethod)
        Me.Name = "frmMenuEngineeringMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmMenuEngineeringMaster"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbMethod As System.Windows.Forms.ComboBox
    Friend WithEvents txtChallenge As System.Windows.Forms.TextBox
    Friend WithEvents txtDog As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtStar As System.Windows.Forms.TextBox
    Friend WithEvents txtHorse As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbDefault As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents imgSave As System.Windows.Forms.Button
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblID As System.Windows.Forms.Label
End Class
