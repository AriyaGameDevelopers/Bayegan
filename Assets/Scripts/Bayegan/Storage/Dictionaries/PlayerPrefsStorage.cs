using System;
using Bayegan.Exceptions;
using Bayegan.Storage.Abstractions;
using UnityEngine;

namespace Bayegan.Storage.Dictionaries
{
    public class PlayerPrefsStorage : IBayeganDictionary
    {
        private void CheckKeyArgument(string key)
        {
            if(string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public virtual TValue Load<TValue>(string key, TValue defaultValue) where TValue : IConvertible
        {
            LoadCheckArguments(key, defaultValue);

            switch(defaultValue.GetTypeCode())
            {
                case TypeCode.String:
                    return LoadString(key, defaultValue);
                
                case TypeCode.Int32:
                    return LoadInt(key, defaultValue);
                
                case TypeCode.Byte:
                    return LoadByte(key, defaultValue);
                
                case TypeCode.Int16:
                    return LoadShort(key, defaultValue);
                
                case TypeCode.Single:
                    return LoadFloat(key, defaultValue);
                
                case TypeCode.Boolean:
                    return LoadBool(key, defaultValue);

                default:
                    throw new TypeNotSupportedException(defaultValue.GetTypeCode());
            }
        }

        protected void LoadCheckArguments<TValue>(string key, TValue defaultValue) where TValue : IConvertible
        {
            CheckKeyArgument(key);
            if(defaultValue == null)
            {
                throw new ArgumentNullException(nameof(defaultValue));
            }
            
        }

        protected TValue LoadString<TValue>(string key, TValue defaultValue)
        {
            var loadedStringValue = PlayerPrefs.GetString(key);
            
            if(string.IsNullOrEmpty(loadedStringValue))
                return defaultValue;

            return (TValue) Convert.ChangeType(loadedStringValue, typeof(TValue));
        }

        private TValue LoadInt<TValue>(string key, TValue defaultValue)
        {
            var defaultValueInt = Convert.ToInt32(defaultValue);

            var loadedIntValue = PlayerPrefs.GetInt(key, defaultValueInt);

            return (TValue) Convert.ChangeType(loadedIntValue, typeof(TValue));
        }

        private TValue LoadByte<TValue>(string key, TValue defaultValue)
        {
            var defaultValueByte = Convert.ToByte(defaultValue);

            var loadedByteValue = PlayerPrefs.GetInt(key, defaultValueByte);

            return (TValue) Convert.ChangeType(loadedByteValue, typeof(TValue));
        }

        private TValue LoadShort<TValue>(string key, TValue defaultValue)
        {
            var defaultValueShort = Convert.ToInt16(defaultValue);

            var loadedShortValue = PlayerPrefs.GetInt(key, defaultValueShort);

            return (TValue) Convert.ChangeType(loadedShortValue, typeof(TValue));
        }

        private TValue LoadFloat<TValue>(string key, TValue defaultValue)
        {
            var defaultValueFloat = Convert.ToSingle(defaultValue);

            var loadedFloatValue = PlayerPrefs.GetFloat(key, defaultValueFloat);
            return (TValue) Convert.ChangeType(loadedFloatValue, typeof(TValue));
        }

        private TValue LoadBool<TValue>(string key, TValue defaultValue)
        {
            var defaultValueInt = Convert.ToBoolean(defaultValue) ? 1 : 0; 
            
            var loadedBoolValue = PlayerPrefs.GetInt(key, defaultValueInt) == 1;
            return (TValue) Convert.ChangeType(loadedBoolValue, typeof(TValue));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <typeparam name="TValue"></typeparam>
        /// <exception cref="TypeNotSupportedException"></exception>
        public virtual void Store<TValue>(string key, TValue value) where TValue : IConvertible
        {
            StoreCheckArguments(key, value);

            switch(value.GetTypeCode())
            {
                case TypeCode.String:
                    StoreStringValue(key, value);
                    return;

                case TypeCode.Int32:
                    StoreIntValue(key, value);
                    return;

                case TypeCode.Byte:
                    StoreByteValue(key, value);
                    return;

                case TypeCode.Int16:
                    StoreShortValue(key, value);
                    return;

                case TypeCode.Single:
                    StoreFloatValue(key, value);
                    return;

                case TypeCode.Boolean:
                    StoreBooleanValue(key, value);
                    return;

                default:
                    throw new TypeNotSupportedException(value.GetTypeCode());
            } 
        }

        protected void StoreCheckArguments<TValue>(string key, TValue value) where TValue : IConvertible
        {
            CheckKeyArgument(key);
            if(value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            if(value.GetTypeCode() == TypeCode.String && string.IsNullOrEmpty(value.ToString()))
            {
                throw new ArgumentNullException(nameof(value));
            }
                
        }

        private void StoreByteValue<TValue>(string key, TValue value)
        {
            var byteValue = Convert.ToByte(value);
            PlayerPrefs.SetInt(key, byteValue);
        }

        private void StoreShortValue<TValue>(string key, TValue value)
        {
            var intValue = Convert.ToInt16(value);
            PlayerPrefs.SetInt(key, intValue);
        }

        private void StoreIntValue<TValue>(string key, TValue value)
        {
            var intValue = Convert.ToInt32(value);
            PlayerPrefs.SetInt(key, intValue);
        }

        private void StoreStringValue<TValue>(string key, TValue value)
        {
            var stringValue = Convert.ToString(value);
            PlayerPrefs.SetString(key, stringValue);
        }

        private void StoreFloatValue<TValue>(string key, TValue value)
        {
            var floatValue = Convert.ToSingle(value);
            PlayerPrefs.SetFloat(key, floatValue);
        }

        private void StoreBooleanValue<TValue>(string key, TValue value)
        {
            var booleanValue = Convert.ToBoolean(value);
            var intValue = booleanValue ? 1 : 0;
            PlayerPrefs.SetInt(key, intValue); 
        }

        public void DeleteAll()
        {
            PlayerPrefs.DeleteAll();
        }

        public void DeleteKey(string key)
        {
            CheckKeyArgument(key);
            
            PlayerPrefs.DeleteKey(key);
        }

        public bool HasKey(string key)
        {
            CheckKeyArgument(key);

            return PlayerPrefs.HasKey(key);
        }
    }
}

