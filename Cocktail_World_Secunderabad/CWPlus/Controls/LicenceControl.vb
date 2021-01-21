Public Class LicenceControl

    Private Sub cmdMultiSelect_Click(sender As System.Object, e As System.EventArgs) Handles cmdMultiSelect.Click
        If DirectCast(sender, Button).Text = "M" Then
            DirectCast(sender, Button).Text = "S"
            Me.Height = 228
        Else
            Me.Height = 25
            DirectCast(sender, Button).Text = "M"
        End If

    End Sub

End Class
