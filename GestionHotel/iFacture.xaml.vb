Public Class iFacture
    Dim bd As P2014_Equipe2_GestionHôtelièreEntities
    Dim noEmp As Integer
    Dim noHotel As Integer
    Dim noReserv As Integer
    Dim note As tblNote

    Sub New(maBD As P2014_Equipe2_GestionHôtelièreEntities, _noEmp As Integer, _noHotel As Integer)
        InitializeComponent()
        noEmp = _noEmp
        noHotel = _noHotel
        bd = maBD
    End Sub

    Sub New(maBD As P2014_Equipe2_GestionHôtelièreEntities, _noEmp As Integer, _noHotel As Integer, _noReservation As Integer)
        InitializeComponent()
        noEmp = _noEmp
        noHotel = _noHotel
        bd = maBD
        noReserv = _noReservation
    End Sub
    Private Sub btnAccueil_Click(sender As Object, e As RoutedEventArgs) Handles btnAccueil.Click
        Me.Owner.Hide()
        Me.Owner.Show()
        Me.Close()
    End Sub

    Private Sub window_Facture_Loaded(sender As Object, e As RoutedEventArgs) Handles window_Facture.Loaded
        If noReserv <> Nothing Then
            note = (From el In bd.tblNote Where el.noReservation = noReserv Select el).First
            window_Facture.DataContext = note
            dgEleFacture.ItemsSource = (From el In bd.tblElementNote Where el.noNote = note.noNote Select el).ToList()

            Dim elem = From el In bd.tblTypeElement Select el
            dgDescFact.ItemsSource = elem.ToList()
        End If
    End Sub

    Private Sub btnAjout_Click(sender As Object, e As RoutedEventArgs) Handles btnAjout.Click
        If dgDescFact.SelectedItem IsNot Nothing And txtMontant.Text <> "" Then
            Dim elemNote = New tblElementNote()
            elemNote.codeTypeElement = dgDescFact.SelectedItem.codeTypeElement
            elemNote.dateAjoutElem = Format(Date.Today(), "yyyy-MM-dd")
            elemNote.montantElement = txtMontant.Text
            elemNote.noNote = Convert.ToInt16(txtNoFact.Text)
            If note.tblElementNote.Count <> 0 Then
                elemNote.noLigne = note.tblElementNote.Last.noLigne + 1
            Else
                elemNote.noLigne = 1
            End If
            bd.tblElementNote.Add(elemNote)
            bd.SaveChanges()
            dgEleFacture.ItemsSource = (From el In bd.tblElementNote Where el.noNote = note.noNote Select el).ToList()
        End If
    End Sub

    Private Sub dgDescFact_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dgDescFact.SelectionChanged
        If dgDescFact.SelectedItem.codeTypeElement = "NUI" Then
            Dim today = Date.Now()
            Dim res = From pe In bd.tblPeriode
                      Join pts In bd.tblPeriodeTypeSalle On pe.codePeriode Equals pts.codePeriode
                      Join tsh In bd.tblTypeSalleHotel On pts.codeTypeSalle Equals tsh.codeTypeSalle And pts.noHotel Equals tsh.noHotel
                      Join ts In bd.tblTypeSalle On tsh.codeTypeSalle Equals ts.codeTypeSalle
                      Join sa In bd.tblSalle On ts.codeTypeSalle Equals sa.codeTypeSalle
                      Join re In bd.tblReservation On sa.noSalle Equals re.noSalle And sa.noHotel Equals re.noHotel
                      Where re.noReservation = noReserv And tsh.noHotel = noHotel And pe.dateDebutPeriode <= today And pe.dateFinPeriode >= today
                      Select pts.prixSallePeriode
            If res.ToList.Count = 0 Then
                Dim prix = From tsh In bd.tblTypeSalleHotel
                           Join ts In bd.tblTypeSalle On tsh.codeTypeSalle Equals ts.codeTypeSalle
                           Join sa In bd.tblSalle On ts.codeTypeSalle Equals sa.codeTypeSalle
                           Join re In bd.tblReservation On sa.noSalle Equals re.noSalle And sa.noHotel Equals re.noHotel
                           Where re.noReservation = noReserv And tsh.noHotel = noHotel
                           Select tsh.prixSalle

                txtMontant.Text = prix.First.ToString()
            Else
                txtMontant.Text = res.First.ToString()
            End If

        End If
    End Sub
    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim check = New iCheck_in_out(bd, noEmp, noHotel)
        check.Owner = Me
        check.Show()
    End Sub

    Private Sub MenuItem_Click_1(sender As Object, e As RoutedEventArgs)
        Dim facture = New iFacture(bd, noEmp, noHotel)
        facture.Owner = Me
        facture.Show()
    End Sub

    Private Sub MenuItem_Click_2(sender As Object, e As RoutedEventArgs)
        Dim lst = New iListeClient
        lst.Owner = Me
        lst.Show()
    End Sub

    Private Sub MenuItem_Click_3(sender As Object, e As RoutedEventArgs)
        Dim reserv = New iFaireReservationChambre(bd, noEmp, noHotel)
        reserv.Owner = Me
        reserv.Show()
    End Sub

    Private Sub MenuItem_Click_4(sender As Object, e As RoutedEventArgs)
        Dim ficheR = New iFicheReserv(bd, noEmp, noHotel)
        ficheR.Owner = Me
        ficheR.Show()
    End Sub

    Private Sub MenuItem_Click_5(sender As Object, e As RoutedEventArgs)
        Dim ficheRF = New iFicheReservFacture(bd, noEmp, noHotel)
        ficheRF.Owner = Me
        ficheRF.Show()
    End Sub

    Private Sub MenuItem_Click_6(sender As Object, e As RoutedEventArgs)
        Dim Cli = New iAjoutCliReserv(noEmp, noHotel, bd)
        Cli.Owner = Me
        Cli.Show()
    End Sub
End Class
