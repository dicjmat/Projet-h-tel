Public Class iListeReservComplet
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Dim noEmp As Integer
    Dim noHotel As Integer
    Dim noChambre As Integer
    Dim p1 As Boolean
    Dim datedeb As Date
    Dim datefin As Date
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
        Dim lst = New iListeClient(bd, noHotel, noEmp)
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
        Me.Owner.Show()
        Me.Close()
    End Sub

    Private Sub window_lstReservComplet_Loaded(sender As Object, e As RoutedEventArgs) Handles window_lstReservComplet.Loaded
        delRes()
    End Sub

    Private Sub dgReserv_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dgReserv.SelectionChanged
        SuppReserv.IsEnabled = True
        ModifReserv.IsEnabled = True
    End Sub

    Private Sub SuppReserv_Click(sender As Object, e As RoutedEventArgs) Handles SuppReserv.Click
        Try
            Dim dated As Date = dgReserv.SelectedItem.dateDebutSejour
            Dim nocha As Integer = dgReserv.SelectedItem.noSalle
            Dim nohot As Integer = dgReserv.SelectedItem.noHotel
            Dim res = From el In bd.tblReservation Where el.dateDebutSejour = dated And el.noSalle = nocha And el.noHotel = nohot Select el

            bd.tblReservation.Remove(res.Single)
            bd.SaveChanges()
            Me.Hide()
            Me.Show()
            MessageBox.Show("La réservation a été effacé avec succès.")
        Catch
            MessageBox.Show("Vous ne pouvez supprimer une réservation qui contient une note.")
        End Try
    End Sub

    Private Sub ModifReserv_Click(sender As Object, e As RoutedEventArgs) Handles ModifReserv.Click
        datedeb = dgReserv.SelectedItem.dateDebutSejour
        datefin = dgReserv.SelectedItem.dateFinSejour
        noChambre = dgReserv.SelectedItem.noSalle
        noHotel = dgReserv.SelectedItem.noHotel

        Dim lst = New ModifierReserv(bd, datedeb, datefin, noChambre, noHotel)
        lst.Owner = Me
        lst.Show()
    End Sub

    Sub delRes()
        SuppReserv.IsEnabled = False
        ModifReserv.IsEnabled = False
        Dim res = From el In bd.tblClient
        Join reserv In bd.tblReservation On el.noClient Equals reserv.noClient
        Where reserv.noHotel = noHotel
        Select el.prenClient, el.nomClient, el.noTelClient, el.noCellClient, reserv.dateDebutSejour, reserv.dateFinSejour, reserv.noSalle, reserv.noHotel
        dgReserv.ItemsSource = res.ToList
    End Sub

    Private Sub TextBox_TextChanged(sender As Object, e As TextChangedEventArgs)
        requete2()
    End Sub

    Sub requete2()
        Dim res = From el In bd.tblClient
             Join reserv In bd.tblReservation On el.noClient Equals reserv.noClient
          Where (el.nomClient + " " + el.prenClient).StartsWith(textnom.Text) Or (el.prenClient + " " + el.nomClient).StartsWith(textnom.Text)
                  Select el.prenClient, el.nomClient, el.noTelClient, el.noCellClient, reserv.dateDebutSejour, reserv.dateFinSejour, reserv.noSalle, reserv.noHotel
        dgReserv.ItemsSource = res.ToList()
    End Sub
End Class
