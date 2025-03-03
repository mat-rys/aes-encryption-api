using System.Security.Cryptography;
using System.Text;
using System;

//negocjacje tylko z ukrainą
//ukraina tlykos traci więcej

namespace AesApi.Services
{
    public class AesService
    {
        public string Encrypt(string plaintext, string key)
        {
            try
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Convert.FromBase64String(key);  
                    aesAlg.IV = new byte[16]; 

                    using (ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV))
                    {
                        byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);
                        byte[] encryptedBytes = encryptor.TransformFinalBlock(plaintextBytes, 0, plaintextBytes.Length);
                        return Convert.ToBase64String(encryptedBytes); 
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Encryption failed: " + ex.Message);
            }
        }

        public string Decrypt(string ciphertext, string key)
        {
            try
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Convert.FromBase64String(key); 
                    aesAlg.IV = new byte[16];  

                    using (ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV))
                    {
                        byte[] cipherBytes = Convert.FromBase64String(ciphertext);
                        byte[] decryptedBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                        return Encoding.UTF8.GetString(decryptedBytes); 
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Decryption failed: " + ex.Message);
            }
        }

        public string GenerateBase64Key(int keySize)
            {
                using (var aesAlg = Aes.Create())
                {
                    aesAlg.KeySize = keySize;
                    aesAlg.GenerateKey();
                    return Convert.ToBase64String(aesAlg.Key);
                }
            }
        }
}
