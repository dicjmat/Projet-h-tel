Class iAjouterItem
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Private _item As String
    Dim noEmp As Integer
    Dim noHotel As Integer
    Dim p2 As Integer

    Sub New(maBD As P2014_Equipe2_GestionHôtelièreEntities)
        InitializeComponent()
        bd = maBD
        cbFournisseur.Visibility = Windows.Visibility.Hidden
        btnAjoutFour.Visibility = Windows.Visibility.Hidden
        btnAjoutFour.IsEnabled = False
        btnAjouterItem.Visibility = Windows.Visibility.Visible
        btnAjouterItem.IsEnabled = True
        btnModifierItem.Visibility = Windows.Visibility.Hidden
        btnModifierItem.IsEnabled = False
        lblFourni.Visibility = Windows.Visibility.Hidden
    End Sub

    Sub New(item As String, _bd As P2014_Equipe2_GestionHôtelièreEntities)
        InitializeComponent()
        _item = item
        bd = _bd
        lblFourni.Visibility = Windows.Visibility.Visible
        btnAjouterItem.Visibility = Windows.Visibility.Hidden
        btnAjouterItem.IsEnabled = False
        cbFournisseur.Visibility = Windows.Visibility.Visible
        btnAjoutFour.Visibility = Windows.Visibility.Visible
        btnAjoutFour.IsEnabled = True
        btnModifierItem.Visibility = Windows.Visibility.Visible
        btnModifierItem.IsEnabled = True

        Dim res = From it In bd.tblItem
                  Join ca In bd.tblCatalogue
                  On ca.codeItem Equals it.codeItem
                  Join fo In bd.tblFournisseur
                  On ca.noFournisseur Equals fo.noFournisseur
                  Where it.codeItem = item
                  Select it.codeItem, it.descItem, it.nomItem, fo.nomFournisseur

        txtRCodeItem.Text = res.First.codeItem
        txtRCodeItem.IsEnabled = False
        txtNomItem.Text = res.First.nomItem
        txtDescItem.Text = res.First.descItem
        cbFournisseur.ItemsSource = res.ToList
    End Sub

    Private Sub Viewbox_Loaded(sender As Object, e As RoutedEventArgs)
        Me.Owner.Hide()
    End Sub
    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub

    Private Sub btnAjoutFour_Click(sender As Object, e As RoutedEventArgs) Handles btnAjoutFour.Click
        Dim fournisseur = New iAjoutFournisseur(bd)
        fournisseur.Owner = Me
        fournisseur.Show()
        Me.Hide()
    End Sub

    Private Sub windowAjoutItem_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles windowAjoutItem.Closing
        Me.Owner.Show()
    End Sub

    Private Sub btnAjouterItem_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterItem.Click
        Dim Item = New tblItem()
        If txtRCodeItem.Text <> "" Or txtNomItem.Text <> "" Then
            Item.codeItem = txtRCodeItem.Text
            Item.nomItem = txtNomItem.Text
            Item.descItem = txtDescItem.Text

            bd.tblItem.Add(Item)
            bd.SaveChanges()
            MessageBox.Show("L'item a été créé avec succès.")
        Else
            MessageBox.Show("Un des champs obligatoire n'a pas été remplis")
        End If


    End Sub

    Private Sub btnModifierItem_Click(sender As Object, e As RoutedEventArgs) Handles btnModifierItem.Click
        Dim item = From it In bd.tblItem
                   Where it.codeItem = _item
                   Select it

        If txtRCodeItem.Text <> "" Or txtNomItem.Text <> "" Then
            item.Single.codeItem = txtRCodeItem.Text
            item.Single.nomItem = txtNomItem.Text
            item.Single.descItem = txtDescItem.Text

            bd.SaveChanges()
            MessageBox.Show("L'item a été modifié avec succès.")
            Me.Close()
        Else
            MessageBox.Show("Un des champs obligatoire n'a pas été remplis")
        End If
    End Sub

    Private Sub btnInventaireGerant_Click(sender As Object, e As RoutedEventArgs) Handles btnInventaireGerant.Click
        Dim inv = New iInventaire(noEmp, noHotel, bd)
        inv.Owner = Me
        inv.Show()
    End Sub

    Private Sub btnAjoutFourniGerant_Click(sender As Object, e As RoutedEventArgs) Handles btnAjoutFourniGerant.Click
        Dim fourni = New iAjoutFournisseur(bd)
        fourni.Owner = Me
        fourni.Show()
    End Sub

    Private Sub btnCommandeGerant_Click(sender As Object, e As RoutedEventArgs) Handles btnCommandeGerant.Click
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
        Dim salle = New iGestionSalle(bd)
        salle.Owner = Me
        salle.Show()
    End Sub

    Private Sub btnGChambre_Click(sender As Object, e As RoutedEventArgs) Handles btnGChambre.Click
        Dim chambre = New iGestionChambre(bd, p2)
        chambre.Owner = Me
        chambre.Show()
    End Sub

    Private Sub btnGHotel_Click(sender As Object, e As RoutedEventArgs) Handles btnGHotel.Click
        Dim hotel = New iGestionHotel(bd)
        hotel.Owner = Me
        hotel.Show()
    End Sub

    Private Sub btnIComplet_Click(sender As Object, e As RoutedEventArgs) Handles btnIComplet.Click
        Dim inv = New iInventaireComplet(bd, noEmp, noHotel, p2)
        inv.Owner = Me
        inv.Show()
    End Sub

    Private Sub btnLCentrale_Click(sender As Object, e As RoutedEventArgs) Handles btnLCentrale.Click
        Dim lst = New iListeCentrale(bd, noEmp, noHotel, p2)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub btnLEmpCentrale_Click(sender As Object, e As RoutedEventArgs) Handles btnLEmpCentrale.Click
        Dim lst = New iListeEmployeComplet(bd, noEmp, noHotel, p2)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub btnLHotel_Click(sender As Object, e As RoutedEventArgs) Handles btnLHotel.Click
        Dim lst = New iListeHotel(bd, noEmp, noHotel, p2)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub btnLSalle_Click(sender As Object, e As RoutedEventArgs) Handles btnLSalle.Click
        Dim lst = New iListeSalle(noHotel, bd, noEmp)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub btnInventaire_Click(sender As Object, e As RoutedEventArgs) Handles btnInventaire.Click
        Dim inv = New iInventaire(noEmp, noHotel, bd)
        inv.Owner = Me
        inv.Show()
    End Sub

    Private Sub btnAjoutFourni_Click(sender As Object, e As RoutedEventArgs) Handles btnAjoutFourni.Click
        Dim fourni = New iAjoutFournisseur(bd)
        fourni.Owner = Me
        fourni.Show()
    End Sub

    Private Sub btnCommande_Click(sender As Object, e As RoutedEventArgs) Handles btnCommande.Click
        Dim com = New iCommande(noEmp, bd)
        com.Owner = Me
        com.Show()
    End Sub
End Class
