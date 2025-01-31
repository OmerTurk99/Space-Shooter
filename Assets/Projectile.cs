using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Projectile : MonoBehaviour
{
	[SerializeField] float damage = 50f;
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			other.GetComponent<Health>().TakeDamage(damage);
			Destroy(gameObject);
		}
	}
}
