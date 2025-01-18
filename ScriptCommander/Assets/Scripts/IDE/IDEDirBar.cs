using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class IDEDirBar : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private string pathToDir;
    [SerializeField] private GameObject barContent;
    [SerializeField] private IDECore core;

    [Header("Prefabs")]
    [SerializeField] private List<FilePrefabWrapper> prefabsList = new List<FilePrefabWrapper>();

    private Dictionary<string, GameObject> prefabsDict = new Dictionary<string, GameObject>();

    public string PathToDir => pathToDir;

    private void Start()
    {
        foreach (FilePrefabWrapper prefab in prefabsList) 
        {
            prefabsDict.Add(prefab.FileExtension, prefab.Prefab);
        }
        ViewDir();
    }

    public void ViewDir()
    {
        string[] files = Directory.GetFiles($"Data/{pathToDir}");

        foreach (string file in files)
        {
            string[] fileInfo = file.Split(".");

            if (prefabsDict.ContainsKey(fileInfo[1]) && fileInfo.Length == 2) 
            {
                GameObject pref = Instantiate(prefabsDict[fileInfo[1]], barContent.transform);

                pref.SetActive(true);

                IDEFilePrefAPI prefApi = pref.GetComponent<IDEFilePrefAPI>();

                if (prefApi != null)
                {
                    prefApi.SetName(file);
                }

                Button button = pref.GetComponent<Button>();

                if (button != null)
                {
                    button.onClick.AddListener(() => core.OpenFile(file));
                }
            }
            
        }
    }
}
