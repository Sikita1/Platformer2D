using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue;
    [SerializeField] private float _currentValue;

    public float Current => _currentValue;

    public void FullLifes()
    {
        _currentValue = _maxValue;
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            return;

        _currentValue = Mathf.Max(_currentValue - damage, 0);
    }

    public void Increase(float life)
    {
        if (life < 0)
            return;

        _currentValue = Mathf.Min(_currentValue + life, _maxValue);
    }
}
