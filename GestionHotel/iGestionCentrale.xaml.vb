Public Class iGestionCentrale

    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Dim noEmp As Integer
    Dim noHotel As Integer

    Sub New(maBD As P2014_Equipe2_GestionHôtelièreEntities, _noEmp As Integer, _noHotel As Integer)
        InitializeComponent()
        bd = maBD
        noEmp = _noEmp
        noHotel = _noHotel
    End Sub

    Private Sub AppuieRapport()

    End Sub
    Private Sub AppuielstCent()
        Dim liste = New iListeCentrale(bd, noEmp, noHotel)
        liste.Owner = Me
        liste.Show()
        Me.Hide()
    End Sub

    Private Sub AppuielstEmp()
        Dim lstemp = New iListeEmployeComplet(bd, noEmp, noHotel)
        lstemp.Owner = Me
        lstemp.Show()
    End Sub

    Private Sub AppuieInvComp()
        Dim invComplet = New iInventaireComplet(bd, noEmp, noHotel)
        invComplet.Owner = Me
        invComplet.Show()
    End Sub

    Private Sub btnDeco_Click(sender As Object, e As RoutedEventArgs) Handles btnDeco.Click
        Me.Owner.Show()
        Me.Close()
    End Sub
End Class
