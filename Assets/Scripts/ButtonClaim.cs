using UnityEngine;

public class ButtonClaim : ButtonOnClick
{
    [SerializeField] private Platform _platform;
    [SerializeField] private KnifeContainer _knife—ontainer;
    [SerializeField] private Settings _settings;
    [SerializeField] private BottomPanel _bottomPanel;
    [SerializeField] private Rotation[] _rotation;
    [SerializeField] private Scale[] _scale;


    protected override void OnClick()
    {
        _platform.Reset();

        _settings.MoveDown();

        _bottomPanel.MoveUp();

        _knife—ontainer.PositionStart();

        transform.parent.gameObject.SetActive(false);

        PlayRotation();
        PlayScale();
    }

    private void PlayRotation()
    {
        _rotation[0].OnPlaying();
        _rotation[1].OnDeviation();
    }

    private void PlayScale()
    {
        for (int i = 0; i < _scale.Length; i++)
        {
            _scale[i].OnPlaying();
        }
    }
}
