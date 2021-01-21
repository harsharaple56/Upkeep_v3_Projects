Imports System.Xml
Public Class FrmSaveDRR
    Dim ObjDRRSale As CWPlusBL.Accor.ClsDRRSale
    Dim ObjCls As CWPlusBL.Accor.ClsReports
    Dim ObjDt As DataTable
    Dim ObjPriDt As DataTable

    Private Sub BindRevenueCenters()
        Try
            grdDRRSale.DataSource = Nothing
            ObjPriDt = New DataTable
            ObjCls = New CWPlusBL.Accor.ClsReports
            ObjCls.BusinessDate = DtBusinessDate.Value
            ObjPriDt = ObjCls.FunFetchRevenueCentersNew()
            grdDRRSale.DataSource = ObjPriDt
            SetgrdDRRSale()
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

    Private Sub FrmSaveDRR_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BindRevenueCenters()
    End Sub

    Private Sub DtBusinessDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtBusinessDate.ValueChanged
        BindRevenueCenters()
    End Sub

    Private Sub SetgrdDRRSale()
        For colcnt = 0 To grdDRRSale.Columns.Count - 1
            grdDRRSale.Columns(colcnt).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        'grdDRRSale.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        grdDRRSale.AutoResizeColumns()
        grdDRRSale.Columns("RevenueCenterId").ReadOnly = True
        grdDRRSale.Columns("RevenueCenterName").ReadOnly = True
        grdDRRSale.Columns("ActualFood").ReadOnly = True
        grdDRRSale.Columns("ActualBeverage").ReadOnly = True
        grdDRRSale.Columns("ActualLiquor").ReadOnly = True
        grdDRRSale.Columns("ActualTobacco").ReadOnly = True
        grdDRRSale.Columns("Ord").Visible = False
    End Sub

    Private Function GenerateXML() As XmlDocument
        Dim xmldoc As New XmlDocument
        xmldoc.LoadXml("<Master><DRR></DRR></Master>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("DRRdetail")
        For index = 0 To grdDRRSale.RowCount - 1
            XmlElt = xmldoc.CreateElement("DRRdetail")
            XmlElt.SetAttribute("RevenueCenterId", grdDRRSale.Item("RevenueCenterId", index).Value)
            XmlElt.SetAttribute("RevenueCenterName", grdDRRSale.Item("RevenueCenterName", index).Value)
            XmlElt.SetAttribute("FoodSaleAmount", IIf(IsDBNull(grdDRRSale.Item("FoodSaleAmount", index).Value), 0, grdDRRSale.Item("FoodSaleAmount", index).Value))
            XmlElt.SetAttribute("ActualFood", IIf(IsDBNull(grdDRRSale.Item("ActualFood", index).Value), 0, grdDRRSale.Item("ActualFood", index).Value))
            XmlElt.SetAttribute("BeverageSaleAmount", IIf(IsDBNull(grdDRRSale.Item("BeverageSaleAmount", index).Value), 0, grdDRRSale.Item("BeverageSaleAmount", index).Value))
            XmlElt.SetAttribute("ActualBeverage", IIf(IsDBNull(grdDRRSale.Item("ActualBeverage", index).Value), 0, grdDRRSale.Item("ActualBeverage", index).Value))
            XmlElt.SetAttribute("LiquorSaleAmount", IIf(IsDBNull(grdDRRSale.Item("LiquorSaleAmount", index).Value), 0, grdDRRSale.Item("LiquorSaleAmount", index).Value))
            XmlElt.SetAttribute("ActualLiquor", IIf(IsDBNull(grdDRRSale.Item("ActualLiquor", index).Value), 0, grdDRRSale.Item("ActualLiquor", index).Value))
            XmlElt.SetAttribute("TobaccoSaleAmount", IIf(IsDBNull(grdDRRSale.Item("TobaccoSaleAmount", index).Value), 0, grdDRRSale.Item("TobaccoSaleAmount", index).Value))
            XmlElt.SetAttribute("ActualTobacco", IIf(IsDBNull(grdDRRSale.Item("ActualTobacco", index).Value), 0, grdDRRSale.Item("ActualTobacco", index).Value))
            XmlElt.SetAttribute("OtherSaleAmount", IIf(IsDBNull(grdDRRSale.Item("OtherSaleAmount", index).Value), 0, grdDRRSale.Item("OtherSaleAmount", index).Value))
            XmlElt.SetAttribute("Covers", IIf(IsDBNull(grdDRRSale.Item("Covers", index).Value), 0, grdDRRSale.Item("Covers", index).Value))
            XmlElt.SetAttribute("FoodDiscount", IIf(IsDBNull(grdDRRSale.Item("FoodDiscount", index).Value), 0, grdDRRSale.Item("FoodDiscount", index).Value))
            XmlElt.SetAttribute("BeverageDiscount", IIf(IsDBNull(grdDRRSale.Item("BeverageDiscount", index).Value), 0, grdDRRSale.Item("BeverageDiscount", index).Value))
            XmlElt.SetAttribute("TobaccoDiscount", IIf(IsDBNull(grdDRRSale.Item("TobaccoDiscount", index).Value), 0, grdDRRSale.Item("TobaccoDiscount", index).Value))
            XmlElt.SetAttribute("OtherDiscount", IIf(IsDBNull(grdDRRSale.Item("OtherDiscount", index).Value), 0, grdDRRSale.Item("OtherDiscount", index).Value))
            xmldoc.DocumentElement.Item("DRR").AppendChild(XmlElt)
        Next
        Return xmldoc
    End Function

    Public Function Save() As Boolean
        Save = False

        If (grdDRRSale.RowCount = 0) Then
            MsgBox("Nothing To Save", MsgBoxStyle.Critical, "DRR")
            Exit Function
        End If
        Try
            ObjCls = New CWPlusBL.Accor.ClsReports


            ObjCls.BusinessDate = DtBusinessDate.Value
            ObjCls.UserName = ""

            ObjCls.DRRXML = GenerateXML()

            Save = ObjCls.FunSaveDRR
            MsgBox(ObjCls.ErrorMsg)
            BindRevenueCenters()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjCls) Then
                ObjCls = Nothing
            End If
        End Try
    End Function

    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click
        Save()

    End Sub


    Private Sub imgClose_Click(sender As System.Object, e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub
End Class