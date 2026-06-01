Shader "JuicedUp/DarkOverlayStencilWriter" {
    Properties {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Cutoff ("Alpha Cutoff", Range(0, 1)) = 0.1
        _StencilRef ("Stencil Ref", Range(0, 255)) = 1
        _StencilWriteMask ("Stencil Write Mask", Range(0, 255)) = 255
    }
    SubShader {
        Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "PreviewType"="Plane" }
        Stencil { Ref [_StencilRef] Comp Always Pass Replace WriteMask [_StencilWriteMask] }
        Cull Off Lighting Off ZWrite Off ZTest [unity_GUIZTestMode]
        ColorMask 0
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            struct appdata_t { float4 vertex : POSITION; float2 texcoord : TEXCOORD0; };
            struct v2f { float4 vertex : SV_POSITION; float2 texcoord : TEXCOORD0; };
            sampler2D _MainTex; float4 _MainTex_ST; fixed _Cutoff;
            v2f vert(appdata_t v) { v2f o; o.vertex = UnityObjectToClipPos(v.vertex); o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex); return o; }
            fixed4 frag(v2f i) : SV_Target { fixed a = tex2D(_MainTex, i.texcoord).a; clip(a - _Cutoff); return 0; }
            ENDCG
        }
    }
}
