using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ObstacleDetector: Singleton<ObstacleDetector>
{
    [SerializeField] protected Ball ballPrefab;			// Ball prefab to spawn ball to throw
    private GameObject[] targetList;

    public GameObject[] TargetList
    {
        get
        {
            return targetList;
        }
    }

    public Transform thrower;

    private bool canThrow = false;

    private bool isWait = false;

    private int randomTime;

    private Ball _ball;					// Ball to throw
    private void OnEnable()
    {
        EventManager.OnEnemyThrowBall.AddListener(() => this.Wait(randomTime , () => canThrow = true));
        EventManager.OnEnemyWait.AddListener(() => isWait = true);
        EventManager.OnObstacleOpen.AddListener(() => isWait = false);
        
    }

    private void OnDisable()
    {
        EventManager.OnEnemyThrowBall.RemoveListener(() => this.Wait(randomTime , () => canThrow = true));
        EventManager.OnEnemyWait.RemoveListener(() => isWait = true);
        EventManager.OnObstacleOpen.RemoveListener(() => isWait = false);
    }
    private void Start()
    {
        targetList = GameObject.FindGameObjectsWithTag("Obstacle");
        Spawn();
        RandomTime();
    }

    private void FixedUpdate()
    {
        if(canThrow)
        {
           for(int a = 0 ; a < targetList.Length ; a++)
            {
                if(transform.position.z <= targetList[a].transform.position.z && Vector3.Distance(transform.position , targetList[a].transform.position) < 5f) 
                {
                    if((targetList[a].transform.position.x - transform.position.x < 1.5f && targetList[a].transform.parent.parent.GetComponent<Target>().targetSituation == Target.TargetSituation.close && targetList[a].transform.parent.parent.tag != "DoubleDoor")
                    || ((targetList[a].transform.position.x - transform.position.x < 1.5f && targetList[a].transform.parent.parent.GetComponent<Target>().targetSituation == Target.TargetSituation.open && targetList[a].transform.parent.parent.tag == "DoubleDoor")) 
                    || (targetList[a].transform.position.x - transform.position.x >= 1.5f && targetList[a].transform.parent.parent.GetComponent<Target>().targetSituation == Target.TargetSituation.open)
                    )
                    { // eger kendi hedefiyse, hedef kapalıysa ve hedef double door değilse vur.
                    //eger kendi hedefiyse, hedef açıksa ve hedef double door ise vur.
                        // ya da playerın hedefiyse ve onun hedefi açıksa vur.
                        ThrowBall(a);
                        
                    }
                    Debug.DrawRay (targetList[a].transform.position, (transform.position - targetList[a].transform.position), Color.yellow);
                }
                
            }
        }
    }
    
    private void RandomTime()
    {
        randomTime = Random.Range(1,3);
        EventManager.OnEnemyThrowBall.Invoke();
    }
    public void Spawn() {
		_ball = Instantiate(ballPrefab, thrower.position, Quaternion.identity);
        _ball.transform.SetParent(transform.parent);
	}

    private void ThrowBall(int a)
    {
        Vector3 direction = new Vector3(targetList[a].transform.position.x +1f,targetList[a].transform.position.y + 1.5f,targetList[a].transform.position.z);
        _ball.Push(direction);
        RandomTime();
        canThrow = false;
        Invoke("Spawn", 1);
    }

}
