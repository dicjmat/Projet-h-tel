'------------------------------------------------------------------------------
' <auto-generated>
'     Ce code a été généré à partir d'un modèle.
'
'     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
'     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class tblCompagnie
    Public Property noCompagnie As Integer
    Public Property nomCompagnie As String
    Public Property noTelCompagnie As String
    Public Property noCellCompagnie As String
    Public Property adrCompagnie As String
    Public Property codeVille As String
    Public Property codeProv As String
    Public Property respCompagnie As String
    Public Property commentaire As String
    Public Property codePostalCompagnie As String

    Public Overridable Property tblVille As tblVille
    Public Overridable Property tblClient As ICollection(Of tblClient) = New HashSet(Of tblClient)
    Public Overridable Property tblDemandeur As ICollection(Of tblDemandeur) = New HashSet(Of tblDemandeur)

End Class
