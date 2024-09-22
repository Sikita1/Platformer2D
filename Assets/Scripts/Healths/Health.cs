using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue;
    [SerializeField] private float _currentValue;

    public event UnityAction<float> ChangedValue;
    
    public float Current => _currentValue;
    public float MaxValue => _maxValue;

    public void FullLifes()
    {
        _currentValue = 80f;
        ChangedValue?.Invoke(Current);
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            return;

        _currentValue = Mathf.Max(_currentValue - damage, 0);

        ChangedValue?.Invoke(Current);
    }

    public void Increase(float life)
    {
        if (life < 0)
            return;

        _currentValue = Mathf.Min(_currentValue + life, _maxValue);

        ChangedValue?.Invoke(Current);
    }
}
