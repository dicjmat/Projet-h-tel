Public Class AjoutProvince

    Private codePays As String
    Private bd As P2014_Equipe2_GestionHôtelièreEntities

    Sub New(_codePays As Object)
        InitializeComponent()
        codePays = _codePays
    End Sub

    Private Sub btnAnnuler_Click(sender As Object, e As RoutedEventArgs) Handles btnAnnuler.Click
        Me.Close()
    End Sub

    Private Sub btnAjouter_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouter.Click
        If txtCodeProv.Text <> "" And txtNomProv.Text <> "" Then
            bd = New P2014_Equipe2_GestionHôtelièreEntities()
            Dim Province = New tblProvince()
            Province.codeProv = txtCodeProv.Text
            Province.nomProv = txtNomProv.Text
            Province.codePays = codePays
            bd.tblProvince.Add(Province)
            bd.SaveChanges()
            MessageBox.Show("La province est ajouté", "Confirmation", MessageBoxButton.OK)
            Me.Close()
        End If
    End Sub
End Class
