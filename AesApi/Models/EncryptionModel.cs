namespace AesApi.Models
{
    public class EncryptionModel
    {
        public required string Key { get; set; }
        public required string Plaintext { get; set; }
    }
}
