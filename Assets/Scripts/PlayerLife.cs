using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{       
    private Rigidbody2D rb;
    private Animator animation;

    [SerializeField] private AudioSource deathSoundEffect;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy")){
            Die();
            deathSoundEffect.Play();
        }
    }
    private void Die(){
        rb.bodyType = RigidbodyType2D.Static;
        animation.SetTrigger("death");
    }
    private void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
