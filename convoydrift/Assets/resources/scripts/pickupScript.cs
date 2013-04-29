using UnityEngine;
using System.Collections;

public class pickupScript : MonoBehaviour {
	GameObject so;
	// Use this for initialization
	void Start () {
		//Resources.Load("sounds/testsound1");
		so = GameObject.FindGameObjectWithTag("sound1");
		Debug.Log(so);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Player"){
			convoylist1.increaseLength();
			//spawn another pickup
			SpawnLocations spawns = GameObject.FindObjectOfType(typeof(SpawnLocations)) as SpawnLocations;
			Vector3 pos = spawns.getSpawnLocation();
			Quaternion rot = transform.rotation;//new Quaternion(0f,0f,0f,0f);
			GameObject tempobj = Instantiate(Resources.Load("prefabs/pickup"), pos, rot) as GameObject;
			so.audio.Play();
			ScoreInfo.Score += 1;
			Destroy (this.gameObject);
		}
	}
}
