Imports System.Data.Odbc
Public Class clsLog
    Public Sub SearchLog(ByVal SQLstatement As String, ByVal ListviewControl As ListView) ', ByVal TransactionCode As Integer, ByVal DataManipulationLanguage As String)

        Dim Fbreader As OdbcDataReader = Nothing
        Dim Lvitem As ListViewItem
        Dim DUPCHECK As Integer = 0
        With frmLog

            Try
                Call FBirdConnectionOpen()
                FbCommand = New OdbcCommand
                FbCommand.Connection = FbConnection
                FbCommand.CommandText = SQLstatement
                Fbreader = FbCommand.ExecuteReader

                While Fbreader.Read
                    If ListviewControl.Name = "lstSearch" Then
                        If Fbreader!transaction_id <> DUPCHECK Then
                            Lvitem = New ListViewItem(Fbreader!SECURITY_AUDIT_ID.ToString)
                            Lvitem.SubItems.Add(Fbreader!transaction_ID.ToString)
                            Lvitem.SubItems.Add(Fbreader!security_user.ToString)
                            Lvitem.SubItems.Add(Fbreader!transdate.ToString)
                            Lvitem.SubItems.Add(Fbreader!dml.ToString)
                            .lstSearch.Items.Add(Lvitem)
                            DUPCHECK = Fbreader!transaction_id
                        End If
                    ElseIf ListviewControl.Name = "lstLog" Then
                        Lvitem = New ListViewItem(Fbreader!SECURITY_AUDIT_ID.ToString)
                        Lvitem.SubItems.Add(Fbreader!transaction_ID.ToString)
                        Lvitem.SubItems.Add(Fbreader!dml.ToString)
                        Lvitem.SubItems.Add(Fbreader!sql_statement.ToString)
                        Lvitem.SubItems.Add(Fbreader!transdate.ToString)
                        Lvitem.SubItems.Add(Fbreader!security_user.ToString)
                        .lstLog.Items.Add(Lvitem)
                    End If
                End While

            Catch ex As Exception

                'MsgBox(ex.Message)
            Finally

                Fbreader.Close()
                FbCommand.Dispose()
                FbConnection.Close()
            End Try

        End With

    End Sub



End Class
