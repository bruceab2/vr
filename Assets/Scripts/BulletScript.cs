using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody bulletBody;
    public KeyCode fireButton;
    public Transform spawn;
    public int force;
    public float fireRate; // Rounds Per Second


    public int damage;

    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKey(fireButton) && timer >= (1.0 / fireRate))
        {
            Fire();
            timer = 0;
        }
    }

    void Fire()
    {
        Rigidbody bullet = Instantiate(bulletBody, spawn.position, spawn.rotation) as Rigidbody;
        bullet.AddForce(spawn.forward * force, ForceMode.Impulse);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerState>())
        {
            PlayerState state = other.GetComponent<PlayerState>();
            state.hit(damage);
            
            Debug.Log("health :" + state.health.ToString());

        }
        // destroy bullet
        Destroy(gameObject);
    }
}
