using UnityEngine;
using System.Collections;

public class ComputeBitmap {
	private Texture2D ResultTexture;
	public Texture2D BitmapsAddMix(Texture2D MainTexture, Texture2D SpriteTexture,Color CustomSpriteColor,float RayX,float RayY){
		var MainWidth = MainTexture.width;
		var MainHeight = MainTexture.height;
		var CenterSpriteX = Mathf.FloorToInt(MainWidth*RayX);
		var CenterSpriteY = Mathf.FloorToInt(MainHeight*RayY);
		var SpriteWidth = SpriteTexture.width;
		var SpriteHeight = SpriteTexture.height;
		var MainColor = MainTexture.GetPixels ();
		var SpriteColor = SpriteTexture.GetPixels ();
		var ResultColor = MainTexture.GetPixels ();
		var FirstPointX = CenterSpriteX - SpriteWidth / 2;
		var FirstPointY = CenterSpriteY - SpriteHeight / 2;

		//var i = 0;
		//var j = 0;
		var PointX = 0;
		var PointY = 0;
		var j = FirstPointY < 0 ? Mathf.Abs (FirstPointY) : 0;
		while (j<SpriteHeight) {
			var i=FirstPointX<0?Mathf.Abs (FirstPointX):0;
			PointY=j+FirstPointY;
			if(PointY<MainHeight){
				while (i<SpriteWidth){
					PointX=i+FirstPointX;
					if(PointX<MainWidth){
						var MainColInd=PointY*MainWidth+PointX;
						var SpriteColInd=j*SpriteWidth+i;

                        //白 0.0f から 1.0f
                        if (SpriteColor[SpriteColInd].r >= 1 && SpriteColor[SpriteColInd].g >= 1 && SpriteColor[SpriteColInd].b >=1)
                        {
                            SpriteColor[SpriteColInd].r = CustomSpriteColor.r;
                            SpriteColor[SpriteColInd].g = CustomSpriteColor.g;
                            SpriteColor[SpriteColInd].b = CustomSpriteColor.b;

                            ResultColor[MainColInd].r = SpriteColor[SpriteColInd].r;
                            ResultColor[MainColInd].g = SpriteColor[SpriteColInd].g;
                            ResultColor[MainColInd].b = SpriteColor[SpriteColInd].b;
                        }
						
					}
					else{
						i=SpriteWidth;
					}
						i++;
				}
			}
			else{
				j=SpriteHeight;
			}
			j++;
		}
		if (ResultTexture == null) {
						ResultTexture = new Texture2D (MainWidth, MainHeight);
				}
		ResultTexture.SetPixels (ResultColor);
		ResultTexture.Apply ();
		return ResultTexture;
	}

}
