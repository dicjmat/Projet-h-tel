﻿Public Class iFactureNote
    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Private noEmpl As Integer
    Private noHotel As Integer
    Private noFacture As Integer

    Sub New(_bd As P2014_Equipe2_GestionHôtelièreEntities, _noEmpl As Integer, _noHotel As Integer, _noFacture As Integer)
        InitializeComponent()
        bd = _bd
        noEmpl = _noEmpl
        noHotel = _noHotel
        noFacture = _noFacture
    End Sub

    Private Sub window_FactureNote_Loaded(sender As Object, e As RoutedEventArgs) Handles window_FactureNote.Loaded
        Dim res = From el In bd.tblNote Where el.noFacture = noFacture Select el

        dgListeNote.ItemsSource = res.ToList()
        txtFact.Text = noFacture.ToString()
    End Sub

    Private Sub dgListeNote_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dgListeNote.SelectionChanged
        Dim note As Integer = dgListeNote.SelectedItem.noNote
        Dim res = From el In bd.tblElementNote Where el.noNote = note Select el

        dgListeElem.ItemsSource = res.ToList()
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Owner.Hide()
        Me.Owner.Show()
        Me.Close()
    End Sub

    Private Sub btnPayerFact_Click(sender As Object, e As RoutedEventArgs) Handles btnPayerFact.Click
        Dim fact = (From el In bd.tblFacture Where el.noFacture = noFacture Select el).Single
        fact.etatFacture = "Payé"
        bd.SaveChanges()
    End Sub
End Class