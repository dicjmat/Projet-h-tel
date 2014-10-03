Public Class iCommande
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Private Sub Grid_Loaded(sender As Object, e As RoutedEventArgs)
        bd = New P2014_Equipe2_GestionHôtelièreEntities
        Dim res = From It In bd.tblItem Join FoIt In bd.tblCatalogue On It.codeItem Equals FoIt.codeItem Join Fo In bd.tblFournisseur On FoIt.noFournisseur Equals Fo.noFournisseur
                    Select It.codeItem, It.nomItem, FoIt.prixItem, Fo.nomFournisseur

        dgCommande.ItemsSource = res.ToList()

    End Sub
    Private Sub btnAjouterItemComm_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterItemComm.Click
        'Dim prix = From item In bd.tblItem
        'Where txtCodeItem.Text = item.codeItem And 
        'Select prix


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

    Private Sub txtQteCom_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtQteCom.TextChanged
        If dgCommande.SelectedIndex <> -1 Then
            calculPrixTot(dgCommande.SelectedItem.prixItem())
        End If
    End Sub
End Class
