Imports System.Data
Imports CWPlusBL.Master
Imports System.Xml

Public Class FrmLicenseList

    '  Dim frmForm2 As New FrmLicenseMst()
    '  Dim gloLicenseID As Integer

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        AddTheme(SplitContainer1.Panel1)
        AddTheme(SplitContainer2.Panel1)
        AddTheme(SplitContainer3.Panel1)
    End Sub

    Public Sub ClearScreen()
        txtLicenseCode.Text = ""
        txtOutLet.Text = ""
        grdLicenseCode.Rows.Clear()
    End Sub


    Private Sub FrmLicenseList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        grdLicenseCode.Columns("LicenseCodeID").Visible = False
        grdLicenseCode.Columns("LicenseID1").Visible = False
        FunFetch()
        'imgNew.Visible = False
    End Sub
    Public Sub FunFetch()
        Dim objLicenseMst As New Utitity
        Dim ObjPridt As New DataTable

        Try
            ObjPridt = objLicenseMst.FunFetchLicense()
            For rwctr = 0 To ObjPridt.Rows.Count - 1
                grdLicenseMst.Rows.Add()
                grdLicenseMst("Store", rwctr).Value = ObjPridt.Rows(rwctr)("Store")
                grdLicenseMst("IsRack", rwctr).Value = ObjPridt.Rows(rwctr)("IsRack")
                grdLicenseMst("ForFL3", rwctr).Value = ObjPridt.Rows(rwctr)("ForFL3")
                grdLicenseMst("FreezDate", rwctr).Value = ObjPridt.Rows(rwctr)("FreezDate")

                grdLicenseMst("LicenseID", rwctr).Value = ObjPridt.Rows(rwctr)("LicenseID")
                grdLicenseMst("LicenseDesc", rwctr).Value = ObjPridt.Rows(rwctr)("LicenseDesc")
                grdLicenseMst("LicenseNo", rwctr).Value = ObjPridt.Rows(rwctr)("LicenseNo")
                grdLicenseMst("Add1", rwctr).Value = ObjPridt.Rows(rwctr)("Add1")
                grdLicenseMst("Add2", rwctr).Value = ObjPridt.Rows(rwctr)("Add2")
                grdLicenseMst("City", rwctr).Value = ObjPridt.Rows(rwctr)("City")
                grdLicenseMst("Pincode", rwctr).Value = ObjPridt.Rows(rwctr)("Pincode")
                grdLicenseMst("Telephone", rwctr).Value = ObjPridt.Rows(rwctr)("Telephone")
                grdLicenseMst("Email", rwctr).Value = ObjPridt.Rows(rwctr)("Email")
                grdLicenseMst("Bst", rwctr).Value = ObjPridt.Rows(rwctr)("Bst")
                grdLicenseMst("Cst", rwctr).Value = ObjPridt.Rows(rwctr)("Cst")
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If IsNothing(objLicenseMst) = False Then
                objLicenseMst = Nothing
            End If
            If IsNothing(ObjPridt) = False Then
                ObjPridt = Nothing
            End If
        End Try
    End Sub
    Public Function Save() As Boolean
        Dim objLicenseCode As New ClsLicenseMst
        Dim ObjPriDt As New DataTable
        Save = False
        'If Not GblBoolNew Then
        '    MsgBox("Access Denied", MsgBoxStyle.Information, "License")
        '    Exit Function
        'End If
        Try
            objLicenseCode.LicenseID = gblLicenseID
            objLicenseCode.ArrParaMeter = GenerateXML()
            objLicenseCode.UserName = gblUserName
            Save = objLicenseCode.FunSaveLicenseCode()
            MsgBox(objLicenseCode.ErrorMsg)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If IsNothing(objLicenseCode) = False Then
                objLicenseCode = Nothing
            End If
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
        End Try


    End Function

    Public Sub FunFetchLicenseCodeMaster()
        Dim objLicenseCode As New ClsLicenseMst
        Dim ObjPriDt As New DataTable
        Try
            objLicenseCode.LicenseID = gblLicenseID
            ObjPriDt = objLicenseCode.FunFetchLicenseCodeMaster
            For rwctr = 0 To ObjPriDt.Rows.Count - 1
                grdLicenseCode.Rows.Add()
                grdLicenseCode("LicenseCodeID", rwctr).Value = ObjPriDt.Rows(rwctr)("LicenseCodeID")
                grdLicenseCode("LicenseID1", rwctr).Value = ObjPriDt.Rows(rwctr)("LicenseID1")
                grdLicenseCode("LicenseCode", rwctr).Value = ObjPriDt.Rows(rwctr)("LicenseCode")
                grdLicenseCode("Outlet", rwctr).Value = ObjPriDt.Rows(rwctr)("Outlet")
                grdLicenseCode("MMSCode", rwctr).Value = ObjPriDt.Rows(rwctr)("MMSCode")
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If IsNothing(objLicenseCode) = False Then
                objLicenseCode = Nothing
            End If
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
        End Try
        '   ClearScreen()
        grdLicenseCode.Columns("LicenseCodeID").Visible = False
        grdLicenseCode.Columns("LicenseID1").Visible = False
    End Sub

    Private Sub btnNewLicense_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'gblLicenseID = 0

        'Dim frmForm2 As New FrmLicenseMst()
        'frmForm2.SetDesktopLocation(350, 200)
        'frmForm2.Show()


    End Sub

    Private Sub btnADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '  Save()

    End Sub

    Private Sub btnAddRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddRow.Click

        'commented by Bhalchandra 23/2/2015 mmscode saving msg
        'For index = 0 To grdLicenseCode.Rows.Count - 1
        '    Dim license = grdLicenseCode("LicenseCode", index).Value.ToString.ToLower
        '    Dim MMSCode = grdLicenseCode("LicenseCode", index).Value.ToString.ToLower
        '    Dim txtLowerLicenseCode = LTrim(RTrim(txtLicenseCode.Text)).ToLower
        '    Dim txtLowertxtMMSCode = LTrim(RTrim(txtMMSCode.Text)).ToLower

        '    If license = txtLowerLicenseCode Or MMSCode = txtLowertxtMMSCode Then
        '        MsgBox("Can not insert duplicate Records")
        '        txtLicenseCode.Text = ""
        '        txtMMSCode.Text = ""
        '        txtOutLet.Text = ""
        '        Exit Sub
        '    End If
        'Next
        grdLicenseCode.Rows.Add(Nothing, Nothing, txtLicenseCode.Text, txtOutLet.Text, txtMMSCode.Text)

        txtLicenseCode.Text = ""
        txtOutLet.Text = ""
        'ClearScreen()
    End Sub

    Private Sub grdLicenseMst_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdLicenseMst.CellDoubleClick
        If e.RowIndex < 0 Then
            Exit Sub
        Else
            ClearScreen()
            gblLicenseID = grdLicenseMst("LicenseID", e.RowIndex).Value()
            FunFetchLicenseCodeMaster()
            ' ClearScreen()
            'grdLicenseCode.Columns("LicenseCodeID").Visible = False
            'grdLicenseCode.Columns("LicenseID").Visible = False
            ' grdLicenseCode.Columns("LicenseCode").Visible = False

        End If
    End Sub


    Private Function GenerateXML() As XmlDocument

        Dim xmldoc As New XmlDocument

        xmldoc.LoadXml("<Master><AssignLicenseCode></AssignLicenseCode></Master>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("AssignLicenseCodeOutLet")
        For index = 0 To grdLicenseCode.RowCount - 1

            XmlElt = xmldoc.CreateElement("AssignLicenseCodeOutLet")
            XmlElt.SetAttribute("LicenseCode", grdLicenseCode.Item("LicenseCode", index).Value)
            XmlElt.SetAttribute("OutLet", Convert.ToString(grdLicenseCode.Item("OutLet", index).Value))
            XmlElt.SetAttribute("MMSCode", Convert.ToString(grdLicenseCode.Item("MMSCode", index).Value))
            '   XmlElt.SetAttribute("CategorySizeLinkUpID", grdLicenseCode.Item("CategorySizeLinkUpID", index).Value)

            xmldoc.DocumentElement.Item("AssignLicenseCode").AppendChild(XmlElt)

        Next

        Return xmldoc
    End Function

    Private Sub grdLicenseMst_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdLicenseMst.CellClick
        If e.RowIndex < 0 Or e.ColumnIndex < 0 Then Exit Sub
        If grdLicenseMst.Columns(e.ColumnIndex).Name = "fzdate" Then
            gblLicenseID = grdLicenseMst("LicenseID", e.RowIndex).Value()
            Dim FrmFreezDate As New FrmFreezDate
            FrmFreezDate.Show()
            FrmFreezDate.SetDesktopLocation(350, 250)
            Exit Sub
        ElseIf grdLicenseMst.Columns(e.ColumnIndex).Name = "Edit" Then
            gblLicenseID = grdLicenseMst("LicenseID", e.RowIndex).Value()
            Dim frmForm2 As New FrmLicenseMst()
            frmForm2.SetDesktopLocation(350, 200)
            frmForm2.Show()
            Exit Sub
            'Else
            '    Exit Sub
        End If

        gblLicenseID = grdLicenseMst("LicenseID", e.RowIndex).Value()
        grdLicenseCode.Rows.Clear()
        FunFetchLicenseCodeMaster()

    End Sub


    Dim ObjDt As New DataSet
    Private Sub btnImportLicenseKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportLicenseKey.Click

        If grdLicenseMst.Rows.Count > 0 Then
            MsgBox("License Already Imported")
            Exit Sub
        End If


        ObjDt = DumpLicenkey()
        ' GenerateImportLicenseXMl()

        If SaveImportLicenseMaster() = True Then
            MsgBox("Inserted Successfully")
        Else
            MsgBox("Please Verify XML File")
        End If


    End Sub

    Private Function GenerateImportLicenseXMl() As XmlDocument
        Dim xmldoc As New XmlDocument
        xmldoc.LoadXml("<Master><ImportLicense></ImportLicense></Master>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("ImportLicenseMst")
        For index = 0 To ObjDt.Tables(0).Rows.Count - 1
            XmlElt = xmldoc.CreateElement("ImportLicenseMst")
            XmlElt.SetAttribute("LicenseNo", ObjDt.Tables(0).Rows(index).Item("LicenseNo"))
            XmlElt.SetAttribute("LicenseName", ObjDt.Tables(0).Rows(index).Item("LicenseName"))
            XmlElt.SetAttribute("Add1", ObjDt.Tables(0).Rows(index).Item("Add1"))
            XmlElt.SetAttribute("Add2", ObjDt.Tables(0).Rows(index).Item("Add2"))
            XmlElt.SetAttribute("city", ObjDt.Tables(0).Rows(index).Item("city"))
            XmlElt.SetAttribute("PinCode", ObjDt.Tables(0).Rows(index).Item("PinCode"))
            XmlElt.SetAttribute("telephone", ObjDt.Tables(0).Rows(index).Item("telephone"))
            XmlElt.SetAttribute("Email", ObjDt.Tables(0).Rows(index).Item("Email"))
            XmlElt.SetAttribute("Bst", ObjDt.Tables(0).Rows(index).Item("Bst"))
            XmlElt.SetAttribute("Cst", ObjDt.Tables(0).Rows(index).Item("Cst"))
            XmlElt.SetAttribute("Store", ObjDt.Tables(0).Rows(index).Item("Store"))
            xmldoc.DocumentElement.Item("ImportLicense").AppendChild(XmlElt)
        Next
        Return xmldoc
    End Function

    Private Function GenerateImportClientDetails() As XmlDocument
        Dim xmlClient As New XmlDocument
        xmlClient.LoadXml("<Master><ImportClient></ImportClient></Master>")
        Dim XmlElement As XmlElement = xmlClient.CreateElement("ImportClientMst")
        For i = 0 To ObjDt.Tables(1).Rows.Count - 1
            XmlElement = xmlClient.CreateElement("ImportClientMst")
            XmlElement.SetAttribute("ClientID", ObjDt.Tables(1).Rows(0).Item("ClientID"))
            XmlElement.SetAttribute("ClientName", ObjDt.Tables(1).Rows(0).Item("ClientName"))
            XmlElement.SetAttribute("Version", ObjDt.Tables(1).Rows(0).Item("Version"))
            xmlClient.DocumentElement.Item("ImportClient").AppendChild(XmlElement)
        Next
        Return xmlClient
    End Function


    Public Function SaveImportLicenseMaster() As Boolean
        Dim objImportLicense As New ClsLicenseMst
        Dim ObjPriDt As New DataTable
        SaveImportLicenseMaster = False
        Try
            objImportLicense.LicenseID = gblLicenseID
            objImportLicense.ImportLicense = GenerateImportLicenseXMl()
            objImportLicense.ImportClientDetails = GenerateImportClientDetails()
            objImportLicense.UserName = gblUserName
            SaveImportLicenseMaster = objImportLicense.FunSaveImportLicense()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If IsNothing(objImportLicense) = False Then
                objImportLicense = Nothing
            End If
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
        End Try

    End Function


    Private Sub imgNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgNew.Click
        gblLicenseID = 0

        Dim frmForm2 As New FrmLicenseMst()
        frmForm2.SetDesktopLocation(350, 200)
        frmForm2.ShowDialog()
    End Sub

    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click
        Save()
    End Sub

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub
    
End Class