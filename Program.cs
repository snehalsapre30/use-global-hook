using System.Threading;
using System.Windows.Input;

namespace GitSpecificApp.Global_events
{
    public class Program
    {
        static LowLevelKeyboardListener  keyboardListener;
        static  MouseListener mouseListener;
        public static void Main(string[] arr)
        {
             keyboardListener = new LowLevelKeyboardListener();
             mouseListener = new MouseListener();
             Start();
          
        }

        private static void Start()
        {
            ////Hooking to keyboard & mouse events
            HookKeybordEvent();
            HookKeyMouseEvent();
            ////Listening  to keyboard & mouse events

            keyboardListener.OnKeyPressed += OnKeyPressed;
            mouseListener.MouseAction += OnMouseAction;

        }

        private static void Stop()
        {
            UnHookKeybordEvent();
            UnHookMouseEvent();           
        }

       

        private static void OnMouseAction(object sender, MouseListener.MousePressedArgs e)
        {
           //Do required operation after recieving mouse event
        }

        private static void OnKeyPressed(object sender, KeyPressedArgs e)
        {
            //Do required operation after recieving keyboard event
        }

        public static void HookKeybordEvent()
        {
            keyboardListener.HookKeyboard();
        }

        public static void UnHookKeybordEvent()
        {
            keyboardListener.UnHookKeyboard();
        }

        public static void HookKeyMouseEvent()
        {
            mouseListener.HookMouse();
        }

        public static void UnHookMouseEvent()
        {
            mouseListener.UnHookMouse();
        }

        public static void SimulateKeyPressedEvent()
        {
            ///Passing the key for which keypress need to be simulated.
            var key = "a";// needs to be replaced with captured key.
            KeyConverter k = new KeyConverter();
            Key keyPressed = (Key)k.ConvertFromString(key);         
            keyboardListener.SimulateKeyEvent(keyPressed);
        }

        public static void simulateMouseClickEvent()
        {
            ///Simulate mouse click
            var positionX = 300;// needs to be replaced with captured position.
            var positionY = 500;//// needs to be replaced with capured position.
            System.Windows.Forms.Cursor.Position = new System.Drawing.Point(positionX, positionY);
            Thread.Sleep(500);         
            mouseListener.ApplyMouseEvent(positionX,positionY);
        }
    }
}
