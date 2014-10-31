Public Class AjoutProvince

    Private codePays As String
    Private bd As P2014_Equipe2_GestionHôtelièreEntities

    Sub New(p1 As Object, _bd As P2014_Equipe2_GestionHôtelièreEntities)
        InitializeComponent()
        codePays = p1
        bd = _bd
    End Sub

    Private Sub btnAnnuler_Click(sender As Object, e As RoutedEventArgs) Handles btnAnnuler.Click
        Me.Close()
    End Sub

    Private Sub btnAjouter_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouter.Click
        If txtCodeProv.Text <> "" And txtNomProv.Text <> "" Then
            Dim Province = New tblProvince()
            Province.codeProv = txtCodeProv.Text
            Province.nomProv = txtNomProv.Text
            Province.codePays = codePays
            bd.tblProvince.Add(Province)
            bd.SaveChanges()
            MessageBox.Show("La province est ajouté", "Confirmation", MessageBoxButton.OK)
            Me.Close()
        Else
            MessageBox.Show("Veuillez entrer le code et le nom de la province")
        End If
    End Sub
End Class
