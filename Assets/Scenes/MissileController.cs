using UnityEngine;

public class MissileController : MonoBehaviour
{
    private Transform Transform;
    private Rigidbody Body;
    private MeshRenderer Renderer;
    private GameScore Score;

    public Vector3 startingVewlocity;
    public GameObject explosion;
    public float thrust;

    void Start()
    {
        Transform = GetComponent<Transform>();
        Body = GetComponent<Rigidbody>();
        Renderer = GetComponent<MeshRenderer>();
        Score = GameObject.Find("/Game").GetComponent<GameScore>();

        Body.velocity = startingVewlocity;
    }

    private void FixedUpdate()
    {
        Body.AddRelativeForce(new Vector3(0, 0, 1) * thrust);
    }

    private void Update()
    {
        if (!Renderer.isVisible)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Asteroid":
                Score.AsteroidDestroied();

                Instantiate(explosion, Transform.position, Transform.rotation);

                Destroy(collision.gameObject);
                Destroy(gameObject);

                break;
        }
    }
}
