﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
  [Serializable]
  public class LoginClass
  {
    public LoginClass(string login, string password)
    {
      this.login = login;
      this.password = password;
    }
    public LoginClass()
    {
    }
    public string login { get; set; }
    public string password { get; set; }
    public string token { get; set; }
    public string GetMD5(string input)
    {
      // Use input string to calculate MD5 hash
      using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
      {
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
        byte[] hashBytes = md5.ComputeHash(inputBytes);

        // Convert the byte array to hexadecimal string
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hashBytes.Length; i++)
        {
          sb.Append(hashBytes[i].ToString("X2"));
        }
        return sb.ToString();
      }
    }
    public string GenToken()
    {
      byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
      byte[] key = Guid.NewGuid().ToByteArray();
      return  Convert.ToBase64String(time.Concat(key).ToArray());
    }

    public override string ToString()
    {
      return String.Format($"login:{login} password:{password} token:{token}");
    }
  }
  [Serializable]
  public class LoginMasClass
  {
     public List<LoginClass> ListOfLogins = new List<LoginClass>();
    public void Add(LoginClass lg)
    {
      ListOfLogins.Add(lg);
    }
    public string CheckLoginPassword(LoginClass lg)
    {
      foreach(LoginClass item in ListOfLogins)
      {
        if (lg.login == item.login)
        {
          if (lg.GetMD5(lg.password) == item.password)
          {
            return lg.GenToken();
          }
        }
      }
      return "";
    }
  }

