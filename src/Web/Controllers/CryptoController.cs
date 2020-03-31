using CryptoCore.Crypto;
using CryptoCore.SecretConfiguration;
using Microsoft.AspNetCore.Mvc;
using Web.Model;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptoController : ControllerBase
    {
        private readonly IEncryptor _encryptor;
        private readonly IDecryptor _decryptor;
        private readonly IDbSettingsResolved _dbSettingsResolved;

        public CryptoController(IEncryptor encryptor, IDecryptor decryptor, IDbSettingsResolved dbSettingsResolved)
        {
            _encryptor = encryptor;
            _decryptor = decryptor;
            _dbSettingsResolved = dbSettingsResolved;
        }

        [HttpGet]
        [Route("~/getdecryptdbsettings")]
        public IDbSettingsResolved Get()
        {
            return _dbSettingsResolved;
        }

        [HttpPost]
        [Route("~/encrypt")]
        public TextModel Encrypt(TextModel input)
        {
            return new TextModel() { Text = _encryptor.Encrypt(input.Text) };
        }

        [HttpPost]
        [Route("~/decrypt")]
        public TextModel Decrypt(TextModel input)
        {
            return new TextModel() { Text = _decryptor.Decrypt(input.Text) };
        }
    }
}
