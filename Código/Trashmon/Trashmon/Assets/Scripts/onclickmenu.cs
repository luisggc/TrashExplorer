using UnityEngine;
using System.Collections;

public class onclickmenu : MonoBehaviour {

    public float time;
    public float times;

    // Use this for initialization
    void Start () {
        times = 1;
	}
	
	// Update is called once per frame
	void Update () {
        time += times * Time.deltaTime;

        if ((Input.anyKey) && time>2)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            Application.LoadLevel("start");
#pragma warning restore CS0618 // Type or member is obsolete
        }


    }
}
