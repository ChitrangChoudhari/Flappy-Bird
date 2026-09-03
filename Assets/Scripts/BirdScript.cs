using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool BirdIsAlive = true;
    public AudioManagerScript audio;
    void Start()
    {
        logic=GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) && BirdIsAlive)
        {
            myRigidbody.linearVelocity=Vector2.up*flapStrength;
            audio.PlaySFX(audio.jump);
        }
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audio.PlaySFX(audio.collide);
        logic.gameOver();
        BirdIsAlive = false;
    }

    private void OnBecameInvisible()
    {
        logic.gameOver();
        BirdIsAlive = false;
        audio.PlaySFX(audio.end);
    }
}
