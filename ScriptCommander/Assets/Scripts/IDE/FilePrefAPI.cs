using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IDEFilePrefAPI : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private TextMeshProUGUI fileName;
    [SerializeField] private Image icon;
    [SerializeField] private List<Sprite> icons;

    private string filePath;

    public string FilePath => filePath;

    public void SetName(string name)
    {
        filePath = name;

        string[] splitList = name.Split("/");

        fileName.text = splitList[splitList.Length - 1];

        foreach (Sprite sprite in icons)
        {
            splitList = name.Split(".");

            if (sprite.name == splitList[1])
            {
                icon.sprite = sprite;
            }
        }
    }
}
