using System;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser; 
using Projekcik.Core.DTO;

namespace Projekcik.Core.Services
{
    public interface IPdfKeywordExtractor
    {
        List<KeywordDto> Find(string pdfPath, IList<KeywordDto> allKeywords);
    }

    class PdfKeywordExtractor : IPdfKeywordExtractor
    {
        public List<KeywordDto> Find(string pdfPath, IList<KeywordDto> allKeywords)
        {
            var keywords = new List<KeywordDto>();
            if (File.Exists(pdfPath))
            {
                var pdfReader = new PdfReader(pdfPath);
                for (int page = 1; page <= pdfReader.NumberOfPages; page++)
                {
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();

                    var currentPageText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);
                    foreach (var kw in allKeywords)
                    {
                        if (currentPageText.Contains(kw.Name, StringComparison.InvariantCultureIgnoreCase))
                            keywords.Add(kw);
                    }
                }
                pdfReader.Close();
            }
            return keywords;
        }
    }
}
