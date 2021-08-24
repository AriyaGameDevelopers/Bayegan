using System;
using Bayegan.Services.Abstractions;
using Bayegan.Services.Cryptography.Aes;
using Bayegan.Storage.Abstractions;
using Bayegan.Storage.Dictionaries;

namespace Bayegan.Builder
{
    public class BayeganDictionaryBuilder 
    {
        private IBayeganDictionary _bayeganDictunary;
		
		public IBayeganDictionary Build()
		{
			if(_bayeganDictunary == null)
				return UsePlayerPrefs().Build();
			
			return _bayeganDictunary;
		}

		public BayeganDictionaryBuilder UsePlayerPrefs()
		{
			_bayeganDictunary = new PlayerPrefsStorage();
			return this;
		}

		public BayeganDictionaryBuilder UseDefaultSecurePlayerPrefs(string encryptionKey, string iv)
		{
			_bayeganDictunary = new SecurePlayerPrefsStorage(new AesCryptoService(encryptionKey, iv));
			return this;
		}

		public BayeganDictionaryBuilder UseCustomSecurePlayerPrefs(ICryptoService cryptoService)
		{
			if(cryptoService == null)
				throw new ArgumentNullException(nameof(cryptoService));
			
			_bayeganDictunary = new SecurePlayerPrefsStorage(cryptoService);
			return this;
		}   
    }
}