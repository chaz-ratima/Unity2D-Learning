using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    public string myScene = "";
    public void LoadNextScene()
    {
        SceneManager.LoadScene(myScene);
    }
}
