Public Class ModifierReserv
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Dim dated As Date
    Dim datef As Date
    Dim noChambre As Integer
    Dim noHotel As Integer


    Sub New(_bd As P2014_Equipe2_GestionHôtelièreEntities, _dated As Date, _datef As Date, _noChambre As Integer, _noHotel As Integer)
        InitializeComponent()
        bd = _bd
        dated = _dated
        datef = _datef
        noChambre = _noChambre
        noHotel = _noHotel
    End Sub

    Private Sub btnAccept_Click(sender As Object, e As RoutedEventArgs) Handles btnAccept.Click
        Dim res = From el In bd.tblReservation
          Where el.dateDebutSejour = dated And el.noSalle = noChambre And el.noHotel = noHotel
          Select el
        res.First.dateDebutSejour = datefin.SelectedDate
        res.First.dateFinSejour = datedeb.SelectedDate
        MessageBox.Show("La modification s'est effectué avec succès.")

    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        datedeb.SelectedDate = dated
        datefin.SelectedDate = datef

    End Sub
End Class
