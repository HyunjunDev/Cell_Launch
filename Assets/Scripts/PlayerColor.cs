using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerColor : MonoBehaviour
{
    private TrailRenderer tr;
    public List<Material> Mats = new List<Material>();
    public Material material;
    public Renderer bulletColor;
    public Renderer effectColor;
    private Player player;
    public int random = 0;
    public void Awake()
    {
        tr = GetComponent<TrailRenderer>();
        player = GetComponent<Player>();
        tr.material = new Material(material);
        bulletColor = player.bullet.GetComponent<Renderer>();
        effectColor = player.deadEffect.GetComponent<Renderer>();
        UnityEngine.Color32 blue = new UnityEngine.Color32(142, 139, 240, 255);
        UnityEngine.Color32 green = new UnityEngine.Color32(124, 222, 164, 255);
        UnityEngine.Color32 yellow = new UnityEngine.Color32(255, 233, 125, 255);
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        random = Random.Range(0, Mats.Count);
        if(random==0)
        {
            gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(blue, 0.5f), new GradientColorKey(UnityEngine.Color.white, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(0, 1.0f) }
        );
        }
        else if (random == 1)
        {
            gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(green, 0.5f), new GradientColorKey(UnityEngine.Color.white, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(0, 1.0f) }
        );
        }
        else if (random == 2)
        {
            gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(yellow, 0.5f), new GradientColorKey(UnityEngine.Color.white, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(0, 1.0f) }
        );
        }
        tr.colorGradient = gradient;
        GetComponent<Renderer>().material = Mats[random];
        bulletColor.material = Mats[random];
        effectColor.material = Mats[random];
    }
}
