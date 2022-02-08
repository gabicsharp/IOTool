using IOToolActiveDirectorySynchronization.DataAccess;
using IOToolActiveDirectorySynchronization.Tables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IOToolActiveDirectorySynchronization
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.StartProcess();
        }

        public void StartProcess()
        {
            DaAdGroups da = new DaAdGroups();
            ActiveDirectory ad = new ActiveDirectory();

            List<UsersModelAD> usersModelAd = new List<UsersModelAD>();  // users from AD
            List<UsersModelAD> usersModelAdTemporary = new List<UsersModelAD>();


            List<UsersModel> usersModelDB = new List<UsersModel>();  // users from DB

            usersModelDB = da.SelectAllUsers();

            var allAdGroups = da.SelectGroups();

            foreach (var item in allAdGroups)  //Add all users from AD To DB
            {
                ad.StartSearchInAd(item);
            }

            foreach (var item in allAdGroups)  //Populate users list from AD to compare
            {
                usersModelAdTemporary = ad.GetAllUsersFromAdGroups(item);
                foreach (var item2 in usersModelAdTemporary)
                {
                    usersModelAd.Add(new UsersModelAD(item2.Wa, item2.Group));
                }
            }

            foreach (var item in usersModelDB)  //Disabled users because they are not in AD groups
            {
                if (item.Active == 1)
                {
                    bool has = usersModelAd.Any(cus => cus.Wa == item.WindowsAccount);
                    if (has == false)
                    {
                        item.Active = 0;
                        da.UpdateUser(item);
                    }

                }
                else if (item.Active == 0)
                {

                }
            }

        }
    }
}