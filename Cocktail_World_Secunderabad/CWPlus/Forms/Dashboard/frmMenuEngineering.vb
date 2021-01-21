Imports CWPlusBL
Public Class frmMenuEngineering
    Dim ClsMenuEng As CWPlusBL.Master.ClsMenuEngineering

#Region "Variables"
    Dim ObjDtMain, ObjDt As DataTable
    Dim objdash As ClsQuickExcess
    Dim IntChallenge, IntStar, IntDog, IntHorse As Integer
#End Region

#Region "Procedures"
    Public Function FetchMethodData(ByVal MethodID As Integer) As DataTable
        Try
            ClsMenuEng = New CWPlusBL.Master.ClsMenuEngineering
            ClsMenuEng.MethodID = MethodID
            Return ClsMenuEng.FunFetch

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            'If Not IsNothing(ObjDtMain) Then
            '    ObjDtMain = Nothing
            'End If
            If Not IsNothing(ClsMenuEng) Then
                ClsMenuEng = Nothing
            End If
        End Try

    End Function

    Public Sub BindMethod()
        ObjDt = New DataTable
        ObjDt = FetchMethodData(0)
        cmbMethod.DataSource = Nothing

        If Not ObjDt.Rows.Count > 0 Then
            MsgBox("Methods not saved,Save a method", MsgBoxStyle.Information, "Menu Engineering")
            Exit Sub
        End If


        With cmbMethod
            .DisplayMember = "methodname"
            .ValueMember = "methodid"
            .DataSource = ObjDt
        End With
        cmbMethod.SelectedValue = ObjDt.Rows(0)("defaultmethod")
    End Sub

    Public Sub FetchProfitPopularData()
        objdash = New ClsQuickExcess
        Try
            ObjDtMain = New DataTable
            ObjDtMain = objdash.FetchMenuEngineering(tbProfit.Value, tbPopular.Value, cmbRate.SelectedIndex)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub Challenge()
        SortData("High", "Low", chartChallenge, grdChallengeData, IntChallenge, "Profitperc  desc")
    End Sub

    Public Sub Star()
        SortData("High", "High", chartStar, grdStar, IntStar, "Popularityperc desc")
    End Sub

    Public Sub Dog()
        SortData("Low", "Low", chartDog, grdDog, IntDog, "ProfitPerc asc")
    End Sub

    Public Sub Horse()
        SortData("Low", "High", chartHorse, grdHorse, IntHorse, "PopularityPerc desc")
    End Sub

    Public Sub SortData(ByVal Profit As String, ByVal Popular As String, ByVal curChart As System.Windows.Forms.DataVisualization.Charting.Chart, ByVal grd As DataGridView, ByVal vCount As Integer, ByVal vSort As String)
        Dim dvProfit As DataView
        'dvProfit = New DataView(ObjDtMain, "", "Profit " & ProfitSort & "," & " Popular " & PopularSort, DataViewRowState.CurrentRows)
        dvProfit = New DataView(ObjDtMain)

        dvProfit.RowFilter = "ProfitCategory='" & Profit & "' and PopularCategory='" & Popular & "'"
        If dvProfit.Count > 0 Then
            dvProfit.Sort = vSort
            grd.DataSource = Nothing
            grd.DataSource = dvProfit.ToTable
            MakeIDColumnsHide(grd)
            DispMultiBarChart(dvProfit.ToTable, curChart, vCount)
        Else
            grd.DataSource = Nothing
            curChart.ChartAreas.Clear()
            curChart.Titles.Clear()
            curChart.Series.Clear()
        End If

    End Sub

    Public Sub DispMultiBarChart(ByVal profitDt As DataTable, ByVal curChart As System.Windows.Forms.DataVisualization.Charting.Chart, ByVal vCount As Integer)
        Try

            curChart.ChartAreas.Clear()
            curChart.Titles.Clear()
            curChart.Series.Clear()
            curChart.ChartAreas.Add("ChartArea1")

            curChart.ChartAreas("ChartArea1").AxisX.Interval = 1

            Dim XValue As String = String.Empty

            Dim StrColName As String = ""

            For clctr = 0 To 1
                If clctr = 0 Then
                    StrColName = "ProfitPerc"
                Else
                    StrColName = "PopularityPerc"
                End If

                curChart.Series.Add(StrColName)

                If profitDt.Rows.Count < vCount Then vCount = profitDt.Rows.Count

                For i As Integer = 0 To vCount - 1

                    Dim YValue As String = String.Empty
                    Dim YValue1 As String = String.Empty
                    Dim YValue2 As String = String.Empty

                    XValue = profitDt.Rows(i).Item("brand")
                    YValue = profitDt.Rows(i).Item(StrColName)
                    curChart.Series(StrColName).Points.AddXY(XValue, YValue)

                Next
                curChart.Series(StrColName).ChartType = DataVisualization.Charting.SeriesChartType.Column
                curChart.Series(StrColName).BorderWidth = 3
                curChart.Series(StrColName).IsValueShownAsLabel = True
            Next


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ApplyFun()
        FetchProfitPopularData()
        Challenge()
        Star()
        Dog()
        Horse()
    End Sub

#End Region

#Region "Events"
    Private Sub frmMenuEngineering_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbRate.SelectedIndex = 0
        btnModify.Text = "Add/Modify" & vbNewLine & "Method"
        btnWhatIf.Text = "What If?"
        BindMethod()
        ApplyFun()
    End Sub

    Private Sub cmbMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMethod.SelectedIndexChanged
        If Not TypeOf (cmbMethod.SelectedValue) Is Integer Then
            Exit Sub
        End If
        ObjDt = New DataTable
        ObjDt = FetchMethodData(cmbMethod.SelectedValue)
        If ObjDt.Rows.Count > 0 Then
            IntChallenge = ObjDt.Rows(0)("challenge")
            IntStar = ObjDt.Rows(0)("star")
            IntDog = ObjDt.Rows(0)("dog")
            IntHorse = ObjDt.Rows(0)("horse")
           ApplyFun
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModify.Click
        Dim objMenu As New frmMenuEngineeringMaster
        objMenu.ShowDialog()
    End Sub

    Private Sub tbProfit_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbProfit.Scroll, tbPopular.Scroll, cmbRate.SelectedValueChanged
        ApplyFun()
    End Sub

    Private Sub btnWhatIf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWhatIf.Click
        FetchProfitPopularData()

        Dim ObjWhatIf As New frmWhatIfParameters(ObjDtMain, tbProfit.Value / 100, tbPopular.Value / 100)
        If Not IsNothing(ObjDtMain) Then
            ObjWhatIf.ShowDialog()
        Else
        MsgBox("No data", MsgBoxStyle.Information, "CW Plus")
        End If
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If lblChallenge.ForeColor = Color.Green Then
            lblChallenge.ForeColor = Color.Purple
            lblStar.ForeColor = Color.Purple
            lblDog.ForeColor = Color.Purple
            lblHorse.ForeColor = Color.Purple
        Else
            lblChallenge.ForeColor = Color.Green
            lblStar.ForeColor = Color.Green
            lblDog.ForeColor = Color.Green
            lblHorse.ForeColor = Color.Green
        End If
    End Sub
#End Region
    
   
    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
      
        ExportExcelTemplate(ObjDtMain)
    End Sub
End Class