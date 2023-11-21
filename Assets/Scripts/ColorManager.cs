using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class ColorManager : MonoBehaviour
{

    public string CellColor;


    // Start is called before the first frame update
    void Start()
    {
        Color color = FromHex(CellColor);

        this.GetComponent<Renderer>().material.SetColor("_Color", color);
    }

    public static Color FromHex(string hex)
    {
        if (hex.Length < 6)
        {
            throw new System.FormatException("Needs a string with a length of at least 6");
        }

        var r = hex.Substring(0, 2);
        var g = hex.Substring(2, 2);
        var b = hex.Substring(4, 2);
        string alpha;
        if (hex.Length >= 8)
            alpha = hex.Substring(6, 2);
        else
            alpha = "FF";

        return new Color((int.Parse(r, NumberStyles.HexNumber) / 255f),
                        (int.Parse(g, NumberStyles.HexNumber) / 255f),
                        (int.Parse(b, NumberStyles.HexNumber) / 255f),
                        (int.Parse(alpha, NumberStyles.HexNumber) / 255f));
    }
}
