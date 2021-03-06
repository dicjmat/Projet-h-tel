﻿Public Class iRabais
    Dim bd As New P2014_Equipe2_GestionHôtelièreEntities
    Private noHotel As Short
    Dim noEmp As Integer
    Dim p1 As Boolean

    Sub New(hotel As Short, _bd As P2014_Equipe2_GestionHôtelièreEntities, _noEmp As Integer)
        InitializeComponent()
        noHotel = hotel
        bd = _bd
        noEmp = _noEmp
    End Sub

    Private Sub btndeco_Click(sender As Object, e As RoutedEventArgs) Handles btndeco.Click
        Me.Owner.Show()
        Me.Close()
    End Sub

    Private Sub AjoutRab_Click(sender As Object, e As RoutedEventArgs) Handles AjoutRab.Click
        Dim rabais As New tblRabais

        If cbTypeChambre.SelectedIndex <> -1 Then
            rabais.codeTypeSalle = cbTypeChambre.SelectedItem.codeTypeSalle
            rabais.tauxRabais = Convert.ToDecimal(numTaux.Value) / 100
            rabais.noHotel = noHotel
            If chkActif.IsChecked Then
                rabais.etatRabais = "AC"
            Else
                rabais.etatRabais = "IN"
            End If
            bd.tblRabais.Add(rabais)
            Try
                bd.SaveChanges()
                requete()
                MessageBox.Show("Votre rabais a été ajouté")
            Catch ex As Exception
                MessageBox.Show("Il y a déjà un rabais assigné à cette chambre")
            End Try


        Else
            MessageBox.Show("Veuillez remplir les champs")
        End If
    End Sub

    Private Sub windowRabais_Loaded(sender As Object, e As RoutedEventArgs) Handles windowRabais.Loaded
        Me.Owner.Hide()
        requete()
        Dim res = From tych In bd.tblTypeSalle
                  Join tychho In bd.tblTypeSalleHotel On tych.codeTypeSalle Equals tychho.codeTypeSalle
                  Where tychho.noHotel = noHotel And tych.codeTypeSalle <> "REU"
                  Select tych

        cbTypeChambre.ItemsSource = res.ToList
    End Sub

    Private Sub requete()
        Dim res = From ra In bd.tblRabais
                  Join tych In bd.tblTypeSalle On ra.codeTypeSalle Equals tych.codeTypeSalle
                  Join tychho In bd.tblTypeSalleHotel On tych.codeTypeSalle Equals tychho.codeTypeSalle
                  Where tychho.noHotel = noHotel
                  Select ra.etatRabais, ra.noRabais, ra.tauxRabais, tych.nomTypeSalle

        dgRabais.ItemsSource = res.ToList
    End Sub

    Private Sub SuppRab_Click(sender As Object, e As RoutedEventArgs) Handles SuppRab.Click
        If dgRabais.SelectedIndex <> -1 Then
            Dim nRabais As Integer = dgRabais.SelectedItem.noRabais
            Dim res = From ra In bd.tblRabais
                      Where ra.noRabais = nRabais
                      Select ra
            bd.tblRabais.Remove(res.Single)
            Dim maxi = From rab In bd.tblRabais
                       Select rab.noRabais
            bd.SaveChanges()
            bd.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Reservation.tblRabais',RESEED," + maxi.ToList.Last.ToString + ")")
            bd.SaveChanges()
            requete()
            MessageBox.Show("Le rabais a bien été supprimé")
        Else
            MessageBox.Show("Veuillez choisir le rabais que vous voulez supprimer")
        End If

    End Sub

    Private Sub dgRabais_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dgRabais.SelectionChanged
        If dgRabais.SelectedIndex <> -1 Then
            Dim rabais As Integer = dgRabais.SelectedItem.noRabais
            Dim res = From ra In bd.tblRabais
                      Where rabais = ra.noRabais
                      Select ra

            For Each el In cbTypeChambre.Items
                If el.codeTypeSalle = res.Single.codeTypeSalle Then
                    cbTypeChambre.SelectedItem = el
                    Exit For
                End If
            Next
            If res.Single.etatRabais = "AC" Then
                chkActif.IsChecked = True
            Else
                chkActif.IsChecked = False
            End If
            numTaux.Value = res.Single.tauxRabais * 100
        End If

    End Sub

    Private Sub ModifcRab_Click(sender As Object, e As RoutedEventArgs) Handles ModifcRab.Click
        If dgRabais.SelectedIndex <> -1 Then
            Dim rabais As Integer = dgRabais.SelectedItem.noRabais
            Dim res = From ra In bd.tblRabais
                      Where rabais = ra.noRabais
                      Select ra

            res.Single.codeTypeSalle = cbTypeChambre.SelectedItem.codeTypeSalle
            If chkActif.IsChecked Then
                res.Single.etatRabais = "AC"
            Else
                res.Single.etatRabais = "IN"
            End If

            res.Single.tauxRabais = Convert.ToDecimal(numTaux.Value) / 100
            bd.SaveChanges()
            requete()
            MessageBox.Show("Le rabais a bien été modifié")
        Else
            MessageBox.Show("Veuillez sélectionner le rabais que vous voulez modifier")
        End If
    End Sub

    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim ajout = New iAjoutForf(p1, noHotel, bd)
        ajout.Owner = Me.Owner
        ajout.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_1(sender As Object, e As RoutedEventArgs)
        Dim lst = New ListeForfait(noHotel, bd, noEmp)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_2(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeSalle(noHotel, bd, noEmp)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_14(sender As Object, e As RoutedEventArgs)
        Dim rab = New iRabais(noHotel, bd, noEmp)
        rab.Owner = Me.Owner
        rab.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_15(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListePeriode(bd, noHotel, noEmp)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_3(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeReservComplet(bd, noHotel, noEmp)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub
End Class
