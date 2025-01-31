using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float healthPoints = 100f;

    public void TakeDamage(float damage)
    {
        healthPoints = Mathf.Max(healthPoints - damage,0);
        if (healthPoints == 0)
        {
            Destroy(gameObject);
        }
    }
}
