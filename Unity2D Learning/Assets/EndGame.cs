using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EndGame : MonoBehaviour
{
    public void endGame()
    {
        //Application.Quit();
        EditorApplication.isPlaying = false;
    }
}
