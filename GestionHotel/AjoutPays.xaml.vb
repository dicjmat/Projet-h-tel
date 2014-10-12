Public Class AjoutPays
    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Private Sub btnAnnuler_Click(sender As Object, e As RoutedEventArgs) Handles btnAnnuler.Click
        Me.Close()
    End Sub

    Private Sub btnAjouter_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouter.Click
        If txtCodePays.Text <> "" And txtnomPays.Text <> "" Then
            bd = New P2014_Equipe2_GestionHôtelièreEntities()
            Dim Pays = New tblPays()
            Pays.codePays = txtCodePays.Text
            Pays.nomPays = txtnomPays.Text
            bd.tblPays.Add(Pays)
            bd.SaveChanges()
            MessageBox.Show("Le pays est ajouté", "Confirmation", MessageBoxButton.OK)
            Me.Close()
        End If
    End Sub
End Class
