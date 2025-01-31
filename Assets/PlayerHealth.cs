using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	public int maxHealth = 1000;
	private int currentHealth;
	public HealthBar healthBar;

	void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		PlayerHealth player = other.GetComponent<PlayerHealth>();

		if (player != null) // E�er player null de�ilse hasar ver
		{
			player.TakeDamage(10);
			Destroy(gameObject); // Asteroidi yok et
		}
	}


	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);

		Debug.Log("Hasar al�nd�! G�ncel can: " + currentHealth); // Test i�in ekledik

		if (currentHealth <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Debug.Log("Player �ld�!");
		// Buraya oyun bitirme kodunu ekleyebilirsin.
	}
}
