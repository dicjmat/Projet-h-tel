Public Class AjoutVille

    Private codeProvince As Object
    Private bd As P2014_Equipe2_GestionHôtelièreEntities

    Sub New(_codeProvince As Object)
        InitializeComponent()
        codeProvince = _codeProvince
    End Sub

    Private Sub btnAnnuler_Click(sender As Object, e As RoutedEventArgs) Handles btnAnnuler.Click
        Me.Close()
    End Sub

    Private Sub btnAjouter_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouter.Click
        If txtCodeVille.Text <> "" And txtNomVille.Text <> "" Then
            bd = New P2014_Equipe2_GestionHôtelièreEntities()
            Dim Ville = New tblVille()
            Ville.codeVille = txtCodeVille.Text
            Ville.nomVille = txtNomVille.Text
            Ville.codeProv = codeProvince
            bd.tblVille.Add(Ville)
            bd.SaveChanges()
            MessageBox.Show("La ville est ajouté", "Confirmation", MessageBoxButton.OK)
        End If
    End Sub
End Class
