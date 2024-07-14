using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tongs : Singleton<Tongs>, IPointerDownHandler,  IDragHandler, IPointerUpHandler
{
    [SerializeField]
    UnityEngine.UI.Image _dummy;
    [SerializeField]
    UnityEngine.UI.Image _range;

    Vector3 _initPoint = Vector3.zero;
    [SerializeField]
    Sprite _originSprite;
    Mercenary _employee;
    // Start is called before the first frame update
    void Start()
    {
    }
    bool _isMove;
    public void OnPointerDown(PointerEventData eventData)
    {
        if(!_isMove)
        {
            Debug.Log("돈잇는지 검사");

            _employee = MercenaryPool.Instance.Get(ref _initPoint);

        }
        else
        {

            transform.position = eventData.position;
        }

        _dummy.sprite = _employee._mercenaryData.Sprite;
        _range.transform.localScale = Vector3.one * _employee._mercenaryData.Range;

        SetState(false);
    }
    public void OnEmployeeSet(Mercenary emplyeee)
    {

        _employee = emplyeee;
        _isMove = true;
    }

    LayerMask _ground=1<<(int)Common.eLayer.Ground;

    LayerMask _obstacle = 1 << (int)Common.eLayer.Obstacle | 1 << (int)Common.eLayer.EnemyPath |1 << (int)Common.eLayer.Mercenary;

    float maxDistance = 10000f;

    Collider[] _obstacleCol= new Collider[1];

    Vector3 curPoint;

    RaycastHit hit;

    Color _red = new Color(1,0,0,0.5f);
    Color _green = new Color(0, 1, 0, 0.5f);



    bool _canHold;

    void SetState(bool canHold)
    {
        _canHold = canHold;
        if (_canHold)
        {
            _dummy.color = _green;
            _range.color = _green;

            curPoint = hit.point;
        }
        else
        {
            _dummy.color = _red;
            _range.color = _red;
        }
    }
    bool CheckCanHold()
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
        bool result = false;
        if (Physics.Raycast(ray, out hit, maxDistance, _ground))
        {
            result =CheckCanHold();
        }
        SetState(result);
    }


    public void OnPointerUp(PointerEventData eventData)
    {

        while (!_canHold)
        {
            Vector3 randomPos = new Vector3(Random.Range(0, Field.Instance._Wide) + 0.5f, 10f, Random.Range(90, 90 + Field.Instance._height) + 0.5f);
            if (Physics.Raycast(randomPos, Vector3.down, out hit, maxDistance, _ground))
            {
                SetState( CheckCanHold());                
            }
        }
        curPoint.y = 1.3f;
        _employee.transform.position = curPoint;

        _dummy.sprite = _originSprite;
        transform.localPosition = Vector3.zero;
        _range.transform.localScale = Vector3.zero;
        _dummy.color = new Color(1, 1, 1, 0);
        _isMove = false;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(curPoint, Common.MERCENARY_SIZE);
    }

}

