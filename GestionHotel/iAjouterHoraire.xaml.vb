Public Class iAjouterHoraire
    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Private noGest As Short
    Sub New(_noGestionnaire As Short)
        InitializeComponent()
        noGest = _noGestionnaire
    End Sub
    Sub New(_noGestionnaire As Short, _noEmploye As Short)
        InitializeComponent()
        'noEmploye = _noEmploye
    End Sub
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        bd = New P2014_Equipe2_GestionHôtelièreEntities
        Dim profGest = From el In bd.tblEmploye Where noGest = el.noEmpl Select el.codeProf

        Dim prof = profGest.Single.ToString()
        Dim res = From el In bd.tblEmploye Where el.codeProf = prof Select el

        cbEmploye.DataContext = res.ToList()
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Focusable = False
        Me.Close()
    End Sub
End Class
