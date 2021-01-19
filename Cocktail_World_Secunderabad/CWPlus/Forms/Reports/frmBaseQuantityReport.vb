Public Class frmBaseQuantityReport
    Dim objCocktail As New CWPlusBL.Master.ClsCocktailReports
    Dim ObjDt As DataTable
#Region "Procedures"
    Public Sub BindGrid()
        ObjDt = New DataTable
        objCocktail = New CWPlusBL.Master.ClsCocktailReports
        objCocktail.LicenseID = MDI.cmbLicenseName.SelectedValue
        objCocktail.ReportDate = dtDate.Value
        ObjDt = objCocktail.FunFetchBaseQtyReport
        grdBaseQtyReport.DataSource = Nothing
        grdBaseQtyReport.DataSource = ObjDt
        MakeIDColumnsHide(grdBaseQtyReport)
    End Sub
#End Region
    Private Sub btnok_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        BindGrid()
    End Sub

    Private Sub btnExport_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        ObjDt = New DataTable
        ObjDt = DirectCast(grdBaseQtyReport.DataSource, DataTable)
        ExportExcelTemplate(ObjDt)
    End Sub
    Dim arrReportName(0) As String
    Private Sub btnPdf_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPdf.Click


        arrReportName(0) = "Base Quenty Report"
        Dim SaveFile As New SaveFileDialog
        If SaveFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            If IO.File.Exists(SaveFile.FileName) Then
                IO.File.Delete(SaveFile.FileName)
            End If
            Dim ObjPdf As New CWUtility.ClsCocktailReportPDF
            ObjPdf.ExportToPdfv2(IO.Path.GetDirectoryName(SaveFile.FileName), IO.Path.GetFileName(SaveFile.FileName), arrReportName, grdBaseQtyReport)
            Dim dlgRes As DialogResult
            dlgRes = MessageBox.Show("Exported Successfully !" & vbCrLf & "Do you want to open the file ?", "CWPlus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dlgRes = Windows.Forms.DialogResult.Yes Then
                Process.Start(SaveFile.FileName & ".pdf")

            End If
        End If
    End Sub
    Public Sub SendReport()
        Dim SaveFile As String = Application.StartupPath & "\CW_Report.pdf"
        If IO.File.Exists(SaveFile) Then
            IO.File.Delete(SaveFile)
        End If
        Dim ObjPdf As New CWUtility.ClsCocktailReportPDF
        ObjPdf.ExportToPdfv2(IO.Path.GetDirectoryName(SaveFile), IO.Path.GetFileNameWithoutExtension(SaveFile), arrReportName, grdBaseQtyReport)
        frmSendReport.Show()
    End Sub

    Private Sub btnMailReport_Click(sender As System.Object, e As System.EventArgs) Handles btnMailReport.Click
        SendReport()
    End Sub
End Class