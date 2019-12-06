Imports System.Data

Public Class TestClass
    Sub prueba(ByRef cad As String)
        cad = "se da garra"
    End Sub

    Function BuscaPregunta(question As String, dt As DataTable) As DataRow
        Dim row As DataRow
        Dim existe As Boolean
        Dim respuesta As String

        row = dt.Select("Pregunta = '" + question + "' ").FirstOrDefault
        If row Is Nothing Then
            existe = False
            respuesta = ""
        Else
            existe = True
            respuesta = row("Respuesta")
        End If
        Return row
    End Function

End Class
