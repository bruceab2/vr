using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public int damage;

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<EnemyState>())
        {
            EnemyState state = other.GetComponent<EnemyState>();
            state.hit(damage);
            // to prevent from calling twice from same arrow
            GetComponent<Collider>().isTrigger = false;
            Debug.Log("health :" + state.health.ToString());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
