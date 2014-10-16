Public Class iAjoutClient
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Private Sub btnAjoutCli_Click(sender As Object, e As RoutedEventArgs) Handles btnAjoutCli.Click
        Dim client = New tblClient
        client.nomClient = txtnomCli.Text
        client.prenClient = txtPrenCli.Text
        client.noTelClient = txtnotel.Text
        client.noCellClient = txtnocell.Text
        client.adrClient = txtAdrCli.Text
        client.noCarteCredit = txtNoCarte.Text
        client.typeCarteCredit = cbTypeCarte.SelectedItem
        client.dateExpiration = txtCodeExp.Text
        client.codeVille = cbCodeVille.SelectedItem
        client.commentaire = txtCommCli.Text
        bd.tblClient.Add(client)
        bd.SaveChanges()
        MessageBox.Show("Le client a été créé avec succès.")
    End Sub

    Private Sub window_AjoutCli_Loaded(sender As Object, e As RoutedEventArgs) Handles window_AjoutCli.Loaded
        bd = New P2014_Equipe2_GestionHôtelièreEntities
    End Sub
End Class
