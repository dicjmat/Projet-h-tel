Public Class iCommande
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Dim lstCommande As New List(Of tblLigneCommande)
    Dim lstAffichage As New List(Of Object)
    Dim prixTotal
    Private noEmpl As Short
    Dim noHotel As Integer

    Sub New(_noEmpl As Short, maBD As P2014_Equipe2_GestionHôtelièreEntities)
        InitializeComponent()
        noEmpl = _noEmpl
        bd = maBD
        Dim res = From el In bd.tblLogin Where el.noEmpl = noEmpl Select el

        If res.First.statut = "PATR" Then
            menu.Visibility = Windows.Visibility.Hidden
            menu.IsEnabled = False
        Else
            menuGerant.Visibility = Windows.Visibility.Hidden
            menuGerant.IsEnabled = False
        End If
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
                If el.prixUnitaire = lstViewCommande.SelectedItem.prixLigne / el.quantite And el.codeItem = lstViewCommande.SelectedItem.codeItem Then
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
            commande.noEmpl = noEmpl
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

    Private Sub MenuItem_Click_5(sender As Object, e As RoutedEventArgs)
        Dim com = New iCommande(noEmpl, bd)
        com.Owner = Me
        com.Show()
    End Sub

    Private Sub MenuItem_Click_6(sender As Object, e As RoutedEventArgs)
        Dim inv = New iInventaireComplet(bd, noEmpl, noHotel)
        inv.Owner = Me
        inv.Show()
    End Sub

    Private Sub MenuItem_Click_7(sender As Object, e As RoutedEventArgs)
        Dim salle = New iGestionSalle(bd)
        salle.Owner = Me
        salle.Show()
    End Sub

    Private Sub MenuItem_Click_8(sender As Object, e As RoutedEventArgs)
        Dim hotel = New iGestionHotel(bd)
        hotel.Owner = Me
        hotel.Show()
    End Sub

    Private Sub MenuItem_Click_9(sender As Object, e As RoutedEventArgs)
        Dim fiche = New iFicheEmploye(bd, noHotel, noEmpl)
        fiche.Owner = Me
        fiche.Show()
    End Sub

    Private Sub MenuItem_Click_10(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeCentrale(bd, noEmpl, noHotel)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click_11(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeEmployeComplet(bd, noEmpl, noHotel)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click_12(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeSalle(noHotel, bd, noEmpl)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click_13(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeHotel(bd, noEmpl, noHotel)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim fiche = New iFicheEmploye(bd, noHotel, noEmpl)
        fiche.Owner = Me
        fiche.Show()
    End Sub

    Private Sub MenuItem_Click_1(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeEmploye(noEmpl, noHotel, bd)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click_2(sender As Object, e As RoutedEventArgs)
        Dim horaire = New iAjouterHoraire(noEmpl, noHotel, bd)
        horaire.Owner = Me
        horaire.Show()
    End Sub

    Private Sub MenuItem_Click_3(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeCOmmande(noEmpl, noHotel, bd)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click_4(sender As Object, e As RoutedEventArgs)
        Dim lst = New iCommunique(noEmpl, noHotel, bd)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click_14(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeReservComplet(bd, noEmpl, noHotel)
        lst.Owner = Me
        lst.Show()
    End Sub
End Class
