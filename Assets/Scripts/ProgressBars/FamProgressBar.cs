using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FamProgressBar : MonoBehaviour {
    private int minimum;
    private int maximum;
    public static int current;
    public Image mask;
    public Image fill;
    public Color fillColor;
    private Color currColor;
    // Start is called before the first frame update
    void Start() {
        minimum = -100;
        maximum = 100;
        current = (2 * FamilyBarUI.current) - 100;
    }

    // Update is called once per frame
    void Update() {
        GetCurrentFill();
    }

    void GetCurrentFill() {
        // ensures that current stays in the bounds of minimum and maximum
        if( current < minimum ) current = minimum;
        else if( current > maximum ) current = maximum;
        // normalizes current value based on range from minimum to maximum
        float currOffset = current - minimum;
        float maxOffset = maximum - minimum;
        float fillAmt =  currOffset / maxOffset;
        // fills mask with specified amount
        mask.fillAmount = fillAmt;

        // calculates fill color and applies to fill
        fillColor = GetCurrentColor(fillAmt);
        fill.color = fillColor;
    }

    Color GetCurrentColor(float fillAmt) {
        // if greater than or equal to 0.5, fill will change from yellow to green
        // else it will change from red to yellow
        if( fillAmt >= 0.5 ){
            currColor.r = (float) (-2 * fillAmt) + 2;
            currColor.g = 1;
            currColor.b = 0;
            currColor.a = 1;
        } else {
            currColor.r = 1;
            currColor.g = (float) 2 * fillAmt;
            currColor.b = 0;
            currColor.a = 1;
        }

        return currColor;
    }

    public static void ChangeFill(int amt){
        current += amt;
    }
}
