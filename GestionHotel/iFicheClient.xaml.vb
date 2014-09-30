Public Class iFicheClient
    Dim db As P2014_Equipe2_GestionHôtelièreEntities
    Private Sub windowFicheCli_Loaded(sender As Object, e As RoutedEventArgs) Handles windowFicheCli.Loaded
        db = New P2014_Equipe2_GestionHôtelièreEntities
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        'Sauvegarder
        Dim Client = New tblClient
        Client.nomClient = txtNomCli.Text
        Client.prenClient = txtPrenCli.Text
        Client.noTelClient = txtNoTellCli.Text
        Client.noCellClient = txtNoCellCli.Text
        Client.adrClient = txtAdrCli.Text
        Client.noCarteCredit = txtCarteCreditCli.Text
        Client.typeCarteCredit = cbTypeCarte.SelectedItem
        Client.dateExpiration = txtCodeExp.Text
        Client.codeVille = cbCodeVille.SelectedItem
        Client.commentaire = txtCommCli.Text
        db.tblClient.Add(Client)
        db.SaveChanges()
    End Sub

    Private Sub btnLierClient_Click(sender As Object, e As RoutedEventArgs) Handles btnLierClient.Click

    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub

End Class
