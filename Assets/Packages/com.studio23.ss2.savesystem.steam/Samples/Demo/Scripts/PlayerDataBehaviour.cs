using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using Studio23.SS2.SaveSystem.Interfaces;
using UnityEngine;

public class PlayerDataBehaviour : MonoBehaviour,ISaveable
{

    public string _uniqueID;
    public PlayerData playerData;

    [SerializeField]
    private bool _isDirty;

    public bool IsDirty { 
        get 
        { 
            return _isDirty;
        } 
        set 
        {
            _isDirty = value;
        } 
    }

    public string GetUniqueID()
    {
        return _uniqueID;
    }

    public UniTask AssignSerializedData(string data)
    {
        playerData = JsonConvert.DeserializeObject<PlayerData>(data);
        return new UniTask();
    }

    public UniTask<string> GetSerializedData()
    {
        return new UniTask<string>(JsonConvert.SerializeObject(playerData));
    }


}
