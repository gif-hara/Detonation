using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField]
    private float delay = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, this.delay);
    }
}
