Public Class FrmFLR4RackOutletReport

    Private Sub btnok_Click(sender As System.Object, e As System.EventArgs) Handles btnok.Click
        BindGrid()
    End Sub

    Sub BindGrid()
        Dim objRack As New CWPlusBL.Master.RackOutletReports
        Dim ObjDta As New DataTable
        If Not MDI.cmbLicenseName.SelectedValue > 0 Then
            MsgBox("Select a license", MsgBoxStyle.Information, "CWPlus")
            Exit Sub
        End If
        Try
            objRack.FromDate = dtchataiFromDate.Value
            objRack.ToDate = dtchataiToDate.Value
            objRack.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjDta = objRack.FunFetchFlr4ForRackOutlet()
            grdData.DataSource = ObjDta
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(objRack) = False Then
                objRack = Nothing
            End If
            If IsNothing(ObjDta) = False Then
                ObjDta = Nothing
            End If
        End Try
    End Sub

    Private Sub btnCrystalReport_Click(sender As Object, e As System.EventArgs) Handles btnCrystalReport.Click
        Dim StrParam As String = ""
        StrParam = "'" & Format(dtchataiFromDate.Value, "dd-MMM-yyyy") & "','" & Format(dtchataiToDate.Value, "dd-MMM-yyyy") & "'," & MDI.cmbLicenseName.SelectedValue
        GenerateReport("FLIVCatg", "proc#" & "Spr_FetchFlr4ForRackOutlet" & "#" & StrParam & ",0,''", txtTimeOut.Text)
    End Sub
End Class