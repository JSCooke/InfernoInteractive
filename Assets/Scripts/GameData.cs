using UnityEngine;
using System.Collections.Generic;
using System;

public class GameData : MonoBehaviour {
    private static Dictionary<string, object> dataItems;

    public static T get<T>(string key) {
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
    }
}
