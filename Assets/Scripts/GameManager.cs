using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField] private GameObject asteroidPrefab = null;
    [SerializeField] private Text scoreText = null;
    [SerializeField] private GameObject gameOverScreen = null;
    [SerializeField] private Text gameOverScoreText = null;
    [SerializeField] private InputField nameInput = null;
    private int points = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Second GameManager found");
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void AsteroidDied()
    {
        Instantiate(asteroidPrefab);
    }

    public void AddPoints(int _amount) {
        points += _amount;

        scoreText.text = "Score: " + points;
    }

    public void GameOver() {
        gameOverScreen.SetActive(true);
        gameOverScoreText.text = "Your score is: " + points;
    }

    public void RealodScene() {
        SceneManager.LoadSceneAsync("Game");
    }

    public void SubmitName() {

        string name = nameInput.text;

        Score newScore = new Score(name, points);

        HighScore highscore = DataLoader.LoadData();

        highscore.list.Add(newScore);
        highscore.list = SortHighscore(highscore.list);

        DataLoader.SaveData(highscore);

        foreach(Score score in highscore.list)
            Debug.Log(score.name + " with score: " + score.score);

        SceneManager.LoadSceneAsync("Game");
    }

    List<Score> SortHighscore(List<Score> _highscore) {
        List<Score> newHighscore = new List<Score>();

        while(_highscore.Count > 0) {
            Score biggest = _highscore[0];

            foreach(Score score in _highscore) {
                if(score.score > biggest.score)
                    biggest = score;
            }

            newHighscore.Add(biggest);
            _highscore.Remove(biggest);
        }
        return newHighscore;
    }
}
