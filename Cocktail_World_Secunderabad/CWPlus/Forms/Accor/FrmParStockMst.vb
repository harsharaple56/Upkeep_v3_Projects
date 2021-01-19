Imports System.Xml

Public Class FrmParStockMst

    Dim ObjBevRec As CWPlusBL.Accor.ClsBeverageReconComment
    Dim ObjParStock As CWPlusBL.Accor.ClsParStockMst
    Dim ObjPriDt As DataTable

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        'SET THEME TO CONTORLS 
        AddTheme(SplitContainer1.Panel1)
    End Sub

    Private Sub FrmSize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        MDI.chkLicenseName.Visible = False
        'BindCostCenters()
        BindEvalLicense()
    End Sub

    Private Sub BindEvalLicense()
        Dim ObjClsEval As CWPlusBL.Accor.ClsEvalLicense
        Try
            ObjPriDt = New DataTable
            ObjClsEval = New CWPlusBL.Accor.ClsEvalLicense
            ObjPriDt = ObjClsEval.FunFetch()
            ComboBindingTemplate(drpCostCenter, ObjPriDt, "LicenseName", "EvalLicenseID")
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjClsEval = Nothing
        End Try
    End Sub

    Private Sub BindCostCenters()
        Try
            ObjPriDt = New DataTable
            ObjBevRec = New CWPlusBL.Accor.ClsBeverageReconComment
            ObjPriDt = ObjBevRec.FunFetchCostCenter
            ComboBindingTemplate(drpCostCenter, ObjPriDt, "CostCenterName", "CostCenterId")
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjBevRec = Nothing
        End Try
    End Sub

    Private Sub BindParStock()
        Try
            ObjPriDt = New DataTable
            ObjParStock = New CWPlusBL.Accor.ClsParStockMst
            ObjParStock.CostCenterId = drpCostCenter.SelectedValue
            ObjParStock.ItemName = txtItemName.Text
            ObjPriDt = ObjParStock.FunFetch
            grdParStock.DataSource = ObjPriDt

            grdParStock.Columns("ArticleId").ReadOnly = True
            grdParStock.Columns("ArticleNo").ReadOnly = True
            grdParStock.Columns("ArticleName").ReadOnly = True
            'grdParStock.Columns("ReorderLevel").Visible = False
            grdParStock.AutoResizeColumns()
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjBevRec = Nothing
        End Try
    End Sub

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub

    Private Sub drpCostCenter_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles drpCostCenter.SelectedIndexChanged
        If Not TypeOf (drpCostCenter.SelectedValue) Is String Then
            Exit Sub
        End If
        BindParStock()
    End Sub

    Private Function GenerateXML() As XmlDocument
        Dim xmldoc As New XmlDocument
        xmldoc.LoadXml("<Report><ParStock></ParStock></Report>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("Item")
        For index = 0 To grdParStock.RowCount - 1
            XmlElt = xmldoc.CreateElement("Item")
            XmlElt.SetAttribute("ItemId", grdParStock.Item("ArticleId", index).Value)
            XmlElt.SetAttribute("ItemNo", grdParStock.Item("ArticleNo", index).Value)
            XmlElt.SetAttribute("ItemName", grdParStock.Item("ArticleName", index).Value)
            XmlElt.SetAttribute("BaseQty", grdParStock.Item("BaseQty", index).Value)
            XmlElt.SetAttribute("ReorderLevel", grdParStock.Item("ReorderLevel", index).Value)
            XmlElt.SetAttribute("OptimumLevel", grdParStock.Item("OptimumLevel", index).Value)
            xmldoc.DocumentElement.Item("ParStock").AppendChild(XmlElt)
        Next
        Return xmldoc
    End Function

    Private Sub imgSave_Click(sender As System.Object, e As System.EventArgs) Handles imgSave.Click
        Save()
    End Sub

    Private Sub Save()
        If grdParStock.RowCount = 0 Then
            MsgBox("Nothing to save", MsgBoxStyle.Information, "CWPlus")
            Exit Sub
        End If
        If Not GblBoolNew Then
            MsgBox("Access Denied", MsgBoxStyle.Information, "CWPlus")
            Exit Sub
        End If
        If Not GblBoolEdit Then
            MsgBox("Access Denied", MsgBoxStyle.Information, "CWPlus")
            Exit Sub
        End If
        Try
            ObjParStock = New CWPlusBL.Accor.ClsParStockMst
            ObjParStock.CostCenterId = drpCostCenter.SelectedValue
            ObjParStock.ItemXMLDoc = GenerateXML()
            ObjParStock.UserName = gblUserName
            ObjParStock.FunSave()
            MsgBox(ObjParStock.ErrorMsg)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjParStock) Then
                ObjParStock = Nothing
            End If
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        BindParStock()
    End Sub
End Class