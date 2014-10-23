Class iAjouterItem
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Private _item As Object

    Sub New(maBD As P2014_Equipe2_GestionHôtelièreEntities)
        InitializeComponent()
        bd = maBD
    End Sub

    Sub New(item As Object, _bd As P2014_Equipe2_GestionHôtelièreEntities)
        InitializeComponent()
        _item = item
        bd = _bd
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
        Item.codeItem = txtRCodeItem.Text
        Item.nomItem = txtNomItem.Text
        Item.descItem = txtDescItem.Text

        bd.tblItem.Add(Item)
        bd.SaveChanges()
        MessageBox.Show("L'item a été créé avec succès.")
    End Sub

    Private Sub btnModifierItem_Click(sender As Object, e As RoutedEventArgs) Handles btnModifierItem.Click

    End Sub
End Class
