Public Class iListeCentrale
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Owner.Show()
        Me.Close()
    End Sub

    Private Sub window_lstCentrale_Loaded(sender As Object, e As RoutedEventArgs) Handles window_lstCentrale.Loaded
        bd = New P2014_Equipe2_GestionHôtelièreEntities
        requete()
    End Sub

    Private Sub window_lstCentrale_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles window_lstCentrale.Closing
        Me.Owner.Show()
    End Sub

    Private Sub dgProvince_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dgProvince.SelectionChanged
        requete()
    End Sub

    Private Sub dgPays_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dgPays.SelectionChanged
        requete()
    End Sub

    Private Sub btnAjouterProv_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterProv.Click
        If dgPays.SelectedItem IsNot Nothing Then
            Dim prov = New AjoutProvince(dgPays.SelectedItem.codePays)
            prov.Owner = Me
            prov.ShowDialog()
        Else
            MessageBox.Show("Veuiller sélectionner un pays", "Attention", MessageBoxButton.OK, MessageBoxImage.Exclamation)
        End If
    End Sub

    Private Sub btnAjouterVille_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterVille.Click
        If dgProvince.SelectedItem IsNot Nothing Then
            Dim ville = New AjoutVille(dgProvince.SelectedItem.codeProv)
            ville.Owner = Me
            ville.ShowDialog()
        Else
            MessageBox.Show("Veuiller sélectionner une province", "Attention", MessageBoxButton.OK, MessageBoxImage.Exclamation)
        End If
    End Sub

    Private Sub btnAjouterPays_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterPays.Click
        Dim pays = New AjoutPays
        pays.Owner = Me
        pays.ShowDialog()
    End Sub

    Private Sub window_lstCentrale_Activated(sender As Object, e As EventArgs) Handles window_lstCentrale.Activated
        requete()
    End Sub

    Private Sub requete()
        Dim res = From Pa In bd.tblPays
          Select Pa

        dgPays.ItemsSource = res.ToList

        If dgProvince.SelectedIndex <> -1 Then
            Dim province As String = dgProvince.SelectedItem.codeProv
            Dim resVille = From Vi In bd.tblVille
                      Where Vi.codeProv = province
                      Select Vi

            dgVille.ItemsSource = resVille.ToList
        End If
        If dgPays.SelectedIndex <> -1 Then
            Dim pays As String = dgPays.SelectedItem.codePays
            Dim resProv = From Pro In bd.tblProvince
                      Where Pro.codePays = pays
                      Select Pro

            dgProvince.ItemsSource = resProv.ToList
        End If
    End Sub
End Class
