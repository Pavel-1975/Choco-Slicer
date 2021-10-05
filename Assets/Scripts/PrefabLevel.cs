using UnityEngine;

public class PrefabLevel : MonoBehaviour
{
    [SerializeField] private int _numberStepsGet;

    public int NumberStepsGet => _numberStepsGet;
}
