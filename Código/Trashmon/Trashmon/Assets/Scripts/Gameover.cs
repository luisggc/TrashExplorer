using UnityEngine;
using System.Collections;

public class Gameover : MonoBehaviour {

    public UnityEngine.UI.Text pontos;
    public UnityEngine.UI.Text recorde;

    // Use this for initialization
    void Start () {
        pontos.text = PlayerPrefs.GetInt("pontuacao").ToString();
        recorde.text = PlayerPrefs.GetInt("recorde").ToString();


    }
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
            {
#pragma warning disable CS0618 // Type or member is obsolete
                Application.LoadLevel("start");
#pragma warning restore CS0618 // Type or member is obsolete
            }


    }
}
