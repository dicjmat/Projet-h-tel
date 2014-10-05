Public Class iGestionCentrale

    Private Sub btnAjoutForf_Click(sender As Object, e As RoutedEventArgs) Handles btnAjoutForf.Click
        Dim ajoutForf As iAjoutForf
        ajoutForf = New iAjoutForf
        ajoutForf.Show()
    End Sub
End Class
