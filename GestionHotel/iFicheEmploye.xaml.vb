Public Class iFicheEmploye
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Private Sub Grid_Loaded(sender As Object, e As RoutedEventArgs)
        bd = New P2014_Equipe2_GestionHôtelièreEntities
    End Sub
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim Employe = New tblEmploye
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
        bd.tblEmploye.Add(Employe)

        bd.SaveChanges()
    End Sub
End Class
