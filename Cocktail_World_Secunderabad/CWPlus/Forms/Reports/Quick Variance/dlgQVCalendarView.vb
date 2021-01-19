Imports System.Windows.Forms.Calendar
Imports CWPlusBL

Public Class dlgQVCalendarView
    Dim ObjSchVar As CWPlusBL.Master.ClsScheduleVariance
    Dim objlicense As CWPlusBL.Master.Utitity
    Dim objDt As DataTable
    Private _dtVariance As DataSet
    Public Property dtVariance() As DataSet
        Get
            Return _dtVariance
        End Get
        Set(ByVal value As DataSet)
            _dtVariance = value
        End Set
    End Property


    Public Sub New(ByVal dt As DataSet)

        ' This call is required by the designer.
        InitializeComponent()

        'Initialize values for Month and Year
        _dtVariance = dt
    End Sub

    Dim loaded As Boolean = False
    Dim vardate As Date
    Public Sub BindCalandar(ByVal dt As DataSet)
        Calendar1.Items.Clear()
        loaded = False
        vardate = Date.Parse("1/" & txtMonth.Text & "/" & txtYear.Text)
        Dim objQV = New ClsQuickExcess
        objQV.Month = vardate.Month
        objQV.Year = vardate.Year
        objQV.FromDate = Now.Date
        objQV.ToDate = Now.Date
        '[+][14/09/2019][Ajay Prajapati]
        objQV.LicenseID = cmbLicense.SelectedValue
        '[-][14/09/2019][Ajay Prajapati]
        dt = objQV.FetchVarianceDatewise

        '[+][14/09/2019][Ajay Prajapati]
        'If dt.Tables(0).Rows.Count > 0 Then
        '    MainModule.License_ID = Convert.ToDouble(dt.Tables(0).Rows(0)("LicenseID"))
        '    MainModule.VarianceDate = Convert.ToDateTime(dt.Tables(0).Rows(0)("VarDate"))
        'End If
        '[-][14/09/2019][Ajay Prajapati]


        Try
            Calendar1.ViewStart = vardate
            Calendar1.ViewEnd = vardate.AddDays(vardate.DaysInMonth(txtYear.Text, vardate.Month))
        Catch ex As Exception
            Calendar1.ViewEnd = vardate.AddDays(vardate.DaysInMonth(txtYear.Text, vardate.Month))
            Calendar1.ViewStart = vardate
        End Try
        ' Add any initialization after the InitializeComponent() call.
        Dim dtQV As DataTable = dt.Tables(0)
        Dim dtQC As DataTable = dt.Tables(1)
        'ADD QUICK VARIANCE

        'By Shiva

        '  If dtQV.Rows.Count <= 0 Then Exit Sub

        'End Shiva
        For rCtr = 0 To dtQV.Rows.Count - 1
            Dim cl As New CalendarItem(Calendar1, CDate(dtQV.Rows(rCtr)("vardate")), CDate(dtQV.Rows(rCtr)("vardate")).AddHours(12), dtQV.Rows(rCtr)("LicenseDesc"))
            cl.ApplyColor(Color.Green)

            Calendar1.Items.Add(cl)
        Next

        'ADD QUICK CONTROLS 
        If dtQC.Rows.Count <= 0 Then Exit Sub
        For rCtr = 0 To dtQC.Rows.Count - 1
            Dim cl As New CalendarItem(Calendar1, CDate(dtQC.Rows(rCtr)("vardate")), CDate(dtQC.Rows(rCtr)("vardate")).AddHours(12), dtQC.Rows(rCtr)("LicenseDesc"))
            cl.ApplyColor(Color.Yellow)

            Calendar1.Items.Add(cl)
        Next

        loaded = True
    End Sub

    Public Sub AssignSchedule(ByVal dt As DataTable)
        BindCalandar(_dtVariance)
        Dim vCurMnth As Date
        vCurMnth = New DateTime(txtYear.Text, mnthCtr + 1, 1)

        For index = 0 To dt.Rows.Count - 1
            Dim vStartDate As Date = dt.Rows(index)("startdate")
            Dim vAddDays As Integer = dt.Rows(index)("repeat")


            If vStartDate >= vCurMnth Then
                AddScheduleToCalendar(vStartDate, vAddDays)
            ElseIf vStartDate < vCurMnth Then
                Dim vDiff As Integer = DateDiff(DateInterval.Day, vStartDate, vCurMnth)
                Dim vCtr As Integer = vDiff Mod vAddDays
                Dim dtMod As Date
                If vAddDays = 1 Then
                    dtMod = vCurMnth
                Else
                    dtMod = vCurMnth.AddDays(vAddDays - vCtr)
                End If

                AddScheduleToCalendar(dtMod, vAddDays)
            End If
        Next

    End Sub


    Public Sub AddScheduleToCalendar(ByVal vDate As Date, ByVal vDays As Integer)
        Dim chk As Boolean = True

        While chk
            If vDate.Month = mnthCtr + 1 And vDate.Year = txtYear.Text Then
                Dim cl As New CalendarItem(Calendar1, vDate, vDate.AddHours(12), "Expected Schedule")
                cl.ApplyColor(Color.Red)
                Calendar1.Items.Add(cl)
                vDate = vDate.AddDays(vDays)
            Else
                chk = False
            End If
        End While
    End Sub

    Private Sub BindLicense()
        Try
            objlicense = New CWPlusBL.Master.Utitity
            objDt = New DataTable
            objlicense.UserID = gblUserID
            objDt = objlicense.FunFetchLicenseByRights
            cmbLicense.DataSource = Nothing
            ComboBindingTemplate(cmbLicense, objDt, "LicenseDesc", "LicenseID")


            If MDI.cmbLicenseName.SelectedValue = 0 Then
                gblLicenseID = 0
            Else
                cmbLicense.SelectedValue = gblLicenseID

            End If


        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            If Not IsNothing(objlicense) Then
                objlicense = Nothing
            End If
            If Not IsNothing(objDt) Then
                objDt = Nothing
            End If
        End Try
    End Sub

    Private Sub Calendar1_ItemCreating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.Calendar.CalendarItemCancelEventArgs) Handles Calendar1.ItemCreating
        e.Cancel = True
        GblPurchaseDate = e.Item.Date
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    Private Sub Calendar1_ItemDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.Calendar.CalendarItemEventArgs) Handles Calendar1.ItemDoubleClick
        'Added by sachin j on 28 Feb 2013
        'MsgBox(e.Item.Date)
        GblPurchaseDate = e.Item.Date
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Calendar1_LoadItm(ByVal sender As System.Object, ByVal e As System.Windows.Forms.Calendar.CalendarLoadEventArgs)
        If loaded Then
            BindCalandar(_dtVariance)
        End If
    End Sub


    Dim mnthCtr As Integer = 0
    Private Sub btnNext_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnNext.ClickButtonArea
        mnthCtr += 1
        If mnthCtr = txtMonth.AutoCompleteCustomSource.Count Then mnthCtr = 0
        txtMonth.Text = txtMonth.AutoCompleteCustomSource.Item(mnthCtr)

        If Not cmbLicense.SelectedValue = 0 Then
            'FetchSchedule()
        End If
    End Sub

    Private Sub btnNextyr_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnNextyr.ClickButtonArea
        txtYear.Text += 1
        If Not cmbLicense.SelectedValue = 0 Then
            'FetchSchedule()
        End If
    End Sub

    Private Sub btnPrevyr_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnPrevyr.ClickButtonArea
        txtYear.Text -= 1
        If Not cmbLicense.SelectedValue = 0 Then
            'FetchSchedule()
        End If
    End Sub

    Private Sub txtMonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMonth.TextChanged, txtYear.TextChanged
        If Not IsNothing(_dtVariance) Then
            BindCalandar(_dtVariance)
        End If


    End Sub

    Private Sub dlgQVCalendarView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtMonth.Text = txtMonth.AutoCompleteCustomSource.Item(DateTime.Now.Month - 1)
        mnthCtr = DateTime.Now.Month - 1
        txtYear.Text = Date.Now.Year

        '[+][14/09/2019][Ajay Prajapati][USe here]
        BindLicense()
        cmbLicense.Enabled = False
        '[-][14/09/2019][Ajay Prajapati]

        'SETUP CALENDAR CONTROL
        Calendar1.MaximumViewDays = 350
        BindCalandar(_dtVariance)

        '[+][14/09/2019][Ajay Prajapati][Commented here]
        'BindLicense()
        '[-][14/09/2019][Ajay Prajapati]

        'STOP SCROLL OF CALENDAR CONTROL
        AddHandler Calendar1.LoadItems, AddressOf Calendar1_LoadItm
    End Sub

    Private Sub btnPrev_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnPrev.ClickButtonArea
        mnthCtr -= 1
        If mnthCtr = -1 Then mnthCtr = txtMonth.AutoCompleteCustomSource.Count - 1
        txtMonth.Text = txtMonth.AutoCompleteCustomSource.Item(mnthCtr)
        If Not cmbLicense.SelectedValue = 0 Then
            'FetchSchedule()
        End If
    End Sub

    Public Sub FetchSchedule()
        Try
            ObjSchVar = New CWPlusBL.Master.ClsScheduleVariance
            objDt = New DataTable
            ObjSchVar.LicenseID = cmbLicense.SelectedValue
            objDt = ObjSchVar.FunFetch

            If objDt.Rows.Count > 0 Then
                AssignSchedule(objDt)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(objDt) Then
                objDt = Nothing
            End If
            If Not IsNothing(ObjSchVar) Then
                ObjSchVar = Nothing
            End If
        End Try
    End Sub

    Private Sub cmbLicense_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLicense.SelectedIndexChanged
        If Not TypeOf (cmbLicense.SelectedValue) Is Decimal Then
            Exit Sub
        End If

        gblLicenseID = cmbLicense.SelectedValue
        gblLicenseNameForQuickControl = cmbLicense.Text
        'FetchSchedule()


    End Sub

   Private Sub Calendar1_ItemDeleting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.Calendar.CalendarItemCancelEventArgs) Handles Calendar1.ItemDeleting
        e.Cancel = True
    End Sub
End Class


