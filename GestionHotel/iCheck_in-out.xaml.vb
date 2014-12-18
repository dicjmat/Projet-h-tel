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
        Me.Owner.Hide()
        Me.Owner.Show()
        Me.Close()
    End Sub

    Private Sub window_Check_Loaded(sender As Object, e As RoutedEventArgs) Handles window_Check.Loaded
        Dim today = Format(Date.Now, "yyyy-MM-dd")
        Dim arrive = From el In bd.tblReservation
                     Join sa In bd.tblSalle On el.noSalle Equals sa.noSalle And el.noHotel Equals sa.noHotel
                     Where el.dateDebutSejour = today And sa.statutSalle = "Libre" And el.noHotel = noHotel
                     Select el

        dgArrive.ItemsSource = creerAffichage(arrive)

        Dim depart = From el In bd.tblReservation
                     Join sa In bd.tblSalle On el.noSalle Equals sa.noSalle And el.noHotel Equals sa.noHotel
                     Where el.dateFinSejour = today And sa.statutSalle <> "Libre" And el.noHotel = noHotel
                     Select el

        dgDepart.ItemsSource = depart.ToList()
    End Sub

    Private Sub btnConsulterA_Click(sender As Object, e As RoutedEventArgs) Handles btnConsulterA.Click
        If dgArrive.SelectedItem IsNot Nothing Then
            Dim ficheReserv = New iFicheReserv(bd, noEmp, noHotel, dgArrive.SelectedItem.noReservation)
            ficheReserv.Owner = Me
            ficheReserv.Show()
        Else
            MessageBox.Show("Veuillez sélectionner une réservation", "Erreur", MessageBoxButton.OK, MessageBoxImage.Exclamation)
        End If
    End Sub

    Private Sub btnConsulterD_Click(sender As Object, e As RoutedEventArgs) Handles btnConsulterD.Click
        If dgDepart.SelectedItem IsNot Nothing Then
            Dim ficheReserv = New iFicheReserv(bd, noEmp, noHotel, dgArrive.SelectedItem.noReservation)
            ficheReserv.Owner = Me
            ficheReserv.Show()
        Else
            MessageBox.Show("Veuillez sélectionner une réservation", "Erreur", MessageBoxButton.OK, MessageBoxImage.Exclamation)
        End If
    End Sub

    Private Sub btnDepart_Click(sender As Object, e As RoutedEventArgs) Handles btnDepart.Click
        If dgDepart.SelectedItem IsNot Nothing Then
            Dim facture = New iListeFacture(bd, noEmp, noHotel, dgDepart.SelectedItem.tblNote)
            Dim depart = dgDepart.SelectedItem
            depart.tblSalle.statutSalle = "Libre"
            bd.SaveChanges()
            facture.Owner = Me
            facture.Show()
        Else
            MessageBox.Show("Veuillez sélectionner une réservation", "Erreur", MessageBoxButton.OK, MessageBoxImage.Exclamation)
        End If
    End Sub

    Private Sub btnArrive_Click(sender As Object, e As RoutedEventArgs) Handles btnArrive.Click
        If dgArrive.SelectedItem IsNot Nothing Then
            Dim arrive As Integer = dgArrive.SelectedItem.noReservation
            Dim salle = From el In bd.tblSalle Join res In bd.tblReservation On el.noSalle Equals res.noSalle And el.noHotel Equals res.noHotel Where res.noReservation = arrive Select el
            Dim fiche = New iFicheReservFacture(bd, noEmp, noHotel, arrive)
            salle.Single.statutSalle = "Occuper"
            Dim note = New tblNote()
            note.noReservation = arrive
            note.etatNote = "Actif"
            bd.tblNote.Add(note)
            bd.SaveChanges()
            fiche.Owner = Me
            fiche.Show()
        Else
            MessageBox.Show("Veuillez sélectionner une réservation", "Erreur", MessageBoxButton.OK, MessageBoxImage.Exclamation)
        End If
    End Sub

    Private Function creerAffichage(res)
        Dim lstAffichage As New List(Of Object)
        Dim Affichage
        Dim client As Boolean
        For Each el As tblReservation In res
            If el.tblClient IsNot Nothing Then
                client = True
                Affichage = New With {.client = client _
                                , .noSalle = el.noSalle _
                                , .nomClient = el.tblClient.nomClient _
                                , .prenClient = el.tblClient.prenClient _
                                , .noReservation = el.noReservation _
                                , .statutSalle = el.tblSalle.statutSalle}
            Else
                client = False
                Affichage = New With {.client = client _
                                , .noSalle = el.noSalle _
                                , .nomClient = el.tblDemandeur.nomDemandeur _
                                , .prenClient = el.tblDemandeur.prenDemandeur _
                                , .noReservation = el.noReservation _
                                , .statutSalle = el.tblSalle.statutSalle}
            End If
            lstAffichage.Add(Affichage)
        Next
        Return lstAffichage
    End Function

    Private Sub btnLierCli_Click(sender As Object, e As RoutedEventArgs) Handles btnLierCli.Click
        If dgArrive.SelectedItem IsNot Nothing Then
            If dgArrive.SelectedItem.client = False Then
                Dim client = New iListeClient(bd, dgArrive.SelectedItem.noReservation)
                client.Owner = Me
                client.Show()
            Else
                MessageBox.Show("Un client est déjà lié à la réservation", "Attention", MessageBoxButton.OK, MessageBoxImage.Exclamation)
            End If
        Else
            MessageBox.Show("Veuillez sélectionner une réservation", "Attention", MessageBoxButton.OK, MessageBoxImage.Exclamation)
        End If
    End Sub

    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim check = New iCheck_in_out(bd, noEmp, noHotel)
        check.Owner = Me.Owner
        check.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_1(sender As Object, e As RoutedEventArgs)
        Dim facture = New iFacture(bd, noEmp, noHotel)
        facture.Owner = Me.Owner
        facture.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_2(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeClient
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_3(sender As Object, e As RoutedEventArgs)
        Dim reserv = New iFaireReservationChambre(bd, noEmp, noHotel)
        reserv.Owner = Me.Owner
        reserv.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_4(sender As Object, e As RoutedEventArgs)
        Dim ficheR = New iFicheReserv(bd, noEmp, noHotel)
        ficheR.Owner = Me.Owner
        ficheR.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_5(sender As Object, e As RoutedEventArgs)
        Dim ficheRF = New iFicheReservFacture(bd, noEmp, noHotel)
        ficheRF.Owner = Me.Owner
        ficheRF.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_6(sender As Object, e As RoutedEventArgs)
        Dim Cli = New iAjoutCliReserv(noEmp, noHotel, bd)
        Cli.Owner = Me.Owner
        Cli.Show()
        Me.Close()
    End Sub
    Private Sub MenuItem_Click_7(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeReservComplet(bd, noEmp, noHotel)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub
    Private Sub window_Check_Activated(sender As Object, e As EventArgs) Handles window_Check.Activated
        Dim today = Format(Date.Now, "yyyy-MM-dd")
        Dim arrive = From el In bd.tblReservation
                     Join sa In bd.tblSalle On el.noSalle Equals sa.noSalle And el.noHotel Equals sa.noHotel
                     Where el.dateDebutSejour = today And sa.statutSalle = "Libre" And el.noHotel = noHotel
                     Select el

        dgArrive.ItemsSource = creerAffichage(arrive)
    End Sub

End Class

