Public Class iFaireReservation
    Private noEmpl As Short
    Private noHotel As Short
    Dim TypeSalle As String
    Dim listClient As iListeClient
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Sub New(maBD As P2014_Equipe2_GestionHôtelièreEntities, noEmploye As Short, nHotel As Short)
        ' TODO: Complete member initialization 
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
        Me.Close()
    End Sub

    Private Sub btnReserv_Click(sender As Object, e As RoutedEventArgs) Handles btnReserv.Click
        listClient = New iListeClient(bd, noEmpl, noHotel, dpDebut.SelectedDate, dpFin.SelectedDate, dgReserv.SelectedItem.noSalle)
        listClient.Owner = Me
        listClient.Show()
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

    Private Sub dgReserv_SelectionChanged_1(sender As Object, e As SelectionChangedEventArgs) Handles dgReserv.SelectionChanged
        Dim nocha As Int16
        nocha = dgReserv.SelectedItem.noSalle
        btnReserv.IsEnabled = True
    End Sub
End Class
