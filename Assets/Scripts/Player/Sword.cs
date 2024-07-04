using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))] 
public class Sword : MonoBehaviour
{
    [SerializeField] private int _damageWeapon;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
            enemy.TakeDamage(_damageWeapon);
    }
}
