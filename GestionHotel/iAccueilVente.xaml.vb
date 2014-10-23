Public Class iAccueilVente

    Private hotel As Short
    Private _maBD As P2014_Equipe2_GestionHôtelièreEntities
    Private _nHotel As Short

    Sub New(nHotel As Short)
        ' TODO: Complete member initialization 
        InitializeComponent()
        hotel = nHotel
    End Sub

    Sub New(maBD As P2014_Equipe2_GestionHôtelièreEntities, nHotel As Short)
        ' TODO: Complete member initialization 
        _maBD = maBD
        _nHotel = nHotel
    End Sub

    Private Sub AppuieForfait()
        Dim Forfait = New ListeForfait(hotel)
        Forfait.Owner = Me
        Forfait.Show()
    End Sub

    Private Sub btnDeco_Click(sender As Object, e As RoutedEventArgs) Handles btnDeco.Click
        Me.Owner.Show()
        Me.Close()
    End Sub
    Private Sub AppuieRabais()
        Dim Rabais = New iRabais(hotel)
        Rabais.Owner = Me
        Rabais.Show()
    End Sub

    Private Sub AppuieSalle()
        Dim salle = New iFaireReservSalle()
        salle.Owner = Me
        salle.Show()
    End Sub

End Class
