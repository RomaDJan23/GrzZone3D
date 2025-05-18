GrzZone3D Plugin for AutoCAD 2019 (.NET C#)
-------------------------------------------

This plugin calculates and visualizes lightning protection zones using the rolling sphere method.
Command: GRZZONE3D

Features:
- Supports multiple lightning rods with different heights
- Calculates protection radius for each rod
- Visualizes zones as circles on XY plane
- Simple point protection check logic (see ZoneAnalyzer.cs)

Installation:
1. Open AutoCAD 2019
2. Run NETLOAD and select GrzZone3D.dll (after compiling the solution)
3. Type GRZZONE3D to start the command

Source files are in GrzZone3DSource/
You can open GrzZone3D.sln with Visual Studio 2019 or newer.