using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Steamworks;
using Studio23.SS2.CloudSave.Data;

namespace Studio23.SS2.SaveSystem.Steam.Data
{
    //TODO: Probably need to utilize steamworks.net and convert C++ callbacks to async await
    public class SteamCloudSaveProvider : AbstractCloudSaveProvider
    {
        protected override UniTask<int> Initialize()
        {
            //DO nothhing
            return new UniTask<int>(0);
        }

        protected override UniTask<int> UploadToCloud(string slotName, string key, byte[] data)
        {
            if (SteamRemoteStorage.FileWrite($"{slotName}_{key}", data))
            {
                return new UniTask<int>(0);
            }

            return new UniTask<int>(-1);
        }

        protected override UniTask<byte[]> DownloadFromCloud(string slotName, string key)
        {
            byte[] data= SteamRemoteStorage.FileRead($"{slotName}_{key}");
            return new UniTask<byte[]>(data);
        }

        protected override async UniTask<Dictionary<string, byte[]>> DownloadFromCloud(string slotName, string[] keys)
        {
            Dictionary<string, byte[]> saveDatas= new Dictionary<string, byte[]>();


            foreach (var key in keys)
            {
                //TODO: Check if it should be Key or slotname+key
                saveDatas[key] = await DownloadFromCloud(slotName, key);
            }

            return saveDatas;

        }

        protected override UniTask<int> DeleteSlotFromCloud(string slotName)
        {
            IEnumerable<string> slotItems = SteamRemoteStorage.Files.Where(r => r.Contains(slotName));

            foreach (var item in slotItems)
            {
                if (!SteamRemoteStorage.FileDelete(item))
                {
                    return new UniTask<int>(-1);
                }
            }

            return new UniTask<int>(0);
        }
    }
}

