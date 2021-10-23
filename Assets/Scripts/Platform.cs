using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Transform[] _move;
    [SerializeField] private Finish _finish;
    [SerializeField] private KnifeCollision _knifeCollisionStone;
    [SerializeField] private Stone _stonePrefab;
    [SerializeField] private Player _player;

    public float[] StartPositionZ { get; private set; } = { 28, 188, 348 };

    public bool Playing { get; private set; }

    private int[] _numberPrefab;
    private readonly int[] _platform = { 2, 0, 1 };
    private readonly float _distanceZ = 100;
    private readonly int _lengthPlatform = 160;

    private bool _pause;
    private bool _complit;


    public void Start()
    {
        StartCoroutine(WaitForSeconds());

        _complit = false;
    }

    public void Play()
    {
        Playing = true;

        _knifeCollisionStone.CollisionOff();
    }

    public void Reset()
    {
        Playing = false;

        _knifeCollisionStone.CollisionOff();

        _stonePrefab.ResetCounter();

        for (int i = 0; i < _move.Length; i++)
        {
            SetPosition(i, StartPositionZ[i]);

            GetComponent<InstantiatePrefab>().Destroy(i);
        }

        GetComponent<InstantiatePrefab>().Play();

        PauseOff();
    }

    public void PauseOn()
    {
        _pause = true;
    }

    public void PauseOff()
    {
        _pause = false;
    }

    public void MakeTransfer(int number)
    {
        if (_player.Complit == false)
        {
            float positionZ = _move[_platform[number]].localPosition.z + _lengthPlatform;

            SetPosition(number, positionZ);

            CallUpInstantiatePrefab(positionZ, number);
        }
        else if (_complit == false)
        {
            _finish.SetPosition(_move[_platform[number]].localPosition.z + _distanceZ);

            _complit = true;
        }
    }

    private void CallUpInstantiatePrefab(float positionZ, int numberPlatform)
    {
        GetComponent<InstantiatePrefab>().Destroy(numberPlatform);

        _numberPrefab = GetComponent<InstantiatePrefab>().SetRandom();

        GetComponent<InstantiatePrefab>().Instantiate(_numberPrefab, numberPlatform, positionZ);
    }

    private void Move()
    {
        for (int i = 0; i < _move.Length; i++)
        {
            SetPosition(i, _move[i].localPosition.z + _player._speed);
        }
    }

    private void SetPosition(int numberPlatform, float positionZ)
    {
        _move[numberPlatform].localPosition = new Vector3(0f, 0f, positionZ);
    }

    private void TryFinish()
    {
        if (_player.Complit && _finish.MoveFinishCylinder())
        {
            PauseOn();

            _complit = false;
        }
    }

    private IEnumerator WaitForSeconds()
    {
        yield return new WaitForFixedUpdate();

        if (_pause == false)
        {
            Move();

            TryFinish();
        }

        if (_knifeCollisionStone.Collision == false)
        {
            StartCoroutine(WaitForSeconds());
        }
        else
        {
            _complit = false;
        }
    }
}
