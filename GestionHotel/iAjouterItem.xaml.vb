Class iAjouterItem
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Private Sub Viewbox_Loaded(sender As Object, e As RoutedEventArgs)
        bd = New P2014_Equipe2_GestionHôtelièreEntities
    End Sub

    Private Sub btnRechercherItem_Click(sender As Object, e As RoutedEventArgs) Handles btnRechercherItem.Click

    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub
End Class
