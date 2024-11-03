using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;
    private static object _lock = new object();

    private static bool applicationIsQuitting = false;

    public static T Instance
    {
        get
        {
            if(applicationIsQuitting) return null;

            lock (_lock)
            {
                if(_instance == null)
                {
                    _instance = FindObjectOfType<T>();

                    if(FindObjectsOfType<T>().Length > 1)
                    {
                        Debug.LogError("There should be only one instance of Singleton");
                        return _instance;
                    }

                    if(_instance == null)
                    {
                        GameObject singleton = new GameObject();
                        _instance = singleton.AddComponent<T>();
                    }
                }

                return _instance;
            }
        }
    }
    private static bool IsDontDestroyOnLoad()
    {
        if(_instance == null) return false;
        if((_instance.gameObject.hideFlags & HideFlags.DontSave) == HideFlags.DontSave) return true;

        return false;
    }

    private void OnDestroy()
    {
        if(IsDontDestroyOnLoad())
        {
            applicationIsQuitting = true;
        }
    }
}
