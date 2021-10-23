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
    
    [SerializeField] private GameObject _settings;
    [SerializeField] private GameObject _pause;


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

        _settings.GetComponent<Settings>().MoveUp();
        _pause.GetComponent<Pause>().MoveDown();
    }

    private void OnEnable()
    {
        _settings.SetActive(true);
    }
}
