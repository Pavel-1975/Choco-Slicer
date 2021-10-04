using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

[RequireComponent(typeof(ScaleArray))]
[RequireComponent(typeof(RotateArray))]
public class BottomPanel : MonoBehaviour
{
    private const float _recoveryRate = 0.5f;
    private float _maximumUp;

    public event UnityAction ScaleArrayStop;
    public event UnityAction ScaleArrayPlay;
    public event UnityAction RotateArrayStop;
    public event UnityAction RotateArrayPlay;


    private void Start()
    {
        _maximumUp = Screen.height / GetComponentInParent<Canvas>().scaleFactor / 2;
    }

    public void MoveDown()
    {
        transform.DOLocalMoveY(transform.localPosition.y - _maximumUp, _recoveryRate);

        ScaleArrayStop?.Invoke();
        RotateArrayStop?.Invoke();
    }

    public void MoveUp()
    {
        transform.DOLocalMoveY(transform.localPosition.y + _maximumUp, _recoveryRate);

        ScaleArrayPlay?.Invoke();
        RotateArrayPlay?.Invoke();
    }
}
