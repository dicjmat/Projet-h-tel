Public Class iListeEmployeComplet
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Dim noEmp As Integer
    Dim noHotel As Integer

    Sub New(_bd As P2014_Equipe2_GestionHôtelièreEntities, _noEmp As Integer, _noHotel As Integer)
        InitializeComponent()
        bd = _bd
        noEmp = _noEmp
        noHotel = _noHotel
    End Sub

    Private Sub btnAjout_Click(sender As Object, e As RoutedEventArgs) Handles btnAjout.Click
        Dim emp = New iFicheEmploye(bd)
        emp.Owner = Me
        emp.Show()
        Me.Hide()
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub

    Private Sub window_lstEmployeComplet_Loaded(sender As Object, e As RoutedEventArgs) Handles window_lstEmployeComplet.Loaded
        Me.Owner.Hide()
        Dim hotel = From ho In bd.tblHotel
                    Select ho
        cbHotel.DataContext = hotel.ToList
        requete()
    End Sub

    Private Sub requete()
        If cbHotel.SelectedIndex <> -1 Then
            Dim hotel As Integer = cbHotel.SelectedItem.noHotel
            Dim res = From el In bd.tblEmploye
                      Where el.noHotel = hotel And (el.noEmpl.ToString.StartsWith(txtRecherche.Text) Or (el.nomEmpl + " " + el.prenEmpl).StartsWith(txtRecherche.Text) Or (el.prenEmpl + " " + el.nomEmpl).StartsWith(txtRecherche.Text) Or el.codeProf.StartsWith(txtRecherche.Text))
                      Select el

            dgEmploye.ItemsSource = res.ToList()
        End If
    End Sub

    Private Sub cbHotel_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cbHotel.SelectionChanged
        requete()
    End Sub

    Private Sub txtRecherche_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtRecherche.TextChanged
        requete()
    End Sub

    Private Sub btnModif_Click(sender As Object, e As RoutedEventArgs) Handles btnModif.Click
        If dgEmploye.SelectedIndex <> -1 Then
            Dim numEmpl = dgEmploye.SelectedItem.noEmpl
            Dim iEmploye As New iFicheEmploye(noEmp, noHotel, numEmpl, bd)
            iEmploye.Owner = Me
            Me.Hide()
            iEmploye.Show()
        Else
            MessageBox.Show("Veuillez sélectionner un employé")
        End If
    End Sub

    Private Sub window_lstEmployeComplet_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles window_lstEmployeComplet.Closing
        Me.Owner.Show()
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

    Private Sub btnLCentrale_Click(sender As Object, e As RoutedEventArgs) Handles btnLCentrale.Click
        Dim lst = New iListeCentrale(bd, noEmp, noHotel)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub btniCommande_Click(sender As Object, e As RoutedEventArgs) Handles btnIComplet.Click
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
