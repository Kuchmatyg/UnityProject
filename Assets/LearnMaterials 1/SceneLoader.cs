using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string[] scenesToLoad; // ����� ���� ��� ��������

    void Start()
    {
        LoadScenesAdditively();
    }

    void LoadScenesAdditively()
    {
        foreach (var sceneName in scenesToLoad)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
    }
}
