Public Class frmSecurity


#Region "Windows File Menu"
    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub
    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

#End Region

    Private Sub frmSecurity_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub




    Private Sub frmSecurity_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub UserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserToolStripMenuItem.Click
        frmSecurityGroup.tabSecurity.SelectTab(0)
        Dim RefreshLIstview As New clsSecurity
        RefreshLIstview.RefreshListView("USER")
        RefreshLIstview = Nothing

        'Dim lstSecurity As New frmSecurityGroup
        'lstSecurity.ListShow = "USER"
        frmSecurityGroup.ListShow = "USER"
        frmSecurityGroup.Show()
    End Sub

    Private Sub GroupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupToolStripMenuItem.Click
        frmSecurityGroup.tabSecurity.SelectTab(1)
        Dim RefreshLIstview As New clsSecurity
        RefreshLIstview.RefreshListView("GROUP")
        RefreshLIstview = Nothing

        'Dim lstSecurity As New frmSecurityGroup
        'lstSecurity.ListShow = "GROUP"
        frmSecurityGroup.ListShow = "GROUP"
        frmSecurityGroup.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
        Me.Close()
    End Sub

    Private Sub PrivilegeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrivilegeToolStripMenuItem.Click
        frmSecurityPrivilege.Show()
    End Sub
End Class