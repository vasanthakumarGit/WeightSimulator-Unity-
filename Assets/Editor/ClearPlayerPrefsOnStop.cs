using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class ClearPlayerPrefsOnStop
{
    static ClearPlayerPrefsOnStop()
    {
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
    }

    private static void OnPlayModeStateChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingPlayMode)
        {
            // Clear PlayerPrefs when exiting play mode
            PlayerPrefs.DeleteAll();
        }
    }
}
