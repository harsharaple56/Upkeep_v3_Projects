Imports CWPlusBL
Public Class FrmManageVariance
    Dim dt As DataTable
    Dim objQV As ClsQuickExcess
    '[+][12/12/2019][Ajay Prajapati]
    Dim MaxVarianceDate As Date
    '[-][12/12/2019][Ajay Prajapati]

    Public Sub BindGrid()
        Try
            dt = New DataTable
            objQV = New ClsQuickExcess
            objQV.Month = 0
            objQV.FromDate = dtpFrom.Value
            objQV.ToDate = DtpTo.Value

            '[+][14/09/2019][Ajay Prajapati]
            objQV.LicenseID = gblLicenseID
            '[-][14/09/2019][Ajay Prajapati]

            dt = objQV.FetchVarianceDatewise.Tables(0)
            grd.DataSource = Nothing
            grd.DataSource = dt
            grd.Columns("LicenseID").Visible = False
            '[+][12/12/2019][Ajay Prajapati]
            If (dt.Rows.Count > 0) Then
                MaxVarianceDate = Date.Parse(dt.Rows(0)("VarDate"))
            End If
            '[-][12/12/2019][Ajay Prajapati]
        Catch ex As Exception
            Throw ex
        Finally
            dt = Nothing
            objQV = Nothing
        End Try
    End Sub
    Public Sub DeleteRecords(ByVal LicID As Double, ByVal vardate As Date)
        Try
            '[+][12/12/2019][Ajay Prajapati]
            If MaxVarianceDate > vardate Then
                Dim Ans1 As String = MsgBox("Can Not Delete Variance", MsgBoxStyle.YesNo, "Remove")
                If Ans1 = vbNo Then
                    Exit Sub
                End If
            Else

                '[-][12/12/2019][Ajay Prajapati]

                Dim Ans As String = MsgBox("Are You Sure Want To Remove", MsgBoxStyle.YesNo, "Remove")
                If Ans = vbNo Then
                    Exit Sub
                End If
                objQV = New ClsQuickExcess
                objQV.LicenseID = LicID
                objQV.PurchaseDate = vardate
                objQV.FunDelete()
                MsgBox(objQV.ErrorMsg)
                BindGrid()
                '[+][12/12/2019][Ajay Prajapati]
            End If
            '[-][12/12/2019][Ajay Prajapati]
        Catch ex As Exception
            Throw ex
        Finally
            dt = Nothing
            objQV = Nothing
        End Try
    End Sub
    Private Sub FrmManageVariance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpFrom.Value = DateSerial(Today.Year, Today.Month, 1)
        DtpTo.Value = DateSerial(Today.Year, Today.Month + 1, 0)
        BindGrid()
    End Sub
    Private Sub grd_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd.CellContentClick
        If e.ColumnIndex = 0 Then
            DeleteRecords(grd.Item("LicenseID", e.RowIndex).Value, CDate(grd.Item("varDate", e.RowIndex).Value))
        End If
    End Sub
    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        BindGrid()
    End Sub
End Class