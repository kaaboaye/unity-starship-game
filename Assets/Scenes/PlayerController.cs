using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform Transform;

    private float timeFromLastFire;

    public GameObject missile;
    public GameObject explosion;
    public float velocity;
    public float rotation;
    public float weponReleadTime;

    void Start()
    {
        Transform = GetComponent<Transform>();

        timeFromLastFire = float.PositiveInfinity;
    }

    private void FixedUpdate()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVerical = Input.GetAxis("Vertical");

        var newPostion = Transform.position;

        newPostion.x += Time.deltaTime * moveHorizontal * velocity;
        newPostion.x = Mathf.Clamp(newPostion.x, -40f, 40f);

        newPostion.z += Time.deltaTime * moveVerical * velocity;
        newPostion.z = Mathf.Clamp(newPostion.z, 0f, 60f);

        Transform.position = newPostion;

        var newRotation = Transform.rotation;
        newRotation.z = moveHorizontal * rotation;

        Transform.rotation = newRotation;
    }

    private void Update()
    {
        var submitted = Input.GetButton("Submit");

        timeFromLastFire += Time.deltaTime;

        if (submitted && timeFromLastFire > weponReleadTime)
        {
            var missilePosiotion = Transform.position;
            missilePosiotion.z += 5;

            Instantiate(missile, missilePosiotion, Quaternion.identity);

            timeFromLastFire = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Asteroid":
                Instantiate(explosion, Transform.position, Transform.rotation);

                Destroy(gameObject);

                break;
        }
    }
}
