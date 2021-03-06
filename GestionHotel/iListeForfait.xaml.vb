﻿Public Class ListeForfait
    Dim bd As New P2014_Equipe2_GestionHôtelièreEntities
    Private _hotel As Short
    Dim noEmp As Integer
    Dim p1 As Boolean

    Sub New(hotel As Short, _bd As P2014_Equipe2_GestionHôtelièreEntities, _noEmp As Integer)
        InitializeComponent()
        _hotel = hotel
        bd = _bd
        noEmp = _noEmp
    End Sub

    Private Sub window_ListeForf_Loaded(sender As Object, e As RoutedEventArgs) Handles window_ListeForf.Loaded
        Me.Owner.Hide()
        requete()
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Owner.Show()
        Me.Close()
    End Sub

    Private Sub requete()
        Dim res = From fo In bd.tblForfait
                  Join tych In bd.tblTypeSalle
                  On tych.codeTypeSalle Equals fo.codeTypeSalle
                  Where fo.noHotel = _hotel And (fo.nomForfait.StartsWith(txtrechercher.Text) Or tych.nomTypeSalle.StartsWith(txtrechercher.Text))
                  Select fo.nomForfait, fo.noForfait, fo.etatForfait, tych.nomTypeSalle, fo.prixForfait, fo.descForfait

        dgForfait.ItemsSource = res.ToList
    End Sub

    Private Sub btnAjoutForf_Click(sender As Object, e As RoutedEventArgs) Handles btnAjoutForf.Click
        Dim forfait = New iAjoutForf(True, _hotel, bd)
        forfait.Owner = Me
        forfait.Show()
    End Sub

    Private Sub btnModifForf_Click(sender As Object, e As RoutedEventArgs) Handles btnModifForf.Click
        If dgForfait.SelectedIndex <> -1 Then
            Dim forfait = New iAjoutForf(False, _hotel, dgForfait.SelectedItem.noForfait, bd)
            forfait.Owner = Me
            forfait.Show()
        Else
            MessageBox.Show("Veuillez choisir un forfait")
        End If


    End Sub

    Private Sub window_ListeForf_Activated(sender As Object, e As EventArgs) Handles window_ListeForf.Activated
        requete()
    End Sub

    Private Sub txtrechercher_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtrechercher.TextChanged
        requete()
    End Sub

    Private Sub btnSuppForf_Click(sender As Object, e As RoutedEventArgs) Handles btnSuppForf.Click
        If dgForfait.SelectedIndex <> -1 Then
            Dim forfait As Integer = dgForfait.SelectedItem.noForfait
            Dim res = From fo In bd.tblForfait
                      Where fo.noForfait = forfait
                      Select fo
            bd.tblForfait.Remove(res.Single)
            Dim maxi = From fo In bd.tblForfait
                       Select fo.noForfait
            bd.SaveChanges()
            bd.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Reservation.tblForfait',RESEED," + maxi.ToList.Last.ToString + ")")
            bd.SaveChanges()
            requete()
            MessageBox.Show("Le forfait a bien été supprimé")
        Else
            MessageBox.Show("Veuillez choisir le forfait que vous voulez supprimer")
        End If
    End Sub

    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim ajout = New iAjoutForf(p1, _hotel, bd)
        ajout.Owner = Me.Owner
        ajout.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_1(sender As Object, e As RoutedEventArgs)
        Dim lst = New ListeForfait(_hotel, bd, noEmp)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_2(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeSalle(_hotel, bd, noEmp)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_14(sender As Object, e As RoutedEventArgs)
        Dim rab = New iRabais(_hotel, bd, noEmp)
        rab.Owner = Me.Owner
        rab.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_15(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListePeriode(bd, _hotel, noEmp)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub
End Class
