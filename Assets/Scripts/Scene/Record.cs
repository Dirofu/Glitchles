using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Timer))]
public class Record : MonoBehaviour
{
    private Timer _timer;

    private void Start()
    {
        _timer = GetComponent<Timer>();
    }

    public void SaveRecord(string levelNumber)
    {        
        if (_timer.Time < TakeRecord(levelNumber) || TakeRecord(levelNumber) == 0)
        {
            PlayerPrefs.SetFloat(levelNumber, _timer.Time);
        }
    }

    public float TakeRecord(string levelNumber) => PlayerPrefs.GetFloat(levelNumber);
}
