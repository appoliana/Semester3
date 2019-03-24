﻿using System;
using System.IO;
using System.Net.Sockets;

namespace Server
{
    public class ListResponce
    {
        public static void List(string response, TcpClient client)
        {
            string responseForClient = "1";
            DirectoryInfo dir = new DirectoryInfo(response);
            Console.WriteLine(response);
            var stream = client.GetStream();
            StreamWriter writer = new StreamWriter(stream);

            //writer.WriteLine(responseForClient);
            //writer.Flush();

            responseForClient += "============Список папок и файлов=============" + " ";
            foreach (var item in dir.GetDirectories())
            {
                try
                {
                    responseForClient += item.Name + " ";
                    //writer.WriteLine(item.Name + "\n");
                    //writer.Flush();
                }
                catch (Exception)
                {

                }
            }
            foreach (var item in dir.GetFiles())
            {
                try
                {
                    responseForClient += item.Name + ""; 
                }
                catch (Exception)
                {

                }
            }

            writer.WriteLine(responseForClient);
            writer.Flush();
            Console.WriteLine("Ответ отправлен");
            client.Close();
            Console.ReadLine();
        }
    }
}


if (!Directory.Exists(path))
            {
                await writer.WriteLineAsync("-1");
                return;
            }

            var directory = new DirectoryInfo(path);
            var dirList = directory.GetDirectories();
            var fileList = directory.GetFiles();

            await writer.WriteLineAsync($"{dirList.Length + fileList.Length}");

            foreach (var dir in dirList)
            {
                await writer.WriteLineAsync(dir.Name);
                await writer.WriteLineAsync("true");
            }

            foreach (var file in fileList)
            {
                await writer.WriteLineAsync(file.Name);
                await writer.WriteLineAsync("false");
            }