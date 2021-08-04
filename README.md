# SpectreXRTest
This is a GitHub repo for the SpectreXR employee test. Here are your tasks:

### Menu Scene
* Simple scrollable menu with more than one field - though only one field needs to actually work.
* Select the proper menu field to load the next level.

### Main Scene
* Make a simple WASD + mouse camera controller.
  * Hold shift to sprint (smooth transition).
  * Press space to jump.
* In this scene you will find four rotating cubes. Do the following:
  * Make a look trigger. When the player is looking at the cube, the cube needs to stop rotating. When the player looks away, the cube continues to rotate as before.
  * Make a radial trigger. When the player gets within one meter of the cube, the cube should change material and animate in an up/down motion. When the player walks away from the cube, it returns to its original state. Bonus points if you make this without triggers or colliders.
* In the scene there is an Interactable cube. Do the following:
  * Click and hold the Interactable cube to make it follow the mouse.
  * Create an object with a transparent material which will be a snap/drop zone for the interactable cube.
  * Upon colliding with the object, the interactable snaps in the transparent objects place and the transparent object dissapears.
  * When the cube snaps a pop up saying you were successful shows as well as a button to return to the menu scene.
* Add tooltips and sound feedback for each interaction (for example, "pop"  sound when cube snaps into place, "place cube here" tooltip for the interaction, sound on UI button click, etc..).
  * There are no particular guidelines on the visual style and UX, do what you think is best!

---

### Project Guidelines
* Please follow industry standard coding structures, code quality is a point of emphasis in this test.
* Please comment your code where applicable when intent may not be clear.
* Please briefly explain your design choices in a separate document.
* Keep it simple but design the project's architecture so it can be scaled easily in the future. 
* Use Unity version 2020.3.*
* If you use any third party plugins, please let us know which ones and why.
* Git Proficiency. Bonus points for nailing the git workflow.
* Create a private repo and add the following people as contributors: matijafumic and fransarlija
