Imports System.Data.Odbc


Module modSecurity

    Public Sub Security_table(ByVal Security_user As String)



        Try
            Call modConnection.FBirdConnectionOpen()
            FbSql = "SELECT * FROM SECURITY_USER JOIN SECURITY_GROUP ON SECURITY_USER.FK_SECURITY_GROUP = SECURITY_GROUP.SECURITY_GROUP JOIN"
            FbSql = FbSql & " SECURITY_PRIVILEGES ON SECURITY_GROUP.SECURITY_GROUP = SECURITY_PRIVILEGES.FK_SECURITY_GROUP WHERE SECURITY_USER.USERNAME = '" & Security_user & "' "
            Dim FBirdadapter As New OdbcDataAdapter(FbSql, FbConnection)


            FBirdadapter.Fill(SecurityDataTable)

        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & FbCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
        Finally


            FbConnection.Close()
        End Try



    End Sub


    Public Sub Security_privilege()
        'Dim FBrecordset As OdbcDataReader

        'Dim sqlstring As String
        Try
            'Call FBirdConnectionOpen()
            'FbCommand = New OdbcCommand
            'FbCommand.Connection = FbConnection


            'sqlstring = "SELECT * FROM SECURITY_USER JOIN SECURITY_GROUP ON SECURITY_USER.FK_SECURITY_GROUP = SECURITY_GROUP.SECURITY_GROUP JOIN"
            'sqlstring = sqlstring & " SECURITY_PRIVILEGES ON SECURITY_GROUP.SECURITY_GROUP = SECURITY_PRIVILEGES.FK_SECURITY_GROUP WHERE SECURITY_USER.USERNAME = '" & securityname & "' "


            'FbCommand.CommandText = sqlstring
            'FBrecordset = FbCommand.ExecuteReader

            For Each xrow As DataRow In SecurityDataTable.Rows


                Security_Group = xrow(4).ToString  ' GET/SET THE GROUP FOR ACCESS GLOBALLY
                Select Case xrow(7).ToString.ToUpper
                    Case "FRMDOCUMENT"

                        Dim ctl As Control = frmDocument.GetNextControl(frmDocument, True)

                        Do Until ctl Is Nothing
                  
                            If ctl.Name.ToUpper = xrow(8).ToString.ToUpper Then
                                If xrow(10) = 1 Then
                                    ctl.Visible = True
                                Else
                                    ctl.Visible = False
                                End If

                            End If
                            ctl = frmDocument.GetNextControl(ctl, True)

                        Loop




                        'CONTEXT MENUS
                        If xrow(9).ToString.ToUpper = "CONTEXTMENU" Then

                            If xrow(8).ToString.ToUpper = "CMSHISTORY_PREVIEW" Then

                                If xrow(10) = 1 Then
                                    frmDocument.cmsHistory_Preview.Visible = True
                                Else
                                    frmDocument.cmsHistory_Preview.Visible = False
                                End If

                            ElseIf xrow(8).ToString.ToUpper = "CMSATTACHMENT_ADD" Then

                                If xrow(10) = 1 Then
                                    frmDocument.cmsAttachment_Add.Visible = True
                                Else
                                    frmDocument.cmsAttachment_Add.Visible = False
                                End If


                            ElseIf xrow(8).ToString.ToUpper = "CMSATTACHMENT_DOWNLOAD" Then

                                If xrow(10) = 1 Then
                                    frmDocument.cmsAttachment_Download.Visible = True
                                Else
                                    frmDocument.cmsAttachment_Download.Visible = False
                                End If

                            ElseIf xrow(8).ToString.ToUpper = "CMSATTACHMENT_REMOVE" Then

                                If xrow(10) = 1 Then
                                    frmDocument.cmsAttachment_Remove.Visible = True
                                Else
                                    frmDocument.cmsAttachment_Remove.Visible = False
                                End If

                            ElseIf xrow(8).ToString.ToUpper = "CMSINDEX_INSERT" Then

                                If xrow(10) = 1 Then
                                    frmDocument.cmsIndex_Insert.Visible = True
                                Else
                                    frmDocument.cmsIndex_Insert.Visible = False
                                End If


                            ElseIf xrow(8).ToString.ToUpper = "CMSINDEX_DELETE" Then

                                If xrow(10) = 1 Then
                                    frmDocument.cmsIndex_Delete.Visible = True
                                Else
                                    frmDocument.cmsIndex_Delete.Visible = False
                                End If


                            End If
                        End If





                    Case "PGLU_DOC_MANAGER"
                        Dim ctl As Control = PGLU_Doc_Manager.GetNextControl(PGLU_Doc_Manager, True)

                        Do Until ctl Is Nothing

                            If ctl.Name.ToUpper = xrow(8).ToString.ToUpper Then
                                If xrow(10) = 1 Then
                                    ctl.Visible = True
                                Else
                                    ctl.Visible = False
                                End If

                            End If
                            ctl = PGLU_Doc_Manager.GetNextControl(ctl, True)

                        Loop


                        If xrow(9).ToString.ToUpper = "MENUITEM" Then

                            If xrow(8).ToString.ToUpper = "MNUDOCUMENT" Then
                                If xrow(10) = 1 Then
                                    PGLU_Doc_Manager.MnuDocument.Visible = True
                                Else
                                    PGLU_Doc_Manager.MnuDocument.Visible = False
                                End If


                            ElseIf xrow(8).ToString.ToUpper = "MNUDOCUMENT_NEWDOCUMENT" Then
                                If xrow(10) = 1 Then
                                    PGLU_Doc_Manager.mnuDocument_NewDocument.Visible = True
                                Else
                                    PGLU_Doc_Manager.mnuDocument_NewDocument.Visible = False
                                End If

                            ElseIf xrow(8).ToString.ToUpper = "MNUMAINTENANCE" Then
                                If xrow(10) = 1 Then
                                    PGLU_Doc_Manager.mnuMaintenance.Visible = True
                                Else
                                    PGLU_Doc_Manager.mnuMaintenance.Visible = False
                                End If

                            ElseIf xrow(8).ToString.ToUpper = "MNUMAINTENANCE_INDEX" Then
                                If xrow(10) = 1 Then
                                    PGLU_Doc_Manager.mnuMaintenance_Index.Visible = True
                                Else
                                    PGLU_Doc_Manager.mnuMaintenance_Index.Visible = False

                                End If
                            ElseIf xrow(8).ToString.ToUpper = "MNUMAINTENANCE_INDEX_INDEXCOLUMN" Then
                                If xrow(10) = 1 Then
                                    PGLU_Doc_Manager.mnuMaintenance_Index_IndexColumn.Visible = True
                                Else
                                    PGLU_Doc_Manager.mnuMaintenance_Index_IndexColumn.Visible = False
                                End If

                            ElseIf xrow(8).ToString.ToUpper = "MNUMAINTENANCE_INDEX_INDEXGROUP" Then
                                If xrow(10) = 1 Then
                                    PGLU_Doc_Manager.mnuMaintenance_Index_IndexGroup.Visible = True
                                Else
                                    PGLU_Doc_Manager.mnuMaintenance_Index_IndexGroup.Visible = False

                                End If
                            ElseIf xrow(8).ToString.ToUpper = "MNUMAINTENANCE_SECURITY" Then
                                If xrow(10) = 1 Then
                                    PGLU_Doc_Manager.mnuMaintenance_Security.Visible = True
                                Else
                                    PGLU_Doc_Manager.mnuMaintenance_Security.Visible = False

                                End If
                            ElseIf xrow(8).ToString.ToUpper = "MNUMAINTENANCE_SECURITY_USERSECURITY" Then
                                If xrow(10) = 1 Then
                                    PGLU_Doc_Manager.mnuMaintenance_Security_UserSecurity.Visible = True
                                Else
                                    PGLU_Doc_Manager.mnuMaintenance_Security_UserSecurity.Visible = False

                                End If

                            ElseIf xrow(8).ToString.ToUpper = "MNUMAINTENANCE_SECURITY_DOCUMENTSECURITY" Then
                                If xrow(10) = 1 Then
                                    PGLU_Doc_Manager.mnuMaintenance_Security_DocumentSecurity.Visible = True
                                Else
                                    PGLU_Doc_Manager.mnuMaintenance_Security_DocumentSecurity.Visible = False

                                End If

                            ElseIf xrow(8).ToString.ToUpper = "MNUMAINTENANCE_SECURITY_AUDITTRAIL" Then
                                If xrow(10) = 1 Then
                                    PGLU_Doc_Manager.mnuMaintenance_Security_AuditTrail.Visible = True
                                Else
                                    PGLU_Doc_Manager.mnuMaintenance_Security_AuditTrail.Visible = False
                                End If

                            ElseIf xrow(8).ToString.ToUpper = "MNUMAINTENANCE_PREFERENCE" Then
                                If xrow(10) = 1 Then
                                    PGLU_Doc_Manager.mnuMaintenance_Preference.Visible = True
                                Else
                                    PGLU_Doc_Manager.mnuMaintenance_Preference.Visible = False
                                End If

                            ElseIf xrow(8).ToString.ToUpper = "MNUMAINTENANCE_SECURITY_USERSECURITY_USER" Then
                                If xrow(10) = 1 Then
                                    PGLU_Doc_Manager.mnuMaintenance_Security_UserSecurity_User.Visible = True
                                Else
                                    PGLU_Doc_Manager.mnuMaintenance_Security_UserSecurity_User.Visible = False
                                End If

                            ElseIf xrow(8).ToString.ToUpper = "MNUMAINTENANCE_SECURITY_USERSECURITY_GROUP" Then
                                If xrow(10) = 1 Then
                                    PGLU_Doc_Manager.mnuMaintenance_Security_UserSecurity_Group.Visible = True
                                Else
                                    PGLU_Doc_Manager.mnuMaintenance_Security_UserSecurity_Group.Visible = False
                                End If

                            ElseIf xrow(8).ToString.ToUpper = "MNUMAINTENANCE_SECURITY_USERSECURITY_PRIVILEGE" Then
                                If xrow(10) = 1 Then
                                    PGLU_Doc_Manager.mnuMaintenance_Security_UserSecurity_Privilege.Visible = True
                                Else
                                    PGLU_Doc_Manager.mnuMaintenance_Security_UserSecurity_Privilege.Visible = False
                                End If

                            End If
                        End If








                            'For Each mnu As ToolStripMenuItem In PGLU_Doc_Manager.MenuStrip.Items
                            '    For Each MNU2 As ToolStripDropDownItem In mnu.DropDownItems

                            '        'Try
                            '        'MsgBox(MNU2.Text.ToString)
                            '        'Catch ex As Exception
                            '        'End Try
                            '        Try
                            '            If xrow(8).ToString.ToUpper = MNU2.Text.ToUpper Then

                            '                If xrow(10) = 1 Then
                            '                    MNU2.Visible = True
                            '                Else
                            '                    MNU2.Visible = False
                            '                End If

                            '            End If
                            '        Catch ex As Exception
                            '            'MsgBox(ex.Message)
                            '        End Try


                            '    Next
                            'Next

                            'For Each CHILE As Object In PGLU_Doc_Manager.MenuStrip.




                            ''''
                            'Dim I As Integer = 0
                            'While I < PGLU_Doc_Manager.MenuStrip.Items.Count
                            '    'MsgBox(PGLU_Doc_Manager.MenuStrip.Items(I).ToString)
                            '    If xrow(8).ToString.ToUpper = PGLU_Doc_Manager.MenuStrip.Items(I).ToString.ToUpper Then

                            '        If xrow(10) = 1 Then
                            '            PGLU_Doc_Manager.MenuStrip.Items(I).Visible = True
                            '        Else
                            '            PGLU_Doc_Manager.MenuStrip.Items(I).Visible = False
                            '        End If
                            '    End If
                            'Dim value As Int32 = Convert.ToInt32(PGLU_Doc_Manager.MenuStrip.Items(I).Value)
                            'Dim level As Int32 = Convert.ToInt32(SESSION.Item("uxID"))

                            'If value > level Then : PGLU_Doc_Manager.MenuStrip.Items.RemoveAt(I)
                            'Else : I += 1
                            ''End If
                            'I = I + 1
                            'End While

                    Case "FRMCOLUMNNAME"
                        Dim ctl As Control = frmColumnName.GetNextControl(frmColumnName, True)

                        Do Until ctl Is Nothing
                            'MsgBox(ctl.GetType.ToString)
                            If ctl.Name.ToUpper = xrow(8).ToString.ToUpper Then
                                If xrow(10) = 1 Then
                                    ctl.Visible = True
                                Else
                                    ctl.Visible = False
                                End If

                            End If
                            ctl = frmColumnName.GetNextControl(ctl, True)

                        Loop
                    Case "FRMCOLUMNGROUP"
                        Dim ctl As Control = frmColumnGroup.GetNextControl(frmColumnGroup, True)

                        Do Until ctl Is Nothing
                            'MsgBox(ctl.GetType.ToString)
                            If ctl.Name.ToUpper = xrow(8).ToString.ToUpper Then
                                If xrow(10) = 1 Then
                                    ctl.Visible = True
                                Else
                                    ctl.Visible = False
                                End If

                            End If
                            ctl = frmColumnGroup.GetNextControl(ctl, True)

                        Loop

                    Case "FRMSECURITYDOCUMENT"
                        Dim ctl As Control = frmSecurityDocument.GetNextControl(frmSecurityDocument, True)

                        Do Until ctl Is Nothing

                            If ctl.Name.ToUpper = xrow(8).ToString.ToUpper Then
                                If xrow(10) = 1 Then
                                    ctl.Visible = True
                                Else
                                    ctl.Visible = False
                                End If

                            End If
                            ctl = frmSecurityDocument.GetNextControl(ctl, True)

                        Loop

                    Case "FRMLOG"
                        Dim ctl As Control = frmLog.GetNextControl(frmSecurityDocument, True)

                        Do Until ctl Is Nothing

                            If ctl.Name.ToUpper = xrow(8).ToString.ToUpper Then
                                If xrow(10) = 1 Then
                                    ctl.Visible = True
                                Else
                                    ctl.Visible = False
                                End If

                            End If
                            ctl = frmLog.GetNextControl(ctl, True)

                        Loop

                    Case "FRMSECURITYGROUP"
                        Dim ctl As Control = frmSecurityGroup.GetNextControl(frmSecurityDocument, True)

                        Do Until ctl Is Nothing

                            If ctl.Name.ToUpper = xrow(8).ToString.ToUpper Then
                                If xrow(10) = 1 Then
                                    ctl.Visible = True
                                Else
                                    ctl.Visible = False
                                End If

                            End If
                            ctl = frmSecurityGroup.GetNextControl(ctl, True)

                        Loop

                    Case "FRMSECURITYPRIVILEGE"
                        Dim ctl As Control = frmSecurityPrivilege.GetNextControl(frmSecurityDocument, True)

                        Do Until ctl Is Nothing

                            If ctl.Name.ToUpper = xrow(8).ToString.ToUpper Then
                                If xrow(10) = 1 Then
                                    ctl.Visible = True
                                Else
                                    ctl.Visible = False
                                End If

                            End If
                            ctl = frmSecurityPrivilege.GetNextControl(ctl, True)
                        Loop
                End Select
            Next


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally

            'Try
            '    FBrecordset.Close()
            'Catch ex As Exception

            'End Try
            'FbCommand.Dispose()
            'FbConnection.Close()
        End Try
        frmDocument.Cursor = Cursors.Default
    End Sub

    Public Sub AuditLog(ByVal SQLstatement As String, ByVal TransactionCode As Integer, ByVal DML As String)

        Dim SQLcommand As String = SQLstatement.Replace("'", "")
        modFunction.SystemStatus("Updating Audit log")


        FbCommand.CommandText = "INSERT INTO SECURITY_AUDIT (TRANSACTION_ID, SQL_STATEMENT ,SECURITY_USER,DML ) VALUES ( " & TransactionCode & ", '" & SQLcommand & "', '" & LoggedUser & "','" & DML & "' ) "
        FbCommand.ExecuteNonQuery()
        modFunction.SystemStatus()

    End Sub


    'RE-CREATE SECURITY PRIVILEGE TABLE BASED FROM SECURITY TEMPLATE
    Public Sub Build_Security_privilege()
        Dim dbReader_TEMPLATE As OdbcDataReader = Nothing
        Dim dbReader_privilege As OdbcDataReader = Nothing
        Dim dbRead_Group As OdbcDataReader = Nothing
        Dim xCount As Integer = 0
        Dim DBcOMMAND As OdbcCommand = Nothing
        Dim countCommand As OdbcCommand = Nothing
        'For Each xrow As DataRow In SecurityDataTable.Rows



        'Next

        Try
            Call modConnection.FBirdConnectionOpen()
            FbCommand = New OdbcCommand
            FbCommand.Connection = FbConnection
            FbCommand.CommandText = "SELECT * FROM SECURITY_TEMPLATE"
            dbReader_TEMPLATE = FbCommand.ExecuteReader

            While dbReader_TEMPLATE.Read()
                DBcOMMAND = New OdbcCommand
                DBcOMMAND.Connection = FbConnection
                DBcOMMAND.CommandText = "SELECT COUNT(*) FROM SECURITY_PRIVILEGES WHERE WINDOW = '" & dbReader_TEMPLATE!WINDOW.ToString & "' AND CONTROL = '" & dbReader_TEMPLATE!CONTROL.ToString & "' AND FK_SECURITY_GROUP = '" & Security_Group & "'"
                xCount = DBcOMMAND.ExecuteScalar

                If xCount = 0 Then
                    countCommand = New OdbcCommand
                    countCommand.Connection = FbConnection
                    countCommand.CommandText = "INSERT INTO SECURITY_PRIVILEGES(WINDOW,CONTROL,CONTROLTYPE,STATUS,FK_SECURITY_GROUP,DESCRIPTION) VALUES ('" & dbReader_TEMPLATE!WINDOW & "','" & dbReader_TEMPLATE!CONTROL & "', '" & dbReader_TEMPLATE!CONTROLTYPE & "', 0,'" & Security_Group & "','" & dbReader_TEMPLATE!DESCRIPTION & "')"
                    countCommand.ExecuteNonQuery()
                    countCommand.Dispose()
                End If

                'While dbReader_privilege.Read
                '    If dbReader_privilege! Then
                'End While

                DBcOMMAND.Dispose()

            End While


        Catch ex As Exception
            MsgBox(DBcOMMAND.CommandText.ToString & vbNewLine & ex.Message, MsgBoxStyle.Critical)

        Finally
            FbConnection.Close()
            dbReader_TEMPLATE.Close()
            'dbReader_privilege.Close()
            'dbRead_Group.Close()
            FbCommand.Dispose()
            DBcOMMAND.Dispose()

        End Try


    End Sub

End Module
