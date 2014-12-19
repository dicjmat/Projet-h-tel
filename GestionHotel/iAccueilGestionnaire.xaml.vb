Public Class iAccueilGestionnaire

    Private noEmpl As Short
    Private noHotel As Short
    Dim maBd As P2014_Equipe2_GestionHôtelièreEntities

    Sub New(_maBD As P2014_Equipe2_GestionHôtelièreEntities, noEmploye As Short, nHotel As Short)
        ' TODO: Complete member initialization 
        InitializeComponent()
        maBd = _maBD
        noEmpl = noEmploye
        noHotel = nHotel
    End Sub

    Private Sub btnDeco_Click(sender As Object, e As RoutedEventArgs) Handles btnDeco.Click
        Me.Owner.Show()
        Me.Close()
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim res = From el In maBd.tblEmploye Where el.noEmpl = noEmpl Select el

        lblNom.Content = "Bonjour, " + res.ToList.Single.prenEmpl + " " + res.ToList.Single.nomEmpl
    End Sub

    Private Sub AppuieCommande()
        Dim lstcommande = New iListeCOmmande(noEmpl, noHotel, maBd)
        lstcommande.Owner = Me
        Me.Hide()
        lstcommande.Show()
    End Sub

    Private Sub AppuieLEmploye()
        Dim iEmploye = New iListeEmploye(noEmpl, noHotel, maBd)
        iEmploye.Owner = Me
        iEmploye.Show()
        Me.Hide()
    End Sub

    Private Sub AppuieCommunique()
        Dim com = New iCommunique(noEmpl, noHotel, maBd)
        com.Owner = Me
        com.Show()
        Me.Hide()
    End Sub

    Private Sub AppuieEmp()
        Dim emp = New iFicheEmploye(maBd, noHotel, noEmpl)
        emp.Owner = Me
        emp.Show()
        Me.Hide()
    End Sub

    Private Sub AppuieHoraire()
        Dim ho = New iAjouterHoraire(noEmpl, noHotel, maBd)
        ho.Owner = Me
        ho.Show()
        Me.Hide()
    End Sub
End Class
