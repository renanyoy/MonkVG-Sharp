using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libMonkVG_fat.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Arm64, ForceLoad = true, IsCxx = true, LinkerFlags="-lc++")]


// -gcc_flags "-lc++"