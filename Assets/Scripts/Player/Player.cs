using UnityEngine;

public class Player : MonoBehaviour
{
    private const string TakeDamage = "TakeDamage";
    private const string Perish = "Die";

    [SerializeField] private Sword _sword;
    [SerializeField] private Health _health;

    [SerializeField] private StockAidKit _aidKit;

    [SerializeField] private AnimatorUnit _animator;

    public bool IsDie;

    private void Start()
    {
        IsDie = false;
        _health.FullLifes();
    }

    private void OnEnable()
    {
        _aidKit.Treatment += OnTreatment;
    }

    private void OnDisable()
    {
        _aidKit.Treatment -= OnTreatment;
    }

    public void ActivateSword()
    {
        _sword.Activate();
    }

    public void DeactivateSword()
    {
        _sword.OffAttack();
    }

    public void ComeUnderAttack(float damage)
    {
        _health.TakeDamage(damage);
        _animator.Animator.SetTrigger(TakeDamage);

        if (_health.Current <= 0)
            Die();
    }

    private void OnTreatment(FirstAidKit aidKit)
    {
        _health.Increase(aidKit.Reward);

        aidKit.Disappear();
    }

    private void Die()
    {
        IsDie = true;
        _animator.Animator.SetTrigger(Perish);
    }
}
