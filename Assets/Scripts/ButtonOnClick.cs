using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonOnClick : MonoBehaviour
{
    protected abstract void OnClick();


    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveListener(OnClick);
    }
}
