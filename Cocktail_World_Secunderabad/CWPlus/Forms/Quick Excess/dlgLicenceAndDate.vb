Public Class dlgLicenceAndDate

    Private Sub tmrButtonFocus_Tick(sender As System.Object, e As System.EventArgs) Handles tmrButtonFocus.Tick
        If btnOK.ForeColor = Color.White Then
            btnOK.ForeColor = Color.Black
        Else
            btnOK.ForeColor = Color.White
        End If
    End Sub

    Private Sub btnOK_ClickButtonArea(Sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles btnOK.ClickButtonArea
        GblPurchaseDate = DateTimePicker1.Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

  
End Class