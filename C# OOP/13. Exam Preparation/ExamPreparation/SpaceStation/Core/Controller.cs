using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private int exploredPlanets;

        private AstronautRepository astronautsRepo;
        private PlanetRepository planetsRepo;
        private Mission mission;

        public Controller()
        {
            this.astronautsRepo = new AstronautRepository();
            this.planetsRepo = new PlanetRepository();
            this.mission = new Mission();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;

            if (type == "Biologist")
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            this.astronautsRepo.Add(astronaut);

            return $"Successfully added {type}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            var planet = new Planet(planetName);

            for (int i = 0; i < items.Length; i++)
            {
                planet.Items.Add(items[i]);
            }

            planetsRepo.Add(planet);

            return $"Successfully added Planet: {planetName}!";
        }

        public string ExplorePlanet(string planetName)
        {
            var astronauts = this.astronautsRepo
                .Models
                .Where(x => x.Oxygen > 60)
                .ToList();

            if (!astronauts.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            exploredPlanets++;

            var planet = this.planetsRepo.FindByName(planetName);

            this.mission.Explore(planet, astronauts);

            int deadAstrondauts = 0;

            foreach (var astronaut in astronauts)
            {
                if (!astronaut.CanBreath)
                {
                    deadAstrondauts++;
                }
            }

            return $"Planet: {planetName} was explored! Exploration finished with {deadAstrondauts} dead astronauts!";
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{exploredPlanets} planets were explored!");
            sb.AppendLine("Astronauts info:");

            foreach (var astronaut in this.astronautsRepo.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");

                if (astronaut.Bag.Items.Count > 0)
                {
                    string items = string.Join(", ", astronaut.Bag.Items);

                    sb.AppendLine($"Bag items: {items}");
                }
                else
                {
                    sb.AppendLine($"Bag items: none");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronautsRepo.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }

            astronautsRepo.Remove(astronaut);

            return $"Astronaut {astronautName} was retired!";
        }
    }
}
