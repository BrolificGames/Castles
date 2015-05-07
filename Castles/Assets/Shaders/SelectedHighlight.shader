Shader "SelectedHighlight" {
	Properties {
		_OutlineColor ("Outline Color", Color) = (0,1,0,1) 
		_Outline ("Outline width", Range (0.002, 0.03)) = 0.01 
	}
	SubShader 
    { 
       Tags {"Queue"="Transparent" "RenderType"="Transparent"} 
  
       Pass 
       { 
			Name "OUTLINE" 
			Tags { "LightMode" = "Always" } 
  
			Blend SrcAlpha OneMinusSrcAlpha
  
			CGPROGRAM 
			#pragma vertex vert 

				struct appdata { 
					float4 vertex; 
					float3 normal; 
				}; 
		  
				struct v2f { 
					float4 pos : POSITION; 
					float4 color : COLOR; 
					float fog : FOGC; 
				}; 
				uniform float _Outline; 
				uniform float4 _OutlineColor; 
		  
				v2f vert(appdata v) { 
					v2f o; 
					o.pos = mul(UNITY_MATRIX_MVP, v.vertex); 
					float3 norm = mul ((float3x3)UNITY_MATRIX_MV, v.normal); 
					norm.x *= UNITY_MATRIX_P[0][0]; 
					norm.y *= UNITY_MATRIX_P[1][1]; 
					o.pos.xy += norm.xy * o.pos.z * _Outline; 

					o.fog = o.pos.z; 
					o.color = _OutlineColor; 
					return o; 
				} 
	  
			ENDCG 
	  
			Cull Front
			ZWrite On
			ColorMask RGBA
			Blend SrcAlpha OneMinusSrcAlpha
			SetTexture [_MainTex] { combine primary } 
		} 
    } 
  
    Fallback "Diffuse" 
 }
