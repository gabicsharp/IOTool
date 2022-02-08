using IOToolDataLibrary.Models;
using IOToolDataLibrary.Models.CustomTables;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IOToolDataLibrary.Data
{
    public interface IRequestsData
    {
        Task<List<NewMyRequestSummaryModel>> GetMyRequests(string WindowsAccount);
        Task<List<NewWorkRequestModel>> GetNotClosedRequests();
        Task<List<NewRequestClosedModel>> GetDashboard();
        Task<List<NewWorkRequestModel>> GetRequestById(int Id);
        Task<NewRequestEditModel> GetRequestByIdToEditProcessor(int Id);
        Task<NewRequestEditCalculationModel> GetRequestByIdToEditProcessorForCalculation(int Id);
        Task<NewMyRequestSummaryModel> GetRequestByIdToSpecificUser(int Id, string WindowsAccount);
        Task<NewWorkRequestDeleteModel> GetRequestByIdToDelete(int Id);
        Task<int> InsertRequest(RequestsModel request);
        Task<int> UpdateRequestByUser(NewMyRequestSummaryModel request);
        Task<int> UpdateRequestByProcessor(NewRequestEditModel request);
        Task<int> DeleteRequestByRequester(int Id, string CommentRequesterForClose);
        Task<int> DeleteRequestByProcessor(int Id, string CommentProcessorForClose);

    }
}