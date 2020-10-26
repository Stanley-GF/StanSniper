using Discord;
using Discord.Gateway;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SniperInMyChamp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "StanSniper - by Tehc#1337 (stan)";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("> ");
            Console.ResetColor();
            Console.Write("Token : ");
            string token = Console.ReadLine();

            DiscordSocketClient client = new DiscordSocketClient();

            try
            {
                client.Login(token);
                client.OnLoggedIn += Client_OnLoggedIn;
                Thread.Sleep(-1);
            }
            catch (Exception)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid token :/");
                Main(args);
            }
            //string input = "discord.gift/freevbuckmedrefdhzeufz";
            //string output = input.Substring(input.IndexOf("discord.gift/") + 13);
            //Console.Write(output);
            //Console.ReadKey();
        }

        private static void Client_OnLoggedIn(DiscordSocketClient client, LoginEventArgs args)
        {
            Console.Title = "Succesfully connected into " + client.User.Username + "#" + client.User.Discriminator + "  -  StanSni";
            Console.Clear();
            Console.WriteLine(Environment.NewLine + Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("                                     [");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("*");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Username : " + client.User.Username + Environment.NewLine);


            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("                                     [");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("*");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("ID : " + client.User.Id + Environment.NewLine);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("                                     [");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("*");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Email : " + client.User.Email + Environment.NewLine);


            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("                                     [");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("*");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Creation Date : " + client.User.CreatedAt + Environment.NewLine);

            Console.Write(Environment.NewLine + Environment.NewLine + Environment.NewLine);
            client.OnMessageReceived += Client_OnMessageReceived;
            Thread.Sleep(-1);
        }

        private static void Client_OnMessageReceived(DiscordSocketClient client, MessageEventArgs msg)
        {
            var message = msg.Message.Content.ToString();
            if (message.Contains("gift/"))
            {
                string gift = removebefore(message);
                string finalgift = gift = gift.Split()[0];
                finalgift = finalgift.Replace("gift/", "");

                try
                {
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    client.RedeemGift(finalgift);
                    sw.Stop();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("[");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("] ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Succesfully redeemed gift  - discord.gift/" + finalgift + " (" + sw.ElapsedMilliseconds + " ms)");
                }
                catch (Exception ex)
                {
                    try
                    {
                        if (client.GetGift(finalgift).Consumed == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("[");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("] ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("Gift already claimed from - discord.gift/" + finalgift + Environment.NewLine);
                        }
                        else
                        {

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("[");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("] ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("Error redeeming gift - discord.gift/" + finalgift + Environment.NewLine);

                        }
                    }
                    catch (Exception)
                    {


                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("[");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("] ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Unknow Gift - discord.gift/" + finalgift + Environment.NewLine);
                    }



                }
            }

        }

        private static string removebefore(string text)
        {
            String orgText = text;
            int i = orgText.IndexOf("gift/");
            if (i != -1)
            {
                text = orgText.Remove(0, i);
            }
            return text;
        }

    }
}
