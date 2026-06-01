Shader "Custom/URP/UnlitRimWithShadows" {
	Properties {
		[Header(Base)] _BaseMap ("Base Map", 2D) = "white" {}
		_BaseColor ("Base Color", Vector) = (1,1,1,1)
		[Header(Rim Light)] [Toggle] _UseRim ("Enable Rim Light", Float) = 1
		_RimColor ("Rim Color", Vector) = (0.2,0.8,1,1)
		_RimPower ("Rim Power", Range(0.1, 8)) = 2.5
		_RimIntensity ("Rim Intensity", Range(0, 4)) = 1
		[Header(Bottom Mask)] _BottomAmount ("Bottom Amount", Range(0, 1)) = 1
		_BottomSoftness ("Bottom Softness", Range(0.001, 1)) = 0.25
		[Header(Right Mask)] _RightAmount ("Right Amount", Range(0, 1)) = 1
		_RightSoftness ("Right Softness", Range(0.001, 1)) = 0.25
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200

		Pass
		{
			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			float4x4 unity_ObjectToWorld;
			float4x4 unity_MatrixVP;

			struct Vertex_Stage_Input
			{
				float4 pos : POSITION;
			};

			struct Vertex_Stage_Output
			{
				float4 pos : SV_POSITION;
			};

			Vertex_Stage_Output vert(Vertex_Stage_Input input)
			{
				Vertex_Stage_Output output;
				output.pos = mul(unity_MatrixVP, mul(unity_ObjectToWorld, input.pos));
				return output;
			}

			float4 frag(Vertex_Stage_Output input) : SV_TARGET
			{
				return float4(1.0, 1.0, 1.0, 1.0); // RGBA
			}

			ENDHLSL
		}
	}
}