﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebApp.Models
{
    public class Encryption
    {
        //metoda wykorzystywana do szyfrowania danych
        private static string encryptedText;
            private static void EncryptionMethod(string password)
            {
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    UTF8Encoding utf8 = new UTF8Encoding(); 
                    try 
                    {
                        byte[] data = md5.ComputeHash(utf8.GetBytes(password));//tworzy klucz hash 
                        encryptedText = Convert.ToBase64String(data);//zwrócenie typu string z konwersji z byte
                    }
                    catch(Exception)
                    {
                    ErrorAndExceptions.RegisterStatus(0);
                    }
                }
            }
            public static string EncryptedString(string password)
            {
                EncryptionMethod(password);
                return encryptedText;
            }
        }
    }