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
        Dim res = From el In bd.tblReservation Where el.noHotel = noHotel Select el

        dgReserv.ItemsSource = res.ToList()
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

    Private Sub btnCheck_Click(sender As Object, e As RoutedEventArgs) Handles btnCheck.Click
        Dim check = New iCheck_in_out(bd, noEmp, noHotel)
        check.Owner = Me
        check.Show()
    End Sub

    Private Sub btnReservC_Click(sender As Object, e As RoutedEventArgs) Handles btnReservC.Click
        Dim reserv = New iFaireReservationChambre(bd, noEmp, noHotel)
        reserv.Owner = Me
        reserv.Show()
    End Sub

    Private Sub btnFact_Click(sender As Object, e As RoutedEventArgs) Handles btnFact.Click
        Dim facture = New iFacture(bd, noEmp, noHotel)
        facture.Owner = Me
        facture.Show()
    End Sub

    Private Sub btnAjoutCli_Click(sender As Object, e As RoutedEventArgs) Handles btnFicheCli.Click
        Dim ajout = New iAjoutCliReserv(noEmp, noHotel, bd)
        ajout.Owner = Me
        ajout.Show()
    End Sub

    Private Sub btnFicheReserv_Click(sender As Object, e As RoutedEventArgs) Handles btnFicheReserv.Click
        Dim ficheR = New iFicheReserv(bd, noEmp, noHotel)
        ficheR.Owner = Me
        ficheR.Show()
    End Sub

    Private Sub btnListeCli_Click(sender As Object, e As RoutedEventArgs) Handles btnListeCli.Click
        Dim lst = New iListeClient
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Dim accueil = New iFaireReservationChambre(bd, noEmp, noHotel)
        accueil.Owner = Me
        accueil.Show()
        Me.Close()
    End Sub

    Private Sub dgReserv_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dgReserv.SelectionChanged
        noReservation = dgFacture.SelectedItem.noReservation
        Dim res = From el In bd.tblReservation Where el.noReservation = noReservation Select el

        window_FicheReservFacture.DataContext = res.ToList()
    End Sub
End Class
