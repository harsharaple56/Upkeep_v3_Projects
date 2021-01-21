Imports CWPlusBL

Public Class Dashlet1

#Region "Variables"
    Dim objDash As ClsQuickExcess
    Dim dt As DataTable
#End Region

    Public Function TotalBrandCount() As Integer
        Dim objMAster As New CWPlusBL.Master.ClsBrandHeadDet
        Return objMAster.FunFetch().Rows.Count - 1
    End Function

    Public Sub FillTile2()
        objDash = New ClsQuickExcess
        objDash.TopBrands = topBrands.Value
        objDash.BrandOption = cmbBrandOptions.Text
        dt = objDash.FetchTopBrands
        chtTopBrands.Series.Clear()
        chtTopBrands.ChartAreas.Clear()
        chtTopBrands.ChartAreas.Add("chartArea")
        chtTopBrands.Series.Add("Sample")
        chtTopBrands.Series(0).Points.Clear()
        chtTopBrands.ChartAreas(0).CursorX.Interval = 0
        chtTopBrands.ChartAreas(0).CursorX.IsUserSelectionEnabled = True
        chtTopBrands.ChartAreas(0).CursorY.Interval = 0
        chtTopBrands.ChartAreas(0).CursorY.IsUserSelectionEnabled = True
        For rCtr = 0 To dt.Rows.Count - 1
            chtTopBrands.Series(0).Points.AddXY(dt.Rows(rCtr)("BrandDesc"), dt.Rows(rCtr)("Sale Amount"))
        Next
    End Sub

    Private Sub Dashlet1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        topBrands.Maximum = IIf(TotalBrandCount() < 0, 0, TotalBrandCount)
        If topBrands.Maximum > 5 Then topBrands.Minimum = 5
        cmbBrandOptions.SelectedIndex = 1 'THIS AUTOMATICALLY CALLS FOR FillTile2()
    End Sub

    Private Sub topBrands_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles topBrands.ValueChanged, cmbBrandOptions.SelectionChangeCommitted
        FillTile2()
    End Sub

End Class
