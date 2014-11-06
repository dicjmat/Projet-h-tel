Public Class iAccueilVente

    Private hotel As Short
    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Private noEmpl As Integer
    Dim p2 As Integer

    Sub New(maBD As P2014_Equipe2_GestionHôtelièreEntities, nHotel As Short, _noEmpl As Integer, _p2 As Integer)
        InitializeComponent()
        bd = maBD
        hotel = nHotel
        noEmpl = _noEmpl
        p2 = _p2
    End Sub

    Private Sub AppuieForfait()
        Dim Forfait = New ListeForfait(hotel, bd, noEmpl)
        Forfait.Owner = Me
        Forfait.Show()
    End Sub

    Private Sub btnDeco_Click(sender As Object, e As RoutedEventArgs) Handles btnDeco.Click
        Me.Owner.Show()
        Me.Close()
    End Sub
    Private Sub AppuieRabais()
        Dim Rabais = New iRabais(hotel, bd, noEmpl)
        Rabais.Owner = Me
        Rabais.Show()
    End Sub

    Private Sub AppuieSalle()
        Dim salle = New iListeSalle(hotel, bd, noEmpl)
        salle.Owner = Me
        salle.Show()
    End Sub

    Private Sub AppuiePeriode()
        Dim periode = New iListePeriode(bd, hotel, noEmpl, p2)
        periode.Owner = Me
        periode.Show()
    End Sub

End Class
