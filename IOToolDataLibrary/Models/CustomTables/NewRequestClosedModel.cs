using System;
using System.ComponentModel;

namespace IOToolDataLibrary.Models.CustomTables
{
    public class NewRequestClosedModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Month")]
        public string Month { get; set; }

        [DisplayName("Import")]
        public string RequestType { get; set; }

        [DisplayName("Type")]
        public string TransportType { get; set; }

        [DisplayName("Week")]
        public int Week { get; set; }

        [DisplayName("ETD")]
        public DateTime ETD { get; set; }

        [DisplayName("ETA")]
        public DateTime ETA { get; set; }

        [DisplayName("From")]
        public string From { get; set; }

        [DisplayName("Location")]
        public string FromLocation { get; set; }

        [DisplayName("To")]
        public string To { get; set; }

        [DisplayName("Delivery location")]
        public string ToLocation { get; set; }

        [DisplayName("Materials")]
        public string Materials { get; set; }

        [DisplayName("Forwarder")]
        public string Transporter { get; set; }

        [DisplayName("AWB")]
        public string AWB { get; set; }

        [DisplayName("Price")]
        public int Price { get; set; }

        [DisplayName("Cost center")]
        public string CostCenter { get; set; }

        [DisplayName("Bill Nr.")]
        public string BillNr { get; set; }

        [DisplayName("# pallet no.")]
        public int PalletNr { get; set; }

        [DisplayName("Price per pallet")]
        public int PricePallet { get; set; }
    }
}
