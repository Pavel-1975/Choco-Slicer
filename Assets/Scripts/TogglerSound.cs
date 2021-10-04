using UnityEngine;
using UnityEngine.EventSystems;

public class TogglerSound : Toggler, IPointerDownHandler
{
    [SerializeField] private Sound _sound;


    private void Start()
    {
        StateSound(SetState());
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StateSound(SetState());
    }

    private void StateSound(bool value)
    {
        if (value)
        {
            _sound.Play();
        }
        else
        {
            _sound.Stop();
        }
    }
}
