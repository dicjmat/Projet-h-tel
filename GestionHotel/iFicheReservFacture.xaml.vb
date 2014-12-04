Public Class iFicheReservFacture

    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Dim noEmp As Integer
    Dim noHotel As Integer
    Dim noReservation As Integer

    Sub New(maBD As P2014_Equipe2_GestionHôtelièreEntities, _noEmp As Integer, _noHotel As Integer)
        InitializeComponent()
        bd = maBD
        noEmp = _noEmp
        noHotel = _noHotel
    End Sub

    Sub New(maBD As P2014_Equipe2_GestionHôtelièreEntities, _noEmp As Integer, _noHotel As Integer, _noReservation As Integer)
        InitializeComponent()
        bd = maBD
        noEmp = _noEmp
        noHotel = _noHotel
        noReservation = _noReservation
        Dim res = From el In bd.tblReservation Where el.noReservation = noReservation Select el

        window_FicheReservFacture.DataContext = res.ToList()
    End Sub
    Private Sub btnAjoutCli_Click(sender As Object, e As RoutedEventArgs) Handles btnFicheCli.Click
        Dim ajout = New iAjoutCliReserv(noEmp, noHotel, bd)
        ajout.Owner = Me
        ajout.Show()
    End Sub
    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Owner.Hide()
        Me.Owner.Show()
        Me.Close()
    End Sub

    Private Sub dgReserv_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dgReserv.SelectionChanged
        noReservation = dgReserv.SelectedItem.noReservation
        Dim res = From el In bd.tblReservation Where el.noReservation = noReservation Select el

        window_FicheReservFacture.DataContext = res.ToList()

        Dim note = (From el In bd.tblNote Where el.noReservation = noReservation Select el).Single
        Dim elem = From el In bd.tblElementNote Where el.noNote = note.noNote Select el
        dgFacture.ItemsSource = elem.ToList()
        txtNoFact.Text = note.noNote.ToString()
    End Sub

    Private Sub window_FicheReservFacture_Loaded(sender As Object, e As RoutedEventArgs) Handles window_FicheReservFacture.Loaded
        Dim today = Date.Now()
        Dim res = From el In bd.tblReservation Join sa In bd.tblSalle On sa.noSalle Equals el.noSalle And sa.noHotel Equals el.noHotel Where el.noHotel = noHotel And sa.statutSalle = "Occuper" And el.dateDebutSejour <= today And el.dateFinSejour >= today Select el
        dgReserv.ItemsSource = res.ToList()

        Dim note = (From el In bd.tblNote Where el.noReservation = noReservation Select el).Single

        Dim elem = From el In bd.tblElementNote Where el.noNote - note.noNote Select el
        dgFacture.ItemsSource = elem.ToList()
        txtNoFact.Text = note.noNote.ToString()
    End Sub

    Private Sub btnConsulter_Click(sender As Object, e As RoutedEventArgs) Handles btnConsulter.Click
        Dim note = New iFacture(bd, noEmp, noHotel, noReservation)
        note.Owner = Me
        note.Show()
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
