Public Class iListePeriode
    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Dim noEmp As Integer
    Dim noHotel As Integer

    Sub New(_bd As P2014_Equipe2_GestionHôtelièreEntities, _noHotel As Integer, _noEmp As Integer)

        InitializeComponent()
        bd = _bd
        noEmp = _noEmp
        noHotel = _noHotel

    End Sub
    Private Sub window_lstPeriode_Loaded(sender As Object, e As RoutedEventArgs) Handles window_lstPeriode.Loaded
        requete()
    End Sub

    Private Sub requete()
        Dim res = From pe In bd.tblPeriode
                  Join petysa In bd.tblPeriodeTypeSalle
                  On petysa.codePeriode Equals pe.codePeriode
                  Where petysa.noHotel = noHotel
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
    Private Sub btnAjoutForfait_Click(sender As Object, e As RoutedEventArgs) Handles btnAjoutForfait.Click
        Dim forf = New iAjoutForf(True, noHotel, bd)
        forf.Owner = Me
        forf.Show()
    End Sub

    Private Sub btnListeForf_Click(sender As Object, e As RoutedEventArgs) Handles btnListeForf.Click
        Dim lst = New ListeForfait(noHotel, bd, noEmp)
        lst.Owner = Me
        lst.Show()
    End Sub
    Private Sub btnListeSalle_Click(sender As Object, e As RoutedEventArgs) Handles btnListeSalle.Click
        Dim lst = New iListeSalle(noHotel, bd, noEmp)
        lst.Owner = Me
        lst.Show()
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
                  Where petych.codePeriode = periode And petych.noHotel = noHotel
                  Select petych.tblTypeSalleHotel.tblTypeSalle.nomTypeSalle, petych.prixSallePeriode

        dgTypeChambre.ItemsSource = res.ToList
    End Sub
    Private Sub btnRabais_Click(sender As Object, e As RoutedEventArgs) Handles btnRabais.Click
        Dim rab = New iRabais(noHotel, bd, noEmp)
        rab.Owner = Me
        rab.Show()
    End Sub

End Class
