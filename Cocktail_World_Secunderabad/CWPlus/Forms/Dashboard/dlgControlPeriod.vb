Imports CWPlusBL

Public Class dlgControlPeriod
    Dim objDash = New ClsQuickExcess
    Dim dt As DataTable

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        grdPeriod.CellBorderStyle = DataGridViewCellBorderStyle.Raised
    End Sub

    Private Sub BindControlsPeriod()
        Try
            objDash = New ClsQuickExcess
            dt = objDash.FunFetchControlsPeriod()
            grdPeriod.DataSource = dt
            grdPeriod.Columns("ValueField").Visible = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub dlgControlPeriod_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'BindControlsPeriod()
    End Sub
    Public toolTip As String = "======== Selected Dates ========" & vbCrLf
    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        For idx = 0 To grdPeriod.RowCount - 1
            toolTip &= grdPeriod("Period", idx).Value.ToString & vbCrLf
        Next
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class