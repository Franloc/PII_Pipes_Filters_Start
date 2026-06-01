namespace CompAndDel
{
    public class FilterSave : IFilter
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
        public FilterSave(string path)
        {
            this.path = path;
        }
        public IPicture Filter(IPicture image)
        {
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image, path);
            return image;
        }
    }    
}