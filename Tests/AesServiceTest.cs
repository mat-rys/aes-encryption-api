using AesApi.Controllers;
using AesApi.Services;
using Moq;

namespace Tests
{
    public class AesServiceTest
    {
        private readonly AesService _aesService;

        public AesServiceTest()
        {
            _aesService = new AesService();
        }

        [Fact]
        public void Encrypt_ProvidedNullKey_ReturnNullException()
        {
            Assert.Throws<System.ArgumentNullException>(() => _aesService.Encrypt("hello", ""));
        }

        [Fact]
        public void Encrypt_ProvidedNullPlainText_ReturnNullException()
        {
            var key = _aesService.GenerateBase64Key(128);
            Assert.Throws<System.ArgumentNullException>(() => _aesService.Encrypt("", key));
        }

        [Fact]
        public void Encrypt_ProvidedNonValidBase64Key_ReturnException()
        {
            Assert.Throws<System.Exception>(() => _aesService.Encrypt("hello", "cnakwbnsyu1/+=a="));
        }

        [Fact]
        public void Encrypt_ProvidedProperInputs_ReturnEncodedString()
        {
            var result = _aesService.Encrypt("hello", "MuhNr/7mHHXGJWcY9xzpkg==");
            Assert.Equal("4gNzs5sEVuA0t8hqaUIE/A==", result);
        }

        [Fact]
        public void Decrypt_ProvidedProperInputs_ReturnEncodedString()
        {
            var result = _aesService.Decrypt("4gNzs5sEVuA0t8hqaUIE/A==", "MuhNr/7mHHXGJWcY9xzpkg==");
            Assert.Equal("hello", result);
        }

        [Fact]
        public void Decrypt_ProvidedNonValidBase64Key_ReturnException()
        {
            Assert.Throws<System.Exception>(() => _aesService.Decrypt("4gNzs5sEVuA0t8hqaUIE/A==", "????w??wwwasd"));
        }

        [Fact]
        public void Decrypt_ProvidedNullKey_ReturnNullException()
        {
            Assert.Throws<System.ArgumentNullException>(() => _aesService.Decrypt("4gNzs5sEVuA0t8hqaUIE/A==", ""));
        }

        [Fact]
        public void Decrypt_ProvidedNullPlainText_ReturnNullException()
        {
            var key = _aesService.GenerateBase64Key(128);
            Assert.Throws<System.ArgumentNullException>(() => _aesService.Decrypt("", "MuhNr/7mHHXGJWcY9xzpkg=="));
        }
    }
}