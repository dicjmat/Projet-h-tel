Public Class iListePeriode
    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Private Sub window_lstPeriode_Loaded(sender As Object, e As RoutedEventArgs) Handles window_lstPeriode.Loaded
        Dim noEmp As Integer
        Dim noHotel As Integer
        Dim p2 As Integer
        Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Private Sub btnAjoutForfait_Click(sender As Object, e As RoutedEventArgs) Handles btnAjoutForfait.Click
        Dim forf = New iAjoutForf(True, noHotel, bd)
        forf.Owner = Me
        forf.Show()
    End Sub

    Private Sub btnListeForf_Click(sender As Object, e As RoutedEventArgs) Handles btnListeForf.Click
        Dim lst = New ListeForfait(noHotel, bd, noEmp)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub btnReservSalle_Click(sender As Object, e As RoutedEventArgs) Handles btnReservSalle.Click
        Dim reserv = New iFaireReservSalle(noHotel, bd, noEmp)
        reserv.Owner = Me
        reserv.Show()
    End Sub

    Private Sub btnListeSalle_Click(sender As Object, e As RoutedEventArgs) Handles btnListeSalle.Click
        Dim lst = New iListeSalle(noHotel, bd, noEmp)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub btnRabais_Click(sender As Object, e As RoutedEventArgs) Handles btnRabais.Click
        Dim rab = New iRabais(noHotel, bd, noEmp)
        rab.Owner = Me
        rab.Show()
    End Sub
    End Sub
    End Sub
End Class
