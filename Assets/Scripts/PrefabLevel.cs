using UnityEngine;

public class PrefabLevel : MonoBehaviour
{
    [SerializeField] private int _level;

    public int Level => _level;
}
