using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EndGame : MonoBehaviour
{
    public void GameEnd()
    {
        //Application.Quit();
        EditorApplication.isPlaying = false;
    }
}
