using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using FFCG.G9.CardAnalyzer.Rule;

namespace FFCG.G9.CardAnalyzer.Analyzer
{
    public class ConsoleAnalyzer
    {
        public AnalyzeResult Analyze(IDeck deck, IRule rule)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int tries = 0;

            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            Task.Run(() =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    Task.Delay(50, cancellationToken);
                    var average = tries / stopwatch.Elapsed.TotalSeconds;
                
                    Console.Write($"\rTries: {tries:N0} - Avg: {average:N0} / sec");    
                }
                

            }, cancellationToken);
            
            var hand = new List<Card>();
            while (true)
            {
                tries++;
                deck.Shuffle();
                
                for (int i = 0; i < 5; i++)
                {
                    hand.Add(deck.Draw());
                }

                if (rule.Matches(hand))
                {
                    stopwatch.Stop();
                    cancellationTokenSource.Cancel();
                    return new AnalyzeResult(hand, tries, stopwatch, rule);
                }
                hand.Clear();
            }
        }
        
    }
}