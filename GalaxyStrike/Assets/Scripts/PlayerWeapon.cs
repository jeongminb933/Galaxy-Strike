using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerWeapon : MonoBehaviour
{
    bool isFiring = false;
    [SerializeField] GameObject[] laser;
    [SerializeField] RectTransform crosshair;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isFiring);

        ProcessFiring();
        MoveCrosshair();
    }

    private void ProcessFiring()
    {
        //Debug.Log("Fire");
        //for (int i = 0; i < laser.Length; i++)
        //{
        //    var emmissionModule = laser[i].GetComponent<ParticleSystem>().emission;
        //    emmissionModule.enabled = isFiring;
        //}
        foreach (GameObject laser in laser) 
        {
            var emmissionModule = laser.GetComponent<ParticleSystem>().emission;
            emmissionModule.enabled = isFiring;
        }
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }
}
 