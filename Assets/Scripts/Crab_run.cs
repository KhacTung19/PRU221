using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    public float speed = 3f;
    public float patrolDistance = 5f;

    private Vector3 startPosition;
    private bool movingRight = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        // Di chuyển qoái vật
        if (movingRight)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        // Kiểm tra xem qoái vật đã di chuyển đủ khoảng cách chưa
        if (Mathf.Abs(transform.position.x - startPosition.x) >= patrolDistance)
        {
            // Đảo hướng di chuyển khi đạt đến khoảng cách nhất định
            movingRight = !movingRight;

            // Lật hình ảnh theo hướng di chuyển
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
