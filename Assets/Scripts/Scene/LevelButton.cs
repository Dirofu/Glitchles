using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private int _levelNumber;

    private void Start()
    {
        float record;

        record = PlayerPrefs.GetFloat(_levelNumber.ToString());
        _text.text = Math.Round(record, 2, MidpointRounding.AwayFromZero).ToString();
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(_levelNumber);
    }
}
