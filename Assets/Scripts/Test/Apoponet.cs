//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;


//public class Apoponet : MonoBehaviour
//{
//    public Transform player;
//    int health = 100;
//    public Rigidbody bullet;
//    public Transform spawner;
//bool isShoot = false;
//    private void Start()
//    {
//        StartCoroutine(shoot());
//    }
//    void Update()
//    {
//        RaycastHit hit;
//        Vector3 distance = this.transform.position - player.transform.position;
//        distance.y = 0;
//        if(Physics.Linecast (this.transform.position, player.transform.position, out hit, -1)){
//            if (hit.transform.CompareTag("Player"))
//            {
//                if(distance.magnitude > 5)
//                {
//                this.transform.Translate(Vector3.forward * 2f * Time.deltaTime);
//                this.transform.LookAt(player.transform);
//                    isShoot = false;
//                }
//                else
//                {
//                    isShoot = true;
//                    this.transform.LookAt (player.transform);

//                }

//            }
//        }
//        if(health < 1)
//        {
//            this.gameObject.SetActive(false);
//        }

//    }
//    IEnumerator shoot()
//    {
//        yield return new WaitForSeconds(0.3f);
//        if (isShoot)
//        {
//            Rigidbody clone;
//            clone = (Rigidbody)Instantiate(bullet,spawner.transform.position, Quaternion.identity);
//            clone.velocity = spawner.TransformDirection(Vector3.forward * 1000 * Time.deltaTime);
//        }

//        StartCoroutine (shoot());
//    }
//    private void OnTriggerEnter(Collider coll)
//    {
//        if(coll.gameObject.tag == "Bullet")
//        {
//            health -= 20;
//        }
//    }
//}


using System.Collections;
using UnityEngine;

public class Apoponet : MonoBehaviour
{
    public Transform vrPlayerTarget;
    int health = 100;
    public Rigidbody bullet;
    public Transform spawner;
    bool isShoot = false;

    private void Start()
    {
        StartCoroutine(shoot());
        Debug.Log("Shoot coroutine started!"); // Check if coroutine starts
    }

    void Update()
    {
        if (vrPlayerTarget == null)
        {
            Debug.LogError("vrPlayerTarget is not assigned!");
            return;
        }

        RaycastHit hit;
        Vector3 distance = this.transform.position - vrPlayerTarget.position;
        distance.y = 0;

        Debug.DrawLine(this.transform.position, vrPlayerTarget.position, Color.red); // Visualize raycast

        if (Physics.Linecast(this.transform.position, vrPlayerTarget.position, out hit, -1))
        {
            if (hit.transform.CompareTag("Player"))
            {
                Debug.Log("Player detected!");
                if (distance.magnitude > 5)
                {
                    this.transform.Translate(Vector3.forward * 2f * Time.deltaTime);
                    this.transform.LookAt(vrPlayerTarget);
                    isShoot = false;
                }
                else
                {
                    isShoot = true;
                    this.transform.LookAt(vrPlayerTarget);
                }
            }
        }

        if (health < 1)
        {
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator shoot()
    {
        while (true) // Keep the coroutine running
        {
            yield return new WaitForSeconds(0.3f);

            if (isShoot)
            {
                Debug.Log("Shooting!");
                Rigidbody clone;
                clone = Instantiate(bullet, spawner.transform.position, spawner.transform.rotation);
                clone.AddForce(spawner.forward * 1000f);
            }
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            health -= 20;
        }
    }
}