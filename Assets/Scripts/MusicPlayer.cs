using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MusicPlayer : MonoBehaviour {

    private void Awake() {
        DontDestroyOnLoad(this); // could also use gameObject instead of this
    }
	void Start () {
        Invoke("LoadFirstScene",2f);
	}
	
	// Update is called once per frame
	void LoadFirstScene () {
        SceneManager.LoadScene(1);
	}
}
