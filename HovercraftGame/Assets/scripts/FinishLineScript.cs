using UnityEngine;

public class FinishLineScript : MonoBehaviour
{
    public int totalCheckpoints;
    
    void Start()
    {
        totalCheckpoints = FindObjectsOfType<CheckpointController>().Length;
    }


    private void OnTriggerExit(Collider other)
    {
        VehicleController vehicle = other.GetComponent<VehicleController>();
        
        // add a check to that way it passes all the check points
        if (vehicle.checkpointcounter >= totalCheckpoints -1 )
        {
            Debug.Log($"we crossed the finish line {other.gameObject.name} ");
            // incease the lap counter in the ui
            vehicle._lapCounter++;
            vehicle.checkpointcounter = 0; // reset to 0 when cross finish line
        }
        else
        {
            Debug.Log("cheating");
        }
        
    }
}
