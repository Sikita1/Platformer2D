using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Sword _sword;
    [SerializeField] private Health _health;
    [SerializeField] private StockAidKit _aidKit;
    [SerializeField] private Vampirism _vampirism;
    [SerializeField] private KeystrokeHandler _handler;

    public event UnityAction TakingDamage;
    public event UnityAction Died;

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
        _vampirism.Activated += OnVampireActive;
        _vampirism.Deactivated += OnVampireActiveOff;
    }

    private void OnDisable()
    {
        _aidKit.Treatment -= OnTreatment;
        _vampirism.Activated -= OnVampireActive;
        _vampirism.Deactivated -= OnVampireActiveOff;
    }

    public void ActivateSword() =>
        _sword.Activate();

    public void DeactivateSword() =>
        _sword.Deactivate();

    public void ComeUnderAttack(float damage)
    {
        _health.TakeDamage(damage);
        TakingDamage?.Invoke();

        if (_health.Current <= 0)
            PassAway();
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

    private void PassAway()
    {
        IsDie = true;
        Died?.Invoke();
    }
}
