using System;
using System.IO.Ports;
class Test{
    
    public static void println(Object obj) {
        Console.WriteLine(obj);
    }
    public static void println() {
        Console.WriteLine();
    }
    public static void print(Object obj) {
        Console.Write(obj);
    }
    public static void Main(string[] asd) {
        SerialPort p = new SerialPort {
            PortName = "COM8",
            BaudRate = 9600,
            DataBits = 8,
            StopBits = StopBits.One,
            Parity = Parity.None,
            ReadTimeout = 1000
        };
        try {
            p.Open();   println("Arduino连接成功");
            while (true) {
                string data = p.ReadLine().Trim();
                if (double.TryParse(data, out double a)) print("\r距离："+a+"  厘米");
            
            }
        }catch(Exception e) {
            Console.WriteLine("错误发生于->"+e.Message);
        } finally {
            if (p.IsOpen) p.Close();
        }
    }
}