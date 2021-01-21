Imports System.Data
Imports CWPlusBL.Master
Imports System.Xml

Public Class FrmBillBook
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'SET THEME TO CONTORLS 

    End Sub

    Private Sub FrmBillBook_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        FunFetch()
    End Sub


    Private Sub ClrScreen()
        grdBillMaster.Rows.Clear()
        lblBillID.Text = 0
    End Sub
#Region "Procedure"

    Public Sub FunFetch()
        Dim ObjPriBill As New ClsBillMaster
        Dim ObjPriDt As New DataTable
        Try
            grdBillMaster.Rows.Clear()
            ObjPriBill.BillID = lblBillID.Text
            ObjPriDt = ObjPriBill.FunFetch()
            For rwctr = 0 To ObjPriDt.Rows.Count - 1
                grdBillMaster.Rows.Add()
                grdBillMaster("BillID", rwctr).Value = ObjPriDt.Rows(rwctr)("BillID")
                grdBillMaster("LicenseID", rwctr).Value = ObjPriDt.Rows(rwctr)("LicenseID")
                grdBillMaster("LicenseNo", rwctr).Value = ObjPriDt.Rows(rwctr)("LicenseNo")
                grdBillMaster("BillStNo", rwctr).Value = ObjPriDt.Rows(rwctr)("BillStNo")
                grdBillMaster("BillEndNo", rwctr).Value = ObjPriDt.Rows(rwctr)("BillEndNo")
                grdBillMaster("CurrentBillNo", rwctr).Value = ObjPriDt.Rows(rwctr)("CurrentBillNo")

            Next
            grdBillMaster.Columns("CurrentBillNo").Visible = False
            grdBillMaster.Columns("BillID").Visible = False
            grdBillMaster.Columns("LicenseID").Visible = False
            lblBillID.Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If IsNothing(ObjPriBill) = False Then
                ObjPriBill = Nothing
            End If
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
        End Try
    End Sub
    Public Function Save() As Boolean
        Save = False
        If lblBillID.Text = 0 Then
            If Not GblBoolNew Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Bill Book")
                Exit Function
            End If
        Else
            If Not GblBoolEdit Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Bill Book")
                Exit Function
            End If
        End If
        Dim ObjPriBill As New ClsBillMaster
        Dim ObjPriDt As New DataTable
        Try
            ObjPriBill.BillID = lblBillID.Text
            ObjPriBill.BillXml = GenerateXML()
            ObjPriBill.UserName = gblUserName
            Save = ObjPriBill.FunSave()
            MsgBox(ObjPriBill.ErrorMsg)
            FunFetch()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If IsNothing(ObjPriBill) = False Then
                ObjPriBill = Nothing
            End If
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
        End Try
    End Function
    Private Function GenerateXML() As XmlDocument

        Dim xmldoc As New XmlDocument

        xmldoc.LoadXml("<Master><Bill></Bill></Master>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("BrandDet")
        For index = 0 To grdBillMaster.RowCount - 1
            XmlElt = xmldoc.CreateElement("BillDetails")
            XmlElt.SetAttribute("LicenseID", grdBillMaster.Item("LicenseID", index).Value)
            XmlElt.SetAttribute("LicenseNo", grdBillMaster.Item("LicenseNo", index).Value)
            XmlElt.SetAttribute("BillStNo", grdBillMaster.Item("BillStNo", index).Value)
            XmlElt.SetAttribute("BillEndNo", grdBillMaster.Item("BillEndNo", index).Value)
            xmldoc.DocumentElement.Item("Bill").AppendChild(XmlElt)
        Next

        Return xmldoc
    End Function

#End Region

    Private Sub grdBillMaster_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdBillMaster.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        lblBillID.Text = grdBillMaster("BillID", e.RowIndex).Value

    End Sub

    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click
        Save()
    End Sub

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub imgClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub

    Private Sub grdBillMaster_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdBillMaster.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) _
                   Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Or (Microsoft.VisualBasic.Asc(e.KeyChar) = 46) Then
            e.Handled = False
        End If
    End Sub
    Private Sub grdBillMaster_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdBillMaster.CellValidating
        If e.ColumnIndex = 3 Or e.ColumnIndex = 4 Then
            If Not IsNumeric(e.FormattedValue) Then
                '  grdBillMaster.Rows(e.RowIndex).ErrorText = _
                '  "Phone must be a numeric value."
                MsgBox("Please insert Number only")
                e.Cancel = True
            End If
        End If
    End Sub
End Class