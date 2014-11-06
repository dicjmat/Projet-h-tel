Public Class iFaireReservSalle

    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Private nohotel As Short
    Dim noEmp As Integer

    Sub New(_nohotel As Short, _bd As P2014_Equipe2_GestionHôtelièreEntities, _noEmp As Integer)
        InitializeComponent()
        bd = _bd
        nohotel = _nohotel
        noEmp = _noEmp
    End Sub

    Private Sub window_ReservSalle_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles window_ReservSalle.Closing
        Me.Owner.Show()
    End Sub

    Private Sub btnAjoutForfait_Click(sender As Object, e As RoutedEventArgs) Handles btnAjoutForfait.Click
        Dim forf = New iAjoutForf(False, nohotel, bd)
        forf.Owner = Me
        forf.Show()
    End Sub

    Private Sub btnListeForf_Click(sender As Object, e As RoutedEventArgs) Handles btnListeForf.Click
        Dim lst = New ListeForfait(nohotel, bd, noEmp)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub btnRabais_Click(sender As Object, e As RoutedEventArgs) Handles btnRabais.Click
        Dim rab = New iRabais(nohotel, bd, noEmp)
        rab.Owner = Me
        rab.Show()
    End Sub

    Private Sub btnListeSalle_Click(sender As Object, e As RoutedEventArgs) Handles btnListeSalle.Click
        Dim lst = New iListeSalle(nohotel, bd, noEmp)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub btnLPeriode_Click(sender As Object, e As RoutedEventArgs) Handles btnLPeriode.Click
        Dim per = New iListePeriode
        per.Owner = Me
        per.Show()
    End Sub
End Class
