Imports System.Data.SqlClient
Imports CWPlusBL.Master

Public Class FrmMigration_cw2
    Dim ObjClsMigrate As CWPlusBL.Master.ClsMigration

    Private Sub FrmMigration_cw2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmbVersion.SelectedIndex = 0
        BindDatabases()
        FunFetchLicense()
        If grdLicenseMst.RowCount > 0 Then
            btnSave.Enabled = False
        End If
    End Sub

    Public Sub FunFetchLicense()
        Dim objLicenseMst As New Utitity
        Dim ObjPridt As New DataTable
        Try
            ObjPridt = objLicenseMst.FunFetchLicense()
            For rwctr = 0 To ObjPridt.Rows.Count - 1
                grdLicenseMst.Rows.Add()
                grdLicenseMst("LicenseID", rwctr).Value = ObjPridt.Rows(rwctr)("LicenseID")
                grdLicenseMst("LicenseDesc", rwctr).Value = ObjPridt.Rows(rwctr)("LicenseDesc")
                grdLicenseMst("LicenseNo", rwctr).Value = ObjPridt.Rows(rwctr)("LicenseNo")
            Next
            grdLicenseMst.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
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

    Private Sub BindDatabases()
        Dim strConnection As String = ""
        Try
            Dim con As New SqlConnection(Configuration.ConfigurationManager.ConnectionStrings("StrSqlConn").ConnectionString & ";connection timeout=5")
            Dim dap As New SqlDataAdapter("select name from sys.databases order by name", con)
            dap.SelectCommand.CommandType = CommandType.Text
            Dim dt As New DataTable
            dap.Fill(dt)
            cmbDataBase.DataSource = dt
            cmbDataBase.Enabled = True
            cmbDataBase.DisplayMember = "name"
        Catch ex As Exception
            cmbDataBase.DataSource = Nothing
            MsgBox("Sql Server is not reachable !" & vbCrLf & "Please verify the settings....", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Try
            If cmbVersion.SelectedIndex = 0 Then
                MsgBox("Select Version", MsgBoxStyle.Information, "CWPlus")
                Exit Sub
            End If
            ObjClsMigrate = New ClsMigration
            ObjClsMigrate.DbName = cmbDataBase.Text
            If cmbVersion.SelectedIndex = 1 Then
                 ObjClsMigrate.FunMigrate("Spr_MigrateFromCW2")
            ElseIf cmbVersion.SelectedIndex = 2 Then
                ObjClsMigrate.FunMigrate("Spr_MigrateFromCW3")
            End If
            FunFetchLicense()
            MsgBox(ObjClsMigrate.ErrorMsg)
            btnSave.Enabled = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub grdLicenseMst_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdLicenseMst.CellClick
        If e.RowIndex < 0 Or e.ColumnIndex < 0 Then Exit Sub
        If grdLicenseMst.Columns(e.ColumnIndex).Name = "BtnSetOpening" Then
            SetBrandOpening(grdLicenseMst("LicenseID", e.RowIndex).Value())
            Exit Sub
        ElseIf grdLicenseMst.Columns(e.ColumnIndex).Name = "Edit" Then
            SetBrandForCocktail(grdLicenseMst("LicenseID", e.RowIndex).Value())
        End If
    End Sub

    Private Sub SetBrandForCocktail(ByVal licenseid As Double)
        Dim ObjPriDt As New DataTable
        Try
            ObjClsMigrate = New ClsMigration
            ObjClsMigrate.NewLicenseid = licenseid
            ObjPriDt = ObjClsMigrate.FetchViewCocktailtocreate()
            grdCocktailBrand.DataSource = ObjPriDt

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub SetBrandOpening(ByVal licenseid As Double)
        Try
            If cmbVersion.SelectedIndex = 0 Then
                MsgBox("Select Version", MsgBoxStyle.Information, "CWPlus")
                Exit Sub
            End If
            ObjClsMigrate = New ClsMigration
            ObjClsMigrate.NewLicenseid = licenseid
            ObjClsMigrate.DbName = cmbDataBase.Text
            ObjClsMigrate.OpeningDate = DtDate.Value
            If cmbVersion.SelectedIndex = 1 Then
                ObjClsMigrate.FunSetOpeningStockForMigration("Spr_SetOpeningStockForMigration")
            ElseIf cmbVersion.SelectedIndex = 2 Then
                ObjClsMigrate.FunSetOpeningStockForMigration("Spr_SetOpeningStockForMigrationFromCW3")
            End If

            MsgBox(ObjClsMigrate.ErrorMsg)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

   
End Class