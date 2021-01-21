Imports System.Data
Imports CWPlusBL.Master



Public Class FrmFreezDate


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddTheme(SplitContainer1.Panel1)

    End Sub
    Private Sub FrmFreezDate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AssignRights(gblMenuDesc)
        'Dim f As New FrmLicenseList
        'f.StartPosition = FormStartPosition.CenterParent
        FunFetchFreezDate()
    End Sub
#Region "Procedure"

    Public Sub ClearScreen()
        lblID.Text = 0

    End Sub

    Function Save() As Boolean
        Save = False
        Dim ObjFreezDate As New ClsLicenseMst
        Dim ObjPriDt As New DataTable

        Try
            ObjFreezDate.FreezID = lblID.Text
            ObjFreezDate.FreezDate = dtfreezDate.Text
            ObjFreezDate.LicenseID = gblLicenseID
            ObjFreezDate.UserName = gblUserName
            Save = ObjFreezDate.FunSaveFreezDate()
            MsgBox(ObjFreezDate.ErrorMsg)
            FunFetchFreezDate()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If IsNothing(ObjFreezDate) = False Then
                ObjFreezDate = Nothing
            End If

            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
        End Try



    End Function

    Function Delete() As Boolean
        Delete = False
        Dim ObjFreezDate As New ClsLicenseMst
        Dim ObjPriDt As New DataTable

        Try
            ObjFreezDate.FreezID = lblID.Text

            ObjFreezDate.UserName = gblUserName
            Delete = ObjFreezDate.FunDeleteFreeze()
            MsgBox(ObjFreezDate.ErrorMsg)
            FunFetchFreezDate()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If IsNothing(ObjFreezDate) = False Then
                ObjFreezDate = Nothing
            End If

            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
        End Try
    End Function

    Public Sub FunFetchFreezDate()
        Dim objLicenseCode As New ClsLicenseMst
        Dim ObjPriDt As New DataTable
        Try
            objLicenseCode.LicenseID = gblLicenseID
            ObjPriDt = objLicenseCode.FunFetchFreezDate
            grdFreezDate.Rows.Clear()
            For rwctr = 0 To ObjPriDt.Rows.Count - 1
                grdFreezDate.Rows.Add()
                grdFreezDate("FreezID", rwctr).Value = ObjPriDt.Rows(rwctr)("FreezID")
                grdFreezDate("LicenseID", rwctr).Value = ObjPriDt.Rows(rwctr)("LicenseID")
                grdFreezDate("FreezDate", rwctr).Value = ObjPriDt.Rows(rwctr)("FreezDate")
                grdFreezDate("IsActive", rwctr).Value = ObjPriDt.Rows(rwctr)("IsActive")
            Next
            ClearScreen()
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
        ' ClearScreen()
        grdFreezDate.Columns("FreezID").Visible = False
        grdFreezDate.Columns("LicenseID").Visible = False

    End Sub
#End Region



    Private Sub grdFreezDate_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdFreezDate.CellDoubleClick
        If e.RowIndex < 0 Then
            Exit Sub
        Else
            lblID.Text = grdFreezDate("FreezID", e.RowIndex).Value
            dtfreezDate.Text = grdFreezDate("FreezDate", e.RowIndex).Value
            gblLicenseID = grdFreezDate("LicenseID", e.RowIndex).Value
           
        End If
    End Sub

    Public Sub SaveCheck()
        If Not GblBoolEdit Then
            MsgBox("Access Denied", MsgBoxStyle.Information, "Freeze Date")
            Exit Sub
        End If
        'lblCurrentDate.Text = DateTime.Now.ToString("dd-MMM-yyyy")



        If dtfreezDate.Value > DateTime.Now.ToString("dd-MMM-yyyy") Then
            MsgBox("Please Insert less date")
            Exit Sub
        Else
            If Save() = True Then
                Me.Close()
                Dim frmForm2 As New FrmLicenseList()
                frmForm2.MdiParent = MDI
                frmForm2.Show()

                ' Exit Sub
            End If

        End If
    End Sub

    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click
        SaveCheck()
    End Sub

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub

    Private Sub imgDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgDelete.Click
        Delete()
    End Sub
End Class