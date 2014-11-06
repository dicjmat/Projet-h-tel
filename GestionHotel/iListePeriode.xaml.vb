Public Class iListePeriode
    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Dim noEmp As Integer
    Dim noHotel As Integer
    Dim p2 As Integer

    Sub New(_bd As P2014_Equipe2_GestionHôtelièreEntities, _noHotel As Integer, _noEmp As Integer, _p2 As Integer)

        InitializeComponent()
        bd = _bd
        noEmp = _noEmp
        noHotel = _noHotel
        p2 = _p2

    End Sub
    Private Sub window_lstPeriode_Loaded(sender As Object, e As RoutedEventArgs) Handles window_lstPeriode.Loaded
    End Sub
    Private Sub btnAjoutForfait_Click(sender As Object, e As RoutedEventArgs) Handles btnAjoutForfait.Click
        Dim forf = New iAjoutForf(True, noHotel, bd)
        forf.Owner = Me
        forf.Show()
    End Sub

    Private Sub btnListeForf_Click(sender As Object, e As RoutedEventArgs) Handles btnListeForf.Click
        Dim lst = New ListeForfait(noHotel, bd, noEmp, p2)
        lst.Owner = Me
        lst.Show()
    End Sub
    Private Sub btnListeSalle_Click(sender As Object, e As RoutedEventArgs) Handles btnListeSalle.Click
        Dim lst = New iListeSalle(noHotel, bd, noEmp)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub btnRabais_Click(sender As Object, e As RoutedEventArgs) Handles btnRabais.Click
        Dim rab = New iRabais(noHotel, bd, noEmp, p2)
        rab.Owner = Me
        rab.Show()
    End Sub

End Class
