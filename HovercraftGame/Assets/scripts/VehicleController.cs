using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class VehicleController : MonoBehaviour
{

    public TextMeshProUGUI timelbl; // drag your text UI element here in Inspector
    private float starttime;
    
    public float desired_acceleration_x = 0.0f;
    
    public float desired_acceleration_z = 0.0f;


    public float impulse;

    public float turnrate;

    public CheckpointController target;

    public Rigidbody _rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        target.left.materials[0].color = Color.red;
        target.right.materials[0].color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
        _rb.AddRelativeForce(desired_acceleration_x*impulse, 0, desired_acceleration_z*impulse);
        timelbl.text = string.Format("Current time: {0:F2} seconds", (Time.time - starttime));
        float dx = (Mouse.current.position.x.value - Screen.width / 2) / turnrate;
        if (Mathf.Abs(dx) > 0.01f)
        {
            transform.Rotate(0, dx, 0);
        }
        
        
    }
    
    void OnMove(InputValue action)
    {
        var movement = action.Get<Vector2>();
        desired_acceleration_x = movement.y; // move in the x direction
        desired_acceleration_z = -movement.x; // move in  the z direction
        
        Debug.Log(movement);
        
    }
}
