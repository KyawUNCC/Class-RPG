using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] Sprite off;
    [SerializeField] Sprite hover;
    [SerializeField] Sprite clicked;

    Vector3 offPos;
    Vector3 hoverPos;
    Vector3 clickedPos;

    GameObject sprite;
    private void Start()
    {
        sprite = transform.GetChild(0).gameObject;

        offPos = new Vector3(sprite.transform.position.x, sprite.transform.position.y, -1);
        hoverPos = new Vector3(sprite.transform.position.x, sprite.transform.position.y - .1f, -1);
        clickedPos = new Vector3(sprite.transform.position.x, sprite.transform.position.y - .2f, -1);
    }
    private void OnMouseEnter()
    {
        Hover();
    }
    private void OnMouseDown()
    {
        Clicked();
    }
    private void OnMouseExit()
    {
        Off();
    }
    private void OnMouseUpAsButton()
    {
        Off();
    }

    public void Off()
    {
        GetComponent<SpriteRenderer>().sprite = off;
        sprite.transform.position = offPos;
    }
    public void Hover()
    {
        GetComponent<SpriteRenderer>().sprite = hover;
        sprite.transform.position = hoverPos;
    }
    public void Clicked()
    {
        GetComponent<SpriteRenderer>().sprite = clicked;
        sprite.transform.position = clickedPos;
    }
}
