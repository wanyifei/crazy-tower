using UnityEngine;
using System.Collections;

public class end : MonoBehaviour {


	public GameObject textbox;
	// Use this for initialization
	void Start () {
	
	}
	void OnMouseOver(){
		//print ("I am on mouse!");
		textbox.GetComponent<TextMesh> ().color = new Color (100,0,0,100);
	}
	
	
	void OnMouseExit(){
		textbox.GetComponent<TextMesh> ().color = new Color(255,255,255);
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) 
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);   
			
			RaycastHit hit = new RaycastHit ();
			
			if (Physics.Raycast (ray, out hit)) {
				
				if (hit.collider.gameObject == gameObject) {
					
					Application.Quit();
				}
				
			}
			
		}
	}
}
