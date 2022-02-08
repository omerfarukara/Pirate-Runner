using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public static UIManager Instance => _instance;

    [SerializeField] Button jumpButton;
    [SerializeField] Button fireButton;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletRefTransform;
    [SerializeField] RectTransform healtImage;
    [SerializeField] TextMeshProUGUI _coinScore;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] Button playButton;
    [SerializeField] Button restartButton;
    [SerializeField] Button mainMenuButton;
    [SerializeField] Button quitApplicationButton;
    [SerializeField] Text highScore;
    [SerializeField] Text score;

    public RectTransform HealtImage
    {
        get
        {
            return healtImage;
        }
        set
        {
            healtImage = value;
        }
    }

    private void Awake()
    {
        _instance = this;
        if (jumpButton != null)
        {
            jumpButton.onClick.AddListener(Jump);
        }
        if(fireButton != null)
        {
            fireButton.onClick.AddListener(Fire);
        }
        if (playButton != null)
        {
            playButton.onClick.AddListener(Play);
        }
        if(restartButton != null)
        {
            restartButton.onClick.AddListener(Restart);
        }
        if (mainMenuButton != null)
        {
            mainMenuButton.onClick.AddListener(MainMenu);
        }
        if (quitApplicationButton != null)
        {
            quitApplicationButton.onClick.AddListener(QuitApplication);
        }
    }

    void Jump()
    {
        GameManager.Instance.PlayerController.Jump();
    }

    void Fire()
    {
        Instantiate(bullet, bulletRefTransform.position, bulletRefTransform.rotation);
    }
    
    public void ScoreUpdate()
    {
        _coinScore.text = $"{GameManager.Instance.Gold}";
        score.text = $"SCORE = {GameManager.Instance.Gold}";
    }

    public void HighScorePassed()
    {
        highScore.text = $"HIGH SCORE = {GameManager.Instance.HighGold}";
    }

    void Play()
    {
        SceneManager.LoadScene(1);
        GameManager.Instance.IsGameOver = false;
    }

    void Restart()
    {
        SceneManager.LoadScene(1);
        GameManager.Instance.IsGameOver = false;
    }

    void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    void QuitApplication()
    {
        Application.Quit();
    }


    public void PanelControl()
    {
        gameOverPanel.SetActive(true);
    }
}
