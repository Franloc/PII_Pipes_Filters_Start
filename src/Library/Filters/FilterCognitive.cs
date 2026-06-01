using System;
using System.Drawing;
using Ucu.Poo.Cognitive;
namespace CompAndDel
{
    public class FilterCognitive : IFilter
    {
        private string path;
        public string Path
        {
            get {return this.path;}
        }
        private bool result;
        public bool Result
        {
            get {return this.result;} set {this.result = value;}
        }
        public FilterCognitive(string path)
        {
            this.path = path;
        }
        public IPicture Filter(IPicture image)
        {
            CognitiveFace cog = new CognitiveFace(true, Color.GreenYellow);
            cog.Recognize(path);
            result = cog.FaceFound;
            return image;
        }
    }    
}