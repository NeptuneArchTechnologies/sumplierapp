using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Essentials;
using System.IO;

namespace sumplierapp.LocalDatabase
{
    public class DataStorage
    {
        private static DataStorage _instance;
        private static readonly object _lock = new object();

        public static DataStorage Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new DataStorage();
                    }
                }
                return _instance;
            }
        }

        private DataStorage() { }

        // ✅ Save a model kaydet ...
        public void SaveModel<T>(string key, T model)
        {
            string json = JsonConvert.SerializeObject(model);
            Preferences.Set(key, json);
        }

        // ✅ Get a model...
        public T GetModel<T>(string key)
        {
            string json = Preferences.Get(key, null);
            return json == null ? default(T) : JsonConvert.DeserializeObject<T>(json);
        }

        // ✅ Save List...
        public void SaveList<T>(string key, List<T> list)
        {
            string json = JsonConvert.SerializeObject(list);
            Preferences.Set(key, json);
        }

        // ✅ Get List...
        public List<T> GetList<T>(string key)
        {
            string json = Preferences.Get(key, null);
            return json == null ? new List<T>() : JsonConvert.DeserializeObject<List<T>>(json);
        }

        // ✅ Veriyi temizle
        public void Remove(string key)
        {
            Preferences.Remove(key);
        }

        // ✅ Tüm verileri temizle
        public void ClearAll()
        {
            Preferences.Clear();
        }
    }
}
