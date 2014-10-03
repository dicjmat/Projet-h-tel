Public Class iListeEmploye

    Private _noHotel As Short
    Dim maBd As P2014_Equipe2_GestionHôtelièreEntities
    Private _noEmpl As Short

    Sub New(noEmpl As Short, noHotel As Short)
        InitializeComponent()
        _noEmpl = noEmpl
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
        Dim prof = From el In maBd.tblEmploye Where el.noEmpl = _noEmpl Select el.codeProf
        Dim codeProff = prof.Single.ToString()
        Dim res = From el In maBd.tblEmploye Where el.noHotel = _noHotel And el.codeProf = codeProff Select el

        'el.noEmpl, el.nomEmpl, el.prenEmpl, el.codeProf
        lstEmploye.DataContext = res.ToList()

    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Focusable = False
        Me.Close()
    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        If Me.Focusable Then
            Me.Owner.Close()
        Else
            Me.Owner.Show()
        End If

    End Sub

    Private Sub txtNoEmp_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtNoEmp.TextChanged
        Dim res = From el In maBd.tblEmploye
                  Where el.noHotel = _noHotel And (el.noEmpl.ToString.StartsWith(txtNoEmp.Text) Or (el.nomEmpl + " " + el.prenEmpl).StartsWith(txtNoEmp.Text) Or (el.prenEmpl + " " + el.nomEmpl).StartsWith(txtNoEmp.Text) Or el.codeProf.StartsWith(txtNoEmp.Text))
                  Select el
        'el.noEmpl, el.nomEmpl, el.prenEmpl, el.codeProf
        lstEmploye.DataContext = res.ToList()
    End Sub

    Private Sub btnFaireHoraire_Click(sender As Object, e As RoutedEventArgs) Handles btnFaireHoraire.Click
        Dim Horaire = New iAjouterHoraire(_noEmpl)
        Horaire.Show()
        Me.Close()
    End Sub
End Class

