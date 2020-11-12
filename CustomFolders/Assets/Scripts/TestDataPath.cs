using GameAnalyticsSDK;
using UnityEditor;
using UnityEngine;

public class TestDataPath : MonoBehaviour
{
    [MenuItem("Tools/Show Data Path")]
    public static void ShowDataPath()
    {
        Debug.Log(Application.dataPath);
    }

    private void Start()
    {
        GameAnalytics.Initialize();
    }
}
