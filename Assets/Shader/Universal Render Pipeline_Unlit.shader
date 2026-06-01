Shader "Universal Render Pipeline/Unlit" {
    Properties {
        _BaseMap ("Albedo", 2D) = "white" {}
        _BaseColor ("Color", Color) = (1,1,1,1)
        _MainTex ("BaseMap", 2D) = "white" {}
        _Color ("Base Color", Color) = (1,1,1,1)
        _Cutoff ("Alpha Cutoff", Range(0,1)) = 0.5
                _EmissionColor ("Emission", Color) = (0,0,0,1)
        _EmissionMap ("Emission Map", 2D) = "white" {}
        _Surface ("Surface", Float) = 0
        _Cull ("Cull", Float) = 2
        _ZWrite ("ZWrite", Float) = 1
    }
    SubShader {
        Tags { "RenderType"="Opaque" "Queue"="Geometry" "RenderPipeline"="UniversalPipeline" }
        Cull [_Cull] ZWrite [_ZWrite]
        Pass {
            Tags { "LightMode"="UniversalForward" }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            struct appdata { float4 vertex : POSITION; float2 uv : TEXCOORD0; fixed4 color : COLOR; };
            struct v2f { float4 pos : SV_POSITION; float2 uv : TEXCOORD0; fixed4 color : COLOR; };
            sampler2D _BaseMap; float4 _BaseMap_ST; fixed4 _BaseColor; sampler2D _MainTex; fixed4 _Color; fixed _Cutoff; fixed4 _EmissionColor;
            v2f vert(appdata v) { v2f o; o.pos = UnityObjectToClipPos(v.vertex); o.uv = TRANSFORM_TEX(v.uv, _BaseMap); o.color = v.color; return o; }
            fixed4 frag(v2f i) : SV_Target { fixed4 c = tex2D(_BaseMap, i.uv) * _BaseColor * _Color * i.color; clip(c.a - _Cutoff); c.rgb += _EmissionColor.rgb * _EmissionColor.a; return c; }
            ENDCG
        }
    }
    Fallback Off
}
