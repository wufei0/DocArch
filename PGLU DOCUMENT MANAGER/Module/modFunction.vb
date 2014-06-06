Imports System.Data.Odbc

Module modFunction
    'FUNCTION TO CREATE GUID TO BE USED FOR PRIMARY KEYS
    'INPUT: NAME OF THE FORM
    'OUTPUT: GENERATED GUID/PRIMARY KEY
    Public Function CreateGuid(ByVal GuidID As String) As String
        CreateGuid = Nothing
        modFunction.SystemStatus("Generating Primary Key")
        Select Case GuidID
            Case "frmColumnGroup"
                CreateGuid = "CGP"
            Case "frmColumnName"
                CreateGuid = "CNM"
            Case "frmDocument"
                CreateGuid = "DOC"
            Case "Attachment"
                CreateGuid = "ATC"
            Case "DocumentFile"
                CreateGuid = "DFL"
        End Select

        CreateGuid = CreateGuid & ":" & System.Guid.NewGuid.ToString()
        modFunction.SystemStatus()
        Return CreateGuid

    End Function

    'FUNCTION TO GET THE PRIMARY KEY USED BY THE TEXT INSIDE/SELECTED COMBOBOX
    'INPUT: SQL STRING 
    'OUTPUT: ID OF THE SELECTED STRING ON COMBOBOX
    Public Function GetIDComboBox(ByVal QueryString As String) As String
        GetIDComboBox = Nothing

        Try
            FbCommand = New OdbcCommand
            Call FBirdConnectionOpen()
            FbCommand.Connection = FbConnection
            FbCommand.CommandText = QueryString
            GetIDComboBox = FbCommand.ExecuteScalar

        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & FbCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
        Finally
            FbConnection.Close()
            FbCommand.Dispose()
        End Try

        Return GetIDComboBox

    End Function

    'FUNCTION TO pOPULATE THE CONTENTS OF COMBOBOX BASED ON THE SQL STRING PASSED
    'INPUT: COMBOBOX NAME, SQL STRING 
    'OUTPUT: DESCRIPTION/TEXT ON COMBOBOX
    Public Sub PopListComboBox(ByVal comboname As ComboBox, ByVal sqlQuery As String)
        Dim FbRecordset As OdbcDataReader
        FbCommand = New OdbcCommand

        comboname.Items.Clear()
        Try
            Call FBirdConnectionOpen()
            FbCommand.Connection = FbConnection
            FbCommand.CommandText = sqlQuery
            FbRecordset = FbCommand.ExecuteReader

            While FbRecordset.Read
                comboname.Items.Add(FbRecordset!GROUP_NAME.ToString)

            End While
            FbRecordset.Close()

        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & FbCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
        Finally
            FbConnection.Close()
            FbCommand.Dispose()

        End Try


    End Sub


    'FUNCTION TO IDENTIFY THE LISTINDEX OF THE COMBOBOX BASED FROM SELECTED SEARCH STRING
    'INPUT: COMBOBOX NAME, SEARCH STRING
    'OUTPUT: NUMBER OF LISTINDEX FROM COMBOBOX
    Public Function ComboListIndetify(ByVal ComboName As ComboBox, ByVal SearchString As String) As Integer
        ComboListIndetify = 0
        ComboName.SelectedIndex = 0

        While ComboName.Items.Count <> ComboListIndetify

            If SearchString = ComboName.Text Then
                Exit While
            End If
            ComboListIndetify = ComboListIndetify + 1
            ComboName.SelectedIndex = ComboListIndetify
        End While




        Return ComboListIndetify
    End Function

    'FUNCTION TO GET/RETRIEVE VALUE BASED ON PASSED SQL
    'INPUT: SQL STRING
    'OUTPUT: DATA BASED ON PASSED SQL
    Public Function SQLScalar(ByVal SQLstring As String) As String
        SQLScalar = Nothing
        Try
            Call FBirdConnectionOpen()
            FbCommand = New OdbcCommand
            FbCommand.Connection = FbConnection
            FbCommand.CommandText = SQLstring
            SQLScalar = FbCommand.ExecuteScalar
            FbConnection.Close()
        Catch ex As Exception

        Finally
            FbCommand.Dispose()

        End Try


        Return SQLScalar
    End Function

    'delete temporary pdf file on TEMP folder
    'INPUT: PATH OF THE TEMPORARY FILE
    'OUTPUT: N/A
    Public Sub Delete_Temp(ByVal Filepath As String)
        'For countX = 0 To 100
        '    directory = directory & countX & ".pdf"

        If System.IO.File.Exists(Filepath) = True Then
            System.IO.File.Delete(Filepath)
        End If

        'Next
    End Sub

    'PROCEDURE TO SHOW STATUS ON STATUS STRIP
    'INPUT: STATUS TEXT/STRING
    'OUTPUT: N/A
    Public Sub SystemStatus(Optional ByVal StatusText As String = Nothing)

        Application.DoEvents()
        PGLU_Doc_Manager.tsStatus.Text = StatusText


    End Sub
    'FUNCTION TO RETRIEVE SYSTEM VERSION AND BUILD DATE
    'INPUT: N/A
    'OUTPUT: SYSTEM VERSION AND BUILD DATE
    Public Function GetVersion() As String
        Dim fbreader As Odbc.OdbcDataReader = Nothing

        Try
            FbCommand = New Odbc.OdbcCommand
            Call modConnection.FBirdConnectionOpen()
            FbCommand.Connection = FbConnection
            FbCommand.CommandText = "SELECT FIRST 1 VERSION_MAJOR,VERSION_MINOR,VERSION_BUILD,TRANSDATE FROM SYSTEM_VERSION ORDER BY VERSION_ID DESC"
            fbreader = FbCommand.ExecuteReader
            fbreader.Read()
            Dim buildDate As Date = fbreader!TRANSDATE

            GetVersion = "v" & fbreader!VERSION_MAJOR.ToString() & "." & fbreader!VERSION_MINOR.ToString() & "." & fbreader!VERSION_BUILD.ToString() & " bd." & buildDate.Year & "." & buildDate.Month & "." & buildDate.Day
            fbreader.Close()
        Catch ex As Exception
            GetVersion = Nothing
        Finally
            FbCommand.Dispose()

            FbConnection.Close()
        End Try

        Return GetVersion
    End Function
End Module
