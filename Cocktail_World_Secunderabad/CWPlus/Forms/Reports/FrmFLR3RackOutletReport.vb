Public Class FrmFLR3RackOutletReport

    Private Sub btnok_Click(sender As System.Object, e As System.EventArgs) Handles btnok.Click
        FetchReport()
    End Sub

    Private Sub FetchReport()
        Dim ObjCls As New CWPlusBL.Master.RackOutletReports
        Dim ObjDt As New DataTable
        Try
            ObjDt = New DataTable
            ObjCls.ReportDate = dtpCocktailReport.Value
            ObjCls.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjCls.AllCheck = chkAll.Checked
            ObjCls.TimeOut = IIf(Trim(txtTimeOut.Text) = "", 30, txtTimeOut.Text)
            ObjDt = ObjCls.FunFetchFlr3ReportForRackOutlet()
            grdFLR3.DataSource = ObjDt
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(ObjCls) = False Then
                ObjCls = Nothing
            End If
            If IsNothing(ObjDt) = False Then
                ObjDt = Nothing
            End If
        End Try
    End Sub

    Private Sub btnCrystalReport_Click(sender As System.Object, e As System.EventArgs) Handles btnCrystalReport.Click
        Dim StrParam As String = ""
        StrParam = "'" & Format(dtpCocktailReport.Value, "dd-MMM-yyyy") & "'," & MDI.cmbLicenseName.SelectedValue & "," & chkAll.Checked
        GenerateReport("FLR3", "proc#" & "Spr_FetchFlr3ReportForRackOutlet" & "#" & StrParam & ",0,''" & vbCrLf & "FLR3Sub", txtTimeOut.Text)
    End Sub
  
End Class