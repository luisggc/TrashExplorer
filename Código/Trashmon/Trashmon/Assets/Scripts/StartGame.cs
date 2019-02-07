using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetMouseButtonDown(0))
        {
#pragma warning disable CS0618 // Type or member is obsolete
            Application.LoadLevel("Scene");
#pragma warning restore CS0618 // Type or member is obsolete
            //SceneManager.LoadScene("Scene");

        }
	
	}
}
