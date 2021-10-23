using UnityEngine;

public abstract class StoneCollision : MonoBehaviour
{
    [SerializeField] private Pause _pause;
    [SerializeField] private ScoreSlider _scoreSlader;
    [SerializeField] private KnifeContainer _knifeContainer;
    [SerializeField] private GameObject _panelLevelFailed;

    public bool Collision { get; private set; }


    public void CollisionOff()
    {
        Collision = false;
    }

    protected void ActivateLevelFailedCanvas()
    {
        Collision = true;

        _knifeContainer.PositionDown();

        _pause.MoveUp();

        _scoreSlader.OffVisibility();

        _panelLevelFailed.SetActive(true);
    }
}
