using IOToolActiveDirectorySynchronization.Tables;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Dapper;

namespace IOToolActiveDirectorySynchronization.DataAccess
{
    public class DaAdGroups
    {
		public List<AdGroupsModel> SelectGroups()
		{
			string sql = $"select * from AdGroups where Active like '1' order by Name asc";

			using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("localDB")))
			{
				return connection.Query<AdGroupsModel>(sql).ToList();
			}
			// throw new NotImplementedException();
		}

		public List<UsersModel> SelectCheckUserIfExist(string WindowsAccount)
		{
			string sql = $"select * from Users where WindowsAccount like '{WindowsAccount}'";

			using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("localDB")))
			{
				return connection.Query<UsersModel>(sql).ToList();
			}
			// throw new NotImplementedException();
		}

		public List<UsersModel> SelectAllUsers()
		{
			string sql = $"select * from Users";

			using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("localDB")))
			{
				return connection.Query<UsersModel>(sql).ToList();
			}
			// throw new NotImplementedException();
		}

		public void InsertNewUser(UsersModel obj)
		{
			using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("localDB")))
			{
				connection.Execute("dbo.spUsers_Insert @Name, " +
													  "@Function, " +
													  "@Department, " +
													  "@Location, " +
													  "@CostCenter, " +
													  "@Email, " +
													  "@WindowsAccount, " +
													  "@AccountRights, " +
													  "@Active"	, obj);
			}
		}

		public void UpdateUser(UsersModel obj)
		{
			using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("localDB")))
			{
				connection.Execute("dbo.spUsers_Update @Id, " +
													  "@Name, " +
													  "@Function, " +
													  "@Department, " +
													  "@Location, " +
													  "@CostCenter, " +
													  "@Email, " +
													  "@WindowsAccount, " +
													  "@AccountRights, " +
													  "@Active", obj);
			}
		}
	}
}
