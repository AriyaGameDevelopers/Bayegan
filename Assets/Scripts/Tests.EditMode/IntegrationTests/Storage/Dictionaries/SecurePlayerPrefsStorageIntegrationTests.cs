using Bayegan.Services.Abstractions;
using Bayegan.Storage.Dictionaries;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace Bayegan.Tests.IntegrationTests.Storage.Dictionaries
{
    public class SecurePlayerPrefsStorageIntegrationTests 
    {
        private const string DefaultValue = "value";
        private const string EncryptedDefaultValue = "encrypted value";

        private SecurePlayerPrefsStorage _securePlayerPrefsStorage;
        private ICryptoService _cryptoService;

        [SetUp]
        public void Setup()
        {
            MockCryptoServie();
            _securePlayerPrefsStorage = new SecurePlayerPrefsStorage(_cryptoService);
        }
        
        private void MockCryptoServie()
        {
            _cryptoService = Substitute.For<ICryptoService>();
            _cryptoService.Encrypt(DefaultValue).Returns(EncryptedDefaultValue);

        }

        [Test]
        public void Store_StoreEncryptedValue()
        {
            var key = "key";

            _securePlayerPrefsStorage.Store(key, DefaultValue);

            var storedValue = PlayerPrefs.GetString(key);

            PlayerPrefs.DeleteKey(key);

            Assert.AreEqual(EncryptedDefaultValue, storedValue);
        }
    }
}

