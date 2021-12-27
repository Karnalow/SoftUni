using P07.MilitaryElite.Contracts;
using P07.MilitaryElite.Models;
using System;
using System.Collections.Generic;

namespace P07.MilitaryElite
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Dictionary<int, ISoldier> soldiers = new Dictionary<int, ISoldier>();

            string[] input = Console.ReadLine()
                .Split(' ');

            while (input[0] != "End")
            {
                string action = input[0];
                int id = int.Parse(input[1]);
                string firstName = input[2];
                string lastName = input[3];

                if (action == "Private")
                {
                    decimal salary = decimal.Parse(input[4]);

                    IPrivate @private = new Private(id, firstName, lastName, salary);

                    soldiers.Add(id, @private);
                }
                else if (action == "LeutenantGeneral")
                {
                    decimal salary = decimal.Parse(input[4]);

                    ILieutenantGeneral lieutenantGeneral = 
                        new LieutenantGeneral(id, firstName, lastName, salary);

                    for (int i = 5; i < input.Length; i++)
                    {
                        int inputId = int.Parse(input[i]);

                        IPrivate @private = soldiers[inputId] as IPrivate;

                        lieutenantGeneral.Privates.Add(@private);
                    }

                    soldiers.Add(id, lieutenantGeneral);
                }
                else if (action == "Engineer")
                {
                    decimal salary = decimal.Parse(input[4]);
                    string corpAsString = input[5];

                    bool isValidEnum = Enum.TryParse(corpAsString, out Corps result);

                    if (!isValidEnum)
                    {
                        input = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                        continue;
                    }

                    IEngineer engineer = new Engineer(id, firstName, lastName, salary, result);

                    for (int i = 6; i < input.Length; i += 2)
                    {
                        string partName = input[i];

                        int hours = int.Parse(input[i + 1]);

                        IRepair repair = new Repair(partName, hours);

                        engineer.Repairs.Add(repair);
                    }

                    soldiers.Add(id, engineer);
                }
                else if (action == "Commando")
                {
                    decimal salary = decimal.Parse(input[4]);
                    string corAsString = input[5];

                    bool isValidEnum = Enum.TryParse(corAsString, out Corps result);

                    if (!isValidEnum)
                    {
                        input = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                        continue;
                    }

                    ICommando commando = new Commando(id, firstName, lastName, salary, result);

                    for (int i = 6; i < input.Length; i += 2)
                    {
                        string missionCode = input[i];
                        string missionStateAsString = input[i + 1];

                        bool isValidMission = Enum.TryParse(missionStateAsString, out Status status);

                        if (!isValidMission)
                        {
                            continue;
                        }

                        IMission mission = new Missione(missionCode, status);

                        commando.Missions.Add(mission);
                    }

                    soldiers.Add(id, commando);
                }
                else if (action == "Spy")
                {
                    int codeNumber = int.Parse(input[4]);

                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);

                    soldiers.Add(id, spy);
                }

                input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var item in soldiers)
            {
                Console.WriteLine(item.Value.ToString());
            }
        }
    }
}
