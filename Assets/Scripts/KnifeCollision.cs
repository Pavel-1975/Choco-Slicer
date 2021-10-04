using UnityEngine;

public class KnifeCollision : StoneCollision
{
    [SerializeField] private Platform _platform;
    [SerializeField] private Vibration _vibration;
    [SerializeField] private GameObject[] _sparks;
    [SerializeField] private GameObject _particleChocolad;
    [SerializeField] private GameObject[] _particleChocolad0;
    [SerializeField] private GameObject[] _particleChocolad1;
    [SerializeField] private GameObject[] _particleChocolad2;
    [SerializeField] private Player _player;

    private int _counter;


    public void PositionDown()
    {
        SetPosition(2.4f);
    }

    public void PositionUp()
    {
        SetPosition(5f);
    }

    private void SetPosition(float positionY)
    {
        transform.position = new Vector3(transform.position.x, positionY, transform.position.z);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Trigger>(out _))
            _platform.MakeTransfer(int.Parse(collider.name.Split('_')[1]));


        if (collider.TryGetComponent(out Stone stone))
        {
            for (int i = 0; i < _sparks.Length; i++)
            {
                _sparks[i].GetComponent<ParticleSystem>().Play();
            }

            if (stone.ActivateCounter())
            {
                ActivateLevelFailedCanvas();
            }

            _vibration.Play();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent<ChocolateCollision>(out _))
        {
            int number = int.Parse(collider.name.Split('_')[1]);

            SetParticleSystem(number);

            collider.transform.parent.gameObject.SetActive(false);

            _player.SetScore();

            _vibration.Play();
        }

        Bonus(collider);
    }

    private void Bonus(Collider collider)
    {
        if (collider.TryGetComponent<BonusParticle>(out _))
        {
            _counter++;
        }

        if (collider.TryGetComponent(out EndBonus endBonus))
        {
            if (_counter == endBonus.Number)
            {
                _particleChocolad.GetComponent<ParticleSystem>().Play();

                _vibration.Play();
            }

            _counter = 0;
        }
    }

    private void SetParticleSystem(int number)
    {
        switch (number)
        {
            case 0:
                Play(_particleChocolad0);
                break;
            case 1:
                Play(_particleChocolad1);
                break;
            case 2:
                Play(_particleChocolad2);
                break;
        }
    }

    private void Play(GameObject[] particleChocolad)
    {
        for (int i = 0; i < particleChocolad.Length; i++)
        {
            particleChocolad[i].GetComponent<ParticleSystem>().Play();
        }
    }
}
