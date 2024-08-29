using UnityEngine;

public class Player : MonoBehaviour
{
    private const string TakeDamage = "TakeDamage";
    private const string Perish = "Die";

    [SerializeField] private Sword _sword;
    [SerializeField] private Health _health;
    [SerializeField] private StockAidKit _aidKit;
    [SerializeField] private AnimatorUnit _animator;
    [SerializeField] private Vampirism _vampirism;
    [SerializeField] private KeystrokeHandler _handler;

    public bool IsDie { get; private set; }
    public bool IsVampirismActiv { get; private set; }

    private void Start()
    {
        IsDie = false;
        _health.FullLifes();
    }

    private void OnEnable()
    {
        _aidKit.Treatment += OnTreatment;
        _vampirism.Activ += OnVampireActive;
        _vampirism.ActivOff += OnVampireActiveOff;
    }

    private void OnDisable()
    {
        _aidKit.Treatment -= OnTreatment;
        _vampirism.Activ -= OnVampireActive;
        _vampirism.ActivOff -= OnVampireActiveOff;
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

    private void OnVampireActive()
    {
        IsVampirismActiv = true;
        _handler.ForbidMove();
    }

    private void OnVampireActiveOff()
    {
        IsVampirismActiv = false;
        _handler.LetMove();
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
