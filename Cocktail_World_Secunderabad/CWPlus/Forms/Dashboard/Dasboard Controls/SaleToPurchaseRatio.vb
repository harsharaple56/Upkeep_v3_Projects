Imports CWPlusBL
Public Class SaleToPurchaseRatio
    Dim objdash As ClsQuickExcess
    Dim dt As DataTable

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        grdData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        cmbType.SelectedIndex = 0
    End Sub
    Public Function FetchData(Optional ByVal IsExport As Boolean = False) As DataTable
        objdash = New ClsQuickExcess
        objdash.LicenseID = gblLicenseID
        objdash.ControlHeadID = cmbPeriod.SelectedValue
        objdash.CategoryID = catgID
        objdash.SubCategoryID = subCatgId
        objdash.IsExport = IsExport
        Return objdash.FetchSaleToPurchaseRatio()
    End Function
    Public Sub init()
       
        dt = New DataTable
        dt = FetchData()
        If IsNothing(dt) Then Exit Sub
        grdData.DataSource = dt
        MakeIDColumnsHide(grdData)
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
            chartControlData.Series(0).Points.AddXY(dt.Rows(rCtr)(1), dt.Rows(rCtr)("SalePerc"))
            chartControlData.Series(0).Points(rCtr).Tag = dt.Rows(rCtr)(0)
        Next

        chartControlData.ChartAreas(0).CursorX.IsUserEnabled = False
        chartControlData.ChartAreas(0).CursorX.IsUserSelectionEnabled = False
        chartControlData.ChartAreas(0).CursorY.IsUserEnabled = False
        chartControlData.ChartAreas(0).CursorY.IsUserSelectionEnabled = False

    End Sub
    Private Sub BindControlsPeriod()
        Try
            objdash = New ClsQuickExcess
            objdash.LicenseID = gblLicenseID
            dt = objDash.FunFetchControlsPeriod()
            With cmbPeriod
                .DisplayMember = "Period"
                .ValueMember = "ValueField"
                .DataSource = dt
            End With

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ControlsStep1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BindControlsPeriod()
        'init()
    End Sub

    Dim catgID As String = 0
    Dim subCatgId As String = 0

    Private Sub chartControlData_GetToolTipText(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs) Handles chartControlData.GetToolTipText
        If e.HitTestResult.ChartElementType = DataVisualization.Charting.ChartElementType.DataPoint Then
            Dim i As Integer = e.HitTestResult.PointIndex
            Dim dp As DataVisualization.Charting.DataPoint = e.HitTestResult.Series.Points(i)
            Select Case cmbType.SelectedIndex
                Case 0
                    catgID = dp.Tag
                    subCatgId = 0
                Case 1
                    subCatgId = dp.Tag
                Case Else

            End Select
        Else
            'catgID = 0
        End If
    End Sub

    Private Sub chartControlData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chartControlData.Click
        If cmbType.SelectedIndex = 2 Then Exit Sub
        cmbType.SelectedIndex += 1
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbType.SelectedIndexChanged
        If cmbType.SelectedIndex = 0 Then
            catgID = 0
            subCatgId = 0
        End If
        init()
    End Sub
    Private Sub cmbPeriod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPeriod.SelectedIndexChanged
        init()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        dt = New DataTable
        dt = FetchData(1)
        ExportExcelTemplate(dt)
    End Sub
End Class
