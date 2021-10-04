using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public int CurrentLevel { get; private set; }
    public int TotalScore { get; private set; }

    public int ScoreCounter { get; private set; }
    public int NewHighScore { get; private set; }
    public float _speed { get; private set; } = -0.6f;
    public bool Complit { get; private set; }

    
    private int _score;

    public event UnityAction<int> Score;
    public event UnityAction Level;
    public event UnityAction MaxScoreSlaider;


    private void Awake()
    {
        LoadData();
    }

    private void LoadData()
    {
        SaveGameData data = SaveLoad.LoadGame();

        if (data != null)
        {
            CurrentLevel = data.CurrentLevel;

            TotalScore = data.TotalScore;

            NewHighScore = data.NewHighScore;
        }

        SetLevel();
    }

    public void ResetComplit()
    {
        Complit = false;
    }

    public void SetComplit()
    {
        Complit = true;
    }

    public void SetScore()
    {
        ScoreCounter++;

        _score++;

        Score?.Invoke(_score);
    }

    public void ResetCounter()
    {
        SetHighScore();

        _score = 0;
        ScoreCounter = 0;

        ResetComplit();

        Score?.Invoke(_score);
    }

    public void SetLevel()
    {
        if (CurrentLevel == 0)
            CurrentLevel = 1;

        Level?.Invoke();
    }

    public void NextLevel()
    {
        CurrentLevel++;

        TotalScore += _score;

        _score = 0;

        SetMaxScoreSlaider();

        SetLevel();
    }

    public void SetHighScore()
    {
        if (ScoreCounter > NewHighScore)
            NewHighScore = ScoreCounter;
    }

    private void SetMaxScoreSlaider()
    {
        MaxScoreSlaider?.Invoke();
    }
}
