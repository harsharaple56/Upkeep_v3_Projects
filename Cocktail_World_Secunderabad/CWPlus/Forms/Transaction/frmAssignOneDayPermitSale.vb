Imports CWPlusBL.Master
Imports System.Xml
Public Class frmAssignOneDayPermitSale
    Dim VCurrentPermitNo As Integer
    Dim IsSave As Boolean = False
#Region "Functions"
    Public Sub FetchSaleList()
        Dim ObjSalerHead As New ClsSale
        Dim ObjPriDt As New DataTable
        Try
            grdSaleList.DataSource = Nothing
            grdSaleList.Columns.Clear()

            ObjSalerHead.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjSalerHead.FromDate = dtFromDate.Value
            ObjSalerHead.ToDate = dtToDate.Value
            ObjPriDt = ObjSalerHead.FunFetch()
            grdSaleList.DataSource = ObjPriDt
            grdSaleList.Columns("billid").Visible = False
            grdSaleList.Columns("licenseid").Visible = False
            grdSaleList.Columns("LicenseCode").Visible = False
            grdSaleList.Columns("Licensedesc").HeaderText = "License"
            grdSaleList.Columns("Licensedesc").Width = 150

            If chkAuto.Checked = True Then
                grdSaleList.Columns("PermitHolderNumber").ReadOnly = True
            Else
                grdSaleList.Columns("PermitHolderNumber").ReadOnly = False
            End If


        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(ObjSalerHead) = False Then
                ObjSalerHead = Nothing
            End If
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If

        End Try
        grdSaleList.Visible = True
    End Sub

    Function FetchOneDayPermitNumber() As DataTable
        Dim ObjOneDayPermit As New ClsOneDayPermitNumber
        ObjOneDayPermit.LicenseID = MDI.cmbLicenseName.SelectedValue
        Return ObjOneDayPermit.FunFetch()

    End Function

    Private Function GenerateXML() As XmlDocument

        Dim xmldoc As New XmlDocument

        xmldoc.LoadXml("<Trans><OneDayPermit></OneDayPermit></Trans>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("PermitNo")
        For index = 0 To grdSaleList.RowCount - 1
            If CBool(grdSaleList("IsOneDayPermit", index).Value) Then
                XmlElt = xmldoc.CreateElement("PermitNo")
                XmlElt.SetAttribute("BillId", grdSaleList.Item("BillId", index).Value)
                XmlElt.SetAttribute("PermitHolderName", grdSaleList.Item("PermitHolderName", index).Value)
                XmlElt.SetAttribute("BillDate", Format(CDate(grdSaleList.Item("BillDate", index).Value), "dd-MMM-yyyy"))
                XmlElt.SetAttribute("PermitHolderNumber", grdSaleList.Item("PermitHolderNumber", index).Value)
                xmldoc.DocumentElement.Item("OneDayPermit").AppendChild(XmlElt)
            End If
        Next
        Return xmldoc
    End Function

    Sub Save()
        Try
            If Not grdSaleList.RowCount > 0 Then
                MsgBox("No Data", MsgBoxStyle.Information)
                Exit Sub
            End If
            If Not IsSave And chkAuto.Checked = True Then
                MsgBox("Permit Number not assigned to all", MsgBoxStyle.Information)
                Exit Sub
            End If
            Dim ObjSalerHead As New ClsSale
            ObjSalerHead.BrandSaleXML = GenerateXML()
            ObjSalerHead.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjSalerHead.Auto = chkAuto.Checked
            ObjSalerHead.FunUpdateOneDayPermit(VCurrentPermitNo)
            MsgBox(ObjSalerHead.ErrorMsg, MsgBoxStyle.Information)
        Catch ex As Exception

        End Try
    End Sub
#End Region
#Region "Events"
    Private Sub frmAssignOneDayPermitSale_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FetchSaleList()
        btnApply.Enabled = False
    End Sub

    Private Sub dtFromDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFromDate.ValueChanged, dtToDate.ValueChanged
        FetchSaleList()
    End Sub

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub
#End Region

    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click
        Save()
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        If Not grdSaleList.RowCount > 0 Then
            MsgBox("No Data", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim vPermitNo As Integer = 0
        Dim dtPermitNo As DataTable = FetchOneDayPermitNumber()
        If Not dtPermitNo.Rows.Count > 0 Then
            MsgBox("One Day Permit Number not exists", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim vIndex As Integer = 0

        'If CInt(dtPermitNo.Rows(0)("currentpermitno")) = 0 Then
        '    vPermitNo = CInt(dtPermitNo.Rows(0)("frompermitno"))
        'Else

        '    For index = 0 To dtPermitNo.Rows.Count - 1
        '        If CInt(dtPermitNo.Rows(index)("ToPermitNo")) <> CInt(dtPermitNo.Rows(index)("currentpermitno")) Then
        '            vPermitNo = CInt(dtPermitNo.Rows(index)("currentpermitno"))
        '            vIndex = index
        '            Exit For
        '        End If
        '    Next
        'End If


        For index = 0 To dtPermitNo.Rows.Count - 1
            If CInt(dtPermitNo.Rows(index)("ToPermitNo")) <> CInt(dtPermitNo.Rows(index)("currentpermitno")) Then
                If CInt(dtPermitNo.Rows(index)("currentpermitno")) = 0 Then
                    vPermitNo = CInt(dtPermitNo.Rows(index)("frompermitno"))
                Else
                    vPermitNo = CInt(dtPermitNo.Rows(index)("currentpermitno"))
                End If
                vIndex = index
                Exit For
            End If
        Next



        For index = 0 To grdSaleList.RowCount - 1
            If CBool(grdSaleList("IsOneDayPermit", index).Value) Then
                If vPermitNo >= dtPermitNo.Rows(vIndex)("frompermitno") And vPermitNo <= dtPermitNo.Rows(vIndex)("topermitno") Then
                    grdSaleList("PermitHolderNumber", index).Value = vPermitNo
                    grdSaleList("PermitHolderName", index).Value = "One Day Permit"
                    vPermitNo += 1
                Else
                    vIndex += 1
                    If dtPermitNo.Rows.Count <= vIndex Then
                        MsgBox("One Day Permit Number not exists", MsgBoxStyle.Information)
                        Exit Sub
                    Else
                        vPermitNo = CInt(dtPermitNo.Rows(vIndex)("frompermitno"))
                        grdSaleList("PermitHolderNumber", index).Value = vPermitNo
                        grdSaleList("PermitHolderName", index).Value = "One Day Permit"
                        vPermitNo += 1
                    End If
                End If
            End If
        Next
        IsSave = True
        VCurrentPermitNo = vPermitNo
    End Sub

    'Private Sub grdSaleList_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSaleList.CellValueChanged
    '    If grdSaleList.Columns(e.ColumnIndex).Name.ToLower = "isonedaypermit" Then
    '        If Not CBool(grdSaleList("IsOneDayPermit", e.RowIndex).Value) Then
    '            grdSaleList.Rows(e.RowIndex).ReadOnly = True
    '        Else
    '            grdSaleList.Rows(e.RowIndex).ReadOnly = False
    '        End If
    '    End If

    'End Sub

    Private Sub chkAuto_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAuto.CheckedChanged
        If chkAuto.Checked = True Then
            btnApply.Enabled = True
            grdSaleList.Columns("PermitHolderNumber").ReadOnly = True
        Else
            btnApply.Enabled = False
            grdSaleList.Columns("PermitHolderNumber").ReadOnly = False
        End If
    End Sub
End Class