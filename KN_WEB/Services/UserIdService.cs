using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KN_WEB.Services
{
    //Entidad, Objeto, Clase
    public class UserIdService
    {
        private readonly byte[] Key = Convert.FromBase64String("sy+v61jJHH5tZTjth2g+PwKpfUiNXWA0ImlUWxikTKUedfPEC6zrkDSzsneTbfkTXJnaEchH7BcVBF4XkqIMDw==");

        public string Cifrar(int userId, TimeSpan vigencia)
        {
            var payload = Encoding.UTF8.GetBytes($"{userId}|{DateTime.UtcNow.Add(vigencia).Ticks}");
            using (var aes = Aes.Create())
            using (var hmac = new HMACSHA256(Key.AsSpan(32).ToArray()))
            {
                aes.Key = Key.AsSpan(0, 32).ToArray();
                aes.GenerateIV();
                var cifrado = aes.CreateEncryptor().TransformFinalBlock(payload, 0, payload.Length);

                var datos = new byte[16 + cifrado.Length + 32];
                Buffer.BlockCopy(aes.IV, 0, datos, 0, 16);
                Buffer.BlockCopy(cifrado, 0, datos, 16, cifrado.Length);
                Buffer.BlockCopy(hmac.ComputeHash(datos, 0, 16 + cifrado.Length), 0, datos, 16 + cifrado.Length, 32);

                return Convert.ToBase64String(datos).TrimEnd('=').Replace('+', '-').Replace('/', '_');
            }
        }

        public int? Descifrar(string token)
        {
            try
            {
                var b64 = token.Replace('-', '+').Replace('_', '/');
                var datos = Convert.FromBase64String(b64.PadRight(b64.Length + (4 - b64.Length % 4) % 4, '='));
                if (datos.Length < 16 + 16 + 32) return null;

                int largoMac = datos.Length - 32;
                using (var hmac = new HMACSHA256(Key.AsSpan(32).ToArray()))
                {
                    var macEsperado = hmac.ComputeHash(datos, 0, largoMac);
                    int diff = 0;
                    for (int i = 0; i < 32; i++) diff |= macEsperado[i] ^ datos[largoMac + i];
                    if (diff != 0) return null;
                }

                using (var aes = Aes.Create())
                {
                    aes.Key = Key.AsSpan(0, 32).ToArray();
                    aes.IV = datos.AsSpan(0, 16).ToArray();
                    var plano = aes.CreateDecryptor().TransformFinalBlock(datos, 16, largoMac - 16);
                    var partes = Encoding.UTF8.GetString(plano).Split('|');

                    if (DateTime.UtcNow.Ticks > long.Parse(partes[1])) return null;
                    return int.Parse(partes[0]);
                }
            }
            catch { return null; }
        }

        public async Task EnviarCorreo(string para, string asunto, string html)
        {
            var cuentaCorreo = "@gmail.com";
            var contrasenaCorreo = "";

            if (string.IsNullOrEmpty(contrasenaCorreo))
                return;

            var mensaje = new MimeMessage();
            mensaje.From.Add(MailboxAddress.Parse(cuentaCorreo));
            mensaje.To.Add(MailboxAddress.Parse(para));
            mensaje.Subject = asunto;
            mensaje.Body = new BodyBuilder { HtmlBody = html }.ToMessageBody();

            using (var smtp = new SmtpClient())
            {
                await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(cuentaCorreo, contrasenaCorreo);
                await smtp.SendAsync(mensaje);
                await smtp.DisconnectAsync(true);
            }
        }

    }
}