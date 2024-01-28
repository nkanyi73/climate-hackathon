using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Unity.AI;
using UnityEngine.AI;

public class TrashCollect : MonoBehaviour
{
    [Header("Script Objects")]
    public SceneController controller;
    public TrashNavDestinations trashNavDestinations;

    [Header("Trash Elements")]
    public GameObject trashGameObject;
    public GameObject netAttachPoint;
    public Animator thisAnimator;
    public Collider trashColliderObject;
    public string animationName;
    public NavMeshAgent agent;

    [Header("Basket Elements")]
    public GameObject basketGameObject;
    public GameObject[] basket1AttachPoints;
    public GameObject[] basket2AttachPoints;
    private bool inBasket;




    // Start is called before the first frame update
    void Start()
    {
        trashGameObject = this.GameObject();
        thisAnimator = GetComponentInChildren<Animator>();
        netAttachPoint = GameObject.FindGameObjectWithTag("Net Attach");
        basketGameObject = GameObject.FindGameObjectWithTag("Basket");
        basket1AttachPoints = GameObject.FindGameObjectsWithTag("Basket 1 Touch Point");
        basket2AttachPoints = GameObject.FindGameObjectsWithTag("Basket 2 Touch Point");
        agent = GetComponent<NavMeshAgent>();
        trashNavDestinations = GetComponent<TrashNavDestinations>();
        trashColliderObject = GetComponent<Collider>();
        controller = GameObject.FindGameObjectWithTag("Scene Controller").GetComponent<SceneController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Net")
        {
            inBasket = true;
            if(netAttachPoint == null)
            {
                netAttachPoint = GameObject.FindGameObjectWithTag("Net Attach");
            }
            if (!controller.netOccupied)
            {
                if(agent != null)
                {
                    trashNavDestinations.enabled = false;
                    agent.enabled = false;
                }

                thisAnimator.enabled = false;
                trashGameObject.transform.SetParent(netAttachPoint.transform);
                trashGameObject.transform.position = netAttachPoint.transform.position;
                controller.netOccupied = true;
                Debug.Log(this + " has been picked up in net");
            }
            else
            {
                Debug.LogWarning("Net Occupied!");
            }

        }

        if (other.tag == "Basket")
        {
            if(other.name == "Basket1Collider")
            {
                for (int i = 0; i < basket1AttachPoints.Length; i++)
                {
                    trashGameObject.transform.SetParent(basket1AttachPoints[controller.collectionCounterBasket1].transform);
                    trashGameObject.transform.position = basket1AttachPoints[controller.collectionCounterBasket1].transform.position;
                    trashColliderObject.enabled = false;
                    

                }
                controller.collectionCounterBasket1++;
            }
            if(other.name == "Basket2Collider")
            {
                for (int i = 0; i < basket2AttachPoints.Length; i++)
                {
                    trashGameObject.transform.SetParent(basket2AttachPoints[controller.collectionCounterBasket2].transform);
                    trashGameObject.transform.position = basket2AttachPoints[controller.collectionCounterBasket2].transform.position;
                    trashColliderObject.enabled = false;
                    

                }
                controller.collectionCounterBasket2++;
            }
            
            controller.netOccupied = false;
            Debug.Log(this + " has been collected in basket");



        }
    }
}
