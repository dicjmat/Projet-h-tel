Public Class iCommande
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Dim lstCommande As New List(Of tblLigneCommande)
    Dim lstAffichage As New List(Of Object)
    Dim prixTotal
    Private _noEmpl As Short
    Dim noHotel As Integer
    Dim p2 As Integer

    Sub New(noEmpl As Short, maBD As P2014_Equipe2_GestionHôtelièreEntities)
        InitializeComponent()
        _noEmpl = noEmpl
        bd = maBD
    End Sub

    Private Sub Grid_Loaded(sender As Object, e As RoutedEventArgs)
        Me.Owner.Hide()
        prixTotal = 0
        Dim res = From It In bd.tblItem Join FoIt In bd.tblCatalogue On It.codeItem Equals FoIt.codeItem Join Fo In bd.tblFournisseur On FoIt.noFournisseur Equals Fo.noFournisseur
                    Select It.codeItem, It.nomItem, FoIt.prixItem, Fo.nomFournisseur, Fo.noFournisseur

        dgCommande.ItemsSource = res.ToList()

    End Sub
    Private Sub btnAjouterItemComm_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterItemComm.Click
        'Dim prix = From item In bd.tblItem
        'Where txtCodeItem.Text = item.codeItem And 
        'Select prix
        Dim pareil As Boolean = False
        If dgCommande.SelectedIndex <> -1 Then
            For Each el In lstAffichage
                If el.codeItem = dgCommande.SelectedItem.codeItem And el.noFournisseur = dgCommande.SelectedItem.noFournisseur Then
                    pareil = True
                End If
            Next
            If Not pareil Then

                Dim ligne = New tblLigneCommande
                ligne.codeItem = dgCommande.SelectedItem.CodeItem
                ligne.quantite = txtQteCom.Text
                ligne.prixUnitaire = dgCommande.SelectedItem.prixItem
                lstCommande.Add(ligne)
                Dim affichage = New With {.nomFournisseur = dgCommande.SelectedItem.nomFournisseur _
                                         , .quantite = ligne.quantite _
                                         , .prixLigne = ligne.prixUnitaire * ligne.quantite _
                                         , .nomItem = dgCommande.SelectedItem.nomItem _
                                         , .codeItem = dgCommande.SelectedItem.codeItem _
                                         , .noFournisseur = dgCommande.SelectedItem.noFournisseur}
                lstAffichage.Add(affichage)
                lstViewCommande.ItemsSource = lstAffichage.ToList()
                prixTotal += ligne.prixUnitaire * ligne.quantite
                lblPrixComm.Content = Convert.ToDouble(prixTotal).ToString() + " $"
                requete()
            Else
                MessageBox.Show("Vous ne pouvez entrer qu'une seule fois le même item")
            End If
        Else
            MessageBox.Show("Veuillez sélectionner un item dans la liste")
        End If
    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Me.Owner.Show()
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub

    Private Sub txtRecherche_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtRecherche.TextChanged
        requete()
    End Sub

    Private Sub dgCommande_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dgCommande.SelectionChanged
        If dgCommande.SelectedIndex <> -1 Then
            calculPrixTot(dgCommande.SelectedItem.prixItem())
        End If

    End Sub


    Private Sub calculPrixTot(dPrix As Decimal)
        If txtQteCom.Text <> "" Then
            lblPrixTotItem.Content = (dPrix * Convert.ToDouble(txtQteCom.Text)).ToString() + " $"
        End If

    End Sub

    Private Sub txtQteCom_ValueChanged(sender As Object, e As RoutedPropertyChangedEventArgs(Of Object)) Handles txtQteCom.ValueChanged
        If dgCommande.SelectedIndex <> -1 Then
            calculPrixTot(dgCommande.SelectedItem.prixItem())
        End If
    End Sub

    Private Sub btnSupprimerItemComm_Click(sender As Object, e As RoutedEventArgs) Handles btnSupprimerItemComm.Click
        If lstViewCommande.SelectedIndex <> -1 Then
            For Each el In lstAffichage
                If el.nomItem = lstViewCommande.SelectedItem.nomItem Then
                    lstAffichage.Remove(el)
                    Exit For
                End If
            Next
            For Each el In lstCommande
                If el.prixUnitaire = lstViewCommande.SelectedItem.prixUnitaire And el.codeItem = lstViewCommande.SelectedItem.codeItem Then
                    prixTotal -= el.prixUnitaire * el.quantite
                    lblPrixComm.Content = Convert.ToDouble(prixTotal).ToString() + " $"
                    lstCommande.Remove(el)
                    Exit For
                End If
            Next
            lstViewCommande.ItemsSource = lstAffichage.ToList
            requete()
        Else
            MessageBox.Show("Veuillez sélectionner l'item que vous voulez supprimer")
        End If
    End Sub

    Private Sub btnFaireComm_Click(sender As Object, e As RoutedEventArgs) Handles btnFaireComm.Click
        Dim commande = New tblCommande
        If lstViewCommande.ItemsSource IsNot Nothing Then
            commande.dateCommande = Date.Today
            commande.prixCommande = prixTotal
            commande.etatCommande = "NL"
            commande.noFournisseur = dgCommande.SelectedItem.noFournisseur
            commande.noEmpl = _noEmpl
            For Each el In lstCommande
                commande.tblLigneCommande.Add(el)
            Next
            bd.tblCommande.Add(commande)
            bd.SaveChanges()
            MessageBox.Show("Votre commande a été enregistrée avec succès!")
            viderListes()
        Else
            MessageBox.Show("Vous devez choisir au moins un item avant de créer la commande")
        End If


    End Sub

    Private Sub viderListes()
        lstAffichage.Clear()
        lstCommande.Clear()
        lstViewCommande.ItemsSource = lstAffichage.ToList()
        lblPrixComm.Content = ""
    End Sub

    Private Sub requete()
        Dim res As System.Linq.IQueryable(Of Object)
        If lstViewCommande.Items.Count <> 0 Then
            Dim fournisseur As Integer = lstViewCommande.Items.Item(0).noFournisseur
            res = From It In bd.tblItem Join FoIt In bd.tblCatalogue On It.codeItem Equals FoIt.codeItem Join Fo In bd.tblFournisseur On FoIt.noFournisseur Equals Fo.noFournisseur
                Where (It.codeItem.StartsWith(txtRecherche.Text) Or It.nomItem.StartsWith(txtRecherche.Text) Or Fo.nomFournisseur.StartsWith(txtRecherche.Text)) And fournisseur = Fo.noFournisseur
                Select It.codeItem, It.nomItem, FoIt.prixItem, Fo.nomFournisseur, Fo.noFournisseur
        Else
            res = From It In bd.tblItem Join FoIt In bd.tblCatalogue On It.codeItem Equals FoIt.codeItem Join Fo In bd.tblFournisseur On FoIt.noFournisseur Equals Fo.noFournisseur
                Where It.codeItem.StartsWith(txtRecherche.Text) Or It.nomItem.StartsWith(txtRecherche.Text) Or Fo.nomFournisseur.StartsWith(txtRecherche.Text)
                Select It.codeItem, It.nomItem, FoIt.prixItem, Fo.nomFournisseur, Fo.noFournisseur
        End If



        dgCommande.ItemsSource = res.ToList()
    End Sub

    Private Sub btnInventaireGerant_Click(sender As Object, e As RoutedEventArgs) Handles btnInventaireGerant.Click
        Dim inv = New iInventaire(_noEmpl, noHotel, bd)
        inv.Owner = Me
        inv.Show()
    End Sub

    Private Sub btnAjoutFourniGerant_Click(sender As Object, e As RoutedEventArgs) Handles btnAjoutFourniGerant.Click
        Dim fourni = New iAjoutFournisseur(bd)
        fourni.Owner = Me
        fourni.Show()
    End Sub

    Private Sub btnAjoutItemGerant_Click(sender As Object, e As RoutedEventArgs) Handles btnAjoutItemGerant.Click
        Dim item = New iAjouterItem(bd)
        item.Owner = Me
        item.Show()
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
        Dim inv = New iInventaireComplet(bd, _noEmpl, noHotel)
        inv.Owner = Me
        inv.Show()
    End Sub

    Private Sub btnLCentrale_Click(sender As Object, e As RoutedEventArgs) Handles btnLCentrale.Click
        Dim lst = New iListeCentrale(bd, _noEmpl, noHotel)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub btnLEmpCentrale_Click(sender As Object, e As RoutedEventArgs) Handles btnLEmpCentrale.Click
        Dim lst = New iListeEmployeComplet(bd, _noEmpl, noHotel)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub btnLHotel_Click(sender As Object, e As RoutedEventArgs) Handles btnLHotel.Click
        Dim lst = New iListeHotel(bd, _noEmpl, noHotel)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub btnLSalle_Click(sender As Object, e As RoutedEventArgs) Handles btnLSalle.Click
        Dim lst = New iListeSalle(noHotel, bd, _noEmpl)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub btnAjoutFourni_Click(sender As Object, e As RoutedEventArgs) Handles btnAjoutFourni.Click
        Dim fourni = New iAjoutFournisseur(bd)
        fourni.Owner = Me
        fourni.Show()
    End Sub

    Private Sub btnCommande_Click(sender As Object, e As RoutedEventArgs) Handles btnCommande.Click
        Dim com = New iCommande(_noEmpl, bd)
        com.Owner = Me
        com.Show()
    End Sub

    Private Sub btnAjouterItem_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterItem.Click
        Dim ajout = New iAjouterItem(bd)
        ajout.Owner = Me
        ajout.Show()
    End Sub
End Class
