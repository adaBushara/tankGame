using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage = 0.5f;

    [Range(0,20)]
    public float splashRadius = 1.0f;


    public float lifeTime = 30.0f;

    public float timeElapsed = 0.0f;

    [HideInInspector]
    public GameObject Owner;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > 30.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //destroy self
        //damage objects near us (with falloff)
        //apply knockback to anything that can be moved
        if (collision.gameObject.GetComponent<Terrain>())
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, splashRadius, Vector2.zero);

            for (int i = 0; i < hits.Length; i++)
            {
                Terrain ter = hits[i].collider.gameObject.GetComponent<Terrain>();
                if (ter)
                {
                    ter.health -= (damage * (1.0f - hits[i].distance / splashRadius));
                }
            }
            Destroy(gameObject);
        }

    }
}
