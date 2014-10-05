Public Class iCommande
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Dim lstCommande As New List(Of tblLigneCommande)
    Dim lstAffichage As New List(Of Object)
    Private Sub Grid_Loaded(sender As Object, e As RoutedEventArgs)
        bd = New P2014_Equipe2_GestionHôtelièreEntities
        Dim res = From It In bd.tblItem Join FoIt In bd.tblCatalogue On It.codeItem Equals FoIt.codeItem Join Fo In bd.tblFournisseur On FoIt.noFournisseur Equals Fo.noFournisseur
                    Select It.codeItem, It.nomItem, FoIt.prixItem, Fo.nomFournisseur, Fo.noFournisseur

        dgCommande.ItemsSource = res.ToList()

    End Sub
    Private Sub btnAjouterItemComm_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterItemComm.Click
        'Dim prix = From item In bd.tblItem
        'Where txtCodeItem.Text = item.codeItem And 
        'Select prix
        If dgCommande.SelectedItem IsNot Nothing Then
            Dim ligne = New tblLigneCommande
            Dim prixTotal = 0
            ligne.noFournisseur = dgCommande.SelectedItem.noFournisseur
            ligne.codeItem = dgCommande.SelectedItem.CodeItem
            ligne.quantite = txtQteCom.Text
            ligne.prixLigne = dgCommande.SelectedItem.prixItem * Convert.ToInt32(txtQteCom.Text)
            lstCommande.Add(ligne)
            Dim affichage = New With {.nomFournisseur = dgCommande.SelectedItem.nomFournisseur _
                                     , .quantite = ligne.quantite _
                                     , .prixLigne = ligne.prixLigne _
                                     , .nomItem = dgCommande.SelectedItem.nomItem}
            lstAffichage.Add(affichage)
            lstViewCommande.ItemsSource = lstAffichage.ToList()
            prixTotal += ligne.prixLigne
            lblPrixComm.Content = prixTotal.ToString() + " $"
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
        Dim res = From It In bd.tblItem Join FoIt In bd.tblCatalogue On It.codeItem Equals FoIt.codeItem Join Fo In bd.tblFournisseur On FoIt.noFournisseur Equals Fo.noFournisseur
                  Where It.codeItem.StartsWith(txtRecherche.Text) Or It.nomItem.StartsWith(txtRecherche.Text) Or Fo.nomFournisseur.StartsWith(txtRecherche.Text)
                  Select It.codeItem, It.nomItem, FoIt.prixItem, Fo.nomFournisseur

        dgCommande.ItemsSource = res.ToList()
    End Sub

    Private Sub dgCommande_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dgCommande.SelectionChanged
        calculPrixTot(dgCommande.SelectedItem.prixItem())
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
                End If
            Next
            For Each el In lstCommande
                'If 
            Next
        Else
            MessageBox.Show("Veullez sélectionner l'item que vous voulez supprimer")
        End If
    End Sub
End Class
