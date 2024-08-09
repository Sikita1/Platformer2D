using UnityEngine;

public class Turning : MonoBehaviour
{
    [SerializeField] private Transform _transform;

    private bool _facingRight = false;

    public bool FacingRight => _facingRight;

    public void Flip()
    {
        _facingRight = !_facingRight;
        Vector2 scaler = _transform.localScale;
        scaler.x *= -1;
        _transform.localScale = scaler;
    }
}
