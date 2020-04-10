using System;

namespace RijndaelCrypto
{
    class Program
    {
        static void Main(string[] args)
        {
            var phrase = "Olá Mundo! Algoritmo de criptografia Rijndael";
            var encryptedPhrase = Crypto.Encrypt(phrase);
            var decryptedPhrase = Crypto.Decrypt(encryptedPhrase);


            Console.WriteLine("Frase Encriptada: " + encryptedPhrase);
            Console.WriteLine("Frase Decriptada: " + decryptedPhrase);
            Console.ReadLine();
        }
    }
}
