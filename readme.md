# Bayegan - Unity Storage Library

## How To Use

first import 
```
using Bayegan.Builder;
```

build player prefs base storage dictionary:
```
var bayeganDictionary = new BayeganDictionaryBuilder()
                            .Build();
```

build "AesCrypto" base encryption storage dictionary:
```
var encryptionKey = "encryption key length must be 32 char";
var iv = "iv key length must be 16 char";

var bayeganDictionary = new BayeganDictionaryBuilder()
                        .UseDefaultSecurePlayerPrefs(encryptionKey, iv)
                        .Build();
```

build custom encryption storage dictionary:
```
using Bayegan.Services.Abstractions.ICryptoService;

class CustomCrypto : ICryptoService
{
    public string Encrypt(string textEncrypt)
    {

    }

    public string Decrypt(string textToDecrypt)
    {

    }

}

```
```
var bayeganDictionary = new BayeganDictionaryBuilder()
                        .UseCustomSecurePlayerPrefs(new CustomCrypto())
                        .Build();
```

Store:
```
bayeganDictionary.Store(key, value);
```
Load:
```
var value = bayeganDictionary.Load(key, defaultValue);
```

## ToDo
- [ ] Default value unit/integration test
- [ ] Document
- [ ] Add sqlite