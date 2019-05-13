using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (BoxCollider2D))]
public class Terrain : MonoBehaviour
{

    //all the blocks will have a base health
    public float health = 5;
    // Start is called before the first frame update
    float originalHealth = 0;
    SpriteRenderer _rend;

    void Start()
    {
        _rend = GetComponent<SpriteRenderer>();
        originalHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        Color c = _rend.color;
        c.a = health / originalHealth;
        _rend.color = c;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
