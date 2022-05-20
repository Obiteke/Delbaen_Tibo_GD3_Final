using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DashScript : MonoBehaviour
{
    [SerializeField]
    private CharacterControllerScript CCS;

    public float _dashSpeed;
    public float _DashTime;


    // Start is called before the first frame update
    void Start()
    {
        CCS = GetComponent<CharacterControllerScript>();

    }

    // Update is called once per frame
    public void MovementInput(InputAction.CallbackContext context)
    {
        StartCoroutine(Dash());
    }
    IEnumerator Dash()
    {
        float startTime = Time.time;

        while(Time.time < startTime + _DashTime)
        {
            CCS._cc.Move(transform.forward * _dashSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
