using UnityEngine;
using UnityEngine.UIElements;

public class Win : MonoBehaviour
{
    public UIDocument uiDocument;
    private Label winLabel;
    private Label collectionLabel;
    public AudioClip winSound;
    public AudioSource backgroundMusic;

    void Start()
    {

        winLabel = uiDocument.rootVisualElement.Q<Label>("Win");
        winLabel.style.display = DisplayStyle.None;
        backgroundMusic.Play();

        

    }

    void Update()
    {
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && eating.cherries == eating.total)
        {
            winLabel.style.display = DisplayStyle.Flex; // Show win label
            Time.timeScale = 0f; // Pause the game
            AudioSource.PlayClipAtPoint(winSound, Camera.main.transform.position);
            backgroundMusic.Stop();

        }
    }
}
