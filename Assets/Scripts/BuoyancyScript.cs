using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BuoyancyScript : MonoBehaviour
{
    public float underWaterDrag = 3f;
    public float underWaterAngularDrag = 1f;
    public float airDrag = 0f;
    public float airAngularDrag = 0.05f;
    public float floatingPower = 15f;
    public float waterHeight = 0f;

    Rigidbody m_Rigibody;

    bool underWater;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigibody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float difference = transform.position.y - waterHeight;
        //Debug.Log(difference);

        if (difference < 0)
        {
            m_Rigibody.AddForceAtPosition(Vector3.up * floatingPower * Mathf.Abs(difference), transform.position, ForceMode.Force);

            if (!underWater)
            {
                underWater = true;
                SwitchState(true);
            }
        }
        else if (underWater)
        {
            underWater = false;
            SwitchState(false);
        }
    }

    void SwitchState(bool isUnderWater)
    {
        if (isUnderWater)
        {
            m_Rigibody.drag = underWaterDrag;
            m_Rigibody.angularDrag = underWaterAngularDrag;
        }
        else
        {
            m_Rigibody.drag = airDrag;
            m_Rigibody.angularDrag = airAngularDrag;
        }
    }
}
