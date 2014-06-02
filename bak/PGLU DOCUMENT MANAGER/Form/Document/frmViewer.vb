Imports System.IO
Imports System.Data.Odbc
Public Class frmViewer

    Dim scrollbar As Integer = 0
    Private Sub frmViewer_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

    End Sub

    Private Sub frmViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PGLU_Doc_Manager
        Call Security_privilege()
        Me.axDocument.Top = 10
        Me.axDocument.Left = 10
        Me.axDocument.Height = Me.Height - 90
        Me.axDocument.Width = Me.Width - 385

        lstAttachment.ContextMenuStrip = Me.cmsAttachment

    End Sub

    Private Sub frmViewer_MdiChildActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MdiChildActivate

    End Sub

    Private Sub frmViewer_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.axDocument.Top = 10
        Me.axDocument.Left = 10
        Me.axDocument.Height = Me.Height - 89
        Me.axDocument.Width = Me.Width - 380

        GroupBox1.Left = axDocument.Width + 25
        GroupBox2.Left = axDocument.Width + 25
        TabDocument.Left = axDocument.Width + 25
        TabDocument.Height = Me.Height - 370
        lstAttachment.Height = TabDocument.Height - 40
        lstTag.Height = lstAttachment.Height

        Me.btnClose.Top = Me.Height - 73
        Me.btnClose.Left = Me.Width - 99

        Me.grpPdf.Top = Me.axDocument.Top '- 1
        Me.grpPdf.Left = Me.axDocument.Left '- 1
        Me.grpPdf.Height = Me.axDocument.Height '+ 2
        Me.grpPdf.Width = Me.axDocument.Width '+ 2

        btnPrevious.Top = grpPdf.Height + 15
        btnNext.Top = grpPdf.Height + 15
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub tsmAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmAttachment.Click
        Dim FBreader As OdbcDataReader = Nothing
        Dim picturecol As Integer
        Dim sfdAttachment As New SaveFileDialog


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
        'CHECK IF CANCEL BUTTON IS CLICKED
        If sfdAttachment.ShowDialog(Me) = DialogResult.Cancel Then Exit Sub
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

            'FbCommand.CommandText = "SELECT FILENAME FROM C_ATTACHMENT WHERE ATTACHMENT_ID = '" & lstAttachment.Items(0).Text & "' "
            'FBreader = FbCommand.ExecuteReader


            'Call Delete_Temp(My.Application.Info.DirectoryPath & "\TEMP\a+@chM3n+.tmp")
            FbCommand.CommandText = "SELECT BLOBATTACHMENT FROM C_ATTACHMENT WHERE ATTACHMENT_ID = '" & lstAttachment.SelectedItems(0).Text & "' "
            FBreader = FbCommand.ExecuteReader
            FBreader.Read()
            'Dim b(FBreader.GetBytes(picturecol, 0, Nothing, 0, Integer.MaxValue) - 1) As Byte
            'Dim fs As New FileStream(sfdAttachment.FileName & "." & lstAttachment.SelectedItems(0).SubItems(3).Text, FileMode.Create, FileAccess.Write)
            'FBreader.GetBytes(picturecol, 0, b, 0, b.Length)
            'FBreader.GetBytes(,,,,
            'fs.Write(b, 0, b.Length)
            'fs.Close()
            'FBreader.Close()
            Dim b(FBreader.GetBytes(picturecol, 0, Nothing, 0, Integer.MaxValue) - 1) As Byte
            FBreader.GetBytes(picturecol, 0, b, 0, b.Length)
            IO.File.WriteAllBytes(sfdAttachment.FileName, b)

            MsgBox("Attachment downloaded at " & sfdAttachment.FileName & ".", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, My.Application.Info.Title.ToString)


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, My.Application.Info.Title.ToString)
        Finally

            FBreader.Close()
            FbConnection.Close()
            FbCommand.Dispose()
        End Try


    End Sub



    Private Sub frmViewer_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.axDocument.setShowScrollbars(False)
        Me.axDocument.setShowToolbar(False)
        Me.axDocument.setPageMode("none")
    End Sub




    Private Sub btnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevious.Click
        axDocument.gotoPreviousPage()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        axDocument.gotoNextPage()
    End Sub
End Class