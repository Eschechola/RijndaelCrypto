using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace RijndaelCrypto
{
    public class Crypto
    {
        private static byte[] Bytes = { 0x50, 0x08, 0xF1, 0xDD, 0xDE, 0x3C, 0xF2, 0x18, 0x44, 0x74, 0x19, 0x2C, 0x53, 0x49, 0xAB, 0xBC };

        //string j7Y9I3YWYLJyoBmWrPm4xYe60nncpxTx encodade em base 64
        private const string CryptoKey = "ajdZOUkzWVdZTEp5b0JtV3JQbTR4WWU2MG5uY3B4VHg=";

        public static string Encrypt(string text)
        {
            try
            {
                // Se a string não está vazia, executa a criptografia
                if (!string.IsNullOrEmpty(text))
                {
                    // Cria instancias de vetores de bytes com as chaves
                    byte[] bytesText;
                    byte[] bytesKey;

                    bytesKey = Convert.FromBase64String(CryptoKey);
                    bytesText = new UTF8Encoding().GetBytes(text);

                    // Instancia a classe de criptografia Rijndael
                    Rijndael rijndael = new RijndaelManaged();

                    // Define o tamanho da chave "256 = 8 * 32"
                    // Lembre-se: chaves possíves:
                    // 128 (16 caracteres), 192 (24 caracteres) e 256 (32 caracteres)

                    rijndael.KeySize = 256;

                    // Cria o espaço de memória para guardar o valor criptografado:
                    MemoryStream memoryStream = new MemoryStream();

                    // Instancia o encriptador 
                    CryptoStream encryptor = new CryptoStream(memoryStream, rijndael.CreateEncryptor(bytesKey, Bytes), CryptoStreamMode.Write);

                    // Faz a escrita dos dados criptografados no espaço de memória
                    encryptor.Write(bytesText, 0, bytesText.Length);

                    // Despeja toda a memória.
                    encryptor.FlushFinalBlock();

                    // Pega o vetor de bytes da memória e gera a string criptografada
                    return Convert.ToBase64String(memoryStream.ToArray());
                }
                else
                {
                    // Se a string for vazia retorna nulo
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public static string Decrypt(string text)
        {
            try
            {
                // Se a string não está vazia, executa a criptografia
                if (!string.IsNullOrEmpty(text))
                {
                    // Cria instancias de vetores de bytes com as chaves
                    byte[] bytesText;
                    byte[] bytesKey;

                    bytesKey = Convert.FromBase64String(CryptoKey);
                    bytesText = Convert.FromBase64String(text);

                    // Instancia a classe de criptografia Rijndael
                    Rijndael rijndael = new RijndaelManaged();

                    // Define o tamanho da chave "256 = 8 * 32"
                    // Lembre-se: chaves possíves:
                    // 128 (16 caracteres), 192 (24 caracteres) e 256 (32 caracteres)
                    rijndael.KeySize = 256;

                    // Cria o espaço de memória para guardar o valor DEScriptografado:
                    MemoryStream memoryStream = new MemoryStream();

                    // Instancia o Decriptador 

                    CryptoStream decryptor = new CryptoStream(memoryStream, rijndael.CreateDecryptor(bytesKey, Bytes), CryptoStreamMode.Write);

                    // Faz a escrita dos dados criptografados no espaço de memória
                    decryptor.Write(bytesText, 0, bytesText.Length);

                    // Despeja toda a memória.
                    decryptor.FlushFinalBlock();

                    // Instancia a classe de codificação para que a string venha de forma correta
                    UTF8Encoding utf8 = new UTF8Encoding();

                    // Com o vetor de bytes da memória, gera a string descritografada em UTF8
                    return utf8.GetString(memoryStream.ToArray());
                }
                else
                {
                    // Se a string for vazia retorna nulo
                    return null;
                }
            }
            catch (Exception)
            {
                // Se a string for vazia retorna nulo
                return null;
            }
        }
    }
}
