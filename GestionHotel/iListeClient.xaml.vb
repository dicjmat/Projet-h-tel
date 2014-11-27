Public Class iListeClient
    Private noEmpl As Short
    Private noHotel As Short
    Private dated As Date
    Private datef As Date
    Private noSalle As Short
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities

    Sub New(maBD As P2014_Equipe2_GestionHôtelièreEntities, noEmploye As Short, nHotel As Short, _dated As Date, _datef As Date, _nochambre As Int16)
        InitializeComponent()
        bd = maBD
        noEmpl = noEmploye
        noHotel = nHotel
        dated = _dated
        datef = _datef
        noSalle = _nochambre
    End Sub

    Sub New(maBD As P2014_Equipe2_GestionHôtelièreEntities, noEmploye As Short, nHotel As Short, _dated As Date, _datef As Date, _nosalle As Int16, _vente As Boolean)
        InitializeComponent()
        bd = maBD
        noEmpl = noEmploye
        noHotel = nHotel
        dated = _dated
        datef = _datef
        noSalle = _nosalle
        Menu.Visibility = Windows.Visibility.Hidden
    End Sub

    Sub New()
        InitializeComponent()
        btnReserv.IsEnabled = False
        btnReserv.Visibility = Windows.Visibility.Hidden
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        requete()
        btnReserv.IsEnabled = False
        btnModifierClient.IsEnabled = False
        btnLierClient.IsEnabled = False
        cbCompagnie.IsEnabled = False
        Dim res3 = From el In bd.tblCompagnie Select el
        cbCompagnie.DataContext = res3.Distinct().ToList()
    End Sub
    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Owner.Hide()
        Me.Owner.Show()
        Me.Close()
    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Me.Owner.Show()
    End Sub

    Private Sub txtRCli_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtRCli.TextChanged
        requete2()
    End Sub

    Private Sub requete()
        Dim res = From el In bd.tblClient
        Select el
        dgClient.ItemsSource = res.ToList

    End Sub

    Private Sub btnReserv_Click(sender As Object, e As RoutedEventArgs) Handles btnReserv.Click
        Dim reserv As New tblReservation
        reserv.tblSalle = (From el In bd.tblSalle Where noSalle = el.noSalle And noHotel = el.noHotel Select el).Single
        reserv.dateDebutSejour = dated
        reserv.dateFinSejour = datef
        reserv.dateReserv = DateValue(Now)
        reserv.noSalle = noSalle
        reserv.noHotel = noHotel
        reserv.noClient = dgClient.SelectedItem.noClient
        reserv.noEmpl = noEmpl
        bd.tblReservation.Add(reserv)
        bd.SaveChanges()
        MessageBox.Show("La réservation a été créé avec succès.")
        Me.Owner.Hide()
        Me.Owner.Show()
        Me.Close()
    End Sub

    Private Sub dgClient_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dgClient.SelectionChanged
        btnReserv.IsEnabled = True
        btnModifierClient.IsEnabled = True
        cbCompagnie.IsEnabled = True
    End Sub

    Private Sub btnAjouterClient_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterClient.Click
        Dim client As New iAjoutCliReserv(noHotel, noEmpl, bd)
        client.Owner = Me
        client.Show()
    End Sub

    Private Sub btnModifierClient_Click(sender As Object, e As RoutedEventArgs) Handles btnModifierClient.Click
        Dim client As New iAjoutCliReserv(bd, dgClient.SelectedItem.noClient, noEmpl, noHotel)
        client.Owner = Me
        client.Show()
    End Sub

    Private Sub requete2()

        Dim res = From el In bd.tblClient
                  Where (el.nomClient + " " + el.prenClient).StartsWith(txtRCli.Text) Or (el.prenClient + " " + el.nomClient).StartsWith(txtRCli.Text)
                  Select el
        dgClient.ItemsSource = res.ToList()
    End Sub
    Private Sub btnCheck_Click(sender As Object, e As RoutedEventArgs) Handles btnCheck.Click
        Dim check = New iCheck_in_out(bd, noEmpl, noHotel)
        check.Owner = Me
        check.Show()
    End Sub

    Private Sub btnReservC_Click(sender As Object, e As RoutedEventArgs) Handles btnReservC.Click
        Dim reserv = New iFaireReservationChambre(bd, noEmpl, noHotel)
        reserv.Owner = Me
        reserv.Show()
    End Sub

    Private Sub btnFact_Click(sender As Object, e As RoutedEventArgs) Handles btnFact.Click
        Dim facture = New iFacture(bd, noEmpl, noHotel)
        facture.Owner = Me
        facture.Show()
    End Sub

    Private Sub btnAjoutCli_Click(sender As Object, e As RoutedEventArgs) Handles btnFicheC.Click
        Dim ajout = New iAjoutCliReserv(noEmpl, noHotel, bd)
        ajout.Owner = Me
        ajout.Show()
    End Sub

    Private Sub btnFicheReservF_Click(sender As Object, e As RoutedEventArgs) Handles btnFicheReservF.Click
        Dim ficheRF = New iFicheReservFacture(bd, noEmpl, noHotel)
        ficheRF.Owner = Me
        ficheRF.Show()
    End Sub

    Private Sub btnFichereserv_Click(sender As Object, e As RoutedEventArgs) Handles btnFicheReserv.Click
        Dim ficheR = New iFicheReserv(bd, noEmpl, noHotel)
        ficheR.Owner = Me
        ficheR.Show()
    End Sub

    Private Sub btnLierClient_Click(sender As Object, e As RoutedEventArgs) Handles btnLierClient.Click
        dgClient.SelectedItem.noCompagnie = cbCompagnie.SelectedItem.noCompagnie
        MessageBox.Show("La liaison a été faite avec succès.")
    End Sub

    Private Sub cbCompagnie_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cbCompagnie.SelectionChanged
        btnLierClient.IsEnabled = True
    End Sub
End Class
