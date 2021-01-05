using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimientoCamara : MonoBehaviour
{  
    public GameObject follow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float posX = follow.transform.position.x-8;
        float posY = follow.transform.position.y+7;
        float posZ = follow.transform.position.z+10;

        transform.position = new Vector3(posX, posY, posZ);
        transform.rotation = Quaternion.Euler(20,-180,0);


    }
}
