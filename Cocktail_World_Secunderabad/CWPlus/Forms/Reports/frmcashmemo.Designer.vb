<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmcashmemo
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
        Me.Dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.DtTo = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCrystalReport = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Dtfrom
        '
        Me.Dtfrom.CustomFormat = "dd-MMM-yyyy"
        Me.Dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtfrom.Location = New System.Drawing.Point(89, 22)
        Me.Dtfrom.Name = "Dtfrom"
        Me.Dtfrom.Size = New System.Drawing.Size(110, 20)
        Me.Dtfrom.TabIndex = 0
        '
        'DtTo
        '
        Me.DtTo.CustomFormat = "dd-MMM-yyyy"
        Me.DtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtTo.Location = New System.Drawing.Point(318, 22)
        Me.DtTo.Name = "DtTo"
        Me.DtTo.Size = New System.Drawing.Size(102, 20)
        Me.DtTo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "From Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(248, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "To Date"
        '
        'btnCrystalReport
        '
        Me.btnCrystalReport.Image = Global.CWPlus.My.Resources.Resources.crystalReport
        Me.btnCrystalReport.Location = New System.Drawing.Point(623, 13)
        Me.btnCrystalReport.Name = "btnCrystalReport"
        Me.btnCrystalReport.Size = New System.Drawing.Size(41, 42)
        Me.btnCrystalReport.TabIndex = 6
        Me.btnCrystalReport.UseVisualStyleBackColor = True
        '
        'frmcashmemo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(689, 262)
        Me.Controls.Add(Me.btnCrystalReport)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DtTo)
        Me.Controls.Add(Me.Dtfrom)
        Me.Name = "frmcashmemo"
        Me.Text = "frmcashmemo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCrystalReport As System.Windows.Forms.Button
End Class
