Public Class iListeReservComplet
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Dim noEmp As Integer
    Dim noHotel As Integer
    Dim p1 As Boolean
    Sub New(_bd As P2014_Equipe2_GestionHôtelièreEntities, _noEmp As Integer, _noHotel As Integer)
        InitializeComponent()
        bd = _bd
        noEmp = _noEmp
        noHotel = _noHotel
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
    Private Sub MenuItem_Click_7(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeReservComplet(bd, noEmp, noHotel)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub btnAcceuil_Click(sender As Object, e As RoutedEventArgs) Handles btnAcceuil.Click
        Me.Close()
    End Sub

    Private Sub window_lstReservComplet_Loaded(sender As Object, e As RoutedEventArgs) Handles window_lstReservComplet.Loaded
        SuppReserv.IsEnabled = False
        ModifReserv.IsEnabled = False
        Dim res = From el In bd.tblClient.Distinct
        Join reserv In bd.tblReservation.Distinct On el.noClient Equals reserv.noClient
        Join salle In bd.tblSalle.Distinct On reserv.noSalle Equals salle.noSalle
        Select el
        dgReserv.ItemsSource = res.ToList
    End Sub
End Class
