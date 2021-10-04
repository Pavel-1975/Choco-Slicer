using UnityEngine;

[RequireComponent(typeof(BottomPanel))]
public class ScaleArray : MonoBehaviour
{
    [SerializeField] private Scale[] _scale;


    public void PlayScale()
    {
        for (int i = 0; i < _scale.Length; i++)
        {
            _scale[i].OnPlaying();
        }
    }

    public void StopScale()
    {
        for (int i = 0; i < _scale.Length; i++)
        {
            _scale[i].OffPlaying();
        }
    }

    private void OnEnable()
    {
        GetComponent<BottomPanel>().ScaleArrayPlay += PlayScale;
        GetComponent<BottomPanel>().ScaleArrayStop += StopScale;
    }

    private void OnDisable()
    {
        GetComponent<BottomPanel>().ScaleArrayPlay -= PlayScale;
        GetComponent<BottomPanel>().ScaleArrayStop -= StopScale;
    }
}
