using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deathPlane : MonoBehaviour
{
    public PlayerHealthBarController PlayerBarController;
    public Slider healthBar;
    public Rigidbody2D PlayerRB;
    public float PushBackSpeed = 1000f;
    public GameObject PlayerOBJ;
    public BoxCollider2D PlayerGC;
    public BoxCollider2D DeathColl;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(GetComponent<SpriteRenderer>());
    }


    // Update is called once per frame
    void Update()
    {
        if (PlayerGC.IsTouching(DeathColl))
        {
            
            PlayerOBJ.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, PushBackSpeed));
        }
    }
}