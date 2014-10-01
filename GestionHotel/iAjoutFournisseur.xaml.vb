Public Class iAjoutFournisseur
    Dim maBd As P2014_Equipe2_GestionHôtelièreEntities
    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
        Me.Owner.Show()
    End Sub

    Private Sub btnConfirmer_Click(sender As Object, e As RoutedEventArgs) Handles btnConfirmer.Click
        Dim fournisseur = New tblFournisseur
        fournisseur.nomFournisseur = txtNomFourni.Text
        maBd.tblFournisseur.Add(fournisseur)
    End Sub

    Private Sub windowAjoutFournisseur_Loaded(sender As Object, e As RoutedEventArgs) Handles windowAjoutFournisseur.Loaded
        maBd = New P2014_Equipe2_GestionHôtelièreEntities
    End Sub
End Class
