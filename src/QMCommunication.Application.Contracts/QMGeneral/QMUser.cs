using com.sun.tools.classfile;
using Flurl.Http;
using java.security;
using java.security.spec;
using javax.crypto;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QMCommunication.QMGeneral
{
    public class QMUser
    {
        public string username { get; set; }
        public string password { get; set; }

        private static IConfiguration Configuration { get; set; }

        public static string QMGetTokenUrl { get; private set; }
        public static string QMUserName { get; private set; }
        public static string QMPassword { get; private set; }
        public static string QMPublicKey { get; private set; }

        public static string QMPalabelCasecodeTotalQueryUrl { get; private set; }

        public QMUser()
        {
        }
        public QMUser(IConfiguration configuration)
        {
            Configuration = configuration;
            QMGetTokenUrl = Configuration["App:QMGetTokenUrl"];
            QMUserName = Configuration["App:QMUserName"];
            QMPassword = Configuration["App:QMPassword"];
            QMPublicKey = Configuration["App:QMPublicKey"];

            QMPalabelCasecodeTotalQueryUrl = Configuration["App:QMPalabelCasecodeTotalQueryUrl"];
        }

        public static QMUser EncryptPublicKey()
        {

            byte[] buffer = Convert.FromBase64String(QMPublicKey);

            X509EncodedKeySpec x509EncodedlKeySpec2 = new X509EncodedKeySpec(buffer);
            KeyFactory keyFactory = KeyFactory.getInstance("RSA");
            java.security.PublicKey publickey = keyFactory.generatePublic(x509EncodedlKeySpec2);
            Cipher cipher = Cipher.getInstance("RSA");
            cipher.init(Cipher.ENCRYPT_MODE, publickey);
            byte[] result = cipher.doFinal(Encoding.UTF8.GetBytes(QMPassword));

            return new QMUser { username = QMUserName, password = Convert.ToBase64String(result) };

        }


        public static async Task<string> GetQMPalabelCasecodeTotalQueryUrl()
        {

            QMUser qmuser = QMUser.EncryptPublicKey();

            QMGeneralResult tokenResult = await QMUser.QMGetTokenUrl.PostJsonAsync(qmuser
                )
                 .ReceiveJson<QMGeneralResult>();

            string QMPalabelCasecodeTotalQueryUrl = string.Format(QMUser.QMPalabelCasecodeTotalQueryUrl, tokenResult.Token);

            return QMPalabelCasecodeTotalQueryUrl;

        }

    }
}
