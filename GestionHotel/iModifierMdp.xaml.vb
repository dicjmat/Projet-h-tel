﻿Imports System.Text.RegularExpressions

Public Class iModifierMdp

    Private _maBD As P2014_Equipe2_GestionHôtelièreEntities
    Private _noEmp As Integer

    Sub New(maBD As P2014_Equipe2_GestionHôtelièreEntities, noEmp As Integer)
        InitializeComponent()
        _maBD = maBD
        _noEmp = noEmp
        txtMdp.Focus()
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub

    Private Sub btnModifierMdp_Click(sender As Object, e As RoutedEventArgs) Handles btnModifierMdp.Click
        modifier()
    End Sub

    Private Sub windowModifierMdp_KeyDown(sender As Object, e As KeyEventArgs) Handles windowModifierMdp.KeyDown
        If e.Key = Key.Enter Then
            modifier()
        End If
    End Sub

    Private Sub modifier()
        Dim regex = New Regex("^(?=(.*[A-Z]))(?=(.*[0-9]))(?!.*\|)(?=[a-zA-Z0-9]{6,})")
        If txtMdp.Password = txtConfirmation.Password Then
            If regex.IsMatch(txtMdp.Password) Then
                Dim res = From lo In _maBD.tblLogin
                          Where lo.noEmpl = _noEmp
                          Select lo

                res.First.mdp = txtMdp.Password
                res.First.premiereConnexion = False
                _maBD.SaveChanges()
                MessageBox.Show("Votre mot de passe a bien été modifié")
                Me.Close()
            Else
                lblErreur.Content = "Le mot de passe doit contenir au minimum" & vbCrLf & "-6 caractères    -1 majuscule    -1 chiffres"
            End If

        Else
            lblErreur.Content = "Les deux mot de passe ne sont pas pareils"
        End If
    End Sub
End Class
