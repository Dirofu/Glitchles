using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class General : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _winGamePanel;
    [SerializeField] private GameObject _loseGamePanel;
    [SerializeField] private GameObject _startGamePanel;
    [SerializeField] private Record _record;


    private void OnEnable()
    {
        _player.EndBlockPicked += ShowWinPanel;
    }

    private void OnDisable()
    {
        _player.EndBlockPicked -= ShowWinPanel;
    }

    private void Start()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _startGamePanel.SetActive(true);
        _winGamePanel.SetActive(false);
        _loseGamePanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _startGamePanel.SetActive(false);
            Time.timeScale = 1;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }

    private void ShowWinPanel()
    {
        Time.timeScale = 0;
        _winGamePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _record.SaveRecord(SceneManager.GetActiveScene().buildIndex.ToString());
    }

    public void BackToMenu() => SceneManager.LoadScene(0);

    public void RestartLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    public void NextLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<Player>())
        {
            Time.timeScale = 0;
            _loseGamePanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
