using UnityEngine;
using System.Collections;

public class ProcessBitmap {
	public Texture2D MainText;
	public Texture2D SecondText;
	public int Xmap;
	public int Ymap;
	private int centerMainTexX;
	private int centerMainTexY;
	private int mainHeight;
	private int mainWidth;
	private Color[] mainColor;
	private Color[] secondColor;
	private Texture2D MixTexture;
	private Texture2D ResultTexture;
	private class DataBitmap
	{
		public int CenterMainTexX;
		public int CenterMainTexY;
		
		public DataBitmap(Texture2D mainTex,Texture2D secondTex,int xMap,int yMap)
		{
			CenterMainTexX=mainTex.width/2;
			CenterMainTexY=mainTex.height/2;
		}
		
	}
	//private int mainWidth{ get; set; }
	
	public ProcessBitmap()
	{
	}
	public ProcessBitmap(Texture2D MainText, Texture2D SecondText,int Xmap,int Ymap){
		this.MainText = MainText;
		this.SecondText = SecondText;
		this.Xmap = Xmap;
		this.Ymap = Ymap;
		this.centerMainTexX = Xmap;
		this.centerMainTexY = Ymap;
		this.mainHeight = MainText.height;
		this.mainWidth = MainText.width;
		this.mainColor = MainText.GetPixels ();
		this.secondColor = SecondText.GetPixels ();
		
	}

	public Texture2D MixeSpritePlus(Texture2D MainTexture,Texture2D SpriteTexture,float MouseX,float MouseY){

		var MainWidth = MainTexture.width;
		var MainHeight = MainTexture.height;
		var SpriteCenterX = Mathf.FloorToInt (MouseX*MainWidth);
		var SpriteCenterY = Mathf.FloorToInt (MouseY*MainHeight);

		var SpriteWidth = SpriteTexture.width;
		var SpriteHeight = SpriteTexture.height;
		var FirstPointX = SpriteCenterX - SpriteWidth / 2;
		var FirstPointY = SpriteCenterY- SpriteHeight / 2;

		var j=FirstPointY<0?Mathf.Abs (FirstPointY):0;
		var MainColor = MainTexture.GetPixels ();
		var SpriteColor = SpriteTexture.GetPixels ();
		var ResultColor = MainTexture.GetPixels ();

		while (j<SpriteHeight) {
			var i=FirstPointX<0?Mathf.Abs (FirstPointX):0;
			var PointY=FirstPointY+j;
			if(PointY<MainHeight){
				while(i<SpriteWidth){
					var PointX=FirstPointX+i;
					if(PointX<MainWidth){
					var SpriteInd=j*SpriteWidth+i;
					var MainInd=PointY*MainWidth+PointX;
					ResultColor[MainInd].r = MainColor[MainInd].r+SpriteColor[SpriteInd].r ;
					ResultColor[MainInd].g = MainColor[MainInd].g+SpriteColor[SpriteInd].g ;
					ResultColor[MainInd].b = MainColor[MainInd].b+SpriteColor[SpriteInd].b ;
					}
					else{i=SpriteWidth;}
					i++;
			}
			}
			else{j=SpriteHeight;}
			j++;
				}
		if (ResultTexture == null) {
						ResultTexture = new Texture2D (MainWidth, MainHeight);
				}
		ResultTexture.SetPixels (ResultColor);
		ResultTexture.Apply ();
		return ResultTexture;
		}
	public Texture2D MixeSpriteAdd(Texture2D MainTexture,Texture2D SpriteTexture,float MapRayX,float MapRayY )
	{
	   // MapRay(X,Y) is a percentage position(vary from 0 to 1) from a RayCast output value
		// By multiplying the MapRayX by the width of the MainTexture we obtain the float version of the
		// SpriteCenter X coordinate that it need to be converted to an Int, and the same for Y coordinate.  
		var MainWidth = MainTexture.width;// We determine our MainTexture width
		var MainHeight = MainTexture.height;// We determine our MainTexture height
		var SpriteCenterX =Mathf.FloorToInt (MapRayX*MainWidth); // We determine the X SpriteCenter
		var SpriteCenterY =Mathf.FloorToInt (MapRayY*MainHeight);// We determine the X SpriteCenter
		var FirstPointX = SpriteCenterX - SpriteTexture.width / 2; // We determine the first point(x,y) of... 
		var FirstPointY = SpriteCenterY - SpriteTexture.height / 2;// ...our sprite, it's the point on lower left corner
		var MainColor = MainTexture.GetPixels (); // We collect the MainTexture color pixels in a Color array
		var ResultColor = MainTexture.GetPixels ();// We collect the MainTexture color pixels in a Color array...
		var SpriteColor = SpriteTexture.GetPixels ();
		// ...Called ResultColor that will be used for the color pixels mixing
		var j = FirstPointY < 0 ? Mathf.Abs (FirstPointY) : 0;//if the Y of our first point is < 0 then j=positive value...
		// ...of  the first point Y
		while (j<SpriteTexture.height) {
			var i = FirstPointX<0? Mathf.Abs (FirstPointX):0;//if the X of our first point is < 0 then i=positive value...
			// ...of  the first point X
						var PointY=FirstPointY+j;//We determine the coordinate Y of our color pixel in the MainTexture
			if(PointY>=MainHeight){
				j=SpriteTexture.height; // We end the j loop, when the Color pixel Y coordinate  reachs the... 
				i=SpriteTexture.width; // ...MainTexture haight value and also We end the i loop
			}
			else{
					while (i<SpriteTexture.width) {
					var PointX=FirstPointX+i;//We determine the coordinate X of our color pixel in the MainTexture
							if(PointX<MainTexture.width){
									var MainInd=PointY*MainTexture.width+PointX;//We convert the X and Y coordinates of ...
						//...the Color pixel located on the MainTexture in to Index array
									var SpriteInd=j*SpriteTexture.width+i;//We convert the locale X and Y coordinates of ...
						//... the Color pixel located on the SpriteTexture in to Index array
									var ColorMixR=MainColor[MainInd].r+SpriteColor[SpriteInd].r;
									var ColorMixG=MainColor[MainInd].g+SpriteColor[SpriteInd].g;
									var ColorMixB=MainColor[MainInd].b+SpriteColor[SpriteInd].b;
									ResultColor[MainInd]=new Color(ColorMixR,ColorMixG,ColorMixB);
						}
					else{i=SpriteTexture.width;}// We end the i loop if PointX>=MainTexture.width
						i++;
						}
				}
				j++;
				}
		if (MixTexture == null) {
				MixTexture = new Texture2D (MainWidth, MainHeight);
				}
		MixTexture.SetPixels (ResultColor);
		MixTexture.Apply ();
		return MixTexture;
		}


}
