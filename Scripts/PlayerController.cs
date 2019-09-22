using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public Text LivesText;

    private Rigidbody2D rb2d;
    private int count;
    public int Lives;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        Lives = 3;
        winText.text = "";

        setCountText();
        setLivesText();
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            setCountText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            Lives = Lives - 1;
            setLivesText();
        }
        if (count == 13)
        {
            transform.position = new Vector2(1.6f, -49f);
        }
        if (Lives == 0)
        {
            Destroy(gameObject);
        }
    }

    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 25)
        {
            winText.text = "You win! Made by Ricardo Gonzalez";
        }
    }
    void setLivesText()
    {
        LivesText.text = "Lives: " + Lives.ToString();
        if (Lives == 0)
        {
            winText.text = "You Lose! Try again";
        }
    }
}