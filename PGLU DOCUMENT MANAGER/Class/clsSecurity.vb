Imports System.Data.Odbc

Public Class clsSecurity

#Region "frmSecurityGroup"
    'BUTTONS START
    Public Sub NewSecurity(ByVal NewObject As String)
        With frmSecurityGroup

            Select Case NewObject

                Case "USER"
                    .txtFullName.Text = Nothing
                    .txtUserName.Text = Nothing
                    .lblid.Text = Nothing

                    .txtFullName.Enabled = True
                    .txtUserName.Enabled = True
                    .cboUserGroup.Enabled = True
                    .btnDelete.Enabled = False
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True
                    Call InsertcboGroup("frmSecurityGroup")

                Case "GROUP"
                    .txtGroup.Text = Nothing
                    .txtGroupDescription.Text = Nothing
                    .lblGroupID.Text = Nothing

                    .txtGroup.Enabled = True
                    .txtGroupDescription.Enabled = True
                    .btnDelete.Enabled = False
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True
            End Select

        End With

    End Sub

    Public Sub EditSecurity(ByVal EditObject As String)
        With frmSecurityGroup
            Select Case EditObject

                Case "USER"
                    .txtFullName.Enabled = True
                    .txtUserName.Enabled = True
                    .cboUserGroup.Enabled = True
                    .btnDelete.Enabled = True
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True
                Case "GROUP"
                    .txtGroup.Enabled = False
                    .txtGroupDescription.Enabled = True
                    .btnDelete.Enabled = True
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True
            End Select
        End With
    End Sub

    Public Sub SaveSecurity(ByVal SaveObject As String)
        With frmSecurityGroup
            Select Case SaveObject

                Case "USER"
                    .txtFullName.Enabled = False
                    .txtUserName.Enabled = False
                    .cboUserGroup.Enabled = False
                    .btnDelete.Enabled = False
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False
                Case "GROUP"
                    .txtGroup.Enabled = False
                    .txtGroupDescription.Enabled = False
                    .btnDelete.Enabled = False
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False
            End Select
        End With
    End Sub

    Public Sub DeleteSecurity(ByVal DeleteObject As String)
        With frmSecurityGroup
            Select Case DeleteObject

                Case "USER"
                    .txtFullName.Text = Nothing
                    .txtUserName.Text = Nothing
                    .lblid.Text = Nothing

                    .txtFullName.Enabled = False
                    .txtUserName.Enabled = False
                    .cboUserGroup.Enabled = False
                    Call InsertcboGroup("frmSecurityGroup")
                    .btnDelete.Enabled = False
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False

                Case "GROUP"
                    .txtGroup.Text = Nothing
                    .txtGroupDescription.Text = Nothing
                    .lblGroupID.Text = Nothing

                    .txtGroup.Enabled = False
                    .txtGroupDescription.Enabled = False
                    .btnDelete.Enabled = False
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False
            End Select
        End With
    End Sub
    'BUTTONS END

    Public Sub SaveUser(ByVal SaveObject As String)
        Dim FBtransaction As OdbcTransaction = Nothing
        'Dim FBreader As OdbcDataReader
        With frmSecurityGroup
            Try
                Call FBirdConnectionOpen()
                FbCommand.Connection = FbConnection
                FBtransaction = FbConnection.BeginTransaction
                FbCommand.Transaction = FBtransaction

                FbCommand.CommandText = "SELECT NEXT VALUE FOR GEN_SECURITY_TRANSACTION_ID FROM RDB$DATABASE;"
                TransactionNumber = FbCommand.ExecuteScalar


                Select Case SaveObject

                    Case "USER"
                        If .lblid.Text = Nothing Then
                    

                            FbCommand.Parameters.Clear()
                            FbCommand.CommandText = "INSERT INTO SECURITY_USER(SECURITY_NAME,USERNAME,FK_SECURITY_GROUP) VALUES(?,?,?)"
                            FbCommand.Parameters.AddWithValue("@SECURITY_NAME", .txtFullName.Text)
                            FbCommand.Parameters.AddWithValue("@USERNAME", .txtUserName.Text)
                            FbCommand.Parameters.AddWithValue("@FK_SECURITY_GROUP", .cboUserGroup.Text)
                            FbCommand.ExecuteNonQuery()

                        Else
                            FbCommand.CommandText = "UPDATE SECURITY_USER SET SECURITY_NAME = '" & .txtFullName.Text & "', USERNAME = '" & .txtUserName.Text & "', FK_SECURITY_GROUP = '" & .cboUserGroup.Text & "' WHERE SECURITY_USER_ID = " & .lblid.Text & " "
                            FbCommand.ExecuteNonQuery()
                            .lblid.Text = "SAVED"
                        End If
                        Call AuditLog(FbCommand.CommandText.ToString, TransactionNumber, "UPDATE")

                        MsgBox("User Saved Successfully.", vbInformation, My.Application.Info.Title.ToString)

                    Case "GROUP"
                        Dim xDatatable As New DataTable("SECURITY_TEMPLATE")
                        Dim FBadapter As New OdbcDataAdapter("SELECT WINDOW,CONTROL,DESCRIPTION,CONTROLTYPE FROM SECURITY_TEMPLATE", FbConnection)

                        'FBadapter.InsertCommand.Transaction = FBtransaction
                        FBadapter.SelectCommand.Transaction = FBtransaction
                        FBadapter.Fill(xDatatable)

                        If .txtGroup.Enabled = True Then
                           


                            FbCommand.CommandText = "INSERT INTO SECURITY_GROUP VALUES('" & .txtGroup.Text & "','" & .txtGroupDescription.Text & "') "
                            FbCommand.ExecuteNonQuery()
                            Call AuditLog(FbCommand.CommandText.ToString, TransactionNumber, "INSERT")

                            For Each xRows As DataRow In xDatatable.Rows
                                FbCommand.CommandText = "INSERT INTO SECURITY_PRIVILEGES(WINDOW,CONTROL,DESCRIPTION,CONTROLTYPE,STATUS,FK_SECURITY_GROUP) VALUES ('" & xRows(0) & "','" & xRows(1) & "','" & xRows(2) & "','" & xRows(3) & "',0,'" & .txtGroup.Text & "') "
                                FbCommand.ExecuteNonQuery()
                                Call AuditLog(FbCommand.CommandText.ToString, TransactionNumber, "INSERT")
                            Next

                            FBadapter.Dispose()
                        Else
                            FbCommand.CommandText = "UPDATE SECURITY_GROUP SET DESCRIPTION = '" & .txtGroupDescription.Text & "' WHERE SECURITY_GROUP = '" & .txtGroup.Text & "'"
                            FbCommand.ExecuteNonQuery()
                            Call AuditLog(FbCommand.CommandText.ToString, TransactionNumber, "UPDATE")

                        End If
                        .lblGroupID.Text = "SAVED"
                        MsgBox("Group Saved Successfully.", vbInformation, My.Application.Info.Title.ToString)
                End Select


                FBtransaction.Commit()
            Catch ex As Exception

                If ex.Message.Contains("UNQ_SECURITY_USER_0") Then
                    MsgBox("User " & .txtUserName.Text.ToUpper & " already exist.", vbCritical + vbOKOnly, My.Application.Info.Title.ToString)
                ElseIf ex.Message.Contains("PK_SECURITY_GROUP_0") Then
                    MsgBox("Group " & .txtGroup.Text.ToUpper & " already exist.", vbCritical + vbOKOnly, My.Application.Info.Title.ToString)
                Else
                    MsgBox(ex.Message & vbNewLine & vbNewLine & FbCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
                End If



                FBtransaction.Rollback()
            Finally

                FbCommand.Dispose()
                FbConnection.Close()
                FBtransaction.Dispose()
            End Try
        End With
    End Sub

    Public Sub DeleteUser(ByVal UserObject As String)
        With frmSecurityGroup
            Try
                Call FBirdConnectionOpen()
                FbCommand.Connection = FbConnection
                FbCommand.CommandText = "SELECT NEXT VALUE FOR GEN_SECURITY_TRANSACTION_ID FROM RDB$DATABASE;"
                TransactionNumber = FbCommand.ExecuteScalar

                Select Case UserObject
                    Case "USER"
                        FbCommand.CommandText = "DELETE FROM SECURITY_USER WHERE SECURITY_USER_ID = " & .lblid.Text & ""
                        FbCommand.ExecuteNonQuery()
                    Case "GROUP"
                        FbCommand.CommandText = "DELETE FROM SECURITY_GROUP WHERE SECURITY_GROUP = '" & .txtGroup.Text & "' "
                        FbCommand.ExecuteNonQuery()
                End Select

                Call AuditLog(FbCommand.CommandText.ToString, TransactionNumber, "DELETE")

                MsgBox("Delete successful", vbInformation, My.Application.Info.Title.ToString)

            Catch ex As Exception
                If ex.Message.Contains("FK_SECURITY_USER_0") Then
                    MsgBox("Group " & .txtGroup.Text.ToUpper & " is still in use. Delete first the user/s that " & vbCrLf & " belonged to this group.", vbCritical + vbOKOnly, My.Application.Info.Title.ToString)
                Else
                    MsgBox(ex.Message & vbNewLine & vbNewLine & FbCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
                End If


            Finally
                FbCommand.Dispose()
                FbConnection.Close()
            End Try

        End With
    End Sub

    Public Sub RefreshListView(ByVal ListViewOption As String)
        Dim FbRecordset As OdbcDataReader = Nothing
        Dim LVitem As ListViewItem
        With frmSecurityGroup

            Try
                .lstSecurity.Items.Clear()
                .lstSecurity.Columns.Clear()
                Call FBirdConnectionOpen()
                FbCommand = New OdbcCommand
                FbCommand.Connection = FbConnection

                Select Case ListViewOption

                    Case "USER"
                        .lstSecurity.Columns.Add("ID")
                        .lstSecurity.Columns.Add("Full Name")
                        .lstSecurity.Columns.Add("User Name")
                        .lstSecurity.Columns.Add("Group")

                        .lstSecurity.Columns(0).Width = 1
                        .lstSecurity.Columns(1).Width = 140
                        .lstSecurity.Columns(2).Width = 100
                        .lstSecurity.Columns(3).Width = 130

                        FbCommand.CommandText = "SELECT * FROM SECURITY_USER ORDER BY SECURITY_NAME ASC"
                        FbRecordset = FbCommand.ExecuteReader
                        While FbRecordset.Read
                            LVitem = New ListViewItem(FbRecordset!SECURITY_USER_ID.ToString)
                            LVitem.SubItems.Add(FbRecordset!SECURITY_NAME.ToString)
                            LVitem.SubItems.Add(FbRecordset!USERNAME.ToString)
                            LVitem.SubItems.Add(FbRecordset!FK_SECURITY_GROUP.ToString)
                            .lstSecurity.Items.Add(LVitem)
                        End While
                    Case "GROUP"
                        .lstSecurity.Columns.Add("Group")
                        .lstSecurity.Columns.Add("Description")

                        .lstSecurity.Columns(0).Width = 150
                        .lstSecurity.Columns(1).Width = 190

                        FbCommand.CommandText = "SELECT * FROM SECURITY_GROUP ORDER BY SECURITY_GROUP ASC"
                        FbRecordset = FbCommand.ExecuteReader
                        While FbRecordset.Read
                            LVitem = New ListViewItem(FbRecordset!SECURITY_GROUP.ToString)
                            LVitem.SubItems.Add(FbRecordset!DESCRIPTION.ToString)

                            .lstSecurity.Items.Add(LVitem)
                        End While
                End Select

            Catch ex As Exception
                MsgBox(ex.Message & vbNewLine & vbNewLine & FbCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
            Finally
                FbRecordset.Close()
                FbCommand.Dispose()
                FbConnection.Close()
            End Try

        End With
    End Sub


#End Region

    Public Sub InsertcboGroup(ByVal FormName As String)
        Dim FBrecordset As OdbcDataReader = Nothing





        Try
            Call FBirdConnectionOpen()
            FbCommand = New OdbcCommand
            FbCommand.Connection = FbConnection
            FbCommand.CommandText = "SELECT SECURITY_GROUP FROM SECURITY_GROUP ORDER BY SECURITY_GROUP ASC"
            FBrecordset = FbCommand.ExecuteReader


            Select Case FormName

                Case "frmSecurityGroup"
                    With frmSecurityGroup
                        .cboUserGroup.Items.Clear()
                        While FBrecordset.Read
                            .cboUserGroup.Items.Add(FBrecordset!SECURITY_GROUP)
                        End While
                    End With
                Case "frmSecurityPrivilege"
                    With frmSecurityPrivilege
                        .cboGroupName.Items.Clear()
                        While FBrecordset.Read
                            .cboGroupName.Items.Add(FBrecordset!SECURITY_GROUP)
                        End While
                    End With
            End Select


        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & FbCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)

        Finally
            FbConnection.Close()
            FBrecordset.Close()
            FbCommand.Dispose()
        End Try




    End Sub

#Region "frmSecurityPrivilege"

    Public Sub RefreshSecurityPrivilegeList(ByVal sqlcommand As String)
        Dim FbRecordset As OdbcDataReader = Nothing
        Dim lviTEM As ListViewItem
        frmSecurityPrivilege.lstPrivilege.Items.Clear()
        Try
            Call FBirdConnectionOpen()
            FbCommand = New OdbcCommand
            FbCommand.Connection = FbConnection

            'FbCommand.CommandText = "SELECT * FROM SECURITY_PRIVILEGES ORDER BY SECURITY_PRIVILEGE_ID ASC "
            FbCommand.CommandText = sqlcommand
            FbRecordset = FbCommand.ExecuteReader
            While FbRecordset.Read

                lviTEM = New ListViewItem("")
                If FbRecordset!STATUS = 1 Then
                    lviTEM.Checked = True
                Else
                    lviTEM.Checked = False
                End If
                lviTEM.SubItems.Add(FbRecordset!SECURITY_PRIVILEGE_ID)
                lviTEM.SubItems.Add(FbRecordset!WINDOW)
                lviTEM.SubItems.Add(FbRecordset!CONTROL)
                lviTEM.SubItems.Add(FbRecordset!CONTROLTYPE)
                lviTEM.SubItems.Add(FbRecordset!DESCRIPTION)
                frmSecurityPrivilege.lstPrivilege.Items.Add(lviTEM)
            End While

        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & FbCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
        Finally
            FbRecordset.Close()
            FbCommand.Dispose()
            FbConnection.Close()
        End Try
    End Sub


    Public Sub SavePrivilege()
        Dim FBtransaction As OdbcTransaction = Nothing
        Try
            Call FBirdConnectionOpen()
            FbCommand = New OdbcCommand
            FbCommand.Connection = FbConnection
            FBtransaction = FbConnection.BeginTransaction
            FbCommand.Transaction = FBtransaction


            FbCommand.CommandText = "SELECT NEXT VALUE FOR GEN_SECURITY_TRANSACTION_ID FROM RDB$DATABASE;"
            TransactionNumber = FbCommand.ExecuteScalar

            For Each item As ListViewItem In frmSecurityPrivilege.lstPrivilege.Items
                If item.Checked = True Then
                    FbSql = "UPDATE SECURITY_PRIVILEGES SET STATUS = 1 WHERE SECURITY_PRIVILEGE_ID = " & item.SubItems(1).Text & " "
                ElseIf item.Checked = False Then
                    FbSql = "UPDATE SECURITY_PRIVILEGES SET STATUS = 0 WHERE SECURITY_PRIVILEGE_ID = " & item.SubItems(1).Text & " "
                End If

                FbCommand.CommandText = FbSql
                FbCommand.ExecuteNonQuery()
                Call AuditLog(FbCommand.CommandText.ToString, TransactionNumber, "UPDATE")
            Next

            FBtransaction.Commit()
            MsgBox("Privilege Updated Successfully.", vbInformation, My.Application.Info.Title.ToString)
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & FbCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
            FBtransaction.Rollback()
        Finally
            FBtransaction.Dispose()
            FbCommand.Dispose()
            FbConnection.Close()
        End Try
    End Sub

#End Region
End Class
