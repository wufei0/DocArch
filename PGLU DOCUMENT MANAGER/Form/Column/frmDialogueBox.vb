Public Class frmDialogueBox

    Private Sub frmDialogueBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub pnlNewDoc_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlNewDoc.Paint


    End Sub

    Private Sub btnNewDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewDoc.Click
        If cboNewDoc.SelectedIndex = -1 Then
            Exit Sub
        Else
            'INITIALIZE LISTVIEW/TAG COLUMNS ACCORDING TO SELECTED GROUP
            Dim ID As String    'HOLDER OF GROUP ID PK
            ID = GetIDComboBox("SELECT COLUMNGROUP_ID FROM S_COLUMNGROUP WHERE GROUP_NAME = '" & cboNewDoc.Text & "' ")
            Call Proc_btnNew("frmDocument")
            Call NEW_DOCUMENT_LISTVIEW(ID)

            frmDocument.Show()
            ''frmDocument.axDocument.src = Nothing
            ''frmDocument.axDocument.Dispose()
            ''frmDocument.axDocument.Refresh()
            'frmDocument.axDocument.LoadFile = Nothing
            Me.Close()

        End If



    End Sub

    Private Sub btnEditTag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditTag.Click
        With frmDocument
            .lstTag.SelectedItems(0).SubItems(2).Text = txtEditTag.Text
        End With
        Me.Close()
    End Sub

    Private Sub txtEditTag_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEditTag.KeyPress
        If e.KeyChar = Chr(13) Then btnEditTag.PerformClick()
    End Sub

    Private Sub txtEditTag_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEditTag.TextChanged

    End Sub
End Class