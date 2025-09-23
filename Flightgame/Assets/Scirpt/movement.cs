using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{   
    // Movement parameters
    private float speed = 0.0f;
    private float rotationSpeed = 200.0f;
    public GameObject bigboosterFlame;
    public GameObject mediumboosterFlame;
    public GameObject smallboosterFlame;
    private float time = 0.0f;
    private float score = 0.0f;
    public float scoreMultiplier = 10f;
    public UIDocument uiDocument;
    private Label scoreLabel;
    private Button restartButton;
    private Label highScoreLabel;
    public GameObject explosionEffect;
    public GameObject border;
    public AudioSource boosterAudio;
    public AudioClip explosionClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        scoreLabel = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
        restartButton = uiDocument.rootVisualElement.Q<Button>("RestartButton");
        restartButton.style.display = DisplayStyle.None; // Hide restart button initially
        highScoreLabel = uiDocument.rootVisualElement.Q<Label>("HighScoreLabel");
        highScoreLabel.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        restartButton.clicked += ReloadScene;


        // Initialize game state
        score = 0.0f;
        speed = 0.0f;
        time = 0.0f;
        // Ensure all booster flames are off at start
        if (bigboosterFlame != null)
        {
            bigboosterFlame.SetActive(false);
        }
        if (mediumboosterFlame != null)
        {
            mediumboosterFlame.SetActive(false);
        }
        if (smallboosterFlame != null)
        {
            smallboosterFlame.SetActive(false);
        }
    }

    void Update()
    {
        // Update score based on time survived
        time += Time.deltaTime;
        score = Mathf.FloorToInt(time * scoreMultiplier);
        if (scoreLabel != null)
        {
            scoreLabel.text = "Score: " + score;
        }
            // Handle input for movement
        if (Keyboard.current.sKey.isPressed)
        {
            speed -= 1f;
            if (speed < -5f) speed = -5f; // Cap the maximum reverse speed
        }
        else if (speed < 0f)
        {
            // Gradually slow down reverse speed when not holding S
            speed += 0.05f;
            if (speed > 0f) speed = 0f;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
        if (Keyboard.current.dKey.isPressed)
        {
            transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
        }
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // Gradually increase speed while moving forward
        if (Keyboard.current.wKey.isPressed)
        {
            speed += 0.1f;
            if (boosterAudio != null && !boosterAudio.isPlaying)
            {
                boosterAudio.loop = true;   // make it loop
                boosterAudio.Play();    // play the sound   
            }
            if (speed > 5f) speed = 5f; // Cap the maximum speed
        }
        //
        if (!Keyboard.current.wKey.isPressed)
        {
            // Gradually decrease speed when not moving forward
            if (boosterAudio != null && boosterAudio.isPlaying)
            {
                boosterAudio.Pause();
            }
            speed -= 0.05f;
            if (speed < 0f) speed = 0f; // Prevent negative speed
        }
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            speed = 0f; // Immediate stop
        }
        if (Keyboard.current.leftShiftKey.isPressed)
        {
            speed += 0.2f; // Boost speed
            if (speed > 8f) speed = 8f; // Cap the maximum boosted speed
        }
        // Update booster flame effects based on speed
        if (smallboosterFlame != null && mediumboosterFlame != null && bigboosterFlame != null)
        {
            if (Keyboard.current.wKey.isPressed && speed < 2f)
            {
                smallboosterFlame.SetActive(true);
                mediumboosterFlame.SetActive(false);
                bigboosterFlame.SetActive(false);
            }
            else if (Keyboard.current.wKey.isPressed && speed >= 2f && speed < 5f)
            {
                smallboosterFlame.SetActive(false);
                mediumboosterFlame.SetActive(true);
                bigboosterFlame.SetActive(false);
            }
            else if (Keyboard.current.wKey.isPressed && speed >= 5f || Keyboard.current.leftShiftKey.isPressed)
            {
                smallboosterFlame.SetActive(false);
                mediumboosterFlame.SetActive(false);
                bigboosterFlame.SetActive(true);
            }
            else
            {
                smallboosterFlame.SetActive(false);
                mediumboosterFlame.SetActive(false);
                bigboosterFlame.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy the player object
        Destroy(gameObject);
        // Play explosion sound
        AudioSource.PlayClipAtPoint(explosionClip, transform.position);
        // Show explosion effect
        Instantiate(explosionEffect, transform.position, transform.rotation);
        restartButton.style.display = DisplayStyle.Flex; // Show restart button on collision
        //high score handling
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", (int)score);
            highScoreLabel.text = "High Score: " + score.ToString();
            PlayerPrefs.Save();
        }
        else
        {
            highScoreLabel.text = "High Score: " + highScore.ToString();
        }
        //deactivate border
        border.SetActive(false);



    }
    void ReloadScene()
        {
        //Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
}