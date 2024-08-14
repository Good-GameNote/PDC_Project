using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongsFor3D : Singleton<TongsFor3D>
{
    bool isDragging = false;

    bool isFind = false;

    Ray ray;

    RaycastHit hit;

    IClickable _clicked;

    float remainCallTime;
    void Update()
    {
        HandleMouseInput();
    }
    LayerMask layerMask = 1 << (int)Common.eLayer.Tile | 1 << (int)Common.eLayer.Enemy ;
    void HandleMouseInput()
    {

        if (Input.GetMouseButton(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            isFind =Physics.Raycast(ray, out hit,10000, layerMask);
        }

        // 마우스 버튼 클릭 감지
        if (Input.GetMouseButtonDown(0))
        {
            if (!isFind) return;
            hit.transform.TryGetComponent(out _clicked);
            if (_clicked != null)
            {

                isDragging = true;
                _clicked.OnBeginDrag(hit.point);
            } 
        }

        if (Input.GetMouseButtonUp(0) && !isFind)
        {
            UI_MercenaryAction.Instance.gameObject.SetActive(false);
        }
        if (!isDragging) return;


        // 마우스 버튼을 누른 상태에서 이동할 때
        if (Input.GetMouseButton(0))
        {
            remainCallTime -= Time.deltaTime;
            if (remainCallTime > 0) { return; }
            remainCallTime = 0.08f;
            _clicked.OnDrag(hit.point);
        }

        // 마우스 버튼을 놓았을 때 드래그 종료
        if (Input.GetMouseButtonUp(0))
        {

            isDragging = false;

            _clicked.OnEndDrag(hit.point);
            _clicked = null;

        }

    }


}
