using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class NewHighScore : MonoBehaviour
{
    private const float _recoveryRate = 0.5f;
    private float _maximumUp;

    private Vector3 _position;
    private Vector3 _positionImage;


    private void Start()
    {
        _maximumUp = Screen.height / GetComponentInParent<Canvas>().scaleFactor;

        _position = transform.localPosition;

        _positionImage = GetComponentInChildren<Image>().transform.localPosition;
    }

    public void SetPositionSource()
    {
        transform.localPosition = Vector3.zero;

        GetComponentInChildren<Image>().transform.localPosition = new Vector3(4f, 72f, 0f);

        GetComponent<TMP_Text>().alignment = TextAlignmentOptions.Center;
    }

    public void SetStartPosition()
    {
        transform.localPosition = _position;

        GetComponentInChildren<Image>().transform.localPosition = _positionImage;

        GetComponent<TMP_Text>().alignment = TextAlignmentOptions.Left;
    }

    public void MoveUp()
    {
        transform.DOLocalMoveY(transform.localPosition.y + _maximumUp, _recoveryRate);
    }

    public void MoveDown()
    {
        transform.DOLocalMoveY(transform.localPosition.y - _maximumUp, _recoveryRate);
    }

    public void ShowNewHighScore(string value)
    {
        GetComponent<TMP_Text>().text = value;
    }
}
