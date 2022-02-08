using IOToolActiveDirectorySynchronization.DataAccess;
using IOToolActiveDirectorySynchronization.Tables;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace IOToolActiveDirectorySynchronization
{
    public class ActiveDirectory
    {
        public void StartSearchInAd(AdGroupsModel adGroupModel)
        {
            using (var context = new PrincipalContext(ContextType.Domain, adGroupModel.FullDomain))
            {
                using (var group = GroupPrincipal.FindByIdentity(context, adGroupModel.Name))
                {
                    if (group != null)
                    {
                        var users = group.GetMembers(true);
                        foreach (UserPrincipal user in users)
                        {
                            DirectoryEntry de = user.GetUnderlyingObject() as DirectoryEntry;
                            DaAdGroups da = new DaAdGroups();
                            var userExist = da.SelectCheckUserIfExist(user.SamAccountName);
                            if (userExist.Count == 0)  // User is NOT in DB
                            {
                                UsersModel userModel = new UsersModel();
                                if (de.Properties["sAMAccountName"].Value != null)
                                {
                                    userModel.WindowsAccount = de.Properties["sAMAccountName"].Value.ToString();

                                    if (user.DisplayName.Length > 5)
                                    {
                                        userModel.Name = user.DisplayName.Replace(",", "");
                                    }
                                    else
                                    {
                                        userModel.Name = "unknown";
                                    }

                                    if (de.Properties["title"].Value != null)
                                    {
                                        userModel.Function = de.Properties["title"].Value.ToString();
                                    }
                                    else
                                    {
                                        userModel.Function = "unknown";
                                    }

                                    if (de.Properties["department"].Value != null)
                                    {
                                        userModel.Department = de.Properties["department"].Value.ToString();
                                    }
                                    else
                                    {
                                        userModel.Department = "unknown";
                                    }

                                    if (de.Properties["global-ExtensionAttribute22"].Value != null)
                                    {
                                        userModel.Location = de.Properties["global-ExtensionAttribute22"].Value.ToString();
                                    }
                                    else
                                    {
                                        userModel.Location = "unknown";
                                    }

                                    if (de.Properties["global-ExtensionAttribute2"].Value != null)
                                    {
                                        userModel.CostCenter = de.Properties["global-ExtensionAttribute2"].Value.ToString();
                                    }
                                    else
                                    {
                                        userModel.CostCenter = "unknown";
                                    }

                                    if (de.Properties["mail"].Value != null)
                                    {
                                        userModel.Email = de.Properties["mail"].Value.ToString();
                                    }
                                    else
                                    {
                                        userModel.Email = "unknown";
                                    }

                                    userModel.AccountRights = adGroupModel.RightsName;
                                    userModel.Active = 1;
                                    da.InsertNewUser(userModel);
                                }
                            }
                            else if (userExist.Count == 1) // User IS in DB
                            {
                                UsersModel userModel = new UsersModel();

                                foreach (var item2 in userExist)
                                {
                                    userModel.Id = item2.Id;
                                    break;
                                }

                                if (de.Properties["sAMAccountName"].Value != null)
                                {
                                    userModel.WindowsAccount = de.Properties["sAMAccountName"].Value.ToString();

                                    if (user.DisplayName.Length > 5)
                                    {
                                        userModel.Name = user.DisplayName.Replace(",", "");
                                    }
                                    else
                                    {
                                        userModel.Name = "unknown";
                                    }

                                    if (de.Properties["title"].Value != null)
                                    {
                                        userModel.Function = de.Properties["title"].Value.ToString();
                                    }
                                    else
                                    {
                                        userModel.Function = "unknown";
                                    }

                                    if (de.Properties["department"].Value != null)
                                    {
                                        userModel.Department = de.Properties["department"].Value.ToString();
                                    }
                                    else
                                    {
                                        userModel.Department = "unknown";
                                    }

                                    if (de.Properties["global-ExtensionAttribute22"].Value != null)
                                    {
                                        userModel.Location = de.Properties["global-ExtensionAttribute22"].Value.ToString();
                                    }
                                    else
                                    {
                                        userModel.Location = "unknown";
                                    }

                                    if (de.Properties["global-ExtensionAttribute2"].Value != null)
                                    {
                                        userModel.CostCenter = de.Properties["global-ExtensionAttribute2"].Value.ToString();
                                    }
                                    else
                                    {
                                        userModel.CostCenter = "unknown";
                                    }

                                    if (de.Properties["mail"].Value != null)
                                    {
                                        userModel.Email = de.Properties["mail"].Value.ToString();
                                    }
                                    else
                                    {
                                        userModel.Email = "unknown";
                                    }

                                    userModel.AccountRights = adGroupModel.RightsName;
                                    userModel.Active = 1;
                                    da.UpdateUser(userModel);
                                }
                            }
                        }
                    }
                }
            }
        }

        public List<UsersModelAD> GetAllUsersFromAdGroups(AdGroupsModel adGroupModel)
        {
            List<UsersModelAD> usersModel = new List<UsersModelAD>();

            using (var context = new PrincipalContext(ContextType.Domain, adGroupModel.FullDomain))
            {
                using (var group = GroupPrincipal.FindByIdentity(context, adGroupModel.Name))
                {
                    if (group == null)
                    {
                        //Group does not exist
                    }
                    else
                    {
                        var users = group.GetMembers(true);
                        foreach (UserPrincipal user in users)
                        {
                            DirectoryEntry de = user.GetUnderlyingObject() as DirectoryEntry;
                            if (de.Properties["sAMAccountName"].Value != null)
                            {
                                string WindowsAccount = de.Properties["sAMAccountName"].Value.ToString();
                                usersModel.Add(new UsersModelAD(WindowsAccount, adGroupModel.Name));
                            }
                        }
                    }
                }
            }
            return usersModel;
        }
    }
}
