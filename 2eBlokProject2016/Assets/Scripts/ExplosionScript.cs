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

    bool barrelHPisZero;

    CircleCollider2D explosionRadius;

    // Use this for initialization
    void Start ()
    {
        explosionRadius = gameObject.GetComponent<CircleCollider2D>();

        
    }
	
	// Update is called once per frame
	void Update ()
    {

        barrelHPisZero = gameObject.GetComponentInParent<BarrelStats>().exploded;

        if (barrelHPisZero == true)
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
        DirtStats otherDirtValues = col.gameObject.GetComponent<DirtStats>();
        CloudStats otherCloudValues = col.gameObject.GetComponent<CloudStats>();
        StoneStats otherStoneValues = col.gameObject.GetComponent<StoneStats>();
        TreeStats otherTreeValues = col.gameObject.GetComponent<TreeStats>();
        PlayerStats otherPlayerValues = col.gameObject.GetComponent<PlayerStats>();

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

            if (col.gameObject.tag == "Dirt")
            {
                otherDirtValues.dirtHP -= barrelATK;

                
            }

            if (col.gameObject.tag == "Stone")
            {
                otherStoneValues.stoneHP -= barrelATK;

                
            }

            if (col.gameObject.tag == "Cloud")
            {
                otherCloudValues.cloudHP -= barrelATK;

                
            }

            if (col.gameObject.tag == "Tree")
            {
                otherTreeValues.treeHP -= barrelATK;

                
            }

            if (col.gameObject.tag == "Player")
            {
                otherPlayerValues.playerHP -= barrelATK;
            }

            if (col.gameObject.tag == "Player2")
            {
                otherPlayerValues.playerHP -= barrelATK;
            }

            if (col.gameObject.tag == "Player3")
            {
                otherPlayerValues.playerHP -= barrelATK;
            }

            if (col.gameObject.tag == "Player4")
            {
                otherPlayerValues.playerHP -= barrelATK;
            }
        }
    }
}
