using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using Studio23.SS2.SaveSystem.Interfaces;
using UnityEngine;


public class ItemDataBehaviour : MonoBehaviour, ISaveable
{
    [SerializeField]
    private string _uniqueID;

    [SerializeField]
    private bool _isDirty;

    public bool IsDirty
    {
        get
        {
            return _isDirty;
        }
        set
        {
            _isDirty = value;
        }
    }

    public ItemData itemData;


    public string GetUniqueID()
    {
        return _uniqueID;
    } 

    public UniTask AssignSerializedData(string data)
    {
        itemData = JsonConvert.DeserializeObject<ItemData>(data);
        return new UniTask();
    }

    public UniTask<string> GetSerializedData()
    {
        return new UniTask<string>(JsonConvert.SerializeObject(itemData));
    }

}
