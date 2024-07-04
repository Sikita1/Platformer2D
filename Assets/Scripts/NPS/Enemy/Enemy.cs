using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;

    [SerializeField] private int _reward;

    [SerializeField] private Player _target;

    public Player Target => _target;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
            Destroy(gameObject);
    }

    public Player GetTarget()
    {
        return _target;
    }
}
