Shader "Custom/NewSurfaceShader"
{
   Properties {

        _Color ("Main Color", Color) = (1,1,1,0.5)

        _MainTex ("Base (RGB)", 2D) = "white" { }

        _SubTex ("2nd Texture",2D) = "white"{ }

    }



    SubShader {

        Pass {

		 Blend SrcAlpha OneMinusSrcAlpha 

            Material {

                Diffuse [_Color]

                Ambient [_Color]

            }

            Lighting On

            SetTexture [_MainTex] {

               // Combine texture * primary DOUBLE

                Combine texture * primary DOUBLE

            }

             SetTexture [_SubTex] {
				ConstantColor[_Color] 
                Combine texture lerp(texture) previous, constant 

            }

        }

    }

}