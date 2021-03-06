﻿Public Class iListeEmploye

    Private _noHotel As Short
    Dim maBd As P2014_Equipe2_GestionHôtelièreEntities
    Private _noEmpl As Short
    Dim p2 As Integer

    Sub New(noEmpl As Short, noHotel As Short, _maBd As P2014_Equipe2_GestionHôtelièreEntities)
        ' TODO: Complete member initialization
        InitializeComponent()
        _noEmpl = noEmpl
        _noHotel = noHotel
        maBd = _maBd
    End Sub

    Private Sub btnAjouterEmploye_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterEmploye.Click
        Dim iEmploye As New iFicheEmploye(maBd, _noHotel, _noEmpl)
        iEmploye.Owner = Me
        Me.Hide()
        iEmploye.Show()
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        requete()
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Owner.Hide()
        Me.Owner.Show()
        Me.Close()
    End Sub

    Private Sub txtNoEmp_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtNoEmp.TextChanged
        requete()
    End Sub

    Private Sub btnFaireHoraire_Click(sender As Object, e As RoutedEventArgs) Handles btnFaireHoraire.Click
        Dim Horaire = New iAjouterHoraire(_noEmpl, _noHotel, maBd)
        Horaire.Owner = Me
        Horaire.Show()
        Me.Hide()
    End Sub

    Private Sub btnModifEmp_Click(sender As Object, e As RoutedEventArgs) Handles btnModifEmp.Click
        If lstEmploye.SelectedIndex <> -1 Then
            Dim numEmpl = lstEmploye.SelectedItem.noEmpl
            Dim iEmploye As New iFicheEmploye(_noEmpl, _noHotel, numEmpl, maBd)
            iEmploye.Owner = Me
            Me.Hide()
            iEmploye.Show()
        Else
            MessageBox.Show("Veuillez sélectionner un employé")
        End If
    End Sub

    Private Sub requete()
        Dim prof = From el In maBd.tblEmploye Where el.noEmpl = _noEmpl Select el.codeProf
        Dim codeProff = prof.Single.ToString()
        Dim res = From el In maBd.tblEmploye
                  Where el.noHotel = _noHotel And el.codeProf = codeProff And el.noEmpl <> _noEmpl And (el.noEmpl.ToString.StartsWith(txtNoEmp.Text) Or (el.nomEmpl + " " + el.prenEmpl).StartsWith(txtNoEmp.Text) Or (el.prenEmpl + " " + el.nomEmpl).StartsWith(txtNoEmp.Text) Or el.codeProf.StartsWith(txtNoEmp.Text))
                  Select el
        'el.noEmpl, el.nomEmpl, el.prenEmpl, el.codeProf
        lstEmploye.DataContext = res.ToList()
    End Sub

    Private Sub btnConsulterHoraire_Click(sender As Object, e As RoutedEventArgs) Handles btnConsulterHoraire.Click
        If lstEmploye.SelectedIndex <> -1 Then
            Dim numEmpl = lstEmploye.SelectedItem.noEmpl
            Dim iHoraire As New iConsulterHoraire(numEmpl, maBd, _noEmpl, _noHotel)
            iHoraire.Owner = Me
            Me.Hide()
            iHoraire.Show()
        Else
            Dim iHoraire As New iConsulterHoraire(maBd, _noEmpl, _noHotel)
            iHoraire.Owner = Me
            Me.Hide()
            iHoraire.Show()
        End If
    End Sub

    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim fiche = New iFicheEmploye(maBd, _noHotel, _noEmpl)
        fiche.Owner = Me.Owner
        fiche.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_1(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeEmploye(_noEmpl, _noHotel, maBd)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_2(sender As Object, e As RoutedEventArgs)
        Dim horaire = New iAjouterHoraire(_noEmpl, _noHotel, maBd)
        horaire.Owner = Me.Owner
        horaire.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_3(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeCOmmande(_noEmpl, _noHotel, maBd)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_4(sender As Object, e As RoutedEventArgs)
        Dim lst = New iCommunique(_noEmpl, _noHotel, maBd)
        lst.Owner = Me.Owner
        lst.Show()
        Me.Close()
    End Sub
End Class