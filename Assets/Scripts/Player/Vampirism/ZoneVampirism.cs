using System.Collections.Generic;
using UnityEngine;

public class ZoneVampirism : MonoBehaviour
{
    private List<Enemy> _enemiesDiscovered = new List<Enemy>();

    public List<Enemy> EnemiesDiscovered => _enemiesDiscovered;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
            _enemiesDiscovered.Add(enemy);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
            _enemiesDiscovered.Clear();
    }
}
