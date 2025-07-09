using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerWeapon : MonoBehaviour
{
    bool isFiring = false;
    [SerializeField] GameObject[] laser;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {


        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
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
    void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }
    void AimLasers()
    {
        foreach (GameObject laser in laser)
        {
            Vector3 fireDirection = targetPoint.position - this.transform.position; //��ǥ ��ġ - ������ ��ġ
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection); //�������� �츮�� ��� ����� ���Ϳ� ���ߵ��� ȸ�� ���
            laser.transform.rotation = rotationToTarget;
        }
    }
}
 