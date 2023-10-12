using System.IO;
using Cysharp.Threading.Tasks;
using Steamworks;
using UnityEngine;

namespace  Studio23.SS2.SaveSystem.Cloud
{
    public class CloudSaveManager : MonoBehaviour
    {

        public string TargetPath;
        [SerializeField] private string _steamFileKey = "CloudData";


        private async UniTask OnApplicationQuit()
        {
            if (enabled) await SaveCloudDataOnSteam();
        }



        private async UniTask<byte[]> ReadFileToByteArray()
        {
            var filePath = Path.Combine(Application.persistentDataPath, TargetPath);


            if (File.Exists(filePath)) return await File.ReadAllBytesAsync(filePath);
            Debug.LogError("File does not exist: " + filePath);
            return null;
        }


        private async UniTask SaveCloudDataOnSteam()
        {
            byte[] saveData = await ReadFileToByteArray();

            if (SteamRemoteStorage.FileWrite(_steamFileKey, saveData))
                Debug.Log("Data Saved on Steam Cloud successfully");
            else
                Debug.LogError("Failed to save cloud data");
        }


        private async UniTask LoadCloudData()
        {
            var data = SteamRemoteStorage.FileRead(_steamFileKey);

            await File.WriteAllBytesAsync(Path.Combine(Application.persistentDataPath, TargetPath), data);
        }
    }
}

