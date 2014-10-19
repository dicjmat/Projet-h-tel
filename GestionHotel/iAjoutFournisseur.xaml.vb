Public Class iAjoutFournisseur
    Dim maBd As P2014_Equipe2_GestionHôtelièreEntities
    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
        Me.Owner.Show()
    End Sub

    Private Sub btnConfirmer_Click(sender As Object, e As RoutedEventArgs) Handles btnConfirmer.Click
        Dim fournisseur = New tblFournisseur
        fournisseur.nomFournisseur = txtNomFourni.Text
        fournisseur.adrFournisseur = txtAdrFourni.Text
        fournisseur.CPFournisseur = txtcodePostFourni.Text
        fournisseur.noTelFournisseur = txtnoTelFourni.Text
        fournisseur.respFournisseur = txtRespFourni.Text
        maBd.tblFournisseur.Add(fournisseur)
    End Sub

    Private Sub windowAjoutFournisseur_Loaded(sender As Object, e As RoutedEventArgs) Handles windowAjoutFournisseur.Loaded
        maBd = New P2014_Equipe2_GestionHôtelièreEntities
        Dim res = From Vi In maBd.tblVille
                  Select Vi

        cbVilleFourni.DataContext = res.ToList
    End Sub


    Private Sub windowAjoutFournisseur_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles windowAjoutFournisseur.Closing
        Me.Owner.Show()
    End Sub
End Class
