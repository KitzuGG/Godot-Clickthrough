# Godot-Clickthrough
Example implementation of a window with "transparent" properties made in the Godot Engine using C#

Using Godot 4.2.1 C#
This is a basic implementation of window transparency with click-through ability using simply the viewport transparent pixels
C# only, using Windows API calls (not tested for other systems)

> I am currently working on a GDExtension adaptation so GDScript-only users can access to this feature more easily!
>
> (And perhaps Linux support if I manage to)

## Known issues

On newer graphic drivers, the window transparency may not work correctly: Clickthrough still functions, but the window is black and not transparent

After some tinkering I managed to find some solutions (yet not sure on why this problem occurs in the first place)
- Change rendering method to `Compatibility` or
- Disable VSync, if you need a fps cap consider using `Project Settings > Application > Run > Max FPS` instead
