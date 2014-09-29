﻿Public Class iAccueilGestionnaire

    Private noEmpl As Short
    Private noHotel As Short

    Sub New(p1 As Short, p2 As Short)
        ' TODO: Complete member initialization 
        InitializeComponent()
        noEmpl = p1
        noHotel = p2
    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Me.Owner.Show()
    End Sub

    Private Sub btnInventaire_Click(sender As Object, e As RoutedEventArgs) Handles btnInventaire.Click
        Dim inventaire = New iInventaire(noHotel)
        inventaire.Owner = Me
        Me.Hide()
        inventaire.Show()
    End Sub

    Private Sub btnDeco_Click(sender As Object, e As RoutedEventArgs) Handles btnDeco.Click
        Me.Close()
    End Sub

    Private Sub btnCommande_Click(sender As Object, e As RoutedEventArgs) Handles btnCommande.Click
        Dim commande = New iCommande()
        commande.Owner = Me
        Me.Hide()
        commande.Show()
    End Sub

    Private Sub btnListeEmploye_Click(sender As Object, e As RoutedEventArgs) Handles btnListeEmploye.Click
        Dim iEmploye = New iListeEmploye(noHotel)
        iEmploye.Owner = Me
        Me.Hide()
        iEmploye.Show()
    End Sub
End Class
