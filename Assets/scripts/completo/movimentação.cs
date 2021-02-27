﻿using UnityEngine;

public class movimentação : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector3 localScreenWidth;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        localScreenWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        recuo_inicial();
    }

    void FixedUpdate()
    {
        
        checkUserInput();

        // Teleporta jogador para o outro canto da tela.
        if (transform.position.x >= 1.09 * localScreenWidth.x)
        {

            transform.position = new Vector3(- 1.07f * localScreenWidth.x, transform.position.y, transform.position.z);

        }
        if (transform.position.x <= -1.09 * localScreenWidth.x)
        {

            transform.position = new Vector3( 1.07f * localScreenWidth.x, transform.position.y, transform.position.z);

        }
    }

    public void checkUserInput()
    {
        // Button clicking detection
        if(Input.GetMouseButton(0))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Debug.Log(touchPos.y);

            if(touchPos.y < 0){
                if(touchPos.x < 0){
                    rb.velocity = new Vector2( -speed, rb.velocity.y);
                }
                else{
                    rb.velocity = new Vector2( speed, rb.velocity.y);
                }
            }
        }
    }

    private void recuo_inicial(){
        while(transform.position.y >= -3.5){
            rb.velocity = new Vector2( 0, -speed);
        }
    }
}
