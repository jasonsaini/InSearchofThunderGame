using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WASD : MonoBehaviour
{
    //public GameObject next;
    //public GameObject parent;
    public Image W;
    public Image A;
    public Image S;
    public Image D;
    public Sprite wPressed;
    public Sprite aPressed;
    public Sprite sPressed;
    public Sprite dPressed;
    public Sprite wUp;
    public Sprite aUp;
    public Sprite sUp;
    public Sprite dUp;
    private uint w = 0;
    private uint a = 0;
    private uint s = 0;
    private uint d = 0;
    private Color tempColor;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w")){
            W.sprite = wPressed;
            //if (w < 50) {
            //    w++;
            //    W.color = Color.HSVToRGB(.347f, w / 100f, 1);
            //}
            //else{
            //    tempColor = W.color;
            //    tempColor.a = .5f;
            //    W.color = tempColor;
            //}
        }
        else
            W.sprite = wUp;

        if (Input.GetKey("a")){
            A.sprite = aPressed;
            //if (a < 50) {
            //    a++;
            //    A.color = Color.HSVToRGB(.347f, a / 100f, 1);
            //}
            //else {
            //    tempColor = A.color;
            //    tempColor.a = .5f;
            //    A.color = tempColor;
            //}
        }
        else
            A.sprite = aUp;

        if (Input.GetKey("s")){
            S.sprite = sPressed;
            //if (s < 50) {
            //    s++;
            //    S.color = Color.HSVToRGB(.347f, s / 100f, 1);
            //}
            //else {
            //    tempColor = S.color;
            //    tempColor.a = .5f;
            //    S.color = tempColor;
            //}
        }
        else
            S.sprite = sUp;

        if (Input.GetKey("d")){
            D.sprite = dPressed;
            //if (d < 50){
            //    d++;
            //    D.color = Color.HSVToRGB(.347f, d / 100f, 1);
            //}
            //else{
            //    tempColor = D.color;
            //    tempColor.a = .5f;
            //    D.color = tempColor;
            //}
        }
        else
            D.sprite = dUp;

        //if (w + a + s + d >= 200){
        //    parent.SetActive(false);
        //    next.SetActive(true);
        //}
    }
}
