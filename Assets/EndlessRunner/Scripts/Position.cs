using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    [SerializeField] private Transform PreviousLayer;
    [SerializeField] private Transform NextLayer;
    [SerializeField] private CamerController cam;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (collision.transform.position.x < transform.position.x)
                cam.MoveToStartingPoint(NextLayer);
            else
                cam.MoveToStartingPoint(PreviousLayer);
        }
    }
}
