using UnityEditor;
using UnityEngine;

namespace Studio23.SS2.SaveSystem.Cloud.Editor
{
    public class SteamCloudSaveInstaller : EditorWindow
    {
        [MenuItem("Studio-23/Save System/Install Steam Cloud")]
        public static void ShowWindow()
        {
            // Get the existing open window or if none, create a new one
            var window = GetWindow<SteamCloudSaveInstaller>("Steam Cloud Installer");
            window.minSize = new Vector2(250, 100);
        }

        private void OnGUI()
        {
            GUILayout.Label("Install Steam Cloud Save", EditorStyles.boldLabel);

            if (GUILayout.Button("Install"))
            {
                // Create an empty GameObject
                var gameObject = new GameObject("SteamCloudSaveManager");
                Selection.activeObject = gameObject;

                // Attach this script to the new GameObject
                SaveSystemSteamCloudBehaviour script = gameObject.AddComponent<SaveSystemSteamCloudBehaviour>();

            }
        }
    }
}
