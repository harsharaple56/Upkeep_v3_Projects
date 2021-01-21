Imports System.Data
Imports CWPlusBL.Master
Imports System.Xml

Public Class QCStep1
    ' Dim gblFromDate As Date

    Dim pubIntTag As Integer = 1

    Public Sub InitMe()
        FetchControls()
        If gblControlHeadID > 0 Then

            FetchQcStep1()
            AssignDateToLable()
            rbtnToatlCost.Checked = True

            Exit Sub
        Else
            FetchFromDateToDate()
            AssignDateToLable()
            FetchQcStep1()
            rbtnToatlCost.Checked = True
            Exit Sub
        End If

        grdQuickControl.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub QCStep1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub
    Public Sub AssignDateToLable()
        lblFromDate.Text = GblFromDate.ToString("dd-MMM-yyyy") & " To " & GblToDate.ToString("dd-MMM-yyyy")
    End Sub
    Public Sub FetchFromDateToDate()
        Dim ObjDate As New CWPlusBL.ClsQuickControl
        Dim Objdt As New DataTable
        Try
            ObjDate.ToDate = GblPurchaseDate
            Objdt = ObjDate.FunFetcFromDateToDate()
            If Objdt.Rows.Count > 0 Then
                GblFromDate = Objdt.Rows(0).Item("FromDate")
                GblToDate = Objdt.Rows(0).Item("ToDate")
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(ObjDate) = False Then
                ObjDate = Nothing
            End If
            If IsNothing(Objdt) = False Then
                Objdt = Nothing
            End If
        End Try
    End Sub

    Public Sub FetchQcStep1()
        Dim ObjQc As New CWPlusBL.ClsQuickControl
        Dim Objds As New DataSet
        Dim ObjDt As New DataTable
        Try
            ObjQc.LicenseID = gblLicenseID
            If GblFromDate > GblToDate Then
                ObjQc.FromDate = GblToDate
                ObjQc.ToDate = GblFromDate
            Else
                ObjQc.FromDate = GblFromDate
                ObjQc.ToDate = GblToDate
            End If
              

            ObjQc.Tag = pubIntTag
            Objds = ObjQc.FetchQuickControls()
            ObjDt = Objds.Tables(2)
            If ObjDt.Rows.Count > 0 Then
                ' lblTotalCost.Text = ObjDt.Rows(0).Item("TotalCost")
                ' GblTotalCost = ObjDt.Rows(0).Item("TotalCost")

                rbtnToatlCost.Text = "FIFOCost =" & ObjDt.Rows(0).Item("TotalCost")
                rbtnMasterCost.Text = "MasterCost =" & ObjDt.Rows(0).Item("MastreRateCost")
                rbtnAverageCost.Text = " AverageCost =" & ObjDt.Rows(0).Item("AveargeCost")

                If rbtnToatlCost.Checked = True Then
                    GblTotalCost = ObjDt.Rows(0).Item("TotalCost")
                    lblTotalCost.Text = ObjDt.Rows(0).Item("TotalCost")


                    rbtnToatlCost.Text = "FIFOCost =" & lblTotalCost.Text

                ElseIf rbtnMasterCost.Checked = True Then
                    GblTotalCost = ObjDt.Rows(0).Item("MastreRateCost")
                    lblTotalCost.Text = ObjDt.Rows(0).Item("MastreRateCost")
                    lblMasterRate.Text = ObjDt.Rows(0).Item("MastreRateCost")

                    rbtnMasterCost.Text = "MasterCost =" & lblTotalCost.Text
                Else
                    GblTotalCost = ObjDt.Rows(0).Item("AveargeCost")
                    lblTotalCost.Text = ObjDt.Rows(0).Item("AveargeCost")

                    lblAverageCost.Text = ObjDt.Rows(0).Item("AveargeCost")
                    rbtnAverageCost.Text = " AverageCost =" & lblTotalCost.Text
                End If


            End If

            lblTotalCost.Visible = True
            grdQuickControl.DataSource = Objds.Tables(1)

            grdQuickControl.Columns("LicenseID").Visible = False
            grdQuickControl.Columns("BrandOpeningID").Visible = False
            'grdQuickControl.Columns("MasterRate").Visible = False

            grdQuickControl.Columns(1).Width = 300
            grdQuickControl.Columns(6).Width = 150
            grdQuickControl.Columns(7).Width = 150
            'grdQuickControl.Columns(4).Width = 300

            gblQCSTEP1SaveXMl = GenerateXML()

        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(ObjQc) = False Then
                ObjQc = Nothing
            End If
            If IsNothing(ObjDt) = False Then
                ObjDt = Nothing
            End If
        End Try

    End Sub

    Private Function GenerateXML() As XmlDocument
        Dim xmldoc As New XmlDocument
        xmldoc.LoadXml("<Master><QCStep1Table></QCStep1Table></Master>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("QcStep1")
        For index = 0 To grdQuickControl.RowCount - 1
            XmlElt = xmldoc.CreateElement("QcStep1")
            XmlElt.SetAttribute("BrandOpeningID", grdQuickControl.Item("BrandOpeningID", index).Value)
            XmlElt.SetAttribute("Qty", grdQuickControl.Item("Qty", index).Value)
            XmlElt.SetAttribute("cost", grdQuickControl.Item("FIFOCost", index).Value)
            xmldoc.DocumentElement.Item("QCStep1Table").AppendChild(XmlElt)
        Next
        Return xmldoc
    End Function
    Public Sub FetchControls()
        Dim ObjControls As New CWPlusBL.ClsQuickControl
        Dim ObjDt As New DataSet
        Try
            gblControlHeadID = 0
            ObjControls.LicenseID = gblLicenseID
            ObjControls.FromDate = GblPurchaseDate
            ObjDt = ObjControls.FunFetchContorlForQCStep2()

            If ObjDt.Tables(0).Rows.Count > 0 Then
                gblControlHeadID = ObjDt.Tables(0).Rows(0).Item("ControlHeadID")
                GblFromDate = ObjDt.Tables(0).Rows(0).Item("FromDate")
                GblToDate = ObjDt.Tables(0).Rows(0).Item("ToDate")
            End If
        Catch ex As Exception
            Throw ex
        End Try


    End Sub

    Private Sub BtnTag1_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnTag1.ClickButtonArea
        pubIntTag = 1
        BtnTag1.ColorFillSolid = Color.Gray
        Btntag2.ColorFillSolid = Color.White
        BtnTag3.ColorFillSolid = Color.White
        FetchQcStep1()
    End Sub

    Private Sub Btntag2_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Btntag2.ClickButtonArea
        pubIntTag = 2
        Btntag2.ColorFillSolid = Color.Gray
        BtnTag1.ColorFillSolid = Color.White
        BtnTag3.ColorFillSolid = Color.White
        FetchQcStep1()
    End Sub

    Private Sub BtnTag3_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnTag3.ClickButtonArea
        pubIntTag = 3
        BtnTag3.ColorFillSolid = Color.Gray
        Btntag2.ColorFillSolid = Color.White
        BtnTag1.ColorFillSolid = Color.White

        FetchQcStep1()
    End Sub

    Private Sub rbtnToatlCost_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnToatlCost.CheckedChanged
        If rbtnToatlCost.Checked = True Then
            rbtnMasterCost.Checked = False
            rbtnAverageCost.Checked = False
            FetchQcStep1()

            lblTotalCost.Visible = True
            'lblTotalCost.Text = lblTotalCost.Text
            'GblTotalCost = lblTotalCost.Text
        End If
    End Sub

    Private Sub rbtnMasterCost_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnMasterCost.CheckedChanged
        If rbtnMasterCost.Checked = True Then
            rbtnToatlCost.Checked = False
            rbtnAverageCost.Checked = False

            FetchQcStep1()
            lblTotalCost.Text = lblMasterRate.Text

            'GblTotalCost = lblTotalCost.Text
        End If
    End Sub

    Private Sub rbtnAverageCost_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnAverageCost.CheckedChanged
        If rbtnAverageCost.Checked = True Then
            rbtnMasterCost.Checked = False
            rbtnToatlCost.Checked = False

            FetchQcStep1()
            lblTotalCost.Text = lblAverageCost.Text
            'GblTotalCost = lblTotalCost.Text
        End If
    End Sub
End Class
