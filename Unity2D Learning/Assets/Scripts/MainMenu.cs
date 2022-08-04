using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    EndGame quitGame;
    LoadLevel levelLoader;
    [SerializeField] GameObject nextScene;

    void Awake()
    {
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
