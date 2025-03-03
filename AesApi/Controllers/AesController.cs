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
        [EndpointSummary("Encrypt text with AES algorythm, using provided key.")]
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
        [EndpointSummary("Decrypt text with AES algorythm, using provided key.")]
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
        [EndpointSummary("Generates a Base64-encoded AES key of the specified size.")]
        public string GenerateBase64Key(int keySize)
        {
            return AesService.GenerateBase64Key(keySize);
        }
    }
}
