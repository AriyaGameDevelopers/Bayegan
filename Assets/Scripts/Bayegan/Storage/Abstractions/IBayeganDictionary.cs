
using System;

namespace Bayegan.Storage.Abstractions
{
    public interface IBayeganDictionary 
    {
        void Store<TValue>(string key, TValue value) where TValue : IConvertible;

        TValue Load<TValue>(string key, TValue defaultValue) where TValue : IConvertible;

        void DeleteAll();

        void DeleteKey(string key);

        bool HasKey(string key);
    }
}

