using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Health _unit;

    private void OnEnable()
    {
        _unit.ChangedHealth += OnHealthChanged;
    }

    private void OnDisable()
    {
        _unit.ChangedHealth -= OnHealthChanged;
    }

    protected virtual void OnHealthChanged(float health) { }
}