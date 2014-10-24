Class iAjouterItem
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Private _item As String

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
        Else
            MessageBox.Show("Un des champs obligatoire n'a pas été remplis")
        End If
    End Sub
End Class
