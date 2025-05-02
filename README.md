# Godot-Clickthrough
Example implementation of a window with "transparent" properties made in the Godot Engine using C#

Updated and tested with 4.5.0
This is a basic implementation of window transparency with click-through ability using simply the viewport transparent pixels
C# only, using Windows API calls (not tested for other systems)

## Known issues

On newer graphic drivers, the window transparency may not work correctly: Clickthrough still functions, but the window is black and not transparent

After some tinkering I managed to find some solutions (yet not sure on why this problem occurs in the first place)
- Change rendering method to `Compatibility` or
- Disable VSync in `Project Settings > Display > Window > V-Sync Mode: "Disabled"`, if you need a fps cap consider using `Project Settings > Application > Run > Max FPS` instead

If you want to use VSync, you can try switching to D3D12 Rendering Driver instead of Vulkan, but the window properties may not function anymore (keeping the window clickable when it shouldn't)
