Public Class iGestionBris
    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Private hotel As Integer

    Private Sub window_GestBris_Loaded(sender As Object, e As RoutedEventArgs) Handles window_GestBris.Loaded
        Dim res = From el In bd.tblBris Where el.noHotel = hotel Select el

        window_GestBris.DataContext = res.ToList()
    End Sub

    Private Sub btnEtat_Click(sender As Object, e As RoutedEventArgs) Handles btnEtat.Click
        If dgBris.SelectedIndex = -1 Then
            MessageBox.Show("Veuillez sélectionner un bris", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning)
        Else
            Dim nobris As Integer = dgBris.SelectedItem.noBris
            Dim res = From el In bd.tblBris Where nobris = el.noBris Select el

            res.Single.etatBris = "Réparé"
            res.Single.dateBris = Date.Now()
            bd.SaveChanges()
        End If
    End Sub
End Class