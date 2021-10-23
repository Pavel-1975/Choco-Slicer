using UnityEngine;
using UnityEngine.EventSystems;

public class ClickPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private KnifeContainer _knifeContainer;
    [SerializeField] private KnifeCollision _knifeCollision;
    [SerializeField] private NewHighScore _textNewHighScore;
    [SerializeField] private Platform _platform;
    [SerializeField] private BottomPanel _bottomPanel;
    [SerializeField] private ScoreSlider _scoreSlader;   
    [SerializeField] private Settings _settings;
    [SerializeField] private Pause _pause;


    public void OnPointerDown(PointerEventData eventData)
    {
        _knifeContainer.RotateDown();
        _knifeCollision.PositionDown();

        if (_platform.Playing == false)
        {
            Play();

            _textNewHighScore.MoveUp();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _knifeContainer.RotateUp();
        _knifeCollision.PositionUp();
    }

    private void Play()
    {
        _platform.Play();
        _bottomPanel.MoveDown();
        _scoreSlader.EnableVisibility();

        _settings.MoveUp();
        _pause.MoveDown();
    }

    private void OnEnable()
    {
        _settings.transform.gameObject.SetActive(true);
    }
}
