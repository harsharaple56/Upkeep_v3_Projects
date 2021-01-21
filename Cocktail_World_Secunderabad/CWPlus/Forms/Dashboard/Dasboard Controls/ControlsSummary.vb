Imports CWPlusBL

Public Class ControlsSummary

#Region "Variables"
    Dim objDash As ClsQuickExcess
    Dim dt As DataTable
#End Region

    Public Sub FillTile3()
        objDash = New ClsQuickExcess
        objDash.FromDate = dtFrom.Value
        objDash.ToDate = dtTo.Value
        objDash.LicenseID = gblLicenseID
        dt = objDash.FetchCosting()
        grdCosting.DataSource = dt
        MakeIDColumnsHide(grdCosting)
        grdCosting.GridTheme = ThemedDataGrid.MKDataGridView.GridThemes.Orange
    End Sub

    Private Sub ControlsSummary_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '####################################
        'FOR TILE=3

        dtFrom.Value = DateSerial(DatePart(DateInterval.Year, Date.Now), DatePart(DateInterval.Month, Date.Now), 1)
        dtTo.Value = DateSerial(DatePart(DateInterval.Year, Date.Now), DatePart(DateInterval.Month, Date.Now) + 1, 0)
   
        FillTile3()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        dt = New DataTable
        dt = DirectCast(grdCosting.DataSource, DataTable)
        ExportExcelTemplate(dt)
    End Sub

    Private Sub dtTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtTo.ValueChanged, dtFrom.ValueChanged
        FillTile3()
    End Sub
End Class
