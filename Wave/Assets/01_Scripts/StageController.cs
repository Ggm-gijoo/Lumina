using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class StageController : MonoBehaviour
{
    [SerializeField]
    private SoundManager soundManager;
    [SerializeField]
    private GameObject textTitle;
    [SerializeField]
    private GameObject textTapToPlay;

    [SerializeField]
    private TextMeshProUGUI textCurrentScore;
    [SerializeField]
    private TextMeshProUGUI textBestScore;

    [SerializeField]
    private GameObject buttonContinue;
    [SerializeField]
    private GameObject TextScoreText;

    private int currentScore = 0;


    public bool IsGameOver { private set; get; } = false;

    private IEnumerator Start()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore");
        textBestScore.text = $"<size=13>Best</size>\n<size=25>{bestScore}</size>";

        while(!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        GameStart();
    }

    public void GameStart()
    {
        textTitle.SetActive(false);
        textTapToPlay.SetActive(false);
        textCurrentScore.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        IsGameOver = true;

        int bestScore = PlayerPrefs.GetInt("BestScore");
        if(currentScore >= bestScore)
        {
            PlayerPrefs.SetInt("BestScore", currentScore);
            textBestScore.text = $"<size=13>Best</size>\n<size=25>{currentScore}</size>";
        }

        buttonContinue.SetActive(true);
        TextScoreText.SetActive(true);
    }

    public void IncreaseScore(int score)
    {
        currentScore += score;

        textCurrentScore.text = currentScore.ToString();
    }

    public void ContinueGame()
    {
        soundManager.AudioPlay();
        SceneManager.LoadScene(0);
    }
}
