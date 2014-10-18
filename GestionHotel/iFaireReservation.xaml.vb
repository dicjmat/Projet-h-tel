Public Class iFaireReservation
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities

    Private Sub window_FaireReserv_Loaded(sender As Object, e As RoutedEventArgs) Handles window_FaireReserv.Loaded
        bd = New P2014_Equipe2_GestionHôtelièreEntities
        lblChambre.Visibility = System.Windows.Visibility.Hidden
        lblSalle.Visibility = System.Windows.Visibility.Hidden
        txtID.IsEnabled = False

    End Sub
    Sub Main()
        If rdSalle.IsChecked = True Then
            lblSalle.Visibility = System.Windows.Visibility.Visible
            txtID.IsEnabled = True
        ElseIf rdChambre.IsChecked = True Then
            lblChambre.Visibility = System.Windows.Visibility.Visible
            txtID.IsEnabled = True
        End If

    End Sub
    Private Sub btnReserv_Click(sender As Object, e As RoutedEventArgs) Handles btnReserv.Click
        If rdSalle.IsChecked = True Then
            Dim salle As New tblReservationSalle

            bd.tblReservationSalle.Add(salle)
            bd.SaveChanges()
            MessageBox.Show("La réservation a été créé avec succès.")

        ElseIf rdChambre.IsChecked = True Then
            Dim chambre As New tblReservationChambre

            bd.tblReservationChambre.Add(chambre)
            bd.SaveChanges()
            MessageBox.Show("La réservation a été créé avec succès.")

        Else
            MessageBox.Show("Il vous manque des informations pour votre réservation")
        End If


    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub
End Class
