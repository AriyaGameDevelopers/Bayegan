using System;
using Bayegan.Services.Abstractions;

namespace Bayegan.Storage.Dictionaries
{
    public class SecurePlayerPrefsStorage : PlayerPrefsStorage
    {   
        private readonly ICryptoService _cryptoService;

        public SecurePlayerPrefsStorage(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService ?? throw new ArgumentNullException(nameof(cryptoService));
        }

        public override TValue Load<TValue>(string key, TValue defaultValue)
        {
            LoadCheckArguments(key, defaultValue);

            var textDefaultValue = defaultValue.ToString();

            var encryptedText = LoadString(key, textDefaultValue);

            if(string.IsNullOrEmpty(encryptedText) || encryptedText == textDefaultValue)
            {
                return defaultValue;
            }
            
            var decryptedValue = _cryptoService.Decrypt(encryptedText);

            if(string.IsNullOrEmpty(decryptedValue))
            {
                return defaultValue;
            }
            
            return (TValue) Convert.ChangeType(decryptedValue, typeof(TValue));
        }

        public override void Store<TValue>(string key, TValue value)
        {
            StoreCheckArguments(key, value);

            var textValue = value.ToString();
            var encryptedValue = _cryptoService.Encrypt(textValue);
            base.Store(key, encryptedValue);
        }
    }
}

