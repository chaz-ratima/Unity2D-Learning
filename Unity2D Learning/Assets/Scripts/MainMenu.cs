using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Quit game, get game object, input no variable
    EndGame quitGame;

    //Load Level, get game object, input variable
    LoadLevel levelLoader;
    [SerializeField] GameObject nextScene;

    void Awake()
    {
        //Quit Game
        GameObject gameEnder = GameObject.FindWithTag("EndGame");
        quitGame = gameEnder.GetComponent<EndGame>();
    }

    void Start()
    {
        levelLoader = nextScene.GetComponent<LoadLevel>();
    }

    void PlayGame()
    {
        levelLoader.LoadNextScene();
    }

    void GameQuit()
    {
        quitGame.GameEnd();
    }

}
