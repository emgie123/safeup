using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Security;
using System.Web;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SafeUp.Models.SSLConnection
{
    public class SslClient
    {

        public X509Certificate2 DownloadSslCertificate(string server)
        {

            X509Certificate2 cert = null;
            using (TcpClient client = new TcpClient())
            {         
                client.Connect(server, 8000);

                SslStream ssl = new SslStream(client.GetStream(), false, new RemoteCertificateValidationCallback(ValidateServerCertificate), null);
                try
                {
                    ssl.AuthenticateAsClient(server);
                }
                catch (AuthenticationException e)
                {
                    Debug.WriteLine(e.Message);
                    ssl.Close();
                    client.Close();
                    return cert;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    ssl.Close();
                    client.Close();
                    return cert;
                }
                cert = new X509Certificate2(ssl.RemoteCertificate);
                ssl.Close();
                client.Close();
                return cert;
            }
        }

        public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;

            Console.WriteLine("Certificate error: {0}", sslPolicyErrors);

            return false;
        }
    }
}