Public Class iFaireReservationChambre
    Private noEmpl As Short
    Private noHotel As Short
    Dim TypeSalle As String
    Dim listClient As iListeClient
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Sub New(maBD As P2014_Equipe2_GestionHôtelièreEntities, noEmploye As Short, nHotel As Short)
        InitializeComponent()
        bd = maBD
        noEmpl = noEmploye
        noHotel = nHotel
    End Sub
    Private Sub window_FaireReserv_Loaded(sender As Object, e As RoutedEventArgs) Handles window_FaireReserv.Loaded
        bd = New P2014_Equipe2_GestionHôtelièreEntities

        Dim res = From el In bd.tblTypeSalle Select el
        btnReserv.IsEnabled = False
        btnAfficher.IsEnabled = False
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Owner.Hide()
        Me.Owner.Show()
        Me.Close()
    End Sub

    Private Sub btnReserv_Click(sender As Object, e As RoutedEventArgs) Handles btnReserv.Click
        If dgReserv.SelectedItem IsNot Nothing Then
            listClient = New iListeClient(bd, noEmpl, noHotel, dpDebut.SelectedDate, dpFin.SelectedDate, dgReserv.SelectedItem.noSalle)
            listClient.Owner = Me
            listClient.Show()
        Else
            MessageBox.Show("Veuillez sélectionner une chambre", "Attention", MessageBoxButton.OK, MessageBoxImage.Exclamation)
        End If
    End Sub
    Private Sub dpFin_SelectedDateChanged(sender As Object, e As SelectionChangedEventArgs) Handles dpFin.SelectedDateChanged
        If dpDebut.SelectedDate IsNot Nothing Then
            If dpDebut.SelectedDate > dpFin.SelectedDate Then
                MessageBox.Show("La date de début ne peut être plus haute que la date de fin")
                dpDebut.SelectedDate = Nothing
            Else
                btnAfficher.IsEnabled = True
            End If
        End If
    End Sub
    Private Sub dpDebut_SelectedDateChanged(sender As Object, e As SelectionChangedEventArgs) Handles dpDebut.SelectedDateChanged
        If dpFin.SelectedDate IsNot Nothing Then
            If dpDebut.SelectedDate > dpFin.SelectedDate Then
                MessageBox.Show("La date de début ne peut être plus haute que la date de fin")
                dpDebut.SelectedDate = Nothing
            Else
                btnAfficher.IsEnabled = True
            End If
        End If
    End Sub

    Private Sub btnAfficher_Click(sender As Object, e As RoutedEventArgs) Handles btnAfficher.Click
        Dim datef As Date
        Dim dated As Date

        datef = dpFin.SelectedDate
        dated = dpDebut.SelectedDate
        dgReserv.ItemsSource = bd.determinerchambrelibre(dated, datef, noHotel).ToList
    End Sub

    Private Sub dgReserv_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dgReserv.SelectionChanged
        Dim nocha As Int16
        nocha = dgReserv.SelectedItem.noSalle
        btnReserv.IsEnabled = True
    End Sub
    Private Sub window_FaireReserv_Activated(sender As Object, e As EventArgs) Handles window_FaireReserv.Activated
        If dpDebut.Text <> "" And dpFin.Text <> "" Then
            Dim datef As Date
            Dim dated As Date

            datef = dpFin.SelectedDate
            dated = dpDebut.SelectedDate
            dgReserv.ItemsSource = bd.determinerchambrelibre(dated, datef, noHotel).ToList
        End If
    End Sub
    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim check = New iCheck_in_out(bd, noEmpl, noHotel)
        check.Owner = Me.Owner
        check.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_1(sender As Object, e As RoutedEventArgs)
        Dim facture = New iFacture(bd, noEmpl, noHotel)
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
        Dim reserv = New iFaireReservationChambre(bd, noEmpl, noHotel)
        reserv.Owner = Me.Owner
        reserv.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_4(sender As Object, e As RoutedEventArgs)
        Dim ficheR = New iFicheReserv(bd, noEmpl, noHotel)
        ficheR.Owner = Me.Owner
        ficheR.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_5(sender As Object, e As RoutedEventArgs)
        Dim ficheRF = New iFicheReservFacture(bd, noEmpl, noHotel)
        ficheRF.Owner = Me.Owner
        ficheRF.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_6(sender As Object, e As RoutedEventArgs)
        Dim Cli = New iAjoutCliReserv(noEmpl, noHotel, bd)
        Cli.Owner = Me.Owner
        Cli.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_7(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeReservComplet(bd, noEmpl, noHotel)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub
End Class
