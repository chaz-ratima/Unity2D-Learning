using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForTime : MonoBehaviour
{
    public int time;

    public void Waiter()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Wait is over");
    }
}
