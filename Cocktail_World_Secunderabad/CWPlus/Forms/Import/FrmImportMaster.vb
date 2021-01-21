Imports CWPlusBL
Imports System.Xml
Public Class FrmImportMaster

#Region "Vars"
    Dim dtHeader As DataTable
    Dim objOffice As New ClsMsOffice
    Dim objImport As ClsImport
#End Region


#Region "Common Functions"

    Sub GetSetup()
        Dim dt As DataTable
        objImport = New ClsImport
        dt = objImport.FetchImportSetup
        cmbMaster.DataSource = dt
        cmbMaster.DisplayMember = "MasterDesc"
        cmbMaster.ValueMember = "MasterID"
        ComboBindingTemplate(cmbMaster, dt, "MasterDesc", "MasterID")
        cmbMaster.SelectedValue = 0
    End Sub

    Function GenerateXMLSetup() As XmlDocument
        Dim xmldoc As New XmlDocument
        xmldoc.LoadXml("<ImportMaster><ImportSetup></ImportSetup></ImportMaster>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("ParamsDet")
        XmlElt = xmldoc.CreateElement("ParamsDet")
        XmlElt.SetAttribute("LicenseID", gblLicenseID)
        xmldoc.DocumentElement.Item("ImportSetup").AppendChild(XmlElt)
        Return xmldoc
    End Function



    Sub CreateHeaders(ProcName As String)
        objImport = New ClsImport
        dtHeader = objImport.ExportMaster(ProcName, GenerateXMLSetup)
    End Sub

    Sub ExportMaster(MasterName As String)
        Try

            Select Case MasterName
                Case "Brand"
                    'BrandMaster()

                Case Else

            End Select

        Catch ex As Exception
            dtHeader = Nothing
        End Try
    End Sub


    Dim xmlMaster As XmlDocument

    Function GenerateXmlData(dtdata As DataTable, Optional CheckForInValid As Boolean = False) As XmlDocument
        Dim xmldoc As New XmlDocument

        xmldoc.LoadXml("<ImportMaster><ImportData></ImportData></ImportMaster>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("DataDet")
        For rCtr = 0 To dtdata.Rows.Count - 1
            If CheckForInValid Then
                If CBool(dtdata.Rows(rCtr)("Invalid")) Then
                    Continue For
                End If
            End If
            XmlElt = xmldoc.CreateElement("DataDet")
            Dim ArrXmlAttr() As String = XmlAttr.Split(",")
            For strRowCtr = 0 To ArrXmlAttr.Length - 1
                XmlElt.SetAttribute(ArrXmlAttr(strRowCtr), If(IsDBNull(dtdata.Rows(rCtr)(ArrXmlAttr(strRowCtr))), "", Replace(dtdata.Rows(rCtr)(ArrXmlAttr(strRowCtr)), "'", "")))
            Next
            xmldoc.DocumentElement.Item("ImportData").AppendChild(XmlElt)
        Next
        Return xmldoc
    End Function
#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub FrmImportMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetSetup()
        cmbFileFormat.SelectedIndex = 0
    End Sub

    Dim drInfo() As DataRow
    Private Sub cmbMaster_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMaster.SelectedIndexChanged
        If Not TypeOf cmbMaster.SelectedValue Is DataRowView Then
            If Not cmbMaster.SelectedValue = 0 Then
                lnkExport.Enabled = True
                drInfo = DirectCast(cmbMaster.DataSource, DataTable).Select("MasterID=" & cmbMaster.SelectedValue)
                CreateHeaders(drInfo(0)("ExportProcName"))
                XmlAttr = drInfo(0)("XmlAttr")
            Else
                lnkExport.Enabled = False
                drInfo = Nothing
            End If
        End If
    End Sub


    Private Sub lnkExport_LinkClicked(ByVal sender As System.Object, ByVal e As EventArgs) Handles lnkExport.Click
        If Not IsNothing(dtHeader) Then
            Dim saveFiledlg As New SaveFileDialog
            Select Case cmbFileFormat.Text
                Case "Microsoft Excel 97-2003"
                    saveFiledlg.DefaultExt = ".xls"
                    objOffice.ExcelFormat = Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel8
                Case "Microsoft Excel 2007-2010"
                    saveFiledlg.DefaultExt = ".xlsx"
                    objOffice.ExcelFormat = Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel12
                Case Else
            End Select
            saveFiledlg.AddExtension = True
            If saveFiledlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                MsgBox(objOffice.ExportToExcel(IO.Path.GetDirectoryName(saveFiledlg.FileName), IO.Path.GetFileName(saveFiledlg.FileName), dtHeader))
            End If

        End If
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        If Not IsNothing(drInfo) And gblLicenseID <> 0 Then
            Dim ProcName As String = drInfo(0)("ProcName")
            Dim DlgexcelFile As New OpenFileDialog
            DlgexcelFile.InitialDirectory = Application.StartupPath
            If DlgexcelFile.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim dt As New DataTable
                Dim ObjOfc As New ExcelReader(DlgexcelFile.FileName, True, False)
                dt = GetExcelSheetData(DlgexcelFile.FileName)
                'TRIM ALL COLUMN NAMES'
                For Each cols As DataColumn In dt.Columns
                    cols.ColumnName = Trim(cols.ColumnName)
                Next

                objImport = New ClsImport
                objImport.LicenseID = gblLicenseID
                xmlMaster = GenerateXmlData(dt)
                dt = objImport.ImportMaster(ProcName, False, xmlMaster)
                ErrorRowCount = 0
                grdImportData.Rows.Clear()
                grdImportData.Columns.Clear()
                grdImportData.DataSource = Nothing
                grdImportData.ImportFromDatatable(dt)
                grdImportData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                SetDesc()
            End If
        End If
    End Sub

    Public Sub SetDesc()
        Panel1.Visible = True
        lblInfo.Text = ErrorRowCount & " Error(s) Found !" & _
            vbCrLf & grdImportData.RowCount - ErrorRowCount & " Rows will be imported."
    End Sub

    Public Function GetExcelSheetData(ByVal FileName As String) As DataTable
        Try
            Dim extension As String = LCase(IO.Path.GetExtension(FileName))
            If extension = ".xls" OrElse extension = ".xlsx" Then
                Dim db As New ExcelReader(FileName, False, False)
                GetExcelSheetData = db.GetWorksheet("Sheet1")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Dim XmlAttr As String
    Dim ErrorRowCount As Integer = 0
    Private Sub grdImportData_RowsAdded(sender As System.Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles grdImportData.RowsAdded
        If e.RowIndex >= 0 And grdImportData.ColumnCount > 1 Then
            If CBool(grdImportData("Invalid", e.RowIndex).Value) Then
                Dim grdCellStyle As New DataGridViewCellStyle
                grdCellStyle.ForeColor = Color.White
                grdCellStyle.Font = New Font("Verdana", 9.75, FontStyle.Bold)
                grdCellStyle.BackColor = Color.Red
                grdImportData.Rows(e.RowIndex).DefaultCellStyle = grdCellStyle
                ErrorRowCount += 1
            End If
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Not IsNothing(drInfo) Then
                Dim ProcName As String = drInfo(0)("ProcName")
                objImport = New ClsImport
                objImport.LicenseID = gblLicenseID
                objImport.ImportMaster(ProcName, True, GenerateXmlData(grdImportData.ToDataTable("Out", False), True))
                MessageBox.Show("Records imported successfully")
                grdImportData.Columns.Clear()
                grdImportData.Rows.Clear()
                Panel1.Visible = False
                cmbMaster.SelectedIndex = 0
            Else
                MessageBox.Show("Nothing to save !", "CWPlus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub
End Class