using UnityEngine;
using System.Collections;

public class PaintMixer : MonoBehaviour {

    public GameObject TrunkMaterialEmission;
    public Texture2D RED;
    public Texture2D BLUE;
    public Texture2D YELLOW;
    public Texture2D GREEN;
    public Texture2D PURPLE;
    public Texture2D ORANGE;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Color AddTwoColor(GameObject PaintBucket_1, GameObject PaintBucket_2)
    {

        // First Color Red
        if (PaintBucket_1.GetComponent<PaintCan>().ColorName == "RED" )
        {
            // If Single Color only [R] or [Y] or [B]
            if (PaintBucket_2 == null || PaintBucket_2.GetComponent<PaintCan>().ColorName == "RED")
            {
                TrunkMaterialEmission.gameObject.GetComponent<Material>().SetTexture("_DetailAlbedoMap", RED);
                return new Color(1.0f, 0.0f, 0.0f);
            }
            else
            {
                // Mix with Yellow
                if (PaintBucket_2.GetComponent<PaintCan>().ColorName == "YELLOW")
                {
                    TrunkMaterialEmission.gameObject.GetComponent<Material>().SetTexture("_DetailAlbedoMap", ORANGE);
                    return new Color(1.0f, 0.647f, 0.0f);// Orange R 255, G 165, B 0
                }
                // Mix with Blue
                if (PaintBucket_2.GetComponent<PaintCan>().ColorName == "BLUE")
                {
                    TrunkMaterialEmission.gameObject.GetComponent<Material>().SetTexture("_DetailAlbedoMap", PURPLE);
                    return new Color(0.50196f, 0.0f, 0.50196f); // Purple R 128, G 0, B 128
                }
            }
           
        }

        // First Color Yellow
        else if (PaintBucket_1.GetComponent<PaintCan>().ColorName == "YELLOW")
        {
            // If Single Color only [R] or [Y] or [B]
            if (PaintBucket_2 == null || PaintBucket_2.GetComponent<PaintCan>().ColorName == "YELLOW")
            {
                TrunkMaterialEmission.gameObject.GetComponent<Material>().SetTexture("_DetailAlbedoMap", YELLOW);
                return new Color(1.0f, 1.0f, 0.0f);
            }
            else
            {

                // Mix with Red
                if (PaintBucket_2.GetComponent<PaintCan>().ColorName == "RED")
                {

                    TrunkMaterialEmission.gameObject.GetComponent<Material>().SetTexture("_DetailAlbedoMap", ORANGE);
                    return new Color(1.0f, 0.647f, 0.0f);// Orange R 255, G 165, B 0
                }

                // Mix with Blue
                if (PaintBucket_2.GetComponent<PaintCan>().ColorName == "BLUE")
                {

                    TrunkMaterialEmission.gameObject.GetComponent<Material>().SetTexture("_DetailAlbedoMap", GREEN);
                    return new Color(0.0f, 0.50196f, 0.0f);// Green R 0, G 128, B 0
                }
            }

        }

        // First Color Blue
        else if (PaintBucket_1.GetComponent<PaintCan>().ColorName == "BLUE")
        {
            // If Single Color only [R] or [Y] or [B]
            if (PaintBucket_2 == null || PaintBucket_2.GetComponent<PaintCan>().ColorName == "BLUE")
            {
                TrunkMaterialEmission.gameObject.GetComponent<Material>().SetTexture("_DetailAlbedoMap", BLUE);
                return new Color(0.0f, 0.0f, 1.0f);
            }
            else
            {
                // Mix with Yellow
                if (PaintBucket_2.GetComponent<PaintCan>().ColorName == "YELLOW")
                {
                    TrunkMaterialEmission.gameObject.GetComponent<Material>().SetTexture("_DetailAlbedoMap", GREEN);
                    return new Color(0.0f, 0.50196f, 0.0f);// Green R 0, G 128, B 0
                }
                // Mix with Red
                if (PaintBucket_2.GetComponent<PaintCan>().ColorName == "RED")
                {
                    TrunkMaterialEmission.gameObject.GetComponent<Material>().SetTexture("_DetailAlbedoMap", PURPLE);
                    return new Color(0.50196f, 0.0f, 0.50196f); // Purple R 128, G 0, B 128
                }
            }
          
        }

        
        return Color.black;
    }

}
