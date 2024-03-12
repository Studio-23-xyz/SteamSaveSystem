using System.IO;
using Studio23.SS2.SaveSystem.Steam.Data;
using UnityEditor;
using UnityEngine;

namespace Studio23.SS2.SaveSystem.Cloud.Editor
{
    public class SteamCloudSaveInstaller : EditorWindow
    {
        [MenuItem("Studio-23/Save System/CloudProviders/Create Steam Provider")]
        static void CreateDefaultProvider()
        {
            SteamCloudSaveProvider providerSettings = ScriptableObject.CreateInstance<SteamCloudSaveProvider>();

            // Create the resource folder path
            string resourceFolderPath = "Assets/Resources/SaveSystem/CloudProviders";

            if (!Directory.Exists(resourceFolderPath))
            {
                Directory.CreateDirectory(resourceFolderPath);
            }

            // Create the ScriptableObject asset in the resource folder
            string assetPath = resourceFolderPath + "/CloudSaveProvider.asset";
            AssetDatabase.CreateAsset(providerSettings, assetPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            Debug.Log("Default Cloud Provider created at: " + assetPath);
        }
    }
}
