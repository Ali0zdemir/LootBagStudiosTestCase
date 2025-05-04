using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [System.Serializable]
    public class PlayerSaveData{
        public int score;
    }
    public PlayerData playerData;
    public static GameManager instance;
    public TextMeshProUGUI scoreText;
    private int totalScore;

    void Awake()
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
    void Start()
    {
        LoadPlayerData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int score)
    {
        totalScore += score;
        scoreText.text = "Score: " + totalScore.ToString();
        SavePlayerData();
    }

    public void SavePlayerData()
    {
        playerData.score = totalScore;
        PlayerPrefs.SetInt("PlayerScore", playerData.score);
        PlayerPrefs.Save();
    }

    
    public void LoadPlayerData()
    {
        if (PlayerPrefs.HasKey("PlayerScore"))
        {
            playerData.score = PlayerPrefs.GetInt("PlayerScore");
            totalScore = playerData.score;
            scoreText.text = "Score: " + totalScore.ToString();
        }
    }

}
