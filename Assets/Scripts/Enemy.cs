using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public GameObject EnemyToGetOutOfTheWay;

	public int health = 100;

	public GameObject deathEffect;

	public void TakeDamage(int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(GetComponent<SpriteRenderer>());
		Destroy(GetComponent<Enemy>());
		Destroy(GetComponent<EnemyPatrol>());
	}

	private void GetOutOfWay()
	{
		EnemyToGetOutOfTheWay.transform.position = new Vector3(0, 0, 0);
	}

}
