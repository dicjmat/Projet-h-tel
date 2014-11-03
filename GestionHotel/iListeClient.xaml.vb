Public Class iListeClient
    Private noEmpl As Short
    Private noHotel As Short
    Private dated As Date
    Private datef As Date
    Private noChambre As Short
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities

    Sub New(maBD As P2014_Equipe2_GestionHôtelièreEntities, noEmploye As Short, nHotel As Short, _dated As Date, _datef As Date, _nochambre As Int16)
        ' TODO: Complete member initialization 
        InitializeComponent()
        bd = maBD
        noEmpl = noEmploye
        noHotel = nHotel
        dated = _dated
        datef = _datef
        noChambre = _nochambre
    End Sub

    Sub New()
        ' TODO: Complete member initialization 
        InitializeComponent()
        btnReserv.IsEnabled = False
        btnReserv.Visibility = Windows.Visibility.Hidden

    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        requete()
        btnReserv.IsEnabled = False
        btnModifierClient.IsEnabled = False
    End Sub
    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        'Dim accueil = New iFaireReservation
        'accueil.Owner = Me
        'accueil.Show()
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
        reserv.dateDebutSejour = dated
        reserv.dateFinSejour = datef
        reserv.dateReserv = DateValue(Now)
        reserv.noSalle = noChambre
        reserv.noHotel = noHotel
        reserv.noClient = dgClient.SelectedItem.noClient
        reserv.noEmpl = noEmpl
        bd.tblReservation.Add(reserv)
        bd.SaveChanges()
        MessageBox.Show("La réservation a été créé avec succès.")
    End Sub

    Private Sub dgClient_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dgClient.SelectionChanged
        btnReserv.IsEnabled = True
        btnModifierClient.IsEnabled = True
    End Sub

    Private Sub btnAjouterClient_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterClient.Click
        Dim client As New iAjoutCliReserv
        client.Owner = Me
        client.Show()
    End Sub

    Private Sub btnModifierClient_Click(sender As Object, e As RoutedEventArgs) Handles btnModifierClient.Click
        Dim client As New iAjoutCliReserv(bd, dgClient.SelectedItem.nomClient, dgClient.SelectedItem.prenClient, dgClient.SelectedItem.noTelClient, dgClient.SelectedItem.noCellClient, dgClient.SelectedItem.adrClient, dgClient.SelectedItem.noCarteCredit, dgClient.SelectedItem.typeCarteCredit, dgClient.SelectedItem.dateExpiration)
        client.Owner = Me
        client.Show()
    End Sub

    Private Sub requete2()

        Dim res = From el In bd.tblClient
                  Where (el.nomClient + " " + el.prenClient).StartsWith(txtRCli.Text) Or (el.prenClient + " " + el.nomClient).StartsWith(txtRCli.Text)
                  Select el
        'el.noEmpl, el.nomEmpl, el.prenEmpl, el.codeProf
        dgClient.ItemsSource = res.ToList()
    End Sub
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

    Private Sub btnFichereserv_Click(sender As Object, e As RoutedEventArgs) Handles btnFicheReserv.Click
        Dim ficheR = New iFicheReserv
        ficheR.Owner = Me
        ficheR.Show()
    End Sub
End Class
