using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;


public class PlayerController : MonoBehaviour
{
    //Movimiento
    public Rigidbody2D rb;
    private Vector2 input;
    public float speed;

    [SerializeField] private FMODUnity.StudioEventEmitter audioEmitterJump;
    [SerializeField] private FMODUnity.StudioEventEmitter audioEmitterAterrizaje;
    [SerializeField] private FMODUnity.StudioEventEmitter audioEmitterWalk;

    [SerializeField] private FMODUnity.StudioGlobalParameterTrigger globalValueA;
    [SerializeField] private FMODUnity.StudioGlobalParameterTrigger globalValueB;


    //Salto
    public bool isGrounded;
    public float jumpForce;

    //Pause
    private bool peuseOn;
    public GameObject menuDePausa;

    private void Move(Vector2 input)
    {
        this.input = input;
        audioEmitterWalk.Play();
    }

    private void Update()
    {
     
    }

    private void FixedUpdate()
    {
        Vector2 velocity = new Vector2(input.x, input.y);
        rb.position += velocity*Time.fixedDeltaTime * speed;
    }

    private void OnEnable()
    {
        InputManager.OnPlayerMovement += Move;
        InputManager.OnJump += Jump;
        InputManager.OnPause += Pause;
    }
   
    private void OnDisable()
    {
        InputManager.OnPlayerMovement -= Move;
        InputManager.OnJump -= Jump;
        InputManager.OnPause -= Pause;
    }

    void Jump()
    {
        if(isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            audioEmitterJump.Play();
            isGrounded = false;
        }
    }

    void Pause()
    {
        
         peuseOn = !peuseOn;

        if (peuseOn == true)
        {
            menuDePausa.SetActive(true);
            globalValueB.TriggerParameters();
            //Time.timeScale = 0f;
        }
        else
        {
            menuDePausa.SetActive(false);
            globalValueA.TriggerParameters();
            //Time.timeScale = 1f;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            audioEmitterAterrizaje.Play();
        }

    }

    //HASHIRE SORI YO KAZE NO YOU NI TSUKIMIHARA WO PADORU PADORU
    //QUE LINDO MI PROFESOR
    //HASHIRE SORI YO KAZE NO YOU NI TSUKIMIHARA WO PADORU PADORU
    //QUE LINDO MI PROFESOR
    //HASHIRE SORI YO KAZE NO YOU NI TSUKIMIHARA WO PADORU PADORU
    //QUE LINDO MI PROFESOR
    //HASHIRE SORI YO KAZE NO YOU NI TSUKIMIHARA WO PADORU PADORU
    //QUE LINDO MI PROFESOR
    //HASHIRE SORI YO KAZE NO YOU NI TSUKIMIHARA WO PADORU PADORU

}
