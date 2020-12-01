using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireButton : MonoBehaviour
{
    public GameObject banana;
    public static bool facingRight = true;
    public Transform barrelL;
    public Transform barrelR;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnFireButtonPressed()
    {
        Fire();
    }

    public void Fire()
    {
        if (facingRight)
        {
            var fireBanana = Instantiate(banana, barrelR.position, barrelR.rotation);
        }
        else
        {
            var fireBanana = Instantiate(banana, barrelL.position, barrelL.rotation);
        }
    }
}
