Public Class iCheckList

    Private _p1 As String

    Sub New(p1 As String)
        ' TODO: Complete member initialization 
        InitializeComponent()
        _p1 = p1
    End Sub

    Dim BD As P2014_Equipe2_GestionHôtelièreEntities
    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Me.Owner.Show()
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        BD = New P2014_Equipe2_GestionHôtelièreEntities

        Dim res = From el In BD.tblChambre Select el

        cbChambre.DataContext = res.ToList()
    End Sub

    Private Sub btnQuitter_Click(sender As Object, e As RoutedEventArgs) Handles btnQuitter.Click
        Me.Close()
    End Sub
End Class
