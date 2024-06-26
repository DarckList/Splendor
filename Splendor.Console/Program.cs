using Core;
using Microsoft.Extensions.DependencyInjection;

ServiceCollection serviceCollectin = new();

IEnumerable<string> players = [ "John", "Bob"];
serviceCollectin.AddSplenderCore();
var serivceProvider = serviceCollectin.BuildServiceProvider();

var developmentCardFactory = serivceProvider.GetRequiredService<IDevelopmentCardFactory>();
Random rand = new Random();
//DevelopmentCardFactory developmentCardFactory = new(rand);
Game game = new(players, developmentCardFactory);
game.Run();

