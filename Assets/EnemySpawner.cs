using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] meteors;
    [SerializeField] float spawningRate = 1f;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float startingPointAtY;
    [SerializeField] float meteorSpeed = 5f;
    [SerializeField] float meteorLifetime = 10f;
    Coroutine spawnerCoroutine = null;

    void Update()
    {
        if (spawnerCoroutine == null)
        {
            spawnerCoroutine = StartCoroutine(SpawnerCoroutine());
        }
    }

    private IEnumerator SpawnerCoroutine()
    {
        while (true)
        {
            float xPoint = UnityEngine.Random.Range(minX, maxX);
            int meteorIndex = UnityEngine.Random.Range(0, meteors.Length);
            GameObject meteor = Instantiate(meteors[meteorIndex]);
            meteor.transform.position = new Vector2(xPoint, startingPointAtY);
            meteor.GetComponent<Rigidbody2D>().linearVelocity = Vector2.down*meteorSpeed;
            Destroy(meteor, meteorLifetime);
            yield return new WaitForSeconds(1 / spawningRate);
        }
    }

}
