Public Class iListeCentrale
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Owner.Show()
        Me.Close()
    End Sub

    Private Sub window_lstCentrale_Loaded(sender As Object, e As RoutedEventArgs) Handles window_lstCentrale.Loaded
        bd = New P2014_Equipe2_GestionHôtelièreEntities
        Dim res = From Pa In bd.tblPays
                  Select Pa

        dgPays.ItemsSource = res.ToList
    End Sub

    Private Sub window_lstCentrale_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles window_lstCentrale.Closing
        Me.Owner.Show()
    End Sub

    Private Sub dgProvince_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dgProvince.SelectionChanged
        If dgProvince.SelectedIndex <> -1 Then
            Dim province As String = dgProvince.SelectedItem.codeProv
            Dim res = From Vi In bd.tblVille
                      Where Vi.codeProv = province
                      Select Vi

            dgVille.ItemsSource = res.ToList
        End If
    End Sub

    Private Sub dgPays_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dgPays.SelectionChanged
        If dgPays.SelectedIndex <> -1 Then
            Dim pays As String = dgPays.SelectedItem.codePays
            Dim res = From Pro In bd.tblProvince
                      Where Pro.codePays = pays
                      Select Pro

            dgProvince.ItemsSource = res.ToList
        End If
    End Sub

    Private Sub btnAjouterProv_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterProv.Click
        Dim prov = New AjoutProvince
        prov.Owner = Me
        prov.ShowDialog()
    End Sub

    Private Sub btnAjouterVille_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterVille.Click
        Dim ville = New AjoutVille
        ville.Owner = Me
        ville.ShowDialog()
    End Sub

    Private Sub btnAjouterPays_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterPays.Click
        Dim pays = New AjoutPays
        pays.Owner = Me
        pays.ShowDialog()
    End Sub
End Class
