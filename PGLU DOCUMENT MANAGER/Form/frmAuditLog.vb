Imports System.Data.Odbc

Public Class frmAuditLog

    Private Sub frmAuditLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PGLU_Doc_Manager
        txtRealeaseNote.ReadOnly = True
        Call Me.AddAuditLog()


    End Sub


    Private Sub AddAuditLog()
        'Dim FbAdapter As OdbcDataAdapter = Nothing
        'Dim AuditDataTable As New DataTable
        Dim FbReader As Odbc.OdbcDataReader = Nothing
        Dim Fbcommand2 As Odbc.OdbcCommand
        Dim FbReader2 As Odbc.OdbcDataReader = Nothing
        Try
            Call FBirdConnectionOpen()
            'FbAdapter = New OdbcDataAdapter("SELECT * FROM SYSTEM_VERSION", FbConnection)
            'FbAdapter.Fill(AuditDataTable)
            'dgAudit.DataSource = AuditDataTable
            FbCommand = New OdbcCommand
            FbCommand.Connection = FbConnection

           
            'FbCommand.CommandText = "SELECT VERSION_MAJOR, VERSION_MINOR,VERSION_BUILD,FIX TRANSDATE FROM SYSTEM_VERSION JOIN SYSTEM_VERSION_FIX ON SYSTEM_VERSION.VERSION_ID" _
            '& "= SYSTEM_VERSION_FIX.VERSION_ID ORDER BY TRANSDATE  DESC"
            FbCommand.CommandText = "SELECT * FROM SYSTEM_VERSION ORDER BY TRANSDATE DESC"
            FbReader = FbCommand.ExecuteReader
            Dim bdate As Date

            While FbReader.Read
                bdate = FbReader!transdate
                txtRealeaseNote.AppendText(FbReader!VERSION_MAJOR.ToString & "." & FbReader!VERSION_MINOR.ToString & "." & FbReader!VERSION_BUILD.ToString & " bd" & bdate.Year & "." & bdate.Month & "." & bdate.Day)
                Fbcommand2 = New OdbcCommand
                Fbcommand2.Connection = FbConnection
                Fbcommand2.CommandText = "SELECT FIX FROM SYSTEM_VERSION_FIX WHERE VERSION_ID = " & FbReader!VERSION_ID
                FbReader2 = Fbcommand2.ExecuteReader
                While FbReader2.Read
                    'If FbReader2!RecCount > 1 Then
                    txtRealeaseNote.AppendText(vbNewLine)
                    txtRealeaseNote.AppendText("   ∙" & FbReader2!FIX.ToString)
                    'Else
                    'txtRealeaseNote.AppendText("             ∙" & FbReader2!FIX.ToString)
                    'End If


                End While
                FbReader2.Close()
                txtRealeaseNote.AppendText(vbNewLine)
                txtRealeaseNote.AppendText(vbNewLine)
            End While


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            'FbAdapter.Dispose()
            FbCommand.Dispose()
            FbReader.Close()

            Fbcommand2.Dispose()
            FbReader2.Close()

            FbConnection.Close()
        End Try

    End Sub

    Private Sub frmAuditLog_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'dgAudit.Width = Me.Width - 42
        'dgAudit.Height = Me.Height - 60
        'dgAudit.Top = 12

        txtRealeaseNote.Width = Me.Width - 40
        txtRealeaseNote.Height = Me.Height - 108

        btnClose.Left = Me.Width - 103
        btnClose.Top = Me.Height - 73
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class