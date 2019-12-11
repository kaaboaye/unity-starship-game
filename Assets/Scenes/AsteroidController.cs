using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    private Rigidbody Body;
    private MeshRenderer Renderer;

    public float baseVelocity;

    void Start()
    {
        Body = GetComponent<Rigidbody>();
        Renderer = GetComponent<MeshRenderer>();

        Body.velocity = new Vector3(0, 0, baseVelocity);
    }

    private void FixedUpdate()
    {
        var velocity = Body.velocity;
        velocity.z = Mathf.Min(velocity.z, baseVelocity / 4);

        Body.velocity = velocity;
    }
    private void Update()
    {
        if (!Renderer.isVisible)
        {
            Destroy(gameObject);
        }
    }
}
