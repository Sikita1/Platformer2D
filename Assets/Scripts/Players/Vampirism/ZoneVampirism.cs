using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ZoneVampirism : MonoBehaviour
{
    private List<Enemy> _enemiesDiscovered = new List<Enemy>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            _enemiesDiscovered.Add(enemy);

            _enemiesDiscovered = _enemiesDiscovered.OrderBy(enemy =>
                            (enemy.transform.position - transform.position)
                            .sqrMagnitude)
                            .ToList();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
            _enemiesDiscovered.Clear();
    }

    public bool TryGetEnemy(out Enemy enemy)
    {
        if(_enemiesDiscovered.Count == 0)
        {
            enemy = null;
            return false;
        }

        enemy = _enemiesDiscovered[0];
        return true;
    }
}
