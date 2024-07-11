using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draw : MonoBehaviour, IPointerDownHandler,  IDragHandler, IPointerUpHandler
{
    [SerializeField]
    UnityEngine.UI.Image dummy;

    Vector3 _initPoint = Vector3.zero;
    [SerializeField]
    Sprite _originSprite;
    Mercenary _employee;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("돈잇는지 검사");

        _employee = MercenaryPool.Instance.Get(ref _initPoint);
        dummy.sprite = _employee._mercenaryData.Sprite;
        curPoint = Vector3.zero;
    }





    LayerMask _ground=1<<(int)Common.eLayer.Ground;

    LayerMask _obstacle = 1 << (int)Common.eLayer.Obstacle | 1 << (int)Common.eLayer.EnemyPath |1 << (int)Common.eLayer.Mercenary;

    float maxDistance = 10000f;

    Collider[] _obstacleCol= new Collider[1];

    Vector3 curPoint;

    RaycastHit hit;

    bool CanHold()
    {
        curPoint = hit.point;
        curPoint.y = 0;
        curPoint.z -= 0.2f;
        int obstacleCount = Physics.OverlapSphereNonAlloc(hit.point, Common.MERCENARY_SIZE, _obstacleCol, _obstacle);
        int obstacleCount2 = Physics.OverlapSphereNonAlloc(curPoint, Common.MERCENARY_SIZE * 2.5f, _obstacleCol, _obstacle);
        return obstacleCount < 1 && obstacleCount2 < 1;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;

        Ray ray = Camera.main.ScreenPointToRay(eventData.position);
        if (Physics.Raycast(ray, out hit, maxDistance, _ground))
        {
           
            if (CanHold())
            {
                dummy.color = Color.green;
                curPoint = hit.point;
   
            }
            else
            {
                dummy.color = Color.red;
                curPoint = Vector3.zero;
            }
        }
        else
        {
            curPoint = Vector3.zero;
            dummy.color = Color.red;
        }
    }


    public void OnPointerUp(PointerEventData eventData)
    {

        dummy.sprite = _originSprite;
        transform.localPosition = Vector3.zero;
        dummy.color = new Color(1, 1, 1, 0);


        bool isPass = curPoint != Vector3.zero;
        while (!isPass)
        {
            Vector3 randomPos = new Vector3(Random.Range(0, Field.Instance._Wide) + 0.5f, 10f, Random.Range(90, 90 + Field.Instance._height) + 0.5f);
            if (Physics.Raycast(randomPos, Vector3.down, out hit, maxDistance, _ground))
            {
                if (CanHold())
                {
                    isPass = true;
                    curPoint = hit.point;
                }
            }
        }
        curPoint.y = 1.5f;
        _employee.transform.position = curPoint;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(curPoint, Common.MERCENARY_SIZE);
    }

}

