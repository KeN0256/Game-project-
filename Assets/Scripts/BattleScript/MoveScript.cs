using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private Rigidbody2D r_body;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        r_body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move_x = Input.GetAxis("Horizontal"),
            move_y = Input.GetAxis("Vertical");
        //var mousePosition = Input.mousePosition;
        r_body.MovePosition(r_body.position + Vector2.right * move_x * speed * Time.deltaTime + Vector2.up * move_y * speed * Time.deltaTime);
        var direction = Input.mousePosition - UnityEngine.Camera.main.WorldToScreenPoint(transform.position); // Нахождение катетов для расчёта тангенса, а в последствии и количества градусов угла. 
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Нахождение тангенса угла и перевод его в градусы.
        r_body.MoveRotation(angle + 90);
    }
}
