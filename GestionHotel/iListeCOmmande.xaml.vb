Public Class iListeCOmmande
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Private _noHotel As Short

    Sub New(noHotel As Short)
        ' TODO: Complete member initialization 
        InitializeComponent()
        _noHotel = noHotel
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Focusable = False
        Me.Close()
    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Me.Owner.Show()
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        bd = New P2014_Equipe2_GestionHôtelièreEntities
        'Dim res = From Co In bd.tblCommande Join Em In bd.tblEmploye On Co.noEmpl Equals Em.noEmpl
        '          Where noHotel = Em.noEmpl
        '          Select Co

        dgCommande.ItemsSource = res.ToList()
    End Sub

    Private Sub txtRComm_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtRComm.TextChanged
        'Dim res = From Co In bd.tblCommande Join Em In bd.tblEmploye On Co.noEmpl Equals Em.noEmpl
        '          Where noHotel = Em.noEmpl And ((Em.nomEmpl + " " + Em.prenEmpl).StartsWith(txtRComm.Text) Or (Em.prenEmpl + " " + Em.nomEmpl).StartsWith(txtRComm.Text) Or Co.dateCommande.ToString.StartsWith(txtRComm.Text) Or Co.etatCommande.StartsWith(txtRComm.Text))
        '          Select Co
    End Sub
End Class
