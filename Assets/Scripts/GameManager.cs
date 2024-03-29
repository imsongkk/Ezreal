﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager m_instance;
    public static GameManager instance 
    { 
        get
        {
            if(m_instance == null)
            {
                m_instance = FindObjectOfType<GameManager>();
            }
            return m_instance;
        }
    }    

    public struct PlayerInfo
    {
        public string champName;
        public int index;
        public float radius;
        public float speed;
        public PlayerInfo(string name, int index, float radius, float speed)
        {
            this.champName = name;
            this.index = index;
            this.radius = radius;
            this.speed = speed;
        }
    }

    public PlayerInfo playerInfo;
    public GameObject screenUI;
    public GameObject gameoverUI;
    public GameObject pauseUI;
    public GameObject playButton;
    public GameObject pauseButton;

    public Text scoreText;
    public Text apmText;
    public Text highScoreText;

    public bool isGameOver { get; private set; }
    public bool isPaused { get; private set; }
    public int clickCount = 0;
    public float startTime = 0f;
    public int APM = 0;
    public int round = 1; // 라운드
    public float frequencyEnemySpawn = 3f; // 적 생성 주기
    public int cs = 0;
    private int highScore;

    // 미니언 골드
    // 처음 플레이어 체력, 공격력

    public void Awake()
    {
        if(instance != this)
        {
            Destroy(gameObject);
        }
        SetPlayer("Ezreal");
        scoreText = screenUI.GetComponentInChildren<Text>();
        highScore = PlayerPrefs.GetInt("HighScore");
    }

    void SetPlayer(string champName) // UI에서 champName을 받아옴
    {
        // 받아온 정보로 DB 조회 해서 정보 때려 박음
        // info = ~~~
        playerInfo = new PlayerInfo(champName, 0, 50, 300);
    }

    public void Start()
    {
        m_instance = this;
        isGameOver = false;
    }

    private void Update()
    {
        if(!GameManager.instance.isGameOver)
        {
            APM = GetAPM(Time.time - startTime);
            scoreText.text = $"Creep Score : {cs}";
            apmText.text = $"APM : {APM}";
            //frequencyEnemySpawn -= 0.1f * Time.deltaTime;
            //print(frequencyEnemySpawn);
            // TODO
            // 스킬 쿨타임 보여주기
        }
    }

    public void AddScore()
    {
        if(!isGameOver)
            cs++;
    }

    public void EndGame() // 내부에서 플레이어 사망
    {
        isGameOver = true;
        GetGameoverUI();
    }

    public void ExitGame() // 유저가 게임 종료
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit() // 어플리케이션 종료
        #endif
    }
    
    public void GoMainMenu()
    {
        ExitPauseUI();
        SceneManager.LoadScene("First");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GetPauseUI()
    {
        if (!isPaused)
        {
            pauseUI.SetActive(true);
            pauseButton.SetActive(false);
            playButton.SetActive(true);
            isPaused = true;
            Time.timeScale = 0;
        }
    }

    public void ExitPauseUI()
    {
        if (isPaused)
        {
            pauseUI.SetActive(false);
            pauseButton.SetActive(true);
            playButton.SetActive(false);
            isPaused = false;
            Time.timeScale = 1;
        }
    }

    private void GetGameoverUI()
    {
        gameoverUI.SetActive(true);
        Text apmText = null;
        Text [] text = gameoverUI.GetComponentsInChildren<Text>();
        for(int i=0; i<text.Length; i++)
        {
            if (text[i].name == "Apm Text")
                apmText = text[i];
        }
        apmText.text = $"APM : {APM}";
        PlayerPrefs.SetInt("HighScore", cs >= highScore ? cs : highScore);
        highScoreText.text = $"HIGH SCORE : {PlayerPrefs.GetInt("HighScore")}";
    }

    public int GetAPM(float duration)
    {
        return (int)(clickCount / duration * 60);
    }
}
