<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAuditLog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAuditLog))
        Me.txtRealeaseNote = New System.Windows.Forms.RichTextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtRealeaseNote
        '
        Me.txtRealeaseNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRealeaseNote.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRealeaseNote.Location = New System.Drawing.Point(12, 12)
        Me.txtRealeaseNote.Name = "txtRealeaseNote"
        Me.txtRealeaseNote.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.txtRealeaseNote.Size = New System.Drawing.Size(421, 419)
        Me.txtRealeaseNote.TabIndex = 1
        Me.txtRealeaseNote.Text = ""
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(358, 437)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmAuditLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(445, 469)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtRealeaseNote)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmAuditLog"
        Me.Text = "Release Notes"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtRealeaseNote As System.Windows.Forms.RichTextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
