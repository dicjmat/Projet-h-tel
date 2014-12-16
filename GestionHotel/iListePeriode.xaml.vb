Public Class iListePeriode
    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Dim noEmp As Integer
    Dim noHotel As Integer
    Dim p1 As Boolean

    Sub New(_bd As P2014_Equipe2_GestionHôtelièreEntities, _noHotel As Integer, _noEmp As Integer)

        InitializeComponent()
        bd = _bd
        noEmp = _noEmp
        noHotel = _noHotel

    End Sub
    Private Sub window_lstPeriode_Loaded(sender As Object, e As RoutedEventArgs) Handles window_lstPeriode.Loaded
        requete()
        Me.Owner.Hide()
    End Sub

    Private Sub requete()
        Dim res = From pe In bd.tblPeriode
                  Join petysa In bd.tblPeriodeTypeSalle
                  On petysa.codePeriode Equals pe.codePeriode
                  Where petysa.noHotel = noHotel
                  Select pe.codePeriode, pe.nomPeriode, dateDebutPeriode = pe.dateDebutPeriode.ToString.Substring(0, 10), dateFinPeriode = pe.dateFinPeriode.ToString.Substring(0, 10)

        dgPeriode.ItemsSource = res.ToList.Distinct
    End Sub

    Private Sub txtRecherche_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtRecherche.TextChanged
        requete()
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
        Me.Owner.Show()
    End Sub

    Private Sub btnAjout_Click(sender As Object, e As RoutedEventArgs) Handles btnAjout.Click
        Dim periode = New iPeriode(bd, noHotel)
        periode.Owner = Me
        periode.Show()
    End Sub

    Private Sub dgPeriode_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dgPeriode.SelectionChanged
        requeteTypeChambre()
    End Sub

    Private Sub requeteTypeChambre()
        If dgPeriode.SelectedIndex <> -1 Then
            Dim periode As String = dgPeriode.SelectedItem.codePeriode
            Dim res = From petych In bd.tblPeriodeTypeSalle
                      Where petych.codePeriode = periode And petych.noHotel = noHotel
                      Select petych.tblTypeSalleHotel.tblTypeSalle.nomTypeSalle, petych.prixSallePeriode, petych.codeTypeSalle

            dgTypeChambre.ItemsSource = res.ToList
        End If
    End Sub

    Private Sub btnModifier_Click(sender As Object, e As RoutedEventArgs)
        'Manque les vérifs
        If dgTypeChambre.SelectedIndex <> -1 Then
            Dim periode As String = dgPeriode.SelectedItem.codePeriode
            Dim type As String = dgTypeChambre.SelectedItem.codeTypeSalle
            Dim prix = InputBox("Entrez le nouveau prix", "Modifier le prix", dgTypeChambre.SelectedItem.prixSallePeriode)
            Dim aModif = From petych In bd.tblPeriodeTypeSalle
                       Where petych.codePeriode = periode And petych.codeTypeSalle = type
                       Select petych
            aModif.Single.prixSallePeriode = prix.Replace(".", ",")
            bd.SaveChanges()
            MessageBox.Show("Le prix a bien été modifié")
        Else
            MessageBox.Show("Veuillez choisir le type de chambre dont vous voulez modifier le prix")
        End If
    End Sub

    Private Sub window_lstPeriode_Activated(sender As Object, e As EventArgs) Handles window_lstPeriode.Activated
        requete()
        requeteTypeChambre()
    End Sub

    Private Sub btnModif_Click(sender As Object, e As RoutedEventArgs)
        Dim periode = New iPeriode(bd, noHotel, dgPeriode.SelectedItem.codePeriode)
        periode.Owner = Me
        periode.Show()
    End Sub

    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim ajout = New iAjoutForf(p1, noHotel, bd)
        ajout.owner = Me
        ajout.Show()
    End Sub

    Private Sub MenuItem_Click_1(sender As Object, e As RoutedEventArgs)
        Dim lst = New ListeForfait(noHotel, bd, noEmp)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click_2(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeSalle(noHotel, bd, noEmp)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click_14(sender As Object, e As RoutedEventArgs)
        Dim rab = New iRabais(noHotel, bd, noEmp)
        rab.Owner = Me
        rab.Show()
    End Sub

    Private Sub MenuItem_Click_15(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListePeriode(bd, noHotel, noEmp)
        lst.Owner = Me
        lst.Show()
    End Sub
End Class
