using System;
using System.IO;
using Cysharp.Threading.Tasks;
using Steamworks;
using UnityEngine;

namespace  Studio23.SS2.SaveSystem.Cloud
{
    public class SaveSystemSteamCloudBehaviour : MonoBehaviour
    {

        [SerializeField]private bool _enableSteamCloud = true;
        [SerializeField] private int _steamAppID = 4000;
        private string _saveBundlePath => Core.SaveSystem.Instance.SaveBundlePath;
        [SerializeField]private string _steamFileKey = "cloudSave";

        public async void Start ()
        {
            if (!_enableSteamCloud) return;

            try
            {
                SteamClient.Init(4000);
                await LoadCloudData();
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }

        public void OnEnable()
        {
            if (!_enableSteamCloud) return;
            Core.SaveSystem.Instance.OnBundleComplete +=async ()=> await SaveCloudDataOnSteam();
        }

       
        private async UniTask<byte[]> ReadFileToByteArray()
        {
            
            if (File.Exists(_saveBundlePath)) return await File.ReadAllBytesAsync(_saveBundlePath);
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
            byte[] data = SteamRemoteStorage.FileRead(_steamFileKey);

            if(data == null) return;
            await UniTask.RunOnThreadPool(()=>File.Delete(_saveBundlePath));
            await File.WriteAllBytesAsync(_saveBundlePath, data);

            await Core.SaveSystem.Instance.UnBundleSaveFiles();
        }
    }
}

