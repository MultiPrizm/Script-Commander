using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FilePrefConfig", menuName = "IDE/FilePrefConfig", order = 1)]
public class FilePrefabWrapper : ScriptableObject
{
    [Header("General")]
    [SerializeField] private GameObject prefab;
    [SerializeField] private string fileExtension;

    public GameObject Prefab => prefab;
    public string FileExtension => fileExtension;
}
