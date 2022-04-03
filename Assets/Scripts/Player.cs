using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [Inject] UIActions actions; 
    [Inject] PlayerHideSystem hideSystem;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private bool left;
    private bool right;
    private Actionable actionable; 

    public void SetActionable(Actionable actionable) => this.actionable = actionable;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        var scale = transform.localScale;

        actions.LeftButtonPressed += () =>
        {
            rb.velocity = Vector2.left;
            transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
            hideSystem.IsHide = false;
        };
        actions.RightButtonPressed += () =>
        {
            rb.velocity = Vector2.right;
            transform.localScale = new Vector3(scale.x, scale.y, scale.z);
            hideSystem.IsHide = false;
        };
        actions.ActionButton.onClick.AddListener( () => 
        {
            actionable?.Action();
        });
    }

    private void Update() {
        hideSystem.Update();
        if(hideSystem.IsHide)
        {
            sprite.color = new Color(1, 1, 1, .5f);
        }
        else
        {
            sprite.color = new Color(1, 1, 1, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        actionable = other.GetComponent<Actionable>();
        if(actionable)
        {
            actions.ActionButton.interactable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        actionable = other.GetComponent<Actionable>();
        if(actionable)
        {
            actions.ActionButton.interactable = false;
        }
    }

    public int Floor 
    {
        get => (int)(transform.position.y / 5f);
    }
}
