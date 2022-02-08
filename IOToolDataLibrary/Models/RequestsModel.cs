using System;

namespace IOToolDataLibrary.Models
{
    public class RequestsModel
    {
        public int Id { get; set; }
        public string Month { get; set; }
        public int Id_RequestType { get; set; }
        public int Id_TransportType { get; set; }
        public int Week { get; set; }
        public DateTime ETD { get; set; }
        public DateTime ETA { get; set; }
        public int Id_SupplierFrom { get; set; }
        public int Id_SupplierTo { get; set; }
        public int Id_Material { get; set; }
        public int Id_Transporter { get; set; }
        public string AWB { get; set; }
        public decimal Price { get; set; }
        public int Id_CostCenter { get; set; }
        public string BillNr { get; set; }
        public int PalletNr { get; set; }
        public decimal PricePallet { get; set; }
        public int Weight { get; set; }
    }
}
