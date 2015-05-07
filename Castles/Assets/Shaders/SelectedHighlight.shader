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
// Upgrade NOTE: excluded shader from DX11 and Xbox360; has structs without semantics (struct appdata members vertex,normal)
#pragma exclude_renderers d3d11 xbox360
			#pragma vertex vert 
			#pragma vertex vert
			#include "UnityCG.cginc"

			struct appdata { 
				float4 vertex; 
				float3 normal; 
			}; 
	  
			struct v2f { 
				float4 pos : POSITION; 
				float4 color : COLOR; 
			}; 
			uniform float _Outline; 
			uniform float4 _OutlineColor; 
	  
			v2f vert(appdata v) {
				// just make a copy of incoming vertex data but scaled according to normal direction
				v2f o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
			 
				float3 norm   = mul ((float3x3)UNITY_MATRIX_IT_MV, v.normal);
				float2 offset = TransformViewToProjection(norm.xy);
			 
				o.pos.xy += offset * o.pos.z * _Outline;
				o.color = _OutlineColor;
				return o;
			}
	  
			ENDCG 
//	  
//			Cull Front
//			ZWrite On
//			ColorMask RGBA
//			Blend SrcAlpha OneMinusSrcAlpha
//			SetTexture [_MainTex] { combine primary } 
		} 
    } 
  
    Fallback "Diffuse" 
 }
