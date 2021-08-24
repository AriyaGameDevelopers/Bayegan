
using Bayegan.Storage.Dictionaries;
using NUnit.Framework;
using UnityEngine;

namespace Bayegan.Tests.IntegrationTests.Storage.Dictionaries
{
    public class PlayerPrefsStorageIntegrationTests 
    {
        private PlayerPrefsStorage _playerPrefsStorage;

        [OneTimeSetUp]
        public void Setup()
        {
            _playerPrefsStorage = new PlayerPrefsStorage();
        }

        [Test]
        [TestCase(" ")]
        [TestCase("11111111111111111111111111111111111111111111")]
        [TestCase("Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi.")]
        public void Store_StringValue_StoreValueWithKey(string value)
        {
            var key = "key";

            _playerPrefsStorage.Store(key, value);

            var actualValue = PlayerPrefs.GetString(key);

            PlayerPrefs.DeleteKey(key);

            Assert.AreEqual(value, actualValue);
        }

        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(32767)]// short max value
        [TestCase(-32768)]// short min value
        public void Store_ShortValue_StoreValueWithKey(short value)
        {
            var key = "key";

            _playerPrefsStorage.Store(key, value);

            var actualValue = PlayerPrefs.GetInt(key);

            PlayerPrefs.DeleteKey(key);

            Assert.AreEqual(value, actualValue);
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(2147483647)]
        [TestCase(-2147483648)]
        public void Store_IntValue_StoreValueWithKey(int value)
        {
            var key = "key";
            
            _playerPrefsStorage.Store(key, value);

            var actualValue = PlayerPrefs.GetInt(key);

            PlayerPrefs.DeleteKey(key);

            Assert.AreEqual(value, actualValue);
        }

        [Test]
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(255)]
        public void Store_ByteValue_StoreValueWithKey(byte value)
        {
            var key = "key";
            
            _playerPrefsStorage.Store(key, value);

            var actualValue = PlayerPrefs.GetInt(key);

            PlayerPrefs.DeleteKey(key);

            Assert.AreEqual(value, actualValue);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(3.40282347E+38f)]
        [TestCase(-3.40282347E+38f)]
        public void Store_FloatValue_StoreValueWithKey(float value)
        {
            var key = "key";

            _playerPrefsStorage.Store(key, value);

            var actualValue = PlayerPrefs.GetFloat(key);

            PlayerPrefs.DeleteKey(key);

            Assert.AreEqual(value, actualValue);
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void Store_BooleanValue_StoreValueWithKey(bool value)
        {
            var key = "key";
            
            _playerPrefsStorage.Store(key, value);

            var actualValue = PlayerPrefs.GetInt(key) == 1;

            PlayerPrefs.DeleteKey(key);

            Assert.AreEqual(value, actualValue);
        }

        [Test]
        public void Delete_PassExistKey_DeleteKeyAndValue()
        {
            var stringKey = "string key";
            var stringValue = "value";
            
            PlayerPrefs.SetString(stringKey, stringValue);
            _playerPrefsStorage.DeleteKey(stringKey);

            Assert.IsFalse(PlayerPrefs.HasKey(stringKey));


            var intKey = "int key";
            var intValue = int.MinValue;

            PlayerPrefs.SetInt(intKey, intValue);
            _playerPrefsStorage.DeleteKey(intKey);

            Assert.IsFalse(PlayerPrefs.HasKey(intKey));

            var booleanKey = "boolean key";

            PlayerPrefs.SetInt(booleanKey, 1);
            _playerPrefsStorage.DeleteKey(booleanKey);
            Assert.IsFalse(PlayerPrefs.HasKey(booleanKey));

        }

        [Test]
        public void DeleteAll_RemoveAllData()
        {
            var stringKey = "string key";
            var stringValue = "value";
            PlayerPrefs.SetString(stringKey, stringValue);
        
            var intKey = "int key";
            var intValue = int.MinValue;
            PlayerPrefs.SetInt(intKey, intValue);

            var booleanKey = "boolean key";
            PlayerPrefs.SetInt(booleanKey, 1);

            _playerPrefsStorage.DeleteAll();

            Assert.IsFalse(PlayerPrefs.HasKey(booleanKey));
            Assert.IsFalse(PlayerPrefs.HasKey(intKey));
            Assert.IsFalse(PlayerPrefs.HasKey(stringKey));
        }

        [Test]
        public void HasKey_Call_ReturnTrue()
        {
            var key = "key";
            
            PlayerPrefs.SetInt(key, 0);
            var result = _playerPrefsStorage.HasKey(key);
            
            PlayerPrefs.DeleteKey(key);

            Assert.IsTrue(result);
        }

        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(32767)]// short max value
        [TestCase(-32768)]// short min value
        public void Load_ShortValue(short value)
        {
            var key = "key";
            PlayerPrefs.SetInt(key, value);
            short defaultValue = 0;

            var actualValue = _playerPrefsStorage.Load(key, defaultValue);

            PlayerPrefs.DeleteKey(key);

            Assert.AreEqual(value, actualValue);
        }

        [Test]
        [TestCase(" ")]
        [TestCase("11111111111111111111111111111111111111111111")]
        [TestCase("Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi.")]
        public void Load_StringValue(string value)
        {
            var key = "key";
            PlayerPrefs.SetString(key, value);

            var actualValue = _playerPrefsStorage.Load(key, string.Empty);

            PlayerPrefs.DeleteKey(key);

            Assert.AreEqual(value, actualValue);
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(2147483647)]
        [TestCase(-2147483648)]
        public void Load_IntValue(int value)
        {
            var key = "key";
            PlayerPrefs.SetInt(key, value);

            var actualValue = _playerPrefsStorage.Load(key, 0);
            
            PlayerPrefs.DeleteKey(key);

            Assert.AreEqual(value, actualValue);
        }

        [Test]
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(255)]
        public void Load_ByteValue(byte value)
        {
            var key = "key";
            PlayerPrefs.SetInt(key, value);
            byte defaultValue = 0;

            var actualValue = _playerPrefsStorage.Load(key, defaultValue);

            PlayerPrefs.DeleteKey(key);

            Assert.AreEqual(value, actualValue);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(3.40282347E+38f)]
        [TestCase(-3.40282347E+38f)]
        public void Load_FloatValue(float value)
        {
            var key = "key";
            PlayerPrefs.SetFloat(key, value);
            float defaultValue = 0f;

            var actualValue = _playerPrefsStorage.Load(key, defaultValue);
            
            PlayerPrefs.DeleteKey(key);

            Assert.AreEqual(value, actualValue);
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void Load_Boolean(bool value)
        {
            var key = "key";
            PlayerPrefs.SetInt(key, value ? 1 : 0);

            var actualValue = _playerPrefsStorage.Load(key, false);

            PlayerPrefs.DeleteKey(key);
            
            Assert.AreEqual(value, actualValue);
        }
    }
}

