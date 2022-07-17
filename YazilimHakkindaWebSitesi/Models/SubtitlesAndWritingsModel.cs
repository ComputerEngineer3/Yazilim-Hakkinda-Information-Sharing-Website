using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YazilimHakkindaWebSitesi.Models
{
    public class SubtitlesAndWritingsModel
    {
        public IEnumerable<Subtitle> Subtitles { get; set; }
        public IEnumerable<Writing> Writings { get; set; }
    }
}