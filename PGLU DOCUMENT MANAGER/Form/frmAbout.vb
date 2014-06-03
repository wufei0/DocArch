Public NotInheritable Class frmAbout

    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        'Dim ApplicationTitle As String
        'If My.Application.Info.Title <> "" Then
        '    ApplicationTitle = My.Application.Info.Title
        'Else
        '    ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        'End If
        'Me.Text = String.Format("About {0}", ApplicationTitle)
        '' Initialize all of the text displayed on the About Box.
        '' TODO: Customize the application's assembly information in the "Application" pane of the project 
        ''    properties dialog (under the "Project" menu).
        'Me.LabelProductName.Text = My.Application.Info.ProductName
        'Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        'Me.LabelCopyright.Text = My.Application.Info.Copyright
        'Me.LabelCompanyName.Text = My.Application.Info.CompanyName
        'Me.TextBoxDescription.Text = My.Application.Info.Description
        lblVersion.Text = Me.GetVersion

    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function GetVersion() As String
        Dim fbreader As Odbc.OdbcDataReader = Nothing

        Try
            FbCommand = New Odbc.OdbcCommand
            Call modConnection.FBirdConnectionOpen()
            FbCommand.Connection = FbConnection
            FbCommand.CommandText = "SELECT FIRST 1 VERSION_MAJOR,VERSION_MINOR,VERSION_BUILD,TRANSDATE FROM SYSTEM_VERSION ORDER BY VERSION_ID DESC"
            fbreader = FbCommand.ExecuteReader
            fbreader.Read()
            Dim buildDate As Date = fbreader!TRANSDATE

            GetVersion = "v " & fbreader!VERSION_MAJOR.ToString() & "." & fbreader!VERSION_MINOR.ToString() & "." & fbreader!VERSION_BUILD.ToString() & "bd." & buildDate.Year & "." & buildDate.Month & "." & buildDate.Day

        Catch ex As Exception
            GetVersion = Nothing
        Finally
            FbCommand.Dispose()
            fbreader.Close()
            FbConnection.Close()
        End Try

        Return GetVersion
    End Function
End Class
