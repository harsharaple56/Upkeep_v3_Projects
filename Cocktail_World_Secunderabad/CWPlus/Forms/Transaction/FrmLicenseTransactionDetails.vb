Imports CWPlusBL.Master



Public Class FrmLicenseTransactionDetails

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ' AddTheme(GroupBox1)
    End Sub


    Private Sub LicenseTransactionDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BindGrid()
    End Sub

#Region "Procedure"


    Public Sub BindGrid()
        Dim ObjLicenseTransction As New CWPlusBL.Master.clsLicenaseTransctionDtails
        Dim ObjDT As New DataTable
        Try
            ObjDT = ObjLicenseTransction.FunFetch()
            Me.grdLicenseTransactionDetails.DataSource = ObjDT

            grdLicenseTransactionDetails.Columns(0).Width = 300




        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(ObjLicenseTransction) = False Then
                ObjLicenseTransction = Nothing
            End If

            If IsNothing(ObjDT) = False Then
                ObjDT = Nothing
            End If

        End Try



    End Sub


#End Region





End Class