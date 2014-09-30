﻿Public Class iInventaire

    Private noHotel As Short
    Dim maBD As P2014_Equipe2_GestionHôtelièreEntities
    Sub New(p2 As Short)
        ' TODO: Complete member initialization 
        InitializeComponent()
        noHotel = p2
    End Sub
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        maBD = New P2014_Equipe2_GestionHôtelièreEntities
        Dim res = From item In maBD.tblItem Join el In maBD.tblInventaire On el.codeItem Equals item.codeItem Where el.noHotel = noHotel Select el.codeItem, item.nomItem, el.Quantite, item.descItem
        lstInventaire.ItemsSource = res.ToList
    End Sub

    Private Sub txtCodeItem_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtCodeItem.TextChanged
        Dim res = From item In maBD.tblItem Join el In maBD.tblInventaire On el.codeItem Equals item.codeItem Where el.noHotel = noHotel And (item.codeItem.StartsWith(txtCodeItem.Text) Or item.nomItem.StartsWith(txtCodeItem.Text)) Select el.codeItem, item.nomItem, el.Quantite, item.descItem
        lstInventaire.ItemsSource = res.ToList
    End Sub


    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Focusable = False
        Me.Close()
    End Sub

    Private Sub windowInventaire_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles windowInventaire.Closing
        If Me.Focusable Then
            Me.Owner.Close()
        Else
            Me.Owner.Show()
        End If

    End Sub
End Class
