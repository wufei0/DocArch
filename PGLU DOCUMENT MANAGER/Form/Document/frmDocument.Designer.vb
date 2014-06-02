<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDocument
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDocument))
        Me.ofdPDF = New System.Windows.Forms.OpenFileDialog()
        Me.axDocument = New AxAcroPDFLib.AxAcroPDF()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblDateUpdated = New System.Windows.Forms.Label()
        Me.lblUpdatedBy = New System.Windows.Forms.Label()
        Me.lblFileSize = New System.Windows.Forms.Label()
        Me.lblFileName = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.TabDocument = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lstTag = New System.Windows.Forms.ListView()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmsIndex = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsIndex_Insert = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsIndex_Delete = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.btnAttachment = New System.Windows.Forms.Button()
        Me.lstAttachment = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmsAttachment = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsAttachment_Add = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsAttachment_Download = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsAttachment_Remove = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lstHistory = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmsHistory = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsHistory_Preview = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnPDF = New System.Windows.Forms.Button()
        Me.lblID = New System.Windows.Forms.Label()
        Me.lblGroupID = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.ofdAttachment = New System.Windows.Forms.OpenFileDialog()
        Me.lblDocumentFileID = New System.Windows.Forms.Label()
        Me.sfdAttachment = New System.Windows.Forms.SaveFileDialog()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnRollback = New System.Windows.Forms.Button()
        Me.fbAttachment = New System.Windows.Forms.FolderBrowserDialog()
        CType(Me.axDocument, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TabDocument.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.cmsIndex.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.cmsAttachment.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.cmsHistory.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofdPDF
        '
        Me.ofdPDF.FileName = "OpenFileDialog1"
        '
        'axDocument
        '
        Me.axDocument.Enabled = True
        Me.axDocument.Location = New System.Drawing.Point(12, 12)
        Me.axDocument.Name = "axDocument"
        Me.axDocument.OcxState = CType(resources.GetObject("axDocument.OcxState"), System.Windows.Forms.AxHost.State)
        Me.axDocument.Size = New System.Drawing.Size(424, 506)
        Me.axDocument.TabIndex = 2
        Me.axDocument.TabStop = False
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
        Me.GroupBox1.Location = New System.Drawing.Point(443, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(337, 131)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Properties"
        '
        'lblDateUpdated
        '
        Me.lblDateUpdated.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblDateUpdated.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateUpdated.Location = New System.Drawing.Point(98, 97)
        Me.lblDateUpdated.Name = "lblDateUpdated"
        Me.lblDateUpdated.Size = New System.Drawing.Size(229, 13)
        Me.lblDateUpdated.TabIndex = 0
        Me.lblDateUpdated.Text = "Date Updated:"
        '
        'lblUpdatedBy
        '
        Me.lblUpdatedBy.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblUpdatedBy.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpdatedBy.Location = New System.Drawing.Point(98, 71)
        Me.lblUpdatedBy.Name = "lblUpdatedBy"
        Me.lblUpdatedBy.Size = New System.Drawing.Size(229, 13)
        Me.lblUpdatedBy.TabIndex = 0
        Me.lblUpdatedBy.Text = "Date Updated:"
        '
        'lblFileSize
        '
        Me.lblFileSize.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblFileSize.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFileSize.Location = New System.Drawing.Point(98, 49)
        Me.lblFileSize.Name = "lblFileSize"
        Me.lblFileSize.Size = New System.Drawing.Size(229, 13)
        Me.lblFileSize.TabIndex = 0
        Me.lblFileSize.Text = "Date Updated:"
        '
        'lblFileName
        '
        Me.lblFileName.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblFileName.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFileName.Location = New System.Drawing.Point(98, 26)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(229, 13)
        Me.lblFileName.TabIndex = 0
        Me.lblFileName.Text = "Date Updated:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(18, 97)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Date Updated:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(18, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Updated by:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "File size:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "File name:"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(624, 539)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        Me.btnSave.Visible = False
        '
        'btnNew
        '
        Me.btnNew.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Location = New System.Drawing.Point(543, 539)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 23)
        Me.btnNew.TabIndex = 6
        Me.btnNew.Text = "&New"
        Me.btnNew.UseVisualStyleBackColor = True
        Me.btnNew.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(705, 539)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 8
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        Me.btnDelete.Visible = False
        '
        'TabDocument
        '
        Me.TabDocument.Controls.Add(Me.TabPage1)
        Me.TabDocument.Controls.Add(Me.TabPage3)
        Me.TabDocument.Controls.Add(Me.TabPage2)
        Me.TabDocument.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabDocument.Location = New System.Drawing.Point(443, 289)
        Me.TabDocument.Name = "TabDocument"
        Me.TabDocument.SelectedIndex = 0
        Me.TabDocument.Size = New System.Drawing.Size(337, 234)
        Me.TabDocument.TabIndex = 9
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lstTag)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(329, 208)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Index"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lstTag
        '
        Me.lstTag.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9})
        Me.lstTag.ContextMenuStrip = Me.cmsIndex
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
        Me.ColumnHeader7.Width = 1
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Index"
        Me.ColumnHeader8.Width = 110
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Text"
        Me.ColumnHeader9.Width = 180
        '
        'cmsIndex
        '
        Me.cmsIndex.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsIndex_Insert, Me.cmsIndex_Delete})
        Me.cmsIndex.Name = "cmsIndex"
        Me.cmsIndex.Size = New System.Drawing.Size(129, 48)
        '
        'cmsIndex_Insert
        '
        Me.cmsIndex_Insert.Name = "cmsIndex_Insert"
        Me.cmsIndex_Insert.Size = New System.Drawing.Size(128, 22)
        Me.cmsIndex_Insert.Text = "Insert/Edit"
        '
        'cmsIndex_Delete
        '
        Me.cmsIndex_Delete.Name = "cmsIndex_Delete"
        Me.cmsIndex_Delete.Size = New System.Drawing.Size(128, 22)
        Me.cmsIndex_Delete.Text = "Delete"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.btnAttachment)
        Me.TabPage3.Controls.Add(Me.lstAttachment)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(329, 208)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Attachment"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'btnAttachment
        '
        Me.btnAttachment.Location = New System.Drawing.Point(289, 179)
        Me.btnAttachment.Name = "btnAttachment"
        Me.btnAttachment.Size = New System.Drawing.Size(34, 23)
        Me.btnAttachment.TabIndex = 1
        Me.btnAttachment.Text = "..."
        Me.btnAttachment.UseVisualStyleBackColor = True
        '
        'lstAttachment
        '
        Me.lstAttachment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstAttachment.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader4, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lstAttachment.ContextMenuStrip = Me.cmsAttachment
        Me.lstAttachment.FullRowSelect = True
        Me.lstAttachment.GridLines = True
        Me.lstAttachment.Location = New System.Drawing.Point(7, 6)
        Me.lstAttachment.MultiSelect = False
        Me.lstAttachment.Name = "lstAttachment"
        Me.lstAttachment.Size = New System.Drawing.Size(316, 167)
        Me.lstAttachment.TabIndex = 0
        Me.lstAttachment.UseCompatibleStateImageBehavior = False
        Me.lstAttachment.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 1
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Path"
        Me.ColumnHeader4.Width = 0
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
        'cmsAttachment
        '
        Me.cmsAttachment.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmsAttachment.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsAttachment_Add, Me.cmsAttachment_Download, Me.cmsAttachment_Remove})
        Me.cmsAttachment.Name = "cmsAttachment"
        Me.cmsAttachment.Size = New System.Drawing.Size(196, 70)
        '
        'cmsAttachment_Add
        '
        Me.cmsAttachment_Add.Name = "cmsAttachment_Add"
        Me.cmsAttachment_Add.Size = New System.Drawing.Size(195, 22)
        Me.cmsAttachment_Add.Text = "Add Attachment"
        '
        'cmsAttachment_Download
        '
        Me.cmsAttachment_Download.Name = "cmsAttachment_Download"
        Me.cmsAttachment_Download.Size = New System.Drawing.Size(195, 22)
        Me.cmsAttachment_Download.Text = "Download Attachment"
        '
        'cmsAttachment_Remove
        '
        Me.cmsAttachment_Remove.Name = "cmsAttachment_Remove"
        Me.cmsAttachment_Remove.Size = New System.Drawing.Size(195, 22)
        Me.cmsAttachment_Remove.Text = "Remove Attachment"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lstHistory)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(329, 208)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "History"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lstHistory
        '
        Me.lstHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstHistory.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader13, Me.ColumnHeader6, Me.ColumnHeader10, Me.ColumnHeader11})
        Me.lstHistory.ContextMenuStrip = Me.cmsHistory
        Me.lstHistory.FullRowSelect = True
        Me.lstHistory.GridLines = True
        Me.lstHistory.Location = New System.Drawing.Point(6, 6)
        Me.lstHistory.MultiSelect = False
        Me.lstHistory.Name = "lstHistory"
        Me.lstHistory.Size = New System.Drawing.Size(316, 196)
        Me.lstHistory.TabIndex = 0
        Me.lstHistory.UseCompatibleStateImageBehavior = False
        Me.lstHistory.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "ID"
        Me.ColumnHeader5.Width = 1
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "No"
        Me.ColumnHeader13.Width = 30
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Note"
        Me.ColumnHeader6.Width = 160
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Date Updated"
        Me.ColumnHeader10.Width = 90
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Security User"
        Me.ColumnHeader11.Width = 130
        '
        'cmsHistory
        '
        Me.cmsHistory.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmsHistory.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsHistory_Preview})
        Me.cmsHistory.Name = "cmsMenu"
        Me.cmsHistory.Size = New System.Drawing.Size(117, 26)
        '
        'cmsHistory_Preview
        '
        Me.cmsHistory_Preview.Name = "cmsHistory_Preview"
        Me.cmsHistory_Preview.Size = New System.Drawing.Size(116, 22)
        Me.cmsHistory_Preview.Text = "Preview"
        '
        'btnPDF
        '
        Me.btnPDF.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPDF.Location = New System.Drawing.Point(13, 529)
        Me.btnPDF.Name = "btnPDF"
        Me.btnPDF.Size = New System.Drawing.Size(75, 23)
        Me.btnPDF.TabIndex = 11
        Me.btnPDF.Text = "Search Pdf"
        Me.btnPDF.UseVisualStyleBackColor = True
        Me.btnPDF.Visible = False
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblID.Location = New System.Drawing.Point(207, 529)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(29, 13)
        Me.lblID.TabIndex = 12
        Me.lblID.Text = "lblID"
        Me.lblID.Visible = False
        '
        'lblGroupID
        '
        Me.lblGroupID.AutoSize = True
        Me.lblGroupID.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroupID.Location = New System.Drawing.Point(207, 549)
        Me.lblGroupID.Name = "lblGroupID"
        Me.lblGroupID.Size = New System.Drawing.Size(58, 13)
        Me.lblGroupID.TabIndex = 12
        Me.lblGroupID.Text = "lblGroupID"
        Me.lblGroupID.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtNote)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(442, 149)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(337, 134)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Note"
        '
        'txtNote
        '
        Me.txtNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNote.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNote.Location = New System.Drawing.Point(20, 19)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNote.Size = New System.Drawing.Size(307, 109)
        Me.txtNote.TabIndex = 0
        '
        'ofdAttachment
        '
        Me.ofdAttachment.FileName = "OpenFileDialog1"
        '
        'lblDocumentFileID
        '
        Me.lblDocumentFileID.AutoSize = True
        Me.lblDocumentFileID.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDocumentFileID.Location = New System.Drawing.Point(207, 571)
        Me.lblDocumentFileID.Name = "lblDocumentFileID"
        Me.lblDocumentFileID.Size = New System.Drawing.Size(96, 13)
        Me.lblDocumentFileID.TabIndex = 14
        Me.lblDocumentFileID.Text = "lblDOcumentFileID"
        Me.lblDocumentFileID.Visible = False
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(94, 529)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 15
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        Me.btnPrint.Visible = False
        '
        'btnRollback
        '
        Me.btnRollback.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRollback.Location = New System.Drawing.Point(441, 539)
        Me.btnRollback.Name = "btnRollback"
        Me.btnRollback.Size = New System.Drawing.Size(75, 23)
        Me.btnRollback.TabIndex = 16
        Me.btnRollback.Text = "Rollback"
        Me.btnRollback.UseVisualStyleBackColor = True
        Me.btnRollback.Visible = False
        '
        'frmDocument
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 579)
        Me.Controls.Add(Me.btnRollback)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.lblDocumentFileID)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblGroupID)
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.btnPDF)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TabDocument)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.axDocument)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDocument"
        Me.Text = "Document"
        Me.TransparencyKey = System.Drawing.Color.Red
        CType(Me.axDocument, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabDocument.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.cmsIndex.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.cmsAttachment.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.cmsHistory.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofdPDF As System.Windows.Forms.OpenFileDialog
    Friend WithEvents axDocument As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents TabDocument As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents lstTag As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnPDF As System.Windows.Forms.Button
    Friend WithEvents lblDateUpdated As System.Windows.Forms.Label
    Friend WithEvents lblUpdatedBy As System.Windows.Forms.Label
    Friend WithEvents lblFileSize As System.Windows.Forms.Label
    Friend WithEvents lblFileName As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents lblGroupID As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents btnAttachment As System.Windows.Forms.Button
    Friend WithEvents lstAttachment As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ofdAttachment As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblDocumentFileID As System.Windows.Forms.Label
    Friend WithEvents lstHistory As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmsHistory As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsHistory_Preview As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsAttachment As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsAttachment_Download As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sfdAttachment As System.Windows.Forms.SaveFileDialog
    Friend WithEvents cmsAttachment_Remove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnRollback As System.Windows.Forms.Button
    Friend WithEvents fbAttachment As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents cmsIndex As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsIndex_Insert As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsIndex_Delete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsAttachment_Add As System.Windows.Forms.ToolStripMenuItem
End Class
