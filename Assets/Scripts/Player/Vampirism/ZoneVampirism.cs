using UnityEngine;

public class ZoneVampirism : MonoBehaviour
{
    public Enemy Enemy { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
            Enemy = enemy;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
            Enemy = null;
    }
}
