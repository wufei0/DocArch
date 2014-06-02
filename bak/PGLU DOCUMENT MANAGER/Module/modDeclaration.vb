Imports System.Data.Odbc

Module modDeclaration

    Public FbConnection As OdbcConnection
    'Public FbRecordset As OdbcDataReader
    Public FbCommand As New OdbcCommand
    Public FbSql As String

    Public FirebirdIP As String
    Public FirebirdDbase As String

    Public SysUserName As String
    Public SysPassword As String

    Public LoggedUser As String = Nothing

    Public Security_Group As String
    Public TransactionNumber As Integer

    Public SecurityDataTable As New DataTable("SECURITY_TEMPLATE")
End Module
