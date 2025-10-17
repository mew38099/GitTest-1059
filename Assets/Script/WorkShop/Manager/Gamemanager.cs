using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// ��˹������ sealed ���ͻ�ͧ�ѹ����׺�ʹ
public class GameManager : MonoBehaviour
{
    // 1. Private Static Field (The Singleton Instance)
    // �� backing field ���ͤǺ��������Ҷ֧
    public static GameManager instance;

    // 2. Public Static Property (Global Access Point)
   
    [Header("Game State")]
    public int currentScore = 0;
    public bool isGamePaused = false;

    [Header("UI Game")]
    public GameObject pauseMenuUI;
    public TMP_Text scoreText;
    public Slider HPBar;

    // 3. Private Constructor Logic (�� Awake() ᷹ Constructor ����� Unity)
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    // ------------------- Singleton Functionality -------------------

    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        HPBar.value = currentHealth;
        HPBar.maxValue = maxHealth;
    }
    public void AddScore(int amount)
    {
        currentScore += amount;
        scoreText.text = currentScore.ToString();
    }

    public void TogglePause()
    {
        isGamePaused = !isGamePaused;
        Time.timeScale = isGamePaused ? 0 : 1;
        pauseMenuUI.SetActive(isGamePaused);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    internal void LoadNewScene(string loadSceneName)
    {
        throw new NotImplementedException();
    }

    public static implicit operator GameManager(LoadSceneManager v)
    {
        throw new NotImplementedException();
    }
}