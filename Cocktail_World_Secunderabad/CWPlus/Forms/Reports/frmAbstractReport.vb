Public Class frmAbstractReport
    
   
    Private Sub btnCrystalReport_Click(sender As System.Object, e As System.EventArgs) Handles btnCrystalReport.Click
        Dim StrParam As String = ""
        StrParam = "'" & Format(dtFrom.Value, "dd-MMM-yyyy") & "','" & Format(dtTo.Value, "dd-MMM-yyyy") & "'," & MDI.cmbLicenseName.SelectedValue
        GenerateReport("abstract", "proc#" & "Spr_FetchAbstractReport" & "#" & StrParam & "#100")
    End Sub
End Class