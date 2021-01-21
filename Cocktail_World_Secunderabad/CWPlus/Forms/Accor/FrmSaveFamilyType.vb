Imports System.Xml
Public Class FrmSaveFamilyType
    Dim ObjDRRSale As CWPlusBL.Accor.ClsDRRSale
    Dim ObjCls As CWPlusBL.Accor.ClsReports
    Dim ObjDt As DataTable
    Dim ObjPriDt As DataTable

    Private Sub BindFamilyType()
        Try
            grdDRRSale.DataSource = Nothing
            ObjPriDt = New DataTable
            ObjCls = New CWPlusBL.Accor.ClsReports
            ObjPriDt = ObjCls.FunFetchFamilyType()
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
        BindFamilyType()
    End Sub

    Private Sub DtBusinessDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        BindFamilyType()
    End Sub

    Private Sub SetgrdDRRSale()
        For colcnt = 0 To grdDRRSale.Columns.Count - 1
            grdDRRSale.Columns(colcnt).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        'grdDRRSale.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        grdDRRSale.AutoResizeColumns()
        grdDRRSale.Columns("FamilyType").ReadOnly = True

    End Sub

    Private Function GenerateXML() As XmlDocument
        Dim xmldoc As New XmlDocument
        xmldoc.LoadXml("<Master><DRR></DRR></Master>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("Family")
        For index = 0 To grdDRRSale.RowCount - 1
            XmlElt = xmldoc.CreateElement("Family")
            XmlElt.SetAttribute("FamilyType", grdDRRSale.Item("FamilyType", index).Value)
            XmlElt.SetAttribute("FamDesc", IIf(IsDBNull(grdDRRSale.Item("FamDesc", index).Value), 0, grdDRRSale.Item("FamDesc", index).Value))
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



            ObjCls.UserName = ""

            ObjCls.DRRXML = GenerateXML()

            Save = ObjCls.FunSaveFamilyType
            MsgBox(ObjCls.ErrorMsg)
            BindFamilyType()
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