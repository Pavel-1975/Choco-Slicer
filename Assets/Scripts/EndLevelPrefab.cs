using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rotation))]
public class EndLevelPrefab : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefab;
    [SerializeField] private CircleBar _circleBar;

    private GameObject _instantiate;

    private int _counter;
    private int _prefabNext;

    public event UnityAction OpenChocolad;


    private void InstantiatePrefab()
    {
        _instantiate = Instantiate(_prefab[_prefabNext], transform.position, Quaternion.identity, transform);
    }

    private void PlayCircleBar()
    {
        int _level = _instantiate.GetComponent<PrefabLevel>().NumberStepsGet;

        if (++_counter == _level)
        {
            _prefabNext++;
            _counter = 0;

            OpenChocolad?.Invoke();
        }

        _circleBar.AdjustCurrentValue(1f / _level);
    }

    private void OnEnable()
    {
        InstantiatePrefab();

        PlayCircleBar();

        GetComponent<Rotation>().OnFreeRotation();
    }

    private void OnDisable()
    {
        Destroy(_instantiate);
    }
}
