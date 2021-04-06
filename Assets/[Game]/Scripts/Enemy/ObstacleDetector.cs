using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ObstacleDetector: MonoBehaviour
{
    private GameObject[] targetList;
    private RaycastHit hit;
    private Ray ray;

    //private List<float> targetPositionList;

    private void Start()
    {
        targetList = GameObject.FindGameObjectsWithTag("Obstacle");
        /*foreach (GameObject item in targetList)
        {
            targetPositionList.Add(item.transform.position.z);
        }*/
    }
 
    void FixedUpdate()
    {
        

        for(int a = 0 ; a < targetList.Length ; a++)
        {
            if(transform.position.z <= targetList[a].transform.position.z && Vector3.Distance(transform.position , targetList[a].transform.position) < 15f) 
            {
                ray = new Ray (transform.position, targetList[a].transform.position);

                if(Physics.Raycast(ray, out hit))
                {
                   
                }

                Debug.DrawRay (targetList[a].transform.position, (transform.position - targetList[a].transform.position), Color.yellow);
            }
            
        }

        //minIndex= targetPositionList.IndexOf(targetPositionList.Min());

        
    }
    


}
