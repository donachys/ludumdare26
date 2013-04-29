using UnityEngine;
using System.Collections;

public class LeadVehicleMovement : MonoBehaviour {
	public float ForwardForce = 10;
	public float RotationSpeed = 10;
	private float x;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update(){
			
	}
	void OnCollisionEnter(Collision c){
		GameObject go = c.gameObject;
		if(go.CompareTag("body")){
			
			if(ScoreInfo.Score > ScoreInfo.HighScore){
				ScoreInfo.HighScore = ScoreInfo.Score;	
			}
			ScoreInfo.Score = 0;
			Application.LoadLevel (Application.loadedLevel);	
		}
	}
	void FixedUpdate () {
		//rigidbody.AddRelativeForce(Vector3.up*ForwardForce*Time.deltaTime*10);//,ForceMode.Impulse
		rigidbody.velocity = (transform.up*ForwardForce);//,ForceMode.Impulse
		//Debug.Log ("setting velocity" + rigidbody.velocity);
		x = Input.GetAxis("Horizontal") * Time.deltaTime;
		//Debug.Log("X: " + x);
		//Debug.Log ("v3x: " + Vector3.right*x*Time.deltaTime);
		//rigidbody.AddRelativeTorque(-Vector3.forward*x*RotationSpeed*20);
		rigidbody.angularVelocity = (-transform.forward*x*RotationSpeed);
	}
}
