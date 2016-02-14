using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class UdpSrvr{

public static void Main(){
      byte[] data = new byte[1024];
      IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9876);
      UdpClient newsock = new UdpClient(ipep);

      Console.WriteLine("Waiting for a client...");

      IPEndPoint sender = new IPEndPoint(IPAddress.Any, 9877);

      data = newsock.Receive(ref sender);

      Console.WriteLine("Message received from {0}:", sender.ToString());
      Console.WriteLine(Encoding.ASCII.GetString(data, 0, data.Length));

      string msg = Encoding.ASCII.GetString(data, 0, data.Length);
      data = Encoding.ASCII.GetBytes(msg);
      newsock.Send(data, data.Length, sender); 

      while(true){
         data = newsock.Receive(ref sender);

         Console.WriteLine(Encoding.ASCII.GetString(data, 0, data.Length));
         newsock.Send(data, data.Length, sender);
      }
   }
}