using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreSlider : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _textCurrentLevel;
    [SerializeField] private TMP_Text _textNextLevel;
    [SerializeField] private TMP_Text _textLevel;
    [SerializeField] private TMP_Text _textScoreCounter;
    [SerializeField] private TMP_Text _textTotalScore;
    [SerializeField] private NewHighScore _textNewHighScore;
    [SerializeField] private Slider _slider;

    private readonly int _coefficient = 10;
    private int _maxScore = 100;
    private const int _minScore = 90;


    private void Start()
    {
        _player.Score += ShowScore;
        _player.Level += ShowData;
        _player.MaxScoreSlaider += SetMaxScoreSlaider;

        ShowData();

        SetMaxScoreSlaider();
    }

    private void ShowScore(int value)
    {
        if (_maxScore <= value)
            _player.SetComplit();

        _textScoreCounter.text = _player.ScoreCounter.ToString();

        _slider.value = value;
    }

    private void ShowData()
    {
        _textCurrentLevel.text = _player.CurrentLevel.ToString();

        _textLevel.text = "LEVEL " + _player.CurrentLevel;

        _textNextLevel.text = (_player.CurrentLevel + 1).ToString();

        _textTotalScore.text = _player.TotalScore.ToString();

        _textNewHighScore.ShowNewHighScore(_player.NewHighScore.ToString());
    }

    public void OffVisibility()
    {
        transform.localScale = Vector3.zero;
    }

    public void EnableVisibility()
    {
        transform.localScale = Vector3.one;
    }

    private void SetMaxScoreSlaider()
    {
        _maxScore = _player.CurrentLevel * _coefficient + _minScore;

        _slider.maxValue = _maxScore;
    }

    private void OnDisable()
    {
        _player.Score -= ShowScore;
        _player.Level -= ShowData;
        _player.MaxScoreSlaider -= SetMaxScoreSlaider;
    }
}
