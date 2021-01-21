Public Class FrmChangePassword
    Dim Objuser As CWPlusBL.Master.ClsUserMaster

    Public Sub save()
        If txtNew.Text <> txtConfirm.Text Then
            MsgBox("New password Mismatch", MsgBoxStyle.Information, "CWPlus")
            Exit Sub
        End If
        Try
            Objuser = New CWPlusBL.Master.ClsUserMaster
            Objuser.UserID = gblUserID
            Objuser.FunChangePassword(txtCurrent.Text, txtNew.Text)
            MsgBox(Objuser.ErrorMsg, MsgBoxStyle.Information, "CWPlus")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        save()
    End Sub

    Private Sub FrmChangePassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = btnSave
    End Sub
End Class