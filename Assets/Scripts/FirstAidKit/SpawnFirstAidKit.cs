using System.Collections;
using UnityEngine;

public class SpawnFirstAidKit : MonoBehaviour
{
    [SerializeField] private FirstAidKit  _aidKit;
    [SerializeField] private int _numberAidKit;
    [SerializeField] private float _interval;

    [SerializeField] private Transform _leftEdge;
    [SerializeField] private Transform _rightEdge;

    private WaitForSeconds _delay;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        _delay = new WaitForSeconds(_interval);

        for (int i = 0; i < _numberAidKit; i++)
        {
            Instatiate();

            yield return _delay;
        }
    }

    private void Instatiate()
    {
        int randomPositionX = Random.Range((int)_leftEdge.position.x, (int)_rightEdge.position.x);

        FirstAidKit aidKit = Instantiate(_aidKit,
                        new Vector2(randomPositionX, _rightEdge.position.y),
                        Quaternion.identity).GetComponent<FirstAidKit >();
    }
}
