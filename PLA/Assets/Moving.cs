using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float IsaacNewton;
    public float Spiiiiid = 3.5f;
    public CharacterController MasterOfPuppet;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 Velocity = direction * Spiiiiid;

        Velocity = transform.transform.TransformDirection(Velocity);
        Velocity.y -= IsaacNewton;
        MasterOfPuppet.Move(Velocity * Time.deltaTime);
    }
}
