using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class IDEAdditionalMenuAPIDirBarItem : MonoBehaviour, IIDEAdditionalMenuAPI
{
    [SerializeField] private IDEFilePrefAPI fileAPI;
    [SerializeField] private GameObject cancelItemPref;

    private List<AdditionalMenuItem> additionalMenuItems = new List<AdditionalMenuItem>();

    private void Start()
    {
        additionalMenuItems.Add(new AdditionalMenuItem { pref = cancelItemPref, click = () => { File.Delete(fileAPI.FilePath); } });
    }

    public List<AdditionalMenuItem> GetItems() 
    {
        return additionalMenuItems;
    }
}
