using System.Reflection.Metadata.Ecma335;

namespace LibraryAPI;

public class LibraryAPI
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public long Isbn { get; set; }
    
    public string Subject { get; set; }
    
    public string Author { get; set; }

    public string Version { get; set; }
    
    public string Shelf { get; set; }
    
    public string Language { get; set; }
    
}