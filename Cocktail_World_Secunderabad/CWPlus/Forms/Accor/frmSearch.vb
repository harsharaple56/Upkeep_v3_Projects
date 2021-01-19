Imports System.Xml
Imports CWPlusBL.Accor

Public Class frmSearch
    Dim ObjCls As ClsReports
    Dim ObjPriDs As DataSet
    Dim ObjPriDt As DataTable
    Dim xmldoc, xmldocrevcenter As XmlDocument

    Public gblArrDiscountType, gblArrRevenueCenter As New ArrayList

    Private Sub BindRevenueCenters()
        Try
            ObjPriDt = New DataTable
            ObjCls = New ClsReports
            ObjPriDt = ObjCls.FunFetchRevenueCenters()

            With chklstRevenueCenter
                .DataSource = ObjPriDt
                .DisplayMember = "revenuecentername"
                .ValueMember = "revenuecenterid"
            End With
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

    Private Sub BindDiscountTypes()
        Try
            ObjPriDt = New DataTable
            ObjCls = New ClsReports
            ObjPriDt = ObjCls.FunFetchDiscountTypes

            With chklstDiscountMst
                .DataSource = ObjPriDt
                .DisplayMember = "discname"
                .ValueMember = "discid"
            End With
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

    Sub fetchdata()
        Try
            xmldoc = New XmlDocument
            gblArrDiscountType.Clear()
            FetchDiscountListChecked(chklstDiscountMst)

            xmldoc.LoadXml("<Report><EvalPack></EvalPack></Report>")
            Dim XmlElt As XmlElement = xmldoc.CreateElement("Discount")


            If gblArrDiscountType.Count > 0 Then
                For cntr = 0 To gblArrDiscountType.Count - 1
                    XmlElt = xmldoc.CreateElement("Discount")
                    XmlElt.SetAttribute("discounttype", gblArrDiscountType.Item(cntr))
                    xmldoc.DocumentElement.Item("EvalPack").AppendChild(XmlElt)
                Next
            End If



            xmldocrevcenter = New XmlDocument
            gblArrRevenueCenter.Clear()
            FetchRevenueCenterChecked(chklstRevenueCenter)

            xmldocrevcenter.LoadXml("<Report><EvalPack></EvalPack></Report>")
            XmlElt = xmldocrevcenter.CreateElement("Revenuecenter")


            If gblArrRevenueCenter.Count > 0 Then
                For cntr = 0 To gblArrRevenueCenter.Count - 1
                    XmlElt = xmldocrevcenter.CreateElement("Revenuecenter")
                    XmlElt.SetAttribute("id", gblArrRevenueCenter.Item(cntr))
                    xmldocrevcenter.DocumentElement.Item("EvalPack").AppendChild(XmlElt)
                Next
            End If

            ObjPriDs = New DataSet
            ObjCls = New ClsReports
            ObjCls.Fromdate = dtFrom.Value
            ObjCls.ToDate = dtTo.Value
            ObjCls.OfficerBillNo = txtCheckNo.Text
            ObjPriDs = ObjCls.FunFetchSearch(xmldocrevcenter, xmldoc)
            grdSearch.DataSource = Nothing
            grdSearch.DataSource = ObjPriDs.Tables(0)
            grdVoid.DataSource = Nothing
            grdVoid.DataSource = ObjPriDs.Tables(1)

            If gblArrDiscountType.Count > 0 Then
                Dim vTotalRate As Double = 0
                For index = 0 To grdSearch.RowCount - 1
                    vTotalRate += grdSearch("Rate", index).Value
                Next
                lblTotalQuantity.Text = "Total rate: " & vTotalRate
            Else
                lblTotalQuantity.Text = ""
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub frmSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BindRevenueCenters()
        BindDiscountTypes()
    End Sub

    Private Sub btnMore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMore.Click
        fetchdata()
    End Sub


    Private Function FetchDiscountListChecked(ByVal chkBox As CheckedListBox) As Boolean
        gblArrDiscountType.Clear()
        FetchDiscountListChecked = False

        If chkBox.CheckedItems.Count > 0 Then
            gblArrDiscountType.Clear()
            For chkCtr = 0 To chkBox.CheckedItems.Count - 1
                If Not DirectCast(chkBox.CheckedItems(chkCtr), System.Data.DataRowView).Row.ItemArray(1) = "" Then
                    gblArrDiscountType.Add(DirectCast(chkBox.CheckedItems(chkCtr), System.Data.DataRowView).Row.ItemArray(1))
                End If
                'gblArrDiscountType.Add(MDI.chkLicenseName.CheckedItems(chkCtr))
            Next


        End If
        Return True

    End Function

    Private Function FetchRevenueCenterChecked(ByVal chkBox As CheckedListBox) As Boolean
        gblArrRevenueCenter.Clear()
        FetchRevenueCenterChecked = False

        If chkBox.CheckedItems.Count > 0 Then
            gblArrRevenueCenter.Clear()
            For chkCtr = 0 To chkBox.CheckedItems.Count - 1
                If Not DirectCast(chkBox.CheckedItems(chkCtr), System.Data.DataRowView).Row.ItemArray(0) = 0 Then
                    gblArrRevenueCenter.Add(DirectCast(chkBox.CheckedItems(chkCtr), System.Data.DataRowView).Row.ItemArray(0))
                End If
                'gblArrDiscountType.Add(MDI.chkLicenseName.CheckedItems(chkCtr))
            Next


        End If
        Return True

    End Function

    
End Class