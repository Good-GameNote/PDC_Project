
using TWC.Actions;
using UnityEngine;

public interface IClickable
{
    void OnBeginDrag(Vector3 point);

    void OnDrag(Vector3 point);

    void OnEndDrag(Vector3 point);

}
