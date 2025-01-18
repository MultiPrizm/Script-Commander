using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System.IO;

public class IDECore : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private TMP_InputField inputText;
    [SerializeField] private TextMeshProUGUI numText;
    [SerializeField] private string filePath;

    private static IDECore instance;
    private string openedFile;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void SetNumText(List<string> text)
    {
        string numLine = "";

        for(int i = 1; i <= text.Count; i++)
        {
            numLine += i.ToString() + "\n";
        }

        numText.text = numLine;
    }

    public static IDECore GetInstance()
    {
        return instance;
    }

    public void CheckText()
    {
        List<string> textLineList = inputText.text.Split("\n").ToList<string>();

        SetNumText(textLineList);
    }

    public void SaveText()
    {
        if(openedFile != null)
        {
            File.WriteAllText(openedFile, inputText.text);
        }
    }

    public void OpenFile(string file)
    {
        if (File.Exists(file))
        {
            openedFile = file;
            inputText.text = File.ReadAllText(file);
            CheckText();
        }
    }
}
