using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Health _unit;

    private void OnEnable()
    {
        _unit.ChangedValue += OnHealthChanged;
    }

    private void OnDisable()
    {
        _unit.ChangedValue -= OnHealthChanged;
    }

    protected virtual void OnHealthChanged(float health) { }
}