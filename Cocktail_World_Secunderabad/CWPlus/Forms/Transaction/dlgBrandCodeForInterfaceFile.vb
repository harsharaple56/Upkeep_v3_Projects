Public Class dlgBrandCodeForInterfaceFile

    Public Sub New(ByVal dtSource As DataTable)

        ' This call is required by the designer.
        InitializeComponent()

        grd.DataSource = Nothing
        grd.DataSource = dtSource

    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim ObjDt As New DataTable
        ObjDt = DirectCast(grd.DataSource, DataTable)
        ExportExcelTemplate(ObjDt)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub dlgBrandCodeForInterfaceFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = btnClose
    End Sub
End Class