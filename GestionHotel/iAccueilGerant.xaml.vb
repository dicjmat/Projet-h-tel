Public Class iAccueilGerant

    Private noEmploye As Short
    Private noHotel As Short
    Dim maBd As P2014_Equipe2_GestionHôtelièreEntities

    Sub New(_maBD As P2014_Equipe2_GestionHôtelièreEntities, _noEmploye As Short, nHotel As Short)
        ' TODO: Complete member initialization
        InitializeComponent()
        maBd = _maBD
        noEmploye = _noEmploye
        noHotel = nHotel
    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Me.Owner.Show()
    End Sub

    Private Sub windowAGerant_Loaded(sender As Object, e As RoutedEventArgs) Handles windowAGerant.Loaded
        Dim res = From el In maBd.tblEmploye Where el.noEmpl = noEmploye Select el
        lblNomEmpl.Content = "Bonjour, " + res.ToList.Single.prenEmpl + " " + res.ToList.Single.nomEmpl
    End Sub

    Private Sub AppuieGHotel()
        Dim Ghotel = New iListeHotel(maBd, noEmploye, noHotel)
        Ghotel.Owner = Me
        Ghotel.Show()
    End Sub

    Private Sub AppuieGSalle()
        Dim Gsalle = New iGestionSalle(maBd)
        Gsalle.Owner = Me
        Gsalle.Show()
    End Sub

    Private Sub btnDeco_Click(sender As Object, e As RoutedEventArgs) Handles btnDeco.Click
        Me.Owner.Show()
        Me.Close()
    End Sub

    Private Sub AppuieEmploye()
        Dim gEmp = New iListeEmployeComplet(maBd, noEmploye, noHotel)
        gEmp.Owner = Me
        gEmp.Show()
    End Sub

    Private Sub AppuieItem()
        Dim inv = New iInventaireComplet(maBd, noEmploye, noHotel)
        inv.Owner = Me
        Me.Close()
    End Sub

End Class
