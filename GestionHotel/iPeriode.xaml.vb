Public Class iPeriode

    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Private hotel As Integer
    Private codePeriode As String

    Sub New(_bd As P2014_Equipe2_GestionHôtelièreEntities, noHotel As Integer)
        InitializeComponent()
        bd = _bd
        hotel = noHotel
        btnAjouter.Visibility = Windows.Visibility.Visible
        btnModifier.Visibility = Windows.Visibility.Hidden
    End Sub

    Sub New(_bd As P2014_Equipe2_GestionHôtelièreEntities, noHotel As Integer, p3 As Object)
        InitializeComponent()
        bd = _bd
        hotel = noHotel
        codePeriode = p3
        btnAjouter.Visibility = Windows.Visibility.Hidden
        btnModifier.Visibility = Windows.Visibility.Visible
        txtCodeP.IsEnabled = False
    End Sub

    Private Sub btnAjouter_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouter.Click
        If txtCodeP.Text <> "" And txtNomP.Text <> "" And dpDebut.Text <> "" And dpFin.Text <> "" Then
            Dim periode = New tblPeriode
            periode.codePeriode = txtCodeP.Text
            periode.nomPeriode = txtNomP.Text
            periode.dateDebutPeriode = dpDebut.Text
            periode.dateFinPeriode = dpFin.Text
            bd.tblPeriode.Add(periode)
            For Each tych In From typch In bd.tblTypeSalleHotel Where typch.noHotel = hotel And typch.codeTypeSalle <> "REU"
                Dim type = New tblPeriodeTypeSalle
                type.codePeriode = periode.codePeriode
                type.codeTypeSalle = tych.codeTypeSalle
                type.noHotel = hotel
                type.prixSallePeriode = tych.prixSalle
                bd.tblPeriodeTypeSalle.Add(type)
            Next
            bd.SaveChanges()
            MessageBox.Show("La période a bien été ajoutée")
        Else
            MessageBox.Show("Un des champs n'a pas été rempli")
        End If

    End Sub

    Private Sub btnModifier_Click(sender As Object, e As RoutedEventArgs) Handles btnModifier.Click
        If txtCodeP.Text <> "" And txtNomP.Text <> "" And dpDebut.Text <> "" And dpFin.Text <> "" Then
            Dim periode = New tblPeriode
            periode.nomPeriode = txtNomP.Text
            periode.dateDebutPeriode = dpDebut.Text
            periode.dateFinPeriode = dpFin.Text
        Else
            MessageBox.Show("Un des champs n'a pas été rempli")
        End If
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Close()
    End Sub
End Class
