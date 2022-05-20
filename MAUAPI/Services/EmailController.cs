using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace MAUAPI.Services
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        [Route("Send")]
        public async Task<IActionResult> SendMessage(EmailData data)
        {
            if (ModelState.IsValid)
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("wfpc.sweden@gmail.com", "sweden2019");
                MailMessage msg = new MailMessage();
                msg.Subject = data.Subject;
                msg.Body = "Message from:" + "\n" + data.Username + "\n\nE-post: " + "\n" + data.Email + "\n" + " \n" +
                   "Message:" + "\n" + data.Message + "\n\n";
#pragma warning disable CS8604 // Possible null reference argument.
                msg.From = new MailAddress(data.Email);
#pragma warning restore CS8604 // Possible null reference argument.
                msg.To.Add("wfpc.sweden@gmail.com");
                await Task.Run(() => smtp.Send(msg));

                return Ok(data);
                
            }
            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }
    }
}
