/// 
How to use: 

1.Make Sure you have "Assets/Pictures""
2.Drag the Cameras prefab from Assets/Prefabs into the scene, also delete any other cameras in the scene.
3.Arrange the cameras as you wish, if you want to add more cameras, you must add them as a child to the "Cameras" gameObject.
3.Click Play.
4.Press the 'C' Key. 
5.Done!
6.Exit the game, if you do not immediatley see your new folder, simply switch windows and go back to unity!

FAQ:

Q: Why is it posting the same picture?
A: Remember to delete the Main Camera or just about any other cameras in the scene.

Q: What does "CaptureOnPlay" do?
A: Rather than needing to press the 'C' button every time, you simply need to press the play button to capture the images.

///



/// 
Original Author of Transparency Capture
Transparency Capture

Capture view with transparency included.

How to use:
Use zzTransparencyCapture.capture(Rect) to capture a rectangular area from view.
zzTransparencyCapture.captureScreenshot capture whole screen.

After Unity4,you have to do those function after WaitForEndOfFrame in Coroutine
Or you will get the error:"ReadPixels was called to read pixels from system frame buffer, while not inside drawing frame"

How does it work:
This is the core. I use Texture2D.ReadPixels to make two captures with black and white background color separately.
Then calculate the alpha value in every pixel, with the two captures.
Thanks for Wang Xiang thinking out the idea, it saved me a lot of time to realize the function.

If you have some advice, some want, or find some bug, you can contact me.

Author:
orange030@gmail.com
///


