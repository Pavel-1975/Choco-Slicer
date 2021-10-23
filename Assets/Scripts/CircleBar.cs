using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CircleBar : MonoBehaviour
{
    [SerializeField] private Image _circleBar;

    public float _value { get; private set; }

    private float _maxValue = 1;
    private float _current;
    private float _recoveryRate = 0.005f;
    private float _time = 0.02f;


    public void AdjustCurrentValue(float adjust)
    {
        _value = _current += (adjust > 0f) ? adjust : 0f;

        _value -= (adjust > 0f) ? adjust : 0f;

        StartCoroutine(WaitForTime(_time));
    }

    private void Move(float recoveryRate)
    {
        _value = Mathf.MoveTowards(_value, _current, recoveryRate);

        if (_current > _value)
        {
            _circleBar.fillAmount = _value + 0.01f;

            StartCoroutine(WaitForTime(_time));
        }
        else if(_maxValue <= _value)
        {
            _value = 0;
            _current = 0;
        }
    }

    private IEnumerator WaitForTime(float value)
    {
        yield return new WaitForSeconds(value);

        Move(_recoveryRate);
    }
}
