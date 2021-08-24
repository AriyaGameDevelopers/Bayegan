using System;
using Bayegan.Services.Cryptography.Aes;
using NUnit.Framework;

namespace Bayegan.Tests.UnitTests.Service.Cryptography.Aes
{
    [TestFixture]
    public class AesCryptoServiceUnitTests
    {
        
        private AesCryptoService _aesCryptoService;

        [SetUp]
        public void Setup()
        {
            _aesCryptoService = new AesCryptoService("aaaaaaaabbbbbbbbccccccccdddddddd", "eeeeeeeeffffffff");
        }

        [Test]
        [TestCase("aaaaaaaabbbbbbbbccccccccdddddddd1", "eeeeeeeeffffffff")]
        [TestCase("aaaaaaaabbbbbbbbccccccccddddddd", "eeeeeeeeffffffff")]
        [TestCase("aaaaaaaabbbbbbbbccccccccdddddddd", "eeeeeeeefffffff")]
        [TestCase("aaaaaaaabbbbbbbbccccccccdddddddd", "eeeeeeeeffffffff1")]
        
        public void Constructor_PassInvalidArguments_ThrowsArgumentException(string key, string iv)
        {
            Assert.Throws<ArgumentException>(() => 
            {
                new AesCryptoService(key, iv);
            });
        }


        [Test]
        [TestCase("", "eeeeeeeeffffffff")]
        [TestCase(null, "eeeeeeeeffffffff")]
        [TestCase("aaaaaaaabbbbbbbbccccccccdddddddd1", "")]
        [TestCase("aaaaaaaabbbbbbbbccccccccdddddddd1", null)]
        
        public void Constructor_PassNullOrEmptyArguments_ThrowArgumentNullException(string key, string iv)
        {
            Assert.Throws<ArgumentNullException>(() => 
            {
                new AesCryptoService(key, iv);                
            });
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Encrypt_PassNullAndEmptyArgument_ThrowsArgumentNullException(string textToEncrypt)
        {
            Assert.Throws<ArgumentNullException>(() => 
            {
                _aesCryptoService.Encrypt(textToEncrypt);
            });
        }

        [Test]
        [TestCase("aaa", "OG2IbG9LzasoStvd5g3AGw==")]
        [TestCase("111111111111111111111111111111111111111111111111111111111111111111111", "9CfiVNnoI/usF3thZgRmtLv1Pqy6r/Of444AELWsQl90FsILkF2/A3KIKG0qOPVE15Sf+Ignv93CllrLRV7W0DgjND1nKCGSyPZivUdj3M8=")]
        [TestCase("2", "JTQKKpA8M/EsTLFkoZW2Qw==")]
        [TestCase("%$#@!%^&*()+_", "gOZsEqIRhIpe5lmctaN0+g==")]
        public void Encrypt_CallWithValidText(string textToEncrypt, string expected)
        {
            
            var encryptedText = _aesCryptoService.Encrypt(textToEncrypt);

            Assert.AreEqual(expected, encryptedText);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Decrypt_PassNullAndEmptyArgument_ThrowsArgumentNullException(string textToDecrypt)
        {
            Assert.Throws<ArgumentNullException>(() => 
            {
                _aesCryptoService.Decrypt(textToDecrypt);
            });
        }

        [Test]
        [TestCase("OG2IbG9LzasoStvd5g3AGw==", "aaa")]
        [TestCase("9CfiVNnoI/usF3thZgRmtLv1Pqy6r/Of444AELWsQl90FsILkF2/A3KIKG0qOPVE15Sf+Ignv93CllrLRV7W0DgjND1nKCGSyPZivUdj3M8=", "111111111111111111111111111111111111111111111111111111111111111111111")]
        [TestCase("JTQKKpA8M/EsTLFkoZW2Qw==", "2")]
        [TestCase("gOZsEqIRhIpe5lmctaN0+g==", "%$#@!%^&*()+_")]
        public void Descrypt_CallWithValidText(string textToDecrypt, string expected)
        {
            var decryptedText = _aesCryptoService.Decrypt(textToDecrypt);
            Assert.AreEqual(decryptedText, expected);
        }


    }

}

