using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using BUS;

namespace GUI
{
    class Email : DevExpress.XtraEditors.XtraUserControl
    {
        private string user;
        private string pass;
        private string GoogleAppPassword ;

        private string Subject;
        private string Body ;
        SmtpClient smtpClient;
        BUS_Vaccine busVC ;
        public Email()
        {
            this.busVC = new BUS_Vaccine();
            this.user = "trungtamtiemchung155@gmail.com";
            this.pass = "nguyen12345";
            this.GoogleAppPassword = "avurfijmedaprpgx";
            this.Subject = "Trung tâm tiêm chủng";
            this.Body = "<h1>Hello</h1>";
            this.smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(this.user, GoogleAppPassword),
                EnableSsl = true,
            };
        }
        public bool send(string hoten, string email, string maVC, string ngayDenHan)
        {
            if (email.Trim() == "")
            {
                return false;
            }
            string vaccine = busVC.getVCName(maVC);
            this.Body = "Xin chào <b>" + hoten+ "</b><br>";
            this.Body += "Email này được gửi từ trung tâm tiêm chủng MTAVC<br>";
            this.Body += "Lịch tiêm nhắc lại vắc xin "+vaccine+" vào ngày "+ngayDenHan+"<br>";
            this.Body += "Mong bạn thu xếp thời gian để tới trung tâm. Xin cảm ơn.";
            var mailMessage = new MailMessage
            {
                From = new MailAddress(this.user),
                Subject = Subject,
                Body = Body,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(email);        
            try
            {
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
    }
}
