# GrzZone3D

GrzZone3D is a .NET plugin for AutoCAD 2019 that calculates and visualizes lightning protection zones using the Rolling Sphere Method.

## Features

- Supports multiple lightning rods of different heights
- Calculates protection zones with mutual influence
- Draws 2D projection of protection zones
- Simple and clear command: `GRZZONE3D`

## Installation

1. Open **AutoCAD 2019**
2. Use the `NETLOAD` command to load `GrzZone3D.dll`
3. Use the `GRZZONE3D` command to run the tool

## Development

- Language: C#
- Framework: .NET Framework 4.7.2
- AutoCAD SDK: References required to `acmgd.dll` and `acdbmgd.dll`

## License

MIT License