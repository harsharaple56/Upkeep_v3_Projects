Imports System.Xml
Public Class frmMergePeriodMaster

    Dim ObjMergePeriod As CWPlusBL.Master.ClsMergePeriod
    Dim objDt As DataTable
    Dim vFrom As Integer = 0
    Dim vTo As Integer = 0

#Region "Procedures"
    Public Sub New()

        'This call is required by the designer.
        InitializeComponent()

        'SET THEME TO CONTROLS
        AddTheme(SplitContainer1.Panel1)
    End Sub

    Private Sub ClrScreen()
        vFrom = 0
        vTo = 0
        dtFrom.Value = DateTime.Now
        dtTo.Value = DateTime.Now
        lblID.Text = 0
        txtName.Clear()
        grdMergePeriod.DataSource = Nothing
    End Sub

    Public Sub BindGrid()
        Try
            ObjMergePeriod = New CWPlusBL.Master.ClsMergePeriod
            objDt = New DataTable

            If Not MDI.cmbLicenseName.SelectedValue > 0 Then
                MsgBox("Please Select License")
                Exit Sub
            End If
            ObjMergePeriod.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjMergePeriod.FromDate = dtFrom.Value
            ObjMergePeriod.ToDate = dtTo.Value
            objDt = ObjMergePeriod.FunFetch
            grdMergePeriod.DataSource = Nothing
            grdMergePeriod.DataSource = objDt
            grdMergePeriod.Columns("licenseid").Visible = False
            grdMergePeriod.Columns("controlheadid").Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(objDt) Then
                objDt = Nothing
            End If
            If Not IsNothing(ObjMergePeriod) Then
                ObjMergePeriod = Nothing
            End If
        End Try

    End Sub

    Private Function GenerateXML() As XmlDocument
        Dim xmldoc As New XmlDocument
        xmldoc.LoadXml("<Merge><Period></Period></Merge>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("MergePeriodDet")
        For index = vFrom To vTo
            XmlElt = xmldoc.CreateElement("MergePeriodDet")
            XmlElt.SetAttribute("ControlHeadID", grdMergePeriod.Item("ControlHeadID", index).Value)
            xmldoc.DocumentElement.Item("Period").AppendChild(XmlElt)
        Next
        Return xmldoc
    End Function

    Public Sub FindStartandEnd()

        For index = 0 To grdMergePeriod.RowCount - 1
            If CDbl(grdMergePeriod.Item(0, index).Value) Then
                vFrom = index
                Exit For
            End If
        Next


        For index = grdMergePeriod.RowCount - 1 To 0 Step -1
            If CDbl(grdMergePeriod.Item(0, index).Value) Then
                vTo = index
                Exit For
            End If
        Next

    End Sub

    Public Function Save() As Boolean
        Save = False
        If Not grdMergePeriod.Rows.Count > 0 Then
            MsgBox("No data to merge")
            Exit Function
        End If
        If MDI.cmbLicenseName.SelectedValue = 0 Then
            MsgBox("Please Select License")
            Exit Function
        End If


        If txtName.Text = "" Then
            MsgBox("Enter Name", MsgBoxStyle.Information, "Merge Period")
            Exit Function
        End If
        If Not GblBoolNew Then
            MsgBox("Access Denied", MsgBoxStyle.Information, "Merge Period")
            Exit Function
        End If
        Try
            FindStartandEnd()
            ObjMergePeriod = New CWPlusBL.Master.ClsMergePeriod
            ObjMergePeriod.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjMergePeriod.Description = txtName.Text
            ObjMergePeriod.FromDate = CDate(grdMergePeriod.Item("fromdate", vFrom).Value)
            ObjMergePeriod.ToDate = CDate(grdMergePeriod.Item("todate", vTo).Value)
            ObjMergePeriod.MergePeriodXML = GenerateXML()
            Save = ObjMergePeriod.FunSave()
            MsgBox(ObjMergePeriod.ErrorMsg)
            ClrScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjMergePeriod) Then
                ObjMergePeriod = Nothing
            End If
        End Try
    End Function

#End Region

#Region "Events"
    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtTo.ValueChanged
        If dtTo.Value < dtFrom.Value Then
            Exit Sub
        End If
        BindGrid()
    End Sub

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub

    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click
        Save()
    End Sub

    Private Sub frmMergePeriodMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
    End Sub
#End Region

End Class