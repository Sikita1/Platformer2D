using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue;
    [SerializeField] private float _currentValue;

    public float Current => _currentValue;

    public event UnityAction<float> ChangedHealth;

    public void FullLifes()
    {
        _currentValue = _maxValue;
        ChangedHealth?.Invoke(Current);
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            return;

        _currentValue = Mathf.Max(_currentValue - damage, 0);

        ChangedHealth?.Invoke(Current);
    }

    public void Increase(float life)
    {
        if (life < 0)
            return;

        _currentValue = Mathf.Min(_currentValue + life, _maxValue);

        ChangedHealth?.Invoke(Current);
    }
}
