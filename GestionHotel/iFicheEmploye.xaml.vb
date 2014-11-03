Public Class iFicheEmploye
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Private numEmpl As Integer
    Private noGest As Short
    Private hotel As Short


    Sub New(noEmpl As Short, noHotel As Short, _numEmpl As Integer, _bd As P2014_Equipe2_GestionHôtelièreEntities)
        InitializeComponent()
        numEmpl = _numEmpl
        bd = _bd
        noGest = noEmpl
        hotel = noHotel
    End Sub

    Sub New(_bd As P2014_Equipe2_GestionHôtelièreEntities)
        InitializeComponent()
        bd = _bd
    End Sub

    Private Sub windowFicheEmploye_Loaded(sender As Object, e As RoutedEventArgs) Handles windowFicheEmploye.Loaded
        Dim ville = From el In bd.tblVille Select el
        Dim hotel = From el In bd.tblHotel Select el
        Dim profession = From el In bd.tblProfession Select el

        cmbCdVille.DataContext = ville.ToList()
        cmbNoHot.DataContext = hotel.ToList()
        cmbCdProf.DataContext = profession.ToList()
        If numEmpl <> 0 Then
            Dim res = From el In bd.tblEmploye Where el.noEmpl = numEmpl Select el
            Me.DataContext = res.ToList()
            Dim i = 0
            For Each el In cmbCdVille.DataContext
                If el.codeVille = res.First.codeVille Then
                    cmbCdVille.SelectedIndex = i
                    Exit For
                End If
                i = i + 1
            Next
            i = 0
            For Each el In cmbNoHot.DataContext
                If el.noHotel = res.First.noHotel Then
                    cmbNoHot.SelectedIndex = i
                    Exit For
                End If
                i = i + 1
            Next
            i = 0
            For Each el In cmbCdProf.DataContext
                If el.codeProf = res.First.codeProf Then
                    cmbCdProf.SelectedIndex = i
                    Exit For
                End If
                i = i + 1
            Next
        End If
    End Sub
    Private Sub btnCreer_Click(sender As Object, e As RoutedEventArgs)
        Dim Employe = New tblEmploye()
        If txtNomEmp.Text = "" Or txtPrenomEmp.Text = "" Or txtTellEmp.Text = "" Or txtAdrEmp.Text = "" Or txtNASEmp.Text = "" Or txtSalaireEmp.Text = "" Then
            Employe.nomEmpl = txtNomEmp.Text
            Employe.prenEmpl = txtPrenomEmp.Text
            Employe.noTelEmpl = txtTellEmp.Text

            If txtCellEmp.Text <> "   -   -    " Then
                Employe.noCellEmpl = txtCellEmp.Text
            End If

            Employe.adrEmpl = txtAdrEmp.Text
            Employe.NAS = txtNASEmp.Text
            Employe.dateEmbauche = DPEmbaucheEmp.Text

            If txtHrsEmp.Text <> "" Then
                Employe.hrtravail = txtHrsEmp.Text
            End If

            If txtVacEmp.Text <> "" Then
                Employe.joursVac = txtVacEmp.Text
            End If

            If txtFerieEmp.Text <> "" Then
                Employe.joursFerie = txtFerieEmp.Text
            End If

            If txtMaladieEmp.Text <> "" Then
                Employe.joursMal = txtMaladieEmp.Text
            End If

            Employe.salaire = txtSalaireEmp.Text
            If cmbCdVille.SelectedIndex <> -1 Then
                Employe.codeVille = cmbCdVille.SelectedItem.codeVille
                If cmbCdProf.SelectedIndex <> -1 Then
                    Employe.codeProf = cmbCdProf.SelectedItem.codeProf
                    If cmbNoHot.SelectedIndex <> -1 Then
                        Employe.noHotel = cmbNoHot.SelectedItem.noHotel
                        bd.tblEmploye.Add(Employe)
                        bd.SaveChanges()
                    Else
                        MessageBox.Show("Veuillez choisir un hôtel")
                    End If

                Else
                    MessageBox.Show("Veuillez choisir une profession")
                End If
            Else
                MessageBox.Show("Veuillez choisir une ville")
            End If
            MessageBox.Show("L'employé a été créé avec succès.")
        Else
            MessageBox.Show("Un des champs obligatoires n'a pas été rempli")
        End If


    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Me.Owner.Show()
    End Sub

    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Dim lol = txtCellEmp.Text
        Me.Owner.Close()
        Me.Close()
        'Dim listeemploye As iListeEmploye
        'listeemploye = New iListeEmploye()
        'listeemploye.Close()
    End Sub
    Private Sub btnAnnuler_Click(sender As Object, e As RoutedEventArgs)
        windowFicheEmploye.Close()
    End Sub

    Private Sub btnAjoutHoraire_Click(sender As Object, e As RoutedEventArgs) Handles btnAjoutHoraire.Click
        Dim Horaire = New iAjouterHoraire(numEmpl, bd)
        Horaire.Owner = Me
        Horaire.Show()
        Me.Hide()
    End Sub

    Private Sub btnListeEmpGest_Click(sender As Object, e As RoutedEventArgs) Handles btnListeEmpGest.Click
        Dim lst = New iListeEmploye(noGest, hotel, bd)
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub btnListeCommandeGest_Click(sender As Object, e As RoutedEventArgs) Handles btnListeCommandeGest.Click
        Dim lst = New iListeCOmmande(noGest, hotel, bd)
        lst.Owner = Me
        lst.Show()
    End Sub

End Class
