using UnityEngine;
using UnityEngine.EventSystems;

public class LevelFailed : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Player _player;
    [SerializeField] private Platform _platform;
    [SerializeField] private KnifeContainer _knifeContainer;
    [SerializeField] private Settings _settings;
    [SerializeField] private BottomPanel _bottomPanel;
    [SerializeField] private NewHighScore _textNewHighScore;
    [SerializeField] private GameObject _textTapToContinue;
    [SerializeField] private Finish _finish;


    public void OnPointerDown(PointerEventData eventData)
    {
        _platform.Reset();
        _platform.Start();

        _settings.MoveDown();

        _bottomPanel.MoveUp();

        _knifeContainer.PositionUp();

        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _textNewHighScore.SetPositionSource();

        _textNewHighScore.ShowNewHighScore(_player.NewHighScore.ToString());

        _platform.PauseOn();

        _player.ResetCounter();

        _finish.SetPosition();

        _textTapToContinue.GetComponentInChildren<Scale>().OnPlaying();
        _textTapToContinue.GetComponentInChildren<Rotation>().OnSwing();
    }

    private void OnDisable()
    {
        _textNewHighScore.SetStartPosition();
    }
}
