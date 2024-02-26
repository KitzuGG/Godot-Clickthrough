using Godot;
using System;

public partial class WindowManager : Node
{
	// Autoloaded
 	// Remember to set the Project Settings correctly:
  	// Project Settings > Advanced Settings
   	// Display > Window > Transparent > TRUE
    	// Display > Window > Always on Top > TRUE
     	// Display > Window > Aspect > Expand (Recommended)
	
	public override void _Ready()
	{
		// Makes the background actually transparent
		GetViewport().TransparentBg = true;
		// Seems to function better when window is maximized or fullscreen, up to you
		DisplayServer.WindowSetMode(DisplayServer.WindowMode.Maximized);
		// If not, the default window border will still be rendered
		DisplayServer.WindowSetFlag(DisplayServer.WindowFlags.Borderless, true);
		// To avoid wacky behaviours
		DisplayServer.WindowSetFlag(DisplayServer.WindowFlags.ResizeDisabled, true);
		
		// Even though window should not be resizable, if the window is moved between monitor (of different sizes)
		// via shortcut, the window may lose transparency. This refreshes the window to become transparent again 
		GetViewport().SizeChanged += ViewportSizeRefresh;
	}
	
	
	
	// Used to avoid losing transparency when the borderless window is moved between monitors
	// of different sizes using the shortcut Super + any arrow key
	private void ViewportSizeRefresh()
	{
		DisplayServer.WindowSetFlag(DisplayServer.WindowFlags.Borderless, false);
		DisplayServer.WindowSetFlag(DisplayServer.WindowFlags.Borderless, true);
	}
}
