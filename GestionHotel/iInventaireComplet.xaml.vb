Public Class iInventaireComplet
    Dim bd As New P2014_Equipe2_GestionHôtelièreEntities
    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub

    Private Sub cbHotel_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cbHotel.SelectionChanged
        requete()
    End Sub

    Private Sub requete()
        Dim hotel As Integer = cbHotel.SelectedItem.noHotel
        If cbHotel.SelectedIndex <> -1 Then
            Dim res = From item In bd.tblItem Join el In bd.tblInventaire On el.codeItem Equals item.codeItem
                  Where el.noHotel = hotel And (item.codeItem.StartsWith(txtRecherche.Text) Or item.nomItem.StartsWith(txtRecherche.Text))
                  Select el.codeItem, item.nomItem, el.Quantite, item.descItem, el.quantiteMin
            dgInventaireC.ItemsSource = creerAffichage(res.ToList)
        End If
    End Sub

    Private Function creerAffichage(res)
        Dim lstAffichage As New List(Of Object)
        Dim Affichage
        For Each el In res
            Dim Stock As Boolean = False
            If el.Quantite < el.quantiteMin Then
                Stock = True
            End If
            Affichage = New With {.codeItem = el.codeItem _
                                , .nomItem = el.nomItem _
                                , .Quantite = el.Quantite _
                                , .stock = Stock _
                                , .descItem = el.descItem}
            lstAffichage.Add(Affichage)
        Next
        Return lstAffichage
    End Function

    Private Sub window_invComp_Loaded(sender As Object, e As RoutedEventArgs) Handles window_invComp.Loaded
        bd = New P2014_Equipe2_GestionHôtelièreEntities
        Dim hotel = From ho In bd.tblHotel
                    Select ho

        cbHotel.DataContext = hotel.ToList
        requete()
    End Sub

    Private Sub txtRecherche_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtRecherche.TextChanged
        requete()
    End Sub

    Private Sub btnAjouter_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouter.Click
        Dim iItem = New iAjouterItem
        iItem.Owner = Me
        iItem.Show()
    End Sub

    Private Sub btnModifier_Click(sender As Object, e As RoutedEventArgs) Handles btnModifier.Click

    End Sub

    Private Sub btnSupprimer_Click(sender As Object, e As RoutedEventArgs) Handles btnSupprimer.Click
        If dgInventaireC.SelectedIndex <> -1 Then
            Dim confirmation = MessageBox.Show("Voulez-vous vraiment supprimer un objet et toutes ses occurences dans le systèmes?", "Attention", MessageBoxButton.YesNo)
            If confirmation Then
                Dim item As String = dgInventaireC.SelectedItem.codeItem
                Dim res = From it In bd.tblItem
                           Where it.codeItem = item
                           Select it
                bd.tblItem.Remove(res.Single)
                bd.SaveChanges()
            End If
        End If
    End Sub
End Class
