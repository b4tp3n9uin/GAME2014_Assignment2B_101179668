using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CherryScript : MonoBehaviour
{

    public static int cherry;
    Text cherryText;

    // Start is called before the first frame update
    void Start()
    {
        cherryText = GetComponent<Text>();
        cherry = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cherryText.text = cherry+ "/8";
    }
}
