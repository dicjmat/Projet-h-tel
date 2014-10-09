Class iAjouterItem
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Private Sub Viewbox_Loaded(sender As Object, e As RoutedEventArgs)
        bd = New P2014_Equipe2_GestionHôtelièreEntities
        Me.Owner.Hide()
    End Sub
    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub

    Private Sub btnAjoutFour_Click(sender As Object, e As RoutedEventArgs) Handles btnAjoutFour.Click
        Dim fournisseur = New iAjoutFournisseur
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
