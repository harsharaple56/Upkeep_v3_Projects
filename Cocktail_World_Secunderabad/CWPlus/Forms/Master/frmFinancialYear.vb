Public Class frmFinancialYear
    Dim ObjFinYear As CWPlusBL.Master.ClsFinancialYear
    Dim ObjDt As DataTable

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'SET THEME TO CONTORLS 
        AddTheme(SplitContainer1.Panel1)
    End Sub

#Region "Procedures"
    Private Sub ClrScreen()
        dtpFromDate.Value = Date.Now
        dtpToDate.Value = Date.Now
        chkIsActive.Checked = False
        lblid.Text = 0
    End Sub

    Private Sub InitScreen()
        Try
            ObjFinYear = New CWPlusBL.Master.ClsFinancialYear
            ObjDt = New DataTable
            ObjDt = ObjFinYear.FunFetch
            grdFinyear.DataSource = Nothing
            grdFinyear.DataSource = ObjDt
            ClrScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
            If Not IsNothing(ObjFinYear) Then
                ObjFinYear = Nothing
            End If
        End Try
        grdFinyear.Columns("FincyearId").Visible = False
    End Sub

    Public Function Save() As Boolean
        Save = False
        If lblid.Text = 0 Then
            If Not GblBoolNew Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Financial Year")
                Exit Function
            End If
        Else
            If Not GblBoolEdit Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Financial Year")
                Exit Function
            End If
        End If

        Try
            ObjFinYear = New CWPlusBL.Master.ClsFinancialYear
            ObjFinYear.FinancialYearID = lblid.Text
            ObjFinYear.Fromdate = dtpFromDate.Value
            ObjFinYear.ToDate = dtpToDate.Value
            ObjFinYear.IsActive = chkIsActive.Checked
            ObjFinYear.UserName = gblUserName
            Save = ObjFinYear.FunSave
            MsgBox(ObjFinYear.ErrorMsg)
            ClrScreen()
            InitScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            If Not IsNothing(ObjFinYear) Then
                ObjFinYear = Nothing
            End If
        End Try
    End Function

    Public Function FunDelete() As Boolean
        FunDelete = False
        If lblid.Text = 0 Then
            MsgBox("Select Financial Year to delete", MsgBoxStyle.Critical, "Financial Year")
            Exit Function
        End If
        Try
            ObjFinYear = New CWPlusBL.Master.ClsFinancialYear
            ObjFinYear.FinancialYearID = lblid.Text
            ObjFinYear.UserName = gblUserName
            FunDelete = ObjFinYear.FunDelete
            MsgBox(ObjFinYear.ErrorMsg)
            ClrScreen()
            InitScreen()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjFinYear) Then
                ObjFinYear = Nothing
            End If
        End Try
    End Function

#End Region
    Private Sub FrmSize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        MDI.chkLicenseName.Visible = False
        InitScreen()
    End Sub

    Private Sub grdsize_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdFinyear.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        lblid.Text = grdFinyear("FincyearId", e.RowIndex).Value
        dtpFromDate.Value = grdFinyear("fromdate", e.RowIndex).Value
        dtpToDate.Value = grdFinyear("todate", e.RowIndex).Value
        chkIsActive.Checked = grdFinyear("Active", e.RowIndex).Value
    End Sub
    
    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click
        Save()
    End Sub

    Private Sub imgDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgDelete.Click
        FunDelete()
    End Sub

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub

    Private Sub imgNew_Click(sender As System.Object, e As System.EventArgs) Handles imgNew.Click
        ClrScreen()
    End Sub
End Class