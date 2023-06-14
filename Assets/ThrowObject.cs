using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyWork
{
    public class ThrowObject : MonoBehaviour
    {
        public Transform ThingToThrow;
        public Transform ThrowStartPosition;
        public Vector3 ThrowDirectionValue;
        public float ThrowPowerValue;
        public float MomentToThrow = 0.5f;

        public void ThrowTheObject()
        {
            Transform obj = Instantiate(ThingToThrow, ThrowStartPosition.position, Quaternion.identity);
            obj.GetComponent<Rigidbody>().velocity = transform.TransformDirection(ThrowDirectionValue).normalized * ThrowPowerValue;
        }

        public void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(ThrowStartPosition.position, ThrowStartPosition.position + transform.TransformDirection(ThrowDirectionValue).normalized * ThrowPowerValue);
        }
    }
}