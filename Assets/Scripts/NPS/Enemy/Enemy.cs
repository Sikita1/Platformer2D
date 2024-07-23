using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private int _reward;
    [SerializeField] private Scanner _scanner;
    
    private Player _target;

    public event UnityAction<Player> FindTarget;

    public Player Target => _target;

    private void OnEnable()
    {
        _scanner.FoundEnemy += OnFoundEnemy;
    }

    private void OnDisable()
    {
        _scanner.FoundEnemy -= OnFoundEnemy;
    }

    private void OnFoundEnemy(Player target)
    {
        _target = target;
        FindTarget?.Invoke(_target);
    }

    private void Start()
    {
        _health.FullLifes();
    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);

        if (_health.Current <= 0)
            Destroy(gameObject);
    }
}
