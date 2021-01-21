Imports CWPlusBL
Public Class frmWhatIfParameters
    Dim ObjDt As DataTable
    Dim ClsMenuEng As CWPlusBL.Master.ClsMenuEngineering
    Dim objdash As ClsQuickExcess
    Dim vProfiyPerc As Double = 0
    Dim vPopularPerc As Double = 0
    Dim chkProfit As Double = False
    Dim chkPopular As Double = False
#Region "Functions"
    Public Sub New(ByVal dt As DataTable, ByVal pofitPec As Double, ByVal PopularPerc As Double)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'ComboBindingTemplate(cmbBrand, dt.Copy, "brand", "brandopeningid")
        ObjDt = New DataTable
        ObjDt = dt.Copy
        vProfiyPerc = pofitPec
        vPopularPerc = PopularPerc
    End Sub

    Public Function AssignCategory(ByVal dt As DataTable, ByVal vCurRow As Integer, ByVal ProfitCat As String, ByVal PopularCat As String) As ArrayList
        Try
            Dim arrOut As New ArrayList
            Dim SumQty As Double = 0
            Dim SumTotalCost As Double = 0
            Dim SumTotalRevenue As Double = 0
            Dim SumTotalProfit As Double = 0

            For index = 0 To dt.Rows.Count - 1
                SumQty += dt.Rows(index)("Quantity")
                SumTotalCost += dt.Rows(index)("TotalCost")
                SumTotalRevenue += dt.Rows(index)("TotalRevenue")
                SumTotalProfit += dt.Rows(index)("TotalProfit")
            Next

            Dim AvgItemProfit As Double = (SumTotalProfit / SumQty) * vProfiyPerc
            Dim PopPerc As Double = (100 / dt.Rows.Count) * vPopularPerc

            If Not dt.Rows(vCurRow)("TotalRevenue") = 0 And Not dt.Rows(vCurRow)("TotalProfit") = 0 Then
                dt.Rows(vCurRow)("profitperc") = Format((dt.Rows(vCurRow)("TotalProfit") / dt.Rows(vCurRow)("TotalRevenue")) * 100, "#.###")
            Else
                dt.Rows(vCurRow)("profitperc") = 0
            End If

            If Not dt.Rows(vCurRow)("Quantity") = 0 Then
                dt.Rows(vCurRow)("Popularityperc") = Format((CDbl(dt.Rows(vCurRow)("Quantity")) / SumQty) * 100, "#.###")
            Else
                dt.Rows(vCurRow)("Popularityperc") = 0
            End If

            If CDbl(dt.Rows(vCurRow)("itemprofit")) < AvgItemProfit Then
                dt.Rows(vCurRow)("Profitcategory") = "Low"
            Else
                dt.Rows(vCurRow)("Profitcategory") = "High"
            End If

            If CDbl(dt.Rows(vCurRow)("Popularityperc")) < PopPerc Then
                dt.Rows(vCurRow)("PopularCategory") = "Low"
            Else
                dt.Rows(vCurRow)("PopularCategory") = "High"
            End If

            If dt.Rows(vCurRow)("Profitcategory") = ProfitCat Then
                chkProfit = True
            End If

            If dt.Rows(vCurRow)("PopularCategory") = PopularCat Then
                chkPopular = True
            End If

            If dt.Rows(vCurRow)("Profitcategory") = ProfitCat And dt.Rows(vCurRow)("PopularCategory") = PopularCat Then
                arrOut.Add(True)
            Else
                arrOut.Add(False)
            End If
            arrOut.Add(dt)
            Return arrOut

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub DispMultiBarChart(ByVal dtData As DataTable, ByVal curChart As System.Windows.Forms.DataVisualization.Charting.Chart, ByVal curIndex As Integer)
        Try

            curChart.ChartAreas.Clear()
            curChart.Titles.Clear()
            curChart.Series.Clear()
            curChart.ChartAreas.Add("ChartArea1")
            curChart.ChartAreas("ChartArea1").AxisX.Interval = 1

            curChart.Series.Add("ProfitPerc")
            curChart.Series("ProfitPerc").Points.AddXY(dtData.Rows(curIndex).Item("brand"), dtData.Rows(curIndex).Item("ProfitPerc"))
            curChart.Series("ProfitPerc").ChartType = DataVisualization.Charting.SeriesChartType.Column
            curChart.Series("ProfitPerc").BorderWidth = 3
            curChart.Series("ProfitPerc").IsValueShownAsLabel = True

            curChart.Series.Add("PopularityPerc")
            curChart.Series("PopularityPerc").Points.AddXY(dtData.Rows(curIndex).Item("brand"), dtData.Rows(curIndex).Item("PopularityPerc"))
            curChart.Series("PopularityPerc").ChartType = DataVisualization.Charting.SeriesChartType.Column
            curChart.Series("PopularityPerc").BorderWidth = 3
            curChart.Series("PopularityPerc").IsValueShownAsLabel = True

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub GridValues(ByVal dtData As DataTable, ByVal CurIndex As Integer, ByVal grd As DataGridView, ByVal AddLabelValues As Boolean)
        Try

            grd.Rows.Clear()
            grd.Rows.Add("Purchase Rate", ObjDt.Rows(CurIndex)("purrate"), dtData.Rows(CurIndex)("purrate"))
            grd.Rows.Add("Quantity", ObjDt.Rows(CurIndex)("quantity"), dtData.Rows(CurIndex)("quantity"))
            grd.Rows.Add("Sale Rate", ObjDt.Rows(CurIndex)("SaleRate"), dtData.Rows(CurIndex)("SaleRate"))

            If AddLabelValues Then
                lbl.Text = cmbBrand.Text
                lblPurRate.Text = ObjDt.Rows(CurIndex)("purrate")
                lblQty.Text = ObjDt.Rows(CurIndex)("quantity")
                lblSaleRate.Text = ObjDt.Rows(CurIndex)("SaleRate")

                txtPurchase.Text = Math.Abs(ObjDt.Rows(CurIndex)("purrate") - dtData.Rows(CurIndex)("purrate"))
                txtQuantity.Text = Math.Abs(ObjDt.Rows(CurIndex)("quantity") - dtData.Rows(CurIndex)("quantity"))
                txtSellRate.Text = Math.Abs(ObjDt.Rows(CurIndex)("SaleRate") - dtData.Rows(CurIndex)("SaleRate"))

                If dtData.Rows(CurIndex)("purrate") >= ObjDt.Rows(CurIndex)("purrate") Then
                    cmbPurchase.SelectedIndex = 1
                Else
                    cmbPurchase.SelectedIndex = 2
                End If

                If dtData.Rows(CurIndex)("Quantity") >= ObjDt.Rows(CurIndex)("quantity") Then
                    cmbQuantity.SelectedIndex = 1
                Else
                    cmbQuantity.SelectedIndex = 2
                End If

                If dtData.Rows(CurIndex)("SaleRate") >= ObjDt.Rows(CurIndex)("SaleRate") Then
                    cmbSellRate.SelectedIndex = 1
                Else
                    cmbSellRate.SelectedIndex = 2
                End If
            End If

            grd.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function MakeType(ByVal ProfitCategory As String, ByVal PopularCategory As String) As String
        Try
            MakeType = ""
            If ProfitCategory = "High" And PopularCategory = "Low" Then
                Return "Challenge"
            ElseIf ProfitCategory = "High" And PopularCategory = "High" Then
                Return "Star"
            ElseIf ProfitCategory = "Low" And PopularCategory = "High" Then
                Return "Horse"
            ElseIf ProfitCategory = "Low" And PopularCategory = "Low" Then
                Return "Dog"
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Calc(ByVal CurIndex As Integer, ByVal purchase As Double, ByVal Quantity As Double, ByVal SaleRate As Double, ByVal ProfitCat As String, ByVal PopularCat As String)

        Try

            Dim RetDt As New DataTable
            RetDt = ObjDt.Copy

            If ProfitCat = "" Then
                RetDt.Rows(CurIndex)("Quantity") += Quantity
                RetDt.Rows(CurIndex)("PurRate") += purchase
                RetDt.Rows(CurIndex)("SaleRate") += SaleRate
                RetDt.Rows(CurIndex)("itemprofit") = RetDt.Rows(CurIndex)("SaleRate") - RetDt.Rows(CurIndex)("PurRate")
                RetDt.Rows(CurIndex)("TotalCost") = RetDt.Rows(CurIndex)("Quantity") * RetDt.Rows(CurIndex)("PurRate")
                RetDt.Rows(CurIndex)("TotalRevenue") = RetDt.Rows(CurIndex)("Quantity") * RetDt.Rows(CurIndex)("SaleRate")
                RetDt.Rows(CurIndex)("TotalProfit") = RetDt.Rows(CurIndex)("Quantity") * RetDt.Rows(CurIndex)("itemprofit")
                Dim arr As New ArrayList
                arr = AssignCategory(RetDt, CurIndex, ProfitCat, PopularCat)
                DispMultiBarChart(arr(1), chartExpected, CurIndex)
                GridValues(arr(1), CurIndex, grdExpected, 0)
                lbl.Text = cmbBrand.Text & vbNewLine & "        Type:" & MakeType(arr(1).rows(CurIndex)("Profitcategory"), arr(1).rows(CurIndex)("PopularCategory"))
            Else
                Dim chk As Boolean = True
                While chk
                    If RetDt.Rows(CurIndex)("Quantity") + Quantity > 0 And Not chkPopular Then
                        RetDt.Rows(CurIndex)("Quantity") += Quantity
                    End If
                    If RetDt.Rows(CurIndex)("PurRate") + purchase > 0 Then
                        RetDt.Rows(CurIndex)("PurRate") += purchase
                    End If
                    If RetDt.Rows(CurIndex)("SaleRate") + SaleRate > 0 And Not chkProfit Then
                        RetDt.Rows(CurIndex)("SaleRate") += SaleRate
                    End If

                    RetDt.Rows(CurIndex)("itemprofit") = RetDt.Rows(CurIndex)("SaleRate") - RetDt.Rows(CurIndex)("PurRate")
                    RetDt.Rows(CurIndex)("TotalCost") = RetDt.Rows(CurIndex)("Quantity") * RetDt.Rows(CurIndex)("PurRate")
                    RetDt.Rows(CurIndex)("TotalRevenue") = RetDt.Rows(CurIndex)("Quantity") * RetDt.Rows(CurIndex)("SaleRate")
                    RetDt.Rows(CurIndex)("TotalProfit") = RetDt.Rows(CurIndex)("Quantity") * RetDt.Rows(CurIndex)("itemprofit")
                    Dim arr As New ArrayList
                    arr = AssignCategory(RetDt, CurIndex, ProfitCat, PopularCat)
                    If arr(0) = True Then
                        DispMultiBarChart(arr(1), chartPredicted, CurIndex)
                        GridValues(arr(1), CurIndex, grdPredicted, 1)
                        chk = False
                    End If
                End While
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Apply()
        Try
            chkPopular = False
            chkProfit = False
            Dim dr() As DataRow
            dr = ObjDt.Select("brandid=" & cmbBrand.SelectedValue)
            Dim vCurRwIndex As Integer
            vCurRwIndex = ObjDt.Rows.IndexOf(dr(0))

            Dim MasterDt As New DataTable
            objdash = New ClsQuickExcess
            MasterDt = New DataTable
            MasterDt = objdash.FetchWhatIfParameters

            Select Case cmbToType.Text

                Case "Challenge"
                    If dr(0)("profitcategory") = "High" And dr(0)("popularcategory") = "Low" Then
                        MsgBox(cmbBrand.Text & " is already in Challenge", MsgBoxStyle.Information, "CWPlus")
                        Exit Sub
                    End If
                    Calc(vCurRwIndex, MasterDt.Rows(0)("purchaserate"), MasterDt.Rows(0)("quantity"), MasterDt.Rows(0)("salerate"), "High", "Low")
                Case "Star"
                    If dr(0)("profitcategory") = "High" And dr(0)("popularcategory") = "High" Then
                        MsgBox(cmbBrand.Text & " is already in Star", MsgBoxStyle.Information, "CWPlus")
                        Exit Sub
                    End If
                    Calc(vCurRwIndex, MasterDt.Rows(1)("purchaserate"), MasterDt.Rows(1)("quantity"), MasterDt.Rows(1)("salerate"), "High", "High")
                Case "Horse"
                    If dr(0)("profitcategory") = "Low" And dr(0)("popularcategory") = "High" Then
                        MsgBox(cmbBrand.Text & " is already in Horse", MsgBoxStyle.Information, "CWPlus")
                        Exit Sub
                    End If
                    Calc(vCurRwIndex, MasterDt.Rows(2)("purchaserate"), MasterDt.Rows(2)("quantity"), MasterDt.Rows(2)("salerate"), "Low", "High")
                Case "Dog"
                    If dr(0)("profitcategory") = "Low" And dr(0)("popularcategory") = "Low" Then
                        MsgBox(cmbBrand.Text & " is already in Dog", MsgBoxStyle.Information, "CWPlus")
                        Exit Sub
                    End If
                    Calc(vCurRwIndex, MasterDt.Rows(3)("purchaserate"), MasterDt.Rows(3)("quantity"), MasterDt.Rows(3)("salerate"), "Low", "Low")
                Case Else
                    MsgBox("Invalid Type selected", MsgBoxStyle.Information, "CWPlus")
            End Select

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ManageText(ByVal txt As TextBox, ByVal cmb As ComboBox) As Double
        ManageText = 0
        If Not txt.Text = 0 And Not txt.Text = "" Then
            If cmb.SelectedItem = "Positive" Then
                Return CDbl(txt.Text)
            ElseIf cmb.SelectedItem = "Negative" Then
                Return CDbl(txt.Text) * -1
            Else
                MsgBox("Please select Positive/Negative", MsgBoxStyle.Information, "CWPlus")
            End If
        End If
    End Function

    Public Sub FunExpected()
        Try
            If cmbBrand.SelectedValue = 0 Then
                MsgBox("Select brnad from list", MsgBoxStyle.Information, "CWPlus")
                Exit Sub
            End If
            Dim purchase As Double = 0
            Dim Qty As Double = 0
            Dim SaleRate As Double = 0

            purchase = ManageText(txtPurchase, cmbPurchase)
            Qty = ManageText(txtQuantity, cmbQuantity)
            SaleRate = ManageText(txtSellRate, cmbSellRate)

            Dim dr() As DataRow
            dr = ObjDt.Select("brandopeningid=" & cmbBrand.SelectedValue)
            Dim vCurRwIndex As Integer
            vCurRwIndex = ObjDt.Rows.IndexOf(dr(0))
            Calc(vCurRwIndex, purchase, Qty, SaleRate, "", "")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Events"
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmWhatIfParameters_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbFromType.SelectedIndex = 0
        cmbPurchase.SelectedIndex = 0
        cmbQuantity.SelectedIndex = 0
        cmbSellRate.SelectedIndex = 0
        cmbToType.SelectedIndex = 0
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        FunExpected()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not cmbBrand.SelectedIndex = 0 And Not cmbToType.SelectedIndex = 0 Then
            Apply()
        End If
    End Sub
#End Region

    Public Sub BindBrand(ByVal StrProfit As String, ByVal StrPopular As String)
        Dim dv As DataView

        dv = New DataView(ObjDt.Copy)
        dv.RowFilter = "profitcategory='" & StrProfit & "' and popularcategory='" & StrPopular & "'"
        If dv.Count > 0 Then
            ComboBindingTemplate(cmbBrand, dv.ToTable, "brand", "brandid")
        Else
            cmbBrand.DataSource = Nothing
            MsgBox("No brands", MsgBoxStyle.Information, "CWPlus")
        End If
    End Sub

    Private Sub cmbFromType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFromType.SelectedIndexChanged
        If cmbFromType.SelectedIndex = 0 Then
            Exit Sub
        End If
   
        Select Case cmbFromType.SelectedIndex
            Case 1
                BindBrand("High", "Low")
            Case 2
                BindBrand("High", "High")
            Case 3
                BindBrand("Low", "High")
            Case 4
                BindBrand("Low", "Low")
        End Select

    End Sub

   
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If lbl.ForeColor = Color.Green Then
            lbl.ForeColor = Color.Purple
        Else
            lbl.ForeColor = Color.Green
        End If
    End Sub
End Class