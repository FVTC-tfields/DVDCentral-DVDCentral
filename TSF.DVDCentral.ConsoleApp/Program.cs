﻿using TSF.DVDCentral.ConsoleApp;

internal class Program
{
    private static string DrawMenu()
    {
        Console.WriteLine("Which operation do you wish to perform?");
        Console.WriteLine("Connect to a channel (c)");
        Console.WriteLine("Send a message to the channel (s)");
        Console.WriteLine("Exit (x)");

        string operation = Console.ReadLine();
        return operation;
    }

    private static void Main(string[] args)
    {
        string user = "Fields";
        //string hubAddress = "https://fvtcdp.azurewebsites.net/Gamehub";
        string hubAddress = "https://localhost:7271/BingoHub";
        string operation = DrawMenu();

        var signalRConnection = new SignalRConnection(hubAddress);
        
        while(operation != "x")
        {
            switch(operation)
            {
                case "c":
                    signalRConnection.ConnectToChannel(user);
                    break;
                case "s":
                    break;
                case "x":
                    break;
            }

            operation = DrawMenu();
        }
    }
}