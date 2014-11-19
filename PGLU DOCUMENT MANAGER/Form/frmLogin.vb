Imports System.Data.Odbc
Imports System.Net
Imports System.Net.NetworkInformation
Public Class frmLogin

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        'Call FirebirdConnect()

        modFunction.SystemStatus("Log-in")
        'SET USERNAME AND PASSWORD TO PUBLIC VARIABLE FOR EASY ACCESS
        SysUserName = txtuser.Text.ToUpper
        SysPassword = txtpassword.Text


        If FBUserConnect(SysUserName, SysPassword) = False Then
            MsgBox("Username or password is invalid", vbInformation, My.Application.Info.Title.ToString)
            Exit Sub

        Else
            Try
                Call FBirdConnectionOpen()
                FBcommand = New OdbcCommand
                FbCommand.Connection = FbConnection


                FbCommand.CommandText = "SELECT NEXT VALUE FOR GEN_SECURITY_TRANSACTION_ID FROM RDB$DATABASE;"
                TransactionNumber = FbCommand.ExecuteScalar


                FbCommand.CommandText = "SELECT SECURITY_NAME FROM SECURITY_USER WHERE USERNAME = '" & txtuser.Text.ToUpper & "' "
                LoggedUser = FBcommand.ExecuteScalar

                'If LoggedUser = Nothing Then
                '    MsgBox("Username or password is invalid", vbInformation, My.Application.Info.Title.ToString)
                '    FBCommand.Dispose()
                '    'FBRecordset.Close()
                '    Exit Sub
                'End If

                ''START CHECK FOR CURRENT VERSION OF SYSTEM

                'CHECK MAJOR VERSION
                Dim VERSION_NUMBER As Integer
                FBcommand.CommandText = "SELECT VERSION_MAJOR FROM SYSTEM_VERSION ORDER BY VERSION_ID DESC"
                VERSION_NUMBER = FBcommand.ExecuteScalar
                If VERSION_NUMBER = My.Application.Info.Version.Major Then
                Else
                    MsgBox("New updated version found. Please update your current system version.", vbInformation, My.Application.Info.Title.ToString)
                    FBcommand.Dispose()
                    Exit Sub
                End If
                'CHECK MINOR VERSION
                FBcommand.CommandText = "SELECT VERSION_MINOR FROM SYSTEM_VERSION ORDER BY VERSION_ID DESC"
                VERSION_NUMBER = FBcommand.ExecuteScalar
                If VERSION_NUMBER = My.Application.Info.Version.Minor Then
                Else
                    MsgBox("New updated version found. Please update your current system version.", vbInformation, My.Application.Info.Title.ToString)
                    FBcommand.Dispose()
                    Exit Sub
                End If
                'CHECK BUILD VERSION
                FBcommand.CommandText = "SELECT VERSION_build FROM SYSTEM_VERSION ORDER BY VERSION_ID DESC"
                VERSION_NUMBER = FBcommand.ExecuteScalar
                If VERSION_NUMBER = My.Application.Info.Version.Build Then
                Else
                    MsgBox("New updated version found. Please update your current system version.", vbInformation, My.Application.Info.Title.ToString)
                    FBcommand.Dispose()
                    Exit Sub
                End If
                ''END CHECK FOR CURRENT VERSION OF SYSTEM
                Dim hostname As IPHostEntry = Dns.GetHostEntry(System.Net.Dns.GetHostName())
                Dim ip As IPAddress() = hostname.AddressList
                Dim nics() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces
                'Call AuditLog("HOSTNAME:" & System.Net.Dns.GetHostName() & "; IP:" & nics(0).GetIPProperties.ToString & "; PHYADDR:" & nics(0).GetPhysicalAddress.ToString, TransactionNumber, "LOGIN")
                Call AuditLog("HOSTNAME:" & System.Net.Dns.GetHostName() & "; IP:" & System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList(0).ToString() & "; PHYADDR:" & nics(0).GetPhysicalAddress.ToString, TransactionNumber, "LOGIN")
            Catch ex As Exception
                MsgBox(ex.Message)
                'FbConnection.Close()
            Finally
                FBcommand.Dispose()
                FbConnection.Close()
            End Try

            ' ''''CHECK DATABASE AND SYSTEM VERSION AND BUILD
            'Using FBCommand As New Odbc.OdbcCommand


            '    Try
            '        FBCommand.Connection = FBirdConnection
            '        FBCommand.CommandText = "SELECT * FROM SYSVER WHERE SYSVERSION IN (SELECT MAX(SYSVERSION) FROM SYSVER) ORDER BY SYSBUILD DESC"
            '        FBRecordset = FBCommand.ExecuteReader
            '        FBRecordset.Read()
            '        If (My.Application.Info.Version.Major <> FBRecordset!SYSVERSION) Or (My.Application.Info.Version.Build <> FBRecordset!sysbuILD) Then

            '            MsgBox("Please use current version and build. " & vbNewLine & vbNewLine & " Contact your system administrator.", vbInformation, My.Application.Info.Title.ToString)
            '            FBirdConnection.Close()
            '            End
            '        End If

            '        'If FBRecordset.IsClosed = False 
            '    Catch ex As Exception
            '        MsgBox(ex.Message)
            '        FBirdConnection.Close()
            '        End
            '    End Try



            'End Using


            'MDIParent1.Text = "MISO Computer Inventory v" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Build
            PGLU_Doc_Manager.TSDatabase.Text = FirebirdIP.ToString.ToUpper & ":" & FirebirdDbase.ToString.ToUpper
            PGLU_Doc_Manager.TSUser.Text = LoggedUser
            'MdiAbono.TSDatabase.Text = FirebirdDbase
            'Call Security_Menu()

            modFunction.SystemStatus("Update User Privilages")
            Call modSecurity.Security_table(txtuser.Text)   'COPIES ALL SECURITY_PRIVILEGE TO PUBLIC DATATABLE
            modFunction.SystemStatus("Setting User Privilages")
            Call modSecurity.Security_privilege()           'ENABLE/DISABLE CONTROLS AND MENUS BASED ON SECURITY_PRIVILEGE
            modFunction.SystemStatus("Recreating User Privilages")
            Call modSecurity.Build_Security_privilege()     'RECREATE MISSING SECURITY_PRIVILEGE BASED FROM SECURITY_TEMPLATE 
            modFunction.SystemStatus()
            Me.Close()
            frmSplash.Close()
            'FBsql = "SELECT * FROM SCHEDULER WHERE SCHEDULE_DATE BETWEEN '" & MdiAbono.mcSchedule.ActiveMonth.Month & "/" & 1 & "/" & MdiAbono.mcSchedule.ActiveMonth.Year & "' AND '" & DateSerial(MdiAbono.mcSchedule.ActiveMonth.Year, MdiAbono.mcSchedule.ActiveMonth.Month + 1, 0) & "' ORDER BY SCHEDULE_DATE"
            'Call LoadDate(FBsql)

            'FBsql = "SELECT * FROM SCHEDULER WHERE SCHEDULE_DATE BETWEEN '" & MdiAbono.mCalendar.TodayDate.Month & "/" & 1 & "/" & MdiAbono.mCalendar.TodayDate.Year & "' AND '" & DateSerial(MdiAbono.mCalendar.TodayDate.Year, MdiAbono.mCalendar.TodayDate.Month + 1, 0) & "' ORDER BY SCHEDULE_DATE"
            'Call LoadDate(FBsql)
        End If
        Dim builddate As Date = RetrieveLinkerTimestamp(My.Application.Info.DirectoryPath & " \PGLU DOCUMENT ARCHIVING SYSTEM.exe")

        PGLU_Doc_Manager.Text = "DocArch " & modFunction.GetVersion & " bd" & builddate.Year & "." & builddate.Month & "." & builddate.Day


    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        End
    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'MsgBox(My.Application.Info.Version.Major)
        'MsgBox(My.Application.Info.Version.Build)

        'txtuser.Text = "user1"
        'txtpassword.Text = "USER1"
        '
    End Sub

   
   
End Class
