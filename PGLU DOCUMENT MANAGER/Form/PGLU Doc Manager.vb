Imports System.Windows.Forms
Imports System.Data.Odbc
Imports System.IO
Imports System.Net.NetworkInformation
Imports System.Net
Public Class PGLU_Doc_Manager
    Private m_SortingColumn As ColumnHeader
    Private m_ChildFormNumber As Integer
    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewWindowToolStripMenuItem.Click
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub

    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        If Me.ToolBarToolStripMenuItem.Checked = True Then
            Me.PictureBox1.Visible = True
            Me.grpSearch.Visible = True

        Else
            Me.PictureBox1.Visible = False
            Me.grpSearch.Visible = False
        End If

    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

  

    

    Private Sub PGLU_Doc_Manager_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim hostname As IPHostEntry = Dns.GetHostEntry(System.Net.Dns.GetHostName())
        Dim ip As IPAddress() = hostname.AddressList
        Dim nics() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces
        Try
            Call FBirdConnectionOpen()
            FbCommand = New OdbcCommand
            FbCommand.Connection = FbConnection

            FbCommand.CommandText = "SELECT NEXT VALUE FOR GEN_SECURITY_TRANSACTION_ID FROM RDB$DATABASE;"
            TransactionNumber = FbCommand.ExecuteScalar

            Call AuditLog("HOSTNAME:" & System.Net.Dns.GetHostName() & "; IP:" & System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList(0).ToString() & "; PHYADDR:" & nics(0).GetPhysicalAddress.ToString, TransactionNumber, "LOGOUT")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FbCommand.Dispose()
            FbConnection.Close()
        End Try

    End Sub



    Private Sub PGLU_Doc_Manager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        frmSplash.Show()
        frmSplash.Close()
        'Me.Text = My.Application.Info.Title.ToString & " v" & My.Application.Info.Version.ToString

        modFunction.SystemStatus("Log in")
        frmLogin.ShowDialog()
        modFunction.SystemStatus()
    End Sub

 




    'SYSTEM RESIZE (SEARCH PANEL)
    Private Sub PGLU_Doc_Manager_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.grpSearch.Height = Me.Height - 20
        Me.lstSearch.Height = grpSearch.Height - 80
        'SplitContainer2.Width = Me.grpSearch.Width + 100
    End Sub





    'search bar resize
    Private Sub PictureBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        Me.grpSearch.Width = MousePosition.X - 63
        Me.lstSearch.Width = grpSearch.Width - 10
        Me.txtSearch.Width = grpSearch.Width - 10
        Me.btnSearch.Left = grpSearch.Width - 77
        'Me.btnAdvanceSearch.Left = Me.btnSearch.Left - 86
        'Me.lstSearch.Columns(1).Width = grpSearch.Width - 120
    End Sub

    'click button search
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim FbReader As OdbcDataReader
        Dim LVitem As ListViewItem
        'Dim LVSearch As ListViewItem
        lstSearch.Items.Clear()
        modFunction.SystemStatus("Searching document..")
        Try
            Me.Cursor = Cursors.WaitCursor
            Call FBirdConnectionOpen()
            FbCommand = New OdbcCommand
            If chkOCR.Checked = True Then
                modFunction.SystemStatus("Performing OCR search")
                FbSql = "SELECT   DOCUMENT_ID,DESCRIPTION,C_DOCUMENTFILE.NOTE,C_DOCUMENT.SECURITY_USER,C_DOCUMENTFILE.TRANSDATE, L_TAG.TEXT,C_DOCUMENTFILE.DOCUMENTFILE_ID " _
                    & "FROM C_DOCUMENT JOIN C_DOCUMENTFILE ON C_DOCUMENT.DOCUMENT_ID = C_DOCUMENTFILE.FK_DOCUMENT_ID JOIN " _
                    & "S_COLUMNGROUP ON C_DOCUMENT.FK_COLUMNGROUP_ID = S_COLUMNGROUP.COLUMNGROUP_ID JOIN L_TAG ON " _
                    & "C_DOCUMENTFILE.DOCUMENTFILE_ID = L_TAG.FK_DOCUMENTFILE_ID WHERE C_DOCUMENTFILE.OCR LIKE '%" & txtSearch.Text.ToLower & "%' " _
                    & " ORDER BY DOCUMENT_ID,transdate DESC"
            Else
                FbSql = "SELECT   DOCUMENT_ID,DESCRIPTION,C_DOCUMENTFILE.NOTE,C_DOCUMENT.SECURITY_USER,C_DOCUMENTFILE.TRANSDATE,L_TAG.TEXT,C_DOCUMENTFILE.DOCUMENTFILE_ID " _
                    & "FROM C_DOCUMENT JOIN C_DOCUMENTFILE ON C_DOCUMENT.DOCUMENT_ID = C_DOCUMENTFILE.FK_DOCUMENT_ID JOIN " _
                    & "S_COLUMNGROUP ON C_DOCUMENT.FK_COLUMNGROUP_ID = S_COLUMNGROUP.COLUMNGROUP_ID JOIN L_TAG ON " _
                    & "C_DOCUMENTFILE.DOCUMENTFILE_ID = L_TAG.FK_DOCUMENTFILE_ID WHERE (L_TAG.TEXT LIKE '" & txtSearch.Text & "%' " _
                    & "OR S_COLUMNGROUP.DESCRIPTION LIKE '%" & txtSearch.Text & "%' OR C_DOCUMENTFILE.NOTE LIKE '%" & txtSearch.Text & "%' OR " _
                    & "C_DOCUMENTFILE.SECURITY_USER LIKE '" & txtSearch.Text & "%') AND S_COLUMNGROUP.COLUMNGROUP_ID IN " _
                    & "(SELECT FK_COLUMNGROUP_ID FROM L_COLUMNSECURITY WHERE FK_SECURITY_GROUP = '" & Security_Group & "') ORDER BY DOCUMENT_ID,transdate DESC"
            End If
            FbCommand.Connection = FbConnection
            FbCommand.CommandText = FbSql
            FbReader = FbCommand.ExecuteReader
            Dim counterX As Integer = 0
            Dim docfileid As String = Nothing
            While FbReader.Read
                If counterX <> 0 Then
                    If FbReader!DOCUMENT_ID.ToString = lstSearch.Items(counterX - 1).Text Then
                        If FbReader!text.ToString <> "" And docfileid = FbReader!DOCUMENTFILE_ID.ToString Then
                            lstSearch.Items(counterX - 1).SubItems(3).Text = lstSearch.Items(counterX - 1).SubItems(3).Text & " | " & FbReader!TEXT.ToString
                        End If

                    Else
                        LVitem = New ListViewItem(FbReader!DOCUMENT_ID.ToString)
                        LVitem.SubItems.Add(FbReader!DESCRIPTION.ToString)
                        LVitem.SubItems.Add(FbReader!NOTE.ToString)
                        LVitem.SubItems.Add(FbReader!TEXT.ToString)
                        LVitem.SubItems.Add(FbReader!SECURITY_USER)
                        LVitem.SubItems.Add(FbReader!TRANSDATE)
                        lstSearch.Items.Add(LVitem)
                        counterX = counterX + 1
                        docfileid = FbReader!DOCUMENTFILE_ID.ToString
                    End If
                Else
                    LVitem = New ListViewItem(FbReader!DOCUMENT_ID.ToString)
                    LVitem.SubItems.Add(FbReader!DESCRIPTION.ToString)
                    LVitem.SubItems.Add(FbReader!NOTE.ToString)
                    LVitem.SubItems.Add(FbReader!TEXT.ToString)
                    LVitem.SubItems.Add(FbReader!SECURITY_USER)
                    LVitem.SubItems.Add(FbReader!TRANSDATE)
                    lstSearch.Items.Add(LVitem)
                    counterX = counterX + 1
                    docfileid = FbReader!DOCUMENTFILE_ID.ToString
                End If

            End While

            'Dim intZ As Integer = 0
            'For Each item In lstSearch.Items

            '    For intX = intZ To lstSearch.Items.Count - 1
            '        If lstSearch.Items(intZ).Text = lstSearch.Items(intX).Text Then
            '            lstSearch.Items(intX).Remove()
            '        End If
            '    Next

            '    intZ = intZ + 1
            'Next

            FbReader.Close()
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & FbCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
        Finally

            FbConnection.Close()
            FbCommand.Dispose()
        End Try


        Me.Cursor = Cursors.Default
        modFunction.SystemStatus()
    End Sub

    Private Sub lstSearch_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstSearch.ColumnClick

        ' Get the new sorting column.  

        Dim new_sorting_column As ColumnHeader = lstSearch.Columns(e.Column)
        ' Figure out the new sorting order.  
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            ' New column. Sort ascending.  
            sort_order = SortOrder.Ascending
        Else ' See if this is the same column.  
            If new_sorting_column.Equals(m_SortingColumn) Then
                ' Same column. Switch the sort order.  
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.  
                sort_order = SortOrder.Ascending
            End If
            ' Remove the old sort indicator.  
            m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
        End If
        ' Display the new sort order.  
        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If
        ' Create a comparer.  
        lstSearch.ListViewItemSorter = New clsListviewSorter(e.Column, sort_order)
        ' Sort.  
        lstSearch.Sort()
    End Sub

    Private Sub lstSearch_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSearch.Disposed

    End Sub


    'COLUMN CLICK OF LSTSEARCH (SORTING)
    'Private Sub lstSearch_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstSearch.ColumnClick



    '' Get the new sorting column.  

    'Dim new_sorting_column As ColumnHeader = lstSearch.Columns(e.Column)
    '' Figure out the new sorting order.  
    'Dim sort_order As System.Windows.Forms.SortOrder
    '    If m_SortingColumn Is Nothing Then
    '' New column. Sort ascending.  
    '        sort_order = SortOrder.Ascending
    '    Else ' See if this is the same column.  
    '        If new_sorting_column.Equals(m_SortingColumn) Then
    '' Same column. Switch the sort order.  
    '            If m_SortingColumn.Text.StartsWith("> ") Then
    '                sort_order = SortOrder.Descending
    '            Else
    '                sort_order = SortOrder.Ascending
    '            End If
    '        Else
    '' New column. Sort ascending.  
    '            sort_order = SortOrder.Ascending
    '        End If
    '' Remove the old sort indicator.  
    '        m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
    '    End If
    '' Display the new sort order.  
    '    m_SortingColumn = new_sorting_column
    '    If sort_order = SortOrder.Ascending Then
    '        m_SortingColumn.Text = "> " & m_SortingColumn.Text
    '    Else
    '        m_SortingColumn.Text = "< " & m_SortingColumn.Text
    '    End If
    '' Create a comparer.  
    '    lstSearch.ListViewItemSorter = New clsListviewSorter(e.Column, sort_order)
    '' Sort.  
    '    lstSearch.Sort()

    'End Sub

    'DOUBLE CLICK OF LSTSEARCH UPON SEARCHING
    Private Sub lstSearch_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSearch.DoubleClick
        Dim FBrecordset As OdbcDataReader
        Dim picturecol As Integer
        Dim LVitem As ListViewItem

        modFunction.SystemStatus("Retrieving document")

        With frmDocument
            'Call NEW_DOCUMENT_LISTVIEW(.lblGroupID.Text)

            Try
                Me.Cursor = Cursors.WaitCursor

                'Call NEW_DOCUMENT_LISTVIEW(.lblGroupID.Text)
                Call FBirdConnectionOpen()
                FbCommand = New OdbcCommand
                FbCommand.Connection = FbConnection
                'C_DOCUMENT
                FbCommand.CommandText = "SELECT * FROM C_DOCUMENT WHERE DOCUMENT_ID = '" & lstSearch.SelectedItems(0).Text & "'"
                FBrecordset = FbCommand.ExecuteReader
                FBrecordset.Read()
                .lblID.Text = FBrecordset!DOCUMENT_ID.ToString
                .lblGroupID.Text = FBrecordset!FK_COLUMNGROUP_ID.ToString
                FBrecordset.Close()

                'C_DOCUMENTFILE
                ''START DELETE CONTENTS OF TEMP DIRECTORY
                Call Delete_Temp(My.Application.Info.DirectoryPath & "\TEMP\v13w3$.tmp")
                ''END DELETE CONTENTS OF TEMP DIRECTORY
                modFunction.SystemStatus("Retrieving document properties")
                FbSql = "SELECT FIRST 1 FILENAME,FILESIZE,SECURITY_USER,TRANSDATE,NOTE,DOCUMENTFILE_ID FROM C_DOCUMENTFILE WHERE FK_DOCUMENT_ID = '" & lstSearch.SelectedItems(0).Text & "' ORDER BY FILEHISTORY DESC"
                FbCommand.CommandText = FbSql
                FBrecordset = FbCommand.ExecuteReader
                FBrecordset.Read()
                .lblFileName.Text = FBrecordset!FILENAME.ToString
                .lblFileSize.Text = FBrecordset!FILESIZE.ToString
                .lblUpdatedBy.Text = FBrecordset!SECURITY_USER.ToString
                .lblDateUpdated.Text = FBrecordset!TRANSDATE.ToString
                .txtNote.Text = FBrecordset!NOTE.ToString
                .lblDocumentFileID.Text = FBrecordset!DOCUMENTFILE_ID.ToString
                FBrecordset.Close()
                'READ BLOB FILE
                modFunction.SystemStatus("Retrieving PDF file")
                FbSql = "SELECT FIRST 1 BLOBFILE FROM C_DOCUMENTFILE WHERE DOCUMENTFILE_ID = '" & .lblDocumentFileID.Text & "' " 'ORDER BY TRANSDATE DESC
                FbCommand.CommandText = FbSql
                FBrecordset = FbCommand.ExecuteReader
                FBrecordset.Read()
                Dim b(FBrecordset.GetBytes(picturecol, 0, Nothing, 0, Integer.MaxValue) - 1) As Byte
                'Dim fs As New FileStream(My.Application.Info.DirectoryPath & "\TEMP\v13w3$.tmp", FileMode.Create, FileAccess.Write)
                FBrecordset.GetBytes(picturecol, 0, b, 0, b.Length)
                IO.File.WriteAllBytes(My.Application.Info.DirectoryPath & "\TEMP\v13w3$.tmp", b)
                'fs.Write(b, 0, b.Length)
                'fs.Close()


                FBrecordset.Close()

                'L_TAG'
                .lstTag.Items.Clear()
                modFunction.SystemStatus("Retrieving indexes")
                FbSql = "SELECT COLUMNNAME_ID,COLUMN_NAME,FK_COLUMNGROUP_ID FROM S_COLUMNNAME WHERE FK_COLUMNGROUP_ID = '" & .lblGroupID.Text & "' ORDER BY PRIORITY,COLUMN_NAME ASC"
                FbCommand.Connection = FbConnection
                FbCommand.CommandText = FbSql
                FBrecordset = FbCommand.ExecuteReader

                While FBrecordset.Read
                    LVitem = New ListViewItem(FBrecordset!COLUMNNAME_ID.ToString)
                    LVitem.SubItems.Add(FBrecordset!COLUMN_NAME.ToString)
                    LVitem.SubItems.Add("")
                    .lstTag.Items.Add(LVitem)
                    .lblGroupID.Text = FBrecordset!FK_COLUMNGROUP_ID.ToString
                End While
                FBrecordset.Close()

                'insert tags
                FbCommand.CommandText = "SELECT * FROM  L_TAG WHERE FK_DOCUMENTFILE_ID = '" & .lblDocumentFileID.Text & "'"
                FBrecordset = FbCommand.ExecuteReader

                While FBrecordset.Read
                    'Dim counterZ As Integer = 0
                    For item = 0 To .lstTag.Items.Count - 1
                        'MsgBox(.lstTag.Items(item).SubItems(0).Text)
                        If .lstTag.Items(item).SubItems(0).Text = FBrecordset!FK_COLUMNNAME_ID.ToString Then
                            '.lstTag.Items(counterZ).Text = FBrecordset!FK_COLUMNNAME_ID.ToString
                            '.lstTag.Items(counterZ).SubItems(2).Text = FBrecordset!COLUMN_NAME.ToString
                            .lstTag.Items(item).SubItems(2).Text = FBrecordset!TEXT.ToString
                            '.lstTag.Items.Add(LVitem)

                        Else
                            '.lstTag.Items(item).SubItems(2).Text = ""
                        End If
                        'counterZ = counterZ + 1
                    Next

                End While
                FBrecordset.Close()

                'C_ATTACHMENT
                modFunction.SystemStatus("Retrieving attachment")
                FbCommand.CommandText = "SELECT * FROM C_ATTACHMENT WHERE FK_DOCUMENTFILE_ID = '" & .lblDocumentFileID.Text & "' "
                FBrecordset = FbCommand.ExecuteReader
                .lstAttachment.Items.Clear()
                While FBrecordset.Read
                    LVitem = New ListViewItem(FBrecordset!ATTACHMENT_ID.ToString)
                    LVitem.SubItems.Add("")
                    LVitem.SubItems.Add(FBrecordset!FILENAME.ToString)
                    LVitem.SubItems.Add(FBrecordset!FILETYPE.ToString)
                    .lstAttachment.Items.Add(LVitem)
                End While
                FBrecordset.Close()

                'C_HISTORY
                Dim counterX As Integer = 1
                modFunction.SystemStatus("Retrieving document history")
                FbCommand.CommandText = "SELECT * FROM C_DOCUMENTFILE WHERE FK_DOCUMENT_ID = '" & .lblID.Text & "' ORDER BY FILEHISTORY ASC"
                FBrecordset = FbCommand.ExecuteReader
                .lstHistory.Items.Clear()
                While FBrecordset.Read
                    If FBrecordset!DOCUMENTFILE_ID <> .lblDocumentFileID.Text Then
                        LVitem = New ListViewItem(FBrecordset!DOCUMENTFILE_ID.ToString)
                        LVitem.SubItems.Add(counterX)
                        LVitem.SubItems.Add(FBrecordset!NOTE.ToString)
                        LVitem.SubItems.Add(FBrecordset!TRANSDATE.ToString)
                        LVitem.SubItems.Add(FBrecordset!SECURITY_USER.ToString)
                        .lstHistory.Items.Add(LVitem)
                        counterX = counterX + 1
                    End If
                End While
                FBrecordset.Close()
                Proc_btnEdit("frmDocument")
                frmDocument.Show()
                .axDocument.src = My.Application.Info.DirectoryPath & "\TEMP\v13w3$.tmp"

            Catch ex As Exception
                MsgBox(ex.Message & vbNewLine & vbNewLine & FbCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
            Finally
                FbConnection.Close()
                FbCommand.Dispose()

            End Try
        End With
        Me.Cursor = Cursors.Default
        modFunction.SystemStatus()
    End Sub

    Private Sub lstSearch_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSearch.MouseHover
        modFunction.SystemStatus("Double click to open document")
    End Sub

    Private Sub lstSearch_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSearch.MouseLeave
        modFunction.SystemStatus()
    End Sub










    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        frmAbout.ShowDialog()
    End Sub



    Private Sub SearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub AuditLogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AuditLogToolStripMenuItem.Click
        frmAuditLog.Show()
    End Sub

    'NEW DOCUMENT MENU
    Private Sub mnuDocument_NewDocument_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDocument_NewDocument.Click

        Call ShowDialoguePanel("New Document")
        Call PopListComboBox(frmDialogueBox.cboNewDoc, "SELECT GROUP_NAME FROM S_COLUMNGROUP WHERE COLUMNGROUP_ID IN (SELECT FK_COLUMNGROUP_ID FROM L_COLUMNSECURITY WHERE FK_SECURITY_GROUP = '" & Security_Group & "')ORDER BY GROUP_NAME ASC")
        frmDialogueBox.ShowDialog()

    End Sub
    'EXIT APP/SYSTEM
    Private Sub mnuDocument_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDocument_Exit.Click




        FbConnection.Close()
        FbCommand.Dispose()

        'Me.Dispose()
        Me.Close()
        End

    End Sub



    Private Sub mnuMaintenance_Index_IndexColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMaintenance_Index_IndexColumn.Click
        frmColumnName.Show()
    End Sub

    Private Sub mnuMaintenance_Index_IndexGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMaintenance_Index_IndexGroup.Click
        frmColumnGroup.Show()
    End Sub

    Private Sub mnuMaintenance_Security_UserSecurity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMaintenance_Security_UserSecurity.Click
        'frmSecurity.Show()
    End Sub

    Private Sub mnuMaintenance_Security_DocumentSecurity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMaintenance_Security_DocumentSecurity.Click
        frmSecurityDocument.Show()
    End Sub

    Private Sub mnuMaintenance_Security_AuditTrail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMaintenance_Security_AuditTrail.Click
        frmLog.Show()
    End Sub


    Private Sub mnuMaintenance_Security_UserSecurity_User_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMaintenance_Security_UserSecurity_User.Click
        frmSecurityGroup.tabSecurity.SelectTab(0)
        Dim RefreshLIstview As New clsSecurity
        RefreshLIstview.RefreshListView("USER")
        RefreshLIstview = Nothing

        'Dim lstSecurity As New frmSecurityGroup
        'lstSecurity.ListShow = "USER"
        frmSecurityGroup.ListShow = "USER"
        frmSecurityGroup.Show()
    End Sub

    Private Sub mnuMaintenance_Security_UserSecurity_Group_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMaintenance_Security_UserSecurity_Group.Click
        frmSecurityGroup.tabSecurity.SelectTab(1)
        Dim RefreshLIstview As New clsSecurity
        RefreshLIstview.RefreshListView("GROUP")
        RefreshLIstview = Nothing

        'Dim lstSecurity As New frmSecurityGroup
        'lstSecurity.ListShow = "GROUP"
        frmSecurityGroup.ListShow = "GROUP"
        frmSecurityGroup.Show()
    End Sub

    Private Sub mnuMaintenance_Security_UserSecurity_Privilege_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMaintenance_Security_UserSecurity_Privilege.Click
        frmSecurityPrivilege.Show()
    End Sub


    Private Sub mnuDocument_NewDocument_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuDocument_NewDocument.MouseHover
        modFunction.SystemStatus("Create new document")
    End Sub

    Private Sub mnuDocument_NewDocument_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuDocument_NewDocument.MouseLeave
        modFunction.SystemStatus()
    End Sub

    Private Sub mnuDocument_Exit_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuDocument_Exit.MouseHover
        modFunction.SystemStatus("Exit System")
    End Sub

    Private Sub mnuDocument_Exit_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuDocument_Exit.MouseLeave
        modFunction.SystemStatus()
    End Sub

    Private Sub mnuMaintenance_Index_IndexColumn_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuMaintenance_Index_IndexColumn.MouseHover
        modFunction.SystemStatus("Add/Edit/Delete Index")
    End Sub

    Private Sub mnuMaintenance_Index_IndexColumn_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuMaintenance_Index_IndexColumn.MouseLeave
        modFunction.SystemStatus()
    End Sub

    Private Sub mnuMaintenance_Index_IndexGroup_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuMaintenance_Index_IndexGroup.MouseHover
        modFunction.SystemStatus("Add/Edit/Delete Index Group")
    End Sub

    Private Sub mnuMaintenance_Index_IndexGroup_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuMaintenance_Index_IndexGroup.MouseLeave
        modFunction.SystemStatus()
    End Sub

    Private Sub mnuMaintenance_Security_UserSecurity_User_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuMaintenance_Security_UserSecurity_User.MouseHover
        modFunction.SystemStatus("Add/Edit/Delete System Users")
    End Sub

    Private Sub mnuMaintenance_Security_UserSecurity_User_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuMaintenance_Security_UserSecurity_User.MouseLeave
        modFunction.SystemStatus()
    End Sub

    Private Sub mnuMaintenance_Security_UserSecurity_Group_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuMaintenance_Security_UserSecurity_Group.MouseHover
        modFunction.SystemStatus("Add/Edit/Delete System Users Group")
    End Sub

    Private Sub mnuMaintenance_Security_UserSecurity_Group_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuMaintenance_Security_UserSecurity_Group.MouseLeave
        modFunction.SystemStatus()
    End Sub

    Private Sub mnuMaintenance_Security_UserSecurity_Privilege_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuMaintenance_Security_UserSecurity_Privilege.MouseHover
        modFunction.SystemStatus("Add/Remove Group System Privilege")
    End Sub

    Private Sub mnuMaintenance_Security_UserSecurity_Privilege_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuMaintenance_Security_UserSecurity_Privilege.MouseLeave
        modFunction.SystemStatus()
    End Sub

    Private Sub mnuMaintenance_Security_DocumentSecurity_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuMaintenance_Security_DocumentSecurity.MouseHover
        modFunction.SystemStatus("Add/Remove Document Privilage")
    End Sub

    Private Sub mnuMaintenance_Security_DocumentSecurity_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuMaintenance_Security_DocumentSecurity.MouseLeave
        modFunction.SystemStatus()
    End Sub

    Private Sub mnuMaintenance_Security_AuditTrail_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuMaintenance_Security_AuditTrail.MouseHover
        modFunction.SystemStatus("System Transaction Audit")
    End Sub

    Private Sub mnuMaintenance_Security_AuditTrail_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuMaintenance_Security_AuditTrail.MouseLeave
        modFunction.SystemStatus()
    End Sub

    Private Sub mnuMaintenance_Preference_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMaintenance_Preference.Click

    End Sub

    Private Sub mnuMaintenance_Preference_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuMaintenance_Preference.MouseHover
        modFunction.SystemStatus("Show system preferences")
    End Sub

    Private Sub mnuMaintenance_Preference_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuMaintenance_Preference.MouseLeave
        modFunction.SystemStatus()
    End Sub

    Private Sub AuditLogToolStripMenuItem_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles AuditLogToolStripMenuItem.MouseHover
        modFunction.SystemStatus("Show system changelog")
    End Sub

    Private Sub chkOCR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOCR.CheckedChanged

    End Sub

    Private Sub chkOCR_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkOCR.MouseHover
        modFunction.SystemStatus("Perform OCR text search")
    End Sub

    Private Sub chkOCR_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkOCR.MouseLeave
        modFunction.SystemStatus()
    End Sub

    Private Sub txtSearch_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.GotFocus
        modFunction.SystemStatus("Leave this blank to display all document")
    End Sub

    Private Sub txtSearch_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.LostFocus
        modFunction.SystemStatus()
    End Sub

    Private Sub txtSearch_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.MouseHover
        modFunction.SystemStatus("Leave this blank to display all document")
    End Sub

    Private Sub txtSearch_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.MouseLeave
        modFunction.SystemStatus()
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub

    Private Sub mnuDocument_Logout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDocument_Logout.Click

        If MsgBox("Are you sure you want to Log Off?", vbInformation + vbYesNo, My.Application.Info.Title.ToString) = vbNo Then Exit Sub

        For i = Me.MdiChildren.Length - 1 To 0 Step -1
            Me.MdiChildren(i).Close()
        Next


        FbConnection.Close()
        FbCommand.Dispose()

        frmSplash.Show()
        frmSplash.Close()
        Me.Text = My.Application.Info.Title.ToString & " v" & My.Application.Info.Version.ToString
        modFunction.SystemStatus("Log in")
        frmLogin.ShowDialog()
        modFunction.SystemStatus()
    End Sub
End Class
