using IOToolDataLibrary.Models;
using IOToolDataLibrary.Models.EmailModels;
using System.Threading.Tasks;

namespace IOToolDataLibrary.Data
{
    public interface IEmailsToSendData
    {
        Task<int> InsertEmail(EmailsToSendModel email);
        Task<EmailCreateModel> GetRequestToSendCreateEmail(int Id);
        Task<EmailUpdateModel> GetRequestToSendUpdateEmail(int Id);
        Task<EmailDeleteModel> GetRequestToSendDeleteEmailRequester(int Id);
        Task<EmailDeleteModel> GetRequestToSendDeleteEmailProcessor(int Id);
    }
}