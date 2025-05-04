using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int score)
    {
        totalScore += score;
        scoreText.text = "Score: " + totalScore.ToString();
    }

}
