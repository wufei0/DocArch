Public Class frmLog
    Private m_SortingColumn As ColumnHeader
    Private Sub frmLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim logsearch As New clsLog

        Me.MdiParent = PGLU_Doc_Manager
        Call Security_privilege()
        lstSearch.Items.Clear()
        'Call logsearch.SearchLog("SELECT  * FROM SECURITY_AUDIT", lstSearch)
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

    Private Sub lstSearch_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSearch.DoubleClick
        Dim logsearch As New clsLog
        lstLog.Items.Clear()
        Call logsearch.SearchLog("SELECT * FROM SECURITY_AUDIT WHERE TRANSACTION_ID = " & lstSearch.SelectedItems(0).SubItems(1).Text & " ORDER BY SECURITY_AUDIT_ID", lstLog)
        'lstSearch.SelectedItems.
    End Sub

    Private Sub lstSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSearch.SelectedIndexChanged

    End Sub

    Private Sub lstLog_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstLog.ColumnClick

        ' Get the new sorting column.  

        Dim new_sorting_column As ColumnHeader = lstLog.Columns(e.Column)
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
        lstLog.ListViewItemSorter = New clsListviewSorter(e.Column, sort_order)
        ' Sort.  
        lstLog.Sort()
    End Sub

    Private Sub lstLog_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstLog.SelectedIndexChanged

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim LOGSEARCH As New clsLog

        If rdUser.Checked = True Then
            FbSql = "SELECT * FROM SECURITY_AUDIT WHERE SECURITY_USER LIKE '" & txtSearch.Text & "%' ORDER BY SECURITY_USER"
        ElseIf rdDML.Checked = True Then
            FbSql = "SELECT * FROM SECURITY_AUDIT WHERE DML LIKE '" & txtSearch.Text & "%' ORDER BY dml"
        ElseIf rdDate.Checked = True Then
            FbSql = "SELECT * FROM SECURITY_AUDIT where cast(TRANSDATE  as date)like date '" & txtSearch.Text & "' "
        ElseIf rdAll.Checked = True Then
            FbSql = "SELECT * FROM SECURITY_AUDIT"
        End If

        lstSearch.Items.Clear()
        Call LOGSEARCH.SearchLog(FbSql, lstSearch)
    End Sub

    Private Sub frmLog_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        lstLog.Height = Me.Height - 126
        lstSearch.Height = Me.Height - 126

        lstLog.Width = Me.Width - 264
        'lstSearch.Width = Me.Width - 572
        btnSearch.Left = Me.Width - 80
        txtSearch.Width = Me.Width - 322

    End Sub
End Class