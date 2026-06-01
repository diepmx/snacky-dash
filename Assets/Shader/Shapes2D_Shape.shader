Shader "Shapes2D/Shape" {
    Properties {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        [HideInInspector] _Shapes2D_SrcBlend ("Src Blend", Float) = 5
        [HideInInspector] _Shapes2D_DstBlend ("Dst Blend", Float) = 10
        [HideInInspector] _Shapes2D_SrcAlpha ("Src Alpha", Float) = 1
        [HideInInspector] _Shapes2D_DstAlpha ("Dst Alpha", Float) = 10
        [HideInInspector] _StencilComp ("Stencil Comparison", Float) = 8
        [HideInInspector] _Stencil ("Stencil ID", Float) = 0
        [HideInInspector] _StencilOp ("Stencil Operation", Float) = 0
        [HideInInspector] _StencilWriteMask ("Stencil Write Mask", Float) = 255
        [HideInInspector] _StencilReadMask ("Stencil Read Mask", Float) = 255
        [HideInInspector] _ColorMask ("Color Mask", Float) = 15
    }
    SubShader {
        Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "PreviewType"="Plane" }
        Stencil { Ref [_Stencil] Comp [_StencilComp] Pass [_StencilOp] ReadMask [_StencilReadMask] WriteMask [_StencilWriteMask] }
        Cull Off Lighting Off ZWrite Off
        Blend [_Shapes2D_SrcBlend] [_Shapes2D_DstBlend], [_Shapes2D_SrcAlpha] [_Shapes2D_DstAlpha]
        ColorMask [_ColorMask]
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            struct appdata_t { float4 vertex : POSITION; fixed4 color : COLOR; float2 texcoord : TEXCOORD0; };
            struct v2f { float4 vertex : SV_POSITION; fixed4 color : COLOR; float2 texcoord : TEXCOORD0; };
            sampler2D _MainTex; float4 _MainTex_ST;
            v2f vert(appdata_t v) { v2f o; o.vertex = UnityObjectToClipPos(v.vertex); o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex); o.color = v.color; return o; }
            fixed4 frag(v2f i) : SV_Target { return tex2D(_MainTex, i.texcoord) * i.color; }
            ENDCG
        }
    }
}
