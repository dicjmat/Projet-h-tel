Public Class iAjoutCliReserv
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities

    Private Sub window_AjoutCliReserv_Loaded(sender As Object, e As RoutedEventArgs) Handles window_AjoutCliReserv.Loaded
        bd = New P2014_Equipe2_GestionHôtelièreEntities
        Dim res = From el In bd.tblClient Select el
        cbTypeCarte.DataContext = res.ToList()
        cbCodeVille.DataContext = res.ToList()
    End Sub

    Private Sub btnAjouterCli_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterCli.Click
        Dim client As New tblClient
        client.nomClient = txtNomCli.Text
        client.prenClient = txtPrenCli.Text
        client.noTelClient = txtTelCli.Text
        client.noCellClient = txtCelCli.Text
        client.adrClient = txtAdrCli.Text
        client.noCarteCredit = txtNoCarteCredit.Text
        client.typeCarteCredit = cbTypeCarte.SelectedItem.typeCarteCredit
        client.dateExpiration = txtCodeExp.Text
        client.codeVille = cbCodeVille.SelectedItem.codeVille
        client.commentaire = txtCommCli.Text
        bd.tblClient.Add(client)
        bd.SaveChanges()
        MessageBox.Show("Le client a été ajouté avec succès.")
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub
End Class
