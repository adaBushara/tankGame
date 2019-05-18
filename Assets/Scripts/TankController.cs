using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Rigidbody2D> wheels;

    public float movement_speed = 2000;

    public float hingeSpeed = 100;

    public GameObject gunHinge;

    public GameObject FirePoint;

    public GameObject Bullet; // the bullet that we have

    public float fireForce = 50;
    void Start()
    {
        
    }

    float elapsedTime = 0.0f;
    public float coolDown = 0.16f;
    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        for (int i = 0; i < wheels.Count; i++)
        {
            float dragFactor = 1.0f - (Input.GetAxis("RTrigger_P1") * 0.5f);
            wheels[i].AddTorque(Input.GetAxis("Horizontal_P1") * -movement_speed * dragFactor);
            Vector3 force = Vector3.up * 0.1f + Vector3.right * -Input.GetAxis("Horizontal_P1");
            wheels[i].AddForce(force, ForceMode2D.Impulse);
        }

        if (Input.GetAxis("A_P1") > 0)
        {
            if (elapsedTime >= coolDown)
            {
                elapsedTime = 0;
                Debug.Log("A Button Pressed");

                GameObject b = Instantiate<GameObject>(Bullet, FirePoint.transform.position, gunHinge.transform.rotation);

                b.GetComponent<Rigidbody2D>().AddForce(FirePoint.transform.right * fireForce, ForceMode2D.Impulse);

                b.GetComponent<Projectile>().Owner = gameObject;
            }
        }

        if (Input.GetAxis("B_P1") > 0)
        {
            Debug.Log("B Button Pressed");
        }

        //if (Input.GetAxis("LTrigger_P1") > 0)
        //{
        //    Debug.Log("Left Trigger Pulled");
        //}
        
        //if (Input.GetAxis("RTrigger_P1") > 0)
        //{
        //    Debug.Log("Right Trigger Pulled");
        //}

        //if (Input.GetAxis("LBumper_P1") > 0)
        //{
        //    Debug.Log("Left Bumper Pressed");
        //}

        //if (Input.GetAxis("RBumper_P1") > 0)
        //{
        //    Debug.Log("Right Bumper Pressed");
        //}
      
       if ( Input.GetButtonUp("RBumper_P1") || Input.GetButtonUp("LBumper_P1"))
        {
            Debug.Log("Button Released");
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.position += Vector3.up;
        }

        if ( (Input.GetAxis("RBumper_P1") + Input.GetAxis("LBumper_P1") ) > 0)
        {
            //we have to flip the character
            
            //gameObject.transform.position += Vector3.up;
        }

        if (gunHinge != null)
        {
            float dragFactor = 1.0f - (Input.GetAxis("LTrigger_P1") * 0.5f);
            Vector3 eul = gunHinge.transform.rotation.eulerAngles;
            eul.z += Input.GetAxis("RHorizontal_P1") * -hingeSpeed * dragFactor;
            gunHinge.transform.rotation = Quaternion.Euler(eul);
        }
      
    }
}
