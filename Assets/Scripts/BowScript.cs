using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowScript : MonoBehaviour
{
    float charge;
    public float chargeMax;
    public float chargeRate;

    public KeyCode fireButton;

    public Transform spawn;
    public Rigidbody arrowObj;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(fireButton) && charge < chargeMax)
        {
            charge += Time.deltaTime * chargeRate;
            //Debug.Log("charge :" + charge.ToString());

            
        }

        if (Input.GetKeyUp(fireButton))
        {
            Rigidbody arrow = Instantiate(arrowObj, spawn.position, spawn.rotation) as Rigidbody;
            arrow.AddForce(spawn.up * (-1) * charge, ForceMode.Impulse);
            charge = 0;
        }
    }
}
