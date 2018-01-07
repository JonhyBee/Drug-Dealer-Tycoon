using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

  public GameObject defaultBody;

  List<NPCcontroller> npcs = new List<NPCcontroller>();
  // Use this for initialization
  void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    if (Input.GetKey(KeyCode.X))
    {
      NPCcontroller tmpNPC = new NPCcontroller(defaultBody);
      npcs.Add(tmpNPC);
    }
  }
}
