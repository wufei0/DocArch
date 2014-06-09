<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PGLU_Doc_Manager
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PGLU_Doc_Manager))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.MnuDocument = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDocument_NewDocument = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDocument_Logout = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDocument_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMaintenance = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMaintenance_Index = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMaintenance_Index_IndexColumn = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMaintenance_Index_IndexGroup = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMaintenance_Security = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMaintenance_Security_UserSecurity = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMaintenance_Security_UserSecurity_User = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMaintenance_Security_UserSecurity_Group = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMaintenance_Security_UserSecurity_Privilege = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMaintenance_Security_DocumentSecurity = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMaintenance_Security_AuditTrail = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMaintenance_Preference = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolBarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusBarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CascadeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TileVerticalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TileHorizontalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArrangeIconsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.AuditLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSDatabase = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TsTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.grpSearch = New System.Windows.Forms.GroupBox()
        Me.chkOCR = New System.Windows.Forms.CheckBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.lstSearch = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.grpSearch.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.AllowMerge = False
        Me.MenuStrip.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuDocument, Me.mnuMaintenance, Me.ViewMenu, Me.WindowsMenu, Me.HelpMenu})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.MdiWindowListItem = Me.mnuMaintenance
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip.Size = New System.Drawing.Size(902, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'MnuDocument
        '
        Me.MnuDocument.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDocument_NewDocument, Me.mnuDocument_Logout, Me.mnuDocument_Exit})
        Me.MnuDocument.Name = "MnuDocument"
        Me.MnuDocument.Size = New System.Drawing.Size(74, 20)
        Me.MnuDocument.Text = "Document"
        '
        'mnuDocument_NewDocument
        '
        Me.mnuDocument_NewDocument.Image = CType(resources.GetObject("mnuDocument_NewDocument.Image"), System.Drawing.Image)
        Me.mnuDocument_NewDocument.Name = "mnuDocument_NewDocument"
        Me.mnuDocument_NewDocument.Size = New System.Drawing.Size(156, 22)
        Me.mnuDocument_NewDocument.Text = "New Document"
        '
        'mnuDocument_Logout
        '
        Me.mnuDocument_Logout.Name = "mnuDocument_Logout"
        Me.mnuDocument_Logout.Size = New System.Drawing.Size(156, 22)
        Me.mnuDocument_Logout.Text = "Log Out"
        '
        'mnuDocument_Exit
        '
        Me.mnuDocument_Exit.Name = "mnuDocument_Exit"
        Me.mnuDocument_Exit.Size = New System.Drawing.Size(156, 22)
        Me.mnuDocument_Exit.Text = "Exit"
        '
        'mnuMaintenance
        '
        Me.mnuMaintenance.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMaintenance_Index, Me.mnuMaintenance_Security, Me.mnuMaintenance_Preference})
        Me.mnuMaintenance.Name = "mnuMaintenance"
        Me.mnuMaintenance.Size = New System.Drawing.Size(91, 20)
        Me.mnuMaintenance.Text = "Maintenance"
        '
        'mnuMaintenance_Index
        '
        Me.mnuMaintenance_Index.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMaintenance_Index_IndexColumn, Me.mnuMaintenance_Index_IndexGroup})
        Me.mnuMaintenance_Index.Name = "mnuMaintenance_Index"
        Me.mnuMaintenance_Index.Size = New System.Drawing.Size(132, 22)
        Me.mnuMaintenance_Index.Text = "Index"
        '
        'mnuMaintenance_Index_IndexColumn
        '
        Me.mnuMaintenance_Index_IndexColumn.Name = "mnuMaintenance_Index_IndexColumn"
        Me.mnuMaintenance_Index_IndexColumn.Size = New System.Drawing.Size(148, 22)
        Me.mnuMaintenance_Index_IndexColumn.Text = "Index Column"
        '
        'mnuMaintenance_Index_IndexGroup
        '
        Me.mnuMaintenance_Index_IndexGroup.Name = "mnuMaintenance_Index_IndexGroup"
        Me.mnuMaintenance_Index_IndexGroup.Size = New System.Drawing.Size(148, 22)
        Me.mnuMaintenance_Index_IndexGroup.Text = "Index Group"
        '
        'mnuMaintenance_Security
        '
        Me.mnuMaintenance_Security.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMaintenance_Security_UserSecurity, Me.mnuMaintenance_Security_DocumentSecurity, Me.mnuMaintenance_Security_AuditTrail})
        Me.mnuMaintenance_Security.Name = "mnuMaintenance_Security"
        Me.mnuMaintenance_Security.Size = New System.Drawing.Size(132, 22)
        Me.mnuMaintenance_Security.Text = "Security"
        '
        'mnuMaintenance_Security_UserSecurity
        '
        Me.mnuMaintenance_Security_UserSecurity.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMaintenance_Security_UserSecurity_User, Me.mnuMaintenance_Security_UserSecurity_Group, Me.mnuMaintenance_Security_UserSecurity_Privilege})
        Me.mnuMaintenance_Security_UserSecurity.Name = "mnuMaintenance_Security_UserSecurity"
        Me.mnuMaintenance_Security_UserSecurity.Size = New System.Drawing.Size(174, 22)
        Me.mnuMaintenance_Security_UserSecurity.Text = "User Security"
        '
        'mnuMaintenance_Security_UserSecurity_User
        '
        Me.mnuMaintenance_Security_UserSecurity_User.Name = "mnuMaintenance_Security_UserSecurity_User"
        Me.mnuMaintenance_Security_UserSecurity_User.Size = New System.Drawing.Size(157, 22)
        Me.mnuMaintenance_Security_UserSecurity_User.Text = "User"
        '
        'mnuMaintenance_Security_UserSecurity_Group
        '
        Me.mnuMaintenance_Security_UserSecurity_Group.Name = "mnuMaintenance_Security_UserSecurity_Group"
        Me.mnuMaintenance_Security_UserSecurity_Group.Size = New System.Drawing.Size(157, 22)
        Me.mnuMaintenance_Security_UserSecurity_Group.Text = "Group"
        '
        'mnuMaintenance_Security_UserSecurity_Privilege
        '
        Me.mnuMaintenance_Security_UserSecurity_Privilege.Name = "mnuMaintenance_Security_UserSecurity_Privilege"
        Me.mnuMaintenance_Security_UserSecurity_Privilege.Size = New System.Drawing.Size(157, 22)
        Me.mnuMaintenance_Security_UserSecurity_Privilege.Text = "Group Privilege"
        '
        'mnuMaintenance_Security_DocumentSecurity
        '
        Me.mnuMaintenance_Security_DocumentSecurity.Name = "mnuMaintenance_Security_DocumentSecurity"
        Me.mnuMaintenance_Security_DocumentSecurity.Size = New System.Drawing.Size(174, 22)
        Me.mnuMaintenance_Security_DocumentSecurity.Text = "Document Security"
        '
        'mnuMaintenance_Security_AuditTrail
        '
        Me.mnuMaintenance_Security_AuditTrail.Name = "mnuMaintenance_Security_AuditTrail"
        Me.mnuMaintenance_Security_AuditTrail.Size = New System.Drawing.Size(174, 22)
        Me.mnuMaintenance_Security_AuditTrail.Text = "Audit Trail"
        '
        'mnuMaintenance_Preference
        '
        Me.mnuMaintenance_Preference.Name = "mnuMaintenance_Preference"
        Me.mnuMaintenance_Preference.Size = New System.Drawing.Size(132, 22)
        Me.mnuMaintenance_Preference.Text = "Preference"
        '
        'ViewMenu
        '
        Me.ViewMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolBarToolStripMenuItem, Me.StatusBarToolStripMenuItem})
        Me.ViewMenu.Name = "ViewMenu"
        Me.ViewMenu.Size = New System.Drawing.Size(46, 20)
        Me.ViewMenu.Text = "View"
        '
        'ToolBarToolStripMenuItem
        '
        Me.ToolBarToolStripMenuItem.Checked = True
        Me.ToolBarToolStripMenuItem.CheckOnClick = True
        Me.ToolBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolBarToolStripMenuItem.Name = "ToolBarToolStripMenuItem"
        Me.ToolBarToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.ToolBarToolStripMenuItem.Text = "&Search Bar"
        '
        'StatusBarToolStripMenuItem
        '
        Me.StatusBarToolStripMenuItem.Checked = True
        Me.StatusBarToolStripMenuItem.CheckOnClick = True
        Me.StatusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.StatusBarToolStripMenuItem.Name = "StatusBarToolStripMenuItem"
        Me.StatusBarToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.StatusBarToolStripMenuItem.Text = "Status Bar"
        '
        'WindowsMenu
        '
        Me.WindowsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewWindowToolStripMenuItem, Me.CascadeToolStripMenuItem, Me.TileVerticalToolStripMenuItem, Me.TileHorizontalToolStripMenuItem, Me.ArrangeIconsToolStripMenuItem, Me.CloseAllToolStripMenuItem})
        Me.WindowsMenu.Name = "WindowsMenu"
        Me.WindowsMenu.Size = New System.Drawing.Size(70, 20)
        Me.WindowsMenu.Text = "Windows"
        '
        'NewWindowToolStripMenuItem
        '
        Me.NewWindowToolStripMenuItem.Name = "NewWindowToolStripMenuItem"
        Me.NewWindowToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.NewWindowToolStripMenuItem.Text = "&New Window"
        '
        'CascadeToolStripMenuItem
        '
        Me.CascadeToolStripMenuItem.Name = "CascadeToolStripMenuItem"
        Me.CascadeToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.CascadeToolStripMenuItem.Text = "&Cascade"
        '
        'TileVerticalToolStripMenuItem
        '
        Me.TileVerticalToolStripMenuItem.Name = "TileVerticalToolStripMenuItem"
        Me.TileVerticalToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.TileVerticalToolStripMenuItem.Text = "Tile &Vertical"
        '
        'TileHorizontalToolStripMenuItem
        '
        Me.TileHorizontalToolStripMenuItem.Name = "TileHorizontalToolStripMenuItem"
        Me.TileHorizontalToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.TileHorizontalToolStripMenuItem.Text = "Tile &Horizontal"
        '
        'ArrangeIconsToolStripMenuItem
        '
        Me.ArrangeIconsToolStripMenuItem.Name = "ArrangeIconsToolStripMenuItem"
        Me.ArrangeIconsToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.ArrangeIconsToolStripMenuItem.Text = "&Arrange Icons"
        '
        'CloseAllToolStripMenuItem
        '
        Me.CloseAllToolStripMenuItem.Name = "CloseAllToolStripMenuItem"
        Me.CloseAllToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.CloseAllToolStripMenuItem.Text = "C&lose All"
        '
        'HelpMenu
        '
        Me.HelpMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AuditLogToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.HelpMenu.Name = "HelpMenu"
        Me.HelpMenu.Size = New System.Drawing.Size(45, 20)
        Me.HelpMenu.Text = "Help"
        '
        'AuditLogToolStripMenuItem
        '
        Me.AuditLogToolStripMenuItem.Name = "AuditLogToolStripMenuItem"
        Me.AuditLogToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.AuditLogToolStripMenuItem.Text = "Audit Log"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel, Me.TSDatabase, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel1, Me.TSUser, Me.ToolStripStatusLabel2, Me.TsTime, Me.tsStatus})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 499)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(902, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(63, 17)
        Me.ToolStripStatusLabel.Text = "Database:"
        '
        'TSDatabase
        '
        Me.TSDatabase.BackColor = System.Drawing.SystemColors.HighlightText
        Me.TSDatabase.Name = "TSDatabase"
        Me.TSDatabase.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(13, 17)
        Me.ToolStripStatusLabel4.Text = "|"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(35, 17)
        Me.ToolStripStatusLabel1.Text = "User:"
        '
        'TSUser
        '
        Me.TSUser.BackColor = System.Drawing.SystemColors.HighlightText
        Me.TSUser.Name = "TSUser"
        Me.TSUser.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(0, 17)
        Me.ToolStripStatusLabel2.Text = "ToolStripStatusLabel2"
        '
        'TsTime
        '
        Me.TsTime.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsTime.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.TsTime.Name = "TsTime"
        Me.TsTime.Size = New System.Drawing.Size(738, 17)
        Me.TsTime.Spring = True
        Me.TsTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tsStatus
        '
        Me.tsStatus.Name = "tsStatus"
        Me.tsStatus.Size = New System.Drawing.Size(38, 17)
        Me.tsStatus.Text = "status"
        '
        'grpSearch
        '
        Me.grpSearch.Controls.Add(Me.chkOCR)
        Me.grpSearch.Controls.Add(Me.btnSearch)
        Me.grpSearch.Controls.Add(Me.lstSearch)
        Me.grpSearch.Controls.Add(Me.txtSearch)
        Me.grpSearch.Dock = System.Windows.Forms.DockStyle.Left
        Me.grpSearch.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSearch.Location = New System.Drawing.Point(0, 24)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(224, 475)
        Me.grpSearch.TabIndex = 17
        Me.grpSearch.TabStop = False
        Me.grpSearch.Text = "Search"
        '
        'chkOCR
        '
        Me.chkOCR.AutoSize = True
        Me.chkOCR.Location = New System.Drawing.Point(2, 43)
        Me.chkOCR.Name = "chkOCR"
        Me.chkOCR.Size = New System.Drawing.Size(90, 17)
        Me.chkOCR.TabIndex = 21
        Me.chkOCR.Text = "Search in OCR"
        Me.chkOCR.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(148, 43)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(70, 23)
        Me.btnSearch.TabIndex = 11
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'lstSearch
        '
        Me.lstSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstSearch.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader8, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.lstSearch.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstSearch.FullRowSelect = True
        Me.lstSearch.GridLines = True
        Me.lstSearch.Location = New System.Drawing.Point(2, 74)
        Me.lstSearch.MultiSelect = False
        Me.lstSearch.Name = "lstSearch"
        Me.lstSearch.Size = New System.Drawing.Size(216, 370)
        Me.lstSearch.TabIndex = 12
        Me.lstSearch.UseCompatibleStateImageBehavior = False
        Me.lstSearch.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Document Group"
        Me.ColumnHeader2.Width = 90
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Note"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Index"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "User"
        Me.ColumnHeader4.Width = 90
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Transdate"
        Me.ColumnHeader5.Width = 120
        '
        'txtSearch
        '
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(2, 19)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(216, 21)
        Me.txtSearch.TabIndex = 11
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.SizeWE
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Location = New System.Drawing.Point(224, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(2, 475)
        Me.PictureBox1.TabIndex = 19
        Me.PictureBox1.TabStop = False
        '
        'PGLU_Doc_Manager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(902, 521)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.grpSearch)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "PGLU_Doc_Manager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DocArch"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents HelpMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ArrangeIconsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewWindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CascadeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileVerticalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileHorizontalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMaintenance_Preference As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents ViewMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolBarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusBarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMaintenance As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSDatabase As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TSUser As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents mnuMaintenance_Index As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMaintenance_Index_IndexGroup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMaintenance_Index_IndexColumn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuDocument As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDocument_NewDocument As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDocument_Exit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TsTime As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents grpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lstSearch As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents mnuMaintenance_Security As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMaintenance_Security_UserSecurity As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMaintenance_Security_DocumentSecurity As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMaintenance_Security_AuditTrail As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AuditLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMaintenance_Security_UserSecurity_User As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMaintenance_Security_UserSecurity_Group As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMaintenance_Security_UserSecurity_Privilege As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkOCR As System.Windows.Forms.CheckBox
    Friend WithEvents tsStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents mnuDocument_Logout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader

End Class
