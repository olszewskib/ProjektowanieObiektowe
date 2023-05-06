namespace ProjektowanieObiektowe.CLI.AddCommand;

public class AddCommand : ICommand
{
    public string CommandName => "add";
    public string Args { get; set; }
    public bool Abort { get; set; } = false;
    private ObjectFactory objectFactory;

    private readonly Dictionary<string, ObjectFactory> availableFactories = new Dictionary<string, ObjectFactory>()
    {
        { "movie", new MovieFactory() },
        { "author", new AuthorFactory() },
        { "episode", new EpisodeFactory() },
        { "series", new SeriesFactory() }
    };

    public void Execute()
    {
        var args = Args.Split(" ");
        if (availableFactories.ContainsKey(args[1]))
        {
            objectFactory = availableFactories[args[1]];
            objectFactory.Representation = args[2];
            objectFactory.ShowOptions();
        }
        
        while (true)
        {
            var input = Console.ReadLine();
            if (input == "DONE") break;
            if (input == "EXIT")
            {
                Abort = true;
                break;
            }
            
            if (input.Contains('='))
            {
                var prop = input.Split("=");
                objectFactory.DeclareProperty(prop[0], prop[1]);
            }
            
        }
        if (Abort)
        {
            Console.WriteLine("[Operation aborted]");
            return;
        }

        Console.WriteLine("[Created]");
        objectFactory.Add();
    }
}