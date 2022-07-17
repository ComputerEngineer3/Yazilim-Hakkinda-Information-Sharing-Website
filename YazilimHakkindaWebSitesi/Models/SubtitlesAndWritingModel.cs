using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YazilimHakkindaWebSitesi.Models
{
    public class SubtitlesAndWritingModel
    {
        public IEnumerable<Subtitle> Subtitles { get; set; }
        public Writing Writing { get; set; }
    }
}