Imports System.Data.Odbc

Public Class frmColumnName
    Private m_SortingColumn As ColumnHeader
    'Used for SQL carrier for populating the contents for the listview
    'Private lstColumnNameSQL As String = "SELECT COLUMNNAME_ID,COLUMNGROUP_ID,GROUP_NAME,COLUMN_NAME,S_COLUMNNAME.DESCRIPTION,PRIORITY,S_COLUMNNAME.SECURITY_USER,S_COLUMNNAME.TRANSDATE FROM S_COLUMNNAME JOIN S_COLUMNGROUP ON S_COLUMNNAME.FK_COLUMNGROUP_ID=S_COLUMNGROUP.COLUMNGROUP_ID ORDER BY PRIORITY,COLUMN_NAME"
    Private Sub InstantiateNtxtSort()
        txtSortNo = New NumericUpDown
        txtSortNo.Value = 0
        txtSortNo.Minimum = 0

        txtSortNo.DecimalPlaces = 0

    End Sub

    Private Sub frmColumnName_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.MdiParent = PGLU_Doc_Manager
        Call Security_privilege()
        Call Proc_btnDelete(Me.Name)
        Call PopListComboBox(cboGroupName, "SELECT GROUP_NAME FROM S_COLUMNGROUP ORDER BY GROUP_NAME")
        Call PopListComboBox(cboFilter, "SELECT GROUP_NAME FROM S_COLUMNGROUP ORDER BY GROUP_NAME")
        'ComboListIndexIdentifier(cboGroupName)
        'Call Proc_listview(Me.Name, lstColumnNameSQL)
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Call Proc_btnNew(Me.Name)
        'Call PopListComboBox(cboGroupName, "SELECT GROUP_NAME FROM S_COLUMNGROUP ORDER BY GROUP_NAME")
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
     

        lblGroupID.Text = GetIDComboBox("SELECT COLUMNGROUP_ID FROM S_COLUMNGROUP WHERE GROUP_NAME LIKE '" & cboGroupName.Text & "' ")

        If txtColumnName.Text = Nothing Or lblGroupID.Text = Nothing Then
            Beep()
            Exit Sub
            'Else
            '    lblGroupID.Text = GetIDComboBox("SELECT COLUMNGROUP_ID FROM S_COLUMNGROUP WHERE GROUP_NAME = '" & cboGroupName.Text & "'")
        End If

        Try
            Call FBirdConnectionOpen()
            FbCommand = New OdbcCommand
            FbCommand.Connection = FbConnection
            FbCommand.CommandText = "SELECT NEXT VALUE FOR GEN_SECURITY_TRANSACTION_ID FROM RDB$DATABASE;"
            TransactionNumber = FbCommand.ExecuteScalar

            If lblID.Text = Nothing Then
                Dim GUIDID As String = CreateGuid(Me.Name)
                FbSql = "INSERT INTO S_COLUMNNAME(COLUMNNAME_ID,COLUMN_NAME,DESCRIPTION,FK_COLUMNGROUP_ID,PRIORITY,SECURITY_USER) VALUES "
                FbSql = FbSql & "('" & GUIDID & "','" & txtColumnName.Text.ToUpper & "','" & txtColumnDescription.Text.ToUpper & "','" & lblGroupID.Text & "',"
                FbSql = FbSql & txtSortNo.Value & ",'" & LoggedUser & "') "

                FbCommand.CommandText = FbSql
                FbCommand.ExecuteNonQuery()
                lblID.Text = GUIDID
            Else
                FbSql = "UPDATE S_COLUMNNAME SET COLUMN_NAME='" & txtColumnName.Text.ToUpper & "',DESCRIPTION='" & txtColumnDescription.Text.ToUpper & "',"
                FbSql = FbSql & "FK_COLUMNGROUP_ID='" & lblGroupID.Text & "',PRIORITY = " & txtSortNo.Value & ",SECURITY_USER = '" & LoggedUser & "' WHERE "
                FbSql = FbSql & " COLUMNNAME_ID = '" & lblID.Text & "'"

                FbCommand.CommandText = FbSql
                FbCommand.ExecuteNonQuery()
            End If
            Call AuditLog(FbCommand.CommandText.ToString, TransactionNumber, "UPDATE")
            MsgBox("Index successful", vbInformation, My.Application.Info.Title.ToString)

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

            FbCommand.CommandText = "DELETE FROM S_COLUMNNAME WHERE COLUMNNAME_ID = '" & lblID.Text & "'"
            FbCommand.ExecuteNonQuery()
            Call AuditLog(FbCommand.CommandText.ToString, TransactionNumber, "DELETE")

            MsgBox("Index deleted successfully", vbInformation, My.Application.Info.Title.ToString)
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & FbCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
        Finally
            FbConnection.Close()
            FbCommand.Dispose()
        End Try
        Call Proc_btnDelete(Me.Name)
    End Sub

    Private Sub lstColumnName_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstColumnName.ColumnClick


        ' Get the new sorting column.  

        Dim new_sorting_column As ColumnHeader = lstColumnName.Columns(e.Column)
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
        lstColumnName.ListViewItemSorter = New clsListviewSorter(e.Column, sort_order)
        ' Sort.  
        lstColumnName.Sort()
    End Sub

    Private Sub cboFilter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFilter.SelectedIndexChanged
        Dim lstColumnNameSQL As String = "SELECT COLUMNNAME_ID,COLUMNGROUP_ID,GROUP_NAME,COLUMN_NAME,S_COLUMNNAME.DESCRIPTION,PRIORITY,S_COLUMNNAME.SECURITY_USER,S_COLUMNNAME.TRANSDATE FROM S_COLUMNNAME JOIN S_COLUMNGROUP ON S_COLUMNNAME.FK_COLUMNGROUP_ID=S_COLUMNGROUP.COLUMNGROUP_ID WHERE GROUP_NAME = '" & cboFilter.Text & "' ORDER BY GROUP_NAME,PRIORITY,COLUMN_NAME"
        Call Proc_listview(Me.Name, lstColumnNameSQL)
    End Sub

    Private Sub lstColumnName_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstColumnName.DoubleClick
        Dim FBRecordset As OdbcDataReader

        'cboGroupName.SelectedIndex=ComboListIndexIdentifier(cboGroupName,
        'ComboListIndexIdentifier
        cboGroupName.SelectedIndex = ComboListIndetify(cboGroupName, lstColumnName.SelectedItems(0).SubItems(2).Text)
        Try
            FbCommand = New OdbcCommand
            Call FBirdConnectionOpen()
            FbSql = "SELECT * FROM S_COLUMNNAME WHERE COLUMNNAME_ID = '" & lstColumnName.SelectedItems(0).Text & "'"
            FbCommand.Connection = FbConnection
            FbCommand.CommandText = FbSql
            FBRecordset = FbCommand.ExecuteReader
            FBRecordset.Read()
            lblID.Text = FBRecordset!COLUMNNAME_ID.ToString
            lblGroupID.Text = FBRecordset!FK_COLUMNGROUP_ID.ToString
            txtColumnName.Text = FBRecordset!COLUMN_NAME.ToString
            txtColumnDescription.Text = FBRecordset!DESCRIPTION.ToString
            txtSortNo.Value = FBRecordset!PRIORITY
            FBRecordset.Close()
            Call Proc_btnEdit(Me.Name)
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & FbCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)

        Finally
            FbCommand.Dispose()
            FbConnection.Close()
        End Try
    End Sub



    Private Sub lstColumnName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstColumnName.SelectedIndexChanged

    End Sub

  

    Private Sub frmColumnName_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        GroupBox1.Width = Me.Width - 48
        lstColumnName.Width = GroupBox1.Width - 14
        GroupBox1.Height = Me.Height - 200
        lstColumnName.Height = GroupBox1.Height - 50

        cboGroupName.Top = GroupBox1.Height + 27
        txtColumnName.Top = GroupBox1.Height + 56
        txtColumnDescription.Top = GroupBox1.Height + 85
        txtSortNo.Top = GroupBox1.Height + 114
        Label1.Top = cboGroupName.Top
        Label3.Top = txtColumnName.Top
        Label2.Top = txtColumnDescription.Top
        Label4.Top = txtSortNo.Top

        cboGroupName.Width = GroupBox1.Width - 126
        txtColumnName.Width = GroupBox1.Width - 126
        txtColumnDescription.Width = GroupBox1.Width - 126
        txtSortNo.Width = GroupBox1.Width - 126

        btnNew.Top = Me.Height - 63
        btnSave.Top = Me.Height - 63
        btnDelete.Top = Me.Height - 63

        btnNew.Left = Me.Width - 280
        btnSave.Left = Me.Width - 197
        btnDelete.Left = Me.Width - 113

    End Sub
End Class