using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerHealthBarController : MonoBehaviour
{
    //Publics
    public float invulTime = 3f;
    public float invulBeforeControl = 1.5f;
    public int CurrentHealth;

    public HealthBarController healthBar;
    public BoxCollider2D PlayerCollider;
    public BoxCollider2D PlayerGroundCollider;
    public BoxCollider2D EnemyCollider;
    public BoxCollider2D DeathCollider;
    //Privates
    private bool isInvul = false;
    private void Start()
    {
        CurrentHealth = 100;
        healthBar.SetMaxHealth(815);
    }
    public void TakeDamage(int damage)
    {
            CurrentHealth -= damage;
            healthBar.SetHealth(CurrentHealth);
    }
    private void Update()
    {
        if (PlayerCollider.IsTouching(EnemyCollider) && isInvul == false && EnemyCollider != null)
        {
            TakeDamage(20);
            StartCoroutine(GetHurt());
        }
        if (EnemyCollider == null)
        {
            EnemyCollider = GameObject.FindWithTag("BackupEnemy").GetComponent<BoxCollider2D>();
        }

        if (PlayerGroundCollider.IsTouching(DeathCollider) && isInvul == false)
        {
            TakeDamage(20);
            StartCoroutine(GetHurt());
        }
    }
    IEnumerator TakeControl()
    {
        CharacterController2D cc = GetComponent<CharacterController2D>();
        cc.enabled = false;
        yield return new WaitForSeconds(invulBeforeControl);
        cc.enabled = true;
    }

    IEnumerator GetHurt()
    {
        isInvul = true;
        yield return new WaitForSeconds(invulTime);
        isInvul = false;
    }

}
