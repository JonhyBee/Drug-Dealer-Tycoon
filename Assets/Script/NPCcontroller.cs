using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomPosition
{
  public static Vector3 GetNewPosition()
  {
    Vector3 firstCorner = new Vector3(-25, -25, 0);
    Vector3 secondCorner = new Vector3(25, 25, 0);

    return new Vector3(Random.Range(firstCorner.x, secondCorner.x),
      Random.Range(firstCorner.y, secondCorner.y),
      Random.Range(firstCorner.z, secondCorner.z)
      );
  }
}

public static class SwapHeadSprite
{
  private static int RandSpriteNumber = (Random.Range(0, 35));

  private static Sprite FetchNewSprite()
  {
    string CurrentSpriteName = "Sprite/Heads_" + RandSpriteNumber as string;

    var TmpSprite = Resources.Load(CurrentSpriteName) as Sprite;

    return TmpSprite;


  } 

}

public class NPCcontroller : baseCharacter
{

  #region Proprieties
  private Rigidbody2D myRigidbody;
  private GameObject body;

  public NPCcontroller(GameObject defaultBody)
  {
    body = (GameObject)Instantiate(defaultBody );
    
    body.transform.position = RandomPosition.GetNewPosition();
  }

  public NPCcontroller()
  {

  }

  public float speed;
  private int WalkDirection;
  public bool isWalking;


  
  public float walkTime;
  public float waitTime;

  private float walkCounter;
  private float waitCounter;

  public static float deltaTime;
  #endregion

  // Use this for initialization
  void Start()
  {

    animator = GetComponent<Animator>();

    waitCounter = waitTime;
    walkCounter = walkTime;

    ChooseDirection();
    right = true; //Set true if the NPC is facing right at start of scene
  }

  // Update is called once per frame
  void Update()
  {
    if (isWalking)

    {
      walkCounter -= Time.deltaTime;

      switch (WalkDirection)
      {
        case 0: // Up
          animator.SetBool("Walking", true);
          transform.Translate(Vector2.up * speed);

          break;

        case 1: // Right
          if (right == false)
          {
            Flip();
          }
          animator.SetBool("Walking", true);
          transform.Translate(Vector2.right * speed);

          break;

        case 2:  // Down
          animator.SetBool("Walking", true);
          transform.Translate(Vector2.down * speed);

          break;

        case 3: // Left                    
          if (right == true)
          {
            Flip();
          }
          animator.SetBool("Walking", true);
          transform.Translate(Vector2.left * speed);

          break;
      }

      if (walkCounter < 0)
      {
        animator.SetBool("Walking", false);
        isWalking = false;
        waitCounter = waitTime;
      }

    }

    else
    {

      waitCounter -= Time.deltaTime;

      if (waitCounter < 0)
      {
        ChooseDirection();
      }
    }
  }


  public void ChooseDirection()
  {
    WalkDirection = Random.Range(0, 4);
    isWalking = true;
    walkCounter = walkTime;
  }

}
