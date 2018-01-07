using UnityEngine;
using System.Collections;



public abstract class baseCharacter : MonoBehaviour
{

  internal Animator animator;
  internal bool right;
  internal void Flip()
  {
    Vector3 scale = transform.localScale;
    scale.x *= -1;
    transform.localScale = scale;
    right = !right;
  }

  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
}
