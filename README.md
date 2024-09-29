
    # Project 02—2D Arcade Space Shooter
        Space Wave Shooter - 9/28/24
        A space shooter with power ups, upgrades, and effects.
    ## Implementation
	- Space shooter built from the ground up using C#
	- Objects wrap around camera space
	- Asteroids and ships that can be shot and destroyed
	- Start and end screen
	- Enemies spawn in waves that get harder over time
	- Spawn protection (so you don't die immediately :D )
	- Custom URP quantized Bayer dithering shader made in HLSL/CG
	- Four types of power-ups
		+ Piercing bullets: allows bullets to go through 1 (+1 per stack) obstacle(s) before being destroyed
		+ Shield: spawns a temporary shield around the player every 15 (-1 per stack) seconds.
		+ Airburst bullets: Bullets split off into three after 0.5 (-0.05 per stack) seconds of being in the air
		+ General upgrade: Random effect
			= Repair ship (+1 life back)
			= Shot speed up (less time between shots)
			= Bullet speed up (faster bullets)
			= Bullet size up (bigger bullets)
			= Camera size up (zooms out the camera and gives more space to move around. Affects wrap boundaries.)
	- Four custom power-up icons (made by me)
	- Mouse rotation for more accurate ship maneuvers.
	- Ship exhaust particles
			
    ## References
	Ship, UFO, and Asteroid sprite from https://kenney.nl
	Font used - Upheaval by AEnigma from https://www.dafont.com/bitmap.php

    ## Future Development
	Cap the bullet speed so they don't leave gaps when they go too fast

    ## Created by Ian Weaver (Skadeddi)
