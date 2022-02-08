using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleImportExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            ImportCitiesAndCountries();
        }
        public static void ImportCitiesAndCountries()
        {
            string fileName = @"c:\\worldcities.xlsx";

            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (SpreadsheetDocument doc = SpreadsheetDocument.Open(fs, true))
                {
                    WorkbookPart workbookPart = doc.WorkbookPart;
                    SharedStringTablePart sstpart = workbookPart.GetPartsOfType<SharedStringTablePart>().First();
                    SharedStringTable sst = sstpart.SharedStringTable;

                    WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                    Worksheet sheet = worksheetPart.Worksheet;

                    var cells = sheet.Descendants<Cell>();
                    var rows = sheet.Descendants<Row>();

                    int CountRows = rows.Count();

                    Console.WriteLine("Row count = {0}", rows.LongCount());
                    Console.WriteLine("Cell count = {0}", cells.LongCount());

                    string[] Columns_Excel = new string[3];
                    Columns_Excel[0] = "A"; //City
                    Columns_Excel[1] = "B"; //Country
                    Columns_Excel[2] = "C"; //Country Code iso2

                    string CityString = "", CountryString = "", CountryCodeString = "";

                    for (uint i = 2; i <= CountRows; i++) // Rows
                    {
                        for (int j = 1; j <= Columns_Excel.Length; j++)  // Columns
                        {
                            Cell cell = GetCell(sheet, Columns_Excel[j - 1], i);

                            // Console.WriteLine(i);

                            if (Columns_Excel[j - 1] == "A")
                            {
                                int ssid = int.Parse(cell.CellValue.Text);
                                string str = sst.ChildElements[ssid].InnerText;
                                CityString = str;
                                Console.WriteLine(CityString);
                            }
                            else if (Columns_Excel[j - 1] == "B")
                            {
                                int ssid = int.Parse(cell.CellValue.Text);
                                string str = sst.ChildElements[ssid].InnerText;
                                CountryString = str;
                                Console.WriteLine(CountryString);
                            }
                            else if (Columns_Excel[j - 1] == "C")
                            {
                                int ssid = int.Parse(cell.CellValue.Text);
                                string str = sst.ChildElements[ssid].InnerText;
                                CountryCodeString = str;
                                Console.WriteLine(CountryCodeString);

                                DataClasses1DataContext dbo = new DataClasses1DataContext();

                                var city = (from y in dbo.Cities
                                            where y.Name == CityString
                                            select y).FirstOrDefault();

                                var country = (from y in dbo.Countries
                                               where y.Name == CountryString
                                               select y).FirstOrDefault();

                                if (city == null)
                                {
                                    if (country == null)
                                    {
                                        Country co = new Country
                                        {
                                            Name = CountryString,
                                            Code = CountryCodeString,
                                            Active = 1
                                        };
                                        dbo.Countries.InsertOnSubmit(co);
                                        dbo.SubmitChanges();
                                        City ci = new City { 
                                            Name = CityString,
                                            Id_Country = co.Id,
                                            Active = 1
                                        };
                                        dbo.Cities.InsertOnSubmit(ci);
                                        dbo.SubmitChanges();
                                        Console.WriteLine($"City: {CityString} & Country: {CountryString}");
                                    }
                                    else if (country != null)
                                    {
                                        City ci = new City
                                        {
                                            Name = CityString,
                                            Id_Country = country.Id,
                                            Active = 1
                                        };
                                        dbo.Cities.InsertOnSubmit(ci);
                                        dbo.SubmitChanges();
                                        Console.WriteLine($"City: {CityString}");

                                    }
                                }
                            }
                        }
                    }
                    sheet.Save();
                }
            }
        }
        private static Cell GetCell(Worksheet worksheet, string columnName, uint rowIndex)
        {
            Row row = GetRow(worksheet, rowIndex);

            if (row == null)
                return null;

            return row.Elements<Cell>().Where(c => string.Compare
                      (c.CellReference.Value, columnName +
                      rowIndex, true) == 0).First();
        }

        private static Row GetRow(Worksheet worksheet, uint rowIndex)
        {
            return worksheet.GetFirstChild<SheetData>().
                  Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
        }
    }
}
