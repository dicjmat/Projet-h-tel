Public Class iListeCentrale

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Owner.Show()
        Me.Close()
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
