Public Class QVDateSelection
    Private Sub btnOK_ClickButtonArea(Sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles btnOK.ClickButtonArea
        GblPurchaseDate = DateTimePicker1.Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub QVDateSelection_Load(sender As Object, e As System.EventArgs) Handles Me.Load

    End Sub
End Class