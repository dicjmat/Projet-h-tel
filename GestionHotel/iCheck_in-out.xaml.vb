Public Class iCheck_in_out
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Dim noEmp As Integer
    Dim noHotel As Integer
    Sub New(maBD As P2014_Equipe2_GestionHôtelièreEntities, _noEmp As Integer, _noHotel As Integer)
        InitializeComponent()
        noEmp = _noEmp
        noHotel = _noHotel
        bd = maBD
    End Sub
    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
        Me.Owner.Show()
    End Sub

    Private Sub window_Check_Loaded(sender As Object, e As RoutedEventArgs) Handles window_Check.Loaded
        Dim today = Format(Date.Now, "yyyy-MM-dd")
        Dim arrive = From el In bd.tblReservation
                     Join sa In bd.tblSalle On el.noSalle Equals sa.noSalle And el.noHotel Equals sa.noHotel
                     Join cl In bd.tblClient On el.noClient Equals cl.noClient
                     Where el.dateDebutSejour = today And sa.statutSalle = "Libre"
                     Select el

        dgArrive.ItemsSource = arrive.ToList()

        Dim depart = From el In bd.tblReservation
                     Join sa In bd.tblSalle On el.noSalle Equals sa.noSalle And el.noHotel Equals sa.noHotel
                     Where el.dateFinSejour = today And sa.statutSalle <> "Libre"
                     Select el

        dgDepart.ItemsSource = depart.ToList()
    End Sub

    Private Sub btnConsulterA_Click(sender As Object, e As RoutedEventArgs) Handles btnConsulterA.Click
        If dgArrive.SelectedItem IsNot Nothing Then
            Dim ficheReserv = New iFicheReserv(bd, noEmp, noHotel, dgArrive.SelectedItem.noReservation)
            ficheReserv.Show()
        Else
            MessageBox.Show("Veuillez sélectionner une réservation", "Erreur", MessageBoxButton.OK, MessageBoxImage.Exclamation)
        End If
    End Sub

    Private Sub btnConsulterD_Click(sender As Object, e As RoutedEventArgs) Handles btnConsulterD.Click
        If dgDepart.SelectedItem IsNot Nothing Then
            Dim ficheReserv = New iFicheReserv(bd, noEmp, noHotel, dgArrive.SelectedItem.noReservation)
            ficheReserv.Show()
        Else
            MessageBox.Show("Veuillez sélectionner une réservation", "Erreur", MessageBoxButton.OK, MessageBoxImage.Exclamation)
        End If
    End Sub

    Private Sub btnDepart_Click(sender As Object, e As RoutedEventArgs) Handles btnDepart.Click
        If dgDepart.SelectedItem IsNot Nothing Then
            Dim depart = dgDepart.SelectedItem
            depart.tblSalle.statutSalle = "Libre"
            bd.SaveChanges()
        Else
            MessageBox.Show("Veuillez sélectionner une réservation", "Erreur", MessageBoxButton.OK, MessageBoxImage.Exclamation)
        End If
    End Sub

    Private Sub btnArrive_Click(sender As Object, e As RoutedEventArgs) Handles btnArrive.Click
        If dgArrive.SelectedItem IsNot Nothing Then
            Dim arrive = dgArrive.SelectedItem
            Dim fiche = New iFicheReservFacture(bd, noEmp, noHotel, arrive.noReservation)
            arrive.tblSalle.statutSalle = "Occuper"
            Dim note = New tblNote()
            note.noReservation = arrive.noReservation
            note.etatNote = "Actif"
            bd.tblNote.Add(note)
            bd.SaveChanges()
            fiche.Owner = Me
            fiche.Show()
        Else
            MessageBox.Show("Veuillez sélectionner une réservation", "Erreur", MessageBoxButton.OK, MessageBoxImage.Exclamation)
        End If
    End Sub

    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim check = New iCheck_in_out(bd, noEmp, noHotel)
        check.Owner = Me
        check.Show()
    End Sub

    Private Sub MenuItem_Click_1(sender As Object, e As RoutedEventArgs)
        Dim facture = New iFacture(bd, noEmp, noHotel)
        facture.Owner = Me
        facture.Show()
    End Sub

    Private Sub MenuItem_Click_2(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeClient
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click_3(sender As Object, e As RoutedEventArgs)
        Dim reserv = New iFaireReservationChambre(bd, noEmp, noHotel)
        reserv.Owner = Me
        reserv.Show()
    End Sub

    Private Sub MenuItem_Click_4(sender As Object, e As RoutedEventArgs)
        Dim ficheR = New iFicheReserv(bd, noEmp, noHotel)
        ficheR.Owner = Me
        ficheR.Show()
    End Sub

    Private Sub MenuItem_Click_5(sender As Object, e As RoutedEventArgs)
        Dim ficheRF = New iFicheReservFacture(bd, noEmp, noHotel)
        ficheRF.Owner = Me
        ficheRF.Show()
    End Sub

    Private Sub MenuItem_Click_6(sender As Object, e As RoutedEventArgs)
        Dim Cli = New iAjoutCliReserv(noEmp, noHotel, bd)
        Cli.Owner = Me
        Cli.Show()
    End Sub
End Class