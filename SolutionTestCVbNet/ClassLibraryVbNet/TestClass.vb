Imports System.Data

Public Class TestClass
    Sub prueba(ByRef cad As String)
        cad = "se da garra"
    End Sub

    Function BuscaPregunta(question As String, dt As DataTable) As DataRow
        Dim row As DataRow
        row = dt.Select("Pregunta = '" + question + "' ").FirstOrDefault

        Return row
    End Function

End Class
