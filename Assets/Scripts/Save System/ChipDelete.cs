using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class ChipDelete : MonoBehaviour
{
    new string name;
    const string fileExtension = ".txt";
    Manager _manager;
    public GameObject deleteConfirmation;
    public TextMeshProUGUI confirmText;

    void Start() {
        _manager = GameObject.FindWithTag("Manager").GetComponent<Manager>();
    }

    public void ConfirmDelete(string _name) {
        deleteConfirmation.SetActive(true);
        confirmText.text = "Do you want to delete chip:" + "\n" + _name + "\n" + "If it used in other chips," + "\n" + "it can break this project";
        name = _name;
    }

    public void DeleteLocal()
    {
        string deletePath = SaveSystem.GetPathToSaveFile(name);
        string wireDeletePath = SaveSystem.GetPathToWireSaveFile(name);
        DeleteFile(deletePath);
        DeleteFile(wireDeletePath);
    }
   
    public void DeleteGlobal()
    {
        string deleteGlobalPath = SaveSystem.GetPathToGlobalSaveFile(name);
        string wireDeleteGlobalPath = SaveSystem.GetPathToGlobalWireSaveFile(name);

        DeleteFile(deleteGlobalPath);
        DeleteFile(wireDeleteGlobalPath);

        DeleteLocal();
    }

    void DeleteFile(string path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
            _manager.RefreshAll();
        }
    }
}
