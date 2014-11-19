<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDialogueBox
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
        Me.pnlNewDoc = New System.Windows.Forms.Panel()
        Me.btnNewDoc = New System.Windows.Forms.Button()
        Me.cboNewDoc = New System.Windows.Forms.ComboBox()
        Me.pnlEditTag = New System.Windows.Forms.Panel()
        Me.btnEditTag = New System.Windows.Forms.Button()
        Me.txtEditTag = New System.Windows.Forms.TextBox()
        Me.pnlNewDoc.SuspendLayout()
        Me.pnlEditTag.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlNewDoc
        '
        Me.pnlNewDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlNewDoc.Controls.Add(Me.btnNewDoc)
        Me.pnlNewDoc.Controls.Add(Me.cboNewDoc)
        Me.pnlNewDoc.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlNewDoc.Location = New System.Drawing.Point(0, 180)
        Me.pnlNewDoc.Name = "pnlNewDoc"
        Me.pnlNewDoc.Size = New System.Drawing.Size(322, 56)
        Me.pnlNewDoc.TabIndex = 0
        Me.pnlNewDoc.Visible = False
        '
        'btnNewDoc
        '
        Me.btnNewDoc.Location = New System.Drawing.Point(223, 15)
        Me.btnNewDoc.Name = "btnNewDoc"
        Me.btnNewDoc.Size = New System.Drawing.Size(75, 23)
        Me.btnNewDoc.TabIndex = 1
        Me.btnNewDoc.Text = "Ok"
        Me.btnNewDoc.UseVisualStyleBackColor = True
        '
        'cboNewDoc
        '
        Me.cboNewDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNewDoc.FormattingEnabled = True
        Me.cboNewDoc.Location = New System.Drawing.Point(22, 15)
        Me.cboNewDoc.Name = "cboNewDoc"
        Me.cboNewDoc.Size = New System.Drawing.Size(195, 21)
        Me.cboNewDoc.TabIndex = 0
        '
        'pnlEditTag
        '
        Me.pnlEditTag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEditTag.Controls.Add(Me.btnEditTag)
        Me.pnlEditTag.Controls.Add(Me.txtEditTag)
        Me.pnlEditTag.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlEditTag.Location = New System.Drawing.Point(0, 118)
        Me.pnlEditTag.Name = "pnlEditTag"
        Me.pnlEditTag.Size = New System.Drawing.Size(322, 56)
        Me.pnlEditTag.TabIndex = 1
        Me.pnlEditTag.Visible = False
        '
        'btnEditTag
        '
        Me.btnEditTag.Location = New System.Drawing.Point(238, 14)
        Me.btnEditTag.Name = "btnEditTag"
        Me.btnEditTag.Size = New System.Drawing.Size(75, 23)
        Me.btnEditTag.TabIndex = 2
        Me.btnEditTag.Text = "Ok"
        Me.btnEditTag.UseVisualStyleBackColor = True
        '
        'txtEditTag
        '
        Me.txtEditTag.Location = New System.Drawing.Point(12, 16)
        Me.txtEditTag.Name = "txtEditTag"
        Me.txtEditTag.Size = New System.Drawing.Size(220, 21)
        Me.txtEditTag.TabIndex = 0
        '
        'frmDialogueBox
        '
        Me.AcceptButton = Me.btnEditTag
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(479, 238)
        Me.Controls.Add(Me.pnlEditTag)
        Me.Controls.Add(Me.pnlNewDoc)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDialogueBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Input"
        Me.pnlNewDoc.ResumeLayout(False)
        Me.pnlEditTag.ResumeLayout(False)
        Me.pnlEditTag.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlNewDoc As System.Windows.Forms.Panel
    Friend WithEvents btnNewDoc As System.Windows.Forms.Button
    Friend WithEvents cboNewDoc As System.Windows.Forms.ComboBox
    Friend WithEvents pnlEditTag As System.Windows.Forms.Panel
    Friend WithEvents btnEditTag As System.Windows.Forms.Button
    Friend WithEvents txtEditTag As System.Windows.Forms.TextBox
End Class
