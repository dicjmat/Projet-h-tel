Public Class iGestionCentrale

    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Dim noEmp As Integer
    Dim noHotel As Integer
    Dim p2 As Integer

    Sub New(maBD As P2014_Equipe2_GestionHôtelièreEntities, _noEmp As Integer, _noHotel As Integer, _p2 As Integer)
        ' TODO: Complete member initialization 
        InitializeComponent()
        bd = maBD
        noEmp = _noEmp
        noHotel = _noHotel
        p2 = _p2
    End Sub

    Private Sub AppuieRapport()

    End Sub
    Private Sub AppuielstCent()
        Dim liste = New iListeCentrale(bd, noEmp, noHotel, p2)
        liste.Owner = Me
        liste.Show()
        Me.Hide()
    End Sub

    Private Sub AppuielstEmp()
        Dim lstemp = New iListeEmployeComplet(bd, noEmp, noHotel, p2)
        lstemp.Owner = Me
        lstemp.Show()
    End Sub

    Private Sub AppuieInvComp()
        Dim invComplet = New iInventaireComplet(bd, noEmp, noHotel, p2)
        invComplet.Owner = Me
        invComplet.Show()
    End Sub

    Private Sub btnDeco_Click(sender As Object, e As RoutedEventArgs) Handles btnDeco.Click
        Me.Owner.Show()
        Me.Close()
    End Sub
End Class
