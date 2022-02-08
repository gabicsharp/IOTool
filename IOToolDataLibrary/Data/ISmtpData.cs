using IOToolDataLibrary.Models;
using System.Threading.Tasks;

namespace IOToolDataLibrary.Data
{
    public interface ISmtpData
    {
        Task<SmtpModel> GetSmtp();
    }
}