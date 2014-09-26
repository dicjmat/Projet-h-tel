Public Class iCheckList

    Private _p1 As Short
    Private _p2 As Short
    Private BD As P2014_Equipe2_GestionHôtelièreEntities
    Private hotel

    Sub New(p1 As Short, p2 As Short)
        InitializeComponent()
        _p1 = p1
        _p2 = p2
    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Me.Owner.Show()
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim nHotel As Short
        BD = New P2014_Equipe2_GestionHôtelièreEntities
        hotel = From el In BD.tblEmploye Where el.noEmpl = _p1 Select el.noHotel
        nHotel = Convert.ToInt16(hotel.First())
        Dim res = From el In BD.tblChambre Where el.noHotel = nHotel Select el

        cbChambre.DataContext = res.ToList()
    End Sub

    Private Sub btnQuitter_Click(sender As Object, e As RoutedEventArgs) Handles btnQuitter.Click
        Me.Close()
    End Sub

    Private Sub cbChambre_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cbChambre.SelectionChanged
        Dim chambre = Convert.ToInt16(cbChambre.SelectedValue.nom())
        Dim typeChambre = From el In BD.tblChambre Where el.noChambre = chambre And el.noHotel = Convert.ToInt16(hotel) Select el.codeTypeChambre
        Dim res = From el In BD.tblItem Join comp In BD.tblGabarit On comp.codeItem Equals el.codeItem Where comp.codeTypeChambre = typeChambre.ToString() Select el.descItem

        lbItem.DataContext = res.ToList()
    End Sub
End Class
