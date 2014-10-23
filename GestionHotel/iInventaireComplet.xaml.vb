Public Class iInventaireComplet
    Dim bd As New P2014_Equipe2_GestionHôtelièreEntities

    Sub New(_bd As P2014_Equipe2_GestionHôtelièreEntities)
        ' TODO: Complete member initialization 
        InitializeComponent()
        bd = _bd
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub

    Private Sub cbHotel_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cbHotel.SelectionChanged
        requete()
    End Sub

    Private Sub requete()
        Dim hotel As Integer = cbHotel.SelectedItem.noHotel
        If cbHotel.SelectedIndex <> -1 Then
            If cbHotel.SelectedItem.nomHotel <> "Tout" Then
                Dim res = From item In bd.tblItem Join el In bd.tblInventaire On el.codeItem Equals item.codeItem
                      Where el.noHotel = hotel And (item.codeItem.StartsWith(txtRecherche.Text) Or item.nomItem.StartsWith(txtRecherche.Text))
                      Select el.codeItem, item.nomItem, el.Quantite, item.descItem, el.quantiteMin
                dgInventaireC.ItemsSource = creerAffichage(res.ToList)
            Else
                Dim res = From el In bd.inventaireCommun
                          Where el.codeItem.StartsWith(txtRecherche.Text) Or el.nomItem.StartsWith(txtRecherche.Text)
                          Select el

                dgInventaireC.ItemsSource = creerAffichage(res.ToList)
            End If
        End If
    End Sub

    Private Function creerAffichage(res)
        Dim lstAffichage As New List(Of Object)
        Dim Affichage
        For Each el In res
            Dim Stock As Boolean = False
            If cbHotel.SelectedItem.nomHotel <> "Tout" AndAlso el.Quantite < el.quantiteMin Then
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
        Dim listeCbHotel As List(Of tblHotel)
        Dim affichage As New tblHotel
        Dim hotel = From ho In bd.tblHotel
                    Select ho
        affichage.nomHotel = "Tout"
        listeCbHotel = hotel.ToList
        listeCbHotel.Add(affichage)
        listeCbHotel.Reverse()
        cbHotel.DataContext = listeCbHotel.ToList

        cbHotel.SelectedItem = affichage
        requete()
    End Sub

    Private Sub txtRecherche_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtRecherche.TextChanged
        requete()
    End Sub

    Private Sub btnAjouter_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouter.Click
        Dim iItem = New iAjouterItem(bd)
        iItem.Owner = Me
        iItem.Show()
    End Sub

    Private Sub btnModifier_Click(sender As Object, e As RoutedEventArgs) Handles btnModifier.Click
        If dgInventaireC.SelectedIndex <> -1 Then
            Dim item = dgInventaireC.SelectedItem.codeItem
            Dim iItem As New iAjouterItem(item, bd)
            iItem.Owner = Me
            Me.Hide()
            iItem.Show()
        Else
            MessageBox.Show("Veuillez sélectionner un item")
        End If


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
        Else
            MessageBox.Show("Vous devez choisir l'item à supprimer")
        End If
    End Sub

    Private Sub window_invComp_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles window_invComp.Closing
        Me.Owner.Show()
    End Sub
End Class
