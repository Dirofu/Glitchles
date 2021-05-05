using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(TMP_Text))]
public class Timer : MonoBehaviour
{
    private TMP_Text _text;
    
    public float Time { get; private set; }

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        Time = 0;
        _text.text = Time.ToString();
    }

    private void Update()
    {
        Time += UnityEngine.Time.deltaTime;
        _text.text = Math.Round(Time, 2, MidpointRounding.AwayFromZero).ToString();
    }
}
