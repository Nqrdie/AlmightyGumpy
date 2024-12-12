using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsScroll : MonoBehaviour
{
    public float speed;
    public GameObject credits;

    private void Update()
    {
        credits.transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
