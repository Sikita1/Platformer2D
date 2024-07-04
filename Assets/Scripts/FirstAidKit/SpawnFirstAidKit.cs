using System.Collections;
using UnityEngine;

public class SpawnFirstAidKit : MonoBehaviour
{
    [SerializeField] private FirstAidKit  _scroll;
    [SerializeField] private int _numberScrolls;
    [SerializeField] private float _interval;

    [SerializeField] private Transform _leftEdge;
    [SerializeField] private Transform _rightEdge;

    [SerializeField] private Player _player;

    private WaitForSeconds _delay;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        _delay = new WaitForSeconds(_interval);

        for (int i = 0; i < _numberScrolls; i++)
        {
            Instatiate();

            yield return _delay;
        }
    }

    private void OnTakeScroll(FirstAidKit  scroll)
    {
        scroll.Matched -= OnTakeScroll;

        _player.Treat(scroll.Reward);
    }

    private void Instatiate()
    {
        int randomPositionX = Random.Range((int)_leftEdge.position.x, (int)_rightEdge.position.x);

        FirstAidKit  scroll = Instantiate(_scroll,
                        new Vector2(randomPositionX, _rightEdge.position.y),
                        Quaternion.identity).GetComponent<FirstAidKit >();

        scroll.Matched += OnTakeScroll;
    }
}
