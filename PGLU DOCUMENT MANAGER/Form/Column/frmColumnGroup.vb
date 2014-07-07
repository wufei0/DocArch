Imports System.Data.Odbc

Public Class frmColumnGroup
    Private m_SortingColumn As ColumnHeader

    Private Sub frmColumnGroup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PGLU_Doc_Manager
        Call Proc_btnDelete(Me.Name)
        Call Security_privilege()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Call Proc_btnNew(Me.Name)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Dim FbRecordset As OdbcDataReader
       
        If txtGroupName.Text = Nothing Then
            Beep()
            Exit Sub
        End If

        Try
            Call FBirdConnectionOpen()
            FbCommand.Connection = FbConnection
            FbCommand.CommandText = "SELECT NEXT VALUE FOR GEN_SECURITY_TRANSACTION_ID FROM RDB$DATABASE;"
            TransactionNumber = FbCommand.ExecuteScalar

            If lblID.Text = Nothing Then
                Dim gUIDID As String = CreateGuid(Me.Name)
                FbSql = "INSERT INTO S_COLUMNGROUP(COLUMNGROUP_ID,GROUP_NAME,DESCRIPTION,SECURITY_USER) "
                FbSql = FbSql & "VALUES ('" & gUIDID & "','" & txtGroupName.Text.ToUpper & "','" & txtGroupDescription.Text.ToUpper & "','" & LoggedUser & "')"

                FbCommand.CommandText = FbSql
                FbCommand.ExecuteNonQuery()
                lblID.Text = gUIDID

                Call AuditLog(FbCommand.CommandText.ToString, TransactionNumber, "INSERT")
                ''''''''''''''''''''''''''''
            Else    'IF LBLID/PK IS PRESENT
                ''''''''''''''''''''''''''''
                FbSql = "UPDATE S_COLUMNGROUP SET GROUP_NAME = '" & txtGroupName.Text.ToString & "',DESCRIPTION = '" & txtGroupDescription.Text.ToUpper & "',  "
                FbSql = FbSql & "SECURITY_USER = '" & LoggedUser & "' WHERE COLUMNGROUP_ID = '" & lblID.Text & "' "

                FbCommand.CommandText = FbSql
                FbCommand.ExecuteNonQuery()
                Call AuditLog(FbCommand.CommandText.ToString, TransactionNumber, "UPDATE")
            End If



            MsgBox("Group saved successful", vbInformation, My.Application.Info.Title.ToString)

        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & FbCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
        Finally
            FbConnection.Close()
            FbCommand.Dispose()
        End Try

        Call Proc_btnSave(Me.Name)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        If MsgBox("Confirm to delete.", vbOKCancel + vbInformation, My.Application.Info.Title.ToString) = vbCancel Then Exit Sub

        Try
            FbCommand = New OdbcCommand
            Call FBirdConnectionOpen()
            FbCommand.Connection = FbConnection

            FbCommand.CommandText = "SELECT NEXT VALUE FOR GEN_SECURITY_TRANSACTION_ID FROM RDB$DATABASE;"
            TransactionNumber = FbCommand.ExecuteScalar

            FbCommand.CommandText = "DELETE FROM S_COLUMNGROUP WHERE COLUMNGROUP_ID = '" & lblID.Text & "'"
            FbCommand.ExecuteNonQuery()
            Call AuditLog(FbCommand.CommandText.ToString, TransactionNumber, "DELETE")

            MsgBox("Group deleted successful", vbInformation, My.Application.Info.Title.ToString)
        Catch ex As Exception
            If ex.Message.Contains("FK_S_COLUMNNAME_0") Then
                MsgBox("Group still in use. Delete failed", MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
            Else

                MsgBox(ex.Message & vbNewLine & vbNewLine & FbCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
            End If

        Finally
            FbConnection.Close()
            FbCommand.Dispose()
        End Try
        Call Proc_btnDelete(Me.Name)
    End Sub

    Private Sub lstTagGroup_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstTagGroup.ColumnClick


        ' Get the new sorting column.  

        Dim new_sorting_column As ColumnHeader = lstTagGroup.Columns(e.Column)
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
        lstTagGroup.ListViewItemSorter = New clsListviewSorter(e.Column, sort_order)
        ' Sort.  
        lstTagGroup.Sort()
    End Sub

    Private Sub lstTagGroup_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstTagGroup.DoubleClick
        Dim FBRecordset As OdbcDataReader
        Try
            FbCommand = New OdbcCommand
            Call FBirdConnectionOpen()
            FbSql = "SELECT * FROM S_COLUMNGROUP WHERE COLUMNGROUP_ID = '" & lstTagGroup.SelectedItems(0).Text & "'"
            FbCommand.Connection = FbConnection
            FbCommand.CommandText = FbSql
            FBRecordset = FbCommand.ExecuteReader
            FBRecordset.Read()
            lblID.Text = FBRecordset!COLUMNGROUP_ID.ToString
            txtGroupName.Text = FBRecordset!GROUP_NAME.ToString
            txtGroupDescription.Text = FBRecordset!DESCRIPTION.ToString
            FBRecordset.Close()
            Call Proc_btnEdit(Me.Name)
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & FbCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
        Finally
            FbCommand.Dispose()
            FbConnection.Close()
        End Try


    End Sub


   
    Private Sub frmColumnGroup_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        txtGroupName.Width = Me.Width - 108 - 30
        txtGroupDescription.Width = Me.Width - 108 - 30
        lstTagGroup.Width = Me.Width - 48

        lstTagGroup.Height = Me.Height - 63 - 89

        btnNew.Top = 63 + lstTagGroup.Height + 18
        btnSave.Top = 63 + lstTagGroup.Height + 18
        btnDelete.Top = 63 + lstTagGroup.Height + 18

        btnNew.Left = Me.Width - 264
        btnSave.Left = Me.Width - 183
        btnDelete.Left = Me.Width - 102

    End Sub

    Private Sub lstTagGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstTagGroup.SelectedIndexChanged

    End Sub
End Class