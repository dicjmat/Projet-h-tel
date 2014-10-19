Public Class iLogin
    Dim maBD As P2014_Equipe2_GestionHôtelièreEntities
    Dim checkList As iCheckList
    Dim gerant As iAccueilGerant
    Dim gestion As iAccueilGestionnaire
    Dim gestionPatr As iGestionCentrale
    Dim reserv As iFaireReservation
    Dim vente As iAccueilVente
    Dim reserv As iListeClientReserv
    Private Sub btnQuitter_Click(sender As Object, e As RoutedEventArgs) Handles btnQuitter.Click
        Me.Close()
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
        Dim noEmploye As Short
        Dim nHotel As Short
        Dim res = From el In maBD.tblLogin Where el.utilisateur = txtNomUtilisateur.Text And txtMDP.Password = el.mdp Select el
        If Not My.Computer.Network.IsAvailable Then
            lblErreur.Content = "Erreur de connexion"
            Exit Sub
        ElseIf res.ToList().Count = 0 Then
            lblErreur.Content = "Nom d'utilisateur ou mot de passe invalide"
            Exit Sub
        End If
        typeEmploye = res.First.statut
        noEmploye = res.First.noEmpl
        Dim hotel = From el In maBD.tblEmploye Where el.noEmpl = noEmploye Select el.noHotel

        nHotel = hotel.First()
        lblErreur.Content = ""
        txtMDP.Password = ""
        txtNomUtilisateur.Text = ""
        txtNomUtilisateur.Focus()
        Select Case typeEmploye
            Case "ADMI"
                gerant = New iAccueilGerant(noEmploye, nHotel)
                gerant.Owner = Me
                gerant.Show()
            Case "PERS"
                checkList = New iCheckList(noEmploye, nHotel)
                checkList.Owner = Me
                checkList.Show()
            Case "GEST"
                gestion = New iAccueilGestionnaire(noEmploye, nHotel)
                gestion.Owner = Me
                gestion.Show()
            Case "PATR"
                gestionPatr = New iGestionCentrale()
                gestionPatr.Owner = Me
                gestionPatr.Show()
            Case "RECE"
                reserv = New iListeClientReserv(noEmploye, nHotel)
                reserv.Owner = Me
                reserv.Show()
            Case "VEND"
                vente = New iAccueilVente(nHotel)
                vente.Owner = Me
                vente.Show()
            Case Else
                lblErreur.Content = "Vous n'avez pas accès au système"
                Exit Sub
        End Select
        Me.Hide()
    End Sub

    Private Sub Window_KeyDown(sender As Object, e As KeyEventArgs)
        If e.Key = Key.Enter Then
            login()
        End If
    End Sub
End Class
