Imports System.Data.Odbc

Public Class clsGroupPrivilege

    Public Sub ListviewRefresh(ByVal ListviewName As String)
        Dim FBrecordset As OdbcDataReader = Nothing
        Dim lvitem As ListViewItem
        With frmSecurityDocument

            Try
                Call FBirdConnectionOpen()
                FbCommand = New OdbcCommand
                FbCommand.Connection = FbConnection

                'X'''''''''''''''''''''''''''''''''''''''''''''''''
                Select Case ListviewName

                    Case "SECURITY_GROUP"
                        .lstSecurityGroup.Items.Clear()
                        FbSql = "SELECT * FROM SECURITY_GROUP ORDER BY SECURITY_GROUP"
                        FbCommand.CommandText = FbSql
                        FBrecordset = FbCommand.ExecuteReader
                        While FBrecordset.Read
                            lvitem = New ListViewItem(FBrecordset!SECURITY_GROUP.ToString)
                            lvitem.SubItems.Add(FBrecordset!DESCRIPTION.ToString)
                            .lstSecurityGroup.Items.Add(lvitem)
                        End While

                    Case "COLUMN_GROUP"
                        .lstColumnGroup.Items.Clear()
                        FbSql = "SELECT * FROM S_COLUMNGROUP ORDER BY GROUP_NAME"
                        FbCommand.CommandText = FbSql
                        FBrecordset = FbCommand.ExecuteReader
                        While FBrecordset.Read
                            lvitem = New ListViewItem(FBrecordset!COLUMNGROUP_ID.ToString)
                            lvitem.SubItems.Add(FBrecordset!GROUP_NAME.ToString)
                            lvitem.SubItems.Add(FBrecordset!DESCRIPTION.ToString)
                            .lstColumnGroup.Items.Add(lvitem)
                        End While

                    Case "GROUP_PRIVILEGE"
                        'SELECT * FROM SECURITY_GROUP JOIN L_COLUMNSECURITY ON SECURITY_GROUP.SECURITY_GROUP=L_COLUMNSECURITY.FK_SECURITY_GROUP JOIN
                        'S_COLUMNGROUP ON L_COLUMNSECURITY.FK_COLUMNGROUP_ID = S_COLUMNGROUP.COLUMNGROUP_ID

                        .lstGroupPrivilege.Items.Clear()
                        FbSql = "SELECT COLUMNSECURITY_ID,SECURITY_GROUP,SECURITY_GROUP.DESCRIPTION AS S_DESCRIPTION,GROUP_NAME,S_COLUMNGROUP.DESCRIPTION AS C_DESC FROM SECURITY_GROUP JOIN L_COLUMNSECURITY ON SECURITY_GROUP.SECURITY_GROUP=L_COLUMNSECURITY.FK_SECURITY_GROUP JOIN S_COLUMNGROUP ON L_COLUMNSECURITY.FK_COLUMNGROUP_ID = S_COLUMNGROUP.COLUMNGROUP_ID"
                        FbCommand.CommandText = FbSql
                        FBrecordset = FbCommand.ExecuteReader
                        While FBrecordset.Read
                            lvitem = New ListViewItem(FBrecordset!COLUMNSECURITY_ID.ToString)
                            lvitem.SubItems.Add(FBrecordset!SECURITY_GROUP.ToString)
                            lvitem.SubItems.Add(FBrecordset!S_DESCRIPTION.ToString)
                            lvitem.SubItems.Add(FBrecordset!GROUP_NAME.ToString)
                            lvitem.SubItems.Add(FBrecordset!C_DESC.ToString)
                            .lstGroupPrivilege.Items.Add(lvitem)
                        End While

                End Select
                ''''''''''''''''''''''''''''''''''''''''''''''''''X
            Catch ex As Exception
                MsgBox(ex.Message & vbNewLine & vbNewLine & FbCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
            Finally
                FbCommand.Dispose()
                FbConnection.Close()
                Try
                    FBrecordset.Close()
                Catch ex As Exception

                End Try
            End Try






        End With
    End Sub

    Public Sub PrivilegeSave()
        'Dim FBrecordset As OdbcDataReader
        Dim FBtransaction As OdbcTransaction = Nothing

        With frmSecurityDocument


            Try
                Call FBirdConnectionOpen()
                FbCommand = New OdbcCommand
                FbCommand.Connection = FbConnection
                FBtransaction = FbConnection.BeginTransaction
                FbCommand.Transaction = FBtransaction

                FbCommand.CommandText = "SELECT NEXT VALUE FOR GEN_SECURITY_TRANSACTION_ID FROM RDB$DATABASE;"
                TransactionNumber = FbCommand.ExecuteScalar

                For Each item As ListViewItem In .lstSecurityGroup.CheckedItems

                    For Each itemb As ListViewItem In .lstColumnGroup.CheckedItems
                        Try
                       
                            FbCommand.CommandText = "INSERT INTO L_COLUMNSECURITY(FK_SECURITY_GROUP,FK_COLUMNGROUP_ID,SECURITY_USER) VALUES ('" & item.Text & "','" & itemb.Text & "','" & LoggedUser & "') "
                            FbCommand.ExecuteNonQuery()

                          
                            Call AuditLog(FbCommand.CommandText.ToString, TransactionNumber, "INSERT")
                        Catch ex As Exception
                            If ex.Message.Contains("ERROR [23000]") = True Then
                                Beep()
                            Else
                                MsgBox(ex.Message & vbNewLine & vbNewLine & FbCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)

                            End If

                        End Try
                    Next

                Next


                FBtransaction.Commit()
                MsgBox("Group Saved Successfully.", vbInformation, My.Application.Info.Title.ToString)
            Catch ex As Exception
                MsgBox(ex.Message & vbNewLine & vbNewLine & FbCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
                FBtransaction.Rollback()

            Finally
                FbCommand.Dispose()
                FbConnection.Close()
                FBtransaction.Dispose()
            End Try

        End With

    End Sub


    Public Sub PrivilegeDelete()
        Dim FBtransaction As OdbcTransaction = Nothing
        With frmSecurityDocument

            Try
                Call FBirdConnectionOpen()
                FbCommand = New OdbcCommand
                FbCommand.Connection = FbConnection
                FBtransaction = FbConnection.BeginTransaction
                FbCommand.Transaction = FBtransaction


                FbCommand.CommandText = "SELECT NEXT VALUE FOR GEN_SECURITY_TRANSACTION_ID FROM RDB$DATABASE;"
                TransactionNumber = FbCommand.ExecuteScalar

                For Each ITEM As ListViewItem In .lstGroupPrivilege.SelectedItems

                    FbCommand.CommandText = "DELETE FROM L_COLUMNSECURITY WHERE COLUMNSECURITY_ID = '" & ITEM.Text & "'"
                    FbCommand.ExecuteNonQuery()
                    Call AuditLog(FbCommand.CommandText.ToString, TransactionNumber, "DELETE")
                Next




                FBtransaction.Commit()
                MsgBox("Delete successful", vbInformation, My.Application.Info.Title.ToString)
            Catch ex As Exception
                MsgBox(ex.Message & vbNewLine & vbNewLine & FbCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
                FBtransaction.Rollback()
            Finally
                FbCommand.Dispose()
                FbConnection.Close()
                FBtransaction.Dispose()
            End Try


        End With
    End Sub

End Class
