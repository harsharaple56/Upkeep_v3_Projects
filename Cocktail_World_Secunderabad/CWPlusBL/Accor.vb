Imports System.Xml
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data.Common

Namespace Accor

#Region "Reports"

    Public Class ClsReports
        Inherits ClsCommon

#Region "Variables"

        Protected DtProBusinessDate, DtProFromDate, DtProToDate As Date
        Protected DblPriRevenueCenterId, DblPriCheckId, DblPriAmount, DblPriAngHeadId, DblPriReportId As Double
        Protected StrPriRevenueCenterName, StrPriBillNo, StrPriEmployeeName, StrPriDesignation, StrPriOperationName, StrPriDiscountType, StrPriType As String
        Protected StrPriAnGFields, StrPriAnGFieldsInfo, StrPriAccountType As String

        Private StrPriOldValue, StrPriNewValue, StrPriReference, StrPriRemark, StrPriCardNo, StrPriArticleName, StrPriBillUniqueId As String

        Private DblPriFoodCostPerc, DblPriBevCostPerc, DblPriLiqCostPerc As Double
        Protected ArrLicenseDoc, ArrOperationDoc As XmlDocument
        Protected BoolPriIsAngField, BoolPriMultipleDesignation, boolIsDept As Boolean
        Private StrPrivSearchByArticle As String
        Private ArrDRRXML As XmlDocument



#End Region

#Region "Property"

        Public Property ReportId() As Double
            Get
                Return DblPriReportId
            End Get
            Set(ByVal value As Double)
                DblPriReportId = value
            End Set
        End Property

        Public Property IsDept() As Boolean
            Get
                Return boolIsDept
            End Get
            Set(ByVal value As Boolean)
                boolIsDept = value
            End Set
        End Property

        Public Property DRRXML() As XmlDocument
            Get
                Return ArrDRRXML
            End Get
            Set(ByVal value As XmlDocument)
                ArrDRRXML = value
            End Set
        End Property

        Public Property Article() As String
            Get
                Return StrPrivSearchByArticle
            End Get
            Set(ByVal value As String)
                StrPrivSearchByArticle = value
            End Set
        End Property
        Public Property ArticleName() As String
            Get
                Return StrPriArticleName
            End Get
            Set(ByVal value As String)
                StrPriArticleName = value
            End Set
        End Property

        Public Property LiqCostPerc() As Double
            Get
                Return DblPriLiqCostPerc
            End Get
            Set(ByVal value As Double)
                DblPriLiqCostPerc = value
            End Set
        End Property

        Public Property BevCostPerc() As Double
            Get
                Return DblPriBevCostPerc
            End Get
            Set(ByVal value As Double)
                DblPriBevCostPerc = value
            End Set
        End Property

        Public Property FoodCostPerc() As Double
            Get
                Return DblPriFoodCostPerc
            End Get
            Set(ByVal value As Double)
                DblPriFoodCostPerc = value
            End Set
        End Property

        Public Property CardNo() As String
            Get
                Return StrPriCardNo
            End Get
            Set(ByVal value As String)
                StrPriCardNo = value
            End Set
        End Property

        Public Property Remark() As String
            Get
                Return StrPriRemark
            End Get
            Set(ByVal value As String)
                StrPriRemark = value
            End Set
        End Property

        Public Property BillUniqueId() As String
            Get
                Return StrPriBillUniqueId
            End Get
            Set(ByVal value As String)
                StrPriBillUniqueId = value
            End Set
        End Property

        Public Property OldValue() As String
            Get
                Return StrPriOldValue
            End Get
            Set(ByVal value As String)
                StrPriOldValue = value
            End Set
        End Property

        Public Property NewValue() As String
            Get
                Return StrPriNewValue
            End Get
            Set(ByVal value As String)
                StrPriNewValue = value
            End Set
        End Property

        Public Property Reference() As String
            Get
                Return StrPriReference
            End Get
            Set(ByVal value As String)
                StrPriReference = value
            End Set
        End Property

        Public Property MultipleDesignation() As Boolean
            Get
                Return BoolPriMultipleDesignation
            End Get
            Set(ByVal value As Boolean)
                BoolPriMultipleDesignation = value
            End Set
        End Property

        Public Property IsAngField() As Boolean
            Get
                Return BoolPriIsAngField
            End Get
            Set(ByVal value As Boolean)
                BoolPriIsAngField = value
            End Set
        End Property

        Public Property LicenseXML() As XmlDocument
            Get
                Return ArrLicenseDoc
            End Get
            Set(ByVal value As XmlDocument)
                ArrLicenseDoc = value
            End Set
        End Property

        Public Property OperationXML() As XmlDocument
            Get
                Return ArrOperationDoc
            End Get
            Set(ByVal value As XmlDocument)
                ArrOperationDoc = value
            End Set
        End Property

        Public Property AngHeadId() As Double
            Get
                Return DblPriAngHeadId
            End Get
            Set(ByVal value As Double)
                DblPriAngHeadId = value
            End Set
        End Property

        Public Property Amount() As Double
            Get
                Return DblPriAmount
            End Get
            Set(ByVal value As Double)
                DblPriAmount = value
            End Set
        End Property

        Public Property AnGFields() As String
            Get
                Return StrPriAnGFields
            End Get
            Set(ByVal value As String)
                StrPriAnGFields = value
            End Set
        End Property

        Public Property AccountType() As String
            Get
                Return StrPriAccountType
            End Get
            Set(ByVal value As String)
                StrPriAccountType = value
            End Set
        End Property

        Public Property AnGFieldsInfo() As String
            Get
                Return StrPriAnGFieldsInfo
            End Get
            Set(ByVal value As String)
                StrPriAnGFieldsInfo = value
            End Set
        End Property

        Public Property Type() As String
            Get
                Return StrPriType
            End Get
            Set(ByVal value As String)
                StrPriType = value
            End Set
        End Property

        Public Property DiscountType() As String
            Get
                Return StrPriDiscountType
            End Get
            Set(ByVal value As String)
                StrPriDiscountType = value
            End Set
        End Property

        Public Property OperationName() As String
            Get
                Return StrPriOperationName
            End Get
            Set(ByVal value As String)
                StrPriOperationName = value
            End Set
        End Property

        Public Property RevenueCenterId() As Double
            Get
                Return DblPriRevenueCenterId
            End Get
            Set(ByVal value As Double)
                DblPriRevenueCenterId = value
            End Set
        End Property

        Public Property CheckId() As Double
            Get
                Return DblPriCheckId
            End Get
            Set(ByVal value As Double)
                DblPriCheckId = value
            End Set
        End Property

        Public Property RevenueCenterName() As String
            Get
                Return StrPriRevenueCenterName
            End Get
            Set(ByVal value As String)
                StrPriRevenueCenterName = value
            End Set
        End Property

        Public Property OfficerBillNo() As String
            Get
                Return StrPriBillNo
            End Get
            Set(ByVal value As String)
                StrPriBillNo = value
            End Set
        End Property

        Public Property EmployeeName() As String
            Get
                Return StrPriEmployeeName
            End Get
            Set(ByVal value As String)
                StrPriEmployeeName = value
            End Set
        End Property

        Public Property Designation() As String
            Get
                Return StrPriDesignation
            End Get
            Set(ByVal value As String)
                StrPriDesignation = value
            End Set
        End Property


        Public Property BusinessDate() As Date
            Get
                Return DtProBusinessDate
            End Get
            Set(ByVal value As Date)
                DtProBusinessDate = value
            End Set
        End Property

        Public Property Fromdate() As Date
            Get
                Return DtProFromDate
            End Get
            Set(ByVal value As Date)
                DtProFromDate = value
            End Set
        End Property

        Public Property ToDate() As Date
            Get
                Return DtProToDate
            End Get
            Set(ByVal value As Date)
                DtProToDate = value
            End Set
        End Property

#End Region



        Public Overrides Function FunDelete() As Boolean

        End Function

        Public Overrides Function FunFetch() As System.Data.DataTable

        End Function

        Public Overrides Function FunSave() As Boolean

        End Function

        Public Function FunFetchAuditReport2() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchAuditReport2")
                ObjPriDbCommand.CommandTimeout = 10000
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.Date, DtProFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, DtProToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@username", DbType.String, StrPubOperator)
                FunFetchAuditReport2 = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FetchAuditReport() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchAuditReport")
                ObjPriDbCommand.CommandTimeout = 10000
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.Date, DtProFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, DtProToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@username", DbType.String, StrPubOperator)
                FetchAuditReport = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FunFetchDCCReport() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchDCCReport")
                ObjPriDbCommand.CommandTimeout = 10000
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.Date, DtProFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, DtProToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@username", DbType.String, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriDbCommand, "@OutMsg", DbType.String, 200)
                FunFetchDCCReport = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
                StrPubErrorMsg = Trim(ObjPriDbCommand.Parameters("@OutMsg").Value)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FunFetchEvalPackReports() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchEvalPackReports")
                ObjPriDbCommand.CommandTimeout = 10000
                FunFetchEvalPackReports = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FunSelectEvalPackReports() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_SelectEvalPackReport")
                ObjPriDbCommand.CommandTimeout = 10000
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ReportId", DbType.Double, DblPriReportId)
                FunSelectEvalPackReports = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FunFetchDailyRevenue() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchDailyRevenue")
                ObjPriDbCommand.CommandTimeout = 10000
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.Date, DtProFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, DtProToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@username", DbType.String, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriDbCommand, "@OutMsg", DbType.String, 200)
                FunFetchDailyRevenue = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
                StrPubErrorMsg = Trim(ObjPriDbCommand.Parameters("@OutMsg").Value)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FunFetchFodBevStats() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchFodBevStats")
                ObjPriDbCommand.CommandTimeout = 999999999
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.Date, DtProFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, DtProToDate)
                FunFetchFodBevStats = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FunFetchAccorAdvStatment() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchAccorAdvStatment")
                ObjPriDbCommand.CommandTimeout = 10000
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.Date, DtProFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, DtProToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@username", DbType.String, StrPubOperator)
                FunFetchAccorAdvStatment = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FunFetchEvalPackReport(ByVal StrPriProcName As String) As System.Data.DataSet
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand(StrPriProcName)
                ObjPriDbCommand.CommandTimeout = 999999999
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@FromDate", DbType.DateTime, DtProFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ToDate", DbType.DateTime, DtProToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@username", DbType.String, StrPubOperator)
                FunFetchEvalPackReport = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand)

            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FunFetchAccorAdvMembership() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchAccorAdvMembership")
                ObjPriDbCommand.CommandTimeout = 10000
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.Date, DtProFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, DtProToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@username", DbType.String, StrPubOperator)
                FunFetchAccorAdvMembership = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FunFetchOperationName() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchOperationName")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@userid", DbType.Double, DblPubUserID)
                FunFetchOperationName = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If
                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FetchEvalPackFetchDashboard(ByVal IntLocProcNo As Integer) As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_EvalPackFetchDashboard")
                ObjPriDbCommand.CommandTimeout = 999999999
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ProcNo", DbType.Int32, IntLocProcNo)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.Date, DtProFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, DtProToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@username", DbType.String, StrPubOperator)
                FetchEvalPackFetchDashboard = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If
                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FunFetchEvalPackDashboardReports() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchEvalPackDashboardReports")
                FunFetchEvalPackDashboardReports = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If
                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FunFetchSplitCheckReport() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchSplitCheckReport")
                ObjPriDbCommand.CommandTimeout = 10000
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.Date, DtProFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, DtProToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@username", DbType.String, StrPubOperator)
                FunFetchSplitCheckReport = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FunFetchVoidDiscountSummary() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchVoidDiscountSummary")
                ObjPriDbCommand.CommandTimeout = 999999999
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.Date, DtProFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, DtProToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@username", DbType.String, StrPubOperator)
                'DbPubDataBase.AddOutParameter(ObjPriDbCommand, "@OutMsg", DbType.String, 200)
                FunFetchVoidDiscountSummary = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
                'StrPubErrorMsg = Trim(ObjPriDbCommand.Parameters("@OutMsg").Value)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FunFetchAGEntSummary() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchAGEntSummary")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.Date, DtProFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, DtProToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@username", DbType.String, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriDbCommand, "@OutMsg", DbType.String, 200)
                FunFetchAGEntSummary = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
                StrPubErrorMsg = Trim(ObjPriDbCommand.Parameters("@OutMsg").Value)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Sub FunSaveUserEvalOperation()
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveUserEvalOperation")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@userid", DbType.Double, DblPubUserID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@operationxml", DbType.Xml, ArrOperationDoc.InnerXml)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", DbType.String, 200)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                ObjPriTrans.Commit()
            Catch ex As Exception
                ObjPriTrans.Rollback()
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
                If IsNothing(ObjPriConnection) = False Then
                    ObjPriConnection = Nothing
                End If

                If IsNothing(ObjPriTrans) = False Then
                    ObjPriTrans = Nothing

                End If
            End Try

        End Sub

        Public Function FunFetchDiscSummaryDaywise() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchDiscSummaryDaywise")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licensexml", DbType.Xml, ArrLicenseDoc.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.Date, DtProFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, DtProToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@FoodCostPerc", DbType.Double, DblPriFoodCostPerc)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@BevCostPerc", DbType.Double, DblPriBevCostPerc)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@liqCostPerc", DbType.Double, DblPriLiqCostPerc)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@username", DbType.String, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriDbCommand, "@OutMsg", DbType.String, 200)
                FunFetchDiscSummaryDaywise = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
                StrPubErrorMsg = Trim(ObjPriDbCommand.Parameters("@OutMsg").Value)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FunFetchParStockReport() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchParStockReport")
                ObjPriDbCommand.CommandTimeout = 10000
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.Date, DtProFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, DtProToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@username", DbType.String, StrPubOperator)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@SearchByArticle", DbType.String, Article)

                FunFetchParStockReport = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FunFetchBeverageReconciliation() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchBeverageReconciliation")
                ObjPriDbCommand.CommandTimeout = 10000
                'DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licensexml", DbType.Xml, ArrLicenseDoc.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.Date, DtProFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, DtProToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@username", DbType.String, StrPubOperator)
                FunFetchBeverageReconciliation = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FunFetchTempBeverageRecon() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchTempBeverageRecon")
                ObjPriDbCommand.CommandTimeout = 10000
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@username", DbType.String, StrPubOperator)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@article", DbType.String, StrPriArticleName)
                FunFetchTempBeverageRecon = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FunFetchBeverageCost() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchBeverageCost")
                ObjPriDbCommand.CommandTimeout = 10000
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licensexml", DbType.Xml, ArrLicenseDoc.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.Date, DtProFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, DtProToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@username", DbType.String, StrPubOperator)
                FunFetchBeverageCost = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FunFetchTobaccoCost() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchTobaccoCost")
                ObjPriDbCommand.CommandTimeout = 10000
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licensexml", DbType.Xml, ArrLicenseDoc.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.Date, DtProFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, DtProToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@username", DbType.String, StrPubOperator)
                FunFetchTobaccoCost = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FunFetchCheckForAnG() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchCheckForAnG")
                ObjPriDbCommand.CommandTimeout = 10000
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@FromDate", DbType.Date, DtProFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ToDate", DbType.Date, DtProToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@Revenuecenterid", DbType.Double, DblPriRevenueCenterId)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@BillNo", DbType.String, StrPriBillNo)
                FunFetchCheckForAnG = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function


        Public Function FunFetchAnGFieldWiseReport() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchAnGFieldWiseReport")
                ObjPriDbCommand.CommandTimeout = 10000
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@FromDate", DbType.Date, DtProFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ToDate", DbType.Date, DtProToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@username", DbType.String, StrPubOperator)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@AngField", DbType.String, StrPriAnGFields)
                FunFetchAnGFieldWiseReport = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FunSaveOfficerMealDetail() As Boolean
            FunSaveOfficerMealDetail = False
            Try

                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveOfficerMealDetail")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@RevenueCenterId", DbType.Double, DblPriRevenueCenterId)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@RevenueCenterName", DbType.String, StrPriRevenueCenterName)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CheckId", DbType.Double, DblPriCheckId)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@BillNo", DbType.String, StrPriBillNo)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@EmployeeName", DbType.String, StrPriEmployeeName)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Designation", DbType.String, StrPriDesignation)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@BusinessDate", DbType.Date, DtProBusinessDate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@DiscountType", DbType.String, StrPriDiscountType)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Type", DbType.String, StrPriType)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Amount", DbType.Double, DblPriAmount)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@AnGFields", DbType.String, StrPriAnGFields)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunSaveOfficerMealDetail = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                ObjPriTrans.Commit()
            Catch ex As Exception
                ObjPriTrans.Rollback()
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
                If IsNothing(ObjPriConnection) = False Then
                    ObjPriConnection = Nothing
                End If

                If IsNothing(ObjPriTrans) = False Then
                    ObjPriTrans = Nothing

                End If
            End Try

        End Function


        Public Function FunSaveAnGDetails() As Boolean
            FunSaveAnGDetails = False
            Try

                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveAnGDetails")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@AngHeadId", DbType.Double, DblPriAngHeadId)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@BusinessDate", DbType.Date, DtProBusinessDate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@RevenueCenterId", DbType.Double, DblPriRevenueCenterId)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@RevenueCenterName", DbType.String, StrPriRevenueCenterName)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CheckId", DbType.Double, DblPriCheckId)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@BillNo", DbType.String, StrPriBillNo)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Type", DbType.String, StrPriType)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@AnGFields", DbType.String, StrPriAnGFields)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@AnGFieldsInfo", DbType.String, StrPriAnGFieldsInfo)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@IsAngField", DbType.Boolean, BoolPriIsAngField)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@MultipleDesignation", DbType.Boolean, BoolPriMultipleDesignation)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@username", DbType.String, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunSaveAnGDetails = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                ObjPriTrans.Commit()
            Catch ex As Exception
                ObjPriTrans.Rollback()
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
                If IsNothing(ObjPriConnection) = False Then
                    ObjPriConnection = Nothing
                End If

                If IsNothing(ObjPriTrans) = False Then
                    ObjPriTrans = Nothing

                End If
            End Try

        End Function

        Public Function FunSaveAnGDetailsWithAccountType() As Boolean
            FunSaveAnGDetailsWithAccountType = False
            Try

                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveAnGDetailsWithAccountType")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@AngHeadId", DbType.Double, DblPriAngHeadId)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@BusinessDate", DbType.Date, DtProBusinessDate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@RevenueCenterId", DbType.Double, DblPriRevenueCenterId)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@RevenueCenterName", DbType.String, StrPriRevenueCenterName)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CheckId", DbType.Double, DblPriCheckId)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@BillNo", DbType.String, StrPriBillNo)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Type", DbType.String, StrPriType)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@AnGFields", DbType.String, StrPriAnGFields)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@AccountType", DbType.String, StrPriAccountType)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@AnGFieldsInfo", DbType.String, StrPriAnGFieldsInfo)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@IsAngField", DbType.Boolean, BoolPriIsAngField)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@MultipleDesignation", DbType.Boolean, BoolPriMultipleDesignation)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@username", DbType.String, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunSaveAnGDetailsWithAccountType = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                ObjPriTrans.Commit()
            Catch ex As Exception
                ObjPriTrans.Rollback()
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
                If IsNothing(ObjPriConnection) = False Then
                    ObjPriConnection = Nothing
                End If

                If IsNothing(ObjPriTrans) = False Then
                    ObjPriTrans = Nothing

                End If
            End Try

        End Function


        Public Function FunSaveAnGDetailsForMarriot() As Boolean
            FunSaveAnGDetailsForMarriot = False
            Try

                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveAnGDetailsForMarriot")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@AngHeadId", DbType.Double, DblPriAngHeadId)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@BusinessDate", DbType.Date, DtProBusinessDate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@RevenueCenterId", DbType.Double, DblPriRevenueCenterId)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@RevenueCenterName", DbType.String, StrPriRevenueCenterName)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CheckId", DbType.Double, DblPriCheckId)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@BillNo", DbType.String, StrPriBillNo)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Type", DbType.String, StrPriType)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@AnGFields", DbType.String, StrPriAnGFields)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@AnGFieldsInfo", DbType.String, StrPriAnGFieldsInfo)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@IsAngField", DbType.Boolean, BoolPriIsAngField)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@MultipleDesignation", DbType.Boolean, BoolPriMultipleDesignation)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@username", DbType.String, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunSaveAnGDetailsForMarriot = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                ObjPriTrans.Commit()
            Catch ex As Exception
                ObjPriTrans.Rollback()
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
                If IsNothing(ObjPriConnection) = False Then
                    ObjPriConnection = Nothing
                End If

                If IsNothing(ObjPriTrans) = False Then
                    ObjPriTrans = Nothing

                End If
            End Try

        End Function

        Public Function FunSaveChangedData() As Boolean
            FunSaveChangedData = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveChangedData")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@BusinessDate", DbType.Date, DtProBusinessDate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@RevenueCenterId", DbType.Double, DblPriRevenueCenterId)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@RevenueCenterName", DbType.String, StrPriRevenueCenterName)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CheckId", DbType.Double, DblPriCheckId)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@BillNo", DbType.String, StrPriBillNo)

                DbPubDataBase.AddInParameter(ObjPriCommand, "@OldValue", DbType.String, StrPriOldValue)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@NewValue", DbType.String, StrPriNewValue)

                DbPubDataBase.AddInParameter(ObjPriCommand, "@Reference", DbType.String, StrPriReference)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Remark", DbType.String, StrPriRemark)

                DbPubDataBase.AddInParameter(ObjPriCommand, "@username", DbType.String, StrPubOperator)

                DbPubDataBase.AddInParameter(ObjPriCommand, "@BillUniqueId", DbType.String, StrPriBillUniqueId)

                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)

                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunSaveChangedData = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                ObjPriTrans.Commit()
            Catch ex As Exception
                ObjPriTrans.Rollback()
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
                If IsNothing(ObjPriConnection) = False Then
                    ObjPriConnection = Nothing
                End If

                If IsNothing(ObjPriTrans) = False Then
                    ObjPriTrans = Nothing

                End If
            End Try

        End Function

        Public Function FunSaveChangedMembershipData() As Boolean
            FunSaveChangedMembershipData = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveChangedMembershipData")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@BusinessDate", DbType.Date, DtProBusinessDate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@RevenueCenterId", DbType.Double, DblPriRevenueCenterId)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@RevenueCenterName", DbType.String, StrPriRevenueCenterName)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CheckId", DbType.Double, DblPriCheckId)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@BillNo", DbType.String, StrPriBillNo)

                DbPubDataBase.AddInParameter(ObjPriCommand, "@DiscountType", DbType.String, StrPriDiscountType)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CardNo", DbType.String, StrPriCardNo)

                DbPubDataBase.AddInParameter(ObjPriCommand, "@username", DbType.String, StrPubOperator)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@BillUniqueId", DbType.String, StrPriBillUniqueId)

                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)

                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunSaveChangedMembershipData = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                ObjPriTrans.Commit()
            Catch ex As Exception
                ObjPriTrans.Rollback()
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
                If IsNothing(ObjPriConnection) = False Then
                    ObjPriConnection = Nothing
                End If

                If IsNothing(ObjPriTrans) = False Then
                    ObjPriTrans = Nothing

                End If
            End Try

        End Function

        Public Function FunSaveMajorType() As Boolean
            FunSaveMajorType = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveUpdateMajorType")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@MajorTypeXML", DbType.Xml, ArrDRRXML.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@username", DbType.String, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", DbType.Boolean, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", DbType.String, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunSaveMajorType = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                ObjPriTrans.Commit()
            Catch ex As Exception
                ObjPriTrans.Rollback()
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
                If IsNothing(ObjPriConnection) = False Then
                    ObjPriConnection = Nothing
                End If

                If IsNothing(ObjPriTrans) = False Then
                    ObjPriTrans = Nothing

                End If
            End Try

        End Function

        Public Function FunSaveFamilyType() As Boolean
            FunSaveFamilyType = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveUpdateFamilyType")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@FamilyTypeXML", DbType.Xml, ArrDRRXML.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@username", DbType.String, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", DbType.Boolean, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", DbType.String, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunSaveFamilyType = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                ObjPriTrans.Commit()
            Catch ex As Exception
                ObjPriTrans.Rollback()
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
                If IsNothing(ObjPriConnection) = False Then
                    ObjPriConnection = Nothing
                End If

                If IsNothing(ObjPriTrans) = False Then
                    ObjPriTrans = Nothing

                End If
            End Try

        End Function

        Public Function FunSaveDRR() As Boolean
            FunSaveDRR = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveUpdateDRR")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@BusinessDate", DbType.Date, DtProBusinessDate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@DRRXML", DbType.Xml, ArrDRRXML.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@username", DbType.String, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", DbType.Boolean, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", DbType.String, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunSaveDRR = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                ObjPriTrans.Commit()
            Catch ex As Exception
                ObjPriTrans.Rollback()
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
                If IsNothing(ObjPriConnection) = False Then
                    ObjPriConnection = Nothing
                End If

                If IsNothing(ObjPriTrans) = False Then
                    ObjPriTrans = Nothing

                End If
            End Try

        End Function

        Public Function FunDeleteAngDetails() As Boolean
            FunDeleteAngDetails = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_DeleteAngDetails")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@AngHeadId", DbType.Double, DblPriAngHeadId)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand)
                FunDeleteAngDetails = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                ObjPriTrans.Commit()
            Catch ex As Exception
                ObjPriTrans.Rollback()
                FunDeleteAngDetails = False
                Throw ex
            Finally

                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If
                If IsNothing(ObjPriCommand) = False Then
                    ObjPriCommand.Dispose()
                End If
                If IsNothing(ObjPriConnection) = False Then
                    ObjPriConnection.Dispose()
                End If
                If IsNothing(ObjPriTrans) = False Then
                    ObjPriTrans.Dispose()
                End If
            End Try
        End Function

        Public Function FunFetchSaleData() As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_ViewData")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@businessdate", DbType.Date, DtProBusinessDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@Revenuecenterid", DbType.Double, DblPriRevenueCenterId)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@BillNo", DbType.String, StrPriBillNo)
                FunFetchSaleData = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FunFetchSearch(ByVal ArrRevcenterDoc As XmlDocument, ByVal ArrDiscountDoc As XmlDocument) As DataSet
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_Search")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@Fromdate", DbType.Date, DtProFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@Todate", DbType.Date, DtProToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@Revenuecenterxml", DbType.Xml, ArrRevcenterDoc.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@discountxml", DbType.Xml, ArrDiscountDoc.InnerXml)
                'DbPubDataBase.AddInParameter(ObjPriDbCommand, "@Discount", DbType.String, Discount)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@BillNo", DbType.String, StrPriBillNo)
                FunFetchSearch = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function


        Public Function FunFetchNonPromotionalMealSummary() As DataSet
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchNonPromotionalMealSummary")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@Fromdate", DbType.Date, DtProFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@Todate", DbType.Date, DtProToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@IsDept", DbType.Boolean, boolIsDept)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@username", DbType.String, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriDbCommand, "@OutMsg", SqlDbType.VarChar, 100)
                FunFetchNonPromotionalMealSummary = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand)
                StrPubErrorMsg = Trim(ObjPriDbCommand.Parameters("@OutMsg").Value)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function
        Public Function FunFetchBulkInsertfilePath() As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_Fetchbulkinsertfilepath")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@OperationName", DbType.String, StrPriOperationName)
                FunFetchBulkInsertfilePath = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FunFetchCostvsSales() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchCostvsSales")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.Date, DtProFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, DtProToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@username", DbType.String, StrPubOperator)
                FunFetchCostvsSales = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FunFetchRevenueCentersNew() As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchNetSaleForDRRNew")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@date", DbType.Date, DtProBusinessDate)
                FunFetchRevenueCentersNew = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FunFetchFamilyType() As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_GetFamilyType")
                FunFetchFamilyType = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FunFetchMajorType() As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_GetMajorType")
                FunFetchMajorType = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FunFetchRevenueCenters() As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_GetRevenueCentersForEvalPack")
                FunFetchRevenueCenters = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FunFetchMCRevenueCenter() As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchMCRevenueCenter")
                FunFetchMCRevenueCenter = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FunFetchDiscountTypes(Optional ByVal IntLocDisType As Integer = 1) As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchDiscountMasterForEvalPack")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@DiscountType", DbType.String, IntLocDisType)
                FunFetchDiscountTypes = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FunFetchDesignation() As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchDesignation")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@Designation", DbType.String, StrPriDesignation)
                FunFetchDesignation = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FunFetchAnGField() As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchAnGField")
                FunFetchAnGField = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FunFetchConsolidatedFoodCostReport() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchCONSOLIDATEDFOODCOSTREPORT")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.Date, DtProFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, DtProToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@username", DbType.String, StrPubOperator)
                FunFetchConsolidatedFoodCostReport = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FunFetchFoodCostReport(ByVal StrRevenueCenterName As String) As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchFoodCostReport")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.Date, DtProFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, DtProToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@RevenueCenterName", DbType.String, StrRevenueCenterName)
                FunFetchFoodCostReport = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function


        Public Function FunFetchNetSaleForDRR() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchNetSaleForDRR")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@date", DbType.Date, DtProBusinessDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@revenuecenterid", DbType.Int32, DblPriRevenueCenterId)
                FUnFetchNetSaleForDRR = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

    End Class

#End Region

#Region "FinYear Menu"

    Public Class ClsFinYear
        Inherits ClsCommon

        Private DtPriFromDate, DtPriToDate As Date

        Public Property FromDate() As Date
            Get
                Return DtPriFromDate
            End Get
            Set(ByVal value As Date)
                DtPriFromDate = value
            End Set
        End Property

        Public Property ToDate() As Date
            Get
                Return DtPriToDate
            End Get
            Set(ByVal value As Date)
                DtPriToDate = value
            End Set
        End Property

        Public Overrides Function FunDelete() As Boolean

        End Function

        Public Overrides Function FunFetch() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchFinancialYear")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@FincyearId", DbType.Double, DblPubCategoryID)
                FunFetch = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

            Catch ex As Exception
                Throw ex

            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If

            End Try
        End Function

        Public Overrides Function FunSave() As Boolean

        End Function
    End Class
#End Region


#Region "Designation Class"
    Public Class ClsDesignation
        Inherits ClsCommon

#Region "Variables"
        Private StrPriDesignationDesc As String
        Private DblPriDesignationId As Double
#End Region
#Region " Property"

        Public Property DesignationDsec() As String
            Get
                Return StrPriDesignationDesc
            End Get
            Set(ByVal value As String)
                StrPriDesignationDesc = value
            End Set
        End Property

        Public Property DesignationId() As Double
            Get
                Return DblPriDesignationId
            End Get
            Set(ByVal value As Double)
                DblPriDesignationId = value
            End Set
        End Property

#End Region
        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_DeleteDesignation")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@DesignationId", DbType.Double, DblPriDesignationId)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand)
                FunDelete = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                ObjPriTrans.Commit()
            Catch ex As Exception
                ObjPriTrans.Rollback()
                FunDelete = False

                Throw ex
            Finally

                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If
                If IsNothing(ObjPriCommand) = False Then
                    ObjPriCommand.Dispose()
                End If
                If IsNothing(ObjPriConnection) = False Then
                    ObjPriConnection.Dispose()
                End If
                If IsNothing(ObjPriTrans) = False Then
                    ObjPriTrans.Dispose()
                End If
            End Try
        End Function

        Public Overrides Function FunFetch() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_fetchDesignationMst")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@DesignationId", DbType.Double, DblPriDesignationId)
                FunFetch = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

            Catch ex As Exception
                Throw ex

            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If

            End Try

        End Function

        Public Overrides Function FunSave() As Boolean
            FunSave = False
            Try

                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveDesignation")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@DesignationId", DbType.Double, DblPriDesignationId)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@DesignationDesc", DbType.String, StrPriDesignationDesc)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@EvalDeptId", DbType.Double, DblPubEvalDepartmentId)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@username", DbType.String, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", DbType.String, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunSave = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                ObjPriTrans.Commit()
            Catch ex As Exception
                ObjPriTrans.Rollback()
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
                If IsNothing(ObjPriConnection) = False Then
                    ObjPriConnection = Nothing
                End If

                If IsNothing(ObjPriTrans) = False Then
                    ObjPriTrans = Nothing

                End If
            End Try
        End Function

    End Class

#End Region

#Region "DRRSale Class"
    Public Class ClsDRRSale
        Inherits ClsCommon

#Region "Variables"

        Private DblPriDRRId, DblPriFoodSaleAmount, DblPriBeverageSaleAmount, DblPriLiquorSaleAmount, DblPriTobaccoSaleAmount, DblPriFoodTransferAmount, DblPriBevTransferAmount, DblPriBeverageToFood As Double
        Private StrPriRevenueCenterId, StrPriRevenueCenterName As String
        Private IntPriCovers As Integer
        Private DtPriBusinessdate As DateTime

#End Region

#Region " Property"

        Public Property BeverageToFood() As Double
            Get
                Return DblPriBeverageToFood
            End Get
            Set(ByVal value As Double)
                DblPriBeverageToFood = value
            End Set
        End Property

        Public Property FoodTransferAmount() As Double
            Get
                Return DblPriFoodTransferAmount
            End Get
            Set(ByVal value As Double)
                DblPriFoodTransferAmount = value
            End Set
        End Property

        Public Property BevTransferAmount() As Double
            Get
                Return DblPriBevTransferAmount
            End Get
            Set(ByVal value As Double)
                DblPriBevTransferAmount = value
            End Set
        End Property

        Public Property Businessdate() As DateTime
            Get
                Return DtPriBusinessdate
            End Get
            Set(ByVal value As DateTime)
                DtPriBusinessdate = value
            End Set
        End Property

        Public Property Covers() As Integer
            Get
                Return IntPriCovers
            End Get
            Set(ByVal value As Integer)
                IntPriCovers = value
            End Set
        End Property

        Public Property FoodSaleAmount() As Double
            Get
                Return DblPriFoodSaleAmount
            End Get
            Set(ByVal value As Double)
                DblPriFoodSaleAmount = value
            End Set
        End Property

        Public Property BeverageSaleAmount() As Double
            Get
                Return DblPriBeverageSaleAmount
            End Get
            Set(ByVal value As Double)
                DblPriBeverageSaleAmount = value
            End Set
        End Property

        Public Property LiquorSaleAmount() As Double
            Get
                Return DblPriLiquorSaleAmount
            End Get
            Set(ByVal value As Double)
                DblPriLiquorSaleAmount = value
            End Set
        End Property

        Public Property TobaccoSaleAmount() As Double
            Get
                Return DblPriTobaccoSaleAmount
            End Get
            Set(ByVal value As Double)
                DblPriTobaccoSaleAmount = value
            End Set
        End Property

        Public Property DRRId() As Double
            Get
                Return DblPriDRRId
            End Get
            Set(ByVal value As Double)
                DblPriDRRId = value
            End Set
        End Property

        Public Property RevenueCenterId() As String
            Get
                Return StrPriRevenueCenterId
            End Get
            Set(ByVal value As String)
                StrPriRevenueCenterId = value
            End Set
        End Property

        Public Property RevenueCenterName() As String
            Get
                Return StrPriRevenueCenterName
            End Get
            Set(ByVal value As String)
                StrPriRevenueCenterName = value
            End Set
        End Property

#End Region
        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_deleteEvalPackDRR")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@DRRId", DbType.Double, DblPriDRRId)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand)
                FunDelete = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                ObjPriTrans.Commit()
            Catch ex As Exception
                ObjPriTrans.Rollback()
                FunDelete = False

                Throw ex
            Finally

                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If
                If IsNothing(ObjPriCommand) = False Then
                    ObjPriCommand.Dispose()
                End If
                If IsNothing(ObjPriConnection) = False Then
                    ObjPriConnection.Dispose()
                End If
                If IsNothing(ObjPriTrans) = False Then
                    ObjPriTrans.Dispose()
                End If
            End Try
        End Function

        Public Overrides Function FunFetch() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchEvalPackDRR")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@DRRId", DbType.Double, DblPriDRRId)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@Businessdate", DbType.Date, DtPriBusinessdate)
                FunFetch = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

            Catch ex As Exception
                Throw ex

            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If

            End Try

        End Function

        Public Overrides Function FunSave() As Boolean
            FunSave = False
            Try

                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveEvalPackDRR")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@DRRId", DbType.Double, DblPriDRRId)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Businessdate", DbType.DateTime, DtPriBusinessdate)

                DbPubDataBase.AddInParameter(ObjPriCommand, "@RevenueCenterId", DbType.String, StrPriRevenueCenterId)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@RevenueCenterName", DbType.String, StrPriRevenueCenterName)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Covers", DbType.Int32, IntPriCovers)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@FoodTransferAmount", DbType.Double, DblPriFoodTransferAmount)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@BevTransferAmount", DbType.Double, DblPriBevTransferAmount)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@BeverageToFood", DbType.Double, DblPriBeverageToFood)

                DbPubDataBase.AddInParameter(ObjPriCommand, "@username", DbType.String, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", DbType.String, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunSave = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                ObjPriTrans.Commit()
            Catch ex As Exception
                ObjPriTrans.Rollback()
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
                If IsNothing(ObjPriConnection) = False Then
                    ObjPriConnection = Nothing
                End If

                If IsNothing(ObjPriTrans) = False Then
                    ObjPriTrans = Nothing

                End If
            End Try
        End Function

    End Class

#End Region

#Region "Eval License Class"
    Public Class ClsEvalLicense
        Inherits ClsCommon
#Region "VAriables"
        Private StrLicenseName As String

        Private ArrLicenseCode As XmlDocument
#End Region
#Region "Property"
        Public Property LicenseCodeXML() As XmlDocument
            Get
                Return ArrLicenseCode
            End Get
            Set(ByVal value As XmlDocument)
                ArrLicenseCode = value
            End Set
        End Property

        Public Property LicenseName() As String
            Get
                Return StrLicenseName
            End Get
            Set(ByVal value As String)
                StrLicenseName = value
            End Set
        End Property

#End Region
        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("[Spr_DeleteEvalLicense]")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseID", DbType.Double, DblPubEvalLicenseID)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand)
                FunDelete = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                ObjPriTrans.Commit()
            Catch ex As Exception
                FunDelete = False
                ObjPriTrans.Rollback()
                Throw ex
            Finally

                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If
                If IsNothing(ObjPriCommand) = False Then
                    ObjPriCommand.Dispose()
                End If
                If IsNothing(ObjPriConnection) = False Then
                    ObjPriConnection.Dispose()
                End If
                If IsNothing(ObjPriTrans) = False Then
                    ObjPriTrans.Dispose()
                End If
            End Try

        End Function

        Public Overrides Function FunFetch() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchEvalLicense")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseID", DbType.Double, DblPubEvalLicenseID)
                FunFetch = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

            Catch ex As Exception
                Throw ex

            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If

            End Try

        End Function

        Public Function FunFetchLicenseCode() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_fetchEvalLicenseCode")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseID", DbType.Double, DblPubEvalLicenseID)
                FunFetchLicenseCode = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

            Catch ex As Exception
                Throw ex

            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If

            End Try

        End Function

        Public Overrides Function FunSave() As Boolean
            FunSave = False
            Try

                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("[Spr_SaveEvalLicense]")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseID", DbType.Double, DblPubEvalLicenseID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseDesc", SqlDbType.VarChar, StrLicenseName)

                DbPubDataBase.AddInParameter(ObjPriCommand, "@username", DbType.String, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", DbType.String, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunSave = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                ObjPriTrans.Commit()
            Catch ex As Exception
                ObjPriTrans.Rollback()
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
                If IsNothing(ObjPriConnection) = False Then
                    ObjPriConnection = Nothing
                End If

                If IsNothing(ObjPriTrans) = False Then
                    ObjPriTrans = Nothing

                End If
            End Try

        End Function

        Public Function FunSaveLicenseCode() As Boolean
            FunSaveLicenseCode = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("[spr_SaveEvalLicenseCode]")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseID", DbType.Double, DblPubEvalLicenseID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseCodeXML", DbType.Xml, ArrLicenseCode.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@username", DbType.String, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", DbType.String, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunSaveLicenseCode = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                ObjPriTrans.Commit()
            Catch ex As Exception
                ObjPriTrans.Rollback()
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If
                If IsNothing(ObjPriCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
                If IsNothing(ObjPriConnection) = False Then
                    ObjPriConnection = Nothing
                End If
                If IsNothing(ObjPriTrans) = False Then
                    ObjPriTrans = Nothing
                End If
            End Try
        End Function
    End Class

#End Region


#Region "Menu Item Class"
    Public Class ClsMenuItem
        Inherits ClsCommon
#Region "Variables"
        Private StrPriItemName, StrPriItemCode, StrPriRevenueCenterID As String
#End Region
#Region " Property"
        Public Property RevenueCenterID() As String
            Get
                Return StrPriRevenueCenterID
            End Get
            Set(ByVal value As String)
                StrPriRevenueCenterID = value
            End Set
        End Property

        Public Property ItemName() As String
            Get
                Return StrPriItemName
            End Get
            Set(ByVal value As String)
                StrPriItemName = value
            End Set
        End Property

        Public Property ItemCode() As String
            Get
                Return StrPriItemCode
            End Get
            Set(ByVal value As String)
                StrPriItemCode = value
            End Set
        End Property
#End Region
        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_DeleteMenuItem")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@MenuItemID", DbType.Double, DblPubMenuItemID)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand)
                FunDelete = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                ObjPriTrans.Commit()
            Catch ex As Exception
                ObjPriTrans.Rollback()
                FunDelete = False

                Throw ex
            Finally

                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If
                If IsNothing(ObjPriCommand) = False Then
                    ObjPriCommand.Dispose()
                End If
                If IsNothing(ObjPriConnection) = False Then
                    ObjPriConnection.Dispose()
                End If
                If IsNothing(ObjPriTrans) = False Then
                    ObjPriTrans.Dispose()
                End If
            End Try
        End Function

        Public Overrides Function FunFetch() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_fetchMenuItem")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@MenuItemID", DbType.Double, DblPubMenuItemID)
                FunFetch = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

            Catch ex As Exception
                Throw ex

            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If

            End Try

        End Function

        Public Overrides Function FunSave() As Boolean
            FunSave = False
            Try

                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveMenuItem")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@MenuItemID", DbType.Double, DblPubMenuItemID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@ItemName", DbType.String, StrPriItemName)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@ItemCode", DbType.String, StrPriItemCode)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@RevenueCenterID", DbType.String, StrPriRevenueCenterID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@username", DbType.String, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", DbType.String, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunSave = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                ObjPriTrans.Commit()
            Catch ex As Exception
                ObjPriTrans.Rollback()
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
                If IsNothing(ObjPriConnection) = False Then
                    ObjPriConnection = Nothing
                End If

                If IsNothing(ObjPriTrans) = False Then
                    ObjPriTrans = Nothing

                End If
            End Try
        End Function

    End Class

#End Region


#Region "EvalDepartment Class"
    Public Class ClsEvalDepartment
        Inherits ClsCommon

#Region "Variables"
        Private StrPriEvalDepartmentDesc, StrPriEvalDepartmentCode As String

#End Region

#Region " Property"

        Public Property EvalDepartmentCode() As String
            Get
                Return StrPriEvalDepartmentCode
            End Get
            Set(ByVal value As String)
                StrPriEvalDepartmentCode = value
            End Set
        End Property

        Public Property EvalDepartmentDesc() As String
            Get
                Return StrPriEvalDepartmentDesc
            End Get
            Set(ByVal value As String)
                StrPriEvalDepartmentDesc = value
            End Set
        End Property

#End Region
        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_DeleteEvalDepartment")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@EvalDeptId", DbType.Double, DblPubEvalDepartmentId)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand)
                FunDelete = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                ObjPriTrans.Commit()
            Catch ex As Exception
                ObjPriTrans.Rollback()
                FunDelete = False

                Throw ex
            Finally

                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If
                If IsNothing(ObjPriCommand) = False Then
                    ObjPriCommand.Dispose()
                End If
                If IsNothing(ObjPriConnection) = False Then
                    ObjPriConnection.Dispose()
                End If
                If IsNothing(ObjPriTrans) = False Then
                    ObjPriTrans.Dispose()
                End If
            End Try
        End Function

        Public Overrides Function FunFetch() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchEvalDepartment")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@EvalDeptId", DbType.Double, DblPubEvalDepartmentId)
                FunFetch = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

            Catch ex As Exception
                Throw ex

            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If

            End Try

        End Function

        Public Overrides Function FunSave() As Boolean
            FunSave = False
            Try

                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveEvalDepartment")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@EvalDeptId", DbType.Double, DblPubEvalDepartmentId)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@EvalDeptDesc", DbType.String, StrPriEvalDepartmentDesc)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@EvalDeptCode", DbType.String, StrPriEvalDepartmentCode)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@username", DbType.String, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", DbType.String, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunSave = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                ObjPriTrans.Commit()
            Catch ex As Exception
                ObjPriTrans.Rollback()
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
                If IsNothing(ObjPriConnection) = False Then
                    ObjPriConnection = Nothing
                End If

                If IsNothing(ObjPriTrans) = False Then
                    ObjPriTrans = Nothing

                End If
            End Try
        End Function

    End Class

#End Region


#Region "Beverage REcon Comment"

    Public Class ClsBeverageReconComment
        Inherits ClsCommon

#Region "Variables"

        Private DblPriIdn, DblPriItemId As Double
        Private DtProBusinessDate As Date
        Private StrPriItemNo, StrPriItemName, StrPriCostCenterId, StrPriCostCenterName, StrPriComments As String
        Private strArticleNo As String
        Private DtPriFromDate, DtPriToDate As Date
        Private StrArticleName As String

#End Region

#Region "Property"
        Public Property ArticleNo() As String
            Get
                Return strArticleNo
            End Get
            Set(ByVal value As String)
                strArticleNo = value
            End Set
        End Property

        Public Property Article() As String
            Get
                Return StrArticleName
            End Get
            Set(ByVal value As String)
                StrArticleName = value
            End Set
        End Property

        Public Property FromDate() As Date
            Get
                Return DtPriFromDate
            End Get
            Set(ByVal value As Date)
                DtPriFromDate = value
            End Set
        End Property

        Public Property ToDate() As Date
            Get
                Return DtPriToDate
            End Get
            Set(ByVal value As Date)
                DtPriToDate = value
            End Set
        End Property

        Public Property BusinessDate() As Date
            Get
                Return DtProBusinessDate
            End Get
            Set(ByVal value As Date)
                DtProBusinessDate = value
            End Set
        End Property

        Public Property Comments() As String
            Get
                Return StrPriComments
            End Get
            Set(ByVal value As String)
                StrPriComments = value
            End Set
        End Property

        Public Property Idn() As Double
            Get
                Return DblPriIdn
            End Get
            Set(ByVal value As Double)
                DblPriIdn = value
            End Set
        End Property

        Public Property ItemId() As Double
            Get
                Return DblPriItemId
            End Get
            Set(ByVal value As Double)
                DblPriItemId = value
            End Set
        End Property

        Public Property ItemNo() As String
            Get
                Return StrPriItemNo
            End Get
            Set(ByVal value As String)
                StrPriItemNo = value
            End Set
        End Property

        Public Property ItemName() As String
            Get
                Return StrPriItemName
            End Get
            Set(ByVal value As String)
                StrPriItemName = value
            End Set
        End Property

        Public Property CostCenterId() As String
            Get
                Return StrPriCostCenterId
            End Get
            Set(ByVal value As String)
                StrPriCostCenterId = value
            End Set
        End Property

        Public Property CostCenterName() As String
            Get
                Return StrPriCostCenterName
            End Get
            Set(ByVal value As String)
                StrPriCostCenterName = value
            End Set
        End Property

#End Region

        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_DeleteBeverageReconComments")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@idn", DbType.Double, DblPriIdn)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand)
                FunDelete = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                ObjPriTrans.Commit()
            Catch ex As Exception
                ObjPriTrans.Rollback()
                FunDelete = False

                Throw ex
            Finally

                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If
                If IsNothing(ObjPriCommand) = False Then
                    ObjPriCommand.Dispose()
                End If
                If IsNothing(ObjPriConnection) = False Then
                    ObjPriConnection.Dispose()
                End If
                If IsNothing(ObjPriTrans) = False Then
                    ObjPriTrans.Dispose()
                End If
            End Try
        End Function

        Public Overrides Function FunFetch() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchBeverageReconComments")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.Date, DtPriFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, DtPriToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@SearchByArticle", DbType.String, Article)

                FunFetch = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Overrides Function FunSave() As Boolean
            FunSave = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveBeverageReconComments")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@idn", DbType.Double, DblPriIdn)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Date", DbType.Date, DtProBusinessDate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@ItemId", DbType.Double, DblPriItemId)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@ItemNo", DbType.String, StrPriItemNo)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@ItemName", DbType.String, StrPriItemName)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CostCenterId", DbType.String, StrPriCostCenterId)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CostCenterName", DbType.String, StrPriCostCenterName)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Comments", DbType.String, StrPriComments)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@username", DbType.String, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunSave = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                ObjPriTrans.Commit()
            Catch ex As Exception
                ObjPriTrans.Rollback()
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
                If IsNothing(ObjPriConnection) = False Then
                    ObjPriConnection = Nothing
                End If

                If IsNothing(ObjPriTrans) = False Then
                    ObjPriTrans = Nothing
                End If
            End Try
        End Function


        Public Function FunFetchCostCenter() As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchCostCenter")
                FunFetchCostCenter = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Function FunFetchMCItems() As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchMCItems")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@SearchByName", DbType.String, Article)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@SearchByNo", DbType.String, ArticleNo)
                FunFetchMCItems = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

    End Class
#End Region

#Region "Beverage REcon Comment"

    Public Class ClsBeverageReconInputs
        Inherits ClsCommon

#Region "Variables"

        Private DblPriIdn, DblPriItemId As Double
        Private DtProBusinessDate As Date
        Private StrPriItemNo, StrPriItemName, StrPriCostCenterId, StrPriCostCenterName As String

        Private DtPriFromDate, DtPriToDate As Date
        Private StrArticleName As String
        Private DblPriQuantity, DblPriValue As Double
        Private BoolPriBreakage As Boolean
#End Region

#Region "Property"

        Public Property Article() As String
            Get
                Return StrArticleName
            End Get
            Set(ByVal value As String)
                StrArticleName = value
            End Set
        End Property

        Public Property Breakage() As Boolean
            Get
                Return BoolPriBreakage
            End Get
            Set(ByVal value As Boolean)
                BoolPriBreakage = value
            End Set
        End Property

        Public Property Quantity() As Double
            Get
                Return DblPriQuantity
            End Get
            Set(ByVal value As Double)
                DblPriQuantity = value
            End Set
        End Property

        Public Property Value() As Double
            Get
                Return DblPriValue
            End Get
            Set(ByVal value As Double)
                DblPriValue = value
            End Set
        End Property

        Public Property FromDate() As Date
            Get
                Return DtPriFromDate
            End Get
            Set(ByVal value As Date)
                DtPriFromDate = value
            End Set
        End Property

        Public Property ToDate() As Date
            Get
                Return DtPriToDate
            End Get
            Set(ByVal value As Date)
                DtPriToDate = value
            End Set
        End Property

        Public Property BusinessDate() As Date
            Get
                Return DtProBusinessDate
            End Get
            Set(ByVal value As Date)
                DtProBusinessDate = value
            End Set
        End Property

        Public Property Idn() As Double
            Get
                Return DblPriIdn
            End Get
            Set(ByVal value As Double)
                DblPriIdn = value
            End Set
        End Property

        Public Property ItemId() As Double
            Get
                Return DblPriItemId
            End Get
            Set(ByVal value As Double)
                DblPriItemId = value
            End Set
        End Property

        Public Property ItemNo() As String
            Get
                Return StrPriItemNo
            End Get
            Set(ByVal value As String)
                StrPriItemNo = value
            End Set
        End Property

        Public Property ItemName() As String
            Get
                Return StrPriItemName
            End Get
            Set(ByVal value As String)
                StrPriItemName = value
            End Set
        End Property

        Public Property CostCenterId() As String
            Get
                Return StrPriCostCenterId
            End Get
            Set(ByVal value As String)
                StrPriCostCenterId = value
            End Set
        End Property

        Public Property CostCenterName() As String
            Get
                Return StrPriCostCenterName
            End Get
            Set(ByVal value As String)
                StrPriCostCenterName = value
            End Set
        End Property

#End Region

        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_DeleteBeverageReconInputs")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@idn", DbType.Double, DblPriIdn)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand)
                FunDelete = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                ObjPriTrans.Commit()
            Catch ex As Exception
                ObjPriTrans.Rollback()
                FunDelete = False

                Throw ex
            Finally

                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If
                If IsNothing(ObjPriCommand) = False Then
                    ObjPriCommand.Dispose()
                End If
                If IsNothing(ObjPriConnection) = False Then
                    ObjPriConnection.Dispose()
                End If
                If IsNothing(ObjPriTrans) = False Then
                    ObjPriTrans.Dispose()
                End If
            End Try
        End Function

        Public Overrides Function FunFetch() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchBeverageReconInputs")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.Date, DtPriFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, DtPriToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@SearchByArticle", DbType.String, Article)
                FunFetch = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Overrides Function FunSave() As Boolean
            FunSave = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveBeverageReconInputs")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@idn", DbType.Double, DblPriIdn)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Date", DbType.Date, DtProBusinessDate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@ItemId", DbType.Double, DblPriItemId)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@ItemNo", DbType.String, StrPriItemNo)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@ItemName", DbType.String, StrPriItemName)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CostCenterId", DbType.String, StrPriCostCenterId)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CostCenterName", DbType.String, StrPriCostCenterName)

                DbPubDataBase.AddInParameter(ObjPriCommand, "@Quantity", DbType.Double, DblPriQuantity)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Value", DbType.Double, DblPriValue)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@IsBreakage", DbType.Boolean, BoolPriBreakage)

                DbPubDataBase.AddInParameter(ObjPriCommand, "@username", DbType.String, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunSave = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                ObjPriTrans.Commit()
            Catch ex As Exception
                ObjPriTrans.Rollback()
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
                If IsNothing(ObjPriConnection) = False Then
                    ObjPriConnection = Nothing
                End If

                If IsNothing(ObjPriTrans) = False Then
                    ObjPriTrans = Nothing
                End If
            End Try
        End Function

    End Class
#End Region

#Region "Par Stock Master"

    Public Class ClsParStockMst
        Inherits ClsCommon

        Private StrPriCostCenterId, StrPriItemName As String
        Dim xmlItemDoc As XmlDocument

        Public Property ItemXMLDoc() As XmlDocument
            Get
                Return xmlItemDoc
            End Get
            Set(ByVal value As XmlDocument)
                xmlItemDoc = value
            End Set
        End Property

        Public Property ItemName() As String
            Get
                Return StrPriItemName
            End Get
            Set(ByVal value As String)
                StrPriItemName = value
            End Set
        End Property

        Public Property CostCenterId() As String
            Get
                Return StrPriCostCenterId
            End Get
            Set(ByVal value As String)
                StrPriCostCenterId = value
            End Set
        End Property

        Public Overrides Function FunDelete() As Boolean

        End Function

        Public Overrides Function FunFetch() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchEvalPackParStock")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@CostCenterId", DbType.String, StrPriCostCenterId)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@itemname", DbType.String, StrPriItemName)
                FunFetch = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Overrides Function FunSave() As Boolean
            FunSave = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveEvalPackParStock")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CostCenterId", DbType.String, StrPriCostCenterId)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@itemxml", DbType.Xml, xmlItemDoc.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@username", DbType.String, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunSave = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                ObjPriTrans.Commit()
            Catch ex As Exception
                ObjPriTrans.Rollback()
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
                If IsNothing(ObjPriConnection) = False Then
                    ObjPriConnection = Nothing
                End If

                If IsNothing(ObjPriTrans) = False Then
                    ObjPriTrans = Nothing
                End If
            End Try
        End Function
    End Class

#End Region



#Region "Genral Set Up"

    Public Class ClsGentralSetUp
        Inherits ClsCommon

#Region "Variabes"
        Dim filepath As String
#End Region
#Region "Property"
        Public Property SetFilePath() As String
            Get
                Return filepath
            End Get
            Set(ByVal value As String)
                filepath = value
            End Set
        End Property
#End Region
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function FunDelete() As Boolean

        End Function

        ''' <summary>
        ''' '
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function FunFetch() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_Fetchbulkinsertfilepath")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@OperationName", DbType.String, SetFilePath)
                FunFetch = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
            End Try
        End Function

        Public Overrides Function FunSave() As Boolean
            FunSave = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_UpdateFilePath")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@FILEPATH", DbType.String, SetFilePath)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunSave = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                ObjPriTrans.Commit()
            Catch ex As Exception
                ObjPriTrans.Rollback()
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
                If IsNothing(ObjPriConnection) = False Then
                    ObjPriConnection = Nothing
                End If

                If IsNothing(ObjPriTrans) = False Then
                    ObjPriTrans = Nothing
                End If
            End Try
        End Function

    End Class

#End Region


#Region "CostReportInput Class"
    Public Class ClsCostReportInput
        Inherits ClsCommon

#Region "Variables"

        Private DblPriDRRId As Double
        Private StrPriRevenueCenterId, StrPriRevenueCenterName As String
        Private DtPriBusinessdate As DateTime
        Private XmlCRIXML As XmlDocument

#End Region

#Region " Property"

        Public Property CRIXML() As XmlDocument
            Get
                Return XmlCRIXML
            End Get
            Set(ByVal value As XmlDocument)
                XmlCRIXML = value
            End Set
        End Property

        Public Property Businessdate() As DateTime
            Get
                Return DtPriBusinessdate
            End Get
            Set(ByVal value As DateTime)
                DtPriBusinessdate = value
            End Set
        End Property

        Public Property DRRId() As Double
            Get
                Return DblPriDRRId
            End Get
            Set(ByVal value As Double)
                DblPriDRRId = value
            End Set
        End Property

        Public Property RevenueCenterId() As String
            Get
                Return StrPriRevenueCenterId
            End Get
            Set(ByVal value As String)
                StrPriRevenueCenterId = value
            End Set
        End Property

        Public Property RevenueCenterName() As String
            Get
                Return StrPriRevenueCenterName
            End Get
            Set(ByVal value As String)
                StrPriRevenueCenterName = value
            End Set
        End Property

#End Region



        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            'Try
            '    ObjPriConnection = DbPubDataBase.CreateConnection
            '    ObjPriConnection.Open()
            '    ObjPriTrans = ObjPriConnection.BeginTransaction
            '    ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_deleteEvalPackDRR")
            '    DbPubDataBase.AddInParameter(ObjPriCommand, "@DRRId", DbType.Double, DblPriDRRId)
            '    DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
            '    DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
            '    DbPubDataBase.ExecuteNonQuery(ObjPriCommand)
            '    FunDelete = Trim(ObjPriCommand.Parameters("@Outbit").Value)
            '    StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
            '    ObjPriTrans.Commit()
            'Catch ex As Exception
            '    ObjPriTrans.Rollback()
            '    FunDelete = False

            '    Throw ex
            'Finally

            '    If IsNothing(DbPubDataBase) = False Then
            '        DbPubDataBase = Nothing
            '    End If
            '    If IsNothing(ObjPriCommand) = False Then
            '        ObjPriCommand.Dispose()
            '    End If
            '    If IsNothing(ObjPriConnection) = False Then
            '        ObjPriConnection.Dispose()
            '    End If
            '    If IsNothing(ObjPriTrans) = False Then
            '        ObjPriTrans.Dispose()
            '    End If
            'End Try
        End Function

        Public Overrides Function FunFetch() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_GetRevenueCenForCostReportInput")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@Businessdate", DbType.Date, DtPriBusinessdate)
                FunFetch = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

            Catch ex As Exception
                Throw ex

            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If

            End Try

        End Function

        Public Overrides Function FunSave() As Boolean
            FunSave = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveCostReportInput")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Businessdate", DbType.Date, DtPriBusinessdate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CRIXML", DbType.Xml, XmlCRIXML.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@username", DbType.String, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", DbType.Boolean, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", DbType.String, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunSave = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                ObjPriTrans.Commit()
            Catch ex As Exception
                ObjPriTrans.Rollback()
                Throw ex
            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If
                If IsNothing(ObjPriConnection) = False Then
                    ObjPriConnection = Nothing
                End If

                If IsNothing(ObjPriTrans) = False Then
                    ObjPriTrans = Nothing

                End If
            End Try
        End Function

    End Class

#End Region


End Namespace


