using UnityEngine;
using UnityEngine.EventSystems;

public class TogglerVibrate : Toggler, IPointerDownHandler
{
    [SerializeField] private Vibration _vibration;


    public void OnPointerDown(PointerEventData eventData)
    {
        StateVibrate(SetState());
    }

    private void StateVibrate(bool value)
    {
        if (value)
        {
            _vibration.On();
        }
        else
        {
            _vibration.Off();
        }
    }
}
