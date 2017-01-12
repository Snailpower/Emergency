using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

    public int barrelATK = 10;

    public float explosionDelay = 1f;
    public float explosionRate = 1f;
    public float explosionMaxSize = 5f;
    public float explosionSpeed = 1f;
    public float currentRadius = 0f;
    bool exploded = false;

    CircleCollider2D explosionRadius;

    // Use this for initialization
    void Start ()
    {
        explosionRadius = gameObject.GetComponent<CircleCollider2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (BarrelStats.exploded == true)
        {
            explosionDelay -= Time.deltaTime;
            if (explosionDelay < 0)
            {
                exploded = true;
            }
        }

    }

    void FixedUpdate()
    {
        if (exploded == true)
        {
            if (currentRadius < explosionMaxSize)
            {
                currentRadius += explosionRate;
            }
            else
            {
                Destroy(gameObject.transform.parent.gameObject);
            }

            explosionRadius.radius = currentRadius;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        Rigidbody2D colRigidbody = col.gameObject.GetComponent<Rigidbody2D>();

        if (exploded == true)
        {

            if (colRigidbody != null)
            {
                Vector2 target = col.gameObject.transform.position;
                Vector2 bomb = gameObject.transform.position;

                Vector2 direction = 200f * (target - bomb);

                colRigidbody.AddForce(direction);

                Debug.Log("Boom");
            }
        }
    }
}
