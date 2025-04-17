namespace RDDApplication.Data
{
    internal class ShowedFile
    {
        public ShowedFile(string Path, string Name) 
        {
            this.Path = Path;
            this.Name = Name;
            
        }
        public string Path { get; set; }
        public string Name { get; set; }

    }
}
