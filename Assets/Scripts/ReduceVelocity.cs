using UnityEngine;
using System.Collections;

public class ReduceVelocity : MonoBehaviour
{
    public Rigidbody RB;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            RB.velocity = Vector3.zero;
        }
    }
}
