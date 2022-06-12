Shader "Hidden/LightweightPipeline/ScreenSpaceShadows" {
	Properties {
	}
	SubShader {
		Tags { "IGNOREPROJECTOR" = "true" "RenderPipeline" = "LightweightPipeline" }
		Pass {
			Name "Default"
			Tags { "IGNOREPROJECTOR" = "true" "RenderPipeline" = "LightweightPipeline" }
			ZTest Always
			ZWrite Off
			Cull Off
			GpuProgramID 956
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
					out vec4 vs_TEXCOORD0;
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
					    u_xlat0 = unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    gl_Position = u_xlat0;
					    u_xlat0.xyz = u_xlat0.xyw * vec3(0.5, 0.5, 0.5);
					    vs_TEXCOORD0.zw = u_xlat0.zz + u_xlat0.xy;
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
					
					layout(std140) uniform UnityPerCameraRare {
						vec4 unused_0_0[10];
						mat4x4 unity_CameraInvProjection;
						vec4 unused_0_2[4];
						mat4x4 unity_CameraToWorld;
					};
					layout(std140) uniform _DirectionalShadowBuffer {
						mat4x4 _WorldToShadow[5];
						vec4 unused_1_1[16];
						vec4 _DirShadowSplitSpheres0;
						vec4 _DirShadowSplitSpheres1;
						vec4 _DirShadowSplitSpheres2;
						vec4 _DirShadowSplitSpheres3;
						vec4 _DirShadowSplitSphereRadii;
						vec4 unused_1_7[4];
						vec4 _ShadowData;
						vec4 unused_1_9;
					};
					uniform  sampler2DShadow hlslcc_zcmp_DirectionalShadowmapTexture;
					uniform  sampler2D _DirectionalShadowmapTexture;
					uniform  sampler2D _CameraDepthTexture;
					in  vec4 vs_TEXCOORD0;
					layout(location = 0) out vec4 SV_Target0;
					vec4 u_xlat0;
					float u_xlat16_0;
					vec4 u_xlat10_0;
					vec4 u_xlat1;
					bvec4 u_xlatb1;
					vec3 u_xlat2;
					vec2 u_xlat3;
					bool u_xlatb3;
					float u_xlat6;
					float u_xlat9;
					int u_xlati9;
					uint u_xlatu9;
					void main()
					{
					    u_xlat10_0 = texture(_CameraDepthTexture, vs_TEXCOORD0.xy);
					    u_xlat16_0 = (-u_xlat10_0.x) + 1.0;
					    u_xlat16_0 = u_xlat16_0 * 2.0 + -1.0;
					    u_xlat3.xy = vs_TEXCOORD0.zw * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat1 = (-u_xlat3.yyyy) * unity_CameraInvProjection[1];
					    u_xlat1 = unity_CameraInvProjection[0] * u_xlat3.xxxx + u_xlat1;
					    u_xlat0 = unity_CameraInvProjection[2] * vec4(u_xlat16_0) + u_xlat1;
					    u_xlat0 = u_xlat0 + unity_CameraInvProjection[3];
					    u_xlat0.xyz = u_xlat0.xyz * vec3(1.0, 1.0, -1.0);
					    u_xlat0.xyz = u_xlat0.xyz / u_xlat0.www;
					    u_xlat1.xyz = u_xlat0.yyy * unity_CameraToWorld[1].xyz;
					    u_xlat0.xyw = unity_CameraToWorld[0].xyz * u_xlat0.xxx + u_xlat1.xyz;
					    u_xlat0.xyz = unity_CameraToWorld[2].xyz * u_xlat0.zzz + u_xlat0.xyw;
					    u_xlat0.xyz = u_xlat0.xyz + unity_CameraToWorld[3].xyz;
					    u_xlat1.xyz = u_xlat0.xyz + (-_DirShadowSplitSpheres0.xyz);
					    u_xlat1.x = dot(u_xlat1.xyz, u_xlat1.xyz);
					    u_xlat2.xyz = u_xlat0.xyz + (-_DirShadowSplitSpheres1.xyz);
					    u_xlat1.y = dot(u_xlat2.xyz, u_xlat2.xyz);
					    u_xlat2.xyz = u_xlat0.xyz + (-_DirShadowSplitSpheres2.xyz);
					    u_xlat1.z = dot(u_xlat2.xyz, u_xlat2.xyz);
					    u_xlat2.xyz = u_xlat0.xyz + (-_DirShadowSplitSpheres3.xyz);
					    u_xlat1.w = dot(u_xlat2.xyz, u_xlat2.xyz);
					    u_xlatb1 = lessThan(u_xlat1, _DirShadowSplitSphereRadii);
					    u_xlat2.x = (u_xlatb1.x) ? float(-1.0) : float(-0.0);
					    u_xlat2.y = (u_xlatb1.y) ? float(-1.0) : float(-0.0);
					    u_xlat2.z = (u_xlatb1.z) ? float(-1.0) : float(-0.0);
					    u_xlat1 = mix(vec4(0.0, 0.0, 0.0, 0.0), vec4(1.0, 1.0, 1.0, 1.0), vec4(u_xlatb1));
					    u_xlat2.xyz = u_xlat2.xyz + u_xlat1.yzw;
					    u_xlat1.yzw = max(u_xlat2.xyz, vec3(0.0, 0.0, 0.0));
					    u_xlat9 = dot(u_xlat1, vec4(4.0, 3.0, 2.0, 1.0));
					    u_xlat9 = (-u_xlat9) + 4.0;
					    u_xlatu9 = uint(u_xlat9);
					    u_xlati9 = int(u_xlatu9) << 2;
					    u_xlat1.xyz = u_xlat0.yyy * _WorldToShadow[(u_xlati9 + 1) / 4][(u_xlati9 + 1) % 4].xyz;
					    u_xlat1.xyz = _WorldToShadow[u_xlati9 / 4][u_xlati9 % 4].xyz * u_xlat0.xxx + u_xlat1.xyz;
					    u_xlat0.xyz = _WorldToShadow[(u_xlati9 + 2) / 4][(u_xlati9 + 2) % 4].xyz * u_xlat0.zzz + u_xlat1.xyz;
					    u_xlat0.xyz = u_xlat0.xyz + _WorldToShadow[(u_xlati9 + 3) / 4][(u_xlati9 + 3) % 4].xyz;
					    vec3 txVec0 = vec3(u_xlat0.xy,u_xlat0.z);
					    u_xlat10_0.x = textureLod(hlslcc_zcmp_DirectionalShadowmapTexture, txVec0, 0.0);
					    u_xlatb3 = 0.0>=u_xlat0.z;
					    u_xlat6 = (-_ShadowData.x) + 1.0;
					    u_xlat0.x = u_xlat10_0.x * _ShadowData.x + u_xlat6;
					    SV_Target0 = (bool(u_xlatb3)) ? vec4(1.0, 1.0, 1.0, 1.0) : u_xlat0.xxxx;
					    return;
					}"
				}
			}
		}
	}
}