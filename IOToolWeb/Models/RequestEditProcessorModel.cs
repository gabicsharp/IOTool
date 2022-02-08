using System.Collections.Generic;

namespace IOToolWeb.Models
{
    public class RequestEditProcessorModel
    {
        public class ViewModel
        {
            public IOToolDataLibrary.Models.CustomTables.NewRequestEditModel RequestDetails { get; set; }
            public List<IOToolDataLibrary.Models.TransportersModel> Transporters { get; set; }
            public List<IOToolDataLibrary.Models.TransportTypesModel> TransportTypes { get; set; }
            public List<IOToolDataLibrary.Models.MaterialsModel> Materials { get; set; }
        }
    }
}
