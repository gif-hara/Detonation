using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab = null;

    [SerializeField]
    private Vector3 randomMin = Vector3.zero;

    [SerializeField]
    private Vector3 randomMax = Vector3.zero;

    [SerializeField]
    private float interval = 1.0f;

    private float timer = 0.0f;

    void Update()
    {
        this.timer += Time.deltaTime;

        if(this.interval <= this.timer)
        {
            this.timer = 0.0f;
            var position =
                this.transform.position +
                new Vector3(
                    Random.Range(this.randomMin.x, this.randomMax.x),
                    Random.Range(this.randomMin.y, this.randomMax.y),
                    Random.Range(this.randomMin.z, this.randomMax.z)
                    );

            Instantiate(this.prefab, position, this.transform.rotation);
        }
    }
}
