using DG.Tweening;
using System.Collections;
using UnityEngine;


public class Rotation : MonoBehaviour
{
    [SerializeField] private float _amplitudeSwing = 3f;
    [SerializeField] private float _time = 2f;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private bool _playingSwing;
    [SerializeField] private bool _rotaryMotion;
    [SerializeField] private bool _deviation;
    [SerializeField] private bool _freeRotation;

    public bool PlayingSwing => _playingSwing;
    public bool RotaryMotion => _rotaryMotion;
    public bool Deviation => _deviation;

    private float _rotationX;
    private float _rotationY;
    private float _rotationZ;
    private float _amplitude;
    private bool _play;


    public void OnSwing()
    {
        _playingSwing = true;

        Play();
    }

    public void OnPlaying()
    {
        _rotaryMotion = true;

        Play();
    }

    public void OnDeviation()
    {
        _deviation = true;

        Play();
    }

    public void OnFreeRotation()
    {
        _freeRotation = true;

        Play();
    }

    private void Play()
    {
        if (_playingSwing || _rotaryMotion || _deviation || _freeRotation)
        {
            if (_play == false)
            {
                StartCoroutine(WaitForSeconds(_time));

                _play = true;
            }
        }
    }

    public void Off()
    {
        _playingSwing = false;
        _rotaryMotion = false;
        _deviation = false;
        _freeRotation = false;
        _play = false;
    }

    private void PlaySwing(float rotate)
    {
        transform.DOLocalRotate(new Vector3(0, 0, rotate), _time);
    }

    private void Rotate()
    {
        _rotationZ += _speed;

        transform.localRotation = Quaternion.Euler(0, 0, _rotationZ);
    }

    private void PlayFreeRotation()
    {
        _rotationX += _speed;
        _rotationY += _speed;
        _rotationZ += _speed;

        transform.localRotation = Quaternion.Euler(_rotationX, _rotationY, _rotationZ);
    }

    private IEnumerator WaitForSeconds(float value)
    {
        if (_playingSwing)
            PlaySwing(_amplitudeSwing *= -1);

        if (_deviation)
        {
            _amplitude = (_amplitude == 0) ? _amplitudeSwing : 0;

            PlaySwing(_amplitude);
        }

        if (_rotaryMotion)
            Rotate();

        if (_freeRotation)
            PlayFreeRotation();

        yield return new WaitForSeconds(value);

        if (_playingSwing || _rotaryMotion || _deviation || _freeRotation)
            StartCoroutine(WaitForSeconds(value));
    }

    private void OnEnable()
    {
        Play();
    }

    private void OnDisable()
    {
        Off();
    }
}
