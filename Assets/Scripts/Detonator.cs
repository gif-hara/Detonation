using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 爆発を起こすクラス
/// </summary>
public class Detonator : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera = null;

    [SerializeField]
    private float radius = 1.0f;

    [SerializeField]
    private float detonationPower = 1.0f;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var ray = this.mainCamera.ScreenPointToRay(Input.mousePosition);
            var hitInfo = default(RaycastHit);
            if (Physics.Raycast(ray, out hitInfo))
            {
                var detonatableObject = hitInfo.rigidbody.GetComponentInParent<DetonatableObject>();
                if(detonatableObject != null)
                {
                    detonatableObject.TakeDetonation(hitInfo.point, this.radius, this.detonationPower);
                }
            }
        }
    }
}
