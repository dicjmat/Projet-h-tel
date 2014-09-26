Public Class iCheckList

    Private _p1 As String

    Sub New(p1 As String)
        ' TODO: Complete member initialization 
        InitializeComponent()
        _p1 = p1
    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Me.Owner.Show()
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)

    End Sub
End Class
