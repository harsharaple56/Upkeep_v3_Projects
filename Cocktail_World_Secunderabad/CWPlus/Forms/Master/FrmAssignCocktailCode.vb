Public Class FrmAssignCocktailCode
    Dim ObjAssignctcode As CWPlusBL.Master.AssignCocktailCode
    Dim ObjDt As DataSet
    Dim Dt As DataTable
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'SET THEME TO CONTROLS
        AddTheme(GroupBox1)
    End Sub
    Private Sub ClrScreen()
        txtcocktailcode.Clear()
        lblid.Text = 0
        'Cmbcocktailname.SelectedValue = 0
    End Sub
    Public Function Save() As Boolean
        Save = False
        If (Cmbcocktailname.Text = "") Then
            MsgBox("Please Select/Enter Cocktail Name", MsgBoxStyle.Critical, "cocktail")
            Cmbcocktailname.Focus()
            Exit Function
        End If
        If (MDI.cmbLicenseName.Text = "") Then
            MsgBox("Please Select License Name", MsgBoxStyle.Critical, "cocktail")
            MDI.cmbLicenseName.Focus()
            Exit Function
        End If
        If txtcocktailcode.Text = "" Then
            MsgBox("Please Enter Cocktail Code", MsgBoxStyle.Critical, "cocktail")
            txtcocktailcode.Focus()
            Exit Function
        End If
        Try

            If gblArrMDICheckedLicense.Count > 0 Then
                For cntr = 0 To gblArrMDICheckedLicense.Count - 1
                    ObjAssignctcode = New CWPlusBL.Master.AssignCocktailCode
                    ObjAssignctcode.AssigncocktailcodeId = lblid.Text
                    ObjAssignctcode.CocktailId = Cmbcocktailname.SelectedValue
                    ObjAssignctcode.Cocktailcode = txtcocktailcode.Text
                    ObjAssignctcode.LicenseID = gblArrMDICheckedLicense.Item(cntr)
                    ObjAssignctcode.UserName = gblUserName
                    Save = ObjAssignctcode.FunSave
                Next
                MsgBox(ObjAssignctcode.ErrorMsg)
            End If
            txtcocktailcode.Clear()
            Bindgrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjAssignctcode) Then
                ObjAssignctcode = Nothing
            End If
        End Try
    End Function
    Public Sub BindCombo()
        Try
            ObjAssignctcode = New CWPlusBL.Master.AssignCocktailCode
            ObjDt = New DataSet
            ObjDt = ObjAssignctcode.FetchAssigncocktail
            ComboBindingTemplate(Cmbcocktailname, ObjDt.Tables(0), "Cocktailname", "CocktailId")
           
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjAssignctcode) Then
                ObjAssignctcode = Nothing
            End If
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
        End Try
    End Sub
    Public Sub Bindgrid()
        Try
            ObjAssignctcode = New CWPlusBL.Master.AssignCocktailCode
            Dt = New DataTable
            ObjAssignctcode.CocktailId = Cmbcocktailname.SelectedValue
            ObjAssignctcode.LicenseID = MDI.cmbLicenseName.SelectedValue
            Dt = ObjAssignctcode.FunFetch
            grdAssigncocktailcode.DataSource = Nothing
            If Dt.Rows.Count > 0 Then

                grdAssigncocktailcode.DataSource = Dt
                grdAssigncocktailcode.Columns("AssigncocktailcodeID").Visible = False
                grdAssigncocktailcode.Columns("cocktailId").Visible = False
                grdAssigncocktailcode.Columns("cocktailname").Width = 130
                grdAssigncocktailcode.Columns("cocktailname").HeaderText = "Cocktail Name"
                grdAssigncocktailcode.Columns("LicenseId").Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjAssignctcode) Then
                ObjAssignctcode = Nothing
            End If
            If Not IsNothing(Dt) Then
                Dt = Nothing
            End If
        End Try
    End Sub

    Private Sub FrmAssignCocktailCode_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        MDI.chkLicenseName.Visible = False
        For rctr = 0 To MDI.chkLicenseName.Items.Count - 1
            MDI.chkLicenseName.SetItemChecked(rctr, False)
        Next

    End Sub
    Private Sub FrmAssignCocktailCode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        MDI.chkLicenseName.Visible = False
        BindCombo()
    End Sub

  
    Private Sub grdAssigncocktailcode_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdAssigncocktailcode.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        lblid.Text = grdAssigncocktailcode("AssigncocktailcodeID", e.RowIndex).Value
        Cmbcocktailname.SelectedValue = grdAssigncocktailcode("cocktailId", e.RowIndex).Value
        txtcocktailcode.Text = grdAssigncocktailcode("cocktailcode", e.RowIndex).Value
    End Sub

    Public Sub FetchAssignCocktailCode()
        ObjAssignctcode = New CWPlusBL.Master.AssignCocktailCode
        Dt = New DataTable
        Try
            ObjAssignctcode.CocktailId = Cmbcocktailname.SelectedValue
            ObjAssignctcode.LicenseID = MDI.cmbLicenseName.SelectedValue
            Dt = ObjAssignctcode.FunFetch
            grdAssigncocktailcode.DataSource = Nothing
            grdAssigncocktailcode.Rows.Clear()

            If Dt.Rows.Count > 0 Then
                grdAssigncocktailcode.DataSource = Dt

                grdAssigncocktailcode.Columns("AssigncocktailcodeID").Visible = False
                grdAssigncocktailcode.Columns("cocktailId").Visible = False
                grdAssigncocktailcode.Columns("cocktailname").Width = 130
                grdAssigncocktailcode.Columns("cocktailname").HeaderText = "Cocktail Name"
                grdAssigncocktailcode.Columns("LicenseId").Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjAssignctcode) Then
                ObjAssignctcode = Nothing
            End If
            If Not IsNothing(Dt) Then
                Dt = Nothing
            End If
        End Try
    End Sub


    Private Sub grdAssigncocktailcode_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdAssigncocktailcode.CellContentClick
       
        If e.ColumnIndex = 0 Then
            If Not GblBoolDelete Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Assign Cocktail Code")
                Exit Sub
            End If
            If (MDI.cmbLicenseName.Text = "") Then
                MsgBox("Please Select License Name", MsgBoxStyle.Critical, "Assign Cocktail Code")
                MDI.cmbLicenseName.Focus()
                Exit Sub
            End If
            Dim Ans As String = MsgBox("Are You Sure Want to Delete", MsgBoxStyle.YesNo, "Assign Cocktail Code")
            If Ans = vbNo Then
                Exit Sub
            End If
            Try
                ObjAssignctcode = New CWPlusBL.Master.AssignCocktailCode
                ObjAssignctcode.AssigncocktailcodeId = grdAssigncocktailcode("AssigncocktailcodeID", e.RowIndex).Value
                ObjAssignctcode.LicenseID = MDI.cmbLicenseName.SelectedValue
                ObjAssignctcode.UserName = gblUserName
                Dim vijay As String = ObjAssignctcode.FunDelete
                MsgBox(ObjAssignctcode.ErrorMsg)
                Bindgrid()

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                If Not IsNothing(ObjAssignctcode) Then
                    ObjAssignctcode = Nothing
                End If
            End Try

        End If
       
    End Sub

    Private Sub Cmbcocktailname_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmbcocktailname.SelectedIndexChanged


        If Not TypeOf Cmbcocktailname.SelectedValue Is Decimal Then
            Cmbcocktailname.Focus()
            Exit Sub
        End If
        If gblArrMDICheckedLicense.Item(0) = 0 Then
            MsgBox("Please Select License")

            Exit Sub
        End If
        FetchAssignCocktailCode()



    End Sub
    Public Sub SaveCheck()

        If Not GblBoolNew Then
            MsgBox("Access Denied", MsgBoxStyle.Information, "Assign Cocktail Code")
            Exit Sub
        End If
       
        gblArrMDICheckedLicense.Clear()
        FetchMDILicenseChecked(MDI.chkLicenseName, MDI.cmbLicenseName.SelectedValue)

        If gblArrMDICheckedLicense.Count > 0 Then
            Save()
            For rctr = 0 To MDI.chkLicenseName.Items.Count - 1
                MDI.chkLicenseName.SetItemChecked(rctr, False)
            Next

        Else
            MsgBox("Please Select License")
        End If
        ClrScreen()
        'BindCombo()
    End Sub
    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click
        SaveCheck()
   End Sub

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub
End Class