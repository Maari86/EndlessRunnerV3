using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Distance : MonoBehaviour
{
    [SerializeField] private Transform CheckPoint;

    [SerializeField] private TextMeshProUGUI distanceText;

    private float distance;

    private void Update()
    {
        distance = (CheckPoint.transform.position.x - transform.position.x);

        distanceText.text = "Distance: " + distance.ToString("F1") + "m";

        if (distance >= 0)
        {
            distanceText.text = "start!";
        }
    }

  
}
