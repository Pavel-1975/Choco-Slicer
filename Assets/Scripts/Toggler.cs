using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class Toggler : MonoBehaviour
{
    private int _toggleEnabled = 1;
    private int _toggleDisable = 0;


    protected bool SetState()
    {
        if (GetComponent<Slider>().value == _toggleDisable)
        {
            SetActive(_toggleEnabled, _toggleDisable);

            return true;
        }
        else
        {
            SetActive(_toggleDisable, _toggleEnabled);

            return false;
        }
    }

    private void SetActive(int value, int value1)
    {
        GetComponent<Slider>().value = value;

        GetComponentsInChildren<TMP_Text>()[value].enabled = false;
        GetComponentsInChildren<TMP_Text>()[value1].enabled = true;
    } 
}
