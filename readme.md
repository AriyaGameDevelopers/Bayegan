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
or

you can use **Bayegan Default Encryption** for more security. 
for generate secure **key** and **iv** you can use  [Perfect Passwords](https://www.grc.com/passwords.htm)
```
var encryptionKey = "encryption key length must be 32 char";
var iv = "iv key length must be 16 char";

var bayeganDictionary = new BayeganDictionaryBuilder()
                        .UseDefaultSecurePlayerPrefs(encryptionKey, iv)
                        .Build();
```
or

you can write own custom encryption. create a class and implement `ICryptoService` interface.
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
and use it in:
```
var bayeganDictionary = new BayeganDictionaryBuilder()
                        .UseCustomSecurePlayerPrefs(new CustomCrypto())
                        .Build();
```

for store your data:
```
bayeganDictionary.Store(key, value);
```
and load your data:
```
var value = bayeganDictionary.Load(key, defaultValue);
```

## ToDo
- [ ] Default value unit/integration test
- [ ] Document
- [ ] Add sqlite