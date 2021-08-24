using System;
using Bayegan.Storage.Dictionaries;
using NUnit.Framework;

namespace Bayegan.Tests.UnitTests.Storage.Dictionaries
{
    public class PlayerPrefsStorageUnitTests
    {
        private PlayerPrefsStorage _playerPrefsStorage;
        
        [SetUp]
        public void SetUp()
        {
            _playerPrefsStorage = new PlayerPrefsStorage();
        }

        [Test]
        [TestCase("", 1)]
        [TestCase(null, 1)]
        [TestCase("key", null)]
        public void Store_PassInvalidArguments_ThrowsArgumentNullException(string key, IConvertible value)
        {

            Assert.Throws<ArgumentNullException>(()=>
            {
                _playerPrefsStorage.Store(key, value);
            });

        }

        [Test]
        [TestCase("", 1)]
        [TestCase(null, 1)]
        [TestCase("key", null)]
        public void Load_PassInvalidArgumnet_ThrowsArgumentNullException(string key, IConvertible value)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _playerPrefsStorage.Load(key, value);
            });
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void HasKey_InvalidArguments_ThrowsArgumentsNullException(string key)
        {
            Assert.Throws<ArgumentNullException>(() => 
            {
                _playerPrefsStorage.HasKey(key);                
            });
        }
    }
}

