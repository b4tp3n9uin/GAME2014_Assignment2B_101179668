using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    [SerializeField]
    public float destroyTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}
