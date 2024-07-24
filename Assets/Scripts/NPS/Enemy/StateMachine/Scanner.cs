using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Scanner : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _target;

    private WaitForSeconds _wait;
    private float _delay = 1f;
    private Coroutine _coroutine;

    private Player _player;

    public UnityAction<Player> FoundEnemy;

    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);
    }

    private void Start()
    {
        _coroutine = StartCoroutine(Scan());
    }

    private void OnEnable()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator Scan()
    {
        while (true)
        {
            _player = null;

            Collider2D[] players = Physics2D.OverlapCircleAll(transform.position,
                                                              _radius,
                                                              _target);

            if (players != null)
                for (int i = 0; i < players.Length; i++)
                    _player = players[i].GetComponent<Player>();

            FoundEnemy?.Invoke(_player);

            yield return _wait;
        }
    }
}
