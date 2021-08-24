using System;
using Bayegan.Services.Abstractions;
using Bayegan.Storage.Dictionaries;
using NSubstitute;
using NUnit.Framework;

namespace Bayegan.Tests.UnitTests.Storage.Dictionaries
{
    public class SecurePlayerPrefsStorageUnitTests 
    {
        private const string TextToEncrypt = "aaa";
        private const string EncryptedText = "encrypted aaa";

        private SecurePlayerPrefsStorage _securePlayerPrefsStorage;
        private ICryptoService _cryptoService;

        [OneTimeSetUp]
        public void Setup()
        {
            MockCryptoServie();
            _securePlayerPrefsStorage = new SecurePlayerPrefsStorage(_cryptoService);
        }

        private void MockCryptoServie()
        {
            _cryptoService = Substitute.For<ICryptoService>();
            _cryptoService.Encrypt(TextToEncrypt).Returns(EncryptedText);

        }

        [Test]
        public void Constructor_PassNullCryproServie_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => 
            {
                new SecurePlayerPrefsStorage(null);
            });
        }

        [Test]
        [TestCase("", "value")]
        [TestCase(null, "value")]
        [TestCase("key", "")]
        [TestCase("key", null)]
        public void Store_PassNullArguments_ThrowsArgumentNullException(string key, string value)
        {
            Assert.Throws<ArgumentNullException>(() => 
            {
                _securePlayerPrefsStorage.Store(key, value);
            });
        }


        [Test]
        [TestCase("", "value")]
        [TestCase(null, "value")]
        [TestCase("key", null)]
        public void Load_PassNullArguments_ThrowsArgumentNullException(string key, string value)
        {
            Assert.Throws<ArgumentNullException>(() => 
            {
                _securePlayerPrefsStorage.Load(key, value);

            });
        }


        
    }

}

