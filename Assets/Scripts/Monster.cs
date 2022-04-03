using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Monster : MonoBehaviour
{
    public const float speed = 1.1f;
    [Inject] Player player;
    [Inject] FloorPoints points;
    [Inject] PlayerHideSystem hideSystem;
    [SerializeField] Rigidbody2D rb;

    private new Transform transform;

    private void Start() {
        transform = rb.transform;
    }

    private void Update() {

        if(hideSystem.HideTime > 0 && hideSystem.IsHide)
        {
            rb.velocity = Hidebox.direction*new Vector3(speed,1,1);
            transform.localScale = new Vector3(Hidebox.direction.x, 1, 1);
            return;
        }

        if(player.transform.position.x > transform.position.x)
        {
            rb.velocity = Vector2.right*new Vector3(speed,1,1);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(player.transform.position.x < transform.position.x)
        {
            rb.velocity = Vector2.left*new Vector3(speed,1,1);
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if(player.Floor != Floor)
        {
            transform.position = points.poinst[player.Floor].position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        var player = other.GetComponent<Player>();
        if(player && !(hideSystem.IsHide && hideSystem.HideTime>0))
        {
            Destroy(player.gameObject);
        }
    }

    public int Floor 
    {
        get => (int)(transform.position.y / 5f);
    }
}
