﻿Public Class iAccueilGestionnaire

    Private noEmpl As Short
    Private noHotel As Short
    Dim maBd As P2014_Equipe2_GestionHôtelièreEntities

    Sub New(p1 As Short, p2 As Short)
        ' TODO: Complete member initialization 
        InitializeComponent()
        noEmpl = p1
        noHotel = p2
    End Sub

    Private Sub btnDeco_Click(sender As Object, e As RoutedEventArgs) Handles btnDeco.Click
        Me.Owner.Show()
        Me.Close()
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        maBd = New P2014_Equipe2_GestionHôtelièreEntities
        Dim res = From el In maBd.tblEmploye Where el.noEmpl = noEmpl Select el

        lblNom.Content = "Bonjour, " + res.ToList.Single.prenEmpl + " " + res.ToList.Single.nomEmpl
    End Sub

    Private Sub AppuieItem()
        Dim inventaire = New iInventaire(noEmpl, noHotel)
        inventaire.Owner = Me
        inventaire.Show()
    End Sub

    Private Sub AppuieCommande()
        Dim lstcommande = New iListeCOmmande(noEmpl, noHotel)
        lstcommande.Owner = Me
        Me.Hide()
        lstcommande.Show()
    End Sub

    Private Sub AppuieEmploye()
        Dim iEmploye = New iListeEmploye(noEmpl, noHotel)
        iEmploye.Owner = Me
        iEmploye.Show()
        Me.Hide()
    End Sub
End Class
