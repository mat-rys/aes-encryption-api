namespace AesApi.Models
{
    public class DecryptionModel
    {
        public required string Key { get; set; }
        public required string EncryptedText  { get; set; }
    }
}
