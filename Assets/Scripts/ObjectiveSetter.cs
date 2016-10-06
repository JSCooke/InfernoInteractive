using UnityEngine;
using System.Collections;

public class ObjectiveSetter : MonoBehaviour {

    public string objectiveText;
    public string shortObjectiveText;
    public ObjectiveController objController;
    public bool destroyWhenActivated = true;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Tank")
        {
            objController.setNewObjective(objectiveText, shortObjectiveText);
            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
        }

        
    }

}
