using UnityEngine;
using TMPro;

public class EndLevel : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Pause _pause;
    [SerializeField] private ScoreSlider _scoreSlader;
    [SerializeField] private SaveGame _saveGame;


    private void Play()
    {
        for (int i = 0; i < 2; i++)
        {
            GetComponentsInChildren<Scale>()[i].OnPlaying();
            GetComponentsInChildren<Rotation>()[i].OnSwing();
        }
    }

    private void ShowLevelCompleted()
    {
        GetComponentInChildren<TMP_Text>().text = "LEVEL " + _player.CurrentLevel + " COMPLETED";
    }

    private void OnEnable()
    {
        _scoreSlader.OffVisibility();

        _pause.MoveUp();

        ShowLevelCompleted();

        Play();

        _player.ResetComplit();

        _player.NextLevel();

        _player.SetHighScore();

        _saveGame.OnSaveGame();
    }
}
