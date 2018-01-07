using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : baseCharacter
{

  public float speed;

  public Inventory inventory { get; set; }

  void Start()
  {
    animator = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()

  {
    HandleMovement();

  }

  private void HandleMovement()
  {
    animator.SetBool("Walking", false);
    if (Input.GetKey(KeyCode.A))
    {
      if (right == false)
      {
        Flip();
      }
      animator.SetBool("Walking", true);
      transform.Translate(Vector2.right * speed);
    }

    if (Input.GetKey(KeyCode.D))
    {
      if (right == true)
      {
        Flip();
      }
      animator.SetBool("Walking", true);
      transform.Translate(Vector2.left * speed);
    }

    if (Input.GetKey(KeyCode.W))
    {
      animator.SetBool("Walking", true);
      transform.Translate(Vector2.up * speed);
    }

    if (Input.GetKey(KeyCode.S))
    {
      animator.SetBool("Walking", true);
      transform.Translate(Vector2.down * speed);
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Item")
    {
      inventory.AddItem(other.GetComponent<Item>());
    }
  }
}