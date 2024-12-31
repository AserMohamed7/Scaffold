using Scaffold.Entities;

namespace Scaffold
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ScaffoldContext())
            {
                // var teamPlayers = context.Teams
                //.Join(
                //    context.Players,
                //    team => team.TeamId,
                //    player => player.TeamId,
                //    (team, player) => new
                //    {
                //        TeamName = team.TeamName,
                //        PlayerName = player.PlayerName,

                //    })
                //.Where(result => result.TeamName == "Manchester United")
                //.ToList();

                // foreach (var item in teamPlayers)
                // {
                //     Console.WriteLine($"Team: {item.TeamName}, Player: {item.PlayerName}");
                // }

                //var leftJoinResult = context.Teams
                //.GroupJoin(
                //    context.Players,                          
                //    team => team.TeamId,                      
                //    player => player.TeamId,                  
                //    (team, players) => new                    
                //    {
                //        TeamName = team.TeamName,
                //        Players = players.DefaultIfEmpty()
                //    })
                //.SelectMany(
                //    result => result.Players,                 
                //    (result, player) => new
                //    {
                //        TeamName = result.TeamName,
                //        PlayerName = player.PlayerName , 
                //        Position = player.Position ,
                //        ShirtNumber = player.ShirtNumber 
                //    })
                //.ToList();


                // Print the result
                //foreach (var item in leftJoinResult)
                //{
                //    Console.WriteLine($"Team: {item.TeamName}, Player: {item.PlayerName}, Position: {item.Position}, Shirt Number: {item.ShirtNumber}");
                //}

                var groupedPlayers = context.Players
                .Where(p => p.Team != null)
                .GroupBy(
                    p => p.Team.TeamName,
                    p => new
                    {
                        p.PlayerName,

                    })
                .ToList();

                // Display the results
                foreach (var group in groupedPlayers)
                {
                    Console.WriteLine($"Team: {group.Key}");

                    foreach (var player in group)
                    {
                        Console.WriteLine($"\tPlayer: {player.PlayerName}");
                    }
                }


                // var leftJoinResult = context.Teams
                //.GroupJoin(
                //    context.Players,                          
                //    team => team.TeamId,                      
                //    player => player.TeamId,                  
                //    (team, players) => new                    
                //    {
                //        TeamName = team.TeamName,
                //        Players = players.DefaultIfEmpty()    
                //    })
                //.SelectMany(
                //    result => result.Players,                
                //    (result, player) => new
                //    {
                //        TeamName = result.TeamName,
                //        PlayerName = player.PlayerName ?? "No Player", 
                //    })
                //.ToList();

                // foreach (var item in leftJoinResult)
                // {
                //     Console.WriteLine($"Team: {item.TeamName}, Player: {item.PlayerName}");
                // }

                var realMadridPlayers = context.Teams
             .Where(team => team.TeamName == "Real Madrid")
             .SelectMany(team => team.Players)
             .ToList();
                foreach (var player in realMadridPlayers)
                {
                    Console.WriteLine($"Playerrrr ID: {player.PlayerId}, Name: {player.PlayerName}");
                    Console.WriteLine("hey hey hey");
                }
            }
        }
    }
}



