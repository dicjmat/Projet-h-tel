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

Partial Public Class tblForfait
    Public Property noForfait As Byte
    Public Property nomForfait As String
    Public Property descForfait As String
    Public Property nbNuitForfait As Byte
    Public Property etatForfait As String
    Public Property prixForfait As Decimal
    Public Property noHotel As Byte
    Public Property codeTypeSalle As String

    Public Overridable Property tblHotel As tblHotel
    Public Overridable Property tblTypeSalle As tblTypeSalle
    Public Overridable Property tblReservation As ICollection(Of tblReservation) = New HashSet(Of tblReservation)

End Class
