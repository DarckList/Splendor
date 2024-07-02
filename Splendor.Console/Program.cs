using Core;
using Core.Components.Nobels;
using Microsoft.Extensions.DependencyInjection;

ServiceCollection serviceCollectin = new();

IEnumerable<string> players = [ "John", "Bob"];
serviceCollectin.AddSplenderCore();
var serivceProvider = serviceCollectin.BuildServiceProvider();

var developmentCardFactory = serivceProvider.GetRequiredService<IDevelopmentCardFactory>();
var nobelFactory = serivceProvider.GetRequiredService<INobelFactory>();
Random rand = new Random();
Game game = new(players, developmentCardFactory, nobelFactory);
game.Run();

