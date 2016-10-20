using UnityEngine;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
public class GameData : MonoBehaviour {
    private static Dictionary<string, object> dataItems;

    public static T get<T>(string key) {
        //try to load from file
        if(dataItems== null) {
            load();
        }
        //if load from file failed, instantiate a new data map
        if(dataItems== null) {
            dataItems = new Dictionary<string, object>();
        }
        if (!dataItems.ContainsKey(key)) {
            return default(T);
        }
        try {
            return (T)(dataItems[key]);
        } catch (InvalidCastException e) {
            return default(T);
        }
    }

    public static void put(string key, object o) {
        if(dataItems== null) {
            dataItems = new Dictionary<string, object>();
        }
        dataItems[key] = o;
        save();
    }

    public static void save() {
		try{
	        BinaryFormatter bf = new BinaryFormatter();
	        FileStream file = File.Create(Application.persistentDataPath + "/gameData.dat");

	        Data data = new Data();
	        data.dataItems = dataItems;

	        bf.Serialize(file, data);
	        file.Close();
		}catch(Exception e){
			Debug.LogError (e);
		}
    }

    public static void load() {
		try{
	        if (File.Exists(Application.persistentDataPath + "/gameData.dat")) {
	            BinaryFormatter bf = new BinaryFormatter();
	            FileStream file = File.Open(Application.persistentDataPath + "/gameData.dat", FileMode.Open);
	            Data data = (Data)bf.Deserialize(file);
	            file.Close();

	            dataItems = data.dataItems;
	        }
		}catch(Exception e){
			Debug.LogError (e);
		}
    }

    [Serializable]
    class Data {
        public Dictionary<string, object> dataItems;

    }
}
