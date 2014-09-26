﻿Public Class iLogin
    Dim maBD As P2014_Equipe2_GestionHôtelièreEntities
    Dim checkList As iCheckList
    Dim gerant As iAccueilGerant
    Dim gestion As iAccueilGestionnaire
    Private Sub btnQuitter_Click(sender As Object, e As RoutedEventArgs) Handles btnQuitter.Click
        Me.Close()
        checkList.Close()
        gerant.Close()
        gestion.Close()
    End Sub

    Private Sub btnConfirmer_Click(sender As Object, e As RoutedEventArgs) Handles btnConfirmer.Click
        login()
    End Sub

    Private Sub Grid_Loaded(sender As Object, e As RoutedEventArgs)
        maBD = New P2014_Equipe2_GestionHôtelièreEntities



        txtNomUtilisateur.Focus()
    End Sub

    Private Sub login()
        Dim typeEmploye As String
        Dim res = From el In maBD.tblLogin Where el.utilisateur = txtNomUtilisateur.Text And txtMDP.Password = el.mdp Select el
        If Not My.Computer.Network.IsAvailable Then
            lblErreur.Content = "Erreur de connexion"
            Exit Sub
        ElseIf res.ToList().Count = 0 Then
            lblErreur.Content = "Nom d'utilisateur ou mot de passe invalide"
            Exit Sub
        End If
        typeEmploye = res.First.statut
        lblErreur.Content = ""
        txtMDP.Password = ""
        Select Case typeEmploye
            Case "ADMI"
                gerant = New iAccueilGerant
                gerant.Show()
            Case "PERS"
                checkList = New iCheckList
                checkList.Show()
            Case "GEST"
                gestion = New iAccueilGestionnaire
                gestion.Show()
            Case Else

        End Select
    End Sub

    Private Sub Window_KeyDown(sender As Object, e As KeyEventArgs)
        If e.Key = Key.Enter Then
            login()
        End If
    End Sub
End Class
