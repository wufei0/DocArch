Imports System.Data.Odbc
Imports System.IO
Imports Microsoft.VisualBasic.Strings

Module modConnection

    Public Sub FirebirdConnect()
        Dim ConfCategory As String
        Try

            'VIEW CONFIG.INF TO VIEW DATABASE CONFIG
            Dim COnfReader As StreamReader = New StreamReader(My.Application.Info.DirectoryPath & " \config.inf")
            ConfCategory = COnfReader.ReadLine()
            Do

                If InStr(ConfCategory.ToUpper, "IP") Then    'SEARCH FOR IP KEYWORD
                    FirebirdIP = Microsoft.VisualBasic.Right(ConfCategory, Microsoft.VisualBasic.Len(ConfCategory) - InStr(ConfCategory, "'"))
                    FirebirdIP = Microsoft.VisualBasic.Left(FirebirdIP, Microsoft.VisualBasic.Len(FirebirdIP) - 1)
                    'txtIP.Text = FirebirdIP
                ElseIf InStr(ConfCategory.ToUpper, "DBNAME") Then   'SEARCH FOR FirebirdDbase KEYWORD
                    FirebirdDbase = Microsoft.VisualBasic.Right(ConfCategory, Microsoft.VisualBasic.Len(ConfCategory) - InStr(ConfCategory, "'"))
                    FirebirdDbase = Microsoft.VisualBasic.Left(FirebirdDbase, Microsoft.VisualBasic.Len(FirebirdDbase) - 1)
                    'txtFirebirdDbase.Text = FirebirdDbase

                    'ElseIf InStr(ConfCategory.ToUpper, "PASSWORD") Then   'SEARCH FOR PASSWORD KEYWORD
                    '    FirebirdDbasePassword = Microsoft.VisualBasic.Right(ConfCategory, Microsoft.VisualBasic.Len(ConfCategory) - InStr(ConfCategory, "'"))
                    '    FirebirdDbasePassword = Microsoft.VisualBasic.Left(FirebirdDbasePassword, Microsoft.VisualBasic.Len(FirebirdDbasePassword) - 1)
                    '    FirebirdDbasePassword = AES_Decrypt(FirebirdDbasePassword, "PaSSw0Rd")
                    '    'txtFirebirdDbasePasswordWORD.Text = AES_Decrypt(FirebirdDbasePassword, "PaSSw0Rd")
                End If
                ConfCategory = COnfReader.ReadLine()
            Loop Until ConfCategory Is Nothing
            COnfReader.Close()

            FbSql = "Driver=Firebird/InterBase(r) driver;Uid=sysdba; Pwd=launi0n@dmin; Dbname=" & FirebirdIP & ":" & FirebirdDbase & "; "
            'DBConstring = "Driver=Firebird/InterBase(r) driver;Uid=sysdba; Pwd=masterkey; FirebirdDbase=" & FirebirdDbase & "; "
            FbConnection = New OdbcConnection(FbSql)
            FbConnection.Open()

        Catch ex As Exception
            modFunction.SystemStatus("Connection failed.")
            MsgBox(ex.Message & vbNewLine & vbNewLine & "Cannot Connect to Firebird Server. Consult your Database Admin.", vbCritical, My.Application.Info.Title.ToString)
            FbConnection.Close()
            End

        End Try

        FbConnection.Close()
    End Sub

    Public Function FBUserConnect(ByVal UserName As String, ByVal Password As String) As Boolean

        Try
            FbSql = "Driver=Firebird/InterBase(r) driver;Uid=" & UserName.ToUpper & "; Pwd=" & Password & "; Dbname=" & FirebirdIP & ":" & FirebirdDbase & "; "
            FbConnection = New OdbcConnection(FbSql)
            FbConnection.Open()
        Catch ex As Exception

            FbConnection.Close()
            FBUserConnect = False
            Return FBUserConnect
        Finally
            FbConnection.Close()
        End Try


        FBUserConnect = True
    End Function

    Public Sub FBirdConnectionOpen()
        Try
            modFunction.SystemStatus("Reconnecting to db server")
            FbSql = "Driver=Firebird/InterBase(r) driver;Uid=" & SysUserName.ToUpper & "; Pwd=" & SysPassword & "; Dbname=" & FirebirdIP & ":" & FirebirdDbase & "; "
            FbConnection = New OdbcConnection(FbSql)
            FbConnection.Open()
        Catch ex As Exception
            modFunction.SystemStatus("Connection failed. Check your network connection or inform the system administrator")
            MsgBox(ex.Message & vbNewLine & vbNewLine & "Cannot Connect to Firebird Server. Consult your Database Admin.", vbCritical, My.Application.Info.Title.ToString)
            FbConnection.Close()
            'FBUserConnect = False
            'Return FBUserConnect()
        End Try
        modFunction.SystemStatus()
    End Sub
End Module
