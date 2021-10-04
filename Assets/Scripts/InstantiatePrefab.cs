using UnityEngine;

public class InstantiatePrefab : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefab;
    [SerializeField] private Transform[] _platforms;
    [SerializeField] private Platform _platform;
    [SerializeField] private EndLevelPrefab _endLevelPrefab;

    private GameObject[,] _instantiate = new GameObject[3, 8];
    private float[] _positionZ = { -70f, -50f, -30f, -10f, 10f, 30f, 50f, 70f };
    private int[] _numberPrefab = { 1, 2, 0, 0, 1, 3, 2, 1 };
    private int _closeChocolad = 3;


    private void Awake()
    {
        Play();
    }

    public void Play()
    {
        for (int i = 0; i < _platforms.Length; i++)
        {
            if (i == 0)
            {
                Instantiate(_numberPrefab, i, _platform.StartPositionZ[i], 2);
            }
            else
            {
                SetRandom();

                Instantiate(_numberPrefab, i, _platform.StartPositionZ[i]);
            }
        }
    }

    public int[] SetRandom()
    {
        for (int j = 0; j < _positionZ.Length; j++)
        {
            _numberPrefab[j] = Random.Range(0, _prefab.Length - _closeChocolad); 
        }

        return _numberPrefab;
    }

    public void Instantiate(int[] number, int numberPlatform, float positionZ, int num = 0)
    {
        for (int j = num; j < _numberPrefab.Length; j++)
        {
            _instantiate[numberPlatform, j] = Instantiate(_prefab[number[j]], new Vector3(0f, 1f, positionZ + _positionZ[num++]), Quaternion.identity, _platforms[numberPlatform]);
        }
    }

    public void Destroy(int numberPlatform)
    {
        for (int i = 0; i < _instantiate.GetLength(1); i++)
        {
            Destroy(_instantiate[numberPlatform, i]);
        }
    }

    private void OpenChocolad()
    {
        _closeChocolad--;
    }

    private void OnEnable()
    {
        _endLevelPrefab.OpenChocolad += OpenChocolad;
    }

    private void OnDisable()
    {
        _endLevelPrefab.OpenChocolad -= OpenChocolad;
    }
}
