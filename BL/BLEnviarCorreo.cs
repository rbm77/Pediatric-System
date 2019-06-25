using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace BL
{
    public class BLEnviarCorreo
    {
        Boolean estado = true;
        String merror;

        /// <summary>
        /// Envia un correo a una cuenta del sistema
        /// </summary>
        /// <param name="destinatario">Direccion de Correo a la cual se enviara el mensaje</param>
        /// <param name="asunto">Asunto que tendra el mensaje del correo</param>
        /// <param name="mensaje">Mensaje de texto enviado por correo</param>
        public BLEnviarCorreo(String destinatario, String asunto, String mensaje)
        {
            MailMessage correo = new MailMessage();
            SmtpClient protocolo = new SmtpClient();
            correo.To.Add(destinatario);
            ///Se asigna el remitente del correo
            correo.From = new MailAddress("pediatricsystem.adm@gmail.com", "Clinica Pediatrica Divino Niño", System.Text.Encoding.UTF8);

            ///Se asigna el receptor del correo
            correo.Subject = asunto;
            correo.SubjectEncoding = System.Text.Encoding.UTF8;

            ///Se asigna el mensaje del correo
            correo.Body = mensaje;
            correo.BodyEncoding = System.Text.Encoding.UTF8;
            correo.IsBodyHtml = false;

            ///Credenciales del correo el cual se utiliza para enviar el mensaje
            protocolo.Credentials = new System.Net.NetworkCredential("pediatricsystem.adm@gmail.com", "pediatrica123");
            protocolo.Port = 587;
            protocolo.Host = "smtp.gmail.com";
            protocolo.EnableSsl = true;

            try
            {
                ///Se envia el correo
                protocolo.Send(correo);
            }
            catch (SmtpException error)
            {
                estado = false;
                merror = error.Message.ToString();
            }
        }

        public Boolean Estado
        {
            get { return estado; }
        }

        public String mensaje_error
        {
            get { return merror; }
        }
    }
}

