using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularBlogCore.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;


namespace AngularBlogCore.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HelperController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendContactEmail(Contact contact)
        {
            System.Threading.Thread.Sleep(5000);
            try
            {
                MailMessage mailMessage = new MailMessage();

                SmtpClient smtpClient = new SmtpClient("mail.ersintopcu.com");

                mailMessage.From = new MailAddress("bilgi@ersintopcu.com");
                mailMessage.To.Add("ersintopcu19@hotmail.com");
                mailMessage.Subject = contact.Subject;
                mailMessage.Body = contact.Message;
                mailMessage.IsBodyHtml = true;
                smtpClient.Port = 587;
                smtpClient.Credentials = new System.Net.NetworkCredential("bilgi@ersintopcu.com", "147258Ersin.");
                smtpClient.Send(mailMessage);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }
    }
}