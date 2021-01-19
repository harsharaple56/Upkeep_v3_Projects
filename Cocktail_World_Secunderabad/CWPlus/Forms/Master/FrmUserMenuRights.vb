Imports System.Data
Imports CWPlusBL.Master
Imports System.Xml

Public Class FrmUserMenuRights

    Dim gloParentMenuID As String

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddTheme(SplitContainer1.Panel1)
        AddTheme(SplitContainer2.Panel2)

    End Sub
    Public Sub ClearScreen()
        txtHidden.Text = ""
    End Sub

    Public Sub BindUserName()
        Dim ObjDtUser As New ClsUserMaster
        Dim ObjPriDt As New DataTable
        Try
            ObjPriDt = ObjDtUser.FunFetch
            cmbUserName.DataSource = Nothing
            ComboBindingTemplate(cmbUserName, ObjPriDt, "User", "UserID")
          
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

    Public Sub BindMenu()
        Dim ObjDtMenu As New ClsUserMenuRights
        Dim ObjPriDt As New DataTable
        Try
            ObjPriDt = ObjDtMenu.FunFetch
            cmbMenu.DataSource = Nothing
            ComboBindingTemplate(cmbMenu, ObjPriDt, "MenuDesc", "MenuId")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDtMenu) Then
                ObjDtMenu = Nothing
            End If
            If Not IsNothing(ObjPriDt) Then
                ObjPriDt = Nothing
            End If
        End Try
    End Sub
    Private Sub FrmUserMenuRights_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        txtHidden.Visible = False
        lblMenuDesc.Visible = True
        lblUserLicense.Visible = True
        BindUserName()
        BindMenu()
        ' FetchCheckedDataUserLicense()
        FunFetchLicense()
        'FetchCheckedDataUserLicense()
        grdUserLicense.Visible = True
    End Sub
    Public Sub BindParentMenuDesc()
        Dim ObjDtmenuDesc As New ClsUserMenuRights
        Dim ObjPriDt As New DataTable
        Try
            ObjDtmenuDesc.MenuID = cmbMenu.SelectedValue
                ObjPriDt = ObjDtmenuDesc.FunFetchParentMenu
                If ObjPriDt.Rows.Count > 0 Then
                    gloParentMenuID = ObjPriDt.Rows(0).Item("ParentMenuID")
                End If
            grdUSerMenuRights.DataSource = Nothing
            grdUSerMenuRights.DataSource = ObjPriDt
            grdUSerMenuRights.Columns("MenuDesc").DisplayIndex = 0
            grdUSerMenuRights.Columns("menuid").Visible = False
            grdUSerMenuRights.Columns("parentmenuid").Visible = False
            grdUSerMenuRights.Columns("isdisable").Visible = False
            ClearScreen()

            For rwctr = 0 To grdUSerMenuRights.RowCount - 1
                If Not grdUSerMenuRights.Item("isdisable", rwctr).Value = "" Then
                    Dim StrDisable As String = grdUSerMenuRights.Item("isdisable", rwctr).Value
                    Dim arr As Array = Split(StrDisable, "#")

                    For arrctr = 0 To arr.Length - 1

                        grdUSerMenuRights.Item("column" & CStr(arr(arrctr)), rwctr).ReadOnly = True

                    Next

                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If IsNothing(ObjDtmenuDesc) = False Then
                ObjDtmenuDesc = Nothing
            End If
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
        End Try



    End Sub
    'Private Sub cmbMenu_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMenu.SelectedIndexChanged

    '    '   ClearScreen()
    '    If TypeOf cmbMenu.SelectedValue Is Decimal Then
    '        If cmbMenu.SelectedValue = "0" Then
    '            grdUSerMenuRights.Visible = False
    '            Exit Sub
    '        End If
    '    Else
    '        If Not cmbMenu.SelectedValue Then
    '            Exit Sub
    '        Else
    '            If TypeOf cmbMenu.SelectedValue Is Decimal Then
    '                BindParentMenuDesc()
    '                FetchCheckedData()
    '                grdUSerMenuRights.Visible = True
    '            End If

    '        End If

    '    End If

    'End Sub

    
    Public Function Save() As Boolean
        ClearScreen()
        HiddenValue()
        Save = False
        If Not GblBoolNew Then
            MsgBox("Access Denied", MsgBoxStyle.Information, "User Menu Rights")
            Exit Function
        End If
        Dim ObjDtUserMenuRights As New ClsUserMenuRights
        Dim ObjPriDt As New DataTable
        Try
            ObjDtUserMenuRights.UserID = cmbUserName.SelectedValue
            ObjDtUserMenuRights.ParentMenuID = gloParentMenuID
            ObjDtUserMenuRights.ArrParameterId = Split(txtHidden.Text, "=$=")
            ObjDtUserMenuRights.ArrUserParameterId = GenerateXML()
            ObjDtUserMenuRights.UserName = gblUserName

            Save = ObjDtUserMenuRights.FunSave
            MsgBox(ObjDtUserMenuRights.ErrorMsg)
            ClearScreen()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDtUserMenuRights) Then
                ObjDtUserMenuRights = Nothing
            End If
        End Try
    End Function

    Public Sub HiddenValue()

        'For index = 0 To grdUSerMenuRights.ColumnCount - 1
        '    MsgBox(grdUSerMenuRights.Columns(index).HeaderText)
        'Next


        For rCtr = 0 To grdUSerMenuRights.RowCount - 1
            For colctr = 1 To 3
                If CBool(grdUSerMenuRights(colctr, rCtr).Value) Then
                    txtHidden.Text &= grdUSerMenuRights("MenuId", rCtr).Value & "#" & colctr & "=$="
                End If
            Next
        Next
    End Sub

    Public Sub FetchCheckedData()

        Dim ObjDtmenuDesc As New ClsUserMenuRights
        Dim ObjPriDt As New DataTable
        Try
            ObjDtmenuDesc.UserID = cmbUserName.SelectedValue
            ObjDtmenuDesc.MenuID = cmbMenu.SelectedValue
            ObjPriDt = ObjDtmenuDesc.FunFetchRightsCheckListData
            For index = 0 To grdUSerMenuRights.RowCount - 1
                Dim dv As DataView
                dv = New DataView(ObjPriDt)
                dv.RowFilter = "menuid=" & grdUSerMenuRights.Item("menuid", index).Value
                If dv.Count > 0 Then
                    Dim chk As Boolean = True
                    For ctr = 1 To 3
                        Dim tmpDv As DataView
                        tmpDv = New DataView(dv.ToTable)
                        tmpDv.RowFilter = "rightstypechoice=" & ctr
                        If tmpDv.Count > 0 Then
                            grdUSerMenuRights.Item(ctr, index).Value = True
                            If chk Then
                                chk = True
                            End If
                        Else
                            chk = False
                        End If
                    Next
                    If chk Then
                        grdUSerMenuRights.Item("column4", index).Value = True
                    End If
                    'grdUSerMenuRights.Visible = True
                End If
            Next
            lblMenuDesc.Visible = True

            ClearScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If IsNothing(ObjDtmenuDesc) = False Then
                ObjDtmenuDesc = Nothing
            End If
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
        End Try
    End Sub
    Private Sub cmbUserName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUserName.SelectedIndexChanged
        ClearScreen()

        If TypeOf cmbUserName.SelectedValue Is Decimal Then
            If cmbUserName.SelectedValue = "0" Then
                grdUSerMenuRights.Visible = False
                FunFetchLicense()
                'grdUserLicense.Visible = False
                Exit Sub
            End If
            ClearScreen()
            BindParentMenuDesc()
            FetchCheckedData()

            ''''''''''USerLIcenseFEtchData

            FunFetchLicense()
            FetchCheckedDataUserLicense()
            ''''''''''End''''
        End If
       

    End Sub

    Private Sub cmbMenu_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMenu.SelectedIndexChanged
        ClearScreen()
        If TypeOf cmbMenu.SelectedValue Is Integer Then
            If cmbMenu.SelectedValue = "0" Then
                grdUSerMenuRights.Visible = False
                lblMenu.Visible = False
                Exit Sub
            End If
            BindParentMenuDesc()
            FetchCheckedData()
            FunFetchLicense()
            FetchCheckedDataUserLicense()
            grdUSerMenuRights.Visible = True
        End If

    End Sub

    'Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
    '    Save()
    'End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim FrmUser As New FrmUserMaster()
        'FrmUser.SetDesktopLocation(350, 200)
        'FrmUser.Show()

    End Sub


#Region "FOR USER LICENSE FETCH AND SAVE"
    ''''''''''''''''''''''USerLicenseFetchFunction''''''''''''''''

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
    Public Sub FetchCheckedDataUserLicense()
        Dim ObjDtUserLicense As New ClsUserLicense
        Dim ObjPriDt As New DataTable
        Try
            ObjDtUserLicense.UserID = Trim(cmbUserName.SelectedValue.ToString())
            ObjPriDt = ObjDtUserLicense.FunFetch
            For rwctr = 0 To grdUserLicense.RowCount - 1
                Dim tmpDv As DataView
                tmpDv = New DataView(ObjPriDt)
                tmpDv.RowFilter = "Licenseid=" & grdUserLicense.Item("Licenseid", rwctr).Value
                If tmpDv.Count > 0 Then
                    grdUserLicense.Item("sel", rwctr).Value = True
                End If
            Next
            If cmbUserName.SelectedValue = 0 Then
                grdUserLicense.Visible = False
                lblUserLicense.Visible = False
                Exit Sub
            Else
                grdUserLicense.Visible = True
                lblUserLicense.Visible = True
                ' lblMenuDesc.Visible = True
                Exit Sub
            End If

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

    '''''''''''''''''''''''End'''''''''''''
#End Region


   
    Private Sub grdUSerMenuRights_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdUSerMenuRights.CellContentClick
        'CHECK ALL
        If e.ColumnIndex = 0 Then
            If CBool(grdUSerMenuRights.Item(0, e.RowIndex).EditedFormattedValue) Then

                For clctr = 1 To 3
                    If Not grdUSerMenuRights.Item(clctr, e.RowIndex).ReadOnly Then
                        grdUSerMenuRights.Item(clctr, e.RowIndex).Value = True
                    End If

                Next
            Else
                For clctr = 1 To 3
                    If Not grdUSerMenuRights.Item(clctr, e.RowIndex).ReadOnly Then
                        grdUSerMenuRights.Item(clctr, e.RowIndex).Value = False
                    End If
                Next
            End If

        ElseIf e.ColumnIndex = 1 Or e.ColumnIndex = 2 Or e.ColumnIndex = 3 Then
            If Not CBool(grdUSerMenuRights.Item(1, e.RowIndex).EditedFormattedValue) Or Not CBool(grdUSerMenuRights.Item(2, e.RowIndex).EditedFormattedValue) Or Not CBool(grdUSerMenuRights.Item(3, e.RowIndex).EditedFormattedValue) Then

                grdUSerMenuRights.Item(0, e.RowIndex).Value = False
            End If
        End If

        'If e.ColumnIndex = 1 And e.ColumnIndex = 2 And e.ColumnIndex = 3 Then
        '    If grdUSerMenuRights.Item(1, e.RowIndex).EditedFormattedValue And grdUSerMenuRights.Item(2, e.RowIndex).EditedFormattedValue And grdUSerMenuRights.Item(3, e.RowIndex).EditedFormattedValue Then
        '        grdUSerMenuRights.Item(0, e.RowIndex).Value = True
        '    End If
        'End If
    End Sub

    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click
        Save()
    End Sub

    Private Sub imgNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgNew.Click
        Dim FrmUser As New FrmUserMaster()
        FrmUser.SetDesktopLocation(350, 200)
        FrmUser.ShowDialog()

    End Sub

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub

    
End Class