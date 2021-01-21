Imports System.Xml
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data.Common
Namespace Master
#Region " Class Menu"
    Public Class Utitity
        Inherits ClsCommon

        

        Public Function FunFetchmenu() As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchMenu")

                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@userID", DbType.Double, DblPubUserID)
                FunFetchmenu = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)



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

        Public Function FunFetchLicense() As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_fetchlicense")
                ''ubDataBase.AddInParameter(ObjPriDbCommand, "@UserID", DbType.Double, DblPubUserID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                FunFetchLicense = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

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

        Public Function FunFetchLicenseCode() As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchLicenseCode")
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

        Public Function FunFetchLicenseByRights() As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_fetchlicenseBYRights")

                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@userID", DbType.Double, DblPubUserID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseID", DbType.Double, DblPubLicenseID)

                FunFetchLicenseByRights = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

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

        Public Function FunFetchLicenseForTransferWise() As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_fetchlicenseForTransfer")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseID", DbType.Double, DblPubLicenseID)

                FunFetchLicenseForTransferWise = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

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

        Public Overrides Function FunDelete() As Boolean

        End Function

        Public Overrides Function FunFetch() As System.Data.DataTable

        End Function

        Public Overrides Function FunSave() As Boolean

        End Function
    End Class
#End Region

#Region "Category Class"
    Public Class ClsCategory
        Inherits ClsCommon
#Region "VAriables"
        Private Strcategorydesc As String
        Private Intpubbottle, IntPubSpeg, IntpubLpeg As Integer
        Private BoolIsExcise As Boolean
        Private ArrCatgPriceSeq As XmlDocument
#End Region
#Region "Property"
        Public Property CatgPriceSeqXML() As XmlDocument
            Get
                Return ArrCatgPriceSeq
            End Get
            Set(ByVal value As XmlDocument)
                ArrCatgPriceSeq = value
            End Set
        End Property

        Public Property IsExcise() As Boolean
            Get
                Return BoolIsExcise
            End Get
            Set(ByVal value As Boolean)
                BoolIsExcise = value
            End Set
        End Property
        Public Property Lpeg() As Integer
            Get
                Return IntpubLpeg
            End Get
            Set(ByVal value As Integer)
                IntpubLpeg = value
            End Set
        End Property
        Public Property Speg() As Integer
            Get
                Return IntPubSpeg
            End Get
            Set(ByVal value As Integer)
                IntPubSpeg = value
            End Set
        End Property
        Public Property Bottle() As Integer
            Get
                Return Intpubbottle
            End Get
            Set(ByVal value As Integer)
                Intpubbottle = value
            End Set
        End Property
        Public Property Categorydesc() As String
            Get
                Return Strcategorydesc
            End Get
            Set(ByVal value As String)
                Strcategorydesc = value
            End Set
        End Property

#End Region
        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                'ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_DeleteCategory")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Categoryid", DbType.Double, DblPubCategoryID)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand)
                FunDelete = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                ' ObjPriTrans.Commit()
            Catch ex As Exception
                FunDelete = False
                'ObjPriTrans.Rollback()
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
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchCategory")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@CategoryID", DbType.Double, DblPubCategoryID)
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

        Public Function FunFetchCatgPriceSeq() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_fetchCategoryPriceSequence")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@CategoryID", DbType.Double, DblPubCategoryID)
                FunFetchCatgPriceSeq = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

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
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveCategory")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CategoryID", DbType.Double, DblPubCategoryID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CategoryDesc", SqlDbType.VarChar, Strcategorydesc)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Bottle", SqlDbType.Int, Intpubbottle)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Speg", SqlDbType.Int, IntPubSpeg)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Lpeg", SqlDbType.Int, IntpubLpeg)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@IsExcise", SqlDbType.Int, BoolIsExcise)
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

        Public Function FunSaveCatgPriceSeq() As Boolean
            FunSaveCatgPriceSeq = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("[spr_SaveCategoryPriceSequence]")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CategoryID", DbType.Double, DblPubCategoryID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CatgPriceSequenceXML", DbType.Xml, ArrCatgPriceSeq.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@username", DbType.String, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", DbType.String, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunSaveCatgPriceSeq = Trim(ObjPriCommand.Parameters("@Outbit").Value)
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

#Region "Sub Category Master"
    Public Class ClsSubCategoryMaster
        Inherits ClsCommon

#Region "Variable"
        Dim StrPriSubCategoryDesc, StrPriSubCategoryMajorDesc As String
#End Region
#Region "Property"
        Public Property SubCategoryDesc() As String
            Get
                Return StrPriSubCategoryDesc
            End Get
            Set(ByVal value As String)
                StrPriSubCategoryDesc = value
            End Set
        End Property

        Public Property SubCategoryMajorDesc() As String
            Get
                Return StrPriSubCategoryMajorDesc
            End Get
            Set(ByVal value As String)
                StrPriSubCategoryMajorDesc = value
            End Set
        End Property
#End Region

        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                'ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_DeleteSubCategory")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@SubCategoryid", DbType.Double, DblPubSubCategoryID)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand)
                FunDelete = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                ' ObjPriTrans.Commit()
            Catch ex As Exception
                FunDelete = False
                'ObjPriTrans.Rollback()
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
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchSubCategory")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@SubCategoryID", DbType.Double, DblPubSubCategoryID)
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
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveSubCategory")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@SubCategoryID", DbType.Double, DblPubSubCategoryID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CategoryID", DbType.Double, DblPubCategoryID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@SubCategoryName", SqlDbType.VarChar, StrPriSubCategoryDesc)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@MajorName", SqlDbType.VarChar, StrPriSubCategoryMajorDesc)
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

        Public Function FunFetchSubCategoryMaster() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchSubCategoryByCategoryWise")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@CategoryID", DbType.Double, DblPubCategoryID)
                FunFetchSubCategoryMaster = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

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

#Region "Sub Category Master"
    Public Class ClsDeptMaster
        Inherits ClsCommon

#Region "Variable"
        Dim StrPriDeptDesc, StrPriShortDesc, StrPriDeptCode As String
#End Region
#Region "Property"
        Public Property DeptCode() As String
            Get
                Return StrPriDeptCode
            End Get
            Set(ByVal value As String)
                StrPriDeptCode = value
            End Set
        End Property
        Public Property ShortDesc() As String
            Get
                Return StrPriShortDesc
            End Get
            Set(ByVal value As String)
                StrPriShortDesc = value
            End Set
        End Property
        Public Property DeptDesc() As String
            Get
                Return StrPriDeptDesc
            End Get
            Set(ByVal value As String)
                StrPriDeptDesc = value
            End Set
        End Property
#End Region

        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("[spr_deleteDept]")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@DeptId", DbType.Double, dblPubDeptID)
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
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("spr_FetchDeptMaster")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@DeptId", DbType.Double, dblPubDeptID)
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
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("[Spr_SaveDeptMaster]")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@DeptID", DbType.Double, dblPubDeptID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@DeptDesc", DbType.String, StrPriDeptDesc)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@ShortDesc", DbType.String, StrPriShortDesc)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@DeptCode", DbType.String, StrPriDeptCode)
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

#Region "Size Class"
    Public Class ClsSize
        Inherits ClsCommon
#Region "Variables"
        Private strSizeDesc As String
#End Region
#Region " Property"
        Public Property Sizedesc() As String
            Get
                Return strSizeDesc
            End Get
            Set(ByVal value As String)
                strSizeDesc = value
            End Set
        End Property
#End Region
        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                'ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_DeleteSize")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Sizeid", DbType.Double, DblPubSizeID)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand)
                FunDelete = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                'ObjPriTrans.Commit()
            Catch ex As Exception
                FunDelete = False
                ' ObjPriTrans.Rollback()
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
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchSize")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@sizeid", DbType.Double, DblPubSizeID)
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
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveSize")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Sizeid", DbType.Double, DblPubSizeID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@SizeDesc", SqlDbType.VarChar, strSizeDesc)
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

#Region "Category Size Linkup Class"
    Public Class ClsCategorySizelinlup
        Inherits ClsCommon

#Region "Variables"

        Private ArrCategorySizeLnkUp As XmlDocument

#End Region

#Region "Property"

        Public Property CategorySizeLnkUpXML() As XmlDocument
            Get
                Return ArrCategorySizeLnkUp
            End Get
            Set(ByVal value As XmlDocument)
                ArrCategorySizeLnkUp = value
            End Set
        End Property

#End Region

        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_DeleteCategorysizelinkup")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CategorySizeLinkID", DbType.Double, DblPubCategorySizeLinkID)
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
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchCategorySizeLinkUP")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@CategoryID", DbType.Double, DblPubCategoryID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
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

        Public Function CheckCategorySizeLinkUpExistence() As Boolean

            CheckCategorySizeLinkUpExistence = False
            Try

                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("validatecategorysizelinkup")

                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CategoryId", DbType.Double, DblPubCategoryID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@size", DbType.Double, DblPubSizeID)

                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)

                DbPubDataBase.ExecuteNonQuery(ObjPriCommand)
                CheckCategorySizeLinkUpExistence = Trim(ObjPriCommand.Parameters("@Outbit").Value)

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

        Public Overrides Function FunSave() As Boolean

            FunSave = False
            Try

                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveCategorySizeLinkUP")

                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CategoryID", DbType.Double, DblPubCategoryID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CategorySizeXML", DbType.Xml, ArrCategorySizeLnkUp.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Username", SqlDbType.VarChar, StrPubOperator)
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

#Region "Brand Opening"
    Public Class ClsBrandOpening
        Inherits ClsCommon

#Region "Variables"

        Private ArrBrandOpening, ArrCategorysizelinkId, ArrLicenseWise As XmlDocument
        Private BlIsBaseQty As Boolean
        Private DblPriSpegRate, DblPriLpegRate As Double
#End Region

 
#Region "Property"
        Public Property LpegRate() As Double
            Get
                Return DblPriLpegRate
            End Get
            Set(ByVal value As Double)
                DblPriLpegRate = value
            End Set
        End Property

        Public Property SpegRate() As Double
            Get
                Return DblPriSpegRate
            End Get
            Set(ByVal value As Double)
                DblPriSpegRate = value
            End Set
        End Property

        Public Property IsBaseQty() As Boolean
            Get
                Return BlIsBaseQty
            End Get
            Set(ByVal value As Boolean)
                BlIsBaseQty = value
            End Set
        End Property

        Public Property BrandOpeningXML() As XmlDocument
            Get
                Return ArrBrandOpening
            End Get
            Set(ByVal value As XmlDocument)
                ArrBrandOpening = value
            End Set
        End Property
        Public Property categorySizeXML() As XmlDocument
            Get
                Return ArrCategorysizelinkId
            End Get
            Set(ByVal value As XmlDocument)
                ArrCategorysizelinkId = value
            End Set
        End Property
        Public Property LicensewiseXML() As XmlDocument
            Get
                Return ArrLicenseWise
            End Get
            Set(ByVal value As XmlDocument)
                ArrLicenseWise = value
            End Set
        End Property
#End Region

        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_DeleteBrandOpening")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Brandid", DbType.Double, DblPubBrandID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@categorysizelinkupid", DbType.Double, DblPubCategorySizeLinkID)
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
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("[Spr_FetchBrandOpening]")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@brandid", DbType.Double, DblPubBrandID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
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

        Public Function CheckBrandOpeningExistence() As Boolean

            CheckBrandOpeningExistence = False
            Try

                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("[spr_validatebrandopening]")

                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Brandid", DbType.Double, DblPubBrandID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@categorysizelinkupid", DbType.Double, DblPubCategorySizeLinkID)

                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)

                DbPubDataBase.ExecuteNonQuery(ObjPriCommand)
                CheckBrandOpeningExistence = Trim(ObjPriCommand.Parameters("@Outbit").Value)

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

        Public Overrides Function FunSave() As Boolean

            FunSave = False
            Try

                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("[spr_SaveBrandOpening]")

                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Brandid", DbType.Double, DblPubBrandID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@SpegRate", DbType.Double, DblPriSpegRate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LpegRate", DbType.Double, DblPriLpegRate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@BrandOpeningXML", DbType.Xml, ArrBrandOpening.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@IsBaseQty", DbType.Boolean, BlIsBaseQty)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Username", SqlDbType.VarChar, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand)
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

        Public Function FunValidatelicenseWise() As Boolean

            FunValidatelicenseWise = False
            Try

                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_ValidateLicensewiseSize")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseIDXML", DbType.Xml, ArrCategorysizelinkId.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CategorySizelinkupIdXML", DbType.Xml, ArrLicenseWise.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Username", SqlDbType.VarChar, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunValidatelicenseWise = Trim(ObjPriCommand.Parameters("@Outbit").Value)
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

#Region "Brand Class"
    Public Class ClsBrandHeadDet
        Inherits ClsCommon

#Region "Variables"

        Private StrPriBrandDesc, StrPriShortname As String
        Private DblPriStrength, DblPriPurRate As Double

        Private ArrBrandDet As XmlDocument

#End Region

#Region "Property"
        Public Property BrandDesc() As String
            Get
                Return StrPriBrandDesc
            End Get
            Set(ByVal value As String)
                StrPriBrandDesc = value
            End Set
        End Property

        Public Property Shortname() As String
            Get
                Return StrPriShortname
            End Get
            Set(ByVal value As String)
                StrPriShortname = value
            End Set
        End Property

        Public Property Strength() As Double
            Get
                Return DblPriStrength
            End Get
            Set(ByVal value As Double)
                DblPriStrength = value
            End Set
        End Property

        Public Property PurRate() As Double
            Get
                Return DblPriPurRate
            End Get
            Set(ByVal value As Double)
                DblPriPurRate = value
            End Set
        End Property

        Public Property BrandDetXML() As XmlDocument
            Get
                Return ArrBrandDet
            End Get
            Set(ByVal value As XmlDocument)
                ArrBrandDet = value
            End Set
        End Property

#End Region

        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ' ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("spr_deletebrand")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Brandid", DbType.Double, DblPubBrandID)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand)
                FunDelete = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                ' ObjPriTrans.Commit()
            Catch ex As Exception
                FunDelete = False
                'ObjPriTrans.Rollback()
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
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchBrandHeadDet")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@brandid", DbType.Double, DblPubBrandID)

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
                'ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveBrandHeadDetails")
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveBrand")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Is_Active", DbType.Double, DisableID)   'Added by Samvedna on [22-01-20] 
                DbPubDataBase.AddInParameter(ObjPriCommand, "@brandid", DbType.Double, DblPubBrandID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CategoryID", DbType.Double, DblPubCategoryID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@BrandDetXML", DbType.Xml, ArrBrandDet.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@BrandDesc", DbType.String, StrPriBrandDesc)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@ShortName", DbType.String, StrPriShortname)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Strength", DbType.Double, DblPriStrength)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PurchaseRate", DbType.Double, DblPriPurRate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@SubCategoryID", DbType.Double, DblPubSubCategoryID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Username", SqlDbType.VarChar, StrPubOperator)
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

#Region "Assign MMS Code"
    Public Class ClsAssignMMSCode
        Inherits ClsCommon
#Region "Variables"

        Private ArrAssignBrandCode As XmlDocument
        Private dblpritypeid, dblmmsCode As Double
#End Region
#Region "Property"

        Public Property AssignBrandCodeXML() As XmlDocument
            Get
                Return ArrAssignBrandCode
            End Get
            Set(ByVal value As XmlDocument)
                ArrAssignBrandCode = value
            End Set
        End Property

        Public Property TypeID() As Double
            Get
                Return dblpritypeid
            End Get
            Set(ByVal value As Double)
                dblpritypeid = value
            End Set
        End Property

        Public Property MMSCode() As Double
            Get
                Return dblmmsCode
            End Get
            Set(ByVal value As Double)
                dblmmsCode = value
            End Set
        End Property



#End Region

       Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("spr_deleteAssignMMScode")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@MMSID", DbType.Double, dblpubAssignBrandCodeiD)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseId", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
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
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchAssignMMSCode")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@MMSID", DbType.Double, DblPubBrandID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@AssignBrandCodeID", DbType.Double, dblpubAssignBrandCodeiD)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
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
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("[spr_SaveAssignMMSCode]")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@MMSCodeID", DbType.Double, dblmmsCode)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Brandid", DbType.Double, DblPubBrandID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@sizeID", DbType.Double, DblPubCategorySizeLinkID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@AssignBrandXML", DbType.Xml, ArrAssignBrandCode.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@TypeID", DbType.Double, dblpritypeid)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Username", SqlDbType.VarChar, StrPubOperator)
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

#Region "Assign Brand Code"
    Public Class ClsAssignBrandCode
        Inherits ClsCommon

#Region "Variables"

        Private ArrAssignBrandCode As XmlDocument

#End Region

#Region "Property"

        Public Property AssignBrandCodeXML() As XmlDocument
            Get
                Return ArrAssignBrandCode
            End Get
            Set(ByVal value As XmlDocument)
                ArrAssignBrandCode = value
            End Set
        End Property

#End Region

        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("spr_deleteAssignBrandcode")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@AssignBrandCodeID", DbType.Double, dblpubAssignBrandCodeiD)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseId", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
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
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("[Spr_FetchAssignBrandCode]")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@brandid", DbType.Double, DblPubBrandID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@AssignBrandCodeID", DbType.Double, dblpubAssignBrandCodeiD)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
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
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("[spr_SaveAssignBrandCode]")

                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@AssignBrandCodeID", DbType.Double, dblpubAssignBrandCodeiD)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Brandid", DbType.Double, DblPubBrandID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CategorySizeLinkUpID", DbType.Double, DblPubCategorySizeLinkID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@AssignBrandXML", DbType.Xml, ArrAssignBrandCode.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Username", SqlDbType.VarChar, StrPubOperator)
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

#Region "UserMaster"
    Public Class ClsUserMaster
        Inherits ClsCommon

#Region "Variable"
        Dim gloStrPassword As String
        Dim gloStrUserName As String


        Dim StrPriUserName As String

        Dim blAdmin, blDefaultRole As Boolean
#End Region

#Region "Property"
        Public Property gloUserName As String
            Get
                Return gloStrUserName
            End Get
            Set(ByVal value As String)
                gloStrUserName = value
            End Set
        End Property
        Public Property gloPassword As String
            Get
                Return gloStrPassword
            End Get
            Set(ByVal value As String)
                gloStrPassword = value
            End Set
        End Property


        Public Property User() As String
            Get
                Return StrPriUserName
            End Get
            Set(ByVal value As String)
                StrPriUserName = value
            End Set
        End Property

        Public Property Administrator() As Boolean
            Get
                Return blAdmin
            End Get
            Set(ByVal value As Boolean)
                blAdmin = value
            End Set
        End Property

        Public Property DefaultRole() As Boolean
            Get
                Return blDefaultRole
            End Get
            Set(ByVal value As Boolean)
                blDefaultRole = value
            End Set
        End Property


#End Region



        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_DeleteUserMaster")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@UserID", DbType.Double, DblPubUserID)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
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

        Public Overrides Function FunFetch() As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchUserMaster")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@UserID", DbType.Double, DblPubUserID)
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
        Public Function funValidate() As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_ValidateLogin")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@UserName", SqlDbType.VarChar, StrPubOperator)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@Password", SqlDbType.VarChar, gloStrPassword)

                funValidate = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

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

        Public Function FunChangePassword(ByVal CurrentPwd As String, ByVal NewPwd As String) As Boolean

            FunChangePassword = False
            Try

                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("[Spr_SaveChangePassword]")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@UserID", DbType.Double, DblPubUserID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CurrentPwd", SqlDbType.VarChar, CurrentPwd)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@NewPwd", SqlDbType.VarChar, NewPwd)

                DbPubDataBase.AddInParameter(ObjPriCommand, "@UserName", SqlDbType.VarChar, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunChangePassword = Trim(ObjPriCommand.Parameters("@Outbit").Value)
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


        Public Overrides Function FunSave() As Boolean

            FunSave = False
            Try

                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveUserMaster")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@UserID", DbType.Double, DblPubUserID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@User", SqlDbType.VarChar, StrPriUserName)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Administrator", DbType.Boolean, blAdmin)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@DefaultRole", DbType.Boolean, blDefaultRole)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@UserName", SqlDbType.VarChar, StrPubOperator)
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

#Region "PermitTypeMaster"
    Public Class ClsPermitTypeMaster
        Inherits ClsCommon

#Region "Variable"
        Private StrPriPermitTypeDesc As String
#End Region

#Region "Property"
        Public Property PermitTypeDesc As String
            Get
                Return StrPriPermitTypeDesc
            End Get
            Set(ByVal value As String)
                StrPriPermitTypeDesc = value
            End Set
        End Property
#End Region


        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                'ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_DeletePermitTypeMaster")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PermitTypeID", DbType.Double, DblPubPermitTypeID)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand)
                FunDelete = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                ' ObjPriTrans.Commit()
            Catch ex As Exception
                FunDelete = False
                ' ObjPriTrans.Rollback()
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
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchPermittypeMaster")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@PermitTypeID", DbType.Double, DblPubPermitTypeID)
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
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SavePermitTypeMaster")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PermitTypeID", DbType.Double, DblPubPermitTypeID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PermitDesc", SqlDbType.VarChar, StrPriPermitTypeDesc)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Username", SqlDbType.VarChar, StrPubOperator)
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

#Region "PermitHolderMaster"
    Public Class ClsPermitHolderMaster
        Inherits ClsCommon

#Region "Variable"
        Private StrPriPermitHolderNumber As Double
        Private StrPriPermitHolderName As String
        Private dtpriExpireDate As Date

#End Region

#Region "Property"
        Public Property PermitHolderNumber() As Double
            Get
                Return StrPriPermitHolderNumber
            End Get
            Set(ByVal value As Double)
                StrPriPermitHolderNumber = value
            End Set
        End Property

        Public Property ExpireDate() As Date
            Get
                Return dtpriExpireDate
            End Get
            Set(ByVal value As Date)
                dtpriExpireDate = value
            End Set
        End Property

        Public Property PermitHolderName As String
            Get
                Return StrPriPermitHolderName
            End Get
            Set(ByVal value As String)
                StrPriPermitHolderName = value
            End Set
        End Property
#End Region


        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                'ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_DeletePermitHolderMaster")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PermitHolderID", DbType.Double, DblPubPermitHolderID)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand)
                FunDelete = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                'ObjPriTrans.Commit()
            Catch ex As Exception
                FunDelete = False
                ' ObjPriTrans.Rollback()
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
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchPermitHolderMaster")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@PermitHolderID", DbType.Double, DblPubPermitHolderID)
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
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SavePermitHolderMaster")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PermitHolderID", DbType.Double, DblPubPermitHolderID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PermitHolderNumber", SqlDbType.VarChar, StrPriPermitHolderNumber)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PermitHolderName", SqlDbType.VarChar, StrPriPermitHolderName)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PermitExpireDate", DbType.DateTime, dtpriExpireDate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PermitTypeID", DbType.Double, DblPubPermitTypeID)


                DbPubDataBase.AddInParameter(ObjPriCommand, "@Username", SqlDbType.VarChar, StrPubOperator)
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
        Public Function FunFetchPermitHolderExpiryDate() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchPermitHolderByExpiryDate")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@Date", DbType.DateTime, dtpriExpireDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@PermitHolderID", DbType.Double, DblPubPermitHolderID)
                FunFetchPermitHolderExpiryDate = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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

#Region "Supplier Master"
    Public Class ClsSupplier
        Inherits ClsCommon

#Region "Variable"
        Dim StrPriSupplierName, StrPriAddress, StrPriCity, StrPriPincode, StrPriTelephone, StrPriEmail, StrPriCode As String
#End Region

#Region "Property"
        Public Property Code() As String
            Get
                Return StrPriCode
            End Get
            Set(ByVal value As String)
                StrPriCode = value
            End Set
        End Property

        Public Property SupplierName() As String
            Get
                Return StrPriSupplierName
            End Get
            Set(ByVal value As String)
                StrPriSupplierName = value
            End Set
        End Property

        Public Property Address() As String
            Get
                Return StrPriAddress
            End Get
            Set(ByVal value As String)
                StrPriAddress = value
            End Set
        End Property

        Public Property City() As String
            Get
                Return StrPriCity
            End Get
            Set(ByVal value As String)
                StrPriCity = value
            End Set
        End Property

        Public Property Pincode() As String
            Get
                Return StrPriPincode
            End Get
            Set(ByVal value As String)
                StrPriPincode = value
            End Set
        End Property

        Public Property Telephone() As String
            Get
                Return StrPriTelephone
            End Get
            Set(ByVal value As String)
                StrPriTelephone = value
            End Set
        End Property

        Public Property Email() As String
            Get
                Return StrPriEmail
            End Get
            Set(ByVal value As String)
                StrPriEmail = value
            End Set
        End Property

#End Region

        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("[Spr_DeleteSupplier]")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@supplierid", DbType.Double, DblPubSupplierID)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
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

        Public Overrides Function FunFetch() As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("[Spr_FetchSupplier]")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@supplierID", DbType.Double, DblPubSupplierID)
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
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("[Spr_SaveSupplier]")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@supplierid", DbType.Double, DblPubSupplierID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@suppliername", SqlDbType.VarChar, StrPriSupplierName)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@address", DbType.String, StrPriAddress)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@city", DbType.String, StrPriCity)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@telephone", DbType.String, StrPriTelephone)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@pincode", DbType.String, StrPriPincode)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@email", DbType.String, StrPriEmail)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@suppliercode", DbType.String, StrPriCode)
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

#Region " Category Tax Master"
    Public Class ClscategoryTax
        Inherits ClsCommon
#Region "Variables"
        Private strtaxtype As String
        Private Inttaxper As Integer
#End Region
#Region "Property"
        Public Property Taxtype() As String
            Get
                Return strtaxtype
            End Get
            Set(ByVal value As String)
                strtaxtype = value
            End Set
        End Property
        Public Property TaxPercentage() As Integer
            Get
                Return Inttaxper
            End Get
            Set(ByVal value As Integer)
                Inttaxper = value
            End Set
        End Property
#End Region
        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_DeleteCategoryTax")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CategoryTaxID", DbType.Double, DblPubCategoryTaxID)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
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
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_fetchcategorytax")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@categorytaxid", DbType.Double, DblPubCategoryTaxID)
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
        Public Function FunFetchcategorytax() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_fetchcategorytaxpercentage")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@categorytaxid", DbType.Double, DblPubCategoryTaxID)
                FunFetchcategorytax = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

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
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveCategorytax")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CategoryTaxID", DbType.Double, DblPubCategoryTaxID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CategoryID", DbType.Double, DblPubCategoryID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Taxtype", SqlDbType.VarChar, strtaxtype)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Taxpercetage", SqlDbType.Int, Inttaxper)
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

#Region "UserMenuRights"
    Public Class ClsUserMenuRights
        Inherits ClsCommon

#Region "Variable"


        Public ArrPubParameterID As Array
        Public StrArrParameterId As XmlDocument
        Public StrArrMenuPriority As XmlDocument

#End Region
#Region "Property"

        Public Property ArrUserParameterId() As XmlDocument
            Get
                Return StrArrParameterId
            End Get
            Set(ByVal value As XmlDocument)
                StrArrParameterId = value
            End Set
        End Property

        Public Property ArrMenuPriority() As XmlDocument
            Get
                Return StrArrMenuPriority
            End Get
            Set(ByVal value As XmlDocument)
                StrArrMenuPriority = value
            End Set
        End Property


        Public Property ArrParameterId As Array
            Get
                Return ArrPubParameterID
            End Get
            Set(ByVal value As Array)
                ArrPubParameterID = value
            End Set
        End Property
#End Region



        Public Overrides Function FunDelete() As Boolean

        End Function

        Public Overrides Function FunFetch() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchMenuItems")
                ' DbPubDataBase.AddInParameter(ObjPriDbCommand, "@PermitHolderID", DbType.Double, DblPubPermitHolderID)
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

        Public Function FunFetchParentMenu() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchParentMenu")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@MenuID", DbType.Double, DblPubMenuID)
                FunFetchParentMenu = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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


        Public Function FunFetchParentMenuForPriority() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchParentMenuForPriority")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@MenuID", DbType.Double, DblPubMenuID)
                FunFetchParentMenuForPriority = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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
            Dim xmlDocProm As XmlDocument = Nothing
            Dim ObjLocDbCommand As DbCommand = Nothing

            Dim xmlDocPromType As XmlDocument = Nothing
            Dim ObjLocDbCommandType As DbCommand = Nothing
            Try
                xmlDocProm = New XmlDocument
                xmlDocProm.LoadXml("<Master><MenuRights></MenuRights></Master>")

                Dim XmlElt As XmlElement = xmlDocProm.CreateElement("UserMenuRights")

                For intLocRowCtr As Integer = 0 To ArrParameterId.Length - 2
                    If Trim(ArrParameterId(intLocRowCtr).ToString) <> "" Then
                        Dim LocArr As Array = Split(ArrParameterId(intLocRowCtr), "#")

                        XmlElt = xmlDocProm.CreateElement("UserMenuRights")
                        XmlElt.SetAttribute("MenuId", LocArr(0))
                        XmlElt.SetAttribute("rightsTypeChoice", LocArr(1))
                        xmlDocProm.DocumentElement.Item("MenuRights").AppendChild(XmlElt)
                    End If
                Next

                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveUserMenuRightsBYSHIVA")

                DbPubDataBase.AddInParameter(ObjPriCommand, "@UserID", DbType.Double, DblPubUserID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@ParentMenuID", DbType.Double, DblPubParentMenuID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@XmlDoc", DbType.Xml, xmlDocProm.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@XmlDocShiva", DbType.Xml, StrArrParameterId.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Username", SqlDbType.VarChar, StrPubOperator)
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

        Public Function FunUpdateMenuPriority() As Boolean
            FunUpdateMenuPriority = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_UpdateMenuPriority")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@XmlDoc", SqlDbType.Xml, StrArrMenuPriority.InnerXml)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunUpdateMenuPriority = Trim(ObjPriCommand.Parameters("@Outbit").Value)
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

        Public Function FunFetchRightsCheckListData() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchRightsCheckedData")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@MenuID", DbType.Double, DblPubMenuID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@UserID", DbType.Double, DblPubUserID)

                FunFetchRightsCheckListData = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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

#Region "Assign Cocktail Code"
    Public Class AssignCocktailCode
        Inherits ClsCommon
#Region "Variables"
        Private strcocktailcode As String
#End Region
#Region "Property"
        Public Property Cocktailcode As String
            Get
                Return strcocktailcode
            End Get
            Set(ByVal value As String)
                strcocktailcode = value
            End Set
        End Property
#End Region
        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_DeleteAssignCocktailCode")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@AssigncocktailcodeID", DbType.Double, DblPubAssignCocktailcodeID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseId", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
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

        Public Function FetchAssigncocktail() As System.Data.DataSet
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchAssigncocktailcode")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@AssigncocktailcodeID", DbType.Double, DblPubAssignCocktailcodeID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                FetchAssigncocktail = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand)
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
        Public Overrides Function FunFetch() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("spr_fetchcocktailcode")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@cocktailid", DbType.Double, DblPubCocktailID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseId", DbType.Double, DblPubLicenseID)
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

        Public Function FetchCocktailCodeByLicenseWise() As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchCocktailCodeByLicenseWise")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                FetchCocktailCodeByLicenseWise = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveAssignCocktailCode")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@AssigncocktailcodeID", DbType.Double, DblPubAssignCocktailcodeID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CocktailID", DbType.Double, DblPubCocktailID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Cocktailcode", SqlDbType.VarChar, strcocktailcode)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseId", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Username", SqlDbType.VarChar, StrPubOperator)
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

#Region "Cocktail Master"
    Public Class Clscocktail
        Inherits ClsCommon
#Region "Variables"
        Private StrpriCocktailName As String
        Private Dblprirate As Double
        Private ArrCocktail As XmlDocument
#End Region
#Region "Property"
        Public Property CocktailXML() As XmlDocument
            Get
                Return ArrCocktail
            End Get
            Set(ByVal value As XmlDocument)
                ArrCocktail = value
            End Set
        End Property
        Public Property rate As Double
            Get
                Return Dblprirate
            End Get
            Set(ByVal value As Double)
                Dblprirate = value
            End Set
        End Property
        Public Property CocktailName As String
            Get
                Return StrpriCocktailName
            End Get
            Set(ByVal value As String)
                StrpriCocktailName = value
            End Set
        End Property
#End Region
        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                'ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_DeleteCocktail")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Cocktailid", DbType.Double, DblPubCocktailID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Licenseid", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand)
                FunDelete = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                'ObjPriTrans.Commit()
            Catch ex As Exception
                FunDelete = False
                'ObjPriTrans.Rollback()
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
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchCocktail")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@CocktailID", DbType.Double, DblPubCocktailID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
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
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_Savecocktail")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CocktailId", DbType.Double, DblPubCocktailID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CocktailName", SqlDbType.VarChar, StrpriCocktailName)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@rate", DbType.Double, Dblprirate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CocktailXML", DbType.Xml, ArrCocktail.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Username", SqlDbType.VarChar, StrPubOperator)
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

#Region "Purchase Master"
    Public Class Clspurchase
        Inherits ClsCommon
#Region "Variables"
        Private strPriTPno, StrPriInvoiceNo, StrPriOtherchargeType, StrPriMlType, StrPriGRNForCode As String
        Private dtPurchasedate, dtFromDate, dtToDate As Date
        Private dblPubOthercharge, DblPubDiscountper, DblPubDiscount, DblPubForLicenseId As Double
        Private ArrPurchaseXML As XmlDocument
#End Region
#Region "Property"

        Public Property FromDate() As DateTime
            Get
                Return dtFromDate
            End Get
            Set(ByVal value As DateTime)
                dtFromDate = value
            End Set
        End Property

        Public Property ToDate() As DateTime
            Get
                Return dtToDate
            End Get
            Set(ByVal value As DateTime)
                dtToDate = value
            End Set
        End Property

        Public Property MlType() As String
            Get
                Return StrPriMlType
            End Get
            Set(ByVal value As String)
                StrPriMlType = value
            End Set
        End Property

        Public Property GRNForCode() As String
            Get
                Return StrPriGRNForCode
            End Get
            Set(ByVal value As String)
                StrPriGRNForCode = value
            End Set
        End Property

        Public Property TPno() As String
            Get
                Return strPriTPno
            End Get
            Set(ByVal value As String)
                strPriTPno = value
            End Set
        End Property
        Public Property InvoiceNo() As String
            Get
                Return StrPriInvoiceNo
            End Get
            Set(ByVal value As String)
                StrPriInvoiceNo = value
            End Set
        End Property
        Public Property OtherchargeType() As String
            Get
                Return StrPriOtherchargeType
            End Get
            Set(ByVal value As String)
                StrPriOtherchargeType = value
            End Set
        End Property
        Public Property Purchasedate() As Date
            Get
                Return dtPurchasedate
            End Get
            Set(ByVal value As Date)
                dtPurchasedate = value
            End Set
        End Property
        Public Property Othercharge() As Double
            Get
                Return dblPubOthercharge
            End Get
            Set(ByVal value As Double)
                dblPubOthercharge = value
            End Set
        End Property
        Public Property Discountper() As Double
            Get
                Return DblPubDiscountper
            End Get
            Set(ByVal value As Double)
                DblPubDiscountper = value
            End Set
        End Property
        Public Property Discount() As Double
            Get
                Return DblPubDiscount
            End Get
            Set(ByVal value As Double)
                DblPubDiscount = value
            End Set
        End Property
        Public Property ForLicenseId() As Double
            Get
                Return DblPubForLicenseId
            End Get
            Set(ByVal value As Double)
                DblPubForLicenseId = value
            End Set
        End Property

        Public Property PurchaseXML() As XmlDocument
            Get
                Return ArrPurchaseXML
            End Get
            Set(ByVal value As XmlDocument)
                ArrPurchaseXML = value
            End Set
        End Property

#End Region
        Public Sub New()
            FromDate = "#1/1/1900#"
            ToDate = "#1/1/1900#"
        End Sub


        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_DeletePurchase")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PurchaseId", DbType.Double, DblPubPurchaseID)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
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
        Public Function BindSizes() As DataSet
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_bindsizes")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@brandid", DbType.Double, DblPubBrandID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                BindSizes = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand)

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

        Public Function BindMMSSize() As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("spr_fetchSizeBrandCatgwise")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@brandid", DbType.Double, DblPubBrandID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                BindMMSSize = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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
        Public Function BindPurchaseRate() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_fetchpurchaseRate")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@Brandid", DbType.Double, DblPubBrandID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@CategorySizeLinkUpID", DbType.Double, DblPubCategorySizeLinkID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@categorytaxid", DbType.Double, DblPubCategoryTaxID)
                BindPurchaseRate = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

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
        Public Function BindBrandOpening() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_Bindbrandopening")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@TransDate", DbType.DateTime, DblTransDate)  'Added by Samvedna on [23-01-20]
                ' DbPubDataBase.AddInParameter(ObjPriDbCommand, "@TransDate", DbType.String, DblTransDate)  'Added by Samvedna on [23-01-20]
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@brandopeningid", DbType.Double, dblPubBrandOpeningId)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
                BindBrandOpening = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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

        Public Function BindSupplier() As System.Data.DataSet
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_Bindsupplier")
                BindSupplier = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand)

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
        Public Function BindTaxpercentage() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("spr_fetchtaxpercentage")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@CategoryTaxId", DbType.Double, DblPubCategoryTaxID)
                BindTaxpercentage = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

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
        Public Overrides Function FunFetch() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_fetchpurchase")

                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@PurchaseId", DbType.Double, DblPubPurchaseID)
                ' DbPubDataBase.AddInParameter(ObjPriDbCommand, "@Purchasedate", DbType.Date, dtPurchasedate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@FromDate", DbType.Date, dtFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ToDate", DbType.Date, dtToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@TPNo", SqlDbType.VarChar, strPriTPno)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@INVoiceNo", SqlDbType.VarChar, StrPriInvoiceNo)
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
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_Savepurchase")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PurchaseId", DbType.Double, DblPubPurchaseID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@SupplierId", DbType.Double, DblPubSupplierID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@TPno", SqlDbType.VarChar, strPriTPno)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@GRNForCode", SqlDbType.VarChar, StrPriGRNForCode)           'Added By Mohammed on 29-March-2019
                DbPubDataBase.AddInParameter(ObjPriCommand, "@InvoiceNo", SqlDbType.VarChar, StrPriInvoiceNo)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Purchasedate", DbType.Date, dtPurchasedate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@OtherchargeType", SqlDbType.VarChar, StrPriOtherchargeType)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Othercharge", DbType.Double, dblPubOthercharge)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Discountper", DbType.Double, DblPubDiscountper)
                ' DbPubDataBase.AddInParameter(ObjPriCommand, "@Discount", DbType.Double, DblPubDiscount)                        'Commented By Mohammed on 29-March-2019        
                DbPubDataBase.AddInParameter(ObjPriCommand, "@ForLicenseId", DbType.Double, DblPubForLicenseId)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PurchaseXML", DbType.Xml, ArrPurchaseXML.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Username", SqlDbType.VarChar, StrPubOperator)
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

        Public Function FunSavePurchaseInterface() As Boolean
            FunSavePurchaseInterface = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SavePurchaseInterface")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@xmlpurchase", DbType.Xml, ArrPurchaseXML.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Username", SqlDbType.VarChar, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunSavePurchaseInterface = Trim(ObjPriCommand.Parameters("@Outbit").Value)
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

        Public Function FunFecthBottalWiseConsumption() As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("spr_FetchBottleWiseConsumption")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@BrandOpeningID", DbType.Double, dblPubBrandOpeningId)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@mltype", SqlDbType.VarChar, StrPriMlType)

                FunFecthBottalWiseConsumption = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

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

        Public Function FunValidatePurchaseSave() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_ValidatePurchaseSave")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@PurchaseId", DbType.Double, DblPubPurchaseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@PurchaseXML", DbType.Xml, ArrPurchaseXML.InnerXml)
                FunValidatePurchaseSave = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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

#Region "UserLicenseMasterSecurity"

    Public Class ClsUserLicense
        Inherits ClsCommon

#Region "Variable"
        Private StrArrParameterId As XmlDocument
#End Region

#Region "Property"

        Public Property ArrUserParameterId() As XmlDocument
            Get
                Return StrArrParameterId
            End Get
            Set(ByVal value As XmlDocument)
                StrArrParameterId = value
            End Set
        End Property
#End Region

        Public Overrides Function FunDelete() As Boolean

        End Function

        Public Overrides Function FunFetch() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchUserLicenseforchecklist")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@UserID", DbType.Double, DblPubUserID)
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
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveUserLicense")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@UserID", DbType.Double, DblPubUserID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@XmlDoc", DbType.Xml, StrArrParameterId.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Username", SqlDbType.VarChar, StrPubOperator)
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

#Region "LicenseMaster"

    Public Class ClsLicenseMst
        Inherits ClsCommon
#Region "Variable"
        Private StrPriLicenseDesc, StrPriLicenseNo, StrPriAdd1, StrPriAdd2, StrPriCity, StrPriPinCode, StrPriTelephone, StrPriEmail, StrPriBst, StrPriCst, StrPriLicenseCode, StrPriOutLet As String
        Private blPriStore, blISActive, BlPriIsRack As Boolean
        Private StrPriArrParaMeter, StrPriImportLicense, StrPriImportClientDetails As XmlDocument
        Private DtFreezDate As DateTime
        Private DblPriForFL3ID As Double
#End Region
#Region "Property"

        Public Property ForFL3ID As Double
            Get
                Return DblPriForFL3ID
            End Get
            Set(ByVal value As Double)
                DblPriForFL3ID = value
            End Set
        End Property

        Public Property IsRack As Boolean
            Get
                Return BlPriIsRack
            End Get
            Set(ByVal value As Boolean)
                BlPriIsRack = value
            End Set
        End Property


        Public Property ISActive As Boolean
            Get
                Return blISActive
            End Get
            Set(ByVal value As Boolean)
                blISActive = value
            End Set
        End Property

        Public Property FreezDate() As DateTime
            Get
                Return DtFreezDate
            End Get
            Set(ByVal value As DateTime)
                DtFreezDate = value
            End Set
        End Property

        Public Property ImportClientDetails() As XmlDocument
            Get
                Return StrPriImportClientDetails
            End Get
            Set(ByVal value As XmlDocument)
                StrPriImportClientDetails = value
            End Set
        End Property


        Public Property ArrParaMeter() As XmlDocument
            Get
                Return StrPriArrParaMeter
            End Get
            Set(ByVal value As XmlDocument)
                StrPriArrParaMeter = value
            End Set
        End Property

        Public Property ImportLicense() As XmlDocument
            Get
                Return StrPriImportLicense
            End Get
            Set(ByVal value As XmlDocument)
                StrPriImportLicense = value
            End Set
        End Property

        Public Property LicenseDesc() As String
            Get
                Return StrPriLicenseDesc
            End Get
            Set(ByVal value As String)
                StrPriLicenseDesc = value
            End Set
        End Property

        Public Property LicenseNo() As String
            Get
                Return StrPriLicenseNo
            End Get
            Set(ByVal value As String)
                StrPriLicenseNo = value
            End Set
        End Property
        Public Property Add1() As String
            Get
                Return StrPriAdd1
            End Get
            Set(ByVal value As String)
                StrPriAdd1 = value
            End Set
        End Property
        Public Property Add2() As String
            Get
                Return StrPriAdd2
            End Get
            Set(ByVal value As String)
                StrPriAdd2 = value
            End Set
        End Property
        Public Property City() As String
            Get
                Return StrPriCity
            End Get
            Set(ByVal value As String)
                StrPriCity = value
            End Set
        End Property
        Public Property PinCode() As String
            Get
                Return StrPriPinCode
            End Get
            Set(ByVal value As String)
                StrPriPinCode = value
            End Set
        End Property
        Public Property Telephone() As String
            Get
                Return StrPriTelephone
            End Get
            Set(ByVal value As String)
                StrPriTelephone = value
            End Set
        End Property
        Public Property Email() As String
            Get
                Return StrPriEmail
            End Get
            Set(ByVal value As String)
                StrPriEmail = value
            End Set
        End Property

        Public Property Bst() As String
            Get
                Return StrPriBst
            End Get
            Set(ByVal value As String)
                StrPriBst = value
            End Set
        End Property
        Public Property Cst() As String
            Get
                Return StrPriCst
            End Get
            Set(ByVal value As String)
                StrPriCst = value
            End Set
        End Property

        Public Property Store() As Boolean
            Get
                Return blPriStore
            End Get
            Set(ByVal value As Boolean)
                blPriStore = value
            End Set
        End Property


        Public Property LicenseCode() As String
            Get
                Return StrPriLicenseCode
            End Get
            Set(ByVal value As String)
                StrPriLicenseCode = value
            End Set
        End Property

        Public Property OutLet() As String
            Get
                Return StrPriOutLet
            End Get
            Set(ByVal value As String)
                StrPriOutLet = value
            End Set
        End Property




#End Region

        Public Overrides Function FunDelete() As Boolean

        End Function

        Public Overrides Function FunFetch() As System.Data.DataTable

        End Function

        Public Overrides Function FunSave() As Boolean
            FunSave = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveLicenseMaster")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseDesc", SqlDbType.VarChar, StrPriLicenseDesc)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseNo", SqlDbType.VarChar, StrPriLicenseNo)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Add1", SqlDbType.VarChar, StrPriAdd1)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Add2", SqlDbType.VarChar, StrPriAdd2)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@City", SqlDbType.VarChar, StrPriCity)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PinCode", SqlDbType.VarChar, StrPriPinCode)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Telephone", SqlDbType.VarChar, StrPriTelephone)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Email", SqlDbType.VarChar, StrPriEmail)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Bst", SqlDbType.VarChar, StrPriBst)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Cst", SqlDbType.VarChar, StrPriCity)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Store", DbType.Boolean, blPriStore)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@IsRack", DbType.Boolean, BlPriIsRack)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@ForFL3", DbType.Double, DblPriForFL3ID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@UserName", SqlDbType.VarChar, StrPubOperator)
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
        Public Function FunSaveImportLicense() As Boolean
            FunSaveImportLicense = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveImportLicense")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@ImportLicenseXml", DbType.Xml, StrPriImportLicense.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@ImportClientDetailsXml", DbType.Xml, StrPriImportClientDetails.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@UserName", SqlDbType.VarChar, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunSaveImportLicense = Trim(ObjPriCommand.Parameters("@Outbit").Value)
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
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveLicenseCode")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseCodeID", DbType.Double, DblPubLicenseCodeID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@XmlDoc", DbType.Xml, StrPriArrParaMeter.InnerXml)


                'DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseCode", SqlDbType.VarChar, StrPriLicenseCode)
                'DbPubDataBase.AddInParameter(ObjPriCommand, "@OutLet", SqlDbType.VarChar, StrPriOutLet)

                DbPubDataBase.AddInParameter(ObjPriCommand, "@UserName", SqlDbType.VarChar, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
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

        Public Function FunFetchLicenseCodeMaster() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchUserLicenseCode")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                FunFetchLicenseCodeMaster = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

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
        Public Function FunSaveFreezDate() As Boolean
            FunSaveFreezDate = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveFreezDate")
                ObjPriCommand.CommandTimeout = 999999999
                DbPubDataBase.AddInParameter(ObjPriCommand, "@FreezID", DbType.Double, DblpUbFreezId)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@FzDate", DbType.DateTime, DtFreezDate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@IsActive", DbType.Double, blISActive)

                DbPubDataBase.AddInParameter(ObjPriCommand, "@UserName", SqlDbType.VarChar, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunSaveFreezDate = Trim(ObjPriCommand.Parameters("@Outbit").Value)
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
        Public Function FunDeleteFreeze() As Boolean
            FunDeleteFreeze = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("[Spr_DeleteFreeze]")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@FreezID", DbType.Double, DblpUbFreezId)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand)
                FunDeleteFreeze = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                ObjPriTrans.Commit()
            Catch ex As Exception
                FunDeleteFreeze = False
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
        Public Function FunFetchFreezDate() As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("spr_FetchFreezDate")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                FunFetchFreezDate = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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

#Region "BillMaster"

    Public Class ClsBillMaster
        Inherits ClsCommon

#Region "Variable"
        Dim StrPriBillStNo, StrPriBillEndNo, StrPriCurrentBillNo
        Dim ArrBillXml As XmlDocument
#End Region
#Region "Property"

        Public Property BillXml() As XmlDocument
            Get
                Return ArrBillXml
            End Get
            Set(ByVal value As XmlDocument)
                ArrBillXml = value
            End Set
        End Property

        Public Property BillStartNumber() As String
            Get
                Return StrPriBillStNo
            End Get
            Set(ByVal value As String)
                StrPriBillStNo = value
            End Set
        End Property
        Public Property BillEndNumber() As String
            Get
                Return StrPriBillEndNo
            End Get
            Set(ByVal value As String)
                StrPriBillEndNo = value
            End Set
        End Property
        Public Property CurrentBillNumber() As String
            Get
                Return StrPriCurrentBillNo
            End Get
            Set(ByVal value As String)
                StrPriCurrentBillNo = value
            End Set
        End Property
#End Region


        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_DeleteBillMaster")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@BillID", DbType.Double, DblPubUserID)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
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
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchBillMaster")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@BillID", DbType.Double, DblPubBillID)
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
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveBillMaster")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@BillID", DbType.Double, DblPubBillID)
                'DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                'DbPubDataBase.AddInParameter(ObjPriCommand, "@BillStNo", SqlDbType.VarChar, StrPriBillStNo)
                'DbPubDataBase.AddInParameter(ObjPriCommand, "@BillEndNo", SqlDbType.VarChar, StrPriBillEndNo)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@XmlDoc", SqlDbType.Xml, ArrBillXml.InnerXml)
                ' DbPubDataBase.AddInParameter(ObjPriCommand, "@BillEndNo", SqlDbType.VarChar, StrPriBillEndNo)

                DbPubDataBase.AddInParameter(ObjPriCommand, "@UserName", SqlDbType.VarChar, StrPubOperator)
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

#Region "Financial Year Class"
    Public Class ClsFinancialYear
        Inherits ClsCommon
#Region "Variables"
        Private DtPriFromdate, DtPriToDate As Date
        Private BlIsActive As Boolean
#End Region
#Region " Property"
        Public Property IsActive() As Boolean
            Get
                Return BlIsActive
            End Get
            Set(ByVal value As Boolean)
                BlIsActive = value
            End Set
        End Property
        Public Property Fromdate() As Date
            Get
                Return DtPriFromdate
            End Get
            Set(ByVal value As Date)
                DtPriFromdate = value
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
#End Region
        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_DeleteFinancialYear")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@FincyearId", DbType.Double, DblPubFinancialYearID)
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
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchFinancialYear")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@FincyearId", DbType.Double, DblPubFinancialYearID)
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
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveFinancialYear")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@FincyearId", DbType.Double, DblPubFinancialYearID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@FromDate", DbType.Date, DtPriFromdate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@ToDate", DbType.Date, DtPriToDate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Active", DbType.Boolean, BlIsActive)
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
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_DeleteDiscountmst")
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
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_fetchDiscountMst")
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
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveDiscountmst")
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

#Region "Void Class"
    Public Class ClsVoid
        Inherits ClsCommon
#Region "Variables"
        Private DtPriFromdate, DtPriToDate As Date
        Private IntPriType As Integer
        Private ArrVoidXML As String
#End Region
#Region " Property"
        Public Property VoidXml() As String
            Get
                Return ArrVoidXML
            End Get
            Set(ByVal value As String)
                ArrVoidXML = value
            End Set
        End Property

        Public Property Type() As Integer
            Get
                Return IntPriType
            End Get
            Set(ByVal value As Integer)
                IntPriType = value
            End Set
        End Property
        Public Property Fromdate() As Date
            Get
                Return DtPriFromdate
            End Get
            Set(ByVal value As Date)
                DtPriFromdate = value
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
#End Region
        Public Overrides Function FunDelete() As Boolean
           
        End Function

        Public Overrides Function FunFetch() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchVoid")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@VoidID", DbType.Double, DblPubVoidID)
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
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveVoid")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@VoidID", DbType.Double, DblPubVoidID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@FromDate", DbType.Date, DtPriFromdate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@ToDate", DbType.Date, DtPriToDate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@VoidXMl", DbType.Xml, ArrVoidXML)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Type", DbType.Int32, IntPriType)
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

        Public Function FunMRSave() As Boolean
            FunMRSave = False
            Try

                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveMRVoid")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@VoidID", DbType.Double, DblPubVoidID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@FromDate", DbType.Date, DtPriFromdate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@ToDate", DbType.Date, DtPriToDate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@VoidXMl", DbType.Xml, ArrVoidXML)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Type", DbType.Int32, IntPriType)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@username", DbType.String, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", DbType.String, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunMRSave = Trim(ObjPriCommand.Parameters("@Outbit").Value)
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

#Region "One Day Permit Number"

    Public Class ClsOneDayPermitNumber
        Inherits ClsCommon
#Region "Variables"
        Dim IntPriFrom, IntPriTo As Integer
        Dim BlPriIsMaster As Boolean
#End Region
#Region "Properties"
        Public Property IsMaster() As String
            Get
                Return BlPriIsMaster
            End Get
            Set(ByVal value As String)
                BlPriIsMaster = value
            End Set
        End Property

        Public Property _From() As String
            Get
                Return IntPriFrom
            End Get
            Set(ByVal value As String)
                IntPriFrom = value
            End Set
        End Property

        Public Property _To() As String
            Get
                Return IntPriTo
            End Get
            Set(ByVal value As String)
                IntPriTo = value
            End Set
        End Property
#End Region

        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("[Spr_DeleteOneDayPermitNumber]")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@OneDayPermitId", DbType.Double, DblPubOneDayPermitId)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
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
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchOneDayPermitMst")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@IsMaster", DbType.Boolean, BlPriIsMaster)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
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
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("[Spr_SaveOneDayPermitNumber]")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@OneDayPermitId", DbType.Double, DblPubOneDayPermitId)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@licenseid", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@From", DbType.Int32, IntPriFrom)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@To", DbType.Int32, IntPriTo)

                DbPubDataBase.AddInParameter(ObjPriCommand, "@UserName", SqlDbType.VarChar, StrPubOperator)
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

#Region "Menu Engineering"

    Public Class ClsMenuEngineering
        Inherits ClsCommon

#Region "Variable"
        Dim IntChallenge, IntStar, IntDog, IntHorse, IntDefaultMethod As Integer
        Dim StrMethodName As String
#End Region
#Region "Property"
        Public Property MethodName() As String
            Get
                Return StrMethodName
            End Get
            Set(ByVal value As String)
                StrMethodName = value
            End Set
        End Property

        Public Property DefaultMethod() As Integer
            Get
                Return IntDefaultMethod
            End Get
            Set(ByVal value As Integer)
                IntDefaultMethod = value
            End Set
        End Property

        Public Property Challenge() As Integer
            Get
                Return IntChallenge
            End Get
            Set(ByVal value As Integer)
                IntChallenge = value
            End Set
        End Property

        Public Property Star() As Integer
            Get
                Return IntStar
            End Get
            Set(ByVal value As Integer)
                IntStar = value
            End Set
        End Property

        Public Property Dog() As Integer
            Get
                Return IntDog
            End Get
            Set(ByVal value As Integer)
                IntDog = value
            End Set
        End Property

        Public Property Horse() As Integer
            Get
                Return IntHorse
            End Get
            Set(ByVal value As Integer)
                IntHorse = value
            End Set
        End Property
#End Region


        Public Overrides Function FunDelete() As Boolean

        End Function

        Public Overrides Function FunFetch() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchMenuEngineeringMaster")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@MethodID", DbType.Double, DblPubMethodID)
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
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("spr_SaveMenuEngineering")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@MethodID", DbType.Double, DblPubMethodID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@MethodName", DbType.String, StrMethodName)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Challenge", DbType.Double, IntChallenge)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Star", DbType.Double, IntStar)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Dog", DbType.Double, IntDog)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Horse", DbType.Double, IntHorse)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@DefaultMethod", DbType.Double, IntDefaultMethod)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@UserName", SqlDbType.VarChar, StrPubOperator)
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

#Region "Interface File SetUp"
    Public Class ClsInterfaceFileSetUp
        Inherits ClsCommon


#Region "Variable"
        Dim StrPriFileType, StrPriInterfaceFileDesc, StrPriSymbol, StrPriFilePrefix, StrPriFileExtension, StrPriDate,
            StrPriPermitHolderExpDt, StrPriPermitHolderExpDtDesc, StrPriFilePath, StrPriBackUpFilePath, intPriPermitHolderName, StrPriPositionPriceSequence As String

        Dim StrTRNPriFileType, StrTRNPriInterfaceFileDesc, StrTRNPriSymbol, StrTRNPriFilePrefix, StrTRNPriFileExtension, StrTRNPriDate As String
        Dim intPriLicenseCodeDef, intPriLicenseCodeLength, intPriLicenseCodePosition, intPurPosiLocationNo,
            intPriPositionBillNo, intPriPositionCode, intPriPositionQty, intPriPositionRate, intPriPermitHolderType, intPriPermitHolderNo As Integer

        Dim IntTRNPosiFromLic, IntTRNPosiToLic, intTRNPriLicenseCodeDef, intTRNPriLicenseCodeLength, intTRNPriLicenseCodePosition, intTRNPosiItemCode, intTRNPosiQuantity, intTRNPurPosiRate, intTRNFreeQty, intTRNPosiTPnumber As Integer

        Dim intPurPosiSupplierCode, intPurPosiTPnumber, intPurPosiRRnumber, intPurPosiItemCode, intPurPosiQuantity, intPurPosiRate, intPurFreeQty As Integer
        Private Outbitno As Integer
        Private StrPriPURFilePath, StrPriPURBackUpFilePath, StrPriPURFilePrefix, StrPriPURFileExtension As String
        Private StrPriTRNFilePath, StrPriTRNBackUpFilePath, StrPriTRNFilePrefix, StrPriTRNFileExtension As String

#End Region
#Region "Property"

       
        Public Property PURFilePath() As String
            Get
                Return StrPriPURFilePath
            End Get
            Set(ByVal value As String)
                StrPriPURFilePath = value
            End Set
        End Property

        Public Property PURBackUpFilePath() As String
            Get
                Return StrPriPURBackUpFilePath
            End Get
            Set(ByVal value As String)
                StrPriPURBackUpFilePath = value
            End Set
        End Property

        Public Property PURFilePrefix() As String
            Get
                Return StrPriPURFilePrefix
            End Get
            Set(ByVal value As String)
                StrPriPURFilePrefix = value
            End Set
        End Property

        Public Property PURFileExtension() As String
            Get
                Return StrPriPURFileExtension
            End Get
            Set(ByVal value As String)
                StrPriPURFileExtension = value
            End Set
        End Property

        Public Property TRNFilePath() As String
            Get
                Return StrPriTRNFilePath
            End Get
            Set(ByVal value As String)
                StrPriTRNFilePath = value
            End Set
        End Property

        Public Property TRNBackUpFilePath() As String
            Get
                Return StrPriTRNBackUpFilePath
            End Get
            Set(ByVal value As String)
                StrPriTRNBackUpFilePath = value
            End Set
        End Property

        Public Property TRNFilePrefix() As String
            Get
                Return StrPriTRNFilePrefix
            End Get
            Set(ByVal value As String)
                StrPriTRNFilePrefix = value
            End Set
        End Property

        Public Property TRNFileExtension() As String
            Get
                Return StrPriTRNFileExtension
            End Get
            Set(ByVal value As String)
                StrPriTRNFileExtension = value
            End Set
        End Property
        Public Property Outbit() As Integer
            Get
                Return Outbitno
            End Get
            Set(ByVal value As Integer)
                Outbitno = value
            End Set
        End Property


        Public Property FileType() As String
            Get
                Return StrPriFileType
            End Get
            Set(ByVal value As String)
                StrPriFileType = value
            End Set
        End Property
        Public Property InterfaceFileDesc() As String
            Get
                Return StrPriInterfaceFileDesc
            End Get
            Set(ByVal value As String)
                StrPriInterfaceFileDesc = value
            End Set
        End Property
        Public Property Symbol() As String
            Get
                Return StrPriSymbol
            End Get
            Set(ByVal value As String)
                StrPriSymbol = value
            End Set
        End Property
        Public Property FilePrefix() As String
            Get
                Return StrPriFilePrefix
            End Get
            Set(ByVal value As String)
                StrPriFilePrefix = value
            End Set
        End Property
        Public Property FileExtension() As String
            Get
                Return StrPriFileExtension
            End Get
            Set(ByVal value As String)
                StrPriFileExtension = value
            End Set
        End Property
        Public Property Date1() As String
            Get
                Return StrPriDate
            End Get
            Set(ByVal value As String)
                StrPriDate = value
            End Set
        End Property
        Public Property PermitHolderExpDt() As String
            Get
                Return StrPriPermitHolderExpDt
            End Get
            Set(ByVal value As String)
                StrPriPermitHolderExpDt = value
            End Set
        End Property
        Public Property PermitHolderExpDtDesc() As String
            Get
                Return StrPriPermitHolderExpDtDesc
            End Get
            Set(ByVal value As String)
                StrPriPermitHolderExpDtDesc = value
            End Set
        End Property
        Public Property FilePath() As String
            Get
                Return StrPriFilePath
            End Get
            Set(ByVal value As String)
                StrPriFilePath = value
            End Set
        End Property
        Public Property BackUpFilePath() As String
            Get
                Return StrPriBackUpFilePath
            End Get
            Set(ByVal value As String)
                StrPriBackUpFilePath = value
            End Set
        End Property
        Public Property LicenseCodeDef() As Integer
            Get
                Return intPriLicenseCodeDef
            End Get
            Set(ByVal value As Integer)
                intPriLicenseCodeDef = value
            End Set
        End Property
        Public Property LicenseCodeLength() As Integer
            Get
                Return intPriLicenseCodeLength
            End Get
            Set(ByVal value As Integer)
                intPriLicenseCodeLength = value
            End Set
        End Property
        Public Property LicenseCodePosition() As Integer
            Get
                Return intPriLicenseCodePosition
            End Get
            Set(ByVal value As Integer)
                intPriLicenseCodePosition = value
            End Set
        End Property
        Public Property PositionBillNo() As Integer
            Get
                Return intPriPositionBillNo
            End Get
            Set(ByVal value As Integer)
                intPriPositionBillNo = value
            End Set
        End Property
        Public Property PositionCode() As Integer
            Get
                Return intPriPositionCode
            End Get
            Set(ByVal value As Integer)
                intPriPositionCode = value
            End Set
        End Property
        Public Property PositionQty() As Integer
            Get
                Return intPriPositionQty
            End Get
            Set(ByVal value As Integer)
                intPriPositionQty = value
            End Set
        End Property
        Public Property PositionRate() As Integer
            Get
                Return intPriPositionRate
            End Get
            Set(ByVal value As Integer)
                intPriPositionRate = value
            End Set
        End Property
        Public Property PositionPriceSequence() As String
            Get
                Return StrPriPositionPriceSequence
            End Get
            Set(ByVal value As String)
                StrPriPositionPriceSequence = value
            End Set
        End Property
        Public Property PermitHolderType() As Integer
            Get
                Return intPriPermitHolderType
            End Get
            Set(ByVal value As Integer)
                intPriPermitHolderType = value
            End Set
        End Property
        Public Property PermitHolderNo() As Integer
            Get
                Return intPriPermitHolderNo
            End Get
            Set(ByVal value As Integer)
                intPriPermitHolderNo = value
            End Set
        End Property
        Public Property PermitHolderName() As String
            Get
                Return intPriPermitHolderName
            End Get
            Set(ByVal value As String)
                intPriPermitHolderName = value
            End Set

        End Property

        Public Property PositionLocationNumber() As Integer
            Get
                Return intPurPosiLocationNo
            End Get
            Set(ByVal value As Integer)
                intPurPosiLocationNo = value
            End Set
        End Property


        Public Property PositionSupplierCode() As Integer
            Get
                Return intPurPosiSupplierCode
            End Get
            Set(ByVal value As Integer)
                intPurPosiSupplierCode = value
            End Set
        End Property

        Public Property PositionTPnumber() As Integer
            Get
                Return intPurPosiTPnumber
            End Get
            Set(ByVal value As Integer)
                intPurPosiTPnumber = value
            End Set
        End Property

        Public Property PositionRRnumber As Integer
            Get
                Return intPurPosiRRnumber
            End Get
            Set(ByVal value As Integer)
                intPurPosiRRnumber = value
            End Set
        End Property

        Public Property PositionPurItemCode As Integer
            Get
                Return intPurPosiItemCode
            End Get
            Set(ByVal value As Integer)
                intPurPosiItemCode = value
            End Set
        End Property

        Public Property PositionPurQuatity As Integer
            Get
                Return intPurPosiQuantity
            End Get
            Set(ByVal value As Integer)
                intPurPosiQuantity = value
            End Set
        End Property

        Public Property PositionPurRate As Integer
            Get
                Return intPurPosiRate
            End Get
            Set(ByVal value As Integer)
                intPurPosiRate = value
            End Set
        End Property

        Public Property PositionPurFreeQty As Integer
            Get
                Return intPurFreeQty
            End Get
            Set(ByVal value As Integer)
                intPurFreeQty = value
            End Set
        End Property

#End Region

        Property PositionToLic As String

        Property PositionFromLic As String

        Property PositionTRNQuatity As String

        Property PositionTRNItemCode As String

        Property PositionTRNFreeQty As String

        Property PositionTRNRate As String

        Public Overrides Function FunDelete() As Boolean

        End Function

        Public Overrides Function FunFetch() As System.Data.DataTable
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchInterfaceFileSetupDetails")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseID", DbType.Int32, LicenseID)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                FunFetch = DbPubDataBase.ExecuteDataSet(ObjPriCommand).Tables(0)
                Outbit = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
            Catch ex As Exception
                Throw ex

            Finally
                If IsNothing(DbPubDataBase) = False Then
                    DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriCommand) = False Then
                    ObjPriCommand = Nothing
                End If

            End Try
        End Function


        Public Function FunFetchInterfaceFileTransferSetUp() As System.Data.DataTable
            Try
                'ObjPriDbCommand.CommandTimeout = 0
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchInterfaceFileTransferSetUp")

                FunFetchInterfaceFileTransferSetUp = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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


        Public Function FunFetchInterfaceFilePurchaseSetUp() As System.Data.DataTable
            Try
                ' ObjPriDbCommand.CommandTimeout = IntPubTimeOut
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchInterfaceFilePurchaseSetUp")
                FunFetchInterfaceFilePurchaseSetUp = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveInterfaceFileSetUp")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@InterfaceFileID", DbType.Double, DblPubInterfaceFileSetUpID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@FileType", SqlDbType.VarChar, StrPriFileType)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@InterfaceFileDesc", SqlDbType.VarChar, StrPriInterfaceFileDesc)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Symbol", SqlDbType.VarChar, StrPriSymbol)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@FilePrefix", SqlDbType.VarChar, StrPriFilePrefix)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@FileExtension", SqlDbType.VarChar, StrPriFileExtension)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Date", SqlDbType.VarChar, StrPriDate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PermitHolderExpDt", SqlDbType.VarChar, StrPriPermitHolderExpDt)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PermitHolderExpDtDesc", SqlDbType.VarChar, StrPriPermitHolderExpDtDesc)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@FilePath", SqlDbType.VarChar, StrPriFilePath)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@BackUpFilePath", SqlDbType.VarChar, StrPriBackUpFilePath)

                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseCodeDef", DbType.Int32, intPriLicenseCodeDef)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseCodeLength", DbType.Int32, intPriLicenseCodeLength)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseCodePosition", DbType.Int32, intPriLicenseCodePosition)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PositionBillNo", DbType.Int32, intPriPositionBillNo)

                DbPubDataBase.AddInParameter(ObjPriCommand, "@PositionCode", DbType.Int32, intPriPositionCode)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PositionQty", DbType.Int32, intPriPositionQty)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PositionRate", DbType.Int32, intPriPositionRate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PositionPriceSequence", SqlDbType.VarChar, StrPriPositionPriceSequence)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PermitHolderType", DbType.Int32, intPriPermitHolderType)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PermitHolderNo", DbType.Int32, intPriPermitHolderNo)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PermitHolderName", SqlDbType.VarChar, intPriPermitHolderName)

                DbPubDataBase.AddInParameter(ObjPriCommand, "@UserName", SqlDbType.VarChar, StrPubOperator)
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

        ''----------------------------Created By abhijeet ingavale on 15 nov 2016-------------------------
        Public Function FunSaveInterfaceFilePurchaseSetup() As Boolean
            FunSaveInterfaceFilePurchaseSetup = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveInterfaceFilePurchaseSetup")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@InterfaceFileID", DbType.Double, DblPubInterfaceFileSetUpID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@FileType", SqlDbType.VarChar, StrPriFileType)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@FilePath", DbType.String, StrPriPURFilePath)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@BackupFilePath", DbType.String, StrPriPURBackUpFilePath)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@FilePrefix", DbType.String, StrPriPURFilePrefix)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@FileExtension", DbType.String, StrPriPURFileExtension)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@InterfaceFileDesc", SqlDbType.VarChar, StrPriInterfaceFileDesc)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Symbol", SqlDbType.VarChar, StrPriSymbol)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Date", SqlDbType.VarChar, StrPriDate)

                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseCodeDef", DbType.Int32, intPriLicenseCodeDef)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseCodeLength", DbType.Int32, intPriLicenseCodeLength)           'Added By RV ON 29-March-2019
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseCodePosition", DbType.Int32, intPriLicenseCodePosition)           'Added By RV ON 29-March-2019
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PositionLocationNo", DbType.Int32, intPurPosiLocationNo)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PositionSupplierCode", DbType.Int32, intPurPosiSupplierCode)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PositionTPnumber", DbType.Int32, intPurPosiTPnumber)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PostionRRnumber", DbType.Int32, intPurPosiRRnumber)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PostionItemCode", DbType.Int32, intPurPosiItemCode)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PositionQuantity", DbType.Int32, intPurPosiQuantity)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PositionRate", DbType.Int32, intPurPosiRate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PositionFreeQty", DbType.Int32, intPurFreeQty)

                DbPubDataBase.AddInParameter(ObjPriCommand, "@username", DbType.String, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", DbType.Boolean, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", DbType.String, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunSaveInterfaceFilePurchaseSetup = Trim(ObjPriCommand.Parameters("@Outbit").Value)
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

        'SAMVEDNA
        Public Function FunSaveInterfaceFileTransferSetup() As Boolean
            FunSaveInterfaceFileTransferSetup = False
            Try
                'ObjPriConnection = DbPubDataBase.CreateConnection
                'ObjPriConnection.Open()
                'ObjPriTrans = ObjPriConnection.BeginTransaction
                'ObjPriCommand = DbPubDataBase.GetStoredProcCommand("[Spr_SaveInterfaceFileTransferSetUp]")
                'DbPubDataBase.AddInParameter(ObjPriCommand, "@FilePath", DbType.String, StrPriTRNFilePath)
                'DbPubDataBase.AddInParameter(ObjPriCommand, "@BackupFilePath", DbType.String, StrPriTRNBackUpFilePath)
                'DbPubDataBase.AddInParameter(ObjPriCommand, "@FilePrefix", DbType.String, StrPriTRNFilePrefix)
                'DbPubDataBase.AddInParameter(ObjPriCommand, "@FileExtension", DbType.String, StrPriTRNFileExtension)
                'DbPubDataBase.AddInParameter(ObjPriCommand, "@username", DbType.String, StrPubOperator)
                'DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", DbType.Boolean, 1)
                'DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", DbType.String, 100)
                'DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                'FunSaveInterfaceFileTransferSetup = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                'StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                'ObjPriTrans.Commit()


                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveInterfaceFileTransferSetUp")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@InterfaceFileID", DbType.Double, DblPubInterfaceFileSetUpID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@FileType", SqlDbType.VarChar, FileType)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@FilePath", DbType.String, TRNFilePath)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@BackupFilePath", DbType.String, StrPriTRNBackUpFilePath)

                DbPubDataBase.AddInParameter(ObjPriCommand, "@FilePrefix", DbType.String, TRNFilePrefix)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@FileExtension", DbType.String, TRNFileExtension)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@InterfaceFileDesc", SqlDbType.VarChar, StrTRNPriInterfaceFileDesc)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Symbol", SqlDbType.VarChar, Symbol)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Date", SqlDbType.VarChar, StrTRNPriDate)

                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseCodeDef", DbType.Int32, intTRNPriLicenseCodeDef)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseCodeLength", DbType.Int32, LicenseCodeLength)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseCodePosition", DbType.Int32, LicenseCodePosition)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PositionFromLic", DbType.Int32, PositionFromLic)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PositionToLic", DbType.Int32, PositionToLic)

                DbPubDataBase.AddInParameter(ObjPriCommand, "@PositionTPnumber", DbType.Int32, PositionTPnumber)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PostionItemCode", DbType.Int32, PositionTRNItemCode)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PositionQuantity", DbType.Int32, PositionTRNQuatity)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PositionRate", DbType.Int32, PositionTRNRate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PositionFreeQty", DbType.Int32, PositionTRNFreeQty)

                DbPubDataBase.AddInParameter(ObjPriCommand, "@username", DbType.String, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", DbType.Boolean, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", DbType.String, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunSaveInterfaceFileTransferSetup = Trim(ObjPriCommand.Parameters("@Outbit").Value)
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

#Region "Transfer Master"
    Public Class ClsTransfer
        Inherits ClsCommon


#Region "Variable"
        Dim dblPubForLicenseID, dblPubToLicenseID As Double
        Dim StrPriTPNo, StrPriInviceNo, StrPriFLIV, StrPriFLIVAddress, StrAgainst, StrPriTrDetailsTPNo As String
        Dim dtTransferDate, dtFromDate, dtToDate As Date
        Dim ArrTransferDetailsXML As XmlDocument
        Dim XmlPribrand, XmlPriCocktail As XmlDocument

        Public StrPriBrand, StrPriCategory, StrPriSize, StrPriCocktail As String

#End Region

#Region "Property"

        Public Property ToLicenseID As Double
            Get
                Return dblPubToLicenseID
            End Get
            Set(ByVal value As Double)
                dblPubToLicenseID = value
            End Set
        End Property

        Public Property Brand As String
            Get
                Return StrPriBrand
            End Get
            Set(ByVal value As String)
                StrPriBrand = value
            End Set
        End Property

        Public Property Category As String
            Get
                Return StrPriCategory
            End Get
            Set(ByVal value As String)
                StrPriCategory = value
            End Set
        End Property
        Public Property Size As String
            Get
                Return StrPriSize
            End Get
            Set(ByVal value As String)
                StrPriSize = value
            End Set
        End Property
        Public Property Cocktail As String
            Get
                Return StrPriCocktail
            End Get
            Set(ByVal value As String)
                StrPriCocktail = value
            End Set
        End Property




        Public Property FromDate() As DateTime
            Get
                Return dtFromDate
            End Get
            Set(ByVal value As DateTime)
                dtFromDate = value
            End Set
        End Property

        Public Property ToDate() As DateTime
            Get
                Return dtToDate
            End Get
            Set(ByVal value As DateTime)
                dtToDate = value
            End Set
        End Property


        Public Property XmlBrand() As XmlDocument
            Get
                Return XmlPribrand
            End Get
            Set(ByVal value As XmlDocument)
                XmlPribrand = value
            End Set
        End Property

        Public Property XmlCocktail() As XmlDocument
            Get
                Return XmlPriCocktail
            End Get
            Set(ByVal value As XmlDocument)
                XmlPriCocktail = value
            End Set
        End Property

        Public Property ForLicenseID() As Double
            Get
                Return dblPubForLicenseID
            End Get
            Set(ByVal value As Double)
                dblPubForLicenseID = value
            End Set
        End Property



        Public Property TransferDetailsXML() As XmlDocument
            Get
                Return ArrTransferDetailsXML
            End Get
            Set(ByVal value As XmlDocument)
                ArrTransferDetailsXML = value
            End Set
        End Property

        Public Property Against() As String
            Get
                Return StrAgainst
            End Get
            Set(ByVal value As String)
                StrAgainst = value
            End Set
        End Property
        Public Property TrDetailsTPNo() As String
            Get
                Return StrPriTrDetailsTPNo
            End Get
            Set(ByVal value As String)
                StrPriTrDetailsTPNo = value
            End Set
        End Property

        Public Property TPNo() As String
            Get
                Return StrPriTPNo
            End Get
            Set(ByVal value As String)
                StrPriTPNo = value
            End Set
        End Property
        Public Property InviceNo() As String
            Get
                Return StrPriInviceNo
            End Get
            Set(ByVal value As String)
                StrPriInviceNo = value
            End Set
        End Property
        Public Property FLIV() As String
            Get
                Return StrPriFLIV
            End Get
            Set(ByVal value As String)
                StrPriFLIV = value
            End Set
        End Property

        Public Property FLIVAddress() As String
            Get
                Return StrPriFLIVAddress
            End Get
            Set(ByVal value As String)
                StrPriFLIVAddress = value
            End Set
        End Property
        Public Property TransferDate() As Date
            Get
                Return dtTransferDate
            End Get
            Set(ByVal value As Date)
                dtTransferDate = value
            End Set
        End Property



#End Region

        Public Sub New()
            FromDate = "#1/1/1900#"
            ToDate = "#1/1/1900#"
        End Sub

        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                'ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_DeleteTransfer")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@TransferHeadID", DbType.Double, DblPubTransferHeadID)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                'DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand)
                FunDelete = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                'ObjPriTrans.Commit()
            Catch ex As Exception
                FunDelete = False
                'ObjPriTrans.Rollback()
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
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchTransferHeadDetails")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@TransferHeadID", DbType.Double, DblPubTransferHeadID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@Tpno", SqlDbType.VarChar, StrPriTPNo)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@InvioceNo", SqlDbType.VarChar, StrPriInviceNo)
                'DbPubDataBase.AddInParameter(ObjPriDbCommand, "@TransferDate", DbType.Date, dtTransferDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@FromDate", DbType.Date, dtFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ToDate", DbType.Date, dtToDate)
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

        Public Function FunFetchFLR1A() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchflrIA")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@TransferHeadID", DbType.Double, DblPubTransferHeadID)

                FunFetchFLR1A = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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

        Public Function FunFetchFLR9() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_Fetchflr9A")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@TransferHeadID", DbType.Double, DblPubTransferHeadID)
                FunFetchFLR9 = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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

        Public Function FunFetchTransferHeadMaster() As DataSet
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchTransferHeadDetails")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@TransferHeadID", DbType.Double, DblPubTransferHeadID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@Tpno", SqlDbType.VarChar, StrPriTPNo)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@InvioceNo", SqlDbType.VarChar, StrPriInviceNo)
                'DbPubDataBase.AddInParameter(ObjPriDbCommand, "@TransferDate", DbType.Date, dtTransferDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@FromDate", DbType.Date, dtFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ToDate", DbType.Date, dtToDate)
                FunFetchTransferHeadMaster = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand)
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

        Public Function FunSaveTransferInterface() As Boolean
            FunSaveTransferInterface = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveTransferInterface")
                ObjPriCommand.CommandTimeout = 0
                DbPubDataBase.AddInParameter(ObjPriCommand, "@xmltransfer", DbType.Xml, ArrTransferDetailsXML.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Username", SqlDbType.VarChar, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunSaveTransferInterface = Trim(ObjPriCommand.Parameters("@Outbit").Value)
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
        Public Function FunSaveTransferPurchase() As Boolean
            FunSaveTransferPurchase = True
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction()
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveTransferPurchase")
                ObjPriCommand.CommandTimeout = 9999999
                DbPubDataBase.AddInParameter(ObjPriCommand, "@xmltransfer", DbType.Xml, ArrTransferDetailsXML.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Username", DbType.String, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunSaveTransferPurchase = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                ObjPriTrans.Commit()
            Catch ex As Exception

            End Try

        End Function

        Public Overrides Function FunSave() As Boolean
            FunSave = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveTransferMaster")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@TransferHeadID", DbType.Double, DblPubTransferHeadID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@TransferDate", DbType.Date, dtTransferDate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@TPNo", SqlDbType.VarChar, StrPriTPNo)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@InvoiceNo", SqlDbType.VarChar, StrPriInviceNo)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@ForLicenseID", DbType.Double, dblPubForLicenseID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@FLIV", SqlDbType.VarChar, StrPriFLIV)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@FLIVAddress", SqlDbType.VarChar, StrPriFLIVAddress)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@DeptID", DbType.Double, dblPubDeptID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@XmlDoc", SqlDbType.Xml, ArrTransferDetailsXML.InnerXml)

                DbPubDataBase.AddInParameter(ObjPriCommand, "@UserName", SqlDbType.VarChar, StrPubOperator)
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

        'Public Function FunSaveTransferDetailsMSt() As Boolean
        '    FunSaveTransferDetailsMSt = False
        '    Try
        '        ObjPriConnection = DbPubDataBase.CreateConnection
        '        ObjPriConnection.Open()
        '        ObjPriTrans = ObjPriConnection.BeginTransaction
        '        ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveTransferDetailsMaster")
        '        DbPubDataBase.AddInParameter(ObjPriCommand, "@TranferDetailID", DbType.Double, DblPubTransferDetailID)
        '        DbPubDataBase.AddInParameter(ObjPriCommand, "@TransferHeadID", DbType.Double, DblPubTransferHeadID)
        '        ' DbPubDataBase.AddInParameter(ObjPriCommand, "@BrandOpeningID", DbType.Double, dblPubBrandOpeningId)
        '        DbPubDataBase.AddInParameter(ObjPriCommand, "@Against", SqlDbType.VarChar, StrAgainst)
        '        DbPubDataBase.AddInParameter(ObjPriCommand, "@TrDetailTPNo", DbType.Double, StrPriTrDetailsTPNo)
        '        DbPubDataBase.AddInParameter(ObjPriCommand, "@XmlDoc", SqlDbType.Xml, ArrTransferDetailsXML.InnerXml)

        '        DbPubDataBase.AddInParameter(ObjPriCommand, "@UserName", SqlDbType.VarChar, StrPubOperator)
        '        DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
        '        DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
        '        DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
        '        FunSaveTransferDetailsMSt = Trim(ObjPriCommand.Parameters("@Outbit").Value)
        '        StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
        '        ObjPriTrans.Commit()
        '    Catch ex As Exception
        '        Throw ex
        '        ObjPriTrans.Rollback()
        '    Finally
        '        If IsNothing(DbPubDataBase) = False Then
        '            DbPubDataBase = Nothing
        '        End If

        '        If IsNothing(ObjPriCommand) = False Then
        '            ObjPriDbCommand = Nothing
        '        End If
        '        If IsNothing(ObjPriConnection) = False Then
        '            ObjPriConnection = Nothing
        '        End If

        '        If IsNothing(ObjPriTrans) = False Then
        '            ObjPriTrans = Nothing

        '        End If
        '    End Try
        'End Function

        Public Function ValidateBrandTransfer() As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_ValidateBrandTransfer")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@brandid", DbType.Double, DblPubBrandID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@categorysizelinkupid", DbType.Double, DblPubCategorySizeLinkID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@forLicenseid", DbType.Double, dblPubForLicenseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@Licenseid", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddOutParameter(ObjPriDbCommand, "@Outbit", DbType.Boolean, 1)
                DbPubDataBase.ExecuteNonQuery(ObjPriDbCommand)
                '  ValidateBrandTransfer = Trim(ObjPriDbCommand.Parameters("@Outbit").Value)
                ValidateBrandTransfer = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

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

        Public Function FunValidateNegativeStockForTransfer(ByVal LocDt As DateTime) As DataTable
            FunValidateNegativeStockForTransfer = Nothing
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_ValidateNegativeStockForTransfer")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@XmlDocBrand", SqlDbType.Xml, XmlPribrand.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@date", DbType.Date, LocDt)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@TransferHeadid", DbType.Double, DblPubTransferHeadID)
                FunValidateNegativeStockForTransfer = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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

        Public Function FunValidateNegativeStockForSale(ByVal LocDt As DateTime) As DataTable
            FunValidateNegativeStockForSale = Nothing
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_ValidateNegativeStockForSale")
                ObjPriDbCommand.CommandTimeout = 999999999
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@XmlDocBrand", SqlDbType.Xml, XmlPribrand.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@XmlDocCocktail", SqlDbType.Xml, XmlPriCocktail.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@date", DbType.Date, LocDt)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@saleheadid", DbType.Double, DblPubBillID)
                FunValidateNegativeStockForSale = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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

        Public Function FunFetchTransferReports() As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchTransferReports")

                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ToLicenseID", DbType.Double, dblPubToLicenseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@category", SqlDbType.VarChar, StrPriCategory)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@brand", SqlDbType.VarChar, StrPriBrand)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@size", SqlDbType.VarChar, StrPriSize)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@cocktail", SqlDbType.VarChar, StrPriCocktail)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@Tpno", SqlDbType.VarChar, StrPriTPNo)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@InvioceNo", SqlDbType.VarChar, StrPriInviceNo)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@FromDate", DbType.Date, dtFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ToDate", DbType.Date, dtToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@FLIVAddress", SqlDbType.VarChar, StrPriFLIVAddress)
                FunFetchTransferReports = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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

#Region "Sale"
    Public Class ClsSale
        Inherits ClsCommon

#Region "Variables"

        Private ArrBrandSale, ArrBrandCocktail, ArrBrandPermit As XmlDocument
        Private StrBillNo As String
        Private DtBillDate, DtPurchaseDate, dtFromDate, dtToDate As Date
        Private BoolPriAuto As Boolean

#End Region

#Region "Property"

        Public Property PurchaseDate() As DateTime
            Get
                Return DtPurchaseDate
            End Get
            Set(ByVal value As DateTime)
                DtPurchaseDate = value
            End Set
        End Property


        Public Property Auto() As Boolean
            Get
                Return BoolPriAuto
            End Get
            Set(ByVal value As Boolean)
                BoolPriAuto = value
            End Set
        End Property

        Public Property FromDate() As DateTime
            Get
                Return dtFromDate
            End Get
            Set(ByVal value As DateTime)
                dtFromDate = value
            End Set
        End Property

        Public Property ToDate() As DateTime
            Get
                Return dtToDate
            End Get
            Set(ByVal value As DateTime)
                dtToDate = value
            End Set
        End Property



        Public Property BillDate() As Date
            Get
                Return DtBillDate
            End Get
            Set(ByVal value As Date)
                DtBillDate = value
            End Set
        End Property

        Public Property BillNo() As String
            Get
                Return StrBillNo
            End Get
            Set(ByVal value As String)
                StrBillNo = value
            End Set
        End Property

        Public Property BrandSaleXML() As XmlDocument
            Get
                Return ArrBrandSale
            End Get
            Set(ByVal value As XmlDocument)
                ArrBrandSale = value
            End Set
        End Property

        Public Property BrandCocktailXML() As XmlDocument
            Get
                Return ArrBrandCocktail
            End Get
            Set(ByVal value As XmlDocument)
                ArrBrandCocktail = value
            End Set
        End Property

        Public Property BrandPermitXML() As XmlDocument
            Get
                Return ArrBrandPermit
            End Get
            Set(ByVal value As XmlDocument)
                ArrBrandPermit = value
            End Set
        End Property
#End Region

#Region "Constructor"
        Public Sub New()
            FromDate = "#1-1-1900#"
            ToDate = "#1/1/1900#"
        End Sub
#End Region



        'Added By RV on 13-Sep-2019

        Public Function FunFetchSaleEditVar() As DataTable
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchSaleEditVar")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@BillDate", DbType.Date, BillDate)
                ' DbPubDataBase.AddInParameter(ObjPriCommand, "@ToDate", DbType.Date, dtToDate)
                FunFetchSaleEditVar = DbPubDataBase.ExecuteDataSet(ObjPriCommand).Tables(0)
            Catch ex As Exception
                Throw ex

            Finally
                If IsNothing(DbPubDataBase) = False Then
                    ' DbPubDataBase = Nothing
                End If

                If IsNothing(ObjPriDbCommand) = False Then
                    ObjPriDbCommand = Nothing
                End If

            End Try
        End Function
        'Public Function FunFetchpurchaseEditVar() As DataTable
        '    Try
        '        ObjPriConnection = DbPubDataBase.CreateConnection
        '        ObjPriConnection.Open()
        '        ObjPriTrans = ObjPriConnection.BeginTransaction
        '        ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchSaleEditVar")
        '        DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
        '        DbPubDataBase.AddInParameter(ObjPriCommand, "@BillDate", DbType.Date, PurchaseDate)
        '        ' DbPubDataBase.AddInParameter(ObjPriCommand, "@ToDate", DbType.Date, dtToDate)
        '        FunFetchpurchaseEditVar = DbPubDataBase.ExecuteDataSet(ObjPriCommand).Tables(0)
        '    Catch ex As Exception
        '        Throw ex

        '    Finally
        '        If IsNothing(DbPubDataBase) = False Then
        '            DbPubDataBase = Nothing
        '        End If

        '        If IsNothing(ObjPriDbCommand) = False Then
        '            ObjPriDbCommand = Nothing
        '        End If

        '    End Try
        'End Function




        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction

                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_DeleteSale")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@BillID", DbType.Double, DblPubBillID)
                'DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                'DbPubDataBase.AddInParameter(ObjPriCommand, "@FromDate", DbType.Date, dtFromDate)
                'DbPubDataBase.AddInParameter(ObjPriCommand, "@ToDate", DbType.Date, dtToDate)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
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

        Public Overrides Function FunFetch() As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchSaleMaster")

                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseID", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@BillID", DbType.Double, DblPubBillID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@BillNo", SqlDbType.VarChar, StrBillNo)
                'DbPubDataBase.AddInParameter(ObjPriDbCommand, "@BillDate", DbType.Date, DtBillDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@FromDate", DbType.DateTime, dtFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ToDate", DbType.DateTime, dtToDate)
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

        Public Function FunUpdateOneDayPermit(ByVal CurrentOneDayPermitNo As Integer) As Boolean

            FunUpdateOneDayPermit = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("[Spr_UpdateOneDayPermit]")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@OneDayPermitXML", DbType.Xml, ArrBrandSale.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@licenseid", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CurrentPermitNo", DbType.Int32, CurrentOneDayPermitNo)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Auto", DbType.Boolean, BoolPriAuto)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Username", SqlDbType.VarChar, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunUpdateOneDayPermit = Trim(ObjPriCommand.Parameters("@Outbit").Value)
                StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
                ObjPriTrans.Commit()
            Catch ex As Exception
                FunUpdateOneDayPermit = False
                StrPubErrorMsg = "error occured"
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

        Public Overrides Function FunSave() As Boolean

            FunSave = False
            Try

                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("[spr_SaveSale]")
                ObjPriCommand.CommandTimeout = 999999999
                DbPubDataBase.AddInParameter(ObjPriCommand, "@BillID", DbType.Double, DblPubBillID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@BillNo", DbType.String, StrBillNo)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Billdate", DbType.Date, DtBillDate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@BrandSaleXML", DbType.Xml, ArrBrandSale.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CocktailSaleXML", DbType.Xml, ArrBrandCocktail.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@PermitHolderXML", DbType.Xml, ArrBrandPermit.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Username", SqlDbType.VarChar, StrPubOperator)
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

        Public Function FunFecthBrandCocktailPermit() As DataSet
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchSaleMaster")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseID", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@BillID", DbType.Double, DblPubBillID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@FromDate", DbType.Date, dtFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ToDate", DbType.Date, dtToDate)
                'DbPubDataBase.AddInParameter(ObjPriDbCommand, "@BillDate", DbType.Date, DtBillDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@BillNo", SqlDbType.VarChar, StrBillNo)
                FunFecthBrandCocktailPermit = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand)
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

        Public Function FunWashDay(ByVal IsPurchase As Boolean, ByVal IsSale As Boolean, ByVal IsTransfer As Boolean) As Boolean

            FunWashDay = False
            Try

                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_WashDay")

                DbPubDataBase.AddInParameter(ObjPriCommand, "@licenseid", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@fromdate", DbType.Date, dtFromDate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@todate", DbType.Date, dtToDate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@sale", DbType.Boolean, IsSale)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@purchase", DbType.Boolean, IsPurchase)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@transfer", DbType.Boolean, IsTransfer)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@forLicenseID", DbType.Double, DblPubforLicenseID)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunWashDay = Trim(ObjPriCommand.Parameters("@Outbit").Value)
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

        Public TransactionType As String
        '[+][13/12/2019][Ajay Prajapati]
        Public Function FunCheckVariance() As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_VarianceDone")

                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseID", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@BillDate", DbType.Date, DtBillDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@TransactionType", DbType.String, TransactionType)

                FunCheckVariance = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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
        '[-][13/12/2019][Ajay Prajapati]


    End Class

#End Region

#Region "AutoBilling"
    Public Class ClsAutobilling
        Inherits ClsCommon
#Region "Variables"
        Dim xmlbrand, xmlCocktail, xmlPermitholder As XmlDocument
        Dim DblUnitwiseQty As Double
        Dim dtAutoDate As Date

#End Region
#Region "Property"

        Public Property UnitwiseQty() As Double
            Get
                Return DblUnitwiseQty
            End Get
            Set(ByVal value As Double)
                DblUnitwiseQty = value
            End Set
        End Property

        Public Property AutoDate() As Date
            Get
                Return dtAutoDate
            End Get
            Set(ByVal value As Date)
                dtAutoDate = value
            End Set
        End Property

        Public Property BrandXml As XmlDocument
            Get
                Return xmlbrand
            End Get
            Set(ByVal value As XmlDocument)
                xmlbrand = value
            End Set
        End Property

        Public Property CocktailXml As XmlDocument
            Get
                Return xmlCocktail
            End Get
            Set(ByVal value As XmlDocument)
                xmlCocktail = value
            End Set
        End Property

        Public Property PermitHolderXml As XmlDocument
            Get
                Return xmlPermitholder
            End Get
            Set(ByVal value As XmlDocument)
                xmlPermitholder = value
            End Set
        End Property




#End Region
        Public Overrides Function FunDelete() As Boolean

        End Function
        Public Function BindCocktailRate() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("spr_fetchcocktailrate")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@cocktailId", DbType.Double, DblPubCocktailID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseId", DbType.Double, DblPubLicenseID)
                BindCocktailRate = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

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
        Public Overrides Function FunFetch() As System.Data.DataTable

        End Function

        Public Overrides Function FunSave() As Boolean
            FunSave = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveAutoBill")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@AutoDate", DbType.Date, dtAutoDate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@XmlDocBrand", SqlDbType.Xml, xmlbrand.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@XmlDocCocktail", SqlDbType.Xml, xmlCocktail.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@XmlDocPermit", SqlDbType.Xml, xmlPermitholder.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@UserName", SqlDbType.VarChar, StrPubOperator)
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
        Public Function FunFetchCurrentBill() As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("spr_FetchCurrentBillNumber")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                FunFetchCurrentBill = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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

        Public Function FunFetchBrandQuntity() As DataTable

            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchBrandQuntity")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@BrandID", DbType.Double, DblPubBrandID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@CategorySizeLinkUpID", DbType.Double, DblPubCategorySizeLinkID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@date", DbType.Date, dtAutoDate)
                DbPubDataBase.AddOutParameter(ObjPriDbCommand, "@UnitwiseQty", DbType.Double, 100)
                FunFetchBrandQuntity = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
                DblUnitwiseQty = ObjPriDbCommand.Parameters("@UnitwiseQty").Value
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

        Public Function FunFecthTaxPercentage() As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_fetchcategorytax")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@categorytaxid", DbType.Double, DblPubCategoryTaxID)
                FunFecthTaxPercentage = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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

        Public Function FunFecthNegativeStock() As DataTable
            FunFecthNegativeStock = Nothing
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_ValidateNegativeStock")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@XmlDocBrand", DbType.Xml, xmlbrand.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@XmlDocCocktail", DbType.Xml, xmlCocktail.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@date", DbType.Date, dtAutoDate)
                FunFecthNegativeStock = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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

        Public Function FunFecthBrandOpeningForExport() As DataTable
            FunFecthBrandOpeningForExport = Nothing
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_ExportBrandOpening")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
                FunFecthBrandOpeningForExport = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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


        Public Function funFetchSettelementData(ByVal IntLocSettleType As Integer) As DataTable
            funFetchSettelementData = Nothing
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("spr_FetchVarianceForSettalment")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@vardate", DbType.Date, dtAutoDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@SettleType", DbType.Int32, IntLocSettleType)
                funFetchSettelementData = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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

#Region "Consumption Master"

    Public Class ClsConsumptionMaster
        Inherits ClsCommon

#Region "Variable"
        Dim DblPubQty As Double
        Dim StrPriMlType As String
#End Region

#Region "Property"

        Public Property MlType As String
            Get
                Return StrPriMlType
            End Get
            Set(ByVal value As String)
                StrPriMlType = value
            End Set
        End Property


        Public Property Qty As Double
            Get
                Return DblPubQty
            End Get
            Set(ByVal value As Double)
                DblPubQty = value
            End Set
        End Property

#End Region


        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_DeleteConsumptionMSt")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@ConsumptionID", DbType.Double, DblPubConsumptionID)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
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
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchConsumption")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ConsumptionID", DbType.Double, DblPubConsumptionID)
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
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveConsumptionMaster")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@ConsumptionID", DbType.Double, DblPubConsumptionID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@categoryID", DbType.Double, DblPubCategoryID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CategorySizeLinkID", DbType.Double, DblPubCategorySizeLinkID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Qty", DbType.Double, DblPubQty)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@MlType", SqlDbType.VarChar, StrPriMlType)


                DbPubDataBase.AddInParameter(ObjPriCommand, "@UserName", SqlDbType.VarChar, StrPubOperator)
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

#Region "ParameterControls"

    Public Class ClsParameter
        Inherits ClsCommon

#Region "Variable"
        Public StrPriParameterName, StrPriParameterDesc, StrPriBehaviour As String


#End Region
#Region "Property"
        Public Property ParameterName() As String
            Get
                Return StrPriParameterName
            End Get
            Set(ByVal value As String)
                StrPriParameterName = value
            End Set
        End Property
        Public Property ParameterDesc() As String
            Get
                Return StrPriParameterDesc
            End Get
            Set(ByVal value As String)
                StrPriParameterDesc = value
            End Set
        End Property
        Public Property Behaviour() As String
            Get
                Return StrPriBehaviour
            End Get
            Set(ByVal value As String)
                StrPriBehaviour = value
            End Set
        End Property
#End Region

        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_DeleteParameterMaster")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@ParameterID", DbType.Double, DblPubParameterID)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
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
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchParameterMaster")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ParameterID", DbType.Double, DblPubParameterID)

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
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveParameterMaster")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@ParameterID", DbType.Double, DblPubParameterID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@ParameterName", SqlDbType.VarChar, StrPriParameterName)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@ParameterDesc", SqlDbType.VarChar, StrPriParameterDesc)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Behaviour", SqlDbType.VarChar, StrPriBehaviour)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@UserName", SqlDbType.VarChar, StrPubOperator)
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

#Region "Cocktail Report"

    Public Class ClsCocktailReports
        Inherits ClsCommon
#Region "Variable"
        Public dtReportDate, dtFromDate, dtToDate As DateTime
        Public strPriMenuDesc, StrPriLicenseList, StrPriBillNo, StrPriCocktailName, StrPriBrand, StrPriCategory, StrPriCocktailCode, StrPriBrandCode, strPriType, strPriHeader, StrPriFilename As String
        Public blAllCheck As Boolean
        Public xmlReport As XmlDocument
        Public StrPriOutMsg, StrPriCostType As String
        Public bloutbit, blisValid, blisML As Boolean
#End Region
#Region "Properties"

        Public Property Filename() As String
            Get
                Return StrPriFilename
            End Get
            Set(ByVal value As String)
                StrPriFilename = value
            End Set
        End Property

        Public Property Header() As String
            Get
                Return strPriHeader
            End Get
            Set(ByVal value As String)
                strPriHeader = value
            End Set
        End Property

        Public Property Type() As String
            Get
                Return strPriType
            End Get
            Set(ByVal value As String)
                strPriType = value
            End Set
        End Property

        Public Property isML() As Boolean
            Get
                Return blisML
            End Get
            Set(ByVal value As Boolean)
                blisML = value
            End Set
        End Property

        Public Property isValid() As Boolean
            Get
                Return blisValid
            End Get
            Set(ByVal value As Boolean)
                blisValid = value
            End Set
        End Property



        Public Property BrandCode() As String
            Get
                Return StrPriBrandCode
            End Get
            Set(ByVal value As String)
                StrPriBrandCode = value
            End Set
        End Property

        Public Property CostType() As String
            Get
                Return StrPriCostType
            End Get
            Set(ByVal value As String)
                StrPriCostType = value
            End Set
        End Property

        Public Property CocktailCode() As String
            Get
                Return StrPriCocktailCode
            End Get
            Set(ByVal value As String)
                StrPriCocktailCode = value
            End Set
        End Property

        Public Property Category() As String
            Get
                Return StrPriCategory
            End Get
            Set(ByVal value As String)
                StrPriCategory = value
            End Set
        End Property
        Public Property Brand() As String
            Get
                Return StrPriBrand
            End Get
            Set(ByVal value As String)
                StrPriBrand = value
            End Set
        End Property

        Public Property CocktailName() As String
            Get
                Return StrPriCocktailName
            End Get
            Set(ByVal value As String)
                StrPriCocktailName = value
            End Set
        End Property

        Public Property BillNo() As String
            Get
                Return StrPriBillNo
            End Get
            Set(ByVal value As String)
                StrPriBillNo = value
            End Set
        End Property

        Public Property LicenseList() As String
            Get
                Return StrPriLicenseList
            End Get
            Set(ByVal value As String)
                StrPriLicenseList = value
            End Set
        End Property

        Public Property OutBit() As Boolean
            Get
                Return bloutbit
            End Get
            Set(ByVal value As Boolean)
                bloutbit = value
            End Set
        End Property

        Public Property OutMsg() As String
            Get
                Return StrPriOutMsg
            End Get
            Set(ByVal value As String)
                StrPriOutMsg = value
            End Set
        End Property

        Public Property CocktailReportXml As XmlDocument
            Get
                Return xmlReport
            End Get
            Set(ByVal value As XmlDocument)
                xmlReport = value
            End Set
        End Property

        Public Property All() As Boolean
            Get
                Return blAllCheck
            End Get
            Set(ByVal value As Boolean)
                blAllCheck = value
            End Set
        End Property

        Public Property MenuDesc() As String
            Get
                Return strPriMenuDesc
            End Get
            Set(ByVal value As String)
                strPriMenuDesc = value
            End Set
        End Property

        Public Property FromDate() As DateTime
            Get
                Return dtFromDate
            End Get
            Set(ByVal value As DateTime)
                dtFromDate = value
            End Set
        End Property

        Public Property ToDate() As DateTime
            Get
                Return dtToDate
            End Get
            Set(ByVal value As DateTime)
                dtToDate = value
            End Set
        End Property

        Public Property ReportDate() As DateTime
            Get
                Return dtReportDate
            End Get
            Set(ByVal value As DateTime)
                dtReportDate = value
            End Set
        End Property
#End Region
        Public Overrides Function FunDelete() As Boolean

        End Function

        Public Overrides Function FunFetch() As System.Data.DataTable

        End Function


        Public Function FetchOpeningStockReport() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchOpeningStockReport")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@brandid", DbType.Double, DblPubBrandID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@CategoryID", DbType.Double, StrPriBrandCode)
                FetchOpeningStockReport = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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
        Public Function FunFetchBulkLiterReport(Optional ByVal timeout As Integer = 30) As System.Data.DataTable
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_BulkReportLiter")
            Try
                ObjPriDbCommand.CommandTimeout = timeout
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseXML", SqlDbType.Xml, xmlReport.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@FromDate", DbType.DateTime, dtFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ToDate", DbType.DateTime, dtToDate)
                DbPubDataBase.AddOutParameter(ObjPriDbCommand, "@isvalid", SqlDbType.Bit, blisValid)
                DbPubDataBase.AddOutParameter(ObjPriDbCommand, "@OutMsg", SqlDbType.VarChar, 100)
                FunFetchBulkLiterReport = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
                StrPriOutMsg = Trim(ObjPriDbCommand.Parameters("@OutMsg").Value)
                ' BoolPubOutParam = ObjPriDbCommand.Parameters("@Outbit").Value
                bloutbit = ObjPriDbCommand.Parameters("@isvalid").Value

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


        Public Function FunFetchReport(ByVal StrPriProcName As String, ByVal IntPubTimeOut As Integer) As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand(StrPriProcName)
                ObjPriDbCommand.CommandTimeout = IntPubTimeOut
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@xmlDoc", SqlDbType.Xml, xmlReport.InnerXml)
                DbPubDataBase.AddOutParameter(ObjPriDbCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriDbCommand, "@OutMsg", SqlDbType.VarChar, 100)
                FunFetchReport = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
                StrPriOutMsg = Trim(ObjPriDbCommand.Parameters("@OutMsg").Value)
                BoolPubOutParam = ObjPriDbCommand.Parameters("@Outbit").Value
                bloutbit = ObjPriDbCommand.Parameters("@Outbit").Value


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



        Public Function FunFetchBrandCodeReport() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchBrandCodeReport")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@brandID", DbType.Double, DblPubBrandID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@BrandDesc", SqlDbType.VarChar, StrPriBrandCode)
                FunFetchBrandCOdeReport = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

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


        'Created By Ravindra Muthe on 18-MARCH-2019
        Public Function FunFetchMMSCodeReport() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchMMSCodeReport")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@brandID", DbType.Double, DblPubBrandID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@BrandDesc", SqlDbType.VarChar, StrPriBrandCode)
                FunFetchMMSCodeReport = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

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




        Public Function FunFetchBrandListReport() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("SpRpt_FetchBrandDetailReports")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@brandID", DbType.Double, DblPubBrandID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@BrandDesc", SqlDbType.VarChar, StrPriBrandCode)
                FunFetchBrandListReport = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

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

        Public Function FunFetchCostingVerification() As System.Data.DataSet
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchCostingVerification")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@FromDate", DbType.DateTime, dtFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ToDate", DbType.DateTime, dtToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@brand", DbType.String, StrPriBrand)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@Category", DbType.String, StrPriCategory)
                FunFetchCostingVerification = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand)

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

        Public Function FunFetchCocktailSaleReport() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchCocktailReport")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseID", DbType.String, StrPriLicenseList)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@billno", DbType.String, StrPriBillNo)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@cocktailname", DbType.String, StrPriCocktailName)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@brandname", DbType.String, StrPriBrand)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.Date, dtFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, dtToDate)
                FunFetchCocktailSaleReport = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

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

        Public Function FunFetchBaseQtyReport() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_Baseqty")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@date", DbType.DateTime, dtReportDate)
                FunFetchBaseQtyReport = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

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

        Public Function FunFetchNonMovingBrandsReport() As System.Data.DataSet
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchNonMovingBrands")
                ObjPriDbCommand.CommandTimeout = 10000
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.Date, dtFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, dtToDate)
                FunFetchNonMovingBrandsReport = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand)

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


        Public Function FunFetchBrandwiseComparisonReport() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_BrandwiseComparisonReport")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.Date, dtFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, dtToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@type", DbType.String, Type)
                FunFetchBrandwiseComparisonReport = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

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

        Public Function FunFetchDailyBarStockReport() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchKolkataStock")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.Date, dtFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, dtToDate)
                FunFetchDailyBarStockReport = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

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

        Public Function FunFetchDailyAccountkolkattaReport() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_DailyAccountkolkatta")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.Date, dtFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, dtToDate)
                FunFetchDailyAccountkolkattaReport = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

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

        Public Function FunFetchCategorywiseComparisonReport() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_CategorywiseComparisonReport")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.Date, dtFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, dtToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@type", DbType.String, Type)
                FunFetchCategorywiseComparisonReport = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

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

        Public Function FunFetchOptQtyReport(Optional ByVal IntPubTimeOut As Integer = 30) As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_BaseOptimumqty")
                ObjPriDbCommand.CommandTimeout = IntPubTimeOut
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@date", DbType.DateTime, dtReportDate)
                FunFetchOptQtyReport = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

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

        Public Function FunFetchCocktailDescReport(Optional ByVal Cocktail As String = "", Optional ByVal Brand As String = "") As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("spr_fetchCocktailReportDetails")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@Cocktail", DbType.String, Cocktail)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@Brand", DbType.String, Brand)
                FunFetchCocktailDescReport = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

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

        Public Function FunFetchCocktailCodeReport() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("spr_fetchCocktailCodeReport")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@cocktailid", DbType.Double, DblPubCocktailID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@CocktailCode", DbType.String, StrPriCocktailCode)
                FunFetchCocktailCodeReport = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

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

        Public Function FunFetchMenuID() As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("spr_FetchMenuID")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@MenuDesc", SqlDbType.VarChar, strPriMenuDesc)

                FunFetchMenuID = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
                '  intOutMenuID = Trim(ObjPriCommand.Parameters("@outmenuid").Value)
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

        Public Function FunFetchMenuUserRights(ByVal DblLocUserId As Double) As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("spr_FetchMenuUserRights")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@menuDesc", DbType.String, strPriMenuDesc)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@userid", DbType.Double, DblLocUserId)
                FunFetchMenuUserRights = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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

        Public Function FunFetchApBangloreReport(ByVal ProcedureName As String, ByVal TimeOut As Integer) As System.Data.DataTable
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand(ProcedureName)
            Try
                ObjPriDbCommand.CommandTimeout = TimeOut
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseXML", SqlDbType.Xml, xmlReport.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@FromDate", DbType.DateTime, dtFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ToDate", DbType.DateTime, dtToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@IsCombined", SqlDbType.Bit, blAllCheck)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@username", DbType.String, StrPubOperator)
                FunFetchApBangloreReport = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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

        Public Function FunFetchBulkBeer(ByVal TimeOut As Integer) As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchBulkBeer")
                ObjPriDbCommand.CommandTimeout = TimeOut

                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseXML", DbType.Xml, xmlReport.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@FromDate", DbType.DateTime, dtFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ToDate", DbType.DateTime, dtToDate)
                FunFetchBulkBeer = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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

        Public Function FunFetchbanglorereportmonthly(ByVal TimeOut As Integer, Optional ByVal IsTP As Boolean = False) As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_Fetchbanglorereportmonthly")
                ObjPriDbCommand.CommandTimeout = TimeOut

                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseXML", DbType.Xml, xmlReport.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@FromDate", DbType.DateTime, dtFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ToDate", DbType.DateTime, dtToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@IsTP", DbType.Boolean, IsTP)
                FunFetchbanglorereportmonthly = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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

        Public Function FunFetchCostEvaluationReport() As System.Data.DataSet
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchCostEvaluationReport")
            Try
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licensexml", SqlDbType.Xml, xmlReport.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@FromDate", DbType.DateTime, dtFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ToDate", DbType.DateTime, dtToDate)
                FunFetchCostEvaluationReport = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand)
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

        Public Function FunFetchLicenseWiseSummery() As System.Data.DataTable
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_fetchLicenseWiseSummery")
            Try
                ObjPriDbCommand.CommandTimeout = 999999999
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licensexml", SqlDbType.Xml, xmlReport.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@FromDate", DbType.DateTime, dtFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ToDate", DbType.DateTime, dtToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@InML", DbType.Boolean, isML)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@type", DbType.String, strPriType)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@Username", DbType.String, StrPubOperator)
                FunFetchLicenseWiseSummery = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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


        Public Function FunFetchCostEvaluationReportv2() As System.Data.DataTable
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchCostEvaluationReportv2")
            Try
                ObjPriDbCommand.CommandTimeout = 999999999
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licensexml", SqlDbType.Xml, xmlReport.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@FromDate", DbType.DateTime, dtFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ToDate", DbType.DateTime, dtToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@reporttype", DbType.String, StrPriCostType)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@InML", DbType.Boolean, isML)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@Brandid", DbType.Double, DblPubBrandID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@CategoryID", DbType.Double, DblPubCategoryID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@SubcategoryID", DbType.Double, DblPubSubCategoryID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@sizeID", DbType.Double, DblPubSizeID)
                FunFetchCostEvaluationReportv2 = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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

        Public Sub SubProcessStockRegister(ByVal InLocTimeOut As Integer)

            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_ProcessStockRegister")
                ObjPriDbCommand.CommandTimeout = InLocTimeOut
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@FromDate", DbType.DateTime, dtFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ToDate", DbType.DateTime, dtToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@Username", DbType.String, StrPubOperator)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@filtercategoryid", DbType.Double, DblPubCategoryID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@filterbrandid", DbType.Double, DblPubBrandID)
                DbPubDataBase.ExecuteNonQuery(ObjPriDbCommand)
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
        End Sub

    End Class

#End Region


#Region "Schedule Variance Class"
    Public Class ClsScheduleVariance
        Inherits ClsCommon
#Region "VAriables"
        Private IntPriRepeat As Integer
        Private dtPriStartDate As Date
#End Region
#Region "Property"

        Public Property Repeat() As Integer
            Get
                Return IntPriRepeat
            End Get
            Set(ByVal value As Integer)
                IntPriRepeat = value
            End Set
        End Property

        Public Property StartDate() As Date
            Get
                Return dtPriStartDate
            End Get
            Set(ByVal value As Date)
                dtPriStartDate = value
            End Set
        End Property

#End Region
        Public Overrides Function FunDelete() As Boolean
            FunDelete = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_DeleteScheduleVariance")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@ScheduleID", DbType.Double, DblPubScheduleID)
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
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchScheduleVariance")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
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
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveScheduleVariance")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Scheduleid", DbType.Double, DblPubScheduleID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Licenseid", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@repeat", SqlDbType.Int, IntPriRepeat)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@startdate", DbType.Date, dtPriStartDate)
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

#Region "Merge Period Class"
    Public Class ClsMergePeriod
        Inherits ClsCommon
#Region "VAriables"
        Private StrPriDescription As String
        Private dtPriFromDate, dtPriToDate As DateTime
        Private xmlMergePeriod As XmlDocument
#End Region
#Region "Property"
        Public Property Description() As String
            Get
                Return StrPriDescription
            End Get
            Set(ByVal value As String)
                StrPriDescription = value
            End Set
        End Property

        Public Property MergePeriodXML As XmlDocument
            Get
                Return xmlMergePeriod
            End Get
            Set(ByVal value As XmlDocument)
                xmlMergePeriod = value
            End Set
        End Property

        Public Property FromDate() As DateTime
            Get
                Return dtPriFromDate
            End Get
            Set(ByVal value As DateTime)
                dtPriFromDate = value
            End Set
        End Property

        Public Property ToDate() As DateTime
            Get
                Return dtPriToDate
            End Get
            Set(ByVal value As DateTime)
                dtPriToDate = value
            End Set
        End Property
#End Region

        Public Overrides Function FunDelete() As Boolean

        End Function

        Public Overrides Function FunFetch() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchPeriodToMerge")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.DateTime, dtPriFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.DateTime, dtPriToDate)
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
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SavePeriodMerge")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@licenseid", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Description", DbType.String, StrPriDescription)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@fromdate", DbType.DateTime, dtPriFromDate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@todate", DbType.DateTime, dtPriToDate)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@MergePeriodXML", SqlDbType.Xml, xmlMergePeriod.InnerXml)
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

#Region "RackOutletReports"

    Public Class RackOutletReports
        Inherits ClsCommon


#Region "Variable"
        Private DtPriReportDate, DtPriFromDate, DtPriToDate As Date
        Private BoolPriAllCheck As Boolean
        Private StrPriOutMsg As String
        Private BoolPriOutBit As Boolean
        Private IntPubTimeOut As Integer
#End Region

#Region "Properties"

        Public Property TimeOut() As Integer
            Get
                Return IntPubTimeOut
            End Get
            Set(ByVal value As Integer)
                IntPubTimeOut = value
            End Set
        End Property

        Public Property AllCheck() As Boolean
            Get
                Return BoolPriAllCheck
            End Get
            Set(ByVal value As Boolean)
                BoolPriAllCheck = value
            End Set
        End Property

        Public Property OutBit() As Boolean
            Get
                Return BoolPriOutBit
            End Get
            Set(ByVal value As Boolean)
                BoolPriOutBit = value
            End Set
        End Property

        Public Property OutMsg() As String
            Get
                Return StrPriOutMsg
            End Get
            Set(ByVal value As String)
                StrPriOutMsg = value
            End Set
        End Property

        Public Property FromDate() As DateTime
            Get
                Return DtPriFromDate
            End Get
            Set(ByVal value As DateTime)
                DtPriFromDate = value
            End Set
        End Property

        Public Property ToDate() As DateTime
            Get
                Return DtPriToDate
            End Get
            Set(ByVal value As DateTime)
                DtPriToDate = value
            End Set
        End Property

        Public Property ReportDate() As DateTime
            Get
                Return DtPriReportDate
            End Get
            Set(ByVal value As DateTime)
                DtPriReportDate = value
            End Set
        End Property

#End Region

#Region "Functions"

        Public Function FunFetchFlr3ReportForRackOutlet() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchFlr3ReportForRackOutlet")
                ObjPriDbCommand.CommandTimeout = IntPubTimeOut
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@Date", DbType.Date, DtPriReportDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@All", DbType.Boolean, BoolPriAllCheck)
                DbPubDataBase.AddOutParameter(ObjPriDbCommand, "@outbit", DbType.Boolean, 1)
                DbPubDataBase.AddOutParameter(ObjPriDbCommand, "@outmsg", DbType.String, 100)
                FunFetchFlr3ReportForRackOutlet = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
                StrPriOutMsg = Trim(ObjPriDbCommand.Parameters("@OutMsg").Value)
                BoolPriOutBit = ObjPriDbCommand.Parameters("@outbit").Value
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


        Public Function FunFetchChataiReportForRackOutlet() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchChataiReportForRackOutlet")
                ObjPriDbCommand.CommandTimeout = IntPubTimeOut
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.Date, DtPriFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, DtPriToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddOutParameter(ObjPriDbCommand, "@outbit", DbType.Boolean, 1)
                DbPubDataBase.AddOutParameter(ObjPriDbCommand, "@outmsg", DbType.String, 100)
                FunFetchChataiReportForRackOutlet = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
                StrPriOutMsg = Trim(ObjPriDbCommand.Parameters("@OutMsg").Value)
                BoolPriOutBit = ObjPriDbCommand.Parameters("@outbit").Value
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

        Public Function FunFetchFlr4ForRackOutlet() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchFlr4ForRackOutlet")
                ObjPriDbCommand.CommandTimeout = IntPubTimeOut
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.Date, DtPriFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, DtPriToDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddOutParameter(ObjPriDbCommand, "@outbit", DbType.Boolean, 1)
                DbPubDataBase.AddOutParameter(ObjPriDbCommand, "@outmsg", DbType.String, 100)
                FunFetchFlr4ForRackOutlet = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
                StrPriOutMsg = Trim(ObjPriDbCommand.Parameters("@OutMsg").Value)
                BoolPriOutBit = ObjPriDbCommand.Parameters("@outbit").Value
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

        Public Overrides Function FunDelete() As Boolean

        End Function

        Public Overrides Function FunFetch() As System.Data.DataTable

        End Function

        Public Overrides Function FunSave() As Boolean

        End Function
#End Region


    End Class
#End Region

#Region "LicenseTransactionDetails"

    Public Class clsLicenaseTransctionDtails
        Inherits ClsCommon




        Public Overrides Function FunDelete() As Boolean

        End Function

        Public Overrides Function FunFetch() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchLicenseTransactionDetails")

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

#Region "MultipalLicenseTransfer"

    Public Class clsMultipleLicenase
        Inherits ClsCommon

#Region "Variable"
        Public StrArrParameterId As XmlDocument
        Public intBrandOpening, intAssignBrandCode, intCocktail, intCocktailCode, intMMSCode As Integer

#End Region

#Region "Property"
        Public Property ArrLicenseParameterId() As XmlDocument
            Get
                Return StrArrParameterId
            End Get
            Set(ByVal value As XmlDocument)
                StrArrParameterId = value
            End Set
        End Property

        Public Property Brandopening() As Integer
            Get
                Return intBrandOpening
            End Get
            Set(ByVal value As Integer)
                intBrandOpening = value
            End Set
        End Property
        Public Property AssignBrandCode() As Integer
            Get
                Return intAssignBrandCode
            End Get
            Set(ByVal value As Integer)
                intAssignBrandCode = value
            End Set
        End Property
        Public Property Cocktail() As Integer
            Get
                Return intCocktail
            End Get
            Set(ByVal value As Integer)
                intCocktail = value
            End Set
        End Property
        Public Property CocktailCode() As Integer
            Get
                Return intCocktailCode
            End Get
            Set(ByVal value As Integer)
                intCocktailCode = value
            End Set
        End Property
        Public Property MMSCode() As Integer
            Get
                Return intMMSCode
            End Get
            Set(ByVal value As Integer)
                intMMSCode = value
            End Set
        End Property

#End Region



        Public Overrides Function FunDelete() As Boolean

        End Function

        Public Overrides Function FunFetch() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchLicenseForTransferMaster")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
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
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveMultipleLicense")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@licenseid", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@XmlDoc", DbType.Xml, StrArrParameterId.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@BrandOpening", DbType.Int32, intBrandOpening)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@AssignBrandCode", DbType.Int32, intAssignBrandCode)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Cocktail", DbType.Int32, intCocktail)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@CocktailCode", DbType.Int32, intCocktailCode)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@MMSCode", DbType.String, intMMSCode)

                DbPubDataBase.AddInParameter(ObjPriCommand, "@UserName", SqlDbType.VarChar, StrPubOperator)
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

#Region "General Setup"

    Public Class clsGeneralSetup
        Inherits ClsCommon

#Region "Variable"
        Public StrArrParameterId As XmlDocument
        Public StrpriFLIVAddress, StrpriAllowNegativeStock, StrpriOnlyInventory As Boolean
        Public intpriClientID, intprilicID As Double
        Public strpriClientName As String
        Public StrpriReportType As Char
#End Region

#Region "Property"
        Public Property ArrUserParameterId() As XmlDocument
            Get
                Return StrArrParameterId
            End Get
            Set(ByVal value As XmlDocument)
                StrArrParameterId = value
            End Set
        End Property

        Public Property ReportType() As Char
            Get
                Return StrpriReportType
            End Get
            Set(ByVal value As Char)
                StrpriReportType = value
            End Set
        End Property

        Public Property AllowNegativeStock() As Boolean
            Get
                Return StrpriAllowNegativeStock
            End Get
            Set(ByVal value As Boolean)
                StrpriAllowNegativeStock = value
            End Set
        End Property

        Public Property OnlyInventory() As Boolean
            Get
                Return StrpriOnlyInventory
            End Get
            Set(ByVal value As Boolean)
                StrpriOnlyInventory = value
            End Set
        End Property

        Public Property FLIVAddress() As Boolean
            Get
                Return StrpriFLIVAddress
            End Get
            Set(ByVal value As Boolean)
                StrpriFLIVAddress = value
            End Set
        End Property

        Public Property ClientID() As Double
            Get
                Return intpriClientID
            End Get
            Set(ByVal value As Double)
                intpriClientID = value
            End Set
        End Property

        Public Property LicenseID() As Double
            Get
                Return intprilicID
            End Get
            Set(ByVal value As Double)
                intprilicID = value
            End Set
        End Property

        Public Property ClientName() As String
            Get
                Return strpriClientName
            End Get
            Set(ByVal value As String)
                strpriClientName = value
            End Set
        End Property

#End Region

        Public Function FunUpdateClient() As Boolean
            FunUpdateClient = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("spr_updateClient")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@clientName", SqlDbType.VarChar, strpriClientName)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@clientID", DbType.Double, intpriClientID)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@LicID", DbType.Double, intprilicID)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunUpdateClient = Trim(ObjPriCommand.Parameters("@Outbit").Value)
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

        Public Function FunFetchClient() As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("spr_fetchClient")
                FunFetchClient = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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


        Public Overrides Function FunDelete() As Boolean

        End Function

        Public Function FunSaveGenSetup() As Boolean
            FunSaveGenSetup = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_GenSetUpSaveing")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@FLIVAddress", DbType.Boolean, StrpriFLIVAddress)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@AllowNegativeStock", DbType.Boolean, StrpriAllowNegativeStock)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@OnlyInventory", DbType.Boolean, StrpriOnlyInventory)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@ReportType", DbType.String, ReportType)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@oprm", DbType.String, StrPubOperator)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", DbType.Boolean, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", DbType.String, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunSaveGenSetup = Trim(ObjPriCommand.Parameters("@Outbit").Value)
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

        Public Function FunFetchGSetUp() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_GenSetUp")
                FunFetchGSetUp = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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

        Public Overrides Function FunFetch() As System.Data.DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("SprFetchButtonSetup")

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
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveGeneralSetupForButton")
                DbPubDataBase.AddInParameter(ObjPriCommand, "@XmlDoc", DbType.Xml, StrArrParameterId.InnerXml)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@Username", SqlDbType.VarChar, StrPubOperator)
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


#Region "Migration"

    Public Class ClsMigration
        Inherits ClsCommon
#Region "Variables"
        Private StrPriDbName As String
        Private DblPriLicenseid As Double
        Private DtPriOpeningDate As DateTime
#End Region

#Region "Property"

        Public Property OpeningDate() As DateTime
            Get
                Return DtPriOpeningDate
            End Get
            Set(ByVal value As DateTime)
                DtPriOpeningDate = value
            End Set
        End Property

        Public Property NewLicenseid() As Double
            Get
                Return DblPriLicenseid
            End Get
            Set(ByVal value As Double)
                DblPriLicenseid = value
            End Set
        End Property

        Public Property DbName() As String
            Get
                Return StrPriDbName
            End Get
            Set(ByVal value As String)
                StrPriDbName = value
            End Set
        End Property
#End Region
        

        Public Function FunMigrate(ByVal ProcName As String) As Boolean
            FunMigrate = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand(ProcName)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@dbname", SqlDbType.VarChar, StrPriDbName)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunMigrate = Trim(ObjPriCommand.Parameters("@Outbit").Value)
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

        Public Function FunSetOpeningStockForMigration(ByVal ProcName As String) As Boolean
            FunSetOpeningStockForMigration = False
            Try
                ObjPriConnection = DbPubDataBase.CreateConnection
                ObjPriConnection.Open()
                ObjPriTrans = ObjPriConnection.BeginTransaction
                ObjPriCommand = DbPubDataBase.GetStoredProcCommand(ProcName)
                ObjPriCommand.CommandTimeout = 10000
                DbPubDataBase.AddInParameter(ObjPriCommand, "@licenseid", DbType.Double, DblPriLicenseid)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@dbname", SqlDbType.VarChar, StrPriDbName)
                DbPubDataBase.AddInParameter(ObjPriCommand, "@openingdate", DbType.DateTime, DtPriOpeningDate)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
                DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
                DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
                FunSetOpeningStockForMigration = Trim(ObjPriCommand.Parameters("@Outbit").Value)
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

        Public Function FetchViewCocktailtocreate() As DataTable
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_ViewCocktailtocreate")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid ", DbType.Double, DblPriLicenseid)
                FetchViewCocktailtocreate = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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

        Public Overrides Function FunDelete() As Boolean

        End Function

        Public Overrides Function FunFetch() As System.Data.DataTable

        End Function

        Public Overrides Function FunSave() As Boolean

        End Function
    End Class

#End Region

End Namespace



