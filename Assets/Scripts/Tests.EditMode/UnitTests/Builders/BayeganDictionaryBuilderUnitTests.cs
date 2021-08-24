

using System;
using Bayegan.Builder;
using NUnit.Framework;

namespace Bayegan.Tests.UnitTests.Builders
{
    public class BayeganDictionaryBuilderUnitTests 
    {
        private BayeganDictionaryBuilder _builder;


        [SetUp]
        public void Setup()
        {
            _builder = new BayeganDictionaryBuilder();
        }

        [Test]
        public void UseCustomSecurePlayerPrefs_PassNullArgument_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => 
            {
                _builder.UseCustomSecurePlayerPrefs(null);
            });
        }
        
    }

}

