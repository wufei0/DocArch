Imports System.Data.Odbc

Public Class frmAuditLog

    Private Sub frmAuditLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PGLU_Doc_Manager

        Call Me.AddAuditLog()


    End Sub


    Private Sub AddAuditLog()
        Dim FbAdapter As OdbcDataAdapter = Nothing
        Dim AuditDataTable As New DataTable

        Try
            Call FBirdConnectionOpen()
            FbAdapter = New OdbcDataAdapter("SELECT * FROM SYSTEM_VERSION", FbConnection)
            FbAdapter.Fill(AuditDataTable)
            dgAudit.DataSource = AuditDataTable
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FbAdapter.Dispose()
            FbConnection.Close()
        End Try

    End Sub

    Private Sub frmAuditLog_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        dgAudit.Width = Me.Width - 42
        dgAudit.Height = Me.Height - 60
        'dgAudit.Top = 12

    End Sub
End Class