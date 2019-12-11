using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionGC : MonoBehaviour
{
    private float lifeTime;

    public float maxAge;

    void Start()
    {
        lifeTime = 0;
    }

    void Update()
    {
        lifeTime += Time.deltaTime;

        if (lifeTime >= maxAge)
        {
            Destroy(gameObject);
        }
    }
}
