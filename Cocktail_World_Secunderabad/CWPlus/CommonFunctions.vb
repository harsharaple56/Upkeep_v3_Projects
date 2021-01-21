Imports System.Runtime.CompilerServices
Imports CWPlusBL.Master
Imports System.Xml
Imports System.IO

Module CommonFunctions


#Region "Global / Local Variables"
    Public gblUserID, gblLicenseID As Double
    Public gblUserName As String
    Public GblPurchaseDate As DateTime = "#1/1/1900#"
    Public GblFromDate As DateTime = "#1/1/1900#"
    Public GblToDate As DateTime = "#1/1/1900#"

    Public gloBillNo, gloBillEndNo, gblControlHeadID As Integer
    Public gblArrMDICheckedLicense As New ArrayList
    Public GblTotalCost, gblGrossTotal, gblNetTotal As Double
    Public gblQcStep2Save As String = False
    Public gblQCSTEP1SaveXMl As XmlDocument
    Public gblMenuDesc As String
    Public GblBoolNew, GblBoolEdit, GblBoolDelete As Boolean


    Public gblLicenseNameForQuickControl As String


    Public GBLDblRevenueCenterId, GblDblCheckId, GblDblAngHeadId As Double
    Public GblDtBusinessDate As Date
    Public GblStrRevenueCenterName, GblStrBillNo, GblStrDiscountType, GblStrBillUniqueId As String

    Public GblStrDiscountTypeIDVD, GblStrDiscountTypeDescVD, GblStrOldDiscountTypeOldVD, GblStrRemarkVD As String 'View Data option in ACCOR Reports VD


    Public GblFormName As String



#End Region



#Region "Functions"

    Public smtpuser As String
    Public smtpPass As String
    Public smtpHost As String
    Public smtpPort As Integer
    Public smtpFrom As String
    Public tomail As String
    Public enableSSL As Boolean
    Public Sub SendMail(Subject As String, body As String, AttachmentPath As String)
        Try
            'CHECK IF INTERNET IS AVAILABLE
            If My.Computer.Network.IsAvailable Then
                If Not My.Computer.Network.Ping("google.com", 3000) Then
                    Exit Sub
                End If
            Else
                Exit Sub
            End If
            Dim ObjMAFrom As Net.Mail.MailAddress
            Dim ObjMg As New Net.Mail.MailMessage
            ObjMg.Subject = Subject
            ObjMAFrom = New Net.Mail.MailAddress(smtpFrom)
            ObjMg.To.Add(tomail)
            ObjMg.From = ObjMAFrom
            ObjMg.Attachments.Add(New Net.Mail.Attachment(AttachmentPath))
            ObjMg.IsBodyHtml = True
            ObjMg.Body = body
            Dim smtClient As New Net.Mail.SmtpClient(smtpHost, smtpPort)
            smtClient.UseDefaultCredentials = False
            smtClient.Credentials = New Net.NetworkCredential(smtpuser, smtpPass)
            smtClient.EnableSsl = enableSSL
            Dim userState As Object = ObjMg
            smtClient.Send(ObjMg)
            Threading.Thread.Sleep(500)
            ObjMg.Dispose()
            '###################### END #####################################
            MsgBox("Report Sent Successfully", vbInformation, "::CWPlus Reporting::")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



#Region "Theming"


    Private Sub SetGridTheme(ByVal grdControl As DataGridView, ByVal foreColor As Color, ByVal backGroundColor As Color, ByVal grdColor As Color, ByVal grdSelectionBackColor As Color, ByVal grdSelectionForeColor As Color, ByVal grdAlternateBackcolor As Color)
        For Each GridCtr As Control In grdControl.Controls
            If TypeOf GridCtr Is DataGridView Then
                Dim Grid As DataGridView = DirectCast(GridCtr, DataGridView)
                Grid.BackgroundColor = backGroundColor
                Grid.CellBorderStyle = DataGridViewCellBorderStyle.Single
                Grid.GridColor = grdColor
                Grid.ForeColor = foreColor
                Grid.DefaultCellStyle.SelectionBackColor = grdSelectionBackColor
                Grid.DefaultCellStyle.SelectionForeColor = grdSelectionForeColor
                Grid.AlternatingRowsDefaultCellStyle.BackColor = grdAlternateBackcolor
            End If
        Next
    End Sub


    Public Sub AddTheme(ByVal ParentControl As Control)
        For Each txtControl As Control In ParentControl.Controls
            If TypeOf txtControl Is TextBox Or TypeOf txtControl Is ComboBox Then
                AddHandler txtControl.GotFocus, AddressOf TextGotFocus
                AddHandler txtControl.LostFocus, AddressOf TextLostFocus
            End If
        Next
    End Sub


    'SET FOCUS COLOR OF TEXTBOX
    Private Sub TextGotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim tmpText As Control = DirectCast(sender, Control)
        tmpText.BackColor = Color.Lavender
    End Sub

    'SET LOST FOCUS COLOR OF TEXTBOX
    Private Sub TextLostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim tmpText As Control = DirectCast(sender, Control)
        tmpText.BackColor = Color.White
    End Sub

#End Region


    '#######################################

    '   CRYSTAL REPORT GENERATION

    '#######################################
    ''' <summary>
    ''' This function is used to call the Report Viewer
    ''' </summary>
    ''' <param name="ReportName">Enter the rpt file name</param>
    ''' <param name="ConnectionString">Enter database connection string</param>
    ''' <param name="QueryOrProcName">Enter Sql query or Procedure name</param>
    ''' <remarks></remarks>
    Public Sub GenerateReport(ByVal ReportName As String, ByVal QueryOrProcName As String, Optional ByVal TimeOut As Integer = 30)
        ' Dim strContent, ConnectionString As String
        Dim strContent As String
        Dim ConnectionString As String = Configuration.ConfigurationManager.ConnectionStrings("StrSqlConn").ConnectionString
        Try
            ConnectionString = ConnectionString & ";Connect Timeout=" & TimeOut
            Dim rptDataPath As String = IO.Path.Combine(Application.StartupPath, "ReportData.txt")
            strContent = ReportName & vbCrLf
            strContent &= ReportName & vbCrLf
            strContent &= ConnectionString & vbCrLf
            strContent &= QueryOrProcName
            IO.File.WriteAllText(rptDataPath, strContent)
            Process.Start(IO.Path.Combine(Application.StartupPath, "ReportViewer.exe"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub




    '#######################################

    '   DUMP LICENSE / VALIDATION 

    '#######################################

    Private Function IsDumped() As Boolean
        Dim regKey As Microsoft.Win32.RegistryKey
        regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\CWPlus")
        Dim Value As Integer = regKey.GetValue("IsRegistered")
        If Value = 0 Or Value = 1 Then
            Return CBool(Value)
        Else
            Return False
        End If
    End Function

    Public Function DumpLicenkey() As DataSet
        DumpLicenkey = Nothing
        Try
            Dim flDialog As New OpenFileDialog
            flDialog.Filter = "XML File(*.xml)|*.xml"
            flDialog.FilterIndex = 0
            flDialog.Title = "Select License File"
            flDialog.FileName = "LicenseDetails.xml"
            If flDialog.ShowDialog = DialogResult.OK Then
                Dim strLicenseDetails As String = encrypt.Decrypt(IO.File.ReadAllText(flDialog.FileName))
                Dim DecryptedByte() As Byte = System.Text.ASCIIEncoding.ASCII.GetBytes(strLicenseDetails)
                Dim ms As New IO.MemoryStream(DecryptedByte)
                Dim dsXml As New DataSet
                dsXml.ReadXml(ms)
                Return dsXml
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub ExportExcelTemplate(ByVal ParamArray DTable() As Data.DataTable)
        Try
            'If Not ObjDt.Rows.Count > 0 Or IsNothing(ObjDt) Then
            '    MsgBox("There is no data to export", MsgBoxStyle.Information, "CWPlus")
            'End If
            'If ObjDt.Rows.Count > 0 Then
            Dim dlgSaveFile As New SaveFileDialog
            dlgSaveFile.DefaultExt = ".xls"
            dlgSaveFile.Filter = "Excel Files (*.xls) | *.xls"
            If dlgSaveFile.ShowDialog = Windows.Forms.DialogResult.OK Then
                If IO.File.Exists(dlgSaveFile.FileName) Then
                    IO.File.Delete(dlgSaveFile.FileName)
                End If
                Dim ObjExp As New ClsMsOffice
                ObjExp.ExportToExcel(IO.Path.GetDirectoryName(dlgSaveFile.FileName), IO.Path.GetFileName(dlgSaveFile.FileName), DTable)
                Dim dlgRes As DialogResult
                dlgRes = MessageBox.Show("Exported Successfully !" & vbCrLf & "Do you want to open the file ?", "CWPlus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If dlgRes = Windows.Forms.DialogResult.Yes Then
                    Process.Start(dlgSaveFile.FileName)
                End If
            End If
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub




    Public Sub MakeIDColumnsHide(ByVal grd As DataGridView)


        For index = 0 To grd.ColumnCount - 1
            If grd.Columns(index).Name.ToLower.Contains("id") And Not (grd.Columns(index).Name.ToLower.Contains("valid")) Then
                grd.Columns(index).Visible = False
            End If
        Next
    End Sub

    Public Sub ComboBindingTemplate(ByVal cmb As ComboBox, ByVal dt As DataTable, ByVal dispfield As String, ByVal valuefield As String)
        cmb.DataSource = Nothing
        With cmb
            .DataSource = BindCombo(dt, valuefield, dispfield)
            .DisplayMember = dispfield
            .ValueMember = valuefield
        End With
    End Sub

    Public Function BindCombo(ByVal SrcData As DataTable, ByVal ValueField As String, ByVal DisplayField As String) As DataTable
        Dim dr As DataRow
        dr = SrcData.NewRow
        dr(DisplayField) = "--Select--"
        dr(ValueField) = "0"
        SrcData.Rows.InsertAt(dr, 0)
        Return SrcData
    End Function
    Public Sub MakeBold(ByVal vNode As TreeNode, ByVal fnt As FontStyle)
        If IsNothing(vNode) Then Exit Sub
        If Not vNode.Parent Is Nothing Then
            vNode.Parent.NodeFont = New Font("Verdana", 8, fnt)
        Else
            Exit Sub
        End If
        If Not vNode.Parent.Parent Is Nothing Then
            vNode.Parent.Parent.NodeFont = New Font("Verdana", 8, fnt)
        End If
    End Sub

    Public Sub OpenForm(ByVal vNode As TreeNode, Optional ByVal IsMenuClicked As Boolean = True)
        If IsNothing(vNode) Then Exit Sub
        MakeBold(vNode, FontStyle.Bold)
        vNode.ForeColor = Color.DarkGreen
        If vNode.Nodes.Count > 0 Then Exit Sub
        Dim ChildForm As New Form
        Dim vIsForm As Boolean = True
        If vNode Is Nothing OrElse vNode.Parent Is Nothing Then
            Exit Sub
        End If
        If vNode.Tag = "" Then
            gblMenuDesc = LCase(vNode.Text)
        Else
            gblMenuDesc = LCase(vNode.Tag)
        End If



        'If LCase(vNode.Parent.Text) = "master" Then
        If LCase(vNode.Text) = "supplier" Then
            ChildForm = frmSupplier
        ElseIf LCase(vNode.Text) = "categorysizelinkup" Then
            ChildForm = FrmCategorySizelinlup
        ElseIf LCase(vNode.Text) = "category" Then
            ChildForm = FrmCategorySizelinlup
        ElseIf LCase(vNode.Text) = "size" Then
            ChildForm = FrmSize
        ElseIf LCase(vNode.Text) = "categorytax" Then
            ChildForm = FrmCategoryTax
        ElseIf LCase(vNode.Text) = "brand" Then
            ChildForm = frmBrand
        ElseIf LCase(vNode.Text) = "financial year" Then
            ChildForm = frmFinancialYear
        ElseIf LCase(vNode.Text) = "opening stock" Then
            ChildForm = frmBrandOpening
        ElseIf LCase(vNode.Text) = "assign mms code" Then
            ChildForm = frmAssignMMSBrandCode
        ElseIf LCase(vNode.Text) = "import master" Then
            ChildForm = FrmImportMaster
        ElseIf LCase(vNode.Text) = "permit type" Then
            ChildForm = FrmSS_PermitTypeMaster
        ElseIf LCase(vNode.Text) = "permit holder" Then
            ChildForm = FrmPermitHolderMaster
        ElseIf LCase(vNode.Text) = "user" Then
            ChildForm = FrmUserMaster
        ElseIf LCase(vNode.Text) = "assign brand code" Then
            ChildForm = frmAssignBrandCode
        ElseIf LCase(vNode.Text) = "user menu rights" Then
            ChildForm = FrmUserMenuRights
        ElseIf LCase(vNode.Text) = "cocktail" Then
            ChildForm = FrmCocktail
        ElseIf LCase(vNode.Text) = "assign cocktail code" Then
            ChildForm = FrmAssignCocktailCode

        ElseIf LCase(vNode.Text) = "userlicense" Then
            ChildForm = FrmUserLicense
        ElseIf LCase(vNode.Text) = "license" Then
            ChildForm = FrmLicenseList
        ElseIf LCase(vNode.Text) = "a&g fields" Then
            ChildForm = frmDiscount
        ElseIf LCase(vNode.Text) = "designation" Then
            ChildForm = frmDesignation
        ElseIf LCase(vNode.Text) = "billbook" Then
            ChildForm = FrmBillBook

        ElseIf LCase(vNode.Text) = "interfacefilesetup" Then
            ChildForm = FrmInterfaceFileSetUp

        ElseIf LCase(vNode.Text) = "consumption" Then
            ChildForm = FrmConsumption


        ElseIf LCase(vNode.Text) = "purmst" Then
            ChildForm = FrmpurchaseMst

        ElseIf LCase(vNode.Text) = "licensetransactiondetails" Then
            ChildForm = FrmLicenseTransactionDetails

        ElseIf LCase(vNode.Text) = "catmst" Then
            ChildForm = FrmCategory
        ElseIf LCase(vNode.Text) = "salemst" Then
            ChildForm = FrmSaleMst
            If IsMenuClicked Then
                GblPurchaseDate = "#1/1/1900#"
            End If
        ElseIf LCase(vNode.Text) = "sub category" Then
            ChildForm = Frm_SubCategoryMaster
        ElseIf LCase(vNode.Text) = "purchase" Then
            ChildForm = FrmPurchasedetail
        ElseIf LCase(vNode.Text) = "autobilling" Then
            ChildForm = FrmAutobilling
            If IsMenuClicked Then
                GblPurchaseDate = "#1/1/1900#"
            End If
        ElseIf LCase(vNode.Text) = "transfer" Then
            ChildForm = FrmTransferList
        ElseIf LCase(vNode.Text) = "transfermst" Then
            ChildForm = FrmTransfer

        ElseIf LCase(vNode.Text) = "licensetransfer" Then
            ChildForm = Frm_LicenseTransfer

        ElseIf LCase(vNode.Text) = "sale" Then
            ChildForm = FrnSaleList
        ElseIf LCase(vNode.Text) = "interface file" Or LCase(vNode.Text) = "sale interface" Then
            ChildForm = frmInterFaceFileSale
        ElseIf LCase(vNode.Text) = "wash day" Then
            ChildForm = frmWashDay

        ElseIf LCase(vNode.Text) = "bulkliterreport" Then
            ChildForm = FrmBulkLiterReport

        ElseIf LCase(vNode.Text) = "flr3" Or LCase(vNode.Text) = "flr6" Or LCase(vNode.Text) = "flr4" Or LCase(vNode.Text) = "chatai" Or LCase(vNode.Text) = "purchase report" Or LCase(vNode.Text) = "sale report" Then
            If FrmCocktailReport.IsMdiChild Then
                FrmCocktailReport.Close()
            End If
            ChildForm = FrmCocktailReport
        ElseIf LCase(vNode.Text) = "flr1a" Then
            ChildForm = frmFLR1A
        ElseIf LCase(vNode.Text) = "flr9" Then
            ChildForm = frmFLR1A


        ElseIf LCase(vNode.Text) = "brand code" Then
            ChildForm = frmBrandCodeReport
            '************** Added By RV on 18-MARCH-2019 ***********************************
        ElseIf LCase(vNode.Text) = "mmscode report" Then
            ChildForm = frmMMSCodeReport
            '*************** ENDS ***************************************
        ElseIf LCase(vNode.Text) = "cocktail report" Then
            ChildForm = FrmCocktailDescReport
        ElseIf LCase(vNode.Text) = "brand summary closin" Then
            ChildForm = frmBrandSummaryClosing
        ElseIf LCase(vNode.Text) = "base quantity" Then
            ChildForm = frmBaseQuantityReport
        ElseIf LCase(vNode.Text) = "optimum quantity" Then
            ChildForm = FrmOptimumQtyReport
        ElseIf LCase(vNode.Text) = "brandlist" Then
            ChildForm = frmBrandlist
        ElseIf LCase(vNode.Text) = "cocktail code" Then
            ChildForm = frmCocktailCodeReport
        ElseIf LCase(vNode.Text) = "cocktail sale" Then
            ChildForm = frmCocktailSaleReport
        ElseIf LCase(vNode.Text) = "monthly" Then
            ChildForm = FrmKarnatakMonthly
        ElseIf LCase(vNode.Text) = "form-7b(daily)" Or LCase(vNode.Text) = "brandwise" Then
            If FrmApBanglore.IsMdiChild Then
                FrmApBanglore.Close()
            End If
            ChildForm = FrmApBanglore
        ElseIf LCase(vNode.Text) = "outlet stock" Then
            If FrmApBanglore.IsMdiChild Then
                FrmApBanglore.Close()
            End If
            ChildForm = FrmApBanglore

            ''Ap6BReport

        ElseIf LCase(vNode.Text) = "form r-6b(daily)" Then
            If FrmApBanglore.IsMdiChild Then
                FrmApBanglore.Close()
            End If
            ChildForm = FrmApBanglore


            ''Delhi REport
        ElseIf LCase(vNode.Text) = "brandwise(daily)" Then
            If FrmApBanglore.IsMdiChild Then
                FrmApBanglore.Close()
            End If
            ChildForm = FrmApBanglore


        ElseIf LCase(vNode.Text) = "transfer report" Then
            If FrmTransferReport.IsMdiChild Then
                FrmTransferReport.Close()
            End If
            ChildForm = FrmTransferReport

        ElseIf LCase(vNode.Text) = "brand opening" Then
            If FrmTransferReport.IsMdiChild Then
                FrmTransferReport.Close()
            End If
            ChildForm = FrmOpeningStockList

        ElseIf LCase(vNode.Text) = "parameter" Then
            ChildForm = FrmParameter
        ElseIf LCase(vNode.Text) = "department" Then
            ChildForm = frmDeptMaster
        ElseIf LCase(vNode.Text) = "schedule variance" Then
            ChildForm = frmScheduleVariance
        ElseIf LCase(vNode.Text) = "merge period" Then
            ChildForm = frmMergePeriodMaster
        ElseIf LCase(vNode.Text) = "menu engineering" Then
            ChildForm = frmMenuEngineering
        ElseIf LCase(vNode.Text) = "manage variance" Then
            ChildForm = FrmManageVariance
        ElseIf LCase(vNode.Text) = "manage controls" Then
            ChildForm = FrmQuickControls
        ElseIf LCase(vNode.Text) = "general setup" Then
            ChildForm = frmGeneralSetup
        ElseIf LCase(vNode.Text) = "purchase interface" Then
            ChildForm = frmInterfaceFilePurchase
        ElseIf LCase(vNode.Text) = "transfer interface" Then
            ChildForm = frmInterfaceFileTransfer
        ElseIf LCase(vNode.Text) = "transfer purchase" Then  'updated by abhijeet for purchase transfer on 18June2016
            ChildForm = frmTransferPurchase
        ElseIf LCase(vNode.Text) = "one day permit" Then
            ChildForm = frmOneDayPermitNumber
        ElseIf LCase(vNode.Text) = "assign one day permit" Then
            ChildForm = frmAssignOneDayPermitSale
        ElseIf LCase(vNode.Text) = "cost valuation" Then
            ChildForm = FrmCostValuationReport
        ElseIf LCase(vNode.Text) = "consumption history" Then
            ChildForm = frmCostingVerification
        ElseIf LCase(vNode.Text) = "store stock" Then
            ChildForm = Frm_StoreStock 'Frm_DailyBarStock
        ElseIf LCase(vNode.Text) = "non-moving" Then
            ChildForm = frmNonMovingBrands
        ElseIf LCase(vNode.Text) = "slow-moving" Then
            ChildForm = frmSlowMovingBrands
        ElseIf LCase(vNode.Text) = "flr3 (rack)" Then
            ChildForm = FrmFLR3RackOutletReport
        ElseIf LCase(vNode.Text) = "flr3 chatai (rack)" Then
            ChildForm = FrmChataiRackOutletReport
        ElseIf LCase(vNode.Text) = "flr4 (rack)" Then
            ChildForm = FrmFLR4RackOutletReport
        ElseIf LCase(vNode.Text) = "migration" Then
            ChildForm = FrmMigration_cw2
        ElseIf LCase(vNode.Text) = "cashmemo" Then
            ChildForm = frmcashmemo
        ElseIf LCase(vNode.Text) = "dcc report" Then 'Accor report
            'commented by sachn j for dashboard testing
            'ChildForm = FrmDCC_REPORT
            'ChildForm = Frm_Dashboard
            ChildForm = FrmDailyRevenue
        ElseIf LCase(vNode.Text) = "daily revenue consolidated" Then 'Accor report
            ChildForm = FrmDailyRevenue
        ElseIf LCase(vNode.Text) = "void discount summary" Then 'Accor report
            ChildForm = FrmVoidDiscSummary
        ElseIf LCase(vNode.Text) = "a&g entertainment summary" Then 'Accor report
            ChildForm = FrmAGEntSummary
        ElseIf LCase(vNode.Text) = "discount summary day wise" Then 'Accor report
            ChildForm = FrmDiscSummaryDaywise
        ElseIf LCase(vNode.Text) = "beverage reconciliation" Then 'Accor report
            ChildForm = FrmBeverageReconciliation
        ElseIf LCase(vNode.Text) = "a&g" Then 'Accor report
            ChildForm = FrmOfficerMeal
        ElseIf LCase(vNode.Text) = "view data (sales transaction)" Then 'Accor report
            ChildForm = FrmViewDatav2
        ElseIf LCase(vNode.Text) = "search" Then 'Accor report
            ChildForm = frmSearch
        ElseIf LCase(vNode.Text) = "cost vs sale" Then 'Accor report
            ChildForm = FrmCostvsSales
        ElseIf LCase(vNode.Text) = "food cost report" Then 'Accor report
            ChildForm = FrmFoodCostReport
        ElseIf LCase(vNode.Text) = "brandwise(monthly)" Then 'Accor report
            ChildForm = frmBrandwise_Monthly_
        ElseIf LCase(vNode.Text) = "brandwise comparison" Then
            ChildForm = FrmBrandwiseComparison
        ElseIf LCase(vNode.Text) = "brand summary" Or LCase(vNode.Text) = "Stock in Hand" Then 'Accor report
            ChildForm = frmBrandSummary
        ElseIf LCase(vNode.Text) = "drr" Then
            ChildForm = frmDRRSale
        ElseIf LCase(vNode.Text) = "split check" Then
            ChildForm = FrmSplitChecks
        ElseIf LCase(vNode.Text) = "accor adv statement" Then
            ChildForm = FrmAccorAdvStatment
        ElseIf LCase(vNode.Text) = "accor adv membership" Then
            ChildForm = FrmAccorAdvMembership
        ElseIf LCase(vNode.Text) = "beverage cost" Then
            ChildForm = FrmBeverageCost
        ElseIf LCase(vNode.Text) = "tobacco cost" Then
            ChildForm = FrmTobaccoCost
        ElseIf LCase(vNode.Text) = "eval license" Then
            ChildForm = frmEvalLicense
        ElseIf LCase(vNode.Text) = "food to beverage items" Then
            ChildForm = frmMenuItem
        ElseIf LCase(vNode.Text) = "eval department" Then
            ChildForm = FrmEvalDepartment
        ElseIf LCase(vNode.Text) = "generate interface" Then
            ChildForm = FrmGenerateInterfaceClient
        ElseIf LCase(vNode.Text) = "eval pack setup" Then
            ChildForm = FrmEvalGeneralSetup
        ElseIf LCase(vNode.Text) = "bulk litre" Then
            ChildForm = FrmKarnatakBulkBeer
        ElseIf LCase(vNode.Text) = "abstract report" Then
            ChildForm = frmAbstractReport
        ElseIf LCase(vNode.Text) = "beverage reconsile comments" Then
            ChildForm = frmBeverageReconComment
        ElseIf LCase(vNode.Text) = "beverage reconsile inputs" Then
            ChildForm = frmBeverageReconInputs
        ElseIf LCase(vNode.Text) = "par stock master" Then
            ChildForm = FrmParStockMst
        ElseIf LCase(vNode.Text) = "audit report" Then
            ChildForm = FrmAuditReport
        ElseIf LCase(vNode.Text) = "par stock report" Then
            ChildForm = FrmParStockReport
        ElseIf LCase(vNode.Text) = "ang detailed" Then
            ChildForm = FrmAnGDetailed
        ElseIf LCase(vNode.Text) = "cost report" Then
            ChildForm = FrmMasterCost
        ElseIf LCase(vNode.Text) = "drr sale" Or LCase(vNode.Text) = "opera trial balance" Then
            ChildForm = FrmSaveDRR
        ElseIf LCase(vNode.Text) = "mr department" Then
            ChildForm = Frm_MR_Department

        ElseIf LCase(vNode.Text) = "mr a&g fileds" Then
            ChildForm = frm_MR_AnGMst

        ElseIf LCase(vNode.Text) = "mr void and discount" Then
            ChildForm = Frm_MR_VoidDiscSummary
        ElseIf LCase(vNode.Text) = "mr a&g" Then
            ChildForm = FrmOfficerMeal
        ElseIf LCase(vNode.Text) = "top sheet" Then
            ChildForm = FrmDCC_TopSheetREPORTMR
        ElseIf LCase(vNode.Text) = "cover statement" Then
            ChildForm = FrmDCC_CoverREPORT
        ElseIf LCase(vNode.Text) = "daily revenue summary" Then
            ChildForm = FrmDCC_REPORTMR
        ElseIf LCase(vNode.Text) = "mr designation" Then
            ChildForm = frmMRDesignation

        ElseIf LCase(vNode.Text) = "license wise summary" Then
            ChildForm = FrmLicenseWiseSummery

        ElseIf LCase(vNode.Text) = "report settings" Then
            ChildForm = FrmSaveMajorType 'FrmSaveFamilyType

        ElseIf LCase(vNode.Text) = "food beverage statistics" Then
            ChildForm = FrmFoodBevStats
        ElseIf LCase(vNode.Text) = "kolkatta" Then
            ChildForm = Frm_DailyAccountkolkatta

        End If
        'Else
        'vIsForm = False
        'End If


        'OPEN FORM
        If vIsForm Then
            ChildForm.Tag = vNode
            ChildForm.MdiParent = MDI
            ChildForm.Text = vNode.Text

            ChildForm.Show()
            If Not ChildForm.WindowState = FormWindowState.Maximized Then
                ChildForm.WindowState = FormWindowState.Maximized
            End If
        End If

    End Sub


    Sub SaveVoid(ByVal VoidID As Double, ByVal fromDate As Date, ByVal ToDate As Date, ByVal VoidDt As DataTable, ByVal Type As Integer)
        Dim ObjClsVoid As New ClsVoid
        Try
            Dim mem As New MemoryStream
            VoidDt.WriteXml(mem, XmlWriteMode.WriteSchema, False)
            mem.Position = 0
            Dim sr As New StreamReader(mem)

            ObjClsVoid.VoidID = VoidID
            ObjClsVoid.Fromdate = fromDate
            ObjClsVoid.ToDate = ToDate
            ObjClsVoid.VoidXml = sr.ReadToEnd()
            ObjClsVoid.Type = Type
            ObjClsVoid.UserName = gblUserName
            ObjClsVoid.FunSave()
            MsgBox(ObjClsVoid.ErrorMsg)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SaveMRVoid(ByVal VoidID As Double, ByVal fromDate As Date, ByVal ToDate As Date, ByVal VoidDt As DataTable, ByVal Type As Integer)
        Dim ObjClsVoid As New ClsVoid
        Try
            Dim mem As New MemoryStream
            VoidDt.WriteXml(mem, XmlWriteMode.WriteSchema, False)
            mem.Position = 0
            Dim sr As New StreamReader(mem)

            ObjClsVoid.VoidID = VoidID
            ObjClsVoid.Fromdate = fromDate
            ObjClsVoid.ToDate = ToDate
            ObjClsVoid.VoidXml = sr.ReadToEnd()
            ObjClsVoid.Type = Type
            ObjClsVoid.UserName = gblUserName
            ObjClsVoid.FunSave()
            MsgBox(ObjClsVoid.ErrorMsg)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    <Extension()> _
    Public Sub ImportFromDatatable(GridControl As DataGridView, DatatableObject As DataTable)
        For Each cl As DataColumn In DatatableObject.Columns
            GridControl.Columns.Add(cl.ColumnName, cl.ColumnName)
        Next

        For Each dr As DataRow In DatatableObject.Rows
            GridControl.Rows.Add(dr.ItemArray)
        Next
    End Sub


    <Extension()> _
    Public Function ToDataTable(ByVal GridControl As DataGridView, ByVal TableName As String, Optional ByVal AllowHiddenColumn As Boolean = True) As DataTable
        Dim tmpDt As New DataTable(TableName)
        For Each cl As DataGridViewColumn In GridControl.Columns
            'CHECK TO ADD ONLY DISPLAYED COLUMNS OF DATAGRIDVIEW
            If Not AllowHiddenColumn Then
                If cl.Visible Then
                    tmpDt.Columns.Add(cl.Name)
                End If
            Else
                tmpDt.Columns.Add(cl.Name)
            End If
        Next

        Dim row As DataRow
        'Now Iterate thru Datagrid and create the data row
        For Each dr As DataGridViewRow In GridControl.Rows
            'Iterate thru datagrid
            row = tmpDt.NewRow 'Create new row
            'SEPERATE COUNTER TO MAINTAIN COLUMN INDEX
            Dim dtColumnCounter As Integer = 0
            For cn As Integer = 0 To GridControl.ColumnCount - 1
                If Not AllowHiddenColumn Then
                    If GridControl.Columns(cn).Visible Then
                        row.Item(dtColumnCounter) = dr.Cells(cn).FormattedValue
                        dtColumnCounter += 1
                    End If
                Else
                    row.Item(dtColumnCounter) = dr.Cells(cn).FormattedValue
                    dtColumnCounter += 1
                End If
            Next
            'Now add the row to Datarow Collection
            If IsDBNull(row.Item(0)) Then Continue For
            tmpDt.Rows.Add(row)
        Next
        Return tmpDt
    End Function


    Public Function DrpSelect(ByVal datatable As DataTable, ByVal ValueField As Integer, ByVal Dispfield As String)




    End Function


    Public Function FetchMDILicenseChecked(ByVal chkBox As CheckedListBox, ByVal SingleValue As String) As Boolean
        gblArrMDICheckedLicense.Clear()
        FetchMDILicenseChecked = False

        If chkBox.CheckedItems.Count > 0 Then
            gblArrMDICheckedLicense.Clear()
            For chkCtr = 0 To chkBox.CheckedItems.Count - 1
                If Not DirectCast(chkBox.CheckedItems(chkCtr), System.Data.DataRowView).Row.ItemArray(0) = 0 Then
                    gblArrMDICheckedLicense.Add(DirectCast(chkBox.CheckedItems(chkCtr), System.Data.DataRowView).Row.ItemArray(0))
                End If
                'gblArrMDICheckedLicense.Add(MDI.chkLicenseName.CheckedItems(chkCtr))
            Next

        Else

            If Not IsNothing(SingleValue) Then
                gblArrMDICheckedLicense.Add(SingleValue)
            End If
        End If
        Return True

    End Function


    ''' <summary>
    ''' This Function IS used to fetch Current Bill NO..
    ''' We have to add (+1) in Current Bill No ..
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FetchCurrentBillNumber() As Integer
        FetchCurrentBillNumber = False
        Dim ObjCurrentBill As New ClsAutobilling
        Dim ObjDt As New DataTable

        Try
            ObjCurrentBill.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjDt = ObjCurrentBill.FunFetchCurrentBill()
            If ObjDt.Rows.Count > 0 Then
                gloBillNo = ObjDt.Rows(0).Item("CurrentBillNo").ToString()
                gloBillEndNo = ObjDt.Rows(0).Item("BillEndNo").ToString()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            If IsNothing(ObjCurrentBill) = False Then
                ObjCurrentBill = Nothing
            End If
            If IsNothing(ObjDt) = False Then
                ObjDt = Nothing
            End If

        End Try
    End Function

    Public Function fetchRights(ByVal Menu As String) As DataTable
        Dim ObjCls As New ClsCocktailReports
        Try
            ObjCls.MenuDesc = Menu
            Return ObjCls.FunFetchMenuUserRights(gblUserID)
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(ObjCls) = False Then
                ObjCls = Nothing
            End If
        End Try
    End Function

    Public Sub AssignRights(ByVal StrLocMenuDesc As String)
        GblBoolNew = False
        GblBoolEdit = False
        GblBoolDelete = False
        Dim ObjDt As New DataTable
        Dim ObjCls As New ClsCocktailReports
        Try
            ObjCls.MenuDesc = StrLocMenuDesc
            ObjDt = ObjCls.FunFetchMenuUserRights(gblUserID)
            GblBoolNew = ObjDt.Rows(0).Item("New")
            GblBoolEdit = ObjDt.Rows(0).Item("Edit")
            GblBoolDelete = ObjDt.Rows(0).Item("Delete")
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(ObjDt) = False Then
                ObjDt = Nothing
            End If
            If IsNothing(ObjCls) = False Then
                ObjCls = Nothing
            End If
        End Try
    End Sub


#End Region





End Module