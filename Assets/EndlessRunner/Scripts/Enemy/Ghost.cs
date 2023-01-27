using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public GameObject DestroyGhost;

    private void OnTrriggerEnter2D(Collider2D col)
    {
        if(col. gameObject.tag == "bullet")
        {
            Instantiate(DestroyGhost, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


}
