using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForTime : MonoBehaviour
{
    public int time;

    private void Start()
    {
        StartCoroutine(Test());

    }

    IEnumerator Test()
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Wait is over");

    }
}
