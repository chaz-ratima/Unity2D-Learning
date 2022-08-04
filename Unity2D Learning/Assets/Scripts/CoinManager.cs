using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{   
    LoadLevel levelLoader;
    [SerializeField] GameObject nextScene;
    [SerializeField] private AudioSource winningSoundEffect;

    public static CoinManager instance;
    public TextMeshProUGUI text;
    public int coinCount = 10;

    // Start is called before the first frame update
    void Start()
    {   
        levelLoader = nextScene.GetComponent<LoadLevel>();

        if(instance == null)
        {
            instance = this;
        }
    }

    public void ChangeCoinScore(int coinValue)
    {
        coinCount += coinValue;
        text.text = "x " + coinCount.ToString();
        if (coinCount <= 0)
        {
            winningSoundEffect.Play();
            levelLoader.LoadNextScene();
        }
    }
}
