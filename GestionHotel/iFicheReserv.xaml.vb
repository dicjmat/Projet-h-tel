Public Class iFicheReserv
    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Private noEmp As Integer
    Private noHotel As Integer
    Private noReserv As Integer

    Sub New(maBD As P2014_Equipe2_GestionHôtelièreEntities, _noEmp As Integer, _noHotel As Integer)
        InitializeComponent()
        bd = maBD
        noEmp = _noEmp
        noHotel = _noHotel
    End Sub

    Sub New(_bd As P2014_Equipe2_GestionHôtelièreEntities, _noEmp As Integer, _noHotel As Integer, _noReserv As Integer)
        InitializeComponent()
        bd = _bd
        noEmp = _noEmp
        noHotel = _noHotel
        noReserv = _noReserv

        Dim res = From el In bd.tblReservation Where el.noReservation = noReserv Select el

        window_FicheReserv.DataContext = res.ToList()
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

    Private Sub btnFicheReservF_Click(sender As Object, e As RoutedEventArgs) Handles btnFicheReservF.Click
        Dim ficheRF = New iFicheReservFacture(bd, noEmp, noHotel)
        ficheRF.Owner = Me
        ficheRF.Show()
    End Sub

    Private Sub btnListeCli_Click(sender As Object, e As RoutedEventArgs) Handles btnListeCli.Click
        Dim lst = New iListeClient
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Dim reserv = New iFaireReservationChambre(bd, noEmp, noHotel)
        reserv.Owner = Me
        reserv.Show()
        Me.Close()
    End Sub
End Class
