<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewer
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmViewer))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblDateUpdated = New System.Windows.Forms.Label()
        Me.lblUpdatedBy = New System.Windows.Forms.Label()
        Me.lblFileSize = New System.Windows.Forms.Label()
        Me.lblFileName = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.lstAttachment = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lstTag = New System.Windows.Forms.ListView()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabDocument = New System.Windows.Forms.TabControl()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.sfdAttachment = New System.Windows.Forms.SaveFileDialog()
        Me.cmsAttachment = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmAttachment = New System.Windows.Forms.ToolStripMenuItem()
        Me.grpPdf = New System.Windows.Forms.GroupBox()
        Me.axDocument = New AxAcroPDFLib.AxAcroPDF()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabDocument.SuspendLayout()
        Me.cmsAttachment.SuspendLayout()
        Me.grpPdf.SuspendLayout()
        CType(Me.axDocument, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtNote)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(474, 149)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(337, 134)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Note"
        '
        'txtNote
        '
        Me.txtNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNote.Location = New System.Drawing.Point(20, 19)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNote.Size = New System.Drawing.Size(307, 109)
        Me.txtNote.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblDateUpdated)
        Me.GroupBox1.Controls.Add(Me.lblUpdatedBy)
        Me.GroupBox1.Controls.Add(Me.lblFileSize)
        Me.GroupBox1.Controls.Add(Me.lblFileName)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(475, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(337, 131)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Properties"
        '
        'lblDateUpdated
        '
        Me.lblDateUpdated.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblDateUpdated.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateUpdated.Location = New System.Drawing.Point(98, 97)
        Me.lblDateUpdated.Name = "lblDateUpdated"
        Me.lblDateUpdated.Size = New System.Drawing.Size(229, 13)
        Me.lblDateUpdated.TabIndex = 0
        Me.lblDateUpdated.Text = "Date Updated:"
        '
        'lblUpdatedBy
        '
        Me.lblUpdatedBy.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblUpdatedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpdatedBy.Location = New System.Drawing.Point(98, 71)
        Me.lblUpdatedBy.Name = "lblUpdatedBy"
        Me.lblUpdatedBy.Size = New System.Drawing.Size(229, 13)
        Me.lblUpdatedBy.TabIndex = 0
        Me.lblUpdatedBy.Text = "Date Updated:"
        '
        'lblFileSize
        '
        Me.lblFileSize.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblFileSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFileSize.Location = New System.Drawing.Point(98, 49)
        Me.lblFileSize.Name = "lblFileSize"
        Me.lblFileSize.Size = New System.Drawing.Size(229, 13)
        Me.lblFileSize.TabIndex = 0
        Me.lblFileSize.Text = "Date Updated:"
        '
        'lblFileName
        '
        Me.lblFileName.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblFileName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFileName.Location = New System.Drawing.Point(98, 26)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(229, 13)
        Me.lblFileName.TabIndex = 0
        Me.lblFileName.Text = "Date Updated:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 97)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Date Updated:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Updated by:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "File size:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "File name:"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.lstAttachment)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(329, 208)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Attachment"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'lstAttachment
        '
        Me.lstAttachment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstAttachment.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader4, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lstAttachment.FullRowSelect = True
        Me.lstAttachment.GridLines = True
        Me.lstAttachment.Location = New System.Drawing.Point(7, 6)
        Me.lstAttachment.MultiSelect = False
        Me.lstAttachment.Name = "lstAttachment"
        Me.lstAttachment.Size = New System.Drawing.Size(316, 194)
        Me.lstAttachment.TabIndex = 0
        Me.lstAttachment.UseCompatibleStateImageBehavior = False
        Me.lstAttachment.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Path"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Filename"
        Me.ColumnHeader2.Width = 180
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Filetype"
        Me.ColumnHeader3.Width = 90
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lstTag)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(329, 208)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Tag"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lstTag
        '
        Me.lstTag.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9})
        Me.lstTag.FullRowSelect = True
        Me.lstTag.GridLines = True
        Me.lstTag.Location = New System.Drawing.Point(5, 6)
        Me.lstTag.Name = "lstTag"
        Me.lstTag.Size = New System.Drawing.Size(317, 196)
        Me.lstTag.TabIndex = 0
        Me.lstTag.UseCompatibleStateImageBehavior = False
        Me.lstTag.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "ID"
        Me.ColumnHeader7.Width = 0
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Tag"
        Me.ColumnHeader8.Width = 110
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Text"
        Me.ColumnHeader9.Width = 180
        '
        'TabDocument
        '
        Me.TabDocument.Controls.Add(Me.TabPage1)
        Me.TabDocument.Controls.Add(Me.TabPage3)
        Me.TabDocument.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabDocument.Location = New System.Drawing.Point(475, 289)
        Me.TabDocument.Name = "TabDocument"
        Me.TabDocument.SelectedIndex = 0
        Me.TabDocument.Size = New System.Drawing.Size(337, 234)
        Me.TabDocument.TabIndex = 15
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(736, 537)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 17
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'cmsAttachment
        '
        Me.cmsAttachment.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmAttachment})
        Me.cmsAttachment.Name = "cmsAttachment"
        Me.cmsAttachment.Size = New System.Drawing.Size(195, 26)
        '
        'tsmAttachment
        '
        Me.tsmAttachment.Name = "tsmAttachment"
        Me.tsmAttachment.Size = New System.Drawing.Size(194, 22)
        Me.tsmAttachment.Text = "Download Attachment"
        '
        'grpPdf
        '
        Me.grpPdf.Controls.Add(Me.axDocument)
        Me.grpPdf.Enabled = False
        Me.grpPdf.Location = New System.Drawing.Point(5, 12)
        Me.grpPdf.Name = "grpPdf"
        Me.grpPdf.Size = New System.Drawing.Size(468, 521)
        Me.grpPdf.TabIndex = 18
        Me.grpPdf.TabStop = False
        '
        'axDocument
        '
        Me.axDocument.Enabled = True
        Me.axDocument.Location = New System.Drawing.Point(1, 1)
        Me.axDocument.Name = "axDocument"
        Me.axDocument.OcxState = CType(resources.GetObject("axDocument.OcxState"), System.Windows.Forms.AxHost.State)
        Me.axDocument.Size = New System.Drawing.Size(466, 519)
        Me.axDocument.TabIndex = 4
        '
        'btnPrevious
        '
        Me.btnPrevious.Font = New System.Drawing.Font("Calibri", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrevious.Location = New System.Drawing.Point(6, 539)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(79, 23)
        Me.btnPrevious.TabIndex = 19
        Me.btnPrevious.Text = "Previous Page"
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.Location = New System.Drawing.Point(91, 539)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(75, 23)
        Me.btnNext.TabIndex = 20
        Me.btnNext.Text = "Next Page"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'frmViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(819, 572)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnPrevious)
        Me.Controls.Add(Me.grpPdf)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TabDocument)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmViewer"
        Me.Text = "Document Viewer"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabDocument.ResumeLayout(False)
        Me.cmsAttachment.ResumeLayout(False)
        Me.grpPdf.ResumeLayout(False)
        CType(Me.axDocument, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblDateUpdated As System.Windows.Forms.Label
    Friend WithEvents lblUpdatedBy As System.Windows.Forms.Label
    Friend WithEvents lblFileSize As System.Windows.Forms.Label
    Friend WithEvents lblFileName As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents lstAttachment As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents lstTag As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TabDocument As System.Windows.Forms.TabControl
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents sfdAttachment As System.Windows.Forms.SaveFileDialog
    Friend WithEvents cmsAttachment As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmAttachment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grpPdf As System.Windows.Forms.GroupBox
    Friend WithEvents axDocument As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents btnPrevious As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
End Class
