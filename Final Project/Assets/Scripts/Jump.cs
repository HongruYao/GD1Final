using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jump : MonoBehaviour
{
    public Rigidbody2D rb;

    public GameObject winPanel;

    public float jumpPower;

    bool canJump = false;

    [SerializeField] private AudioSource JSE;
    [SerializeField] private AudioSource Con;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&&canJump==true)
        {
            JSE.Play();
            canJump = false;
            rb.AddForce(Vector2.up * jumpPower);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Circle"))
        {
            canJump = true;
        }
        if (collision.transform.CompareTag("Obstacles"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("WinCondition"))
        {
            Con.Play();
            winPanel.SetActive(true);
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Level 1");
    }
}
