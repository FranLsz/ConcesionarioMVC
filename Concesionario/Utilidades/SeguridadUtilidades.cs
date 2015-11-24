using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Concesionario.Utilidades
{
    public class SeguridadUtilidades
    {
        //se transforma un string a 32 bytes para que cripto.Key lo admita
        public static byte[] GetKey(String txt)
        {
            return new PasswordDeriveBytes(txt, null).GetBytes(32);
        }

        public static String GetSha1(String texto)
        {
            //se obtiene el codificador
            var sha = SHA1.Create();

            //se obtiene el encoding UTF8
            UTF8Encoding encoding = new UTF8Encoding();

            byte[] datos;
            StringBuilder builder = new StringBuilder();

            //la clase SHA1 devuelve un array de bytes
            datos = sha.ComputeHash(encoding.GetBytes(texto));

            //se recorre el array de bytes y se transforma en un string
            for (int i = 0; i < datos.Length; i++)
            {
                //crea una cadena hexadecimal con 2 digitos por byte
                builder.AppendFormat("{0:x2}", datos[i]);
            }

            return builder.ToString();
        }

        public static String Cifrar(String contenido, String clave)
        {
            var encoding = new UTF8Encoding();
            var cripto = new RijndaelManaged();
            //contenido cifrado
            byte[] cifrado;

            //array que contiene IV + texto cifrado
            byte[] retorno;
            byte[] key = GetKey(clave);

            cripto.Key = key;
            //IV es el patron a partir del cual el algoritmo genera el cifrado
            cripto.GenerateIV();
            byte[] aEncriptar = encoding.GetBytes(contenido);

            cifrado = cripto.CreateEncryptor().TransformFinalBlock(aEncriptar, 0, aEncriptar.Length);

            retorno = new byte[cripto.IV.Length + cifrado.Length];

            cripto.IV.CopyTo(retorno, 0);
            cifrado.CopyTo(retorno, cripto.IV.Length);


            return Convert.ToBase64String(retorno);
        }

        public static String DesCifrar(byte[] contenido, String clave)
        {
            var encoding = new UTF8Encoding();
            var cripto = new RijndaelManaged();
            var ivTemp = new byte[cripto.IV.Length];
            //IV + contenido cifrado
            var key = GetKey(clave);
            var cifrado = new byte[contenido.Length - ivTemp.Length];

            cripto.Key = key;
            //se copia el IV en IVTemp
            Array.Copy(contenido, ivTemp, ivTemp.Length);

            //se copia el contenido sin el IV en cifrado
            Array.Copy(contenido, ivTemp.Length, cifrado, 0, cifrado.Length);
            cripto.IV = ivTemp;
            var descifrado = cripto.CreateDecryptor().TransformFinalBlock(cifrado, 0, cifrado.Length);

            return encoding.GetString(descifrado);
        }


    }
}
