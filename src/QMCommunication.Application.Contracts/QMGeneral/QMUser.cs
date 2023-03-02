using com.sun.tools.classfile;
using java.security;
using java.security.spec;
using javax.crypto;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
namespace QMCommunication.QMGeneral
{
    public class QMUser
    {
        public string username { get; set; }
        public string password { get; set; }


        public static QMUser EncryptPublicKey(string publicKey, string text, string userName)
        {

            byte[] buffer = Convert.FromBase64String(publicKey);

            X509EncodedKeySpec x509EncodedlKeySpec2 = new X509EncodedKeySpec(buffer);
            KeyFactory keyFactory = KeyFactory.getInstance("RSA");
            java.security.PublicKey publickey = keyFactory.generatePublic(x509EncodedlKeySpec2);
            Cipher cipher = Cipher.getInstance("RSA");
            cipher.init(Cipher.ENCRYPT_MODE, publickey);
            byte[] result = cipher.doFinal(Encoding.UTF8.GetBytes(text));

            return new QMUser { username = userName, password = Convert.ToBase64String(result) };

        }


    }
}
