using UnityEngine;
using UnityEngine.Events;

public class StockAidKit : MonoBehaviour
{
    public event UnityAction<FirstAidKit> Treatment;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out FirstAidKit aidKit))
            Treatment?.Invoke(aidKit);
    }
}
