using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{   
    LoadLevel levelLoader;
    //[SerializeField] GameObject nextScene;
    [SerializeField] private AudioSource winningSoundEffect;

    public static CoinManager instance;
    public int coinCount = 10;
    int time = 0;
    int teleport = 4;
    public TMP_Text _coinTracker;
    public TMP_Text _tpTimer;

    // Start is called before the first frame update
    void Start()
    {   
        levelLoader = FindObjectOfType<LoadLevel>();
        Debug.Log(levelLoader);
        //levelLoader = nextScene.GetComponent<LoadLevel>();

        if(instance == null)
        {
            instance = this;
        }
    }

    public void ChangeCoinScore(int coinValue)
    {
        coinCount += coinValue;
        _coinTracker.text = "x " + coinCount.ToString();
        if (coinCount <= 0)
        {
            winningSoundEffect.Play();
            Waiter();
        }
    }

    IEnumerator Timer()
    {
        while (true)
        {
            time += 1;
            teleport --;
            _tpTimer.text = "Finishing in " + teleport.ToString();
            yield return new WaitForSeconds(1);

            if(time >= 4)
            {
                levelLoader.LoadNextScene();
            }
        }
    }

    public void Waiter()
    {
        StartCoroutine(Timer());
    }
}
