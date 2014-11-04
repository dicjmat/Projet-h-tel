Public Class iFicheReserv
    Private Sub btnCheck_Click(sender As Object, e As RoutedEventArgs) Handles btnCheck.Click
        Dim check = New iCheck_in_out()
        check.Owner = Me
        check.Show()
    End Sub

    Private Sub btnReservC_Click(sender As Object, e As RoutedEventArgs) Handles btnReservC.Click
        'Dim reserv = New iFaireReservation(bd, noEmploye, noHotel)
        'reserv.Owner = Me
        'reserv.Show()
    End Sub

    Private Sub btnFact_Click(sender As Object, e As RoutedEventArgs) Handles btnFact.Click
        Dim facture = New iFacture
        facture.Owner = Me
        facture.Show()
    End Sub

    Private Sub btnAjoutCli_Click(sender As Object, e As RoutedEventArgs) Handles btnAjoutCli.Click
        Dim ajout = New iAjoutCliReserv
        ajout.Owner = Me
        ajout.Show()
    End Sub

    Private Sub btnFicheC_Click(sender As Object, e As RoutedEventArgs) Handles btnFicheC.Click
        Dim ficheC = New iFicheClient
        ficheC.Owner = Me
        ficheC.Show()
    End Sub

    Private Sub btnFicheReservF_Click(sender As Object, e As RoutedEventArgs) Handles btnFicheReservF.Click
        Dim ficheRF = New iFicheReservFacture
        ficheRF.Owner = Me
        ficheRF.Show()
    End Sub

    Private Sub btnListeCli_Click(sender As Object, e As RoutedEventArgs) Handles btnListeCli.Click
        Dim lst = New iListeClient
        lst.owner = Me
        lst.Show()
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        'Dim accueil = New iFaireReservation
        'accueil.Owner = Me
        'accueil.Show()
        Me.Close()
    End Sub
End Class
