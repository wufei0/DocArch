<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLog
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
        Me.lstLog = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstSearch = New System.Windows.Forms.ListView()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdAll = New System.Windows.Forms.RadioButton()
        Me.rdDate = New System.Windows.Forms.RadioButton()
        Me.rdDML = New System.Windows.Forms.RadioButton()
        Me.rdUser = New System.Windows.Forms.RadioButton()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstLog
        '
        Me.lstLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstLog.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader6, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.lstLog.FullRowSelect = True
        Me.lstLog.GridLines = True
        Me.lstLog.Location = New System.Drawing.Point(236, 62)
        Me.lstLog.MultiSelect = False
        Me.lstLog.Name = "lstLog"
        Me.lstLog.Size = New System.Drawing.Size(527, 357)
        Me.lstLog.TabIndex = 0
        Me.lstLog.UseCompatibleStateImageBehavior = False
        Me.lstLog.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Transaction No"
        Me.ColumnHeader2.Width = 0
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "DML"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "SQL Statement"
        Me.ColumnHeader6.Width = 250
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Date"
        Me.ColumnHeader4.Width = 120
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "User"
        Me.ColumnHeader5.Width = 90
        '
        'lstSearch
        '
        Me.lstSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstSearch.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader11, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10})
        Me.lstSearch.FullRowSelect = True
        Me.lstSearch.GridLines = True
        Me.lstSearch.Location = New System.Drawing.Point(11, 62)
        Me.lstSearch.MultiSelect = False
        Me.lstSearch.Name = "lstSearch"
        Me.lstSearch.Size = New System.Drawing.Size(219, 357)
        Me.lstSearch.TabIndex = 0
        Me.lstSearch.UseCompatibleStateImageBehavior = False
        Me.lstSearch.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "ID"
        Me.ColumnHeader7.Width = 0
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Transaction ID"
        Me.ColumnHeader11.Width = 0
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "User"
        Me.ColumnHeader8.Width = 80
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Date"
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "DML"
        Me.ColumnHeader10.Width = 90
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdAll)
        Me.GroupBox1.Controls.Add(Me.rdDate)
        Me.GroupBox1.Controls.Add(Me.rdDML)
        Me.GroupBox1.Controls.Add(Me.rdUser)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(219, 44)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter"
        '
        'rdAll
        '
        Me.rdAll.AutoSize = True
        Me.rdAll.Checked = True
        Me.rdAll.Location = New System.Drawing.Point(177, 20)
        Me.rdAll.Name = "rdAll"
        Me.rdAll.Size = New System.Drawing.Size(36, 17)
        Me.rdAll.TabIndex = 0
        Me.rdAll.TabStop = True
        Me.rdAll.Text = "All"
        Me.rdAll.UseVisualStyleBackColor = True
        '
        'rdDate
        '
        Me.rdDate.AutoSize = True
        Me.rdDate.Location = New System.Drawing.Point(112, 20)
        Me.rdDate.Name = "rdDate"
        Me.rdDate.Size = New System.Drawing.Size(48, 17)
        Me.rdDate.TabIndex = 0
        Me.rdDate.TabStop = True
        Me.rdDate.Text = "Date"
        Me.rdDate.UseVisualStyleBackColor = True
        '
        'rdDML
        '
        Me.rdDML.AutoSize = True
        Me.rdDML.Location = New System.Drawing.Point(61, 20)
        Me.rdDML.Name = "rdDML"
        Me.rdDML.Size = New System.Drawing.Size(45, 17)
        Me.rdDML.TabIndex = 0
        Me.rdDML.TabStop = True
        Me.rdDML.Text = "DML"
        Me.rdDML.UseVisualStyleBackColor = True
        '
        'rdUser
        '
        Me.rdUser.AutoSize = True
        Me.rdUser.Location = New System.Drawing.Point(8, 20)
        Me.rdUser.Name = "rdUser"
        Me.rdUser.Size = New System.Drawing.Size(47, 17)
        Me.rdUser.TabIndex = 0
        Me.rdUser.TabStop = True
        Me.rdUser.Text = "User"
        Me.rdUser.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Location = New System.Drawing.Point(236, 28)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(469, 21)
        Me.txtSearch.TabIndex = 2
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(711, 26)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(52, 23)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        Me.btnSearch.Visible = False
        '
        'frmLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(775, 445)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lstSearch)
        Me.Controls.Add(Me.lstLog)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmLog"
        Me.Text = "Audit Trail"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstLog As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstSearch As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdAll As System.Windows.Forms.RadioButton
    Friend WithEvents rdDate As System.Windows.Forms.RadioButton
    Friend WithEvents rdDML As System.Windows.Forms.RadioButton
    Friend WithEvents rdUser As System.Windows.Forms.RadioButton
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
End Class
