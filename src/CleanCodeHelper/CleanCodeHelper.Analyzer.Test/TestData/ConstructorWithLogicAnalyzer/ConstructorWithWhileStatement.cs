﻿using System;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.ConstructorWithLogicAnalyzer
{
    [ExpectedDiagnostic("CC0005", Arguments = new object[] { nameof(ConstructorWithWhileStatement) }, Line = 9, Column = 16)]
    public class ConstructorWithWhileStatement
    {
        public ConstructorWithWhileStatement()
        {
            while (new Random().Next() % 2 == 0)
            {
                Console.WriteLine();
            }
        }
    }
}