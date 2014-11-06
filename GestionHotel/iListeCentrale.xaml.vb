Public Class iListeCentrale
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Dim noEmp As Integer
    Dim noHotel As Integer

    Sub New(_bd As P2014_Equipe2_GestionHôtelièreEntities, _noEmp As Integer, _noHotel As Integer)
        InitializeComponent()
        bd = _bd
        noEmp = _noEmp
        noHotel = _noHotel
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Owner.Show()
        Me.Close()
    End Sub

    Private Sub window_lstCentrale_Loaded(sender As Object, e As RoutedEventArgs) Handles window_lstCentrale.Loaded
        requete()
    End Sub

    Private Sub window_lstCentrale_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles window_lstCentrale.Closing
        Me.Owner.Show()
    End Sub

    Private Sub dgProvince_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dgProvince.SelectionChanged
        requete()
    End Sub

    Private Sub dgPays_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dgPays.SelectionChanged
        requete()
    End Sub

    Private Sub btnAjouterProv_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterProv.Click
        If dgPays.SelectedItem IsNot Nothing Then
            Dim prov = New AjoutProvince(dgPays.SelectedItem.codePays, bd)
            prov.Owner = Me
            prov.ShowDialog()
        Else
            MessageBox.Show("Veuiller sélectionner un pays", "Attention", MessageBoxButton.OK, MessageBoxImage.Exclamation)
        End If
    End Sub

    Private Sub btnAjouterVille_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterVille.Click
        If dgProvince.SelectedItem IsNot Nothing Then
            Dim ville = New AjoutVille(dgProvince.SelectedItem.codeProv, bd)
            ville.Owner = Me
            ville.ShowDialog()
        Else
            MessageBox.Show("Veuiller sélectionner une province", "Attention", MessageBoxButton.OK, MessageBoxImage.Exclamation)
        End If
    End Sub

    Private Sub btnAjouterPays_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterPays.Click
        Dim pays = New AjoutPays(bd)
        pays.Owner = Me
        pays.ShowDialog()
    End Sub

    Private Sub window_lstCentrale_Activated(sender As Object, e As EventArgs) Handles window_lstCentrale.Activated
        requete()
    End Sub

    Private Sub requete()
        Dim res = From Pa In bd.tblPays
          Select Pa

        dgPays.ItemsSource = res.ToList

        If dgProvince.SelectedIndex <> -1 Then
            Dim province As String = dgProvince.SelectedItem.codeProv
            Dim resVille = From Vi In bd.tblVille
                      Where Vi.codeProv = province
                      Select Vi

            dgVille.ItemsSource = resVille.ToList
        End If
        If dgPays.SelectedIndex <> -1 Then
            Dim pays As String = dgPays.SelectedItem.codePays
            Dim resProv = From Pro In bd.tblProvince
                      Where Pro.codePays = pays
                      Select Pro

            dgProvince.ItemsSource = resProv.ToList
        End If
    End Sub

    Private Sub btnAjoutFourni_Click(sender As Object, e As RoutedEventArgs) Handles btnAjoutFourni.Click
        Dim ajout = New iAjoutFournisseur(bd)
        ajout.Owner = Me
        ajout.Show()
    End Sub

    Private Sub btnAjouterItem_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterItem.Click
        Dim ajout = New iAjouterItem(bd)
        ajout.Owner = Me
        ajout.Show()
    End Sub

    Private Sub btnCommande_Click(sender As Object, e As RoutedEventArgs) Handles btnCommande.Click
        Dim com = New iCommande(noEmp, bd)
        com.Owner = Me
        com.Show()
    End Sub

    Private Sub btnFicheEmp_Click(sender As Object, e As RoutedEventArgs) Handles btnFicheEmp.Click
        Dim fiche = New iFicheEmploye(bd)
        fiche.Owner = Me
        fiche.Show()
    End Sub

    Private Sub btnGSalle_Click(sender As Object, e As RoutedEventArgs) Handles btnGSalle.Click
        Dim gSalle = New iGestionSalle(bd)
        gSalle.Owner = Me
        gSalle.Show()
    End Sub

    Private Sub btnGChambre_Click(sender As Object, e As RoutedEventArgs) Handles btnGChambre.Click
        Dim gC = New iGestionChambre(bd, noHotel)
        gC.Owner = Me
        gC.Show()
    End Sub

    Private Sub btnGHotel_Click(sender As Object, e As RoutedEventArgs) Handles btnGHotel.Click
        Dim gh = New iGestionHotel(bd)
        gh.Owner = Me
        gh.Show()
    End Sub

    Private Sub btnIventaire_Click(sender As Object, e As RoutedEventArgs) Handles btnInventaire.Click
        Dim inv = New iInventaire(noEmp, noHotel, bd)
        inv.Owner = Me
        inv.Show()
    End Sub

    Private Sub btniComplet_Click(sender As Object, e As RoutedEventArgs) Handles btnIComplet.Click
        Dim invC = New iInventaireComplet(bd, noEmp, noHotel)
        invC.Owner = Me
        invC.Show()
    End Sub

    Private Sub btnLEmpCentrale_Click(sender As Object, e As RoutedEventArgs) Handles btnLEmpCentrale.Click
        Dim lst = New iListeEmployeComplet(bd, noEmp, noHotel)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub btnLHotel_Click(sender As Object, e As RoutedEventArgs) Handles btnLHotel.Click
        Dim lst = New iListeHotel(bd, noEmp, noHotel)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub btnLSalle_Click(sender As Object, e As RoutedEventArgs) Handles btnLSalle.Click
        Dim lst = New iListeSalle(noHotel, bd, noEmp)
        lst.Owner = Me
        lst.Show()
    End Sub
End Class
