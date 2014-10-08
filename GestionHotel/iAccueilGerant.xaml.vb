Public Class iAccueilGerant

    Private noEmploye As Short
    Private noHotel As Short
    Dim maBd As P2014_Equipe2_GestionHôtelièreEntities

    Sub New(p1 As Short, p2 As Short)
        ' TODO: Complete member initialization 
        InitializeComponent()
        noEmploye = p1
        noHotel = p2
    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Me.Owner.Show()
    End Sub

    Private Sub windowAGerant_Loaded(sender As Object, e As RoutedEventArgs) Handles windowAGerant.Loaded
        maBd = New P2014_Equipe2_GestionHôtelièreEntities
        Dim res = From el In maBd.tblEmploye Where el.noEmpl = noEmploye Select el
        lblNomEmpl.Content = "Bonjour, " + res.ToList.Single.prenEmpl + " " + res.ToList.Single.nomEmpl
    End Sub

    Private Sub AppuieRapport()

    End Sub

    Private Sub AppuieGHotel()
        Dim Ghotel = New iListeHotel
        Ghotel.Owner = Me
        Ghotel.Show()
    End Sub

    Private Sub AppuieGChambre()
        Dim Gchambre = New iGestionChambre
        Gchambre.Owner = Me
        Gchambre.Show()
    End Sub

    Private Sub AppuieGSalle()
        Dim Gsalle = New iGestionSalle
        Gsalle.Owner = Me
        Gsalle.Show()
    End Sub

    Private Sub btnDeco_Click(sender As Object, e As RoutedEventArgs) Handles btnDeco.Click
        Me.Owner.Show()
        Me.Close()
    End Sub
End Class
