using BlinkStickNET;

namespace Blinky;

public static class Program
{
    public static void Main()
    {
        BlinkStick blinkStick = BlinkStick.FindFirst();
        blinkStick.OpenDevice();

        byte r = 0;
        byte g = 30;
        byte b = 30;

        blinkStick.SetColor(0, 0, r, g, b); // Set first LED.
        blinkStick.SetColor(0, 1, r, g, b); // Set second LED.
        
        blinkStick.Pulse(0, 0, r, g, b, 2); // Pulse first LED 5 times.
        blinkStick.Blink(0, 1, r, g, b, 2); // Blink second LED 5 times.
        
        blinkStick.TurnOff(); // Will not turn off LED 2.
                              // Don't blame me! That's how it works in the original code!

        blinkStick.CloseDevice();
    }
}