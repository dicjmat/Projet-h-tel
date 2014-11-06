Public Class iListePeriode
    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Private hotel As Short

    Sub New(_bd As P2014_Equipe2_GestionHôtelièreEntities, _hotel As Short)
        InitializeComponent()
        bd = _bd
        hotel = _hotel
    End Sub

    Private Sub window_lstPeriode_Loaded(sender As Object, e As RoutedEventArgs) Handles window_lstPeriode.Loaded
        requete()
    End Sub

    Private Sub requete()
        Dim res = From pe In bd.tblPeriode
                  Join petysa In bd.tblPeriodeTypeSalle
                  On petysa.codePeriode Equals pe.codePeriode
                  Where petysa.noHotel = hotel
                  Select pe.codePeriode, pe.nomPeriode, dateDebutPeriode = pe.dateDebutPeriode.ToString.Substring(0, 10), dateFinPeriode = pe.dateFinPeriode.ToString.Substring(0, 10), petysa

        dgPeriode.ItemsSource = res.ToList
    End Sub

    Private Sub txtRecherche_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtRecherche.TextChanged
        requete()
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
        Me.Owner.Show()
    End Sub

    Private Sub btnAjout_Click(sender As Object, e As RoutedEventArgs) Handles btnAjout.Click

    End Sub

    Private Sub dgPeriode_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dgPeriode.SelectionChanged
        If dgPeriode.SelectedIndex <> -1 Then
            requeteTypeChambre()
        End If
    End Sub

    Private Sub requeteTypeChambre()
        Dim periode As String = dgPeriode.SelectedItem.codePeriode
        Dim res = From petych In bd.tblPeriodeTypeSalle
                  Where petych.codePeriode = periode And petych.noHotel = hotel
                  Select petych.tblTypeSalleHotel.tblTypeSalle.nomTypeSalle, petych.prixSallePeriode

        dgTypeChambre.ItemsSource = res.ToList
    End Sub
End Class
