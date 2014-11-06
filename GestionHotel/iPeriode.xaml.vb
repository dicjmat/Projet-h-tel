Public Class iPeriode

    Private Sub btnAjouter_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouter.Click
        If txtNomP.Text <> "" And dpDebut.Text <> "" And dpFin.Text <> "" Then
            Dim periode = New tblPeriode
            periode.nomPeriode = txtNomP.Text
            periode.dateDebutPeriode = dpDebut.Text
            periode.dateFinPeriode = dpFin.Text
        Else
            MessageBox.Show("Un des champs n'a pas été rempli")
        End If

    End Sub
End Class
