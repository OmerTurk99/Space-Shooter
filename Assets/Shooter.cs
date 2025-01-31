using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] float hitRate = 1.0f;
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;

    Coroutine firingCoroutine = null;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (firingCoroutine == null)
            {
                firingCoroutine = StartCoroutine(FiringCoroutine());
            }
        }
    }

    private IEnumerator FiringCoroutine()
    {
        while (true) 
        {
            GameObject instance = Instantiate(projectile, transform.position, Quaternion.identity);
            instance.GetComponent<Rigidbody2D>().linearVelocity = transform.up * projectileSpeed;
            Destroy(instance, projectileLifetime);
            yield return new WaitForSeconds(1/hitRate);

        }
       
    }

}
