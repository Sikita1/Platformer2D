using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    [SerializeField] private float _reward;

    public float Reward => _reward;

    public void Disappear()
    {
        Destroy(gameObject);
    }
}
