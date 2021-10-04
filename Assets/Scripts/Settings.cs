using UnityEngine;
using DG.Tweening;

public class Settings : ButtonOnClick
{
    [SerializeField] private SettingsButtonMenu _buttonMenu;
    [SerializeField] private BottomPanel _bottomPanel;

    private const float _recoveryRate = 0.5f;
    private float _maximumUp;


    private void Start()
    {
        _maximumUp = Screen.height / GetComponentInParent<Canvas>().scaleFactor / 2;
    }

    public void MoveDown()
    {
        transform.parent.DOLocalMoveY(transform.parent.localPosition.y - _maximumUp, _recoveryRate);
    }

    public void MoveUp()
    {
        transform.parent.DOLocalMoveY(transform.parent.localPosition.y + _maximumUp, _recoveryRate);
    }

    protected override void OnClick()
    {
        _buttonMenu.MoveDown();
        _bottomPanel.MoveDown();

        MoveUp();
    }
}
