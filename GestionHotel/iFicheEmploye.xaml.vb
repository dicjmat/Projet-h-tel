Public Class iFicheEmploye
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Private Sub windowFicheEmploye_Loaded(sender As Object, e As RoutedEventArgs) Handles windowFicheEmploye.Loaded
        bd = New P2014_Equipe2_GestionHôtelièreEntities()
    End Sub
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim Employe = New tblEmploye()
        Employe.noEmpl = txtRNoClient.Text
        Employe.nomEmpl = txtNomEmp.Text
        Employe.prenEmpl = txtPrenomEmp.Text
        Employe.noTelEmpl = txtTellEmp.Text
        Employe.noCellEmpl = txtCellEmp.Text
        Employe.adrEmpl = txtAdrEmp.Text
        Employe.NAS = txtNASEmp.Text
        Employe.dateEmbauche = DPEmbaucheEmp.Text
        Employe.hrtravail = txtHrsEmp.Text
        Employe.salaire = txtSalaireEmp.Text
        Employe.joursVac = txtVacEmp.Text
        Employe.joursFerie = txtFerieEmp.Text
        Employe.joursMal = txtMaladieEmp.Text
        Employe.codeVille = txtCdVille.Text
        Employe.codeProf = txtNoHot.Text
        Employe.noHotel = txtCdProf.Text
        bd.tblEmploye.Add(Employe)
        bd.SaveChanges()
        MessageBox.Show("L'employé a été créé avec succès.")
    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        If Me.Focusable Then
            Me.Owner.Close()
        Else
            Me.Owner.Show()
        End If

    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Focusable = False
        windowFicheEmploye.Close()
        Me.Owner.Focusable = False
        Me.Owner.Close()
        'Dim listeemploye As iListeEmploye
        'listeemploye = New iListeEmploye()
        'listeemploye.Close()
    End Sub
    Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        Me.Focusable = False
        windowFicheEmploye.Close()
    End Sub
End Class
