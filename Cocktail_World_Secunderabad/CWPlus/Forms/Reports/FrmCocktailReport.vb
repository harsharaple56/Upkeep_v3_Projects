Imports System.Data
Imports CWPlusBL.Master
Imports System.Xml


Public Class FrmCocktailReport

    Dim CocktailReportMenuID As Integer
    Dim StrProcedureName As String
    Dim GroupBoxName As String
    Dim StrReportName As String
    Dim StrSubReportName As String
    Public _Brand As String = ""
    Public _Category As String = ""
    Public _Size As String = ""
    Public _Cocktail As String = ""
    Dim arrReportName(0) As String
    Dim objpurchasedet As CWPlusBL.Master.Clspurchase
    Dim LicName As String
    Dim LicID As Double
    Dim BillDate As Date
    Dim PurchaseDate As Date
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddTheme(grpCocktailReport)
    End Sub

    Private Sub FrmCocktailReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'GetFirstDayOfMonth(DateTime.Now.ToString("dd-MMM-yyyy"))
        'GetLastDayOfMonth(DateTime.Now.ToString("dd-MMM-yyyy"))
        LicName = MainModule.LicenseName


        HideAllButton()

        grpCocktailReport.Visible = False
        grpPurchaseReport.Visible = False
        grpSaleReport.Visible = False
        grpChataiReportmodify.Visible = False

        FetchMenuIDForCocktailReport()
        bindsupplier()
    End Sub

    Public Sub bindsupplier()
        Dim Objpurchase As CWPlusBL.Master.Clspurchase
        Dim dt As DataTable
        Try
            Objpurchase = New CWPlusBL.Master.Clspurchase
            dt = New DataTable
            dt = Objpurchase.BindSupplier.Tables(0)
            ComboBindingTemplate(cmbSuplier, dt, "SupplierName", "SupplierID")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(Objpurchase) Then
                Objpurchase = Nothing
            End If
            If Not IsNothing(dt) Then
                dt = Nothing
            End If
        End Try
    End Sub

    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        If Trim(txtTimeOut.Text) = "" Then
            txtTimeOut.Text = 30
        End If
        'ClearGrid()
        FetchCocktailReport()
    End Sub

    Public Property Location As Point
    Dim Sz As System.Drawing.Size
    Public Sub HideAllButton()
        btnok.Enabled = False
        btnExport.Enabled = False
        btnCrystalReport.Enabled = False
        btnPdf.Enabled = False
        btnMore.Enabled = False
    End Sub
    Public Sub FetchMenuIDForCocktailReport()
        Dim objCocktail As New ClsCocktailReports
        Dim ObjDt As New DataTable
        Try
            objCocktail.MenuDesc = gblMenuDesc
            ObjDt = objCocktail.FunFetchMenuID
            If ObjDt.Rows.Count > 0 Then
                CocktailReportMenuID = ObjDt.Rows(0).Item("MenuID")
                StrProcedureName = ObjDt.Rows(0).Item("procedurename")
                GroupBoxName = ObjDt.Rows(0).Item("GroupboxName")
                StrReportName = ObjDt.Rows(0).Item("ReportName")
                arrReportName(0) = StrReportName



                StrSubReportName = IIf(ObjDt.Rows(0).Item("subReport").ToString = Nothing, "", ObjDt.Rows(0).Item("subReport"))

                btnok.Enabled = ObjDt.Rows(0).Item("ok")
                btnExport.Enabled = ObjDt.Rows(0).Item("Excel")
                btnCrystalReport.Enabled = ObjDt.Rows(0).Item("Crystal")
                btnPdf.Enabled = ObjDt.Rows(0).Item("pdf")
                btnMore.Enabled = ObjDt.Rows(0).Item("filter")

                Panel1.Location = New Point(1203, 5)
                'Dim obj() As Control
                'obj = Me.Controls.Find(GroupBoxName, True)
                'obj(0).Location = New Point(12, 12)
                'grpCocktailReport.Text = UCase(gblMenuDesc) & " " & "Report"
                'If obj.Length > 0 Then obj(0).Visible = True

                If StrProcedureName = "Spr_FetchFlr4ReportNew" Then
                    Dim obj() As Control
                    obj = Me.Controls.Find(GroupBoxName, True)
                    grpChataiReportmodify.Text = "FLR-4 Report"
                    obj(0).Location = New Point(12, 12)
                    grpCocktailReport.Text = UCase(gblMenuDesc) & " " & "Report"
                    If obj.Length > 0 Then obj(0).Visible = True
                    Exit Sub
                End If
            End If

            Dim obj1() As Control
            obj1 = Me.Controls.Find(GroupBoxName, True)
            obj1(0).Location = New Point(12, 12)
            grpCocktailReport.Text = UCase(gblMenuDesc) & " " & "Report"
            If obj1.Length > 0 Then obj1(0).Visible = True

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function GetFirstDayOfMonth(ByVal dtDate As DateTime) As DateTime
        Dim Flr4FromDate As DateTime = dtDate
        Flr4FromDate = Flr4FromDate.AddDays(-(Flr4FromDate.Day - 1))

        dtpPurFromDate.Text = Flr4FromDate
        dtchataiFromDate.Text = Flr4FromDate
        dtSaleFromDate.Text = Flr4FromDate
        Return Flr4FromDate
    End Function

    Private Function GetLastDayOfMonth(ByVal dtDate As DateTime) As DateTime
        Dim Flr4ToDate As New DateTime(dtDate.Year, dtDate.Month, 1)
        Flr4ToDate = Flr4ToDate.AddMonths(1)
        Flr4ToDate = Flr4ToDate.AddDays(-(Flr4ToDate.Day))

        dtpurToDate.Text = Flr4ToDate
        DtSaleToDate.Text = Flr4ToDate
        dtchataiToDate.Text = Flr4ToDate


        Return Flr4ToDate
    End Function
    Dim ObjDta As DataTable
    Dim xmldocString As String
    Sub ClearGrid()
        grdCocktailReport.DataSource = Nothing
        grdCocktailReport.Rows.Clear()
        grdCocktailReport.Columns.Clear()
    End Sub
    Sub AddEditToGrid()
        Dim btn As DataGridViewButtonColumn
        btn = New DataGridViewButtonColumn
        btn.Name = "Edit"
        btn.Text = "Edit"
        btn.HeaderText = "Edit"
        btn.UseColumnTextForButtonValue = True
        grdCocktailReport.Columns.Insert(0, btn)

        btn = New DataGridViewButtonColumn
        btn.Name = "Delete"
        btn.Text = "Delete"
        btn.HeaderText = "Delete"
        btn.UseColumnTextForButtonValue = True
        grdCocktailReport.Columns.Insert(1, btn)
    End Sub
    Public Function FetchCocktailReport() As XmlDocument
        FetchCocktailReport = Nothing
        ClearGrid()
        Dim objCocktail As New ClsCocktailReports
        Dim chk As Boolean = False
        lblTotalQty.Text = ""
        ' Dim ObjDta As New DataTable
        Dim xmldoc As New XmlDocument
        xmldoc.LoadXml("<Master><CocktailReports></CocktailReports></Master>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("Report")
        Try
            gblArrMDICheckedLicense.Clear()
            FetchMDILicenseChecked(MDI.chkLicenseName, MDI.cmbLicenseName.SelectedValue)

            If gblArrMDICheckedLicense.Count = 0 Then
                MsgBox("Please Select License")
                Exit Function
            End If

            '''''''For Cocktail GroupBox 
            If grpCocktailReport.Visible = True Then
                For cnt = 0 To gblArrMDICheckedLicense.Count - 1
                    XmlElt = xmldoc.CreateElement("Report")
                    XmlElt.SetAttribute("LicenseID", gblArrMDICheckedLicense.Item(cnt))
                    XmlElt.SetAttribute("CocktailReportDate", dtpCocktailReport.Text)
                    XmlElt.SetAttribute("FromDate", GetFirstDayOfMonth(dtpCocktailReport.Value).ToString("dd-MMM-yyyy"))
                    XmlElt.SetAttribute("ToDate", GetLastDayOfMonth(dtpCocktailReport.Value).ToString("dd-MMM-yyyy"))
                    If chkAll.Checked = True Then
                        XmlElt.SetAttribute("All", 1)
                    Else
                        XmlElt.SetAttribute("All", 0)
                    End If
                    XmlElt.SetAttribute("Brand", _Brand)
                    XmlElt.SetAttribute("Category", _Category)
                    XmlElt.SetAttribute("Size", _Size)
                    XmlElt.SetAttribute("Cocktail", _Cocktail)
                    xmldoc.DocumentElement.Item("CocktailReports").AppendChild(XmlElt)
                Next
                'Return xmldoc
            End If
            '''''End Cocktail GroupBox 


            '''''''For Purchase GroupBox 
            If grpPurchaseReport.Visible = True Then
                chk = True
                'For cntr = 0 To gblArrMDICheckedLicense.Count - 1
                XmlElt = xmldoc.CreateElement("Report")
                XmlElt.SetAttribute("LicenseID", Trim(GetLicenseID()))
                XmlElt.SetAttribute("FromDate", dtpPurFromDate.Text)
                XmlElt.SetAttribute("ToDate", dtpurToDate.Text)
                XmlElt.SetAttribute("tpNo", txtTpNo.Text)
                XmlElt.SetAttribute("invoiceNo", txtinvoiceNo.Text)
                XmlElt.SetAttribute("Brand", _Brand)
                XmlElt.SetAttribute("Category", _Category)
                XmlElt.SetAttribute("Size", _Size)
                XmlElt.SetAttribute("Cocktail", _Cocktail)
                XmlElt.SetAttribute("Supplierid", cmbSuplier.SelectedValue)
                xmldoc.DocumentElement.Item("CocktailReports").AppendChild(XmlElt)
                ' Next
                ' Return xmldoc
            End If
            '''''End Purchase  GroupBox 


            '''''''For Sale GroupBox 
            If grpSaleReport.Visible = True Then
                chk = True
                '  For cntr = 0 To gblArrMDICheckedLicense.Count - 1
                XmlElt = xmldoc.CreateElement("Report")
                XmlElt.SetAttribute("LicenseID", Trim(GetLicenseID()))
                XmlElt.SetAttribute("FromDate", dtSaleFromDate.Text)
                XmlElt.SetAttribute("ToDate", DtSaleToDate.Text)
                XmlElt.SetAttribute("billNo", txtBillNo.Text)
                XmlElt.SetAttribute("Brand", _Brand)
                XmlElt.SetAttribute("Category", _Category)
                XmlElt.SetAttribute("Size", _Size)
                XmlElt.SetAttribute("Cocktail", _Cocktail)
                xmldoc.DocumentElement.Item("CocktailReports").AppendChild(XmlElt)
                '   Next
                ' Return xmldoc
            End If
            '''''End Sale  GroupBox 

            '''''For Chatai Report'''''
            If grpChataiReportmodify.Visible = True Then
                For cntr = 0 To gblArrMDICheckedLicense.Count - 1
                    XmlElt = xmldoc.CreateElement("Report")
                    XmlElt.SetAttribute("LicenseID", gblArrMDICheckedLicense.Item(cntr))
                    XmlElt.SetAttribute("FromDate", dtchataiFromDate.Text)
                    XmlElt.SetAttribute("ToDate", dtchataiToDate.Text)
                    XmlElt.SetAttribute("Brand", _Brand)
                    XmlElt.SetAttribute("Category", _Category)
                    XmlElt.SetAttribute("Size", _Size)
                    XmlElt.SetAttribute("Cocktail", _Cocktail)
                    xmldoc.DocumentElement.Item("CocktailReports").AppendChild(XmlElt)
                Next
                ' Return xmldoc
            End If
            '''''End Chatai  GroupBox 


            objCocktail.CocktailReportXml = xmldoc
            ObjDta = New DataTable
            ObjDta = objCocktail.FunFetchReport(StrProcedureName, txtTimeOut.Text)




            '[+][14/09/2019][Ajay Prajapati]
            If ObjDta.Rows.Count > 0 Then
                '[-][14/09/2019][Ajay Prajapati]


                'Added Mohammed
                If StrProcedureName = "Spr_purchaseReport" Then
                    PurchaseDate = Convert.ToDateTime(ObjDta.Rows(0)("purchaseDate"))   'Added By RV on 13-Sep-2019
                Else
                    BillDate = Convert.ToDateTime(ObjDta.Rows(0)("BillDate"))
                End If
                'End Mohammed


                'BillDate = Convert.ToDateTime(ObjDta.Rows(0)("BillDate")) 'Added By RV on 13-Sep-2019 
                ' PurchaseDate = Convert.ToDateTime(ObjDta.Rows(0)("purchaseDate"))   'Added By RV on 13-Sep-2019

                'MsgBox(objCocktail.OutMsg)
                If objCocktail.OutBit = True Then
                    xmldocString = xmldoc.InnerXml
                Else
                    MsgBox(objCocktail.OutMsg)
                End If

                If StrProcedureName = "Spr_FetchFlr3ChataiReport" Then
                    FunChataiReport(ObjDta)
                Else
                    grdCocktailReport.DataSource = ObjDta
                End If

                ''[+][14/09/2019][Ajay Prajapati]
                'End If
                ''[-][14/09/2019][Ajay Prajapati]

                If StrReportName = "Sale" Then
                    AddEditToGrid()
                    grdCocktailReport.Columns("billid").Visible = False
                ElseIf StrReportName = "Purchase" Then
                    AddEditToGrid()
                    grdCocktailReport.Columns("purchaseid").Visible = False
                End If
                MakeIDColumnsHide(grdCocktailReport)

                '[+][14/09/2019][Ajay Prajapati]
            End If
            '[-][14/09/2019][Ajay Prajapati]

            xmldocString = xmldoc.InnerXml
            If chk Then
                CalculateQty()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(objCocktail) = False Then
                objCocktail = Nothing
            End If
            'If IsNothing(ObjDta) = False Then
            '    ObjDta = Nothing
            'End If
        End Try
    End Function

    Public Sub CalculateQty()
        Dim vBtl As Double = 0
        Dim vSpeg As Double = 0
        Dim vLpeg As Double = 0
        If grpSaleReport.Visible Then
            For index = 0 To grdCocktailReport.RowCount - 1
                vBtl += IIf(IsDBNull(grdCocktailReport("bottleqty", index).Value), 0, grdCocktailReport("bottleqty", index).Value)
                vSpeg += IIf(IsDBNull(grdCocktailReport("speg", index).Value), 0, grdCocktailReport("speg", index).Value)
                vLpeg += IIf(IsDBNull(grdCocktailReport("lpeg", index).Value), 0, grdCocktailReport("lpeg", index).Value)
            Next
            lblTotalQty.Text = "Bottle:   " & vBtl & "  SPeg:   " & vSpeg & "   LPeg:   " & vLpeg
        End If
        If grpPurchaseReport.Visible Then
            For index = 0 To grdCocktailReport.RowCount - 1
                vBtl += grdCocktailReport("bottleqty", index).Value
            Next
            lblPurchaseTotal.Text = "Bottle:   " & vBtl
        End If
    End Sub

    Public Function GetLicenseID() As String
        GetLicenseID = " in ("
        'GetLicenseID = False
        gblArrMDICheckedLicense.Clear()
        FetchMDILicenseChecked(MDI.chkLicenseName, MDI.cmbLicenseName.SelectedValue)
        For cntr = 0 To gblArrMDICheckedLicense.Count - 2
            GetLicenseID &= gblArrMDICheckedLicense.Item(cntr) & ","
        Next
        GetLicenseID &= gblArrMDICheckedLicense.Item(gblArrMDICheckedLicense.Count - 1) & ")"
    End Function
    Function ChataiExport() As DataTable
        Dim dt As New DataTable

        For index = 0 To grdCocktailReport.ColumnCount - 1
            dt.Columns.Add(grdCocktailReport.Columns(index).Name)
        Next

        For rwctr = 0 To grdCocktailReport.RowCount - 1
            dt.Rows.Add()
            For clctr = 0 To grdCocktailReport.ColumnCount - 1
                dt.Rows(rwctr)(clctr) = grdCocktailReport(clctr, rwctr).Value
            Next

        Next

        Return dt
    End Function
    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        If Not TypeOf (MDI.cmbLicenseName.SelectedValue) Is Decimal Then
            MsgBox("Please select license", vbInformation, "CWPlus")
            Exit Sub
        End If

        If Me.grdCocktailReport.Rows.Count = 0 Then
            MsgBox("Nothing To Export ")
            Exit Sub
        End If

        Dim objCocktail As New ClsCocktailReports
        '  Dim ObjDt As New DataTable
        Try
            If StrProcedureName = "Spr_FetchFlr3ChataiReport" Then
                ExportExcelTemplate(ChataiExport)
            Else
                ExportExcelTemplate(ObjDta)
            End If



        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(objCocktail) = False Then
                objCocktail = Nothing
            End If
            If IsNothing(ObjDta) = False Then
                ObjDta = Nothing
            End If
        End Try
    End Sub

    Private Sub btnCrystalReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrystalReport.Click
        If Trim(txtTimeOut.Text) = "" Then
            txtTimeOut.Text = 30
        End If
        Dim xmldoc As New XmlDocument
        xmldoc.LoadXml("<Master><CocktailReports></CocktailReports></Master>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("Report")

        gblArrMDICheckedLicense.Clear()
        FetchMDILicenseChecked(MDI.chkLicenseName, MDI.cmbLicenseName.SelectedValue)

        If gblArrMDICheckedLicense.Count = 0 Then
            MsgBox("Please Select License")
            Exit Sub
        End If

        '''''''For Cocktail GroupBox 
        If grpCocktailReport.Visible = True Then
            For cnt = 0 To gblArrMDICheckedLicense.Count - 1
                XmlElt = xmldoc.CreateElement("Report")
                XmlElt.SetAttribute("LicenseID", gblArrMDICheckedLicense.Item(cnt))
                XmlElt.SetAttribute("CocktailReportDate", dtpCocktailReport.Text)
                XmlElt.SetAttribute("FromDate", GetFirstDayOfMonth(dtpCocktailReport.Value).ToString("dd-MMM-yyyy"))
                XmlElt.SetAttribute("ToDate", GetLastDayOfMonth(dtpCocktailReport.Value).ToString("dd-MMM-yyyy"))
                If chkAll.Checked = True Then
                    XmlElt.SetAttribute("All", 1)
                Else
                    XmlElt.SetAttribute("All", 0)
                End If
                XmlElt.SetAttribute("Brand", _Brand)
                XmlElt.SetAttribute("Category", _Category)
                XmlElt.SetAttribute("Size", _Size)
                XmlElt.SetAttribute("Cocktail", _Cocktail)
                xmldoc.DocumentElement.Item("CocktailReports").AppendChild(XmlElt)
            Next
            'Return xmldoc
        End If
        '''''End Cocktail GroupBox 


        '''''''For Purchase GroupBox 
        If grpPurchaseReport.Visible = True Then

            'For cntr = 0 To gblArrMDICheckedLicense.Count - 1
            XmlElt = xmldoc.CreateElement("Report")
            XmlElt.SetAttribute("LicenseID", Trim(GetLicenseID()))
            XmlElt.SetAttribute("FromDate", dtpPurFromDate.Text)
            XmlElt.SetAttribute("ToDate", dtpurToDate.Text)
            XmlElt.SetAttribute("tpNo", txtTpNo.Text)
            XmlElt.SetAttribute("invoiceNo", txtinvoiceNo.Text)
            XmlElt.SetAttribute("Brand", _Brand)
            XmlElt.SetAttribute("Category", _Category)
            XmlElt.SetAttribute("Size", _Size)
            XmlElt.SetAttribute("Cocktail", _Cocktail)
            xmldoc.DocumentElement.Item("CocktailReports").AppendChild(XmlElt)
            ' Next
            ' Return xmldoc
        End If
        '''''End Purchase  GroupBox 


        '''''''For Sale GroupBox 
        If grpSaleReport.Visible = True Then

            '  For cntr = 0 To gblArrMDICheckedLicense.Count - 1
            XmlElt = xmldoc.CreateElement("Report")
            XmlElt.SetAttribute("LicenseID", Trim(GetLicenseID()))
            XmlElt.SetAttribute("FromDate", dtSaleFromDate.Text)
            XmlElt.SetAttribute("ToDate", DtSaleToDate.Text)
            XmlElt.SetAttribute("billNo", txtBillNo.Text)
            XmlElt.SetAttribute("Brand", _Brand)
            XmlElt.SetAttribute("Category", _Category)
            XmlElt.SetAttribute("Size", _Size)
            XmlElt.SetAttribute("Cocktail", _Cocktail)
            xmldoc.DocumentElement.Item("CocktailReports").AppendChild(XmlElt)
            '   Next
            ' Return xmldoc
        End If
        '''''End Sale  GroupBox 

        '''''For Chatai Report'''''
        If grpChataiReportmodify.Visible = True Then
            '  For cntr = 0 To gblArrMDICheckedLicense.Count - 1
            XmlElt = xmldoc.CreateElement("Report")
            XmlElt.SetAttribute("LicenseID", MDI.cmbLicenseName.SelectedValue)
            XmlElt.SetAttribute("FromDate", dtchataiFromDate.Text)
            XmlElt.SetAttribute("ToDate", dtchataiToDate.Text)
            XmlElt.SetAttribute("Brand", _Brand)
            XmlElt.SetAttribute("Category", _Category)
            XmlElt.SetAttribute("Size", _Size)
            XmlElt.SetAttribute("Cocktail", _Cocktail)
            xmldoc.DocumentElement.Item("CocktailReports").AppendChild(XmlElt)
            '   Next
            ' Return xmldoc
        End If
        '''''End Chatai  GroupBox 
        xmldocString = xmldoc.InnerXml

        Dim StrParam As String = ""
        StrParam = "'" & xmldocString & "',0,''#" & LTrim(RTrim(txtTimeOut.Text))

        GenerateReport(StrReportName, "proc#" & StrProcedureName & "#" & StrParam & IIf(StrSubReportName <> "", vbCrLf & StrSubReportName, Nothing), txtTimeOut.Text)
    End Sub

    Public Sub FunChataiReport(ByVal dt As DataTable)
        grdCocktailReport.Rows.Clear()
        grdCocktailReport.Columns.Clear()
        grdCocktailReport.DataSource = Nothing
        Dim dtGrp As New DataTable
        dtGrp = dt.DefaultView.ToTable(True, "date")

        Dim dtGrpCols As New DataTable
        dtGrpCols = dt.DefaultView.ToTable(True, "catg", "siz")

        grdCocktailReport.Columns.Add("Title", "")
        grdCocktailReport.Columns.Add("Date", "Date")
        grdCocktailReport.Columns.Add("TPNO", "TPNO")
        grdCocktailReport.Columns("Date").Width = 180


        For index = 0 To dtGrpCols.Rows.Count - 1
            If index = 0 Then
                grdCocktailReport.Columns.Add(dtGrpCols.Rows(index)("catg"), dtGrpCols.Rows(index)("catg"))
                grdCocktailReport.Columns(CStr(dtGrpCols.Rows(index)("catg"))).ReadOnly = True
            Else
                If Not dtGrpCols.Rows(index - 1)("catg") = dtGrpCols.Rows(index)("catg") Then
                    grdCocktailReport.Columns.Add(dtGrpCols.Rows(index)("catg"), dtGrpCols.Rows(index)("catg"))
                    grdCocktailReport.Columns(CStr(dtGrpCols.Rows(index)("catg"))).ReadOnly = True
                End If
            End If
            grdCocktailReport.Columns.Add(dtGrpCols.Rows(index)("catg") & dtGrpCols.Rows(index)("siz"), dtGrpCols.Rows(index)("siz"))
        Next


        For index = 0 To dtGrp.Rows.Count - 1
            Dim dv As DataView
            dv = New DataView(dt)
            dv.RowFilter = "date='" & dtGrp.Rows(index)("date") & "'"
            grdCocktailReport.Rows.Add("Opening", dtGrp.Rows(index)("date"), Nothing)
            grdCocktailReport.Rows(grdCocktailReport.RowCount - 1).DefaultCellStyle.BackColor = Color.LightGray
            grdCocktailReport.Rows.Add("Purchase", Nothing, dv(0)("tpno"))
            grdCocktailReport.Rows.Add("Total", Nothing, Nothing)
            grdCocktailReport.Rows.Add("Sale", Nothing, dv(0)("trntpno"))
            grdCocktailReport.Rows.Add("Closing", Nothing, Nothing)
            Dim rwIndex As Integer = grdCocktailReport.RowCount - 5
            For dvCtr = 0 To dv.Count - 1

                For inctr = 0 To 4
                    grdCocktailReport.Item(CStr(dv(dvCtr + inctr)("catg") & dv(dvCtr + inctr)("siz")), rwIndex + inctr).Value = dv(dvCtr + inctr)("totsale")
                Next
                dvCtr += 4
            Next

        Next
        grdCocktailReport.Columns(0).Frozen = True
        grdCocktailReport.Columns(1).Frozen = True
        grdCocktailReport.AutoResizeColumns()
    End Sub


    Private Sub btnMore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMore.Click
        Dim ObjSearch As New dlgReportSearch
        ObjSearch.IntForm = 1
        If ObjSearch.ShowDialog = DialogResult.OK Then
            FetchCocktailReport()

        End If
    End Sub
    Private Sub btnPdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPdf.Click
        Dim SaveFile As New SaveFileDialog
        'SaveFile.DefaultExt = ".pdf"
        'SaveFile.Filter = "pdf Files (*.pdf) | *.pdf"

        If SaveFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            If IO.File.Exists(SaveFile.FileName) Then
                IO.File.Delete(SaveFile.FileName)
            End If
            If Me.grdCocktailReport.Rows.Count = 0 Then
                MsgBox("Nothing To Export ")
                Exit Sub
            Else
                If Trim(txtTimeOut.Text) = "" Then
                    txtTimeOut.Text = 30
                End If
                'ClearGrid()
                FetchCocktailReport()

                Dim ObjPdf As New CWUtility.ClsCocktailReportPDF
                ObjPdf.ExportToPdfv2(IO.Path.GetDirectoryName(SaveFile.FileName), IO.Path.GetFileName(SaveFile.FileName), arrReportName, grdCocktailReport)

                'ObjPdf.ExportToPdfNew(IO.Path.GetDirectoryName(SaveFile.FileName), IO.Path.GetFileName(SaveFile.FileName), arrReportName, ObjDta)
                Dim dlgRes As DialogResult
                dlgRes = MessageBox.Show("Exported Successfully !" & vbCrLf & "Do you want to open the file ?", "CWPlus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If dlgRes = Windows.Forms.DialogResult.Yes Then
                    Process.Start(SaveFile.FileName & ".pdf")
                End If
            End If
        End If
    End Sub


    Public Sub SendReport()
        Dim SaveFile As String = Application.StartupPath & "\CW_Report.pdf"
        If IO.File.Exists(SaveFile) Then
            IO.File.Delete(SaveFile)
        End If
        Dim ObjPdf As New CWUtility.ClsCocktailReportPDF
        ObjPdf.ExportToPdfv2(IO.Path.GetDirectoryName(SaveFile), IO.Path.GetFileNameWithoutExtension(SaveFile), arrReportName, grdCocktailReport)
        frmSendReport.Show()
    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnMailReport.Click
        SendReport()
    End Sub

    Private Sub grdCocktailReport_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCocktailReport.CellContentClick
        If grdCocktailReport.Columns(e.ColumnIndex).Name.ToLower = "edit" Then
            If Not CBool(fetchRights(StrReportName).Rows(0).Item("Edit")) Then
                MsgBox("Access Denied", MsgBoxStyle.Information, StrReportName)
                Exit Sub
            End If
            If StrReportName = "Sale" Then

                Dim ObjDt As New DataTable
                Dim ObjSaleFetchVar As New ClsSale
                Dim objSale As New FrmSaleMst()
                objSale.IsReport = True
                objSale.BillID = grdCocktailReport.Item("billid", e.RowIndex).Value
                objSale.Dtdate.Text = ""
                objSale.txtBillno.Text = ""
                ObjSaleFetchVar.LicenseID = MDI.cmbLicenseName.SelectedValue
                ObjSaleFetchVar.BillDate = grdCocktailReport.Item("Billdate", e.RowIndex).Value                              'Added By RV on 13-Sep-2019          
                ' ObjSaleFetchVar.ToDate = grdCocktailReport.Item("Billdate", e.RowIndex).Value                                 'Added By RV on 13-Sep-2019
                ObjDt = ObjSaleFetchVar.FunFetchSaleEditVar()                                'Added By RV on 13-Sep-2019

                'Added By RV on 13-Sep-2019 Starts
                If ObjDt.Rows.Count > 0 Then
                    MessageBox.Show("Cannot Edit Used in Variance")

                Else
                    objSale.MdiParent = MDI
                    objSale.Show()
                    objSale.WindowState = FormWindowState.Maximized
                End If
                'Added By RV on 13-Sep-2019 Ends
            ElseIf StrReportName = "Purchase" Then
                Dim ObjDt As New DataTable
                Dim ObjSaleFetchVar As New ClsSale
                Dim objSale As New FrmSaleMst()
                Dim objPurchase As New FrmpurchaseMst()
                objPurchase.IsReport = True
                objPurchase.PurchaseID = grdCocktailReport.Item("purchaseid", e.RowIndex).Value
                objPurchase.Dtdate.Text = grdCocktailReport.Item("purchaseDate", e.RowIndex).Value
                objPurchase.txttpno.Text = grdCocktailReport.Item("TPno", e.RowIndex).Value
                objPurchase.txtGRNForCode.Text = grdCocktailReport.Item("GRNForCode", e.RowIndex).Value               'Added By Mohammed on 29-March-2019
                objPurchase.txtInvoiceno.Text = grdCocktailReport.Item("InvoiceNo", e.RowIndex).Value

                ObjSaleFetchVar.LicenseID = MDI.cmbLicenseName.SelectedValue
                ObjSaleFetchVar.BillDate = grdCocktailReport.Item("purchaseDate", e.RowIndex).Value
                ObjDt = ObjSaleFetchVar.FunFetchSaleEditVar()                                'Added By RV on 13-Sep-2019

                ' Added By RV on 13-Sep-2019 Starts
                If ObjDt.Rows.Count > 0 Then
                    MessageBox.Show("Cannot Edit Used in Variance")

                Else
                    objPurchase.MdiParent = MDI
                    objPurchase.Show()
                    objPurchase.WindowState = FormWindowState.Maximized
                End If
                End If
            ElseIf grdCocktailReport.Columns(e.ColumnIndex).Name.ToLower = "delete" Then
                If Not CBool(fetchRights(StrReportName).Rows(0).Item("Delete")) Then
                    MsgBox("Access Denied", MsgBoxStyle.Information, StrReportName)
                    Exit Sub
                End If
                Dim Ans As String = MsgBox("Are You Sure Want To Remove", MsgBoxStyle.YesNo, StrReportName)
                If Ans = vbNo Then
                    Exit Sub
                End If
            If StrReportName = "Sale" Then
                Dim ObjDt As New DataTable
                Dim objSale As New ClsSale
                objSale.BillID = grdCocktailReport.Item("billid", e.RowIndex).Value
                objSale.UserName = gblUserName
                ' objSale.LicenseID = LicName
                objSale.LicenseID = MDI.cmbLicenseName.SelectedValue
                objSale.BillDate = grdCocktailReport.Item("Billdate", e.RowIndex).Value                            'Added By RV on 13-Sep-2019
                ' objSale.ToDate = grdCocktailReport.Item("Billdate", e.RowIndex).Value                       'Added By RV on 13-Sep-2019
                ObjDt = objSale.FunFetchSaleEditVar()                        'Added By RV on 13-Sep-2019

                'Added By RV on 13-Sep-2019 Starts
                If ObjDt.Rows.Count > 0 Then
                    MessageBox.Show("Cannot Delete Used in Variance")

                Else
                    objSale.FunDelete()
                    MsgBox(objSale.ErrorMsg)
                End If
                'Added By RV on 13-Sep-2019 Ends
            ElseIf StrReportName = "Purchase" Then
                objpurchasedet = New CWPlusBL.Master.Clspurchase
                Dim ObjDt As New DataTable
                Dim objSale As New ClsSale
                objpurchasedet.PurchaseID = grdCocktailReport.Item("purchaseid", e.RowIndex).Value
                objpurchasedet.UserName = gblUserName
                objSale.LicenseID = LicName 'Add Mohammed
                objSale.BillDate = grdCocktailReport.Item("purchaseDate", e.RowIndex).Value
                'objSale.ToDate = grdCocktailReport.Item("Billdate", e.RowIndex).Value                      
                ObjDt = objSale.FunFetchSaleEditVar()

                'Added By RV on 13-Sep-2019 Starts
                If ObjDt.Rows.Count > 0 Then
                    MessageBox.Show("Cannot Delete Used in Variance")

                Else



                    objpurchasedet.FunDelete()
                    MsgBox(objpurchasedet.ErrorMsg)
                End If
            End If
            btnok.PerformClick()
        End If
    End Sub


    ' flr6LegalFormat And flr3LegalFormat

    'Private Sub btnLegalFormat_Click(sender As System.Object, e As System.EventArgs)
    '    If Trim(txtTimeOut.Text) = "" Then
    '        txtTimeOut.Text = 30
    '    End If
    '    Dim xmldoc As New XmlDocument
    '    xmldoc.LoadXml("<Master><CocktailReports></CocktailReports></Master>")
    '    Dim XmlElt As XmlElement = xmldoc.CreateElement("Report")

    '    gblArrMDICheckedLicense.Clear()
    '    FetchMDILicenseChecked(MDI.chkLicenseName, MDI.cmbLicenseName.SelectedValue)

    '    If gblArrMDICheckedLicense.Count = 0 Then
    '        MsgBox("Please Select License")
    '        Exit Sub
    '    End If

    '    '''''''For Cocktail GroupBox 
    '    If grpCocktailReport.Visible = True Then
    '        For cnt = 0 To gblArrMDICheckedLicense.Count - 1
    '            XmlElt = xmldoc.CreateElement("Report")
    '            XmlElt.SetAttribute("LicenseID", gblArrMDICheckedLicense.Item(cnt))
    '            XmlElt.SetAttribute("CocktailReportDate", dtpCocktailReport.Text)
    '            XmlElt.SetAttribute("FromDate", GetFirstDayOfMonth(dtpCocktailReport.Value).ToString("dd-MMM-yyyy"))
    '            XmlElt.SetAttribute("ToDate", GetLastDayOfMonth(dtpCocktailReport.Value).ToString("dd-MMM-yyyy"))
    '            If chkAll.Checked = True Then
    '                XmlElt.SetAttribute("All", 1)
    '            Else
    '                XmlElt.SetAttribute("All", 0)
    '            End If
    '            XmlElt.SetAttribute("Brand", _Brand)
    '            XmlElt.SetAttribute("Category", _Category)
    '            XmlElt.SetAttribute("Size", _Size)
    '            XmlElt.SetAttribute("Cocktail", _Cocktail)
    '            xmldoc.DocumentElement.Item("CocktailReports").AppendChild(XmlElt)
    '        Next
    '        'Return xmldoc
    '    End If
    '    '''''End Cocktail GroupBox 


    '    '''''''For Purchase GroupBox 
    '    If grpPurchaseReport.Visible = True Then

    '        'For cntr = 0 To gblArrMDICheckedLicense.Count - 1
    '        XmlElt = xmldoc.CreateElement("Report")
    '        XmlElt.SetAttribute("LicenseID", Trim(GetLicenseID()))
    '        XmlElt.SetAttribute("FromDate", dtpPurFromDate.Text)
    '        XmlElt.SetAttribute("ToDate", dtpurToDate.Text)
    '        XmlElt.SetAttribute("tpNo", txtTpNo.Text)
    '        XmlElt.SetAttribute("invoiceNo", txtinvoiceNo.Text)
    '        XmlElt.SetAttribute("Brand", _Brand)
    '        XmlElt.SetAttribute("Category", _Category)
    '        XmlElt.SetAttribute("Size", _Size)
    '        XmlElt.SetAttribute("Cocktail", _Cocktail)
    '        xmldoc.DocumentElement.Item("CocktailReports").AppendChild(XmlElt)
    '        ' Next
    '        ' Return xmldoc
    '    End If
    '    '''''End Purchase  GroupBox 


    '    '''''''For Sale GroupBox 
    '    If grpSaleReport.Visible = True Then

    '        '  For cntr = 0 To gblArrMDICheckedLicense.Count - 1
    '        XmlElt = xmldoc.CreateElement("Report")
    '        XmlElt.SetAttribute("LicenseID", Trim(GetLicenseID()))
    '        XmlElt.SetAttribute("FromDate", dtSaleFromDate.Text)
    '        XmlElt.SetAttribute("ToDate", DtSaleToDate.Text)
    '        XmlElt.SetAttribute("billNo", txtBillNo.Text)
    '        XmlElt.SetAttribute("Brand", _Brand)
    '        XmlElt.SetAttribute("Category", _Category)
    '        XmlElt.SetAttribute("Size", _Size)
    '        XmlElt.SetAttribute("Cocktail", _Cocktail)
    '        xmldoc.DocumentElement.Item("CocktailReports").AppendChild(XmlElt)
    '        '   Next
    '        ' Return xmldoc
    '    End If
    '    '''''End Sale  GroupBox 

    '    '''''For Chatai Report'''''
    '    If grpChataiReportmodify.Visible = True Then
    '        '  For cntr = 0 To gblArrMDICheckedLicense.Count - 1
    '        XmlElt = xmldoc.CreateElement("Report")
    '        XmlElt.SetAttribute("LicenseID", MDI.cmbLicenseName.SelectedValue)
    '        XmlElt.SetAttribute("FromDate", dtchataiFromDate.Text)
    '        XmlElt.SetAttribute("ToDate", dtchataiToDate.Text)
    '        XmlElt.SetAttribute("Brand", _Brand)
    '        XmlElt.SetAttribute("Category", _Category)
    '        XmlElt.SetAttribute("Size", _Size)
    '        XmlElt.SetAttribute("Cocktail", _Cocktail)
    '        xmldoc.DocumentElement.Item("CocktailReports").AppendChild(XmlElt)
    '        '   Next
    '        ' Return xmldoc
    '    End If
    '    '''''End Chatai  GroupBox 
    '    xmldocString = xmldoc.InnerXml

    '    Dim StrParam As String = ""
    '    StrParam = "'" & xmldocString & "',0,''#" & LTrim(RTrim(txtTimeOut.Text))
    '    If StrReportName = "FLR6" Then
    '        GenerateReport("flr6LegalFormat", "proc#" & StrProcedureName & "#" & StrParam & IIf(StrSubReportName <> "", vbCrLf & StrSubReportName, Nothing), txtTimeOut.Text)

    '    Else
    '        GenerateReport("flr3LegalFormat", "proc#" & StrProcedureName & "#" & StrParam & IIf(StrSubReportName <> "", vbCrLf & StrSubReportName, Nothing), txtTimeOut.Text)
    '    End If


    'End Sub
End Class