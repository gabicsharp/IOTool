using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ConsoleImportExcelPrices
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = "Jászárokszállás";

            string input = "Jászárokszállás";
            StringBuilder output = new StringBuilder(input.Length);

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '&')
                {
                    int startOfEntity = i; // just for easier reading
                    int endOfEntity = input.IndexOf(';', startOfEntity);
                    string entity = input.Substring(startOfEntity, endOfEntity - startOfEntity);
                    int unicodeNumber = (int)(HttpUtility.HtmlDecode(entity)[0]);
                    output.Append("&#" + unicodeNumber + ";");
                    i = endOfEntity; // continue parsing after the end of the entity
                }
                else
                    output.Append(input[i]);
            }
            Console.Write(output);
            // ImportPrices();
        }
        public static void ImportPrices()
        {
            string fileName = @"c:\\Prices.xlsx";

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

                    string[] Columns_Excel = new string[41];
                    Columns_Excel[0] = "A"; //LaneID
                    Columns_Excel[1] = "B"; //LaneName
                    Columns_Excel[2] = "C"; //OriginCountry
                    Columns_Excel[3] = "D"; //OriginCity
                    Columns_Excel[4] = "E"; //OriginZip
                    Columns_Excel[5] = "F"; //DestinationCountry
                    Columns_Excel[6] = "G"; //DestinationCity
                    Columns_Excel[7] = "H"; //DestinationZip
                    Columns_Excel[8] = "I"; //Direction
                    Columns_Excel[9] = "J"; //PartnerLocation
                    Columns_Excel[10] = "K"; //Minimum
                    Columns_Excel[11] = "L"; //1-4 pallet INCLUSIVE
                    Columns_Excel[12] = "M"; //5-8 pallet INCLUSIVE
                    Columns_Excel[13] = "N"; //9-12 pallet INCLUSIVE
                    Columns_Excel[14] = "O"; //13-16 pallet INCLUSIVE
                    Columns_Excel[15] = "P"; //17-20 pallet INCLUSIVE
                    Columns_Excel[16] = "Q"; //21-24 pallet INCLUSIVE
                    Columns_Excel[17] = "R"; //25-28 pallet INCLUSIVE
                    Columns_Excel[18] = "S"; //29-32 pallet INCLUSIVE
                    Columns_Excel[19] = "T"; //33-36 pallet INCLUSIVE
                    Columns_Excel[20] = "U"; //37-40 pallet INCLUSIVE
                    Columns_Excel[21] = "V"; //41-44 pallet INCLUSIVE
                    Columns_Excel[22] = "W"; //45-48 pallet INCLUSIVE
                    Columns_Excel[23] = "X"; //49-52 pallet INCLUSIVE
                    Columns_Excel[24] = "Y"; //53-56 pallet INCLUSIVE
                    Columns_Excel[25] = "Z"; //57-60 pallet INCLUSIVE
                    Columns_Excel[26] = "AA"; //61-64 pallet INCLUSIVE
                    Columns_Excel[27] = "AB"; //Maximum
                    Columns_Excel[28] = "AC"; //Shipment Frequency  LTL
                    Columns_Excel[29] = "AD"; //Transit Time Groupage
                    Columns_Excel[30] = "AE"; //Transit Time LTL
                    Columns_Excel[31] = "AF"; //Comments LTL
                    Columns_Excel[32] = "AG"; //3,5 tons
                    Columns_Excel[33] = "AH"; //Transit Time 3,5 t
                    Columns_Excel[34] = "AI"; //Shipment Frequency 3,5 tons
                    Columns_Excel[35] = "AJ"; //7,5 tons
                    Columns_Excel[36] = "AK"; //Shipment Frequency 7,5 tons
                    Columns_Excel[37] = "AL"; //24 tons
                    Columns_Excel[38] = "AM"; //Shipment Frequency  24 tons
                    Columns_Excel[39] = "AN"; //Transit Time FTL
                    Columns_Excel[40] = "AO"; //Comments FTL




                    string CityString = "", CountryString = "", CountryCodeString = "";

                    for (uint i = 2; i <= CountRows; i++) // Rows
                    {
                        for (int j = 0; j < Columns_Excel.Length; j++)  // Columns
                        {
                            Cell cell = GetCell(sheet, Columns_Excel[j], i);

                            if (Columns_Excel[j] == "A")
                            {
                                int ssid = int.Parse(cell.CellValue.Text);
                                string str = sst.ChildElements[ssid].InnerText;
                                Console.WriteLine(ssid);
                            }
                            else if (Columns_Excel[j] == "B")
                            {
                                int ssid = int.Parse(cell.CellValue.Text);
                                string str = sst.ChildElements[ssid].InnerText;
                                Console.WriteLine(str);
                            }
                            else if (Columns_Excel[j] == "C")
                            {
                                int ssid = int.Parse(cell.CellValue.Text);
                                string str = sst.ChildElements[ssid].InnerText;
                                Console.WriteLine(str);
                            }
                            else if (Columns_Excel[j] == "D")
                            {
                                int ssid = int.Parse(cell.CellValue.Text);
                                string str = sst.ChildElements[ssid].InnerText;
                                Console.WriteLine(str);
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
