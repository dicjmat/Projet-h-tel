﻿Public Class iFicheClient
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

        db.tblClient.Add(Client)
        db.SaveChanges()
    End Sub

End Class
