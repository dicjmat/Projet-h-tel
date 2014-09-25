Public Class iLogin
    Dim maBD As P2014_Equipe2_GestionHôtelièreEntities
    Dim checkList As iCheckList
    Dim gerant As iAccueilGerant
    Dim gestion As iAccueilGestionnaire
    Private Sub btnQuitter_Click(sender As Object, e As RoutedEventArgs) Handles btnQuitter.Click
        Me.Close()
    End Sub

    Private Sub btnConfirmer_Click(sender As Object, e As RoutedEventArgs) Handles btnConfirmer.Click
        login()
    End Sub

    Private Sub Grid_Loaded(sender As Object, e As RoutedEventArgs)
        maBD = New P2014_Equipe2_GestionHôtelièreEntities
        checkList = New iCheckList
        gerant = New iAccueilGerant
        gestion = New iAccueilGestionnaire
        txtNomUtilisateur.Focus()
    End Sub

    Private Sub login()
        Dim typeEmploye As String
        Dim res = From el In maBD.tblLogin Where el.utilisateur = txtNomUtilisateur.Text And txtMDP.Password = el.mdp Select el
        If Not My.Computer.Network.IsAvailable Then
            lblErreur.Content = "Erreur de connexion"
        ElseIf res.ToList().Count = 0 Then
            lblErreur.Content = "Le nom d'utilisateur ou le mot de passe est invalide"
        End If
        typeEmploye = res.First.statut
        Select Case typeEmploye
            Case "ADMI"
                gerant.Show()
            Case "PERS"
                checkList.Show()
            Case "GEST"
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
