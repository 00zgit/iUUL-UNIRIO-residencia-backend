using System.Net.Mail;
using System.Net;
using scb_externo.Models;

namespace scb_externo.services
{
    public class MailTrapAPI
    {
        public void enviarEmail(NovoEmail novoEmail)
        {
            var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("06c52fd7f8506f", "eb426f2444903f"),
                EnableSsl = true,
            };

            client.Send("sistema@scb.com", novoEmail.Endereco, novoEmail.Assunto, novoEmail.Mensagem);
        }
    }
}
