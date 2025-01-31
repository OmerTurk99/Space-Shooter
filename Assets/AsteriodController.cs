using UnityEngine;

public class AsteriodController : MonoBehaviour
{
	[SerializeField] private float damage = 50f; // Asteroidin vereceği hasar

	private void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("Çarpışma algılandı: " + other.gameObject.name); // Hangi obje çarptı?

		if (other.CompareTag("Player")) // Çarpan obje "Player" mı?
		{
			PlayerHealth player = other.GetComponent<PlayerHealth>();

			if (player != null)
			{
				Debug.Log("Player bulundu! Hasar veriliyor.");
				player.TakeDamage((int)damage); // float → int dönüşümü
			}
			else
			{
				Debug.LogError("HATA: Çarpışan objede 'PlayerHealth' bileşeni YOK!");
			}

			Destroy(gameObject); // Asteroidi yok et
		}
	}

	private void OnDestroy()
	{
		if (ScoreManager.instance != null)
		{
			ScoreManager.instance.AddScore(1); // 1 puan ekle
		}
		else
		{
			Debug.LogWarning("Uyarı: ScoreManager sahnede bulunamadı!");
		}
	}
}
