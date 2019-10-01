using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 爆発するオブジェクト
/// </summary>
public class DetonatableObject : MonoBehaviour
{
    [SerializeField]
    private GameObject[] effectPrefabs;

    private Rigidbody rootRigidbody;

    private Rigidbody[] rigidbodies;

    void Awake()
    {
        this.rootRigidbody = this.GetComponent<Rigidbody>();
        this.rigidbodies = this.GetComponentsInChildren<Rigidbody>();
    }

    public void TakeDetonation(Vector3 detonationPosition, float radius, float power)
    {
        this.rootRigidbody.useGravity = true;
        this.rootRigidbody.AddExplosionForce(power, detonationPosition, radius, 100.0f, ForceMode.Impulse);
        this.rootRigidbody.AddTorque(Random.Range(10.0f, 100.0f), Random.Range(10.0f, 100.0f), Random.Range(10.0f, 100.0f), ForceMode.Impulse);
        foreach(var r in this.rigidbodies)
        {
            var distance = Vector3.Distance(r.transform.position, detonationPosition);
            if(distance <= radius)
            {
                r.isKinematic = false;
                r.AddExplosionForce(power, detonationPosition, radius, 1.0f, ForceMode.Impulse);
            }
        }

        var effectPrefab = this.effectPrefabs[Random.Range(0, this.effectPrefabs.Length)];
        Instantiate(effectPrefab, detonationPosition, Quaternion.identity);
    }
}
