using System;
using System.IO.Ports;
using System.Text;
using MachineBridge.HardCoded;

namespace COM100Test
{
    public class Program
    {
        public const string START_GAME = "0001";
        public const string CONTINUE_GAME = "0003";

        static void Main(string[] args)
        {
            try
            {
                var ballNum = -1;
                var simulateWait = false;
                var port = new SerialPort("COM99");
                port.Open();

                Console.WriteLine("Waiting for connection...");

                while (true)
                {
                    if (port.BytesToRead > 0)
                    {
                        var buffer = new byte[4];
                        port.Read(buffer, 0, buffer.Length);

                        var received = Encoding.ASCII.GetString(buffer);
                        Console.WriteLine(Encoding.ASCII.GetString(buffer));

                        simulateWait = received == START_GAME
                            || received == CONTINUE_GAME;

                        byte[] toSend = Encoding.ASCII.GetBytes(
                            received == START_GAME ? $"[{Codes.STARTED}]" : $"[{Codes.CONTINUING}]");
                        port.Write(toSend, 0, toSend.Length);

                        if (simulateWait)
                        {
                            Thread.Sleep(3500);

                            if (ballNum >= 2)
                            {
                                ballNum = -1;
                                toSend = Encoding.ASCII.GetBytes(
                                    $"[{Codes.RUNNING}][{Codes.CONTINUING}]");
                                port.Write(toSend, 0, toSend.Length);
                                Thread.Sleep(3500);
                                toSend = Encoding.ASCII.GetBytes(
                                    $"[{Codes.RUNNING}][{Codes.OVER}][{Codes.CONTINUING}]");
                            }
                            else
                            {
                                ballNum++;
                                if (ballNum <= 0)
                                {
                                    toSend = Encoding.ASCII.GetBytes($"[{Codes.CONTINUING}]");
                                }
                                else
                                {
                                    toSend = Encoding.ASCII.GetBytes(
                                        $"[{Codes.RUNNING}][0{ballNum}{ballNum + 11}][{Codes.CONTINUING}]");
                                }
                            }
                            port.Write(toSend, 0, toSend.Length);
                            simulateWait = false;
                        }
                    }

                    Thread.Sleep(50);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
            Console.ReadKey();
        }
    }
}
