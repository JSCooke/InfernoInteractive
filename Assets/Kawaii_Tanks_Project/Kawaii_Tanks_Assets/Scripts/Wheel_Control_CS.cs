using UnityEngine;
using System.Collections;

// This script must be attached to "MainBody".

public class Wheel_Control_CS : MonoBehaviour {

	[ Header ( "Driving settings" ) ]
	[ Tooltip ( "Torque added to each wheel." ) ] public float wheelTorque = 2000.0f ; // Reference to "Wheel_Rotate".
	[ Tooltip ( "Maximum Speed (Meter per Second)" ) ] public float maxSpeed = 7.0f ; // Reference to "Wheel_Rotate".
	[ Tooltip ( "Rate for ease of turning." ) , Range ( 0.0f , 1.0f ) ] public float turnClamp = 0.5f ;
	[ Tooltip ( "Velocity the parking brake automatically works." ) ] public float autoParkingBrakeVelocity = 0.5f ;
	[ Tooltip ( "Lag time for activating the parking brake." ) ] public float autoParkingBrakeLag = 0.5f ;
	[ Tooltip ( "'Solver Iteration Count' of all the rigidbodies in this tank." ) ] public int solverIterationCount = 7 ;

	[HideInInspector] public float leftRate ; // Reference to "Wheel_Rotate".
	[HideInInspector] public float rightRate ; // Reference to "Wheel_Rotate".

    public float speed;
    public float rotation;

	bool isParkingBrake = false ;
	float lagCount ;


	void Awake () {
		// Layer Collision Settings.
		// Layer9 >> for wheels.
		// Layer10 >> for Suspensions.
		// Layer11 >> for MainBody.
		for ( int i =0 ; i <= 11 ; i ++ ) {
			Physics.IgnoreLayerCollision ( 9 , i , false ) ; // Reset settings.
			Physics.IgnoreLayerCollision ( 11 , i , false ) ; // Reset settings.
		}
		Physics.IgnoreLayerCollision ( 9 , 9 , true ) ; // Wheels do not collide with each other.
		Physics.IgnoreLayerCollision ( 9 , 11 , true ) ; // Wheels do not collide with MainBody.
		for ( int i =0 ; i <= 11 ; i ++ ) {
			Physics.IgnoreLayerCollision ( 10 , i , true ) ; // Suspensions do not collide with anything.
		}
	}

	void Start () {
		this.gameObject.layer = 11 ; // Layer11 >> for MainBody.
		BroadcastMessage ( "Get_Wheel_Control" , this , SendMessageOptions.DontRequireReceiver ) ; // Send this reference to all the "Wheel_Rotate".
	}
	
	void Update () {
        rotation = Mathf.Clamp(rotation, -turnClamp, turnClamp);
        leftRate = Mathf.Clamp(-speed - rotation, -2.0f, 2.0f);
		rightRate = Mathf.Clamp(speed - rotation, -2.0f, 2.0f);
    }
}
