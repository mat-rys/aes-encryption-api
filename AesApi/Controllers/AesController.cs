using AesApi.Models;
using AesApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AesApi.Controllers
{
    [Route("api/aes")]
    [ApiController]
    public class AesController : ControllerBase
    {
        [HttpPost("encrypt")]
        public ActionResult<string> EncryptWithAes([FromBody] EncryptionModel encryptionModel)
        {
            try
            {
                return AesService.Encrypt(encryptionModel.Plaintext, encryptionModel.Key);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("decrypt")]
        public ActionResult<string> DecryptWithAes([FromBody] DecryptionModel decryptionModel)
        {
            try
            {
                return AesService.Decrypt(decryptionModel.EncryptedText, decryptionModel.Key);
            }
            catch (FormatException ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("generateKey/{keySize}")]
        public string GenerateBase64Key(int keySize)
        {
            return AesService.GenerateBase64Key(keySize);
        }
    
    }
}
