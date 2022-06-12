Shader "Hidden/LightweightPipeline/Sampling" {
	Properties {
		_MainTex ("Albedo", 2D) = "white" {}
	}
	SubShader {
		LOD 100
		Tags { "RenderPipeline" = "LightweightPipeline" "RenderType" = "Opaque" }
		Pass {
			Name "Default"
			LOD 100
			Tags { "LIGHTMODE" = "LightweightForward" "RenderPipeline" = "LightweightPipeline" "RenderType" = "Opaque" }
			ZTest Always
			ZWrite Off
			GpuProgramID 11375
			Program "vp" {
				SubProgram "d3d11 " {
					"!!vs_4_0
					
					#version 330
					#extension GL_ARB_explicit_attrib_location : require
					#extension GL_ARB_explicit_uniform_location : require
					
					layout(std140) uniform UnityPerDraw {
						mat4x4 unity_ObjectToWorld;
						vec4 unused_0_1[21];
					};
					layout(std140) uniform UnityPerFrame {
						vec4 unused_1_0[19];
						mat4x4 unity_MatrixVP;
						vec4 unused_1_2[3];
					};
					in  vec4 in_POSITION0;
					in  vec2 in_TEXCOORD0;
					out vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * unity_ObjectToWorld[1];
					    u_xlat0 = unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * unity_MatrixVP[1];
					    u_xlat1 = unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
					    return;
					}"
				}
			}
			Program "fp" {
				SubProgram "d3d11 " {
					"!!ps_4_0
					
					#version 330
					#extension GL_ARB_explicit_attrib_location : require
					#extension GL_ARB_explicit_uniform_location : require
					
					layout(std140) uniform PGlobals {
						vec4 _MainTex_TexelSize;
						float _SampleOffset;
					};
					uniform  sampler2D _MainTex;
					in  vec2 vs_TEXCOORD0;
					layout(location = 0) out vec4 SV_Target0;
					vec4 u_xlat0;
					vec3 u_xlat16_0;
					vec4 u_xlat10_0;
					vec4 u_xlat1;
					vec3 u_xlat16_1;
					vec4 u_xlat10_1;
					vec4 u_xlat10_2;
					void main()
					{
					    u_xlat0 = vec4(_SampleOffset) * vec4(-1.0, -1.0, 1.0, 1.0);
					    u_xlat1 = _MainTex_TexelSize.xyxy * u_xlat0.xyzy + vs_TEXCOORD0.xyxy;
					    u_xlat0 = _MainTex_TexelSize.xyxy * u_xlat0.xwzw + vs_TEXCOORD0.xyxy;
					    u_xlat10_2 = texture(_MainTex, u_xlat1.xy);
					    u_xlat10_1 = texture(_MainTex, u_xlat1.zw);
					    u_xlat16_1.xyz = u_xlat10_1.xyz + u_xlat10_2.xyz;
					    u_xlat10_2 = texture(_MainTex, u_xlat0.xy);
					    u_xlat10_0 = texture(_MainTex, u_xlat0.zw);
					    u_xlat16_1.xyz = u_xlat16_1.xyz + u_xlat10_2.xyz;
					    u_xlat16_0.xyz = u_xlat10_0.xyz + u_xlat16_1.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vec3(0.25, 0.25, 0.25);
					    SV_Target0.w = 1.0;
					    return;
					}"
				}
			}
		}
	}
}