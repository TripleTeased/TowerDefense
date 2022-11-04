using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Inherit from this base class to create a singleton.
/// This class is a variation of Unity Community's Singleton, but with the ability to destroy.
/// e.g. public class MyClassName : Singleton<MyClassName> {}
/// </summary>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // Check to see if we're about to be destroyed.
    private static object m_Lock = new object();
    private static T m_Instance;
    private static bool _destroyed;

    /// <summary>
    /// Access singleton instance through this propriety.
    /// </summary>
    public static T Instance
    {
        get
        {
            if (_destroyed)
            {
                return null;
            }

            lock (m_Lock)
            {
                if (m_Instance == null)
                {
                    // Search for existing instance.
                    var MatchObjects = new List<T>();

                    // Go through each loaded scene in the hierarchy
                    for (int i = 0; i < UnityEngine.SceneManagement.SceneManager.sceneCount; i++)
                    {
                        // Go through each root game object
                        var RootObjects = UnityEngine.SceneManagement.SceneManager.GetSceneAt(i).GetRootGameObjects();
                        foreach (var ro in RootObjects)
                        {
                            // Search for all objects of type T
                            var Matches = ro.GetComponentsInChildren<T>(true);
                            MatchObjects.AddRange(Matches);
                        }
                    }

                    // Set instance
                    m_Instance = MatchObjects.FirstOrDefault();

                    // Create new instance if one doesn't already exist.
                    if (m_Instance == null)
                    {
                        // Need to create a new GameObject to attach the singleton to.
                        GameObject singletonObject = new GameObject(typeof(T).ToString() + " (Singleton)");
                        m_Instance = singletonObject.AddComponent<T>();
                    }
                }

                return m_Instance;
            }
        }
    }

    void OnEnable()
    {
        // When a new scene is loaded, allow for singletons to be retrieved
        SceneManager.sceneLoaded += (_, x) => _destroyed = false;
    }

    protected virtual void OnDestroy()
    {
        _destroyed = true;
        m_Instance = null;
    }
}
