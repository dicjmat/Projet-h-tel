Public Class iGestionCentrale

    Private bd As P2014_Equipe2_GestionHôtelièreEntities

    Sub New(maBD As P2014_Equipe2_GestionHôtelièreEntities)
        ' TODO: Complete member initialization 
        InitializeComponent()
        bd = maBD
    End Sub

    Private Sub AppuieRapport()

    End Sub
    Private Sub AppuielstCent()
        Dim liste = New iListeCentrale(bd)
        liste.Owner = Me
        liste.Show()
        Me.Hide()
    End Sub

    Private Sub AppuielstEmp()
        Dim lstemp = New iListeEmployeComplet(bd)
        lstemp.Owner = Me
        lstemp.Show()
    End Sub

    Private Sub AppuieInvComp()
        Dim invComplet = New iInventaireComplet(bd)
        invComplet.Owner = Me
        invComplet.Show()
    End Sub

    Private Sub btnDeco_Click(sender As Object, e As RoutedEventArgs) Handles btnDeco.Click
        Me.Owner.Show()
        Me.Close()
    End Sub
End Class
