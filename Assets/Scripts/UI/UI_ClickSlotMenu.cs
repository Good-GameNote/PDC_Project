using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ClickSlotMenu : Singleton<UI_ClickSlotMenu>
{
    public ISlotExhibition _purchas { get; private set; }
    Transform _parentTrf;


    List< ISlotMenu> _slotMenus = new List< ISlotMenu >();

    public void Resist(ISlotMenu menu)
    {
        _slotMenus.Add( menu );
    }

    public void ClickThis(Transform obj , ISlotExhibition purchas)
    {
        if (obj != _parentTrf)
        {
            gameObject.SetActive(true);
        }
        else gameObject.SetActive(!gameObject.activeSelf);


        transform.SetParent(obj,false);
        _parentTrf = obj;
        _purchas = purchas;
        foreach ( ISlotMenu menu in _slotMenus )
        {
            menu.Show(_purchas);
        }
    }



}
