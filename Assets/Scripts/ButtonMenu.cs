using DG.Tweening;
using UnityEngine;

public class ButtonMenu : ButtonOnClick
{
    [SerializeField] private GameObject _panelSlader;
    [SerializeField] private Settings _settings;
    [SerializeField] private Platform _platform;
    [SerializeField] private BottomPanel _bottomPanel;
    [SerializeField] private NewHighScore _textNewHighScore;

    private const float _recoveryRate = 1f;


    protected override void OnClick()
    {
        transform.parent.DOScale(Vector3.zero, _recoveryRate);

        _platform.PauseOff();

        _settings.MoveDown();

        _bottomPanel.MoveUp();

        _platform.Reset();

        _textNewHighScore.MoveDown();

        _panelSlader.transform.localScale = Vector3.zero;
    }
}
