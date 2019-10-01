using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    [SerializeField]
    private Vector3 velcity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        this.transform.position += this.velcity * Time.deltaTime;
    }
}
