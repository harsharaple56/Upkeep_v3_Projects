Imports cErrorLog
Namespace My
    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        
        Private Sub MyApplication_UnhandledException(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            e.ExitApplication = False
            Dim objLog As New cLogger
            objLog.smtpHost = "smtp.gmail.com"
            objLog.smtpPass = "as5assin@123$"
            objLog.smtpuser = "t3amassassin@gmail.com"
            objLog.smtpPort = 587
            objLog.AppName = "CWPlus"
            objLog.ToEmail = "support@compelconsultancy.com"
            objLog.EnableSSl = True
            objLog.HandleException(e.Exception)
        End Sub
    End Class


End Namespace

