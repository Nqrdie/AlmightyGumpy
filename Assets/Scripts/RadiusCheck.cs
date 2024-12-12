using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusCheck : MonoBehaviour
{
    public GameObject player;
    public float radius;
    public GameObject obj;
    
    void Update()
    {
        if (Vector3.Distance(obj.transform.position, player.transform.position) <= radius)
        {
            obj.SetActive(true);
        }
        else
        {
            obj.SetActive(false);
        }
    }
}
