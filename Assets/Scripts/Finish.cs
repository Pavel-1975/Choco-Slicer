using System.Collections;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject _panelEndLevel;
    [SerializeField] private KnifeContainer _knifeContainer;
    [SerializeField] private Player _player;


    private Vector3 _position;

    private void Start()
    {
        _position = transform.position;
    }

    public void SetPosition(float pozitionZ)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, pozitionZ);
    }

    public void SetPosition()
    {
        transform.position = _position;
    }

    public bool MoveFinishCylinder()
    {
        SetPosition(transform.position.z + _player._speed);

        if (transform.position.z < 0)
        {
            _knifeContainer.EnableFlightAnimation();

            float time = 2f;

            StartCoroutine(WaitForSecondsFinish(time));

            return true;
        }

        return false;
    }

    private IEnumerator WaitForSecondsFinish(float value)
    {
        yield return new WaitForSeconds(value);

        _panelEndLevel.SetActive(true);

        SetPosition();
    }
}
