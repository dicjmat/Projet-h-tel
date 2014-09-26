Public Class iAccueilGestionnaire

    Private _p1 As Short
    Private _p2 As Short

    Sub New(p1 As Short, p2 As Short)
        ' TODO: Complete member initialization 
        InitializeComponent()
        _p1 = p1
        _p2 = p2
    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Me.Owner.Show()
    End Sub

    Private Sub btnFicheEmploye_Click(sender As Object, e As RoutedEventArgs) Handles btnFicheEmploye.Click
        Dim iEmploye As New iFicheEmploye
        iEmploye.Show()
    End Sub

    Private Sub btnInventaire_Click(sender As Object, e As RoutedEventArgs) Handles btnInventaire.Click
        Dim inventaire = New iInventaire(_p2)
        inventaire.Show()
    End Sub

    Private Sub btnDeco_Click(sender As Object, e As RoutedEventArgs) Handles btnDeco.Click
        Me.Close()
    End Sub
End Class
