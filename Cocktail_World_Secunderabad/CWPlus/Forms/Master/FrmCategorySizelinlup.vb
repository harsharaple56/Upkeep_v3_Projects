Imports System.Xml

Public Class FrmCategorySizelinlup
    Dim ObjSize As CWPlusBL.Master.ClsSize
    Dim ObjCategory As CWPlusBL.Master.ClsCategory
    Dim ObjCategorySizeLnkUp As CWPlusBL.Master.ClsCategorySizelinlup
    Dim ObjDt As DataTable

    Dim arrRowIndex As ArrayList
    Dim arrRowLicenses As ArrayList

    Dim shivaLicenseID As Double
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'SET THEME TO CONTROLS
        AddTheme(SplitContainer1.Panel1)
    End Sub

#Region "Procedures"

    Private Sub BindCategory()
        Try
            ObjCategory = New CWPlusBL.Master.ClsCategory
            ObjDt = New DataTable
            'ObjCategory.CategoryID = 0
            ObjDt = ObjCategory.FunFetch

            cmbCategory.DataSource = Nothing
            ComboBindingTemplate(cmbCategory, ObjDt, "Categorydesc", "Categoryid")
          

        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            If Not IsNothing(ObjCategory) Then
                ObjCategory = Nothing
            End If
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
        End Try
    End Sub

    Public Sub FetchSizes()
        Try
            ObjSize = New CWPlusBL.Master.ClsSize
            ObjDt = New DataTable
            ObjDt = ObjSize.FunFetch
            grdCategorySizeLinkUp.Rows.Clear()
            If ObjDt.Rows.Count > 0 Then
                For index = 0 To ObjDt.Rows.Count - 1
                    grdCategorySizeLinkUp.Rows.Add()
                    grdCategorySizeLinkUp.Item("sizeid", index).Value = ObjDt.Rows(index)("sizeid")
                    grdCategorySizeLinkUp.Item("size", index).Value = ObjDt.Rows(index)("sizedesc")
                    grdCategorySizeLinkUp.Item("ml", index).Value = "0"
                    grdCategorySizeLinkUp.Item("SPeg", index).Value = 0.0
                    grdCategorySizeLinkUp.Item("stockin", index).Value = "0"
                    grdCategorySizeLinkUp.Item("vAlias", index).Value = "0"
                Next

            End If

        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            If Not IsNothing(ObjSize) Then
                ObjSize = Nothing
            End If
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
        End Try
    End Sub
    Dim CheckExistLicenseID As Double

    Public Function CheckExistence() As String
        Dim str As String = ""
        arrRowIndex = New ArrayList
        arrRowLicenses = New ArrayList
        If gblArrMDICheckedLicense.Count > 0 Then
            For cntr = 0 To gblArrMDICheckedLicense.Count - 1
                For index = 0 To grdCategorySizeLinkUp.RowCount - 1

                    ' For cntr = 0 To gblArrMDICheckedLicense.Count - 1
                    If CBool(grdCategorySizeLinkUp.Item("sel", index).Value) Then 'And CBool(grdCategorySizeLinkUp.Item("isvaluechanged", index).Value) Then
                        ObjCategorySizeLnkUp = New CWPlusBL.Master.ClsCategorySizelinlup
                        ObjCategorySizeLnkUp.CategoryID = cmbCategory.SelectedValue
                        ObjCategorySizeLnkUp.LicenseID = gblArrMDICheckedLicense.Item(cntr)
                        ObjCategorySizeLnkUp.SizeID = grdCategorySizeLinkUp.Item("SizeID", index).Value
                        If Not ObjCategorySizeLnkUp.CheckCategorySizeLinkUpExistence Then
                            str &= "," & grdCategorySizeLinkUp.Item("size", index).Value
                        Else
                            arrRowIndex.Add(index)
                            arrRowLicenses.Add(gblArrMDICheckedLicense(cntr))
                        End If
                    End If
                Next


            Next


        End If
        If Not str = "" Then
            str = str.Trim(",")
            str &= " are already used."
        End If

        Return str
    End Function

    Public Function Save() As Boolean
        Save = False
        If LCase(MDI.cmdMultiSelect.Text) = "s" And MDI.chkLicenseName.CheckedItems.Count = 0 Then
            MsgBox("Select License Name.", MsgBoxStyle.Critical, "Category")
            Exit Function
        End If
      
        'If (MDI.cmbLicenseName.Text = "") Then
        '    MsgBox("Please Select License Name", MsgBoxStyle.Critical, "Category")
        '    MDI.cmbLicenseName.Focus()
        '    Exit Function
        'End If

        Dim tmpStr As String = ""
        tmpStr = CheckExistence()

        If Not tmpStr = "" Then
            If MsgBox(tmpStr & " Do you want to continue?", MsgBoxStyle.YesNo) = vbNo Then
                Exit Function
            End If
        End If

        If Not arrRowIndex.Count > 0 Then
            MsgBox("There are no changes to save")
            Exit Function
        End If

        For ctr = 0 To arrRowIndex.Count - 1
            'If grdCategorySizeLinkUp.Item("Sel", grdRow).Value = True Then
            Dim grdRow As Integer = arrRowIndex.Item(ctr)
            If Not IsNumeric(grdCategorySizeLinkUp.Item("ML", grdRow).Value) Then
                MsgBox("Please Enter Numeric value In ML   " & grdCategorySizeLinkUp.Item("ML", grdRow).Value, MsgBoxStyle.Critical, "Category")
                grdCategorySizeLinkUp.Focus()
                Exit Function
            End If
            If Not IsNumeric(grdCategorySizeLinkUp.Item("Speg", grdRow).Value) Then
                MsgBox("Please Enter Numeric value In Speg   " & grdCategorySizeLinkUp.Item("Speg", grdRow).Value, MsgBoxStyle.Critical, "Category")
                grdCategorySizeLinkUp.Focus()
                Exit Function
            End If
            If LCase(grdCategorySizeLinkUp.Item("StockIN", grdRow).Value) <> "b" And LCase(grdCategorySizeLinkUp.Item("StockIN", grdRow).Value) <> "p" And LCase(grdCategorySizeLinkUp.Item("StockIN", grdRow).Value) <> "m" Then
                MsgBox("Invalid Value In Stock    " & grdCategorySizeLinkUp.Item("stockIN", grdRow).Value, MsgBoxStyle.Critical, "Category")
                Exit Function
                'End If
            End If
            If Not IsNumeric(grdCategorySizeLinkUp.Item("noofspeg", grdRow).Value) Then
                MsgBox("Please Enter Numeric value In No of sPeg " & grdCategorySizeLinkUp.Item("noofspeg", grdRow).Value, MsgBoxStyle.Critical, "Category")
                grdCategorySizeLinkUp.Focus()
                Exit Function
            End If
            If Not IsNumeric(grdCategorySizeLinkUp.Item("pegsize", grdRow).Value) Then
                MsgBox("Please Enter Numeric value In Peg Size(ML) " & grdCategorySizeLinkUp.Item("pegsize", grdRow).Value, MsgBoxStyle.Critical, "Category")
                grdCategorySizeLinkUp.Focus()
                Exit Function
            End If
        Next
        Try
            '''''''Shiva-----
            'If MDI.cmdMultiSelect.Text = "M" And MDI.chkLicenseName.CheckedItems.Count = 0 Then
            '    ObjCategorySizeLnkUp = New CWPlusBL.Master.ClsCategorySizelinlup
            '    ObjCategorySizeLnkUp.CategorySizeLnkUpXML = GenerateXML()
            '    ObjCategorySizeLnkUp.CategoryID = cmbCategory.SelectedValue
            '    ObjCategorySizeLnkUp.LicenseID = MDI.cmbLicenseName.SelectedValue
            '    Save = ObjCategorySizeLnkUp.FunSave
            'Else

            '    For chkCtr = 0 To MDI.chkLicenseName.CheckedItems.Count - 1

            '        If Not DirectCast(MDI.chkLicenseName.CheckedItems(chkCtr), System.Data.DataRowView).Row.ItemArray(0) = 0 Then

            '            ObjCategorySizeLnkUp = New CWPlusBL.Master.ClsCategorySizelinlup
            '            ObjCategorySizeLnkUp.CategorySizeLnkUpXML = GenerateXML()
            '            ObjCategorySizeLnkUp.CategoryID = cmbCategory.SelectedValue
            '            ObjCategorySizeLnkUp.LicenseID = DirectCast(MDI.chkLicenseName.CheckedItems(chkCtr), System.Data.DataRowView).Row.ItemArray(0)
            '            Save = ObjCategorySizeLnkUp.FunSave
            '            'MsgBox(DirectCast(MDI.chkLicenseName.CheckedItems(chkCtr), System.Data.DataRowView).Row.ItemArray(0))
            '        End If

            '    Next
            'End If

            ''''''''End Shiav---------

            '  gblArrMDICheckedLicense.Clear()
            ' FetchMDILicenseChecked(MDI.chkLicenseName, MDI.cmbLicenseName.SelectedValue)

            If gblArrMDICheckedLicense.Count > 0 Then
                For cntr = 0 To gblArrMDICheckedLicense.Count - 1
                    ObjCategorySizeLnkUp = New CWPlusBL.Master.ClsCategorySizelinlup
                    ObjCategorySizeLnkUp.CategorySizeLnkUpXML = GenerateXML(gblArrMDICheckedLicense.Item(cntr))
                    ObjCategorySizeLnkUp.CategoryID = cmbCategory.SelectedValue
                    ObjCategorySizeLnkUp.LicenseID = gblArrMDICheckedLicense.Item(cntr)
                    ObjCategorySizeLnkUp.UserName = gblUserName
                    Save = ObjCategorySizeLnkUp.FunSave
                Next
            End If
            MsgBox(ObjCategorySizeLnkUp.ErrorMsg)

            cmbCategory.SelectedValue = 0
            FetchCategorySizeLinkUp()
            FetchSizes()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjCategorySizeLnkUp) Then
                ObjCategorySizeLnkUp = Nothing
            End If
            If Not IsNothing(arrRowIndex) Then
                arrRowIndex.Clear()
            End If
        End Try
    End Function

    Public Function FunDelete(ByVal CategorySizeLinkUpID As Double) As Boolean
        FunDelete = False

        Try
            ObjCategorySizeLnkUp = New CWPlusBL.Master.ClsCategorySizelinlup
          
            ObjCategorySizeLnkUp.CategorySizeLinkID = CategorySizeLinkUpID
            ObjCategorySizeLnkUp.UserID = gblUserID
            FunDelete = ObjCategorySizeLnkUp.FunDelete
            MsgBox(ObjCategorySizeLnkUp.ErrorMsg)
            cmbCategory.SelectedValue = 0
            FetchCategorySizeLinkUp()
            FetchSizes()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjCategorySizeLnkUp) Then
                ObjCategorySizeLnkUp = Nothing
            End If
            If Not IsNothing(arrRowIndex) Then
                arrRowIndex.Clear()
            End If
        End Try
    End Function

    Private Function GenerateXML(ByVal DblLocLicenseid As Double) As XmlDocument

        Dim xmldoc As New XmlDocument

        xmldoc.LoadXml("<Master><CatgSizeLnk></CatgSizeLnk></Master>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("CatgSize")
        For ctr = 0 To arrRowIndex.Count - 1
            If arrRowLicenses.Item(ctr) = DblLocLicenseid Then
                Dim index As Integer = arrRowIndex.Item(ctr)
                If CBool(grdCategorySizeLinkUp.Item("Sel", index).Value) Then
                    XmlElt = xmldoc.CreateElement("CatgSize")
                    XmlElt.SetAttribute("SizeID", grdCategorySizeLinkUp.Item("sizeid", index).Value)
                    XmlElt.SetAttribute("Alias", UCase(grdCategorySizeLinkUp.Item("vAlias", index).Value))
                    XmlElt.SetAttribute("ML", grdCategorySizeLinkUp.Item("ML", index).Value)
                    XmlElt.SetAttribute("Speg", grdCategorySizeLinkUp.Item("SPeg", index).Value)
                    XmlElt.SetAttribute("StockIN", UCase(grdCategorySizeLinkUp.Item("StockIN", index).Value))
                    XmlElt.SetAttribute("NoOfSpeg", UCase(grdCategorySizeLinkUp.Item("noofspeg", index).Value))
                    XmlElt.SetAttribute("PegSize", UCase(grdCategorySizeLinkUp.Item("pegsize", index).Value))
                    xmldoc.DocumentElement.Item("CatgSizeLnk").AppendChild(XmlElt)
                End If
            End If
        Next

        Return xmldoc
    End Function

    Public Sub FetchCategorySizeLinkUp()
        Try
            ObjCategorySizeLnkUp = New CWPlusBL.Master.ClsCategorySizelinlup
            ObjDt = New DataTable
            ObjCategorySizeLnkUp.CategoryID = cmbCategory.SelectedValue
            ObjCategorySizeLnkUp.LicenseID = MDI.cmbLicenseName.SelectedValue
            shivaLicenseID = MDI.cmbLicenseName.SelectedValue
            ObjDt = ObjCategorySizeLnkUp.FunFetch

            For rwctr = 0 To grdCategorySizeLinkUp.RowCount - 1
                Dim tmpDv As DataView
                tmpDv = New DataView(ObjDt)
                tmpDv.RowFilter = "sizeid=" & grdCategorySizeLinkUp.Item("sizeid", rwctr).Value
                If tmpDv.Count > 0 Then
                    grdCategorySizeLinkUp.Item("categorysizelinkid", rwctr).Value = tmpDv(0)("CategorySizeLinkID")
                    grdCategorySizeLinkUp.Item("sel", rwctr).Value = True
                    grdCategorySizeLinkUp.Item("vAlias", rwctr).Value = tmpDv(0)("alias")
                    grdCategorySizeLinkUp.Item("ml", rwctr).Value = tmpDv(0)("ml")
                    grdCategorySizeLinkUp.Item("speg", rwctr).Value = CDbl(tmpDv(0)("speg"))
                    grdCategorySizeLinkUp.Item("stockin", rwctr).Value = tmpDv(0)("stockin")
                    grdCategorySizeLinkUp.Item("noofspeg", rwctr).Value = tmpDv(0)("NoOfSpeg")
                    grdCategorySizeLinkUp.Item("pegsize", rwctr).Value = tmpDv(0)("PegSize")
                End If
                grdCategorySizeLinkUp.Item("isvaluechanged", rwctr).Value = False
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjCategorySizeLnkUp) Then
                ObjCategorySizeLnkUp = Nothing
            End If
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
        End Try
    End Sub
#End Region

    Private Sub FrmCategorySizelinlup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        MDI.chkLicenseName.Visible = False
        BindCategory()
        grdCategorySizeLinkUp.Columns("stockin").ValueType = GetType(System.String)
        grdCategorySizeLinkUp.Columns("speg").ValueType = GetType(System.Double)
        grdCategorySizeLinkUp.Columns("ml").ValueType = GetType(System.String)
        grdCategorySizeLinkUp.Columns("valias").ValueType = GetType(System.String)


    End Sub

    Private Sub cmbCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCategory.SelectedIndexChanged
        grdCategorySizeLinkUp.Rows.Clear()
        If Not TypeOf (cmbCategory.SelectedValue) Is Decimal Then
            Exit Sub
        End If
        FetchSizes()
        FetchCategorySizeLinkUp()
    End Sub

    Private Sub imgNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgNew.Click
        Dim parentNod As New TreeNode("master")
        Dim childNod As New TreeNode("catmst")
        childNod.Tag = "Category"
        parentNod.Nodes.Add(childNod)
        OpenForm(childNod)
        Me.Close()
    End Sub
    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub

    Public Sub Savecheck()
        If Not GblBoolNew Then
            MsgBox("Access Denied", MsgBoxStyle.Information, "Category Size Linkup")
            Exit Sub
        End If
        If cmbCategory.SelectedValue = 0 Then
            MsgBox("Please Select Catgory")
            Exit Sub
        End If
        If MDI.cmbLicenseName.SelectedValue = "0" Then
            MsgBox("Please Select License")
            Exit Sub
        End If

        gblArrMDICheckedLicense.Clear()
        FetchMDILicenseChecked(MDI.chkLicenseName, MDI.cmbLicenseName.SelectedValue)

        If gblArrMDICheckedLicense.Count > 0 Then
            Save()
        Else
            MsgBox("Please Select License")
        End If
    End Sub


    Private Sub imgSave_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click
        Savecheck()
    End Sub

    Dim vTempCellValue As String = ""
    Private Sub grdBrandOpening_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCategorySizeLinkUp.CellEnter
        If e.RowIndex < 0 Then Exit Sub
        If e.ColumnIndex = 4 Or e.ColumnIndex = 5 Or e.ColumnIndex = 6 Or e.ColumnIndex = 7 Or e.ColumnIndex = 8 Or e.ColumnIndex = 9 Then
            vTempCellValue = CStr(grdCategorySizeLinkUp.Item(e.ColumnIndex, e.RowIndex).Value)
        End If
    End Sub

    Private Sub grdBrandOpening_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCategorySizeLinkUp.CellContentClick
        If grdCategorySizeLinkUp.Columns(e.ColumnIndex).Name.ToLower = "vremove" Then
            If Not GblBoolDelete Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Category")
                Exit Sub
            End If
            ObjCategorySizeLnkUp = New CWPlusBL.Master.ClsCategorySizelinlup
            ObjCategorySizeLnkUp.CategoryID = cmbCategory.SelectedValue
            ObjCategorySizeLnkUp.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjCategorySizeLnkUp.SizeID = grdCategorySizeLinkUp.Item("SizeID", e.RowIndex).Value
            If Not ObjCategorySizeLnkUp.CheckCategorySizeLinkUpExistence Then
                MsgBox(grdCategorySizeLinkUp.Item("Size", e.RowIndex).Value & " is used you can't remove this")
            Else
                FunDelete(grdCategorySizeLinkUp.Item("categorysizelinkid", e.RowIndex).Value)
            End If
        End If
    End Sub

    Private Sub grdBrandOpening_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCategorySizeLinkUp.CellValueChanged
        If e.RowIndex < 0 Then Exit Sub
        If e.ColumnIndex = 0 Then
            If CBool(grdCategorySizeLinkUp.Item(e.ColumnIndex, e.RowIndex).Value) Then
                grdCategorySizeLinkUp.Item("IsValueChanged", e.RowIndex).Value = True
                Exit Sub
            End If
        End If
        If e.ColumnIndex = 4 Or e.ColumnIndex = 5 Or e.ColumnIndex = 6 Or e.ColumnIndex = 7 Or e.ColumnIndex = 8 Or e.ColumnIndex = 9 Then
            If Not vTempCellValue = CStr(grdCategorySizeLinkUp.Item(e.ColumnIndex, e.RowIndex).Value) Then
                grdCategorySizeLinkUp.Item("IsValueChanged", e.RowIndex).Value = True
            End If
        End If
    End Sub
End Class