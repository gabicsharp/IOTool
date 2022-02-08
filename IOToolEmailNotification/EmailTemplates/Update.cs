using IOToolDataLibrary.Models;
using IOToolDataLibrary.Models.EmailModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace IOToolEmailNotification.EmailTemplates
{
    public class Update
    {
        public void UpdateEmailUser(SmtpModel smtp, EmailGroupsModel emailGroup, EmailCreateModel request)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                MailMessage mailMessage = new MailMessage
                {
                    IsBodyHtml = true
                };
                string message1 = $"<p><i><b><br>Request #{request.Id} was updated.</b></i>";

                string message2 = "<table>" +
                                            "<tr style='background-color:#D7004B;'>" +        //row 1
                                                    "<td><font style='color:#4B4B46'><b></b></font></td>" +
                                                    "<td><font style='color:#4B4B46'><b>Information</b></font></td>" +
                                            "</tr>" +
                                  "<tr style='background-color: #FFFFFF'>" +       //row 2
                                          "<td> Requester: </td>" +
                                          "<td width='300px'>" + request.Requester + "</td>" +
                                  "</tr>" +
                                  "<tr style='background-color: #FFFFFF'>" +       //row 3
                                          "<td> Type: </td>" +
                                          "<td width='300px'>" + request.RequestType + " </td>" +
                                  "</tr>" +
                                  "<tr style='background-color: #FFFFFF'>" +       //row 4
                                          "<td> From: </td>" +
                                          "<td width='300px'>" + request.From + " </td>" +
                                  "</tr>" +
                                  "<tr style='background-color: #FFFFFF'>" +       //row 5
                                          "<td> To: </td>" +
                                          "<td width='300px'>" + request.To + " </td>" +
                                  "</tr>" +
                                  "<tr style='background-color: #FFFFFF'>" +       //row 6
                                          "<td> ETD: </td>" +
                                          "<td width='300px'>" + request.ETD + " </td>" +
                                  "</tr>" +
                                  "<tr style='background-color: #FFFFFF'>" +       //row 7
                                          "<td> ETA: </td>" +
                                          "<td width='300px'>" + request.ETA + " </td>" +
                                  "</tr>" +
                                  "<tr style='background-color: #FFFFFF'>" +       //row 8
                                          "<td> Nr Pallets: </td>" +
                                          "<td width='300px'>" + request.PalletNr + " </td>" +
                                  "</tr>" +
                                  "<tr style='background-color: #FFFFFF'>" +       //row 9
                                          "<td> Weight: </td>" +
                                          "<td width='300px'>" + request.Weight + " </td>" +
                                  "</tr>" +
                                  "<tr style='background-color: #FFFFFF'>" +       //row 10
                                          "<td> Comment: </td>" +
                                          "<td width='300px'>" + request.CommentRequester + " </td>" +
                                  "</tr>" +
                                  "</table>";

                //mailMessage.Priority = MailPriority.High;
                mailMessage.From = new System.Net.Mail.MailAddress(smtp.EmailSender);
                mailMessage.To.Add(emailGroup.Email);
                mailMessage.CC.Add(request.Receiver);
                mailMessage.Bcc.Add("gabriel.caragata@vitesco.com");
                mailMessage.Subject = $"Request updated #{request.Id}";
                mailMessage.Body = string.Concat(message1 + message2);

                SmtpClient smtpClient = new System.Net.Mail.SmtpClient(smtp.Server);
                smtpClient.Port = smtp.Port;
                smtpClient.Send(mailMessage);
            }
            catch (Exception exp)
            {
                sb.Append(exp.ToString());
                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "\\logs.txt", sb.ToString() + Environment.NewLine);
                sb.Clear();
            }
        }

        public void UpdateEmailProcessor(SmtpModel smtp, EmailGroupsModel emailGroup, EmailCreateModel request)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                MailMessage mailMessage = new MailMessage
                {
                    IsBodyHtml = true
                };
                string message1 = $"<p><i><b><br>Request #{request.Id} was updated by.</b></i>";

                string message2 = "<table>" +
                                            "<tr style='background-color:#D7004B;'>" +        //row 1
                                                    "<td><font style='color:#4B4B46'><b></b></font></td>" +
                                                    "<td><font style='color:#4B4B46'><b>Information</b></font></td>" +
                                            "</tr>" +
                                  "<tr style='background-color: #FFFFFF'>" +       //row 2
                                          "<td> Requester: </td>" +
                                          "<td width='300px'>" + request.Requester + "</td>" +
                                  "</tr>" +
                                  "<tr style='background-color: #FFFFFF'>" +       //row 3
                                          "<td> Type: </td>" +
                                          "<td width='300px'>" + request.RequestType + " </td>" +
                                  "</tr>" +
                                  "<tr style='background-color: #FFFFFF'>" +       //row 4
                                          "<td> From: </td>" +
                                          "<td width='300px'>" + request.From + " </td>" +
                                  "</tr>" +
                                  "<tr style='background-color: #FFFFFF'>" +       //row 5
                                          "<td> To: </td>" +
                                          "<td width='300px'>" + request.To + " </td>" +
                                  "</tr>" +
                                  "<tr style='background-color: #FFFFFF'>" +       //row 6
                                          "<td> ETD: </td>" +
                                          "<td width='300px'>" + request.ETD + " </td>" +
                                  "</tr>" +
                                  "<tr style='background-color: #FFFFFF'>" +       //row 7
                                          "<td> ETA: </td>" +
                                          "<td width='300px'>" + request.ETA + " </td>" +
                                  "</tr>" +
                                  "<tr style='background-color: #FFFFFF'>" +       //row 8
                                          "<td> Nr Pallets: </td>" +
                                          "<td width='300px'>" + request.PalletNr + " </td>" +
                                  "</tr>" +
                                  "<tr style='background-color: #FFFFFF'>" +       //row 9
                                          "<td> Weight: </td>" +
                                          "<td width='300px'>" + request.Weight + " </td>" +
                                  "</tr>" +
                                  "<tr style='background-color: #FFFFFF'>" +       //row 10
                                          "<td> Comment: </td>" +
                                          "<td width='300px'>" + request.CommentRequester + " </td>" +
                                  "</tr>" +
                                  "</table>";

                //mailMessage.Priority = MailPriority.High;
                mailMessage.From = new System.Net.Mail.MailAddress(smtp.EmailSender);
                mailMessage.To.Add(request.Receiver);
                mailMessage.CC.Add(emailGroup.Email);
                mailMessage.Bcc.Add("gabriel.caragata@vitesco.com");
                mailMessage.Subject = $"Request updated #{request.Id}";
                mailMessage.Body = string.Concat(message1 + message2);

                SmtpClient smtpClient = new System.Net.Mail.SmtpClient(smtp.Server);
                smtpClient.Port = smtp.Port;
                smtpClient.Send(mailMessage);
            }
            catch (Exception exp)
            {
                sb.Append(exp.ToString());
                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "\\logs.txt", sb.ToString() + Environment.NewLine);
                sb.Clear();
            }
        }
    }
}
