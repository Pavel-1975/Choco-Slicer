using UnityEngine;
using DG.Tweening;
using System.Collections;

public class KnifeContainer : MonoBehaviour
{
    [SerializeField] Transform[] _point;

    private const float _recoveryRate = 1f;
    private const float _maximumUp = 40;

    private float _quaternionX = 0f;
    private float _quaternionY = -90;
    private float _quaternionZ;
    private float _counter;
    private float _time = 0.03f;

    private Vector3 _position;
    private Quaternion _rotation;


    private void Start()
    {
        _position = transform.position;
        _rotation = transform.rotation;
    }

    public void RotateDown()
    {
        _quaternionZ = -45;

        transform.rotation = Quaternion.Euler(_quaternionX, _quaternionY, _quaternionZ);
    }

    public void RotateUp()
    {
        _quaternionZ = 0;

        transform.rotation = Quaternion.Euler(_quaternionX, _quaternionY, _quaternionZ);
    }

    public void PositionDown()
    {
        transform.DOMoveZ(transform.position.z - _maximumUp, _recoveryRate);
    }

    public void PositionUp()
    {
        transform.DOMoveZ(transform.position.z + _maximumUp, _recoveryRate);
    }

    public void EnableFlightAnimation()
    {
        _counter = 0;

        StartCoroutine(WaitForSeconds());
    }

    public void PositionStart()
    {
        transform.position = _position;

        transform.rotation = _rotation;
    }

    private IEnumerator WaitForSeconds()
    {
        yield return new WaitForFixedUpdate();

        Move();
    }

    private void Move()
    {
        _counter += _time;

        if (_counter <= 1)
        {
            transform.position = GetPoint(_counter);

            if (_counter >= 0.5f)
                transform.rotation = Quaternion.LookRotation(GetFirstDerivative(_counter));

            StartCoroutine(WaitForSeconds());
        }
    }

    private Vector3 GetPoint(float counter)
    {
        counter = Mathf.Clamp01(counter);

        float oneMinusT = 1f - counter;

        return oneMinusT * oneMinusT * oneMinusT * _point[0].position +
            3f * oneMinusT * oneMinusT * counter * _point[1].position +
            3f * oneMinusT * counter * counter * _point[2].position +
            counter * counter * counter * _point[3].position;
    }

    private Vector3 GetFirstDerivative(float counter)
    {
        counter = Mathf.Clamp01(counter);

        float oneMinusT = 1f - counter;

        return 3f * oneMinusT * oneMinusT * (_point[1].position - _point[0].position) +
            6f * oneMinusT * counter * (_point[2].position - _point[1].position) +
            3f * counter * counter * (_point[3].position - _point[2].position);
    }

    ////private void OnDrawGizmos()
    //{
    //    int sigmentNumber = 20;

    //    Vector3 preveousePoint = _point[0].position;

    //    for (int i = 0; i < sigmentNumber + 1; i++)
    //    {
    //        float parametr = (float)i / sigmentNumber;

    //        Vector3 point = GetPoint(parametr);

    //        Gizmos.DrawLine(preveousePoint, point);

    //        preveousePoint = point;
    //    }
    //}
}
