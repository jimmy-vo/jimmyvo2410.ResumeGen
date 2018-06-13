Imports SautinSoft.Document

Module ExampleVB
    Sub Main()
        ConvertPointsTo()
        UsingUnitConversion()
    End Sub

    Public Sub ConvertPointsTo()
        For Each unit As LengthUnit In System.Enum.GetValues(GetType(LengthUnit))
            Dim s As String = String.Format("1 point = {0} {1}", LengthUnitConverter.Convert(1, LengthUnit.Point, unit), unit.ToString().ToLowerInvariant())
            Console.WriteLine(s)
        Next unit
        Console.ReadLine()
    End Sub

    Public Sub UsingUnitConversion()
        Dim dc As New DocumentCore()
        ' Add new section.
        Dim sectFirst As New Section(dc)
        sectFirst.PageSetup.PageMargins = New PageMargins() With {
                .Top = LengthUnitConverter.Convert(50, LengthUnit.Millimeter, LengthUnit.Point),
                .Right = LengthUnitConverter.Convert(1, LengthUnit.Inch, LengthUnit.Point),
                .Bottom = LengthUnitConverter.Convert(10, LengthUnit.Millimeter, LengthUnit.Point),
                .Left = LengthUnitConverter.Convert(2, LengthUnit.Centimeter, LengthUnit.Point)
            }
    End Sub
End Module