using UnityEngine;
using DG.Tweening;

public class SettingsButtonMenu : ButtonOnClick
{
    [SerializeField] private Settings _settings;
    [SerializeField] private BottomPanel _startingGame;

    private const float _recoveryRate = 0.5f;
    private float _maximumUp;


    private void Start()
    {
        _maximumUp = Screen.height / GetComponentInParent<Canvas>().scaleFactor;

        MoveUp(0);
    }

    public void MoveDown()
    {
        transform.parent.DOLocalMoveY(transform.parent.localPosition.y - _maximumUp, _recoveryRate);
    }

    private void MoveUp(float recoveryRate = _recoveryRate)
    {
        transform.parent.DOLocalMoveY(transform.parent.localPosition.y + _maximumUp, recoveryRate);
    }

    protected override void OnClick()
    {
        _settings.MoveDown();
        _startingGame.MoveUp();

        MoveUp();
    }
}
