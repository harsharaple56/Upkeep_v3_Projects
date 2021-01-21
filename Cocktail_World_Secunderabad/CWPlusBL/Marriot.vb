Imports System.Xml
Namespace Marriot

#Region "Discount Class"
    Public Class ClsDiscount
        Inherits ClsCommon
#Region "Variables"
        Private StrPriDiscount, StrPriDiscountCode As String
        Private boolPriAng, boolPriCredits As Boolean
#End Region
#Region " Property"

        Public Property Credits() As Boolean
            Get
                Return boolPriCredits
            End Get
            Set(ByVal value As Boolean)
                boolPriCredits = value
            End Set
        End Property

        Public Property Ang() As Boolean
            Get
                Return boolPriAng
            End Get
            Set(ByVal value As Boolean)
                boolPriAng = value
            End Set
        End Property


        Public Property DiscountCode() As String
            Get
                Return StrPriDiscountCode
            End Get
            Set(ByVal value As String)
                StrPriDiscountCode = value
            End Set
        End Property



        Public Property Discount() As String
            Get
                Return StrPriDiscount
            End Get
            Set(ByVal value As String)
                StrPriDiscount = value
            End Set
        End Property
#End Region
        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_DeleteMRDiscountmst")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@DiscountID", DbType.Double, DblPubDiscountID)
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
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_fetchMRDiscountMst")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@DiscountID", DbType.Double, DblPubDiscountID)
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
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveMRDiscountmst")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@DiscountID", DbType.Double, DblPubDiscountID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@DeptID", DbType.Double, dblPubDeptID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@DiscountDesc", DbType.String, StrPriDiscount)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@DiscountCode", DbType.String, StrPriDiscountCode)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@AnG", DbType.Boolean, boolPriAng)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Credits", DbType.Boolean, boolPriCredits)
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

#Region "MR Department Class"
    Public Class ClsMRDepartment
        Inherits ClsCommon

#Region "Variables"
        Private StrPriMRDepartmentDesc, StrPriMRDepartmentCode, DblPubMRDepartmentId As String

#End Region

#Region " Property"

        Public Property MRDepartmentId() As Double
            Get
                Return DblPubMRDepartmentId
            End Get
            Set(ByVal value As Double)
                DblPubMRDepartmentId = value
            End Set
        End Property

        Public Property MRDepartmentCode() As String
            Get
                Return StrPriMRDepartmentCode
            End Get
            Set(ByVal value As String)
                StrPriMRDepartmentCode = value
            End Set
        End Property

        Public Property MRDepartmentDesc() As String
            Get
                Return StrPriMRDepartmentDesc
            End Get
            Set(ByVal value As String)
                StrPriMRDepartmentDesc = value
            End Set
        End Property

#End Region

        Public Sub New()
            DblPubMRDepartmentId = 0
        End Sub

        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_DeleteMRDepartment")
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
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchMRDepartment")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@EvalDeptId", DbType.Double, DblPubMRDepartmentId)
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
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveMRDepartment")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@EvalDeptId", DbType.Double, DblPubEvalDepartmentId)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@EvalDeptDesc", DbType.String, StrPriMRDepartmentDesc)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@EvalDeptCode", DbType.String, StrPriMRDepartmentCode)
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

    Public Class ClsReports
        Inherits ClsCommon

#Region "Variables"

        Protected DtProBusinessDate, DtProFromDate, DtProToDate As Date
        Protected DblPriRevenueCenterId, DblPriCheckId, DblPriAmount, DblPriAngHeadId As Double
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
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchMRDCCReport")
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


        Public Function FunFetchCoverStatementReport() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchMRCoverStatementReport")
                ObjPriDbCommand.CommandTimeout = 10000
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.Date, DtProFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, DtProToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@username", DbType.String, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriDbCommand, "@OutMsg", DbType.String, 200)
                FunFetchCoverStatementReport = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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


        Public Function FunFetchTopSheet() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchMRTopSheet")
                ObjPriDbCommand.CommandTimeout = 10000
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.Date, DtProFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, DtProToDate)
                FunFetchTopSheet = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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

        Public Function FunFetchMRVoidDiscountSummary() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchMRVoidDiscountSummary")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.Date, DtProFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, DtProToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@username", DbType.String, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriDbCommand, "@OutMsg", DbType.String, 200)
                FunFetchMRVoidDiscountSummary = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchMRCheckForAnG")
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
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchNonPromotionalMealSummaryForMR")
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



        Public Function FunFetchRevenueCenters() As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_GetRevenueCentersForMR")
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
                FunFetchNetSaleForDRR = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_DeleteMRDesignation")
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
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_fetchMRDesignationMst")
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
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveMRDesignation")
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
End Namespace
