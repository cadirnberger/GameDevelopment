using UnityEngine;

public class Debris : MonoBehaviour
{
    float minSize = 0.5f;
    float maxSize = 5f;
    Rigidbody2D rb;
    float minspeed = 100f;
    float maxspeed = 300f;
    public float maxSpinSpeed = 10f;
    public GameObject bounceEffectPrefab;
    private float baseSpeed;
    private float elapsed = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        float randomscale = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(randomscale, randomscale, 1);
        rb = GetComponent<Rigidbody2D>();
        float randomspeed = Random.Range(minspeed, maxspeed);
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        if (randomscale > 3f)
        {
            randomspeed = randomspeed / 2;
        }
        else if (randomscale < 1f)
        {
            randomspeed = randomspeed * 2;
        }
        rb.AddForce(randomDirection * randomspeed);
        float randomTorque = Random.Range(-maxSpinSpeed, maxSpinSpeed);
        rb.AddTorque(randomTorque);
        baseSpeed = 2f;


    }
    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime; 
        float difficultyMultiplier = 1f;

        // Phase selection
        if (elapsed < 20f) // Phase 1: Easy
        {
            difficultyMultiplier = 1f;
            Debug.Log("easy" + elapsed);
        }
        else if (elapsed < 40f) // Phase 2: Medium
        {
            difficultyMultiplier = 1.5f;
            Debug.Log("medium" + elapsed);
        }
        else if (elapsed<1200f) // Phase 3: Hard
        {
            difficultyMultiplier = 2.5f;
            Debug.Log("hard" + elapsed);
        }
        else // Phase 4: Extreme
        {
            difficultyMultiplier = 5f;
            Debug.Log("extreme" + elapsed);
        }


        // Apply once instead of multiplying every frame
        rb.linearVelocity = rb.linearVelocity.normalized * baseSpeed * difficultyMultiplier;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 contactPoint = collision.GetContact(0).point;
        GameObject bounceEffect = Instantiate(bounceEffectPrefab, contactPoint, Quaternion.identity);

        // Destroy the effect after 0.5 seconds
        Destroy(bounceEffect, .5f);
         if (collision.gameObject.CompareTag("Player"))
        {
            elapsed = 0f;
        }

    }
    
}
