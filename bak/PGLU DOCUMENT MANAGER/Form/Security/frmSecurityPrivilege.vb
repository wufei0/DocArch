Public Class frmSecurityPrivilege
    Private m_SortingColumn As ColumnHeader
    Private Sub frmSecurityPrivilege_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PGLU_Doc_Manager
        Dim a As New clsSecurity
        a.InsertcboGroup(Me.Name)
        Call Security_privilege()
    End Sub

    Private Sub cboGroupName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGroupName.SelectedIndexChanged
        Dim a As New clsSecurity
        Call a.RefreshSecurityPrivilegeList("SELECT * FROM SECURITY_PRIVILEGES WHERE FK_SECURITY_GROUP = '" & cboGroupName.Text & "' ORDER BY SECURITY_PRIVILEGE_ID ASC ")
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim A As New clsSecurity
        A.SavePrivilege()
    End Sub

    Private Sub lstPrivilege_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstPrivilege.ColumnClick

        ' Get the new sorting column.  

        Dim new_sorting_column As ColumnHeader = lstPrivilege.Columns(e.Column)
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
        lstPrivilege.ListViewItemSorter = New clsListviewSorter(e.Column, sort_order)
        ' Sort.  
        lstPrivilege.Sort()
    End Sub

    Private Sub lstPrivilege_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstPrivilege.SelectedIndexChanged

    End Sub

    Private Sub frmSecurityPrivilege_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        lstPrivilege.Width = Me.Width - 41
        lstPrivilege.Height = Me.Height - 128

        btnSave.Left = Me.Width - 103
        btnSave.Top = Me.Height - 73
    End Sub
End Class