using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))] 
public class Sword : MonoBehaviour
{
    [SerializeField] private int _damageWeapon;

    private BoxCollider2D _collider2D;

    private void Awake()
    {
        _collider2D = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        OffAttack();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
            enemy.TakeDamage(_damageWeapon);
    }

    public void Activate()
    {
        _collider2D.enabled = true;
    }

    public void OffAttack()
    {
        _collider2D.enabled = false;
    }
}
