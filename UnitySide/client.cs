using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class UdpClnt{
	public static void Main(){
		byte[] data = new byte[1024];
      	string input, stringData;
      	UdpClient server = new UdpClient("127.0.0.1", 9876);

	    IPEndPoint sender = new IPEndPoint(IPAddress.Any, 9877);

	    string welcome = "Hello, are you there?";
	    data = Encoding.ASCII.GetBytes(welcome);
	    server.Send(data, data.Length);

	    data = server.Receive(ref sender);

	    Console.WriteLine("Message received from {0}:", sender.ToString());
	    stringData = Encoding.ASCII.GetString(data, 0, data.Length);
	    Console.WriteLine(stringData);

	    while(true){
	        input = Console.ReadLine();
	        if (input == "exit")
	        	break;
	       
	        	server.Send(Encoding.ASCII.GetBytes(input), input.Length);
	         	data = server.Receive(ref sender);	         	
	    }
	    Console.WriteLine("Stopping client");
	    server.Close();
	}
}