using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float bulletForce;

    private void Start()
    {
        bulletForce = 20;
    }

    void OnCollisionEnter(Collision col)
    {
        Vector3 bulletSpeed = GetComponent<Rigidbody>().velocity;
        bulletSpeed *= bulletForce;
        Destroy(gameObject);
        //Geting the only the gameobjects that have health (in this case the players)
        var health = col.gameObject.GetComponent<Health>();
        if (health != null)
        {
            //TODO Diferent damage if powerup activated
            health.TakeDamage(10);
            if (col.gameObject.tag == "Player")
            {
                var playerRb = col.gameObject.GetComponent<Rigidbody>();
                playerRb.AddForce(bulletSpeed);

            }


        }

    }
}


