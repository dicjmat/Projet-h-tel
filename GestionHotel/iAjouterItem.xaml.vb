﻿Class iAjouterItem
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Private item As String
    Dim noEmp As Integer
    Dim noHotel As Integer

    Sub New(maBD As P2014_Equipe2_GestionHôtelièreEntities, _noEmp As Integer, _noHotel As Integer)
        InitializeComponent()
        bd = maBD
        noEmp = _noEmp
        noHotel = _noHotel
        Dim res = From el In bd.tblLogin Where el.noEmpl = noEmp Select el

        btnModifierItem.Visibility = Windows.Visibility.Hidden
        btnAjouterItem.Visibility = Windows.Visibility.Visible
        btnAjouterItem.IsEnabled = True
        btnAjoutFour.IsEnabled = False
    End Sub

    Sub New(_item As String, _bd As P2014_Equipe2_GestionHôtelièreEntities)
        InitializeComponent()
        item = _item
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
                  Where it.codeItem = item
                  Select it

        Dim fourn = From fo In bd.tblFournisseur
                    Join ca In bd.tblCatalogue
                    On ca.noFournisseur Equals fo.noFournisseur
                    Where ca.codeItem = item
                    Select fo

        txtRCodeItem.Text = res.First.codeItem
        txtRCodeItem.IsEnabled = False
        txtNomItem.Text = res.First.nomItem
        txtDescItem.Text = res.First.descItem
        cbFournisseur.ItemsSource = fourn.ToList
    End Sub

    Private Sub Viewbox_Loaded(sender As Object, e As RoutedEventArgs)
        Me.Owner.Hide()
    End Sub
    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub

    Private Sub btnAjoutFour_Click(sender As Object, e As RoutedEventArgs) Handles btnAjoutFour.Click
        Dim fournisseur = New LierFournisseur(bd, item)
        fournisseur.Owner = Me
        fournisseur.Show()
    End Sub

    Private Sub windowAjoutItem_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles windowAjoutItem.Closing
        Me.Owner.Show()
    End Sub

    Private Sub btnAjouterItem_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterItem.Click
        Dim Item = New tblItem()
        If txtRCodeItem.Text <> "" Or txtNomItem.Text <> "" Then
            Dim pour = New tblInventaire
            pour.codeItem = txtRCodeItem.Text
            pour.noHotel = "1"
            pour.quantiteMin = 0
            pour.Quantite = 0
            Item.codeItem = txtRCodeItem.Text
            Item.nomItem = txtNomItem.Text
            Item.descItem = txtDescItem.Text
            Item.tblInventaire.Add(pour)
            bd.tblItem.Add(Item)
            Try
                bd.SaveChanges()
            Catch ex As Exception
                MessageBox.Show("Le code d'item existe déjà")
                Exit Sub
            End Try

            MessageBox.Show("L'item a été créé avec succès")
            btnAjoutFour.IsEnabled = True
            btnAjouterItem.IsEnabled = False
        Else
            MessageBox.Show("Un des champs obligatoire n'a pas été remplis")
        End If


    End Sub

    Private Sub btnModifierItem_Click(sender As Object, e As RoutedEventArgs) Handles btnModifierItem.Click
        Dim res = From it In bd.tblItem
                   Where it.codeItem = item
                   Select it

        If txtRCodeItem.Text <> "" Or txtNomItem.Text <> "" Then
            res.Single.codeItem = txtRCodeItem.Text
            res.Single.nomItem = txtNomItem.Text
            res.Single.descItem = txtDescItem.Text

            bd.SaveChanges()
            MessageBox.Show("L'item a été modifié avec succès.")
            Me.Close()
        Else
            MessageBox.Show("Un des champs obligatoire n'a pas été remplis")
        End If
    End Sub

    'Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
    '    Dim com = New iCommande(noEmp, bd)
    '    com.Owner = Me
    '    com.Show()
    'End Sub

    'Private Sub MenuItem_Click_1(sender As Object, e As RoutedEventArgs)
    '    Dim inv = New iInventaire(noEmp, noHotel, bd)
    '    inv.Owner = Me
    '    inv.Show()
    'End Sub

    'Private Sub MenuItem_Click_2(sender As Object, e As RoutedEventArgs)
    '    Dim fourni = New iAjoutFournisseur(bd)
    '    fourni.Owner = Me
    '    fourni.Show()
    'End Sub

    'Private Sub MenuItem_Click_3(sender As Object, e As RoutedEventArgs)
    '    Dim inv = New iInventaire(noEmp, noHotel, bd)
    '    inv.Owner = Me
    '    inv.Show()
    'End Sub

    'Private Sub MenuItem_Click_4(sender As Object, e As RoutedEventArgs)
    '    Dim fourni = New iAjoutFournisseur(bd)
    '    fourni.Owner = Me
    '    fourni.Show()
    'End Sub

    'Private Sub MenuItem_Click_5(sender As Object, e As RoutedEventArgs)
    '    Dim com = New iCommande(noEmp, bd)
    '    com.Owner = Me
    '    com.Show()
    'End Sub

    'Private Sub MenuItem_Click_6(sender As Object, e As RoutedEventArgs)
    '    Dim inv = New iInventaireComplet(bd, noEmp, noHotel)
    '    inv.Owner = Me
    '    inv.Show()
    'End Sub

    'Private Sub MenuItem_Click_7(sender As Object, e As RoutedEventArgs)
    '    Dim salle = New iGestionSalle(bd)
    '    salle.Owner = Me
    '    salle.Show()
    'End Sub

    'Private Sub MenuItem_Click_8(sender As Object, e As RoutedEventArgs)
    '    Dim hotel = New iGestionHotel(bd)
    '    hotel.Owner = Me
    '    hotel.Show()
    'End Sub

    'Private Sub MenuItem_Click_9(sender As Object, e As RoutedEventArgs)
    '    Dim fiche = New iFicheEmploye(bd, noHotel, noEmp)
    '    fiche.Owner = Me
    '    fiche.Show()
    'End Sub

    'Private Sub MenuItem_Click_10(sender As Object, e As RoutedEventArgs)
    '    Dim lst = New iListeCentrale(bd, noEmp, noHotel)
    '    lst.Owner = Me
    '    lst.Show()
    'End Sub

    'Private Sub MenuItem_Click_11(sender As Object, e As RoutedEventArgs)
    '    Dim lst = New iListeEmployeComplet(bd, noEmp, noHotel)
    '    lst.Owner = Me
    '    lst.Show()
    'End Sub

    'Private Sub MenuItem_Click_12(sender As Object, e As RoutedEventArgs)
    '    Dim lst = New iListeSalle(noHotel, bd, noEmp)
    '    lst.Owner = Me
    '    lst.Show()
    'End Sub

    'Private Sub MenuItem_Click_13(sender As Object, e As RoutedEventArgs)
    '    Dim lst = New iListeHotel(bd, noEmp, noHotel)
    '    lst.Owner = Me
    '    lst.Show()
    'End Sub

    Private Sub iAjouterItem_Activated(sender As Object, e As EventArgs) Handles Me.Activated

        Dim res = From it In bd.tblItem
                  Join ca In bd.tblCatalogue
                  On ca.codeItem Equals it.codeItem
                  Join fo In bd.tblFournisseur
                  On ca.noFournisseur Equals fo.noFournisseur
                  Where it.codeItem = item
                  Select it.codeItem, it.descItem, it.nomItem, fo.nomFournisseur
        cbFournisseur.ItemsSource = res.ToList
    End Sub
End Class
