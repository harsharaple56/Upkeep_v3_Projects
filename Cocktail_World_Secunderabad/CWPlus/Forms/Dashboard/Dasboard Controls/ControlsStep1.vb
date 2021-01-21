Imports CWPlusBL
Public Class ControlsStep1
    Dim objdash As ClsQuickExcess
    Dim dt As DataTable

    Public Sub init()
        objdash = New ClsQuickExcess
        objdash.LicenseID = gblLicenseID
        objdash.FromDate = dtFrom.Text
        objdash.ToDate = dtTo.Text
        objdash.CategoryID = 0
        objdash.SubCategoryID = 0
        dt = objdash.FetchControlsStep1

        chartControlData.Series.Clear()
        chartControlData.ChartAreas.Clear()
        chartControlData.ChartAreas.Add("chartArea")
        chartControlData.Series.Add("Sample")
        chartControlData.Series(0).Points.Clear()
        chartControlData.ChartAreas(0).CursorX.Interval = 0
        chartControlData.ChartAreas(0).CursorX.IsUserSelectionEnabled = True
        chartControlData.ChartAreas(0).CursorY.Interval = 0
        chartControlData.ChartAreas(0).CursorY.IsUserSelectionEnabled = True
        For rCtr = 0 To dt.Rows.Count - 1
            chartControlData.Series(0).Points.AddXY(dt.Rows(rCtr)("Category"), dt.Rows(rCtr)("Qty"))
        Next

    End Sub

    Private Sub ControlsStep1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        init()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        init()
    End Sub
End Class
