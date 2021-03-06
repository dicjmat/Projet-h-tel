﻿Public Class iInventaireComplet
    Dim bd As New P2014_Equipe2_GestionHôtelièreEntities
    Dim noEmp As Integer
    Dim noHotel As Integer
    Dim item As String

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

    Private Sub cbHotel_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cbHotel.SelectionChanged
        requete()
    End Sub

    Private Sub requete()
        Dim hotel As Integer = cbHotel.SelectedItem.noHotel
        If cbHotel.SelectedIndex <> -1 Then
            If cbHotel.SelectedItem.nomHotel <> "Tout" Then
                Dim res = From item In bd.tblItem
                          Join el In bd.tblInventaire On el.codeItem Equals item.codeItem
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
        Dim Affichage As Object
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
        Me.Owner.Hide()
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
        Dim iItem = New iAjouterItem(bd, noEmp, noHotel)
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

    Private Sub window_invComp_Activated(sender As Object, e As EventArgs) Handles window_invComp.Activated
        requete()
    End Sub

    Private Sub MenuItem_Click_3(sender As Object, e As RoutedEventArgs)
        Dim com = New iCommande(noEmp, bd)
        com.Owner = Me.Owner
        com.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_4(sender As Object, e As RoutedEventArgs)
        Dim fiche = New iFicheEmploye(bd, noHotel, noEmp)
        fiche.Owner = Me.Owner
        fiche.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_5(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeEmployeComplet(bd, noEmp, noHotel)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_6(sender As Object, e As RoutedEventArgs)
        Dim ajout = New iAjouterItem(bd, noEmp, noHotel)
        ajout.Owner = Me.Owner
        ajout.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_7(sender As Object, e As RoutedEventArgs)
        Dim ajout = New iAjoutFournisseur(bd)
        ajout.Owner = Me.Owner
        ajout.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_8(sender As Object, e As RoutedEventArgs)
        Dim inv = New iInventaireComplet(bd, noEmp, noHotel)
        inv.Owner = Me.Owner
        inv.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_9(sender As Object, e As RoutedEventArgs)
        Dim gest = New iGestionSalle(bd, noHotel)
        gest.Owner = Me.Owner
        gest.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_10(sender As Object, e As RoutedEventArgs)
        Dim gest = New iGestionHotel(bd)
        gest.Owner = Me.Owner
        gest.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_11(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeCentrale(bd, noEmp, noHotel)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_12(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeHotel(bd, noEmp, noHotel)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_13(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeSalle(noHotel, bd, noEmp)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeReservComplet(bd, noEmp, noHotel)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub
End Class
