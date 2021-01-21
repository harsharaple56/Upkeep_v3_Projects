Imports System.Data
Imports CWPlusBL.Master
Public Class Frm_SubCategoryMaster
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        'SET THEME TO CONTORLS 
        AddTheme(SplitContainer1.Panel1)
    End Sub

    Public Sub DynamicColorOnGrid(ByVal shvaGrid As DataGridView)
        With shvaGrid
            .ForeColor = Color.Black
            .GridColor = Color.Gold

        End With


    End Sub
    Private Sub Frm_SubCategoryMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        DynamicColorOnGrid(grdSubCategory)
        lblSubCategoryID.Visible = False

        BindCategory()
        FetchSubcategoryMaster()
    End Sub
    Public Function Save() As Boolean
        Save = False
        If Not cmbCategory.SelectedValue > 0 Then
            MsgBox("Select Category", MsgBoxStyle.Information, "SubCategory")
            Exit Function

        End If
        If lblSubCategoryID.Text = 0 Then
            If Not GblBoolNew Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "SubCategory")
                Exit Function
            End If
        Else
            If Not GblBoolEdit Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "SubCategory")
                Exit Function
            End If
        End If
       
        Dim ObjSubCategory As New ClsSubCategoryMaster
        Dim ObjDt As New DataTable
        Try
            ObjSubCategory.SubCategoryID = lblSubCategoryID.Text
            ObjSubCategory.CategoryID = cmbCategory.SelectedValue
            ObjSubCategory.SubCategoryDesc = txtSubCategory.Text
            ObjSubCategory.UserName = gblUserName
            ObjSubCategory.SubCategoryMajorDesc = drpMajorSubCat.Text
            Save = ObjSubCategory.FunSave()
            MsgBox(ObjSubCategory.ErrorMsg)
            lblSubCategoryID.Text = 0
            FetchSubcategoryMaster()
            txtSubCategory.Text = ""
            'BindCategory()
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(ObjSubCategory) Then
                ObjSubCategory = Nothing
            End If
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
        End Try
    End Function
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If Save() = True Then
        '    lblSubCategoryID.Text = 0
        '    FetchSubcategoryMaster()
        '    txtSubCategory.Text = ""
        '    BindCategory()
        'End If
    End Sub
    Private Sub BindCategory()
        Dim ObjCategory As New ClsCategory
        Dim ObjDt As New DataTable
        Try
            ' ObjCategory.CategoryID = 0
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
    Public Sub BindGrid()
        Dim objsubCategory As New ClsSubCategoryMaster
        Dim ObjPriDt As New DataTable
        Try
            grdSubCategory.Rows.Clear()
            ObjPriDt = objsubCategory.FunFetch()
            For rwctr = 0 To ObjPriDt.Rows.Count - 1
                grdSubCategory.Rows.Add()
                grdSubCategory("Subcategoryid", rwctr).Value = ObjPriDt.Rows(rwctr)("SubCategoryID")
                grdSubCategory("categoryid", rwctr).Value = ObjPriDt.Rows(rwctr)("CategoryId")
                grdSubCategory("subCategoryName", rwctr).Value = ObjPriDt.Rows(rwctr)("subCategoryName")
                grdSubCategory("CategoryDesc", rwctr).Value = ObjPriDt.Rows(rwctr)("CategoryDesc")
            Next
            BindCategory()
            txtSubCategory.Text = ""
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(objsubCategory) = False Then
                objsubCategory = Nothing
            End If
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If

        End Try
    End Sub
    Public Sub FetchSubcategoryMaster()
        Dim objsubCategory As New ClsSubCategoryMaster
        Dim ObjPriDt As New DataTable
        Try
            If lblSubCategoryID.Text = 0 Then
                grdSubCategory.DataSource = Nothing

                objsubCategory.SubCategoryID = lblSubCategoryID.Text
                ObjPriDt = objsubCategory.FunFetch()

                'Binding datatable to grid

                Dim dv As DataView
                dv = New DataView(ObjPriDt)
                If TypeOf cmbCategory.SelectedValue Is Decimal And cmbCategory.SelectedValue > 0 Then
                    dv.RowFilter = "categoryid=" & cmbCategory.SelectedValue
                End If
                grdSubCategory.DataSource = dv
                grdSubCategory.Columns("Subcategoryid").Visible = False
                grdSubCategory.Columns("categoryid").Visible = False
                grdSubCategory.Columns("subCategoryName").HeaderText = "Sub-Category"
                grdSubCategory.Columns("CategoryDesc").HeaderText = "Category"
                grdSubCategory.Columns("CategoryDesc").Width = 200
                grdSubCategory.Columns("subCategoryName").Width = 200
                'For rwctr = 0 To ObjPriDt.Rows.Count - 1
                '    grdSubCategory.Rows.Add()
                '    grdSubCategory("Subcategoryid", rwctr).Value = ObjPriDt.Rows(rwctr)("SubCategoryID")
                '    grdSubCategory("categoryid", rwctr).Value = ObjPriDt.Rows(rwctr)("CategoryId")
                '    grdSubCategory("subCategoryName", rwctr).Value = ObjPriDt.Rows(rwctr)("subCategoryName")
                '    grdSubCategory("CategoryDesc", rwctr).Value = ObjPriDt.Rows(rwctr)("CategoryDesc")
                'Next
                lblSubCategoryID.Visible = False
            Else

                objsubCategory.SubCategoryID = lblSubCategoryID.Text
                ObjPriDt = objsubCategory.FunFetch()
                If ObjPriDt.Rows.Count > 0 Then
                    cmbCategory.SelectedValue = ObjPriDt.Rows(0).Item("categoryid").ToString()
                    txtSubCategory.Text = ObjPriDt.Rows(0).Item("subcategoryname").ToString()
                    drpMajorSubCat.Text = ObjPriDt.Rows(0).Item("APReportCategoryDesc").ToString()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If IsNothing(objsubCategory) = False Then
                objsubCategory = Nothing
            End If
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
        End Try
    End Sub

    Private Sub grdSubCategory_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSubCategory.CellDoubleClick
        If e.RowIndex < 0 Then
            Exit Sub
        End If
        lblSubCategoryID.Text = grdSubCategory(0, e.RowIndex).Value
        FetchSubcategoryMaster()
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim str As DialogResult = MsgBox("Are You Sure Want to Delete?", MsgBoxStyle.YesNo, "Brand")
        'If str = vbNo Then
        '    Exit Sub
        'End If

        'delete()
    End Sub

    Public Function delete() As Boolean
        delete = False
        If Not GblBoolDelete Then
            MsgBox("Access Denied", MsgBoxStyle.Information, "SubCategory")
        End If
        Dim str As DialogResult = MsgBox("Are You Sure Want to Delete?", MsgBoxStyle.YesNo, "Brand")
        If str = vbNo Then
            Exit Function
        End If

        Dim ObjSubCategory As New ClsSubCategoryMaster
        Dim ObjDt As New DataTable
        Try
            ObjSubCategory.SubCategoryID = lblSubCategoryID.Text
            ObjSubCategory.UserName = gblUserName
            delete = ObjSubCategory.FunDelete
            MsgBox(ObjSubCategory.ErrorMsg)
            BindGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjSubCategory) Then
                ObjSubCategory = Nothing
            End If
            If IsNothing(ObjDt) = False Then
                ObjDt = Nothing
            End If
        End Try
    End Function

    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click
        Save()
    End Sub

    Private Sub imgDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
       
        delete()
    End Sub

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub

    Private Sub cmbCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCategory.SelectedIndexChanged
        If Not TypeOf cmbCategory.SelectedValue Is Decimal Then
            txtSubCategory.Clear()
            Exit Sub
        End If
        FetchSubcategoryMaster()
    End Sub
End Class