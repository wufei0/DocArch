Imports System.Data.Odbc
Imports System.IO

Imports org.apache.pdfbox.pdmodel
Imports org.apache.pdfbox.util



Public Class frmDocument
    Dim oDocument As Object
    Dim PDFFileInfo As FileInfo


    Private Sub frmDocument_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PGLU_Doc_Manager
        axDocument.setPageMode("none")
        Call Security_privilege()
        axDocument.setShowToolbar(False)
        Me.Cursor = Cursors.Default
        'axDocument.
        'SET CONTEXTMENU INTO LISTVIEW-HISTORY CONTROL
        'lstHistory.ContextMenuStrip = Me.cmsMenu
        'lstAttachment.ContextMenuStrip = Me.cmsAttachment

    End Sub


    Private Sub lstTag_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstTag.DoubleClick
        'ListView1.SelectedItems(0).SubItems(2).Text = "asdasdasdasdsasad"
 
    End Sub

    Private Sub btnPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPDF.Click
        Dim ofdPDF As New OpenFileDialog
        'ofdPDF.InitialDirectory = "Desktop"
        ofdPDF.Filter = "pdf file (*.pdf)|*.pdf"
        ofdPDF.FilterIndex = 1
        ofdPDF.RestoreDirectory = True
        modFunction.SystemStatus("Open PDF File")
        ofdPDF.ShowDialog()

        If ofdPDF.FileName <> Nothing Then
            axDocument.src = ofdPDF.FileName

            PDFFileInfo = My.Computer.FileSystem.GetFileInfo(ofdPDF.FileName)
            lblFileSize.Text = Format(PDFFileInfo.Length / 1024, "0.00") & " KB"
            lblFileName.Text = ofdPDF.SafeFileName
            lblUpdatedBy.Text = LoggedUser
            lblDateUpdated.Text = SQLScalar("select current_timestamp from rdb$database")
            lblDocumentFileID.Text = CreateGuid("DocumentFile")
        End If

        modFunction.SystemStatus()
    End Sub


#Region "SAVE"


    'SAVE DOCUMENT (BUTTON SAVE)
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim FBtransaction As OdbcTransaction = Nothing
        Dim FBreader As OdbcDataReader = Nothing
        Dim GuidID As String = Nothing
        Dim GUIDDOCFILE As String = Nothing
        Dim FS As FileStream
        Dim RawData() As Byte
        ''''OCR
        Dim pdfpath As String = Microsoft.VisualBasic.Right(axDocument.src.ToString, Microsoft.VisualBasic.Len(axDocument.src) - 7)
        Dim doc As PDDocument = Nothing
        Dim OCRstring As String
        Dim stripper As PDFTextStripper

        ''''OCR END

        ''''GENERATE GUID FOR PRIMARY KEYS
        GuidID = CreateGuid(Me.Name)
        If lblFileName.Text = Nothing Then
            Beep()
            Exit Sub
        End If


        Try
            'START OF TRANSACTION
            Me.Cursor = Cursors.WaitCursor
            Call FBirdConnectionOpen()
            FbCommand.Connection = FbConnection
            FBtransaction = FbConnection.BeginTransaction
            FbCommand.Transaction = FBtransaction

            FbCommand.CommandText = "SELECT NEXT VALUE FOR GEN_SECURITY_TRANSACTION_ID FROM RDB$DATABASE;"
            TransactionNumber = FbCommand.ExecuteScalar

            ''GET/CHECK HASH OF PDF FILE
            Dim MD5hashvalue As String
            Dim hashcount As Integer
            MD5hashvalue = modFunction.GetHash(PDFFileInfo.FullName.ToString)
            'MsgBox(MD5hashvalue)
            FbCommand.CommandText = "SELECT COUNT(*) FROM C_DOCUMENTFILE WHERE DOCHASH LIKE '" & MD5hashvalue & "' "
            hashcount = FbCommand.ExecuteScalar()
            If hashcount > 0 Then
                If MsgBox("File already exist in the database. Continue save?", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    FBtransaction.Rollback()
                    Exit Try

                End If
            End If
            ''FbSql = "SELECT * FROM C_DOCUMENTFILE WHERE DOCHASH = '" & MD5hashvalue & "' "

            ''END GET/CHECK HASH OF PDF FILE

            'CHECK IF LBLID IS EMPTY
            'THIS WILL IDENTIFY IF EDIT OR NEW
            If lblID.Text = Nothing Then


                'INSERT INTO C_DOCUMENT TABLE
                modFunction.SystemStatus("Inserting document")
                FbSql = "INSERT INTO C_DOCUMENT(DOCUMENT_ID,FK_COLUMNGROUP_ID,SECURITY_USER) VALUES ('" & GuidID & "','" & lblGroupID.Text & "','" & LoggedUser & "')"
                FbCommand.CommandText = FbSql
                FbCommand.ExecuteNonQuery()
                Call AuditLog(FbCommand.CommandText.ToString, TransactionNumber, "INSERT")

                'INSERT PDF FILE
                FS = New FileStream(PDFFileInfo.FullName.ToString, FileMode.OpenOrCreate, FileAccess.Read)
                RawData = New Byte((FS.Length) - 1) {}

                FS.Read(RawData, 0, FS.Length)
                FS.Close()

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'OCR START''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'MsgBox(pdfpath)
                modFunction.SystemStatus("Performing OCR indexing")
                doc = PDDocument.load(pdfpath)
                stripper = New PDFTextStripper
                OCRstring = stripper.getText(doc)

                If doc IsNot Nothing Then
                    doc.close()
                End If
                'txtNote.Text = OCRstring.ToLower
                Dim OCRbyte() As Byte = System.Text.Encoding.ASCII.GetBytes(OCRstring.ToLower)
                'OCR END''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                modFunction.SystemStatus("Inserting document file")
                FbCommand.Parameters.Clear()
                FbCommand.CommandText = "INSERT INTO C_DOCUMENTFILE(DOCUMENTFILE_ID,BLOBFILE,FILENAME,FILESIZE,FK_DOCUMENT_ID,SECURITY_USER,NOTE,OCR,DOCHASH) VALUES (?,?,?,?,?,?,?,?,?)"
                FbCommand.Parameters.AddWithValue("@DOCUMENTFILE_ID", lblDocumentFileID.Text)
                FbCommand.Parameters.AddWithValue("@BLOBFILE", RawData)
                FbCommand.Parameters.AddWithValue("@FILENAME", lblFileName.Text)
                FbCommand.Parameters.AddWithValue("@FILESIZE", Format(PDFFileInfo.Length / 1024, "0.00"))
                FbCommand.Parameters.AddWithValue("@FK_DOCUMENT_ID", GuidID)
                FbCommand.Parameters.AddWithValue("@SECURITY_USER", LoggedUser)
                FbCommand.Parameters.AddWithValue("@NOTE", txtNote.Text)
                FbCommand.Parameters.AddWithValue("@OCR", OCRbyte)
                FbCommand.Parameters.AddWithValue("@DOCHASH", MD5hashvalue)


                FbCommand.ExecuteNonQuery()

                Call AuditLog("INSERT INTO C_DOCUMENTFILE(DOCUMENTFILE_ID,BLOBFILE,FILENAME,FILESIZE," _
                              & "FK_DOCUMENT_ID,SECURITY_USER,NOTE,OCR) VALUES(" & lblDocumentFileID.Text & ",BLOB," _
                              & lblFileName.Text & "," & Format(PDFFileInfo.Length / 1024, "0.00") & "," & GuidID & "," & LoggedUser & "," & txtNote.Text & ",BLOB)", TransactionNumber, "INSERT")

                'INSERT INTO L_TAG TABLE
                modFunction.SystemStatus("Inserting index")
                For counterX = 0 To lstTag.Items.Count - 1
                    'If lstTag.Items(counterX).SubItems(2).Text <> "" Then
                    FbSql = "INSERT INTO L_TAG(FK_DOCUMENTFILE_ID,FK_COLUMNNAME_ID,SECURITY_USER,TEXT) VALUES ('" & lblDocumentFileID.Text & "','" & lstTag.Items(counterX).SubItems(0).Text & "','" & LoggedUser & "','" & lstTag.Items(counterX).SubItems(2).Text & "')"
                    FbCommand.CommandText = FbSql
                    FbCommand.ExecuteNonQuery()
                    Call AuditLog(FbCommand.CommandText.ToString, TransactionNumber, "INSERT")
                    'End If
                Next

                'INSERT ATTACHMENT FILE
                modFunction.SystemStatus("Inserting attachment")
                For intX = 0 To lstAttachment.Items.Count - 1

                    FS = New FileStream(lstAttachment.Items(intX).SubItems(1).Text, FileMode.OpenOrCreate, FileAccess.Read)
                    RawData = New Byte((FS.Length) - 1) {}
                    FS.Read(RawData, 0, FS.Length)
                    FS.Close()

                    FbCommand.Parameters.Clear()
                    FbSql = "INSERT INTO C_ATTACHMENT(ATTACHMENT_ID,BLOBATTACHMENT,FILENAME,FILETYPE,FK_DOCUMENTFILE_ID,SECURITY_USER) VALUES (?,?,?,?,?,?)"
                    FbCommand.CommandText = FbSql
                    FbCommand.Parameters.AddWithValue("@ATTACHMENT_ID", lstAttachment.Items(intX).SubItems(0).Text)
                    FbCommand.Parameters.AddWithValue("@BLOBATTACHMENT", RawData)
                    FbCommand.Parameters.AddWithValue("@FILENAME", lstAttachment.Items(intX).SubItems(2).Text)
                    FbCommand.Parameters.AddWithValue("@FILETYPE", lstAttachment.Items(intX).SubItems(3).Text)
                    FbCommand.Parameters.AddWithValue("@FK_DOCUMENTFILE_ID", lblDocumentFileID.Text)
                    FbCommand.Parameters.AddWithValue("@SECURITY_USER", LoggedUser)
                    FbCommand.ExecuteNonQuery()
                    Call AuditLog("INSERT INTO C_ATTACHMENT(ATTACHMENT_ID,BLOBATTACHMENT,FILENAME,FILETYPE,FK_DOCUMENTFILE_ID,SECURITY_USER) VALUES (" & lstAttachment.Items(intX).SubItems(0).Text & ",BLOB," & lstAttachment.Items(intX).SubItems(2).Text & "," & lstAttachment.Items(intX).SubItems(3).Text & "," & lblDocumentFileID.Text & "," & LoggedUser & ")", TransactionNumber, "INSERT")
                Next


                '''''''''''''''''''''''
                'EDIT CURRENT DOCUMENT'
                '''''''''''''''''''''''
            Else
                'CHECK IF PDF DOCUMENT IS CHANGED/NEW
                modFunction.SystemStatus("Updating document")
                If Microsoft.VisualBasic.Right(axDocument.src, 10) = "v13w3$.tmp" Then
                    'UPDATE PDF PROPERTIES AND NOTE
                    FbSql = "UPDATE C_DOCUMENTFILE SET NOTE='" & txtNote.Text & "',SECURITY_USER='" & LoggedUser & "' WHERE DOCUMENTFILE_ID = '" & lblDocumentFileID.Text & "' "
                    FbCommand.CommandText = FbSql
                    FbCommand.ExecuteNonQuery()
                    Call AuditLog(FbCommand.CommandText.ToString, TransactionNumber, "UPDATE")
                    'UPDATE L_TAG
                    For intX = 0 To lstTag.Items.Count - 1
                        FbCommand.CommandText = "SELECT COUNT(*) FROM L_TAG WHERE FK_DOCUMENTFILE_ID = '" & lblDocumentFileID.Text & "' AND FK_COLUMNNAME_ID = '" & lstTag.Items(intX).Text & "' "
                        If FbCommand.ExecuteScalar = 1 Then
                            FbSql = "UPDATE L_TAG SET TEXT = '" & lstTag.Items(intX).SubItems(2).Text & "' ,SECURITY_USER='" & LoggedUser & "' WHERE FK_DOCUMENTFILE_ID = '" & lblDocumentFileID.Text & "' AND FK_COLUMNNAME_ID = '" & lstTag.Items(intX).Text & "'"
                            FbCommand.CommandText = FbSql
                            FbCommand.ExecuteNonQuery()
                        Else
                            FbCommand.CommandText = "INSERT INTO L_TAG(FK_DOCUMENTFILE_ID,FK_COLUMNNAME_ID,SECURITY_USER,TEXT) VALUES ('" & lblDocumentFileID.Text & "','" & lstTag.Items(intX).SubItems(0).Text & "','" & LoggedUser & "','" & lstTag.Items(intX).SubItems(2).Text & "')"

                            FbCommand.ExecuteNonQuery()
                        End If
                        Call AuditLog(FbCommand.CommandText.ToString, TransactionNumber, "UPDATE")
                    Next
                    'UPDATE C_ATTACHMENT
                    'DELETE OF ATTACHMENT NOT IN LSTATTACHMENT
                    Dim Attachment_checker As Boolean = False
                    Dim Attachment_array(100) As String
                    Dim CounterArray As Integer = 0
                    FbSql = "SELECT * FROM C_ATTACHMENT WHERE FK_DOCUMENTFILE_ID = '" & lblDocumentFileID.Text & "' "
                    FbCommand.CommandText = FbSql
                    FBreader = FbCommand.ExecuteReader()
                    'READ ALL THE CONTENTS OF LISTVIEW AND COMPARE THEM WITH ATTACHMENT_ID
                    While FBreader.Read
                        Attachment_checker = False
                        For intX = 0 To lstAttachment.Items.Count - 1
                            If FBreader!ATTACHMENT_ID.ToString = lstAttachment.Items(intX).Text Then
                                Attachment_checker = True

                            End If
                        Next
                        If Attachment_checker = False Then
                            Attachment_array(CounterArray) = FBreader!ATTACHMENT_ID.ToString
                            CounterArray = CounterArray + 1
                        End If
                    End While
                    FBreader.Close()

                    For Each value In Attachment_array
                        If value <> Nothing Then

                            FbSql = "DELETE FROM C_ATTACHMENT WHERE ATTACHMENT_ID = '" & value & "' "
                            FbCommand.CommandText = FbSql
                            FbCommand.ExecuteNonQuery()
                            Call AuditLog(FbCommand.CommandText.ToString, TransactionNumber, "UPDATE")
                        End If
                    Next

                    'INSERT NEW ATTACHMENT WITH PATH <> NULL
                    modFunction.SystemStatus("Updating attachment")
                    For intx = 0 To lstAttachment.Items.Count - 1
                        If lstAttachment.Items(intx).SubItems(1).Text <> "" Then

                            FS = New FileStream(lstAttachment.Items(intx).SubItems(1).Text, FileMode.OpenOrCreate, FileAccess.Read)
                            RawData = New Byte((FS.Length) - 1) {}
                            FS.Read(RawData, 0, FS.Length)
                            FS.Close()
                            'Dim StreamFile As New FileStream(lstAttachment.Items(intx).SubItems(1).Text, FileMode.OpenOrCreate, FileAccess.Read)

                            'Dim mydata() As Byte = New Byte((FS.Length) - 1) {}
                            'FS.Read(mydata, 0, FS.Length)
                            'FS.Close()



                            FbCommand.Parameters.Clear()
                            FbSql = "INSERT INTO C_ATTACHMENT(ATTACHMENT_ID,BLOBATTACHMENT,FILENAME,FILETYPE,FK_DOCUMENTFILE_ID,SECURITY_USER) VALUES (?,?,?,?,?,?)"
                            FbCommand.CommandText = FbSql
                            FbCommand.Parameters.AddWithValue("@ATTACHMENT_ID", lstAttachment.Items(intx).SubItems(0).Text)
                            FbCommand.Parameters.AddWithValue("@BLOBATTACHMENT", RawData)
                            'FbCommand.Parameters.AddWithValue("@BLOBATTACHMENT", mydata)
                            FbCommand.Parameters.AddWithValue("@FILENAME", lstAttachment.Items(intx).SubItems(2).Text)
                            FbCommand.Parameters.AddWithValue("@FILETYPE", lstAttachment.Items(intx).SubItems(3).Text)
                            FbCommand.Parameters.AddWithValue("@FK_DOCUMENTFILE_ID", lblDocumentFileID.Text)
                            FbCommand.Parameters.AddWithValue("@SECURITY_USER", LoggedUser)
                            FbCommand.ExecuteNonQuery()
                            Call AuditLog("INSERT INTO C_ATTACHMENT(ATTACHMENT_ID,BLOBATTACHMENT,FILENAME,FILETYPE,FK_DOCUMENTFILE_ID,SECURITY_USER) VALUES (" & lstAttachment.Items(intx).SubItems(0).Text & ",BLOB," & lstAttachment.Items(intx).SubItems(2).Text & "," & lstAttachment.Items(intx).SubItems(3).Text & "," & lblDocumentFileID.Text & "," & LoggedUser & ")", TransactionNumber, "UPDATE")
                        End If
                    Next
                    '''''''''''''''''''''
                    'INSERT NEW PDF FILE'
                    '''''''''''''''''''''

                Else
                    'INSERT PDF/BLOB FILE
                    FS = New FileStream(PDFFileInfo.FullName.ToString, FileMode.OpenOrCreate, FileAccess.Read)
                    RawData = New Byte((FS.Length) - 1) {}
                    FS.Read(RawData, 0, FS.Length)
                    FS.Close()
                    FS.Dispose()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'OCR START''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    modFunction.SystemStatus("Performing OCR indexing")
                    doc = PDDocument.load(pdfpath)
                    stripper = New PDFTextStripper
                    OCRstring = stripper.getText(doc)

                    If doc IsNot Nothing Then
                        doc.close()
                    End If

                    Dim OCRbyte() As Byte = System.Text.Encoding.ASCII.GetBytes(OCRstring.ToLower)
                    'For Each b As Byte In array

                    'Next

                    'OCR END''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                    modFunction.SystemStatus("Updating document file")
                    FbCommand.Parameters.Clear()
                    FbCommand.CommandText = "INSERT INTO C_DOCUMENTFILE(DOCUMENTFILE_ID,BLOBFILE,FILENAME,FILESIZE,FK_DOCUMENT_ID,SECURITY_USER,NOTE,OCR,DOCHASH) VALUES (?,?,?,?,?,?,?,?,?)"
                    'GUIDDOCFILE = CreateGuid("DocumentFile")
                    FbCommand.Parameters.AddWithValue("@DOCUMENTFILE_ID", lblDocumentFileID.Text)
                    FbCommand.Parameters.AddWithValue("@BLOBFILE", RawData)
                    FbCommand.Parameters.AddWithValue("@FILENAME", lblFileName.Text)
                    FbCommand.Parameters.AddWithValue("@FILESIZE", Format(PDFFileInfo.Length / 1024, "0.00"))
                    FbCommand.Parameters.AddWithValue("@FK_DOCUMENT_ID", lblID.Text)
                    FbCommand.Parameters.AddWithValue("@SECURITY_USER", LoggedUser)
                    FbCommand.Parameters.AddWithValue("@NOTE", txtNote.Text)
                    FbCommand.Parameters.AddWithValue("@OCR", OCRbyte)
                    FbCommand.Parameters.AddWithValue("@DOCHASH", MD5hashvalue)
                    FbCommand.ExecuteNonQuery()
                    'Call AuditLog(FbCommand.CommandText.ToString, TransactionNumber, "INSERT")
                    'Call AuditLog("INSERT INTO C_DOCUMENTFILE(DOCUMENTFILE_ID,BLOBFILE,FILENAME,FILESIZE,FK_DOCUMENT_ID,SECURITY_USER,NOTE) VALUES(" & lblDocumentFileID.Text & ",BLOB," & lblFileName.Text & "," & Format(PDFFileInfo.Length / 1024, "0.00") & "," & GuidID & "," & LoggedUser & "," & txtNote.Text & ")", TransactionNumber, "INSERT")
                    Call AuditLog("INSERT INTO C_DOCUMENTFILE(DOCUMENTFILE_ID,BLOBFILE,FILENAME,FILESIZE,FK_DOCUMENT_ID,SECURITY_USER,NOTE,OCR) VALUES(" & lblDocumentFileID.Text & ",BLOB," & lblFileName.Text & "," & Format(PDFFileInfo.Length / 1024, "0.00") & "," & GuidID & "," & LoggedUser & "," & txtNote.Text & ",BLOB)", TransactionNumber, "UPDATE")

                    'INSERT INTO L_TAG TABLE
                    modFunction.SystemStatus("Updating index")
                    For counterX = 0 To lstTag.Items.Count - 1
                        'If lstTag.Items(counterX).SubItems(2).Text <> "" Then
                        FbSql = "INSERT INTO L_TAG(FK_DOCUMENTFILE_ID,FK_COLUMNNAME_ID,SECURITY_USER,TEXT) VALUES ('" & lblDocumentFileID.Text & "','" & lstTag.Items(counterX).SubItems(0).Text & "','" & LoggedUser & "','" & lstTag.Items(counterX).SubItems(2).Text & "')"
                        FbCommand.CommandText = FbSql
                        FbCommand.ExecuteNonQuery()
                        Call AuditLog(FbCommand.CommandText.ToString, TransactionNumber, "UPDATE")
                        'End If
                    Next

                    'DELETE ATTACHMENT NOT IN LISTVIEW

                    Dim FBdatatable As New DataTable
                    'Dim DBDataAdapter As New OdbcDataAdapter
                    '''''''''''''''
                    modFunction.SystemStatus("Updating attachment")
                    FBdatatable.Columns.Add("BLOBATTACHMENT", System.Type.GetType("System.Byte[]"))
                    FBdatatable.Columns.Add("FILENAME", GetType(String))
                    FBdatatable.Columns.Add("FILETYPE", GetType(String))
                    'INSERT CURRENT ATTACHMENTS TO DATATABE ELSE
                    'INSERT TO DATABASE
                    For intZ = 0 To lstAttachment.Items.Count - 1
                        If lstAttachment.Items(intZ).SubItems(1).Text = "" Then
                            FbSql = "SELECT * FROM C_ATTACHMENT WHERE ATTACHMENT_ID = '" & lstAttachment.Items(intZ).Text & "' "
                            FbCommand.CommandText = FbSql
                            FBreader = FbCommand.ExecuteReader
                            FBreader.Read()
                            FBdatatable.Rows.Add(FBreader!BLOBATTACHMENT, FBreader!FILENAME.ToString, FBreader!FILETYPE.ToString)
                            FBreader.Close()

                        Else
                            'NEW ATTACHMENTS
                            FS = New FileStream(lstAttachment.Items(intZ).SubItems(1).Text, FileMode.OpenOrCreate, FileAccess.Read)
                            RawData = New Byte((FS.Length) - 1) {}
                            FS.Read(RawData, 0, FS.Length)
                            FS.Close()


                            FbCommand.Parameters.Clear()
                            FbSql = "INSERT INTO C_ATTACHMENT(ATTACHMENT_ID,BLOBATTACHMENT,FILENAME,FILETYPE,FK_DOCUMENTFILE_ID,SECURITY_USER) VALUES (?,?,?,?,?,?)"
                            FbCommand.CommandText = FbSql
                            FbCommand.Parameters.AddWithValue("@ATTACHMENT_ID", lstAttachment.Items(intZ).SubItems(0).Text)
                            FbCommand.Parameters.AddWithValue("@BLOBATTACHMENT", RawData)
                            FbCommand.Parameters.AddWithValue("@FILENAME", lstAttachment.Items(intZ).SubItems(2).Text)
                            FbCommand.Parameters.AddWithValue("@FILETYPE", lstAttachment.Items(intZ).SubItems(3).Text)
                            FbCommand.Parameters.AddWithValue("@FK_DOCUMENTFILE_ID", lblDocumentFileID.Text)
                            FbCommand.Parameters.AddWithValue("@SECURITY_USER", LoggedUser)
                            FbCommand.ExecuteNonQuery()

                            'Call AuditLog(FbCommand.CommandText.ToString, TransactionNumber, "INSERT")
                            Call AuditLog("INSERT INTO C_ATTACHMENT(ATTACHMENT_ID,BLOBATTACHMENT,FILENAME,FILETYPE,FK_DOCUMENTFILE_ID,SECURITY_USER) VALUES (" & lstAttachment.Items(intZ).SubItems(0).Text & ",BLOB," & lstAttachment.Items(intZ).SubItems(2).Text & "," & lstAttachment.Items(intZ).SubItems(3).Text & "," & lblDocumentFileID.Text & "," & LoggedUser & ")", TransactionNumber, "UPDATE")
                        End If

                    Next
                    'INSERT ATTACHMENTS FROM DATATABLE
                    Dim intB As Integer = 0
                    Dim GUIDATTACHMENT As String
                    GUIDATTACHMENT = CreateGuid("Attachment")
                    For Each qrow In FBdatatable.Rows
                        FbCommand.Parameters.Clear()
                        FbSql = "INSERT INTO C_ATTACHMENT(ATTACHMENT_ID,BLOBATTACHMENT,FILENAME,FILETYPE,FK_DOCUMENTFILE_ID,SECURITY_USER) VALUES (?,?,?,?,?,?)"
                        FbCommand.CommandText = FbSql
                        GUIDATTACHMENT = CreateGuid("Attachment")
                        FbCommand.Parameters.AddWithValue("@ATTACHMENT_ID", GUIDATTACHMENT)
                        FbCommand.Parameters.AddWithValue("@BLOBATTACHMENT", qrow("BLOBATTACHMENT"))
                        FbCommand.Parameters.AddWithValue("@FILENAME", qrow("FILENAME"))
                        FbCommand.Parameters.AddWithValue("@FILETYPE", qrow("FILETYPE"))
                        FbCommand.Parameters.AddWithValue("@FK_DOCUMENTFILE_ID", lblDocumentFileID.Text)
                        FbCommand.Parameters.AddWithValue("@SECURITY_USER", LoggedUser)
                        FbCommand.ExecuteNonQuery()
                        'Call AuditLog(FbCommand.CommandText.ToString, TransactionNumber, "INSERT")
                        Call AuditLog("INSERT INTO C_ATTACHMENT(ATTACHMENT_ID,BLOBATTACHMENT,FILENAME,FILETYPE,FK_DOCUMENTFILE_ID,SECURITY_USER) VALUES (" & GUIDATTACHMENT & ",BLOB," & qrow("FILENAME") & "," & qrow("FILETYPE") & "," & lblDocumentFileID.Text & "," & LoggedUser & ")", TransactionNumber, "UPDATE")
                    Next



                    'For intX = 0 To lstAttachment.Items.Count - 1
                    '    FS = New FileStream(lstAttachment.Items(intX).SubItems(1).Text, FileMode.Open, FileAccess.Read)
                    '    RawData = New Byte(FS.Length) {}
                    '    FS.Read(RawData, 0, FS.Length)
                    '    FS.Close()

                    '    FbCommand.Parameters.Clear()
                    '    FbSql = "INSERT INTO C_ATTACHMENT(ATTACHMENT_ID,BLOBATTACHMENT,FILENAME,FILETYPE,FK_DOCUMENTFILE_ID,SECURITY_USER) VALUES (?,?,?,?,?,?)"
                    '    FbCommand.CommandText = FbSql
                    '    FbCommand.Parameters.AddWithValue("@ATTACHMENT_ID", lstAttachment.Items(intX).SubItems(0).Text)
                    '    FbCommand.Parameters.AddWithValue("@BLOBATTACHMENT", RawData)
                    '    FbCommand.Parameters.AddWithValue("@FILENAME", lstAttachment.Items(intX).SubItems(2).Text)
                    '    FbCommand.Parameters.AddWithValue("@FILETYPE", lstAttachment.Items(intX).SubItems(3).Text)
                    '    FbCommand.Parameters.AddWithValue("@FK_DOCUMENTFILE_ID", GUIDDOCFILE)
                    '    FbCommand.Parameters.AddWithValue("@SECURITY_USER", LoggedUser)
                    '    FbCommand.ExecuteNonQuery()
                    'Next

                    FBdatatable.Clear()

                End If






            End If

            FBtransaction.Commit()
            lblID.Text = GuidID
            'lblDocumentFileID.Text = GUIDDOCFILE
            modFunction.SystemStatus("Document saved successfully")
            MsgBox("Saved successful", vbInformation, My.Application.Info.Title.ToString)

        Catch ex As Exception
            modFunction.SystemStatus("Save error. Please print this screen and show it to the system admin.")
            MsgBox(ex.Message & vbNewLine & vbNewLine & FbCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
            FBtransaction.Rollback()
        Finally
            FbConnection.Close()
            FbCommand.Dispose()
        End Try
        Me.Cursor = Cursors.Default
        Call Proc_btnSave(Me.Name)
        modFunction.SystemStatus()
    End Sub



#End Region


#Region "NEW"
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Call Proc_btnNew(Me.Name)
    End Sub
#End Region


#Region "DELETE"

    'DELETE
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim FBTransaction As OdbcTransaction = Nothing
        Dim FbReader As OdbcDataReader = Nothing
        Dim DocumentIDArray(50) As String
        Dim CounterA As Integer = 0
        If MsgBox("Are you sure you want to delete? This process is irreversible. Continue?", MsgBoxStyle.YesNo, "Delete Document") = MsgBoxResult.Yes Then
            Try
                Call FBirdConnectionOpen()
                modFunction.SystemStatus("Deleting document")
                FbCommand.Connection = FbConnection
                FBTransaction = FbConnection.BeginTransaction
                FbCommand.Transaction = FBTransaction

                FbCommand.CommandText = "SELECT NEXT VALUE FOR GEN_SECURITY_TRANSACTION_ID FROM RDB$DATABASE;"
                TransactionNumber = FbCommand.ExecuteScalar
                modFunction.SystemStatus("Delete document file")
                FbCommand.CommandText = "SELECT DOCUMENTFILE_ID FROM C_DOCUMENTFILE WHERE FK_DOCUMENT_ID = '" & lblID.Text & "' "
                FbReader = FbCommand.ExecuteReader

                While FbReader.Read

                    DocumentIDArray(CounterA) = FbReader!DOCUMENTFILE_ID
                    CounterA = CounterA + 1

                End While
                FbReader.Close()
                modFunction.SystemStatus("Delete history")
                For Each VALUE In DocumentIDArray
                    'DELETE L_TAG
                    If VALUE <> Nothing Then

                        FbCommand.CommandText = "DELETE FROM L_TAG WHERE FK_DOCUMENTFILE_ID = '" & VALUE & "' "
                        FbCommand.ExecuteNonQuery()
                        Call AuditLog(FbCommand.CommandText.ToString, TransactionNumber, "DELETE")
                        'DELETE ATTACHMENT
                        FbCommand.CommandText = "DELETE FROM C_ATTACHMENT WHERE FK_DOCUMENTFILE_ID = '" & VALUE & "' "
                        FbCommand.ExecuteNonQuery()
                        Call AuditLog(FbCommand.CommandText.ToString, TransactionNumber, "DELETE")
                    End If

                Next


                'DELETE DOCUMENTFILE
                FbCommand.CommandText = "DELETE FROM C_DOCUMENTFILE WHERE FK_DOCUMENT_ID = '" & lblID.Text & "' "
                FbCommand.ExecuteNonQuery()
                Call AuditLog(FbCommand.CommandText.ToString, TransactionNumber, "DELETE")
                'DELETE DOCUMENT
                FbCommand.CommandText = "DELETE FROM C_DOCUMENT WHERE DOCUMENT_ID = '" & lblID.Text & "' "
                FbCommand.ExecuteNonQuery()
                Call AuditLog(FbCommand.CommandText.ToString, TransactionNumber, "DELETE")
                FBTransaction.Commit()
                modFunction.SystemStatus("Deletion success")
                MsgBox("Delete successful", vbInformation, My.Application.Info.Title.ToString)
                Call Proc_btnDelete(Me.Name)
            Catch ex As Exception
                modFunction.SystemStatus("Delete document error. Please print this screen and show it to the system admin.")
                MsgBox(ex.Message & vbNewLine & vbNewLine & FbCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
                FBTransaction.Rollback()
            Finally
                FbConnection.Close()
                FbCommand.Dispose()
                If FbReader.IsClosed Then
                Else
                    FbReader.Close()
                End If

            End Try


        End If

        modFunction.SystemStatus()

    End Sub

#End Region

#Region "HISTORY"



    Private Sub CmsMenuPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsHistory_Preview.Click
        Dim Fbirdreader As OdbcDataReader = Nothing
        Dim LVITEM As ListViewItem
        Dim picturecol As Integer

        Me.Cursor = Cursors.WaitCursor
        Try
            If lstHistory.SelectedItems(0).Text Is Nothing Then
                Exit Sub
            End If
        Catch ex As Exception
            Beep()
            Exit Sub
        End Try


        'C_DOCUMENTFILE
        ''START DELETE CONTENTS OF TEMP DIRECTORY
        Call Delete_Temp(My.Application.Info.DirectoryPath & "\TEMP\h1$2r1.tmp")
        ''END DELETE CONTENTS OF TEMP DIRECTORY

        With frmViewer

            Try
                Me.Cursor = Cursors.WaitCursor
                Call FBirdConnectionOpen()
                FbCommand = New OdbcCommand
                FbCommand.Connection = FbConnection
                'READ DOCUMENT PROPERTIES
                FbCommand.CommandText = "SELECT * FROM C_DOCUMENTFILE WHERE DOCUMENTFILE_ID = '" & lstHistory.SelectedItems(0).Text & "'"
                Fbirdreader = FbCommand.ExecuteReader
                Fbirdreader.Read()

                .lblFileName.Text = Fbirdreader!FILENAME.ToString
                .lblFileSize.Text = Fbirdreader!FILESIZE.ToString
                .lblUpdatedBy.Text = Fbirdreader!SECURITY_USER.ToString
                .lblDateUpdated.Text = Fbirdreader!TRANSDATE.ToString
                .txtNote.Text = Fbirdreader!NOTE.ToString
                Fbirdreader.Close()

                'READ DOCUMENT TAG
                .lstTag.Items.Clear()
                FbSql = "SELECT COLUMNNAME_ID,COLUMN_NAME,FK_COLUMNGROUP_ID FROM S_COLUMNNAME WHERE FK_COLUMNGROUP_ID = '" & Me.lblGroupID.Text & "' ORDER BY PRIORITY,COLUMN_NAME ASC"
                FbCommand.Connection = FbConnection
                FbCommand.CommandText = FbSql
                Fbirdreader = FbCommand.ExecuteReader

                While Fbirdreader.Read
                    LVITEM = New ListViewItem(Fbirdreader!COLUMNNAME_ID.ToString)
                    LVITEM.SubItems.Add(Fbirdreader!COLUMN_NAME.ToString)
                    LVITEM.SubItems.Add("")
                    .lstTag.Items.Add(LVITEM)
                    'Me.lblGroupID.Text = Fbirdreader!FK_COLUMNGROUP_ID.ToString
                End While
                Fbirdreader.Close()

                FbCommand.CommandText = "SELECT * FROM  L_TAG WHERE FK_DOCUMENTFILE_ID = '" & lstHistory.SelectedItems(0).Text & "'"
                Fbirdreader = FbCommand.ExecuteReader

                While Fbirdreader.Read
                    'Dim counterZ As Integer = 0
                    For item = 0 To .lstTag.Items.Count - 1
                        If .lstTag.Items(item).Text = Fbirdreader!FK_COLUMNNAME_ID.ToString Then
                            '.lstTag.Items(counterZ).Text = Fbirdreader!FK_COLUMNNAME_ID.ToString
                            '.lstTag.Items(counterZ).SubItems(2).Text = Fbirdreader!COLUMN_NAME.ToString
                            .lstTag.Items(item).SubItems(2).Text = Fbirdreader!TEXT.ToString
                            '.lstTag.Items.Add(LVitem)
                        Else
                            '.lstTag.Items(item).SubItems(2).Text = ""
                        End If
                        'counterZ = counterZ + 1
                    Next

                End While
                Fbirdreader.Close()

                'READ ATTACHMENT
                FbCommand.CommandText = "SELECT * FROM C_ATTACHMENT WHERE FK_DOCUMENTFILE_ID = '" & lstHistory.SelectedItems(0).Text & "' "
                Fbirdreader = FbCommand.ExecuteReader
                .lstAttachment.Items.Clear()
                While Fbirdreader.Read
                    LVITEM = New ListViewItem(Fbirdreader!ATTACHMENT_ID.ToString)
                    LVITEM.SubItems.Add("")
                    LVITEM.SubItems.Add(Fbirdreader!FILENAME.ToString)
                    LVITEM.SubItems.Add(Fbirdreader!FILETYPE.ToString)
                    .lstAttachment.Items.Add(LVITEM)
                End While
                Fbirdreader.Close()

                'READ BLOB
                'READ BLOB FILE
                FbSql = "SELECT BLOBFILE FROM C_DOCUMENTFILE WHERE DOCUMENTFILE_ID = '" & lstHistory.SelectedItems(0).Text & "' ORDER BY TRANSDATE DESC"
                FbCommand.CommandText = FbSql
                Fbirdreader = FbCommand.ExecuteReader
                Fbirdreader.Read()
                Dim b(Fbirdreader.GetBytes(picturecol, 0, Nothing, 0, Integer.MaxValue) - 1) As Byte
                'Dim fs As New FileStream(My.Application.Info.DirectoryPath & "\TEMP\h1$2r1.tmp", FileMode.Create, FileAccess.Write)
                'Fbirdreader.GetBytes(picturecol, 0, b, 0, b.Length)
                'fs.Write(b, 0, b.Length)
                'fs.Close()
                Fbirdreader.GetBytes(picturecol, 0, b, 0, b.Length)
                IO.File.WriteAllBytes(My.Application.Info.DirectoryPath & "\TEMP\h1$2r1.tmp", b)




            Catch ex As Exception
                MsgBox(ex.Message & vbNewLine & vbNewLine & FbCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)

            Finally
                Fbirdreader.Close()
                FbConnection.Close()
                FbCommand.Dispose()
            End Try

            frmViewer.Show()
            .axDocument.src = My.Application.Info.DirectoryPath & "\TEMP\h1$2r1.tmp"
            .axDocument.setShowScrollbars(False)
            .axDocument.setShowToolbar(False)
            .axDocument.setPageMode("none")
            .Cursor = Cursors.Default
            .axDocument.setView("FIT")
        End With

        Me.Cursor = Cursors.Default
    End Sub

#End Region

#Region "RESIZE FORM"

    Private Sub frmDocument_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.axDocument.Top = 10
        Me.axDocument.Left = 10
        Me.axDocument.Height = Me.Height - 90
        Me.axDocument.Width = Me.Width - 380


        GroupBox1.Left = axDocument.Width + 25
        GroupBox2.Left = axDocument.Width + 25
        TabDocument.Left = axDocument.Width + 25
        TabDocument.Height = Me.Height - 370
        lstAttachment.Height = TabDocument.Height - 60
        lstTag.Height = lstAttachment.Height + 25
        lstHistory.Height = lstTag.Height

        Me.btnDelete.Top = Me.Height - 73
        Me.btnDelete.Left = Me.Width - 93

        Me.btnSave.Top = Me.Height - 73
        Me.btnSave.Left = Me.Width - 174

        Me.btnNew.Top = Me.Height - 73
        Me.btnNew.Left = Me.Width - 255

        Me.btnPDF.Top = Me.Height - 73
        Me.btnPrint.Top = Me.Height - 73
        'Me.btnPDF.Left = Me.Width - 785
        Me.btnAttachment.Top = TabDocument.Height - 50
        Me.btnAttachment.Left = TabDocument.Width - 48

        Me.btnRollback.Top = Me.Height - 73
        Me.btnRollback.Left = Me.Width - 369

    End Sub

#End Region


#Region "Attachments"
  

    Private Sub cmsAttachment_Download_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAttachment_Download.Click
        Dim FBreader As OdbcDataReader = Nothing
        Dim picturecol As Integer = 0
        Dim sfdAttachment As New SaveFileDialog

        'Dim fbAttachment As New FolderBrowserDialog

        Try
            If lstAttachment.SelectedItems(0).Text Is Nothing Then
                Exit Sub
            End If
        Catch ex As Exception
            Beep()
            Exit Sub
        End Try


        sfdAttachment.RestoreDirectory = True
        sfdAttachment.OverwritePrompt = True
        sfdAttachment.FileName = lstAttachment.SelectedItems(0).SubItems(2).Text

        'sfdAttachment.ShowDialog()

        'CHECK IF CANCEL BUTTON IS CLICKED
        If sfdAttachment.ShowDialog(Me) = DialogResult.Cancel Then Exit Sub
        'fbAttachment.ShowDialog()
        'If fbAttachment.SelectedPath = Nothing Then Exit Sub
        If sfdAttachment.FileName = Nothing Then
            Exit Sub
        End If

        'Condition to check for ovewrrite file 
        If sfdAttachment.OverwritePrompt = vbNo Then
            Exit Sub
        End If

        Try
            Call FBirdConnectionOpen()
            FbCommand.Connection = FbConnection


            FbCommand.CommandText = "SELECT BLOBATTACHMENT FROM C_ATTACHMENT WHERE ATTACHMENT_ID = '" & lstAttachment.SelectedItems(0).Text & "' "
            FBreader = FbCommand.ExecuteReader
            FBreader.Read()

            'Dim b(FBreader.GetBytes(0, 0, Nothing, 0, Integer.MaxValue)) As Byte
            'b = File.ReadAllBytes(FBreader!BLOBATTACHMENT)
            'File.WriteAllBytes(sfdAttachment.FileName, b)
            'b = System.Text.Encoding.ASCII.GetBytes(FbCommand.ExecuteScalar)
            ''FBreader.GetBytes(picturecol, 0, b, 0, b.Length)
            'Dim fs As New FileStream(sfdAttachment.FileName, IO.FileMode.Create, IO.FileAccess.Write)

            Dim b(FBreader.GetBytes(picturecol, 0, Nothing, 0, Integer.MaxValue) - 1) As Byte
            FBreader.GetBytes(picturecol, 0, b, 0, b.Length)
            IO.File.WriteAllBytes(sfdAttachment.FileName, b)




            MsgBox("Attachment downloaded at " & sfdAttachment.FileName & ".", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, My.Application.Info.Title.ToString)

            Process.Start(sfdAttachment.FileName)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, My.Application.Info.Title.ToString)
        Finally

            FBreader.Close()
            FbConnection.Close()
            FbCommand.Dispose()
        End Try
    End Sub

    Private Sub btnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAttachment.Click

        Dim ofdAttachment As New OpenFileDialog
        Dim lviTEM As ListViewItem


        ofdAttachment.Filter = "supported attachment file(image,pdf,document,spreadsheet)|*.pdf;*.jpg;*.jpeg;*.tif;*.doc;*.docx;*.xls;*.txt"
        ofdAttachment.FilterIndex = 1
        ofdAttachment.RestoreDirectory = True
        ofdAttachment.Multiselect = True
        ofdAttachment.ShowDialog()

        'While ofdAttachment.FileNames.Count
        'For Each File In ofdAttachment.FileNames

        For x = 0 To ofdAttachment.FileNames.Count - 1


            If ofdAttachment.FileName <> Nothing Then
                lviTEM = New ListViewItem(CreateGuid("Attachment"))
                lviTEM.SubItems.Add(ofdAttachment.FileNames(x))

                lviTEM.SubItems.Add(ofdAttachment.SafeFileNames(x))
                lviTEM.SubItems.Add(IO.Path.GetExtension(ofdAttachment.FileNames(x)))
                lstAttachment.Items.Add(lviTEM)

            End If
        Next

    End Sub

    Private Sub cmsAttachment_Remove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAttachment_Remove.Click
        Try
            If lstAttachment.SelectedItems(0).Text Is Nothing Then
                Exit Sub
            End If
        Catch ex As Exception
            Beep()
            Exit Sub
        End Try

        lstAttachment.SelectedItems(0).Remove()
    End Sub


#End Region

    Private Sub lstTag_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstTag.MouseHover
        modFunction.SystemStatus("Right click this control to show options")
    End Sub

    Private Sub lstTag_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstTag.MouseLeave
        modFunction.SystemStatus()
    End Sub


    Private Sub lstTag_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstTag.SelectedIndexChanged

    End Sub





    Private Sub axDocument_OnError(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles axDocument.OnError

    End Sub


    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        modFunction.SystemStatus("Print Pdf Document")
        axDocument.printWithDialog()
        modFunction.SystemStatus()
    End Sub

    Private Sub btnRollback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRollback.Click
        'Dim FbTransaction As OdbcTransaction
        'Dim FbReader As OdbcDataReader = Nothing
        Dim docFileId As String
        Dim FBTransaction As OdbcTransaction = Nothing

        If lstHistory.Items.Count = 0 Then
            MsgBox("Cannot rollback. No previous history.", vbInformation + MsgBoxStyle.OkOnly, "Rollback")
            Exit Sub
        End If


        If MsgBox("This process is irreversible. Do you want to continue?", vbInformation + MsgBoxStyle.YesNo, "Rollback") = vbNo Then
            Exit Sub
        End If

        modFunction.SystemStatus("Rollback document")


        Try
            Call FBirdConnectionOpen()
            FbCommand = New OdbcCommand
            FbCommand.Connection = FbConnection
            FBTransaction = FbConnection.BeginTransaction
            FbCommand.Transaction = FBTransaction

            FbCommand.CommandText = "SELECT NEXT VALUE FOR GEN_SECURITY_TRANSACTION_ID FROM RDB$DATABASE;"
            TransactionNumber = FbCommand.ExecuteScalar
            modFunction.SystemStatus("Deleting current document")
            FbCommand.CommandText = "SELECT DOCUMENTFILE_ID FROM C_DOCUMENTFILE WHERE FK_DOCUMENT_ID = '" & lblID.Text & "' ORDER BY FILEHISTORY DESC"
            docFileId = FbCommand.ExecuteScalar

            FbCommand.CommandText = "DELETE FROM L_TAG wHERE FK_DOCUMENTFILE_ID = '" & docFileId & "' "
            FbCommand.ExecuteNonQuery()
            Call AuditLog(FbCommand.CommandText.ToString, TransactionNumber, "ROLLBACK")
            modFunction.SystemStatus("Restoring history")
            FbCommand.CommandText = "DELETE FROM C_ATTACHMENT wHERE FK_DOCUMENTFILE_ID = '" & docFileId & "' "
            FbCommand.ExecuteNonQuery()
            Call AuditLog(FbCommand.CommandText.ToString, TransactionNumber, "ROLLBACK")

            FbCommand.CommandText = "DELETE FROM C_DOCUMENTFILE wHERE DOCUMENTFILE_ID = '" & docFileId & "' "
            FbCommand.ExecuteNonQuery()
            Call AuditLog(FbCommand.CommandText.ToString, TransactionNumber, "ROLLBACK")




            FBTransaction.Commit()
            Call Proc_btnDelete(Me.Name)
            modFunction.SystemStatus("Rollback Successful")
            MsgBox("Rollback Completed.", vbInformation + MsgBoxStyle.OkOnly, "Rollback")

        Catch ex As Exception
            modFunction.SystemStatus("Rollback error. Please print this screen and show it to the system admin.")
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, My.Application.Info.Title.ToString)
            FBTransaction.Rollback()
        Finally
            FBTransaction.Dispose()
            FbCommand.Dispose()
            FbConnection.Close()

        End Try

        modFunction.SystemStatus()
    End Sub

 

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PictureBox1.Top = axDocument.Top
    '    PictureBox1.Left = axDocument.Left
    '    PictureBox1.Height = axDocument.Height
    '    PictureBox1.Width = axDocument.Width
    '    PictureBox1.BackColor = Color.Red

    'End Sub



    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsIndex_Delete.Click
        Me.lstTag.SelectedItems(0).SubItems(2).Text = Nothing
    End Sub

    Private Sub cmsIndex_Insert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsIndex_Insert.Click
        Call ShowDialoguePanel("Edit Tag", lstTag.SelectedItems(0).SubItems(2).Text)
        frmDialogueBox.ShowDialog()
        frmDialogueBox.txtEditTag.Focus()
    End Sub




    'Dim objApp As Object
    'Dim objPDDoc As Object
    'Dim objjso As Object
    'Dim wordsCount As Long
    'Dim page As Long
    'Dim i As Long
    'Dim strData As String = Nothing
    'Dim strFileName As String


    'strFileName = Microsoft.VisualBasic.Right(axDocument.src.ToString, Microsoft.VisualBasic.Len(axDocument.src) - 7)

    'objApp = CreateObject("AcroExch.App")
    'objPDDoc = CreateObject("AcroExch.PDDoc")
    ''AD.1 open file, if =false file is damage
    'If objPDDoc.Open(strFileName) Then
    '    objjso = objPDDoc.GetJSObject
    '    For page = 0 To objPDDoc.GetNumPages - 1
    '        wordsCount = objjso.GetPageNumWords(page)
    '        For i = 0 To wordsCount
    '            'AD.2 Set text to variable strData
    '            strData = strData & " " & objjso.getPageNthWord(page, i)
    '        Next i
    '    Next
    '    MsgBox(strData)
    'Else
    '    MsgBox("error!")
    'End If


    Private Sub btnRollback_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRollback.MouseHover
        modFunction.SystemStatus("Rollback current document based from previous history. Applicable for documents with history")
    End Sub

    Private Sub btnRollback_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRollback.MouseLeave
        modFunction.SystemStatus()
    End Sub

    Private Sub AddAttachmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAttachment_Add.Click

        Dim ofdAttachment As New OpenFileDialog
        Dim lviTEM As ListViewItem


        ofdAttachment.Filter = "supported attachment file(image,pdf,document,spreadsheet)|*.pdf;*.jpg;*.jpeg;*.tif;*.doc;*.docx;*.xls;*.txt"
        ofdAttachment.FilterIndex = 1
        ofdAttachment.RestoreDirectory = True
        ofdAttachment.ShowDialog()

        If ofdAttachment.FileName <> Nothing Then
            lviTEM = New ListViewItem(CreateGuid("Attachment"))
            lviTEM.SubItems.Add(ofdAttachment.FileName)
            lviTEM.SubItems.Add(ofdAttachment.SafeFileName)
            lviTEM.SubItems.Add(IO.Path.GetExtension(ofdAttachment.FileName))
            lstAttachment.Items.Add(lviTEM)

        End If
    End Sub

    Private Sub lstAttachment_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstAttachment.MouseHover
        modFunction.SystemStatus("Right click this control to show options")
    End Sub

    Private Sub lstAttachment_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstAttachment.MouseLeave
        modFunction.SystemStatus()
    End Sub

    Private Sub lstAttachment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstAttachment.SelectedIndexChanged

    End Sub

    Private Sub lstHistory_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstHistory.MouseHover
        modFunction.SystemStatus("Right click this control to show options")
    End Sub

    Private Sub lstHistory_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstHistory.MouseLeave
        modFunction.SystemStatus()
    End Sub

    Private Sub lstHistory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstHistory.SelectedIndexChanged
        modFunction.SystemStatus()
    End Sub

    Private Sub btnNew_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.MouseHover
        modFunction.SystemStatus("Create new document based on current document group")
    End Sub

    Private Sub btnNew_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.MouseLeave
        modFunction.SystemStatus()
    End Sub
End Class