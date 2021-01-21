Imports System.Xml
Public Class FrmCostReportInput
    Dim ObjDRRSale As CWPlusBL.Accor.ClsDRRSale
    Dim ObjCls As CWPlusBL.Accor.ClsCostReportInput
    Dim ObjDt As DataTable
    Dim ObjPriDt As DataTable

    Private Sub BindRevenueCenters()
        Try
            grdDRRSale.DataSource = Nothing
            ObjPriDt = New DataTable
            ObjCls = New CWPlusBL.Accor.ClsCostReportInput
            ObjCls.Businessdate = DtBusinessDate.Value
            ObjPriDt = ObjCls.FunFetch()
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



    Private Sub SetgrdDRRSale()
        For colcnt = 0 To grdDRRSale.Columns.Count - 1
            grdDRRSale.Columns(colcnt).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        'grdDRRSale.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        grdDRRSale.AutoResizeColumns()
        grdDRRSale.Columns("RevenueCenterId").ReadOnly = True
        grdDRRSale.Columns("RevenueCenterName").ReadOnly = True

    End Sub

    Private Function GenerateXML() As XmlDocument
        Dim xmldoc As New XmlDocument
        xmldoc.LoadXml("<Master><DRR></DRR></Master>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("CRI")
        For index = 0 To grdDRRSale.RowCount - 1
            XmlElt = xmldoc.CreateElement("CRI")

            XmlElt.SetAttribute("RevenueCenterId", grdDRRSale.Item("RevenueCenterId", index).Value)
            XmlElt.SetAttribute("RevenueCenterName", grdDRRSale.Item("RevenueCenterName", index).Value)
            XmlElt.SetAttribute("Covers", IIf(IsDBNull(grdDRRSale.Item("Covers", index).Value), 0, grdDRRSale.Item("Covers", index).Value))
            XmlElt.SetAttribute("FoodTransferAmount", IIf(IsDBNull(grdDRRSale.Item("FoodTransferAmount", index).Value), 0, grdDRRSale.Item("FoodTransferAmount", index).Value))
            XmlElt.SetAttribute("BevTransferAmount", IIf(IsDBNull(grdDRRSale.Item("BevTransferAmount", index).Value), 0, grdDRRSale.Item("BevTransferAmount", index).Value))
            XmlElt.SetAttribute("BeverageToFood", IIf(IsDBNull(grdDRRSale.Item("BeverageToFood", index).Value), 0, grdDRRSale.Item("BeverageToFood", index).Value))
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
            ObjCls = New CWPlusBL.Accor.ClsCostReportInput



            ObjCls.UserName = ""
            ObjCls.Businessdate = DtBusinessDate.Value
            ObjCls.CRIXML = GenerateXML()

            Save = ObjCls.FunSave
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


    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub
End Class