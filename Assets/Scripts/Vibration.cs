using UnityEngine;

public class Vibration : MonoBehaviour
{
    private bool _state;


    public void On()
    {
        _state = true;
    }

    public void Off()
    {
        _state = false;
    }

    public void Play()
    {
        if (_state)
            Handheld.Vibrate();
    }
}
