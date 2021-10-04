using UnityEngine;
using DG.Tweening;

public class Pause : ButtonOnClick
{
    [SerializeField] private GameObject _panelPaused;
    [SerializeField] private Platform _platform;

    private const float _recoveryRate = 1f;
    private float _maximumUp;


    private void Start()
    {
        _maximumUp = Screen.height / GetComponentInParent<Canvas>().scaleFactor / 2f;

        MoveUp(0f);
    }

    public void MoveDown()
    {
        transform.DOLocalMoveY(transform.localPosition.y - _maximumUp, _recoveryRate);
    }

    public void MoveUp(float recoveryRate = _recoveryRate)
    {
        transform.DOLocalMoveY(transform.localPosition.y + _maximumUp, recoveryRate);
    }

    protected override void OnClick()
    {
        _panelPaused.SetActive(true);
        _panelPaused.transform.DOScale(Vector3.one, _recoveryRate);

        _platform.PauseOn();

        MoveUp();
    }
}
