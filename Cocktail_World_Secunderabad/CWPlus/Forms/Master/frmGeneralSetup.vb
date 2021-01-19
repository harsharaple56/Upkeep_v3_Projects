Imports System.Data
Imports CWPlusBL.Master
Imports System.Xml
Public Class frmGeneralSetup
    Private Sub frmGeneralSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FetchButtonSetup()
        FetchGrneralSetUp()
        FetchClient()

        BindMenu()
    End Sub
#Region "Button Setup"
    Public Sub FetchButtonSetup()
        Dim ObjButton As New clsGeneralSetup
        Dim Objdt As New DataTable
        Try
            Objdt = ObjButton.FunFetch()
            If Objdt.Rows.Count > 0 Then
                For index = 0 To Objdt.Rows.Count - 1
                    grdGeneralSetup.Rows.Add()
                    grdGeneralSetup.Item("ReportID", index).Value = Objdt.Rows(index)("ReportID")
                    grdGeneralSetup.Item("reportname", index).Value = Objdt.Rows(index)("reportname")
                    grdGeneralSetup.Item("ok", index).Value = Objdt.Rows(index)("ok")
                    grdGeneralSetup.Item("Excel", index).Value = Objdt.Rows(index)("Excel")
                    grdGeneralSetup.Item("Crystal", index).Value = Objdt.Rows(index)("Crystal")
                    grdGeneralSetup.Item("pdf", index).Value = Objdt.Rows(index)("pdf")
                    grdGeneralSetup.Item("filter", index).Value = Objdt.Rows(index)("filter")
                    grdGeneralSetup.Item("isCombine", index).Value = Objdt.Rows(index)("isCombine")
                Next
            End If

            grdGeneralSetup.Columns("reportid").Visible = False

        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(ObjButton) = False Then
                ObjButton = Nothing
            End If
            If IsNothing(Objdt) = False Then
                Objdt = Nothing
            End If
        End Try


    End Sub
    Public Function Save() As Boolean
        Save = False
        Dim ObjSave As New clsGeneralSetup
        Dim ObjDt As New DataTable
        Try
            ObjSave.ArrUserParameterId = GenerateXML()
            ObjSave.UserName = gblUserName
            Save = ObjSave.FunSave()
            MsgBox(ObjSave.ErrorMsg)
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(ObjSave) = False Then
                ObjSave = Nothing
            End If
            If IsNothing(ObjDt) = False Then
                ObjDt = Nothing
            End If

        End Try

    End Function
    Private Function GenerateXML() As XmlDocument
        Dim xmldoc As New XmlDocument
        xmldoc.LoadXml("<Master><GeneralSetup></GeneralSetup></Master>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("GeneralSetUpButton")
        For index = 0 To grdGeneralSetup.RowCount - 1
            XmlElt = xmldoc.CreateElement("GeneralSetUpButton")
            XmlElt.SetAttribute("reportid", grdGeneralSetup.Item("reportid", index).Value)
            XmlElt.SetAttribute("reportname", grdGeneralSetup.Item("reportname", index).Value)
            XmlElt.SetAttribute("ok", grdGeneralSetup.Item("ok", index).Value)
            XmlElt.SetAttribute("excel", grdGeneralSetup.Item("excel", index).Value)
            XmlElt.SetAttribute("crystal", grdGeneralSetup.Item("crystal", index).Value)
            XmlElt.SetAttribute("pdf", grdGeneralSetup.Item("pdf", index).Value)
            XmlElt.SetAttribute("filter", grdGeneralSetup.Item("filter", index).Value)
            XmlElt.SetAttribute("iscombine", grdGeneralSetup.Item("iscombine", index).Value)
            xmldoc.DocumentElement.Item("GeneralSetup").AppendChild(XmlElt)
        Next
        Return xmldoc
    End Function
    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click
        Save()
    End Sub
    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub

#Region "ColumnImage"
    'Dim InfoIcon As Image = Image.FromFile("D:\Shiva Work\Cocktail4Date9Aprail\CWPlus\CWPlus\Resources\1342009708_001_18.gif")
    'Dim infoexcel As Image = Image.FromFile("D:\Shiva Work\Cocktail4Date9Aprail\CWPlus\CWPlus\Resources\excel.png")
    'Dim Infopdf As Image = Image.FromFile("D:\Shiva Work\Cocktail4Date9Aprail\CWPlus\CWPlus\Resources\pdf.png")
    'Dim InfoIcrystal As Image = Image.FromFile("D:\Shiva Work\Cocktail4Date9Aprail\CWPlus\CWPlus\Resources\1342088280_report.png")
    'Dim Infofilter As Image = Image.FromFile("D:\Shiva Work\Cocktail4Date9Aprail\CWPlus\CWPlus\Resources\tdrnk20a.gif")
    'Dim InfoIScombine As Image = Image.FromFile("D:\Shiva Work\Cocktail4Date9Aprail\CWPlus\CWPlus\Resources\blue4.jpg")

    'Private Sub grdGeneralSetup_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles grdGeneralSetup.CellPainting

    '    If e.RowIndex = -1 AndAlso e.ColumnIndex = 2 Then

    '        e.Paint(e.CellBounds, DataGridViewPaintParts.All And Not DataGridViewPaintParts.ContentForeground)
    '        e.Graphics.DrawImage(InfoIcon, e.CellBounds)
    '        e.Handled = True
    '    End If

    '    If e.RowIndex = -1 AndAlso e.ColumnIndex = 3 Then

    '        e.Paint(e.CellBounds, DataGridViewPaintParts.All And Not DataGridViewPaintParts.ContentForeground)
    '        e.Graphics.DrawImage(infoexcel, e.CellBounds)
    '        e.Handled = True
    '    End If

    '    If e.RowIndex = -1 AndAlso e.ColumnIndex = 4 Then

    '        e.Paint(e.CellBounds, DataGridViewPaintParts.All And Not DataGridViewPaintParts.ContentForeground)
    '        e.Graphics.DrawImage(Infopdf, e.CellBounds)
    '        e.Handled = True
    '    End If

    '    If e.RowIndex = -1 AndAlso e.ColumnIndex = 5 Then

    '        e.Paint(e.CellBounds, DataGridViewPaintParts.All And Not DataGridViewPaintParts.ContentForeground)
    '        e.Graphics.DrawImage(InfoIcrystal, e.CellBounds)
    '        e.Handled = True
    '    End If

    '    If e.RowIndex = -1 AndAlso e.ColumnIndex = 6 Then

    '        e.Paint(e.CellBounds, DataGridViewPaintParts.All And Not DataGridViewPaintParts.ContentForeground)
    '        e.Graphics.DrawImage(Infofilter, e.CellBounds)
    '        e.Handled = True
    '    End If


    '    If e.RowIndex = -1 AndAlso e.ColumnIndex = 7 Then

    '        e.Paint(e.CellBounds, DataGridViewPaintParts.All And Not DataGridViewPaintParts.ContentForeground)
    '        e.Graphics.DrawImage(InfoIScombine, e.CellBounds)
    '        e.Handled = True
    '    End If

    'End Sub
#End Region
    


#End Region
#Region "Other Setup"
    Public Sub FetchGrneralSetUp()
        Dim ObjButton As New clsGeneralSetup
        Dim Objdt As New DataTable
        Try
            ' Send ControlID for Parameter to Check for Fetching....

            Objdt = ObjButton.FunFetchGSetUp()
            If Objdt.Rows.Count > 0 Then
                'After Fetching the Value Set Checked or Unchecked Depend on the Value
                chkFlivAdd.Checked = Objdt.Rows.Item(0)("FLIVAddress")
                ChkAllowNegativeStock.Checked = Objdt.Rows.Item(0)("AllowNegativeStock")
                ChkOnlyInventory.Checked = Objdt.Rows.Item(0)("OnlyInventory")
                If Objdt.Rows.Item(0)("ReportType") = "b" Then
                    rdbBrandwise.Checked = True
                ElseIf Objdt.Rows.Item(0)("ReportType") = "c" Then
                    rdbCategorywise.Checked = True
                Else
                    rdbSubCategorywise.Checked = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(ObjButton) = False Then
                ObjButton = Nothing
            End If
            If IsNothing(Objdt) = False Then
                Objdt = Nothing
            End If
        End Try


    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ObjButton As New clsGeneralSetup
        Dim Objdt As New DataTable
        Try
            ObjButton.FLIVAddress = chkFlivAdd.Checked
            ObjButton.AllowNegativeStock = ChkAllowNegativeStock.Checked
            ObjButton.OnlyInventory = ChkOnlyInventory.Checked
            If rdbBrandwise.Checked Then
                ObjButton.ReportType = "b"

            ElseIf rdbCategorywise.Checked Then
                ObjButton.ReportType = "c"
            Else

                ObjButton.ReportType = "s"
            End If

            ObjButton.FunSaveGenSetup()
            MsgBox(ObjButton.ErrorMsg)
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(ObjButton) = False Then
                ObjButton = Nothing
            End If
            If IsNothing(Objdt) = False Then
                Objdt = Nothing
            End If
        End Try
    End Sub

    

    Public Sub FetchClient()
        Dim objprifetchclient As New clsGeneralSetup
        Dim objpridt As New DataTable
        Try
            objpridt = objprifetchclient.FunFetchClient()
            If objpridt.Rows.Count = 1 Then
                txtClientName.Text = objpridt.Rows(0)(1).ToString()
                ' lblLicense.Text = "License ID is :- " & objpridt.Rows(0)(7).ToString()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If gblLicenseID > 0 Then
            Dim objpriUpdate As New clsGeneralSetup
            'For Fetch ClientID
            Dim objprifetchclient1 As New clsGeneralSetup
            'Dim objpridt As New DataTable
            'objpridt = objprifetchclient1.FunFetchClient()
            'If objpridt.Rows.Count = 1 Then
            objpriUpdate.ClientID = 0
            objpriUpdate.LicenseID = gblLicenseID
            objpriUpdate.ClientName = Replace(txtClientName.Text, "'", "''")
            objpriUpdate.FunUpdateClient()
            MsgBox(objpriUpdate.ErrorMsg)
            'End If
        Else
            MsgBox("Select License before update Client Info")
        End If
    End Sub

#Region "Menus Priority"

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

    Private Sub cmbMenu_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbMenu.SelectedIndexChanged
        If TypeOf cmbMenu.SelectedValue Is Integer Then
            If cmbMenu.SelectedValue = "0" Then
                Exit Sub
            End If
            BindParentMenuDesc()
        End If
    End Sub

    Public Sub BindParentMenuDesc()
        Dim ObjDtmenuDesc As New ClsUserMenuRights
        Dim ObjPriDt As New DataTable
        Try
            ObjDtmenuDesc.MenuID = cmbMenu.SelectedValue
            ObjPriDt = ObjDtmenuDesc.FunFetchParentMenuForPriority
            grdMenus.DataSource = Nothing
            grdMenus.DataSource = ObjPriDt

            grdMenus.Columns("Menuid").ReadOnly = True
            grdMenus.Columns("Menu").ReadOnly = True
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

    Private Function GenerateMenuPriorityXML() As XmlDocument

        Dim xmldoc As New XmlDocument

        xmldoc.LoadXml("<Master><UserLicenseMaster></UserLicenseMaster></Master>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("UserLicense")
        For index = 0 To grdMenus.RowCount - 1
            XmlElt = xmldoc.CreateElement("UserLicense")
            XmlElt.SetAttribute("Menuid", grdMenus.Item("Menuid", index).Value)
            XmlElt.SetAttribute("Priority", grdMenus.Item("Priority", index).Value)
            xmldoc.DocumentElement.Item("UserLicenseMaster").AppendChild(XmlElt)
        Next

        Return xmldoc
    End Function

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        SaveMenuPriority()
    End Sub

    Public Function SaveMenuPriority() As Boolean
        SaveMenuPriority = False
        Dim ObjDtUserMenuRights As New ClsUserMenuRights
        Dim ObjPriDt As New DataTable
        Try
            ObjDtUserMenuRights.ArrMenuPriority = GenerateMenuPriorityXML()
            SaveMenuPriority = ObjDtUserMenuRights.FunUpdateMenuPriority
            MsgBox(ObjDtUserMenuRights.ErrorMsg)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDtUserMenuRights) Then
                ObjDtUserMenuRights = Nothing
            End If
        End Try
    End Function

#End Region


End Class