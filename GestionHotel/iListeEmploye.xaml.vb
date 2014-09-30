Public Class iListeEmploye

    Private _noHotel As Short
    Dim maBd As P2014_Equipe2_GestionHôtelièreEntities
    Sub New(noHotel As Short)
        ' TODO: Complete member initialization 
        InitializeComponent()
        _noHotel = noHotel
    End Sub

    Private Sub btnAjouterEmploye_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterEmploye.Click
        Dim iEmploye As New iFicheEmploye
        iEmploye.Owner = Me
        Me.Hide()
        iEmploye.Show()
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        maBd = New P2014_Equipe2_GestionHôtelièreEntities
        Dim res = From el In maBd.tblEmploye Where el.noHotel = _noHotel Select el

        'el.noEmpl, el.nomEmpl, el.prenEmpl, el.codeProf
        lstEmploye.DataContext = res.ToList()

    End Sub

    'Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
    '    Me.Owner.Show()
    'End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Focusable = False
        Me.Close()
    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        If Me.Focusable Then
            Me.Owner.Close()
        End If

    End Sub
End Class
