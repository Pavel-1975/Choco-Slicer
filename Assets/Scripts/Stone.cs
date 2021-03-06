using System.Collections;
using UnityEngine;

public class Stone : MonoBehaviour
{
    private const int _numberŅollisions = 2;
    private static int _counter;
    private bool _blockTime;


    public void ResetCounter()
    {
        _counter = 0;
    }

    public bool ActivateCounter()
    {
        if (_blockTime == false)
        {
            float seconds = 2;
            StartCoroutine(WaitForSeconds(seconds));

            _counter++;

            _blockTime = true;
        }

        if (_counter == _numberŅollisions)
        {
            _counter = 0;

            return true;
        }

        return false;
    }

    private IEnumerator WaitForSeconds(float value)
    {
        yield return new WaitForSeconds(value);

        _blockTime = false;
    }
}
