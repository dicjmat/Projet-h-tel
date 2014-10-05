Public Class iAjouterHoraire
    Private bd As P2014_Equipe2_GestionHôtelièreEntities
    Private noGest As Short
    Private hotel As Short
    Sub New(_noGestionnaire As Short)
        InitializeComponent()

    End Sub
    Sub New(_noGestionnaire As Short, _noHotel As Short)
        InitializeComponent()
        noGest = _noGestionnaire
        hotel = _noHotel
    End Sub
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        bd = New P2014_Equipe2_GestionHôtelièreEntities
        Dim profGest = From el In bd.tblEmploye Where noGest = el.noEmpl Select el.codeProf
        Dim prof = profGest.Single.ToString()
        Dim res = From el In bd.tblEmploye Where el.codeProf = prof And el.noHotel = hotel Select el

        cbEmploye.DataContext = res.ToList()
    End Sub

    Private Sub btnRetour_Click(sender As Object, e As RoutedEventArgs) Handles btnRetour.Click
        Me.Focusable = False
        Me.Close()
    End Sub

    Private Sub windowAjoutHoraire_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles windowAjoutHoraire.Closing
        If Me.Focusable Then
            Me.Owner.Close()
        Else
            Me.Owner.Show()
        End If
    End Sub

    Private Sub btnAjouterHor_Click(sender As Object, e As RoutedEventArgs) Handles btnAjouterHor.Click
        Dim Horaire = New tblHoraire()
        Horaire.noEmpl = Convert.ToInt16(cbEmploye.SelectedItem.noEmpl)
        Horaire.dateHoraire = Format(cldHoraire.SelectedDate(), "yyyy/MM/dd")
        Horaire.heureDebut = Replace(cmbHeureFin.SelectedValue(), "h", ":")
    End Sub

    Private Sub tpDebut_ValueChanged(sender As Object, e As RoutedPropertyChangedEventArgs(Of Object)) Handles tpDebut.ValueChanged
        Dim temp As Integer
        'Dim Debut = tpDebut.Value()
        If Convert.ToInt16(Debut) > 15 Then
            temp = Convert.ToInt16(Debut) - 16
            'tpFin.SetCurrentValue()
        End If
        'cmbHeureFin.SelectedIndex = Debut + 8
    End Sub
End Class
