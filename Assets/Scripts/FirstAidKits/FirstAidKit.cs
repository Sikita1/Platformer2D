using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    [field: SerializeField] public float Reward;

    public void Disappear() =>
        Destroy(gameObject);
}
