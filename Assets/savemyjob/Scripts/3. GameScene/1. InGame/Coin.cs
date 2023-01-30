using UnityEngine;

public class Coin : MonoBehaviour
{
    public Vector3 target;
    public Vector3 targetScale;
    public float speed = 0.1f;
    public bool destoryAfterMove;
    private bool isActivate;

    private void FixedUpdate()
    {
        if (isActivate)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed);
            transform.localScale = Vector3.MoveTowards(transform.localScale, targetScale, speed);

            if (destoryAfterMove)
                if (transform.position == target)
                    Destroy(gameObject);
        }
    }

    public void SetTarget(Vector3 location, Vector3 scale)
    {
        isActivate = true;
        target = location;
        targetScale = scale;
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Player"))
    //         Destroy(gameObject);
    // }
}