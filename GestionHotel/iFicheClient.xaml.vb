Public Class iFicheClient
    Dim db As P2014_Equipe2_GestionHôtelièreEntities
    Private Sub windowFicheCli_Loaded(sender As Object, e As RoutedEventArgs) Handles windowFicheCli.Loaded
        db = New P2014_Equipe2_GestionHôtelièreEntities
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        'Sauvegarder

    End Sub

End Class
