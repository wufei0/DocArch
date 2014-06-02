Imports System.Data.Odbc

Public Class frmSecurityGroup
    Private m_SortingColumn As ColumnHeader
    Public ListShow As String
    Private Sub frmSecurityGroup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PGLU_Doc_Manager
        Call Security_privilege()
        Dim NewSecurity As New clsSecurity
        NewSecurity.InsertcboGroup(Me.Name)
        NewSecurity.DeleteSecurity("USER")
        NewSecurity.DeleteSecurity("GROUP")
        'NewSecurity.NewUser("USER")
        'NewSecurity = Nothing
    End Sub



    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Dim NewUser As New clsSecurity

        If ListShow = "USER" Then


            NewUser.NewSecurity("USER")
            NewUser.InsertcboGroup(Me.Name)
        ElseIf ListShow = "GROUP" Then
            NewUser.NewSecurity("GROUP")

        End If
    End Sub

    Private Sub lstSecurity_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstSecurity.ColumnClick


        ' Get the new sorting column.  

        Dim new_sorting_column As ColumnHeader = lstSecurity.Columns(e.Column)
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
        lstSecurity.ListViewItemSorter = New clsListviewSorter(e.Column, sort_order)
        ' Sort.  
        lstSecurity.Sort()
    End Sub

    Private Sub lstSecurity_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSecurity.DoubleClick
        Dim DOubleclick As New clsSecurity
        Select Case ListShow

            Case "USER"
                Dim intX As Integer = 0
                lblid.Text = lstSecurity.SelectedItems(0).Text
                txtFullName.Text = lstSecurity.SelectedItems(0).SubItems(1).Text
                txtUserName.Text = lstSecurity.SelectedItems(0).SubItems(2).Text
                For Each ITEM In cboUserGroup.Items
                    If cboUserGroup.Items(intX).ToString = lstSecurity.SelectedItems(0).SubItems(3).Text Then
                        Exit For
                    End If
                    intX = intX + 1
                Next
                cboUserGroup.SelectedIndex = intX

            Case "GROUP"
                txtGroup.Text = lstSecurity.SelectedItems(0).Text
                txtGroupDescription.Text = lstSecurity.SelectedItems(0).SubItems(1).Text
        End Select
        DOubleclick.EditSecurity(ListShow)
    End Sub



    Private Sub TabPage1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage1.Enter
        Dim REFRESHLISTVIEW As New clsSecurity
        REFRESHLISTVIEW.RefreshListView("USER")
        'REFRESHLISTVIEW.DeleteSecurity("GROUP")
        ListShow = "USER"
    End Sub

    Private Sub TabPage2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage2.Enter
        Dim REFRESHLISTVIEW As New clsSecurity
        REFRESHLISTVIEW.RefreshListView("GROUP")
        'REFRESHLISTVIEW.DeleteSecurity("USER")
        ListShow = "GROUP"
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Are you sure you want to delete? This process is irreversible. Continue?", vbCritical + MsgBoxStyle.YesNo, "Delete Document") = MsgBoxResult.No Then
            Exit Sub

        Else
            Dim A As New clsSecurity
            A.DeleteUser(ListShow)
            A.DeleteSecurity(ListShow)
            A.RefreshListView(ListShow)
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim SaveUser As New clsSecurity
        If ListShow = "USER" Then

            If txtFullName.Text = Nothing Or txtUserName.Text = Nothing Or cboUserGroup.Text = Nothing Then
                Beep()
                Exit Sub
            End If

            SaveUser.SaveUser(ListShow)
            SaveUser.SaveSecurity(ListShow)
            SaveUser.RefreshListView(ListShow)

        ElseIf ListShow = "GROUP" Then

            If txtGroup.Text = Nothing Then
                Beep()
                Exit Sub
            End If

            SaveUser.SaveUser(ListShow)
            SaveUser.SaveSecurity(ListShow)
            SaveUser.RefreshListView(ListShow)
            End If
    End Sub

    Private Sub TabPage1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage1.GotFocus

    End Sub
    Private Sub TabPage2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage1.GotFocus

    End Sub

    Private Sub lstSecurity_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSecurity.SelectedIndexChanged

    End Sub
End Class