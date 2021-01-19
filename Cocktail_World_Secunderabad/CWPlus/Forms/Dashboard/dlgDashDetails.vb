Public Class dlgDashDetails

    Private Sub dlgDashDetails_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If Me.Opacity >= 1 Then Timer1.Enabled = False
        Me.Opacity += 0.4
    End Sub
End Class