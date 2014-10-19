Public Class iFaireReservation
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities

    Private Sub window_FaireReserv_Loaded(sender As Object, e As RoutedEventArgs) Handles window_FaireReserv.Loaded
        bd = New P2014_Equipe2_GestionHôtelièreEntities

    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub

    Private Sub btnReserv_Click(sender As Object, e As RoutedEventArgs) Handles btnReserv.Click

    End Sub
End Class
