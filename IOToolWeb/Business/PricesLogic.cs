using Dapper;
using IOToolDataLibrary.Data;
using IOToolDataLibrary.Db;
using IOToolDataLibrary.Models;
using IOToolDataLibrary.Models.CustomTables;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace IOToolWeb.Business
{
    public class PriceLogic : IPriceLogic
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;
        private readonly ISuppliersData _suppliersData;
        private readonly IPricesData _priceData;

        public PriceLogic(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

      
    }
}
