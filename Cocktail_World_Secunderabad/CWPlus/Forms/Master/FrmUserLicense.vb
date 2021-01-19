Imports System.Data
Imports CWPlusBL.Master
Imports System.Xml

Public Class FrmUserLicense
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddTheme(SplitContainer1.Panel1)
    End Sub

    Public Sub ClearScreen()

    End Sub
    Private Sub FrmUserLicense_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)

        BindUserName()
        FetchCheckedData()
        ' FunFetchLicense()
    End Sub
    Public Sub BindUserName()

        Dim ObjDtUser As New ClsUserMaster
        Dim ObjPriDt As New DataTable
        Try
            ObjPriDt = ObjDtUser.FunFetch
            cmbUserLicense.DataSource = Nothing
            ComboBindingTemplate(cmbUserLicense, ObjPriDt, "User", "UserID")
          
                If cmbUserLicense.SelectedValue = "0" Then
                    grdUserLicense.Visible = False
                    Exit Sub
                Else
                    grdUserLicense.Visible = True
                    Exit Sub
                End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDtUser) Then
                ObjDtUser = Nothing
            End If
            If Not IsNothing(ObjPriDt) Then
                ObjPriDt = Nothing
            End If
        End Try
    End Sub

    Public Sub FunFetchLicense()
        Dim ObjLicense As New Utitity
        Dim ObjPriDt As New DataTable
        Try
            ObjLicense.LicenseID = 0
            ObjPriDt = ObjLicense.FunFetchLicense()
            grdUserLicense.Rows.Clear()
            If ObjPriDt.Rows.Count > 0 Then
                For index = 0 To ObjPriDt.Rows.Count - 1
                    grdUserLicense.Rows.Add()
                    grdUserLicense.Item("LicenseDesc", index).Value = ObjPriDt.Rows(index)("LicenseDesc")
                    grdUserLicense.Item("licenseID", index).Value = ObjPriDt.Rows(index)("licenseID")

                Next

            End If
            grdUserLicense.Visible = True

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If IsNothing(ObjLicense) = False Then
                ObjLicense = Nothing
            End If
            If IsNothing(ObjLicense) = False Then
                ObjLicense = Nothing
            End If
        End Try

        grdUserLicense.Columns("LicenseID").Visible = False
        'grdUserLicense.Columns("Licensedesc").HeaderText = "License"


    End Sub

    Public Function Save() As Boolean
        Save = False
        If Not GblBoolNew Then
            MsgBox("Access Denied", MsgBoxStyle.Information, "User License")
            Exit Function
        End If
        Save = False
        Dim ObjDtUserLicense As New ClsUserLicense
        Dim ObjPriDt As New DataTable
        Try
            ObjDtUserLicense.UserID = cmbUserLicense.SelectedValue.ToString()
            ObjDtUserLicense.ArrUserParameterId = GenerateXML()
            ObjDtUserLicense.UserName = gblUserName
            Save = ObjDtUserLicense.FunSave()
            
            MsgBox(ObjDtUserLicense.ErrorMsg)
            ClearScreen()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If IsNothing(ObjDtUserLicense) = False Then
                ObjDtUserLicense = Nothing
            End If
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
        End Try
    End Function
    Private Function GenerateXML() As XmlDocument

        Dim xmldoc As New XmlDocument

        xmldoc.LoadXml("<Master><UserLicenseMaster></UserLicenseMaster></Master>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("UserLicense")
        For index = 0 To grdUserLicense.RowCount - 1
            If CBool(grdUserLicense.Item("Sel", index).Value) Then
                XmlElt = xmldoc.CreateElement("UserLicense")
                XmlElt.SetAttribute("LicenseID", grdUserLicense.Item("LicenseID", index).Value)
                xmldoc.DocumentElement.Item("UserLicenseMaster").AppendChild(XmlElt)
            End If
        Next

        Return xmldoc
    End Function
    Public Sub FetchCheckedData()
        Dim ObjDtUserLicense As New ClsUserLicense
        Dim ObjPriDt As New DataTable
        Try
            ObjDtUserLicense.UserID = Trim(cmbUserLicense.SelectedValue.ToString())

            ObjPriDt = ObjDtUserLicense.FunFetch
            For rwctr = 0 To grdUserLicense.RowCount - 1
                Dim tmpDv As DataView
                tmpDv = New DataView(ObjPriDt)
                tmpDv.RowFilter = "Licenseid=" & grdUserLicense.Item("Licenseid", rwctr).Value
                If tmpDv.Count > 0 Then
                    grdUserLicense.Item("sel", rwctr).Value = True
                End If

            Next
            If cmbUserLicense.SelectedValue = 0 Then
                grdUserLicense.Visible = False
                Exit Sub
            Else
                grdUserLicense.Visible = True
                Exit Sub
            End If


            ' ClearScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If IsNothing(ObjDtUserLicense) = False Then
                ObjDtUserLicense = Nothing
            End If
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
        End Try
    End Sub

    Private Sub cmbUserLicense_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUserLicense.SelectedIndexChanged
        If TypeOf cmbUserLicense.SelectedValue Is Decimal Then


            If cmbUserLicense.SelectedValue = "0" Then
                grdUserLicense.Visible = False
                Exit Sub
            Else
                FunFetchLicense()
                FetchCheckedData()
            End If

        End If


        'If cmbUserLicense.SelectedValue = "0" Then
        '    grdUserLicense.Visible = False
        '    Exit Sub
        'Else
        '    FunFetchLicense()l
        '    FetchCheckedData()
        'End If

    End Sub

    
    'Private Sub btnSave_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
    '    Save()
    'End Sub

    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click
        Save()
    End Sub

    
    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub

   
End Class