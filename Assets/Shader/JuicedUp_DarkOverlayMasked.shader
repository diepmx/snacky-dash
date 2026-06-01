Shader "JuicedUp/DarkOverlayMasked" {
    Properties {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        _StencilRef ("Stencil Ref", Range(0, 255)) = 1
        _StencilReadMask ("Stencil Read Mask", Range(0, 255)) = 255
    }
    SubShader {
        Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "PreviewType"="Plane" }
        Stencil { Ref [_StencilRef] Comp Equal ReadMask [_StencilReadMask] }
        Cull Off Lighting Off ZWrite Off ZTest [unity_GUIZTestMode]
        Blend SrcAlpha OneMinusSrcAlpha
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            struct appdata_t { float4 vertex : POSITION; fixed4 color : COLOR; float2 texcoord : TEXCOORD0; };
            struct v2f { float4 vertex : SV_POSITION; fixed4 color : COLOR; float2 texcoord : TEXCOORD0; };
            sampler2D _MainTex; fixed4 _Color; float4 _MainTex_ST;
            v2f vert(appdata_t v) { v2f o; o.vertex = UnityObjectToClipPos(v.vertex); o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex); o.color = v.color * _Color; return o; }
            fixed4 frag(v2f i) : SV_Target { return tex2D(_MainTex, i.texcoord) * i.color; }
            ENDCG
        }
    }
}
