﻿Public Class iListeCOmmande
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Dim lstAffichage As New List(Of Object)
    Private _noHotel As Short
    Private _noEmpl As Short

    Sub New(noEmpl As Short, noHotel As Short)
        ' TODO: Complete member initialization 
        InitializeComponent()
        _noEmpl = noEmpl
        _noHotel = noHotel
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Focusable = False
        Me.Close()
    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Me.Owner.Show()
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        bd = New P2014_Equipe2_GestionHôtelièreEntities
        requete()
    End Sub

    Private Sub txtRComm_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtRComm.TextChanged
        Dim res = From Co In bd.tblCommande Join Em In bd.tblEmploye On Co.noEmpl Equals Em.noEmpl
                  Where _noHotel = Em.noHotel And ((Em.nomEmpl + " " + Em.prenEmpl).StartsWith(txtRComm.Text) Or (Em.prenEmpl + " " + Em.nomEmpl).StartsWith(txtRComm.Text) Or Co.dateCommande.ToString.StartsWith(txtRComm.Text) Or Co.etatCommande.StartsWith(txtRComm.Text))
                  Select Co.noCommande, Co.dateCommande, Co.etatCommande, Co.prixCommande, Em.nomEmpl, Em.prenEmpl

        dgCommande.ItemsSource = res.ToList
    End Sub

    Private Sub dgCommande_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dgCommande.SelectionChanged
        If dgCommande.SelectedIndex <> -1 Then
            Dim commande As Integer = dgCommande.SelectedItem.noCommande
            Dim ligne = From LiCo In bd.tblLigneCommande
                        Where LiCo.noCommande = commande
                        Select LiCo
            For Each el In ligne.ToList()
                Dim affichage = New With {.nomFournisseur = el.tblFournisseur.nomFournisseur _
                                            , .quantite = el.quantite _
                                            , .prixLigne = el.prixLigne _
                                            , .nomItem = el.tblItem.nomItem _
                                            , .codeItem = el.codeItem}
                lstAffichage.Add(affichage)
            Next
            dgLigneCommande.ItemsSource = lstAffichage.ToList
            lstAffichage.Clear()
        End If
    End Sub

    Private Sub btnAjouterComm_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterComm.Click
        Dim iComman = New iCommande(_noEmpl)
        iComman.Owner = Me
        iComman.Show()
    End Sub

    Private Sub btnSupprimerComm_Click(sender As Object, e As RoutedEventArgs) Handles btnSupprimerComm.Click
        If dgCommande.SelectedIndex <> -1 Then
            Dim supprime As Integer = dgCommande.SelectedItem.noCommande
            Dim res = From LiCo In bd.tblLigneCommande
                      Where LiCo.noCommande = supprime
                      Select LiCo
            For Each el As tblLigneCommande In res.ToList
                bd.tblLigneCommande.Remove(el)
            Next
            Dim commande = From Co In bd.tblCommande
                          Where Co.noCommande = supprime
                          Select Co
            bd.tblCommande.Remove(commande.Single())
        End If
        bd.SaveChanges()
        requete()

    End Sub

    Private Sub requete()
        Dim res = From Co In bd.tblCommande Join Em In bd.tblEmploye On Co.noEmpl Equals Em.noEmpl
                          Where _noHotel = Em.noHotel
                          Select Co.noCommande, Co.dateCommande, Co.etatCommande, Co.prixCommande, Em.nomEmpl, Em.prenEmpl

        dgCommande.ItemsSource = res.ToList()
    End Sub
End Class
