using UnityEngine;
using TMPro;
using System.IO;

public class IDEFileCreator : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private TMP_InputField input;
    [SerializeField] private TextMeshProUGUI alarmText;
    [SerializeField] private TextMeshProUGUI fomatText;
    [SerializeField] private IDEDirBar iDEDirBar;

    [SerializeField] private string selectFormat;

    public void CreateFile() 
    {
        if (iDEDirBar != null && input != null)
        {
            string[] file = input.text.Split(".");

            if (file.Length == 1)
            {
                Debug.Log($"Data/" + iDEDirBar.PathToDir + input.text + selectFormat);
                File.Create($"Data/" + iDEDirBar.PathToDir + input.text + selectFormat);
                iDEDirBar.ViewDir();
                gameObject.SetActive(false);
            }
            else if (alarmText != null)
            {
                alarmText.text = "<color=red>Format error.</color>";
            }
        }
    }

    public void SetFormat(string format) 
    { 
        selectFormat = format;

        fomatText.text = format;
    }
}
