using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductoScript : MonoBehaviour
{
    public int precio;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 40f * Time.deltaTime, 0f, Space.Self);
    }
}
