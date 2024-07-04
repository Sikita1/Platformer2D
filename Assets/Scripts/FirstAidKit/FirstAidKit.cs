using UnityEngine;
using UnityEngine.Events;

public class FirstAidKit : MonoBehaviour
{
    [SerializeField] private float _reward;

    private Player _target;

    public UnityAction<FirstAidKit > Matched;

    public Player Target => _target;
    public float Reward => _reward;

    public void Init(Player target)
    {
        _target = target;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            Matched?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
