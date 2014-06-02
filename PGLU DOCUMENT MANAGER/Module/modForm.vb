Imports System.Data.Odbc
Module modForm

    Public Sub Proc_btnNew(ByVal FormName As String)

        Select Case FormName

            Case "frmColumnGroup"
                With frmColumnGroup
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True
                    .btnDelete.Enabled = False

                    .txtGroupName.Text = Nothing
                    .txtGroupDescription.Text = Nothing
                    .lblID.Text = Nothing
                    Call Disable_Control(FormName, "NEW")
                End With

            Case "frmColumnName"
                With frmColumnName
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True
                    .btnDelete.Enabled = False

                    .txtColumnName.Text = Nothing
                    .txtColumnDescription.Text = Nothing
                    .txtSortNo.Value = 0
                    .lblGroupID.Text = Nothing
                    .lblID.Text = Nothing
                    Call Disable_Control(FormName, "NEW")
                End With

            Case "frmDocument"
                With frmDocument
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True
                    .btnDelete.Enabled = False
                    .btnPDF.Enabled = True
                    .btnPrint.Enabled = False
                    .btnRollback.Enabled = False

                    .lblID.Text = Nothing
                    '.lblGroupID.Text = Nothing
                    .lblDocumentFileID.Text = Nothing
                    .lblFileName.Text = Nothing
                    .lblFileSize.Text = Nothing
                    .lblUpdatedBy.Text = Nothing
                    .lblDateUpdated.Text = Nothing
                    .txtNote.Text = Nothing

                    .lstAttachment.Items.Clear()
                    .lstHistory.Items.Clear()
                    Call Disable_Control(FormName, "NEW")
                    Call NEW_DOCUMENT_LISTVIEW(.lblGroupID.Text)
                End With

        End Select

    End Sub

    Public Sub Proc_btnDelete(ByVal FormName As String)
        Select Case FormName

            Case "frmColumnGroup"
                With frmColumnGroup
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False
                    .btnDelete.Enabled = False

                    .txtGroupName.Text = Nothing
                    .txtGroupDescription.Text = Nothing
                    .lblID.Text = Nothing
                    Call Proc_listview(FormName, "SELECT * FROM S_COLUMNGROUP ORDER BY GROUP_NAME ASC")
                    Call Disable_Control(FormName, "DELETE")
                End With
            Case "frmColumnName"
                With frmColumnName
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False
                    .btnDelete.Enabled = False

                    .txtColumnName.Text = Nothing
                    .txtColumnDescription.Text = Nothing
                    .txtSortNo.Value = 0
                    .lblGroupID.Text = Nothing
                    .lblID.Text = Nothing

                    Call Proc_listview(FormName, "SELECT COLUMNNAME_ID,COLUMNGROUP_ID,GROUP_NAME,COLUMN_NAME,S_COLUMNNAME.DESCRIPTION,PRIORITY,S_COLUMNNAME.SECURITY_USER,S_COLUMNNAME.TRANSDATE FROM S_COLUMNNAME JOIN S_COLUMNGROUP ON S_COLUMNNAME.FK_COLUMNGROUP_ID=S_COLUMNGROUP.COLUMNGROUP_ID ORDER BY GROUP_NAME,PRIORITY,COLUMN_NAME")
                    Call Disable_Control(FormName, "DELETE")
                End With

            Case "frmDocument"
                With frmDocument
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False
                    .btnDelete.Enabled = False
                    .btnPDF.Enabled = False
                    .btnPrint.Enabled = False
                    .btnRollback.Enabled = False

                    .lblID.Text = Nothing
                    '.lblGroupID.Text = Nothing
                    .lblDocumentFileID.Text = Nothing
                    .lblFileName.Text = Nothing
                    .lblFileSize.Text = Nothing
                    .lblUpdatedBy.Text = Nothing
                    .lblDateUpdated.Text = Nothing
                    .txtNote.Text = Nothing
                    Call Disable_Control(FormName, "DELETE")
                    .lstAttachment.Items.Clear()
                    .lstHistory.Items.Clear()
                    'INITIALIZE LISTVIEW/TAG COLUMNS ACCORDING TO SELECTED GROUP
                    Call NEW_DOCUMENT_LISTVIEW(.lblGroupID.Text)
                   
                End With

        End Select
    End Sub

    Public Sub Proc_btnSave(ByVal FormName As String)
        Select Case FormName

            Case "frmColumnGroup"
                With frmColumnGroup
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False
                    .btnDelete.Enabled = True

                    '.txtGroupName.Text = Nothing
                    '.txtGroupDescription.Text = Nothing
                    Call Proc_listview(FormName, "SELECT * FROM S_COLUMNGROUP ORDER BY GROUP_NAME ASC")
                    Call Disable_Control(FormName, "SAVE")
                End With

            Case "frmColumnName"
                With frmColumnName
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False
                    .btnDelete.Enabled = True

                    Call Proc_listview(FormName, "SELECT COLUMNNAME_ID,COLUMNGROUP_ID,GROUP_NAME,COLUMN_NAME,S_COLUMNNAME.DESCRIPTION,PRIORITY,S_COLUMNNAME.SECURITY_USER,S_COLUMNNAME.TRANSDATE FROM S_COLUMNNAME JOIN S_COLUMNGROUP ON S_COLUMNNAME.FK_COLUMNGROUP_ID=S_COLUMNGROUP.COLUMNGROUP_ID ORDER BY GROUP_NAME,PRIORITY,COLUMN_NAME")
                    Call Disable_Control(FormName, "SAVE")
                End With

            Case "frmDocument"
                With frmDocument
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False
                    .btnDelete.Enabled = True
                    .btnPDF.Enabled = False
                    .btnPrint.Enabled = True
                    .btnRollback.Enabled = True

                    Call Disable_Control(FormName, "SAVE")
                End With
        End Select
    End Sub

    Public Sub Proc_btnEdit(ByVal FormName As String)
        Select Case FormName

            Case "frmColumnGroup"
                With frmColumnGroup
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True
                    .btnDelete.Enabled = True

                    Call Disable_Control(FormName, "EDIT")
                End With

            Case "frmColumnName"
                With frmColumnName
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True
                    .btnDelete.Enabled = True

                   Call Disable_Control(FormName, "EDIT")
                End With

            Case "frmDocument"
                With frmDocument
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True
                    .btnDelete.Enabled = True
                    .btnPDF.Enabled = True
                    .btnPrint.Enabled = True
                    .btnRollback.Enabled = True

                    Call Disable_Control(FormName, "EDIT")
                End With

        End Select
    End Sub

    Public Sub Proc_listview(ByVal FormName As String, ByVal SQLString As String, Optional ByVal ListControl2 As String = Nothing, Optional ByVal SQLString2 As String = Nothing)
        Dim lvItem As ListViewItem
        Dim FBRecordset As OdbcDataReader = Nothing
        'Dim FbCommand As New OdbcCommand
        Try
            Call FBirdConnectionOpen()
            FbCommand = New OdbcCommand
            FbCommand.Connection = FbConnection
            FbCommand.CommandText = SQLString
            FBRecordset = FbCommand.ExecuteReader

            Select Case FormName

                Case "frmColumnGroup"
                    With frmColumnGroup
                        .lstTagGroup.Items.Clear()
                        While FBRecordset.Read
                            lvItem = New ListViewItem(FBRecordset!COLUMNGROUP_ID.ToString)
                            'lvItem = .lstTagGroup.Items.Add(FBRecordset!COLUMNGROUP_ID)
                            lvItem.SubItems.Add(FBRecordset!GROUP_NAME.ToString)
                            lvItem.SubItems.Add(FBRecordset!DESCRIPTION.ToString)
                            lvItem.SubItems.Add(FBRecordset!SECURITY_USER.ToString)
                            lvItem.SubItems.Add(FBRecordset!TRANSDATE)
                            .lstTagGroup.Items.Add(lvItem)
                        End While
                    End With

                Case "frmColumnName"
                    With frmColumnName
                        .lstColumnName.Items.Clear()
                        While FBRecordset.Read
                            lvItem = New ListViewItem(FBRecordset!COLUMNNAME_ID.ToString)
                            lvItem.SubItems.Add(FBRecordset!COLUMNGROUP_ID.ToString)
                            lvItem.SubItems.Add(FBRecordset!GROUP_NAME.ToString)
                            lvItem.SubItems.Add(FBRecordset!COLUMN_NAME.ToString)
                            lvItem.SubItems.Add(FBRecordset!DESCRIPTION.ToString)
                            lvItem.SubItems.Add(FBRecordset!PRIORITY.ToString)
                            lvItem.SubItems.Add(FBRecordset!SECURITY_USER.ToString)
                            lvItem.SubItems.Add(FBRecordset!TRANSDATE.ToString)
                            .lstColumnName.Items.Add(lvItem)
                        End While

                    End With


                Case "frmDocument"
                    With frmDocument
                        .lstTag.Items.Clear()

                        While FBRecordset.Read
                            lvItem = New ListViewItem(FBRecordset!COLUMNGROUP_ID.ToString)
                            'lvItem = .lstTagGroup.Items.Add(FBRecordset!COLUMNGROUP_ID)
                            lvItem.SubItems.Add(FBRecordset!GROUP_NAME.ToString)
                            lvItem.SubItems.Add(FBRecordset!DESCRIPTION.ToString)
                            lvItem.SubItems.Add(FBRecordset!SECURITY_USER.ToString)
                            lvItem.SubItems.Add(FBRecordset!TRANSDATE)
                            .lstTag.Items.Add(lvItem)
                        End While
                        If ListControl2 <> Nothing Then

                        End If

                    End With

                Case "PGLU_Doc_Manager"
                    With PGLU_Doc_Manager
                        .lstSearch.Items.Clear()


                    End With

            End Select

            FbConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & FbCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
            FbConnection.Close()
        Finally

            FbCommand.Dispose()
            FBRecordset.Close()

        End Try

    End Sub

    Public Sub Disable_Control(ByVal formname As String, ByVal FormStatus As String)
        Select Case formname

            Case "frmColumnGroup"
                With frmColumnGroup
                    Select Case FormStatus
                        Case "NEW"
                            .txtGroupName.Enabled = True
                            .txtGroupDescription.Enabled = True
                            '.lstTagGroup.Enabled = True
                        Case "DELETE"
                            .txtGroupName.Enabled = False
                            .txtGroupDescription.Enabled = False
                            '.lstTagGroup.Enabled = False
                        Case "SAVE"
                            .txtGroupName.Enabled = False
                            .txtGroupDescription.Enabled = False
                            '.lstTagGroup.Enabled = False
                        Case "EDIT"
                            .txtGroupName.Enabled = True
                            .txtGroupDescription.Enabled = True
                            '.lstTagGroup.Enabled = False
                    End Select

                End With

            Case "frmColumnName"
                With frmColumnName
                    Select Case FormStatus
                        Case "NEW"
                            .cboGroupName.Enabled = True
                            .txtColumnName.Enabled = True
                            .txtColumnDescription.Enabled = True
                            .txtSortNo.Enabled = True
                            '.lstTagGroup.Enabled = True
                        Case "DELETE"
                            .cboGroupName.Enabled = False
                            .txtColumnName.Enabled = False
                            .txtColumnDescription.Enabled = False
                            .txtSortNo.Enabled = False
                            '.lstTagGroup.Enabled = False
                        Case "SAVE"
                            .cboGroupName.Enabled = False
                            .txtColumnName.Enabled = False
                            .txtColumnDescription.Enabled = False
                            .txtSortNo.Enabled = False
                        Case "EDIT"
                            .cboGroupName.Enabled = True
                            .txtColumnName.Enabled = True
                            .txtColumnDescription.Enabled = True
                            .txtSortNo.Enabled = True
                    End Select
                End With

            Case "frmDocument"
                With frmDocument
                    Select formname
                        Case "NEW"
                            .txtNote.Enabled = True
                            .lstTag.Enabled = True
                            .TabDocument.Enabled = True
                        Case "DELETE"
                            .txtNote.Enabled = False
                            .lstTag.Enabled = False
                            .TabDocument.Enabled = False
                        Case "SAVE"
                            .txtNote.Enabled = False
                            .lstTag.Enabled = False
                            .TabDocument.Enabled = False
                        Case "EDIT"
                            .txtNote.Enabled = True
                            .lstTag.Enabled = True
                            .TabDocument.Enabled = True

                    End Select

                End With

        End Select

    End Sub

    Public Sub ShowDialoguePanel(ByVal PanelName As String, Optional ByVal CurText As String = Nothing)
        With frmDialogueBox
            .pnlNewDoc.Visible = False
            .pnlEditTag.Visible = False
            Select Case PanelName
                Case "New Document"
                    '.pnlNewDoc.Dock = DockStyle.Fill
                    .pnlNewDoc.Top = 0
                    .Text = "Select Document Group"
                    .pnlNewDoc.Visible = True
                    .pnlNewDoc.Height = 56
                    .Width = .pnlNewDoc.Width
                    .Height = .pnlNewDoc.Height + 30

                Case "Edit Tag"
                    '.pnlEditTag.Dock = DockStyle.
                    .pnlEditTag.Top = 0
                    .Text = "Type Document Tag"
                    .txtEditTag.Text = CurText
                    .pnlEditTag.Visible = True
                    .pnlEditTag.Height = 56
                    .Width = .pnlEditTag.Width
                    .Height = .pnlEditTag.Height + 30


            End Select
        End With
    End Sub

    'PROCEDURE TO POPULATE THE COLUMN/TAGS IN FRMDOCUMENT
    'INPUT: N/A
    'OUTPUT: N/A
    Public Sub NEW_DOCUMENT_LISTVIEW(ByVal COLUMNGROUP_ID As String)
        Dim lvItem As ListViewItem
        Dim FBRecordset As OdbcDataReader = Nothing


        With frmDocument
            .lstTag.Items.Clear()
            Try
                Call FBirdConnectionOpen()
                FbSql = "SELECT COLUMNNAME_ID,COLUMN_NAME,FK_COLUMNGROUP_ID FROM S_COLUMNNAME WHERE FK_COLUMNGROUP_ID = '" & COLUMNGROUP_ID & "' ORDER BY PRIORITY,COLUMN_NAME ASC"
                FbCommand.Connection = FbConnection
                FbCommand.CommandText = FbSql
                FBRecordset = FbCommand.ExecuteReader

                While FBRecordset.Read
                    lvItem = New ListViewItem(FBRecordset!COLUMNNAME_ID.ToString)
                    lvItem.SubItems.Add(FBRecordset!COLUMN_NAME.ToString)
                    lvItem.SubItems.Add("")
                    .lstTag.Items.Add(lvItem)
                    .lblGroupID.Text = FBRecordset!FK_COLUMNGROUP_ID.ToString
                End While

                FbConnection.Close()
            Catch ex As Exception
                MsgBox(ex.Message & vbNewLine & vbNewLine & FbCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
                FbConnection.Close()
            Finally

                FbCommand.Dispose()
                FBRecordset.Close()

            End Try

        End With

    End Sub

End Module
