using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Channels;
using System.Xml.Xsl;

Console.WriteLine("TCPClient");

try
{
    bool sending = true;

    // Opret TcpClient, som forbinder til IP-adressen og porten
    using var client = new TcpClient("127.0.0.1", 7);
    Console.WriteLine("Forbundet til serveren!");

    // Få streamen til at sende data
    NetworkStream stream = client.GetStream();
    StreamReader reader = new StreamReader(stream);
    StreamWriter writer = new StreamWriter(stream);
   

    while (sending)
    {
        // Send en besked til serveren
        string message = Console.ReadLine();
        writer.WriteLine(message);
        writer.Flush();
        Console.WriteLine($"Sendt besked: {message}");

        // Læs svaret fra serveren
        string response = reader.ReadLine();
        Console.WriteLine($"Modtaget svar: {response}");
        if (message.ToLower() == "close") 
        { 
        
        sending = false;
        
        }
    }
    stream.Close();
}
catch (Exception e)
{
    Console.WriteLine($"Fejl: {e.Message}");
}