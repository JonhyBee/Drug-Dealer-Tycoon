using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

  public GameObject textBox;

  public Text currentText;

  public TextAsset textFile;
  public string[] textLines;

  public int currentLine;
  public int endAtLine;

  public Player player;

  // Use this for initialization
  void Start()
  {

    player = FindObjectOfType<Player>();

    if (textFile != null)
    {
      textLines = (textFile.text.Split('\n'));

    }

    if (endAtLine == 0)
    {
      endAtLine = textLines.Length - 1;
    }

  }

  // Update is called once per frame
  void Update()
  {
    currentText.text = textLines[currentLine];

    //place holder pour faire avancer le text et scroller dans les lignes courantes.
    if (Input.GetKeyDown(KeyCode.Space))
    {
      currentLine += 1;
    }

    if(currentLine > endAtLine)
    {
      textBox.SetActive(false);
      currentLine = 0;
    }

  }




}

