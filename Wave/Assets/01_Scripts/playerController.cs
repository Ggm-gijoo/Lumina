using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField]
    private StageController stageController;
    private Movement2D movement;

    private void Awake()
    {
        movement = GetComponent<Movement2D>();
    }

    private void FixedUpdate()
    {
        movement.MoveToX();

        if (!stageController.IsGameOver)
        {
            if (Input.GetMouseButton(0))
            {
                movement.MoveToY();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Item"))
        {
            stageController.IncreaseScore(1);
            Destroy(collision.gameObject);
        }
        else if (collision.tag.Equals("Obstacle"))
        {
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            stageController.GameOver();
        }
    }
}
