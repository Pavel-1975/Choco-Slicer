using DG.Tweening;
using UnityEngine;

public class ButtonResume : ButtonOnClick
{
    [SerializeField] private Pause _pause;
    [SerializeField] private Platform _platform;

    private const float _recoveryRate = 1f;


    protected override void OnClick()
    {
        transform.parent.DOScale(Vector3.zero, _recoveryRate);

        _platform.PauseOff();

        _pause.MoveDown();
    }
}
