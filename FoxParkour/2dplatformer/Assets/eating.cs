using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class eating : MonoBehaviour
{
    [SerializeField] ParticleSystem Eating;
    public AudioClip pickupSound;
    public static int cherries = 0;
    public static int total = 4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Eating.Stop();

    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Eating.transform.parent = null; // Detach from cherry
            Eating.Play();
            cherries++;
            AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
    
}
