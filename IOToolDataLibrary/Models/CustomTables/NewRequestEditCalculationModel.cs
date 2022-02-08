using System;

namespace IOToolDataLibrary.Models.CustomTables
{
    public class NewRequestEditCalculationModel
    {
        public int Id { get; set; }
        public int IdFrom { get; set; }
        public int IdTo { get; set; }
        public int PalletNr { get; set; }
        public DateTime ETD { get; set; }
        public DateTime ETA { get; set; }

    }
}
