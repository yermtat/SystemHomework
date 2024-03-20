using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace taskHomework.Services;

class ReportService
{
    public Task<string> WordsCount(string source)
    {
        if (source != "")
        {

            return Task.Factory.StartNew(() => (source.Count(x => x == ' ') + 1).ToString() + " words");

        }
        else return Task.Factory.StartNew(() => "0 words");
    }


    public Task<string> SentenceCount(string source)
    {
        return Task.Factory.StartNew(() => source.Count(x => x == '.' || x == '!' || x == '?').ToString() + " sentences");


    }


    public Task<string> SymbolsCount(string source)
    {
        return Task.Factory.StartNew(() => source.Length.ToString() + " symbols");

    }



    public Task<string> QuestionsCount(string source)
    {
        return Task.Factory.StartNew(() => source.Count(x => x == '?').ToString() + " question sentences");
    }



    public Task<string> ExclamationCount(string source)
    {
        return Task.Factory.StartNew(() => source.Count(x => x == '!').ToString() + " exclamation sentences");
    }


    public async Task<string> FullReport(string source)
    {
        return await WordsCount(source) + '\n' + await SentenceCount(source) + '\n' + await SymbolsCount(source) + '\n' +
            await QuestionsCount(source) + '\n' + await ExclamationCount(source) + '\n';
    }


    
}
