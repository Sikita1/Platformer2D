using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private Sword _sword;

    public bool IsDie;

    private Animator _animator;
    private BoxCollider2D _boxCollider;

    public float CurrentHealth { get; private set; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _boxCollider = _sword.GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        IsDie = false;
        CurrentHealth = _maxHealth;

        _boxCollider.enabled = false;
    }

    public void OnAttack()
    {
        _boxCollider.enabled = true;
    }

    public void OffAttack()
    {
        _boxCollider.enabled = false;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        _animator.SetTrigger("TakeDamage");

        if (CurrentHealth <= 0)
            Die();
    }

    public void Treat(float reward)
    {
        CurrentHealth += reward;

        if (CurrentHealth > _maxHealth)
            CurrentHealth = _maxHealth;
    }

    private void Die()
    {
        IsDie = true;
        _animator.SetTrigger("Die");
    }
}
