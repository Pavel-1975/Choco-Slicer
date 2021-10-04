using UnityEngine;

[RequireComponent(typeof(BottomPanel))]
public class RotateArray : MonoBehaviour
{
    [SerializeField] private Rotation[] _rotation;


    public void PlayRotation()
    {
        _rotation[0].OnPlaying();
        _rotation[1].OnDeviation();
    }

    public void StopRotation()
    {
        for (int i = 0; i < _rotation.Length; i++)
        {
            _rotation[i].Off();
        }
    }

    private void OnEnable()
    {
        GetComponent<BottomPanel>().RotateArrayPlay += PlayRotation;
        GetComponent<BottomPanel>().RotateArrayStop += StopRotation;
    }

    private void OnDisable()
    {
        GetComponent<BottomPanel>().RotateArrayPlay -= PlayRotation;
        GetComponent<BottomPanel>().RotateArrayStop -= StopRotation;
    }
}
