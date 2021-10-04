using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Scale : MonoBehaviour
{
    [SerializeField] private float _amplitude = 0.08f;
    [SerializeField] private float _time = 1f;
    [SerializeField] private bool _playing;

    private Vector3 _scale;
    public bool Playing => _playing;

    private bool _play;


    private void Start()
    {
        _scale = transform.localScale;
    }

    public void OnPlaying()
    {
        _playing = true;

        Play();
    }

    private void Play()
    {
        if (_playing)
            if (_play == false)
            {
                StartCoroutine(WaitForSeconds(_time));

                _play = true;
            }
    }

    public void OffPlaying()
    {
        _playing = false;
        _play = false;
    }

    private void Play(float scale)
    {
        _scale = (_scale == Vector3.zero) ? transform.localScale : _scale;

        transform.DOScale(new Vector3(_scale.x + scale, _scale.y + scale, _scale.z), _time);
    }

    private IEnumerator WaitForSeconds(float value)
    {
        Play(_amplitude *= -1);

        yield return new WaitForSeconds(value);

        if (_playing)
            StartCoroutine(WaitForSeconds(value));
    }

    private void OnEnable()
    {
        Play();
    }

    private void OnDisable()
    {
        OffPlaying();
    }
}
