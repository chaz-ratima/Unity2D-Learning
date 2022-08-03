using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{   
    LoadLevel levelLoader;
    [SerializeField] GameObject coinManager;

    public static CoinManager instance;
    public TextMeshProUGUI text;
    public int coinCount = 10;

    // Start is called before the first frame update
    void Start()
    {   
        levelLoader = coinManager.GetComponent<LoadLevel>();

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
            levelLoader.LoadNextScene();
        }
    }
}
