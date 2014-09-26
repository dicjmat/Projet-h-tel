Public Class iAccueilGestionnaire

    Private _p1 As String

    Sub New(p1 As String)
        ' TODO: Complete member initialization 
        InitializeComponent()
        _p1 = p1
    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Me.Owner.Show()
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Me.Close()
    End Sub

    Private Sub btnFicheEmploye_Click(sender As Object, e As RoutedEventArgs) Handles btnFicheEmploye.Click
        Dim iEmploye = New iFicheEmploye
        iEmploye.Show()
    End Sub
End Class
