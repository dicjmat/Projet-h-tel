Public Class iAccueilGerant

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
End Class
