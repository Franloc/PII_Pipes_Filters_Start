using System;
using Ucu.Poo.Twitter;
namespace CompAndDel
{
    public class FilterTwitter : IFilter
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
        public FilterTwitter(string path)
        {
            this.path = path;
        }
        public IPicture Filter(IPicture image)
        {
            var twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter("Hola", path));
            return image;
        }
    }    
}