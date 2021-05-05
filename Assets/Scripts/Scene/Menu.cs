using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _levelsPanel;

    private void Start()
    {
        _levelsPanel.SetActive(false);
    }

    public void OpenLevelPanel()
    {
        _levelsPanel.SetActive(true);
    }

    public void CloseLevelPanel()
    {
        _levelsPanel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
