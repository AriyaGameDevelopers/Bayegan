using Bayegan.Builder;
using NUnit.Framework;
using UnityEngine;

namespace Bayegan.Tests.IntegrationTests.Builders
{
    public class BayeganDictionaryBuilderIntegrationTests 
    {
        private BayeganDictionaryBuilder _builder;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _builder = new BayeganDictionaryBuilder();
            
        }


        [Test]
        public void Build_UsePlayerPrefsByDefault()
        {
            var baygan = _builder.Build();
            
            var key = "key";
            var value = "value";

            baygan.Store(key, value);

            var actualValue = PlayerPrefs.GetString(key);
            PlayerPrefs.DeleteKey(key);
            Assert.AreEqual(value, actualValue);
        }

    }
}