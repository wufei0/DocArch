Public Class frmSecurityDocument
    Private m_SortingColumn As ColumnHeader
    Private Sub frmSecurityDocument_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Refrestlist As New clsGroupPrivilege
        Me.MdiParent = PGLU_Doc_Manager
        Call Security_privilege()
        Refrestlist.ListviewRefresh("SECURITY_GROUP")
        Refrestlist.ListviewRefresh("COLUMN_GROUP")
        Refrestlist.ListviewRefresh("GROUP_PRIVILEGE")
    End Sub

    Private Sub lstGroupPrivilege_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstGroupPrivilege.ColumnClick


        ' Get the new sorting column.  

        Dim new_sorting_column As ColumnHeader = lstGroupPrivilege.Columns(e.Column)
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
        lstGroupPrivilege.ListViewItemSorter = New clsListviewSorter(e.Column, sort_order)
        ' Sort.  
        lstGroupPrivilege.Sort()
    End Sub

    Private Sub lstGroupPrivilege_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstGroupPrivilege.SelectedIndexChanged

    End Sub

    Private Sub lstColumnGroup_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstColumnGroup.ColumnClick


        ' Get the new sorting column.  

        Dim new_sorting_column As ColumnHeader = lstColumnGroup.Columns(e.Column)
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
        lstColumnGroup.ListViewItemSorter = New clsListviewSorter(e.Column, sort_order)
        ' Sort.  
        lstColumnGroup.Sort()
    End Sub

    Private Sub lstColumnGroup_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnWidthChangedEventArgs) Handles lstColumnGroup.ColumnWidthChanged
        'lstColumnGroup.Columns.Item(0).Width = 23
    End Sub

    Private Sub lstColumnGroup_ColumnWidthChanging(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnWidthChangingEventArgs) Handles lstColumnGroup.ColumnWidthChanging
        'If lstColumnGroup.Columns(0).Width <> 25 Then

        '    lstColumnGroup.Columns(0).Width = 25
        'Else

        'End If
    End Sub

    Private Sub lstColumnGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstColumnGroup.SelectedIndexChanged

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim SavePrivilege As New clsGroupPrivilege
        If lstSecurityGroup.CheckedItems.Count = 0 Then
            Beep()
            Exit Sub


        ElseIf lstColumnGroup.CheckedItems.Count = 0 Then
            Beep()
            Exit Sub
        Else
            SavePrivilege.PrivilegeSave()
            SavePrivilege.ListviewRefresh("GROUP_PRIVILEGE")

        End If


    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim DeletePrivilege As New clsGroupPrivilege
        If lstGroupPrivilege.SelectedItems.Count = 0 Then
            Beep()
        Else

            If MsgBox("Are you sure you want to remove privilege?", MsgBoxStyle.YesNo, "Delete Privilege") = MsgBoxResult.Yes Then
                Call DeletePrivilege.PrivilegeDelete()
                DeletePrivilege.ListviewRefresh("GROUP_PRIVILEGE")

            End If
        End If
    

    End Sub



    Private Sub lstSecurityGroup_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstSecurityGroup.ColumnClick


        ' Get the new sorting column.  

        Dim new_sorting_column As ColumnHeader = lstSecurityGroup.Columns(e.Column)
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
        lstSecurityGroup.ListViewItemSorter = New clsListviewSorter(e.Column, sort_order)
        ' Sort.  
        lstSecurityGroup.Sort()
    End Sub

    Private Sub lstSecurityGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSecurityGroup.SelectedIndexChanged

    End Sub
End Class