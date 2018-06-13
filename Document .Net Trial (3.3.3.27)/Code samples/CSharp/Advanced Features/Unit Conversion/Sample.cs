using System;
using SautinSoft.Document;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            ConvertPointsTo();
            UsingUnitConversion();
        }

        public static void ConvertPointsTo()
        {
            foreach (LengthUnit unit in Enum.GetValues(typeof(LengthUnit)))
            {
                string s = string.Format("1 point = {0} {1}",
                    LengthUnitConverter.Convert(1, LengthUnit.Point, unit),
                    unit.ToString().ToLowerInvariant());

                Console.WriteLine(s);
            }
            Console.ReadLine();
        }

        public static void UsingUnitConversion()
        {
            DocumentCore dc = new DocumentCore();
            // Add new section.
            Section sectFirst = new Section(dc);
            sectFirst.PageSetup.PageMargins = new PageMargins()
            {
                Top = LengthUnitConverter.Convert(50, LengthUnit.Millimeter, LengthUnit.Point),
                Right = LengthUnitConverter.Convert(1, LengthUnit.Inch, LengthUnit.Point),
                Bottom = LengthUnitConverter.Convert(10, LengthUnit.Millimeter, LengthUnit.Point),
                Left = LengthUnitConverter.Convert(2, LengthUnit.Centimeter, LengthUnit.Point)
            };
        }
    }
}