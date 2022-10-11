// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "S_ParticleAdd"
{
	Properties
	{
		[Enum(UnityEngine.Rendering.BlendMode)]_Add_Blend("Add_Blend", Float) = 1
		[HDR]_Tint_01("Tint_01", Color) = (1,1,1,0)
		[HDR]_Tint_02("Tint_02", Color) = (1,1,1,0)
		_MainTex("MainTex", 2D) = "white" {}
		_SpeedDirMainTex("Speed Dir MainTex", Vector) = (0,0,0,0)
		_NoiseMainTex("Noise MainTex", 2D) = "white" {}
		_NoiseStrengthMainTex("Noise Strength MainTex", Float) = 0
		_SpeedDirNoiseMainTex("Speed Dir Noise MainTex", Vector) = (0,0,0,0)
		_AlphaMask("Alpha Mask", 2D) = "white" {}
		_SpeedDirAlphaMask("Speed Dir Alpha Mask", Vector) = (0,0,0,0)
		_NoiseAlphaMask("Noise Alpha Mask", 2D) = "white" {}
		_NoiseAlphaMaskStrength("Noise Alpha Mask Strength", Float) = 0
		_SpeedDirNoiseAlphaMask("Speed Dir Noise Alpha Mask", Vector) = (0,0,0,0)
		_SubAlphaMask("Sub Alpha Mask", 2D) = "white" {}
		_SpeedDirSubAlphaMask("Speed Dir Sub Alpha Mask", Vector) = (0,0,0,0)
		[Enum(UnityEngine.Rendering.CullMode)]_CullMode("CullMode", Float) = 0
		[HideInInspector] _texcoord2( "", 2D ) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Off
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha
		
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 4.6
		#pragma surface surf Unlit keepalpha noshadow 
		#undef TRANSFORM_TEX
		#define TRANSFORM_TEX(tex,name) float4(tex.xy * name##_ST.xy + name##_ST.zw, tex.z, tex.w)
		struct Input
		{
			float4 uv2_texcoord2;
			float2 uv_texcoord;
			float4 vertexColor : COLOR;
		};

		uniform float _CullMode;
		uniform float _Add_Blend;
		uniform float4 _Tint_01;
		uniform float4 _Tint_02;
		uniform sampler2D _MainTex;
		uniform float2 _SpeedDirMainTex;
		uniform float4 _MainTex_ST;
		uniform float _NoiseStrengthMainTex;
		uniform sampler2D _NoiseMainTex;
		uniform float2 _SpeedDirNoiseMainTex;
		uniform float4 _NoiseMainTex_ST;
		uniform sampler2D _AlphaMask;
		uniform float2 _SpeedDirAlphaMask;
		uniform float4 _AlphaMask_ST;
		uniform float _NoiseAlphaMaskStrength;
		uniform sampler2D _NoiseAlphaMask;
		uniform float2 _SpeedDirNoiseAlphaMask;
		uniform sampler2D _SubAlphaMask;
		uniform float2 _SpeedDirSubAlphaMask;
		uniform float4 _SubAlphaMask_ST;

		inline half4 LightingUnlit( SurfaceOutput s, half3 lightDir, half atten )
		{
			return half4 ( 0, 0, 0, s.Alpha );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			float ControlMoveMainTexByU60 = i.uv2_texcoord2.w;
			float2 appendResult69 = (float2(0.0 , ControlMoveMainTexByU60));
			float2 uv_MainTex = i.uv_texcoord * _MainTex_ST.xy + _MainTex_ST.zw;
			float2 panner6 = ( 1.0 * _Time.y * _SpeedDirMainTex + uv_MainTex);
			float2 uv_NoiseMainTex = i.uv_texcoord * _NoiseMainTex_ST.xy + _NoiseMainTex_ST.zw;
			float2 panner11 = ( 1.0 * _Time.y * _SpeedDirNoiseMainTex + uv_NoiseMainTex);
			float4 lerpResult56 = lerp( _Tint_01 , _Tint_02 , tex2D( _MainTex, ( appendResult69 + ( panner6 + ( _NoiseStrengthMainTex * tex2D( _NoiseMainTex, panner11 ).r ) ) ) ));
			o.Emission = ( lerpResult56 * i.vertexColor ).rgb;
			float ControlMoveAlphaByU59 = i.uv2_texcoord2.z;
			float2 appendResult64 = (float2(0.0 , ControlMoveAlphaByU59));
			float2 uv_AlphaMask = i.uv_texcoord * _AlphaMask_ST.xy + _AlphaMask_ST.zw;
			float2 panner18 = ( 1.0 * _Time.y * _SpeedDirAlphaMask + uv_AlphaMask);
			float2 panner23 = ( 1.0 * _Time.y * _SpeedDirNoiseAlphaMask + uv_AlphaMask);
			float2 uv_SubAlphaMask = i.uv_texcoord * _SubAlphaMask_ST.xy + _SubAlphaMask_ST.zw;
			float2 panner30 = ( 1.0 * _Time.y * _SpeedDirSubAlphaMask + uv_SubAlphaMask);
			o.Alpha = ( tex2D( _AlphaMask, ( float4( appendResult64, 0.0 , 0.0 ) + ( float4( panner18, 0.0 , 0.0 ) + ( _NoiseAlphaMaskStrength * tex2D( _NoiseAlphaMask, panner23 ) ) ) ).rg ) * tex2D( _SubAlphaMask, panner30 ) * i.vertexColor.a ).r;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18935
668;367;2296;992;767.1499;71.14198;1.492842;True;False
Node;AmplifyShaderEditor.TextureCoordinatesNode;10;-968.448,444.5343;Inherit;False;0;9;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;12;-967.448,583.5347;Inherit;False;Property;_SpeedDirNoiseMainTex;Speed Dir Noise MainTex;8;0;Create;True;0;0;0;False;0;False;0,0;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.PannerNode;11;-670.1279,502.5684;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;24;-368.6004,1146.438;Inherit;False;0;15;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;25;-430.702,1357.192;Inherit;False;Property;_SpeedDirNoiseAlphaMask;Speed Dir Noise Alpha Mask;13;0;Create;True;0;0;0;False;0;False;0,0;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TextureCoordinatesNode;58;158.2147,1751.949;Inherit;False;1;-1;4;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;14;-387.4221,345.9073;Inherit;False;Property;_NoiseStrengthMainTex;Noise Strength MainTex;7;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;9;-436.8305,468.2125;Inherit;True;Property;_NoiseMainTex;Noise MainTex;6;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;7;-358.8156,193.7596;Inherit;False;Property;_SpeedDirMainTex;Speed Dir MainTex;5;0;Create;True;0;0;0;False;0;False;0,0;-0.3,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.PannerNode;23;-152.9425,1241.835;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;5;-366.8837,19.35723;Inherit;False;0;3;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;60;462.5197,1873.685;Inherit;False;ControlMoveMainTexByU;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;22;-44.04284,1044.512;Inherit;False;Property;_NoiseAlphaMaskStrength;Noise Alpha Mask Strength;12;0;Create;True;0;0;0;False;0;False;0;0.15;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;16;27.43677,660.9495;Inherit;False;0;15;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;17;36.43678,848.9495;Inherit;False;Property;_SpeedDirAlphaMask;Speed Dir Alpha Mask;10;0;Create;True;0;0;0;False;0;False;0,0;-1,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;13;-49.09483,321.8971;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;68;-356.445,-143.8032;Inherit;False;60;ControlMoveMainTexByU;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;20;41.92786,1227.621;Inherit;True;Property;_NoiseAlphaMask;Noise Alpha Mask;11;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.PannerNode;6;-117.8711,134.4751;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;59;460.3356,1781.94;Inherit;False;ControlMoveAlphaByU;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.PannerNode;18;355.4365,717.9495;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DynamicAppendNode;69;95.8882,6.539736;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;21;385.8973,1050.804;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;61;312.2847,563.2803;Inherit;False;59;ControlMoveAlphaByU;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;8;135.5361,197.4647;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DynamicAppendNode;64;562.0626,708.5015;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;67;278.0422,67.6181;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Vector2Node;28;734.2374,1237.974;Inherit;False;Property;_SpeedDirSubAlphaMask;Speed Dir Sub Alpha Mask;15;0;Create;True;0;0;0;False;0;False;0,0;-1,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TextureCoordinatesNode;29;725.2374,1049.974;Inherit;False;0;27;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;19;583.8585,862.8062;Inherit;False;2;2;0;FLOAT2;0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;57;1170.247,-3.923715;Inherit;False;Property;_Tint_02;Tint_02;3;1;[HDR];Create;True;0;0;0;False;0;False;1,1,1,0;1,1,1,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.PannerNode;30;1055.237,1133.974;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.ColorNode;1;1169.105,-222.6952;Inherit;False;Property;_Tint_01;Tint_01;2;1;[HDR];Create;True;0;0;0;False;0;False;1,1,1,0;1,1,1,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;3;468.3255,68.57934;Inherit;True;Property;_MainTex;MainTex;4;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;62;782.6708,813.5143;Inherit;False;2;2;0;FLOAT2;0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;15;921.4925,777.1282;Inherit;True;Property;_AlphaMask;Alpha Mask;9;0;Create;True;0;0;0;False;0;False;-1;abaf76e832f6c744d8e610c661b33c5e;abaf76e832f6c744d8e610c661b33c5e;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.VertexColorNode;33;1437.52,461.2245;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;56;1431.102,230.6232;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;27;1320.549,1111.123;Inherit;True;Property;_SubAlphaMask;Sub Alpha Mask;14;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;2;1673.404,377.7861;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;31;1713.81,608.2183;Inherit;False;3;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;70;326.8078,2116.479;Inherit;False;Property;_CullMode;CullMode;16;1;[Enum];Create;True;0;0;1;UnityEngine.Rendering.CullMode;True;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;4;160.6136,2106.334;Inherit;False;Property;_Add_Blend;Add_Blend;0;1;[Enum];Create;True;0;0;1;UnityEngine.Rendering.BlendMode;True;0;False;1;4;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;2058.906,288.2424;Float;False;True;-1;6;ASEMaterialInspector;0;0;Unlit;S_ParticleAdd;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Off;2;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;False;0;True;Transparent;;Transparent;All;18;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;True;Relative;0;;1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;11;0;10;0
WireConnection;11;2;12;0
WireConnection;9;1;11;0
WireConnection;23;0;24;0
WireConnection;23;2;25;0
WireConnection;60;0;58;4
WireConnection;13;0;14;0
WireConnection;13;1;9;1
WireConnection;20;1;23;0
WireConnection;6;0;5;0
WireConnection;6;2;7;0
WireConnection;59;0;58;3
WireConnection;18;0;16;0
WireConnection;18;2;17;0
WireConnection;69;1;68;0
WireConnection;21;0;22;0
WireConnection;21;1;20;0
WireConnection;8;0;6;0
WireConnection;8;1;13;0
WireConnection;64;1;61;0
WireConnection;67;0;69;0
WireConnection;67;1;8;0
WireConnection;19;0;18;0
WireConnection;19;1;21;0
WireConnection;30;0;29;0
WireConnection;30;2;28;0
WireConnection;3;1;67;0
WireConnection;62;0;64;0
WireConnection;62;1;19;0
WireConnection;15;1;62;0
WireConnection;56;0;1;0
WireConnection;56;1;57;0
WireConnection;56;2;3;0
WireConnection;27;1;30;0
WireConnection;2;0;56;0
WireConnection;2;1;33;0
WireConnection;31;0;15;0
WireConnection;31;1;27;0
WireConnection;31;2;33;4
WireConnection;0;2;2;0
WireConnection;0;9;31;0
ASEEND*/
//CHKSM=8CF83139D20331F559CDEF83B057A65749AE35D2