using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] float speed = 5f;
	void Update()
	{
		float horizontalSpeed = Input.GetAxis("Horizontal");
		float verticalSpeed = Input.GetAxis("Vertical");
		Vector2 direction = new Vector2(horizontalSpeed, verticalSpeed);
		transform.Translate(speed * Time.deltaTime * new Vector2(horizontalSpeed, verticalSpeed));
	}
}
