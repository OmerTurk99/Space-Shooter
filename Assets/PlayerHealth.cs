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

		if (player != null) // Eðer player null deðilse hasar ver
		{
			player.TakeDamage(10);
			Destroy(gameObject); // Asteroidi yok et
		}
	}


	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);

		Debug.Log("Hasar alýndý! Güncel can: " + currentHealth); // Test için ekledik

		if (currentHealth <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Debug.Log("Player öldü!");
		// Buraya oyun bitirme kodunu ekleyebilirsin.
	}
}
