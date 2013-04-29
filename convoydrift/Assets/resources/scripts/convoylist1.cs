using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class convoylist1 : MonoBehaviour {
	public GameObject[] vehAry;
	private static List<GameObject> vehicles;
	//public GameObject car;
	public GameObject leader;
	private static LeadVehicleMovement leadermovement;
	// Use this for initialization
	void Start () {
		leadermovement = leader.GetComponent<LeadVehicleMovement>();
		vehicles = new List<GameObject>();
		for(int i = 0; i < vehAry.Length; i++){
			vehicles.Add (vehAry[i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public static void increaseLength(){
		leadermovement.ForwardForce += 0.6f;
		leadermovement.RotationSpeed += 7;
		List<GameObject> templist = convoylist1.getVehicles();
		int size = convoylist1.getVehicles().Count;
		Vector3 pos = templist[size-1].transform.position-templist[size-1].transform.up;
		Quaternion rot = templist[size-1].transform.rotation;
		//pos = pos-new Vector3(0,-1,0);
		GameObject tempobj = Instantiate(Resources.Load("prefabs/bodySection"), pos, rot) as GameObject;//Instantiate(Resources.Load("PrefabName"), position, rotation)
		tempobj.tag = "body";
		HingeJoint hj = templist[size-1].AddComponent("HingeJoint") as HingeJoint;
		hj.anchor = new Vector3(0,-1,0);
		hj.axis = new Vector3(0,0,1);
		hj.useLimits = true;
		JointLimits lims = hj.limits;
		lims.min = -45;
		lims.max = 45;
		hj.limits = lims;
		templist[size-1].hingeJoint.connectedBody = tempobj.rigidbody;
		//tempobj.transform.localScale = new Vector3(1,1,1);
		//OTAnimatingSprite otscript = tempobj.GetComponent<OTAnimatingSprite>();
		//otscript.size.X = 1;
		//otscript.size.Y = 1;
		convoylist1.getVehicles().Add(tempobj);
	}
	public static List<GameObject> getVehicles(){
		return vehicles;	
	}
}
