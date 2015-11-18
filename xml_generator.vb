Imports System.Xml.Serialization
Imports System.Xml
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO

Public Enum BulgarianCities
    Sofia
    Plovdiv
    Varna
    Rousse
End Enum

<Serializable>
Public Class GradesAtSchool
    Public DateAndTime As Date
    Public Grade As Double
    Public Name As String
    Public UniversityEducation As Boolean
    Public City As String
End Class

Module Module1
    Public Function generate_name(l_seed As Long) As String
        Dim grandom As New Random(l_seed)

        Dim l_counter As Long
        Dim s_result As String

        Dim l As Long = grandom.Next(3, 10)

        For l_counter = 0 To l
            s_result &= CStr(Chr(grandom.Next(70, 90)))
        Next

        generate_name = s_result

    End Function

    Sub Main()

        Dim values As New List(Of GradesAtSchool)()
        Dim random As New Random()

        For l_counter As Long = 0 To 25
            Dim my_unit As New GradesAtSchool()
            my_unit.DateAndTime = Date.Now
            my_unit.Grade = random.Next(2, 6)
            my_unit.Name = generate_name(l_counter * 10)
            my_unit.UniversityEducation = l_counter Mod 2 = 0

            Select Case l_counter Mod 4
                Case 0
                    my_unit.City = BulgarianCities.Sofia
                Case 1
                    my_unit.City = BulgarianCities.Plovdiv
                Case 2
                    my_unit.City = BulgarianCities.Varna
                Case 3
                    my_unit.City = BulgarianCities.Rousse
            End Select

            values.Add(my_unit)
        Next l_counter

        Dim settings As New XmlWriterSettings()

        settings.Indent = True
        Dim ser As New XmlSerializer(GetType(List(Of GradesAtSchool)))
        Dim writer As XmlWriter = XmlWriter.Create("C:\Users\Gro\Desktop\sample.xml", settings)

        ser.Serialize(writer, values)
        writer.Close()

    End Sub
End Module
