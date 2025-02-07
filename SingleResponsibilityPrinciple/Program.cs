﻿using System;
using System.Reflection;

using SingleResponsibilityPrinciple.AdoNet;

namespace SingleResponsibilityPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            //var tradeStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SingleResponsibilityPrinciple.trades.txt");
            string url = "http://faculty.css.edu/tgibbons/trades4.txt";
            var logger = new ConsoleLogger();
            var tradeValidator = new SimpleTradeValidator(logger);
            //var tradeDataProvider = new StreamTradeDataProvider(tradeStream);
            var urltradedata = new URLTradeDataProvider(url);
            var tradeMapper = new SimpleTradeMapper();
            var tradeParser = new SimpleTradeParser(tradeValidator, tradeMapper);
            var tradeStorage = new AdoNetTradeStorage(logger);
            var tradeProcessor = new TradeProcessor(urltradedata, tradeParser, tradeStorage);
            tradeProcessor.ProcessTrades();

            Console.ReadKey();
        }
    }
}
