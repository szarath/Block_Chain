using Block_Chain;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;


class Program
{
    static void Main(string[] args)
    {
        Blockchain myCoin = new Blockchain();

        myCoin.AddBlock("Transaction Data 1");
        myCoin.AddBlock("Transaction Data 2");
    }
}
