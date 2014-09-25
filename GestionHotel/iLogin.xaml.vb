Public Class iLogin
    Dim maBD As P2014_Equipe2_GestionHôtelièreEntities

    Private Sub btnQuitter_Click(sender As Object, e As RoutedEventArgs) Handles btnQuitter.Click
        Me.Close()
    End Sub

    Private Sub btnConfirmer_Click(sender As Object, e As RoutedEventArgs) Handles btnConfirmer.Click
        Dim res = From el In maBD.tblLogin Where el.utilisateur = txtNomUtilisateur.Text And txtMDP.Password = el.mdp Select el
        'If Not My.Computer.Network.IsAvailable Then
        '    lblReussi.Content = "Erreur de connexion"
        'ElseIf res.ToList().Count = 0 Then
        '    lblReussi.Content = "Erreur de connexion"
        'Else
        '    lblReussi.Content = "Connexion réussie"
        'End If
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        maBD = New P2014_Equipe2_GestionHôtelièreEntities
    End Sub
End Class
