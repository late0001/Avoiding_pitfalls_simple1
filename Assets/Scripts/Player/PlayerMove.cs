using System.Collections;
using System.Collections.Generic;
//using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    private NavMeshAgent playerAgent;
    // Start is called before the first frame update
    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && EventSystem.current.IsPointerOverGameObject() == false )
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool isCollide = Physics.Raycast(ray, out hit);
            if (isCollide)
            {
                if (hit.collider.tag == Tags.GROUND) 
                {
                    playerAgent.SetDestination(hit.point);
                    playerAgent.stoppingDistance = 0;
                }
                else if (hit.collider.tag == Tags.INTERACTABLE) 
                {
                    hit.collider.GetComponent<InteractableObject>().OnClick(playerAgent);
                }
                
            }
        }
    }
}
