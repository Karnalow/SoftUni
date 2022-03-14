using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private List<IGym> gyms;

        public Controller()
        {
            this.equipment = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }

        public string AddAthlete(string gymName, string athleteType,
            string athleteName, string motivation, int numberOfMedals)
        {
            IGym searchedGym = gyms.FirstOrDefault(n => n.Name == gymName);

            if (searchedGym != null)
            {
                if (athleteType == "Boxer") 
                {
                    if (searchedGym.GetType().Name == "BoxingGym")
                    {
                        Boxer boxer = new Boxer(athleteName, motivation, numberOfMedals);

                        searchedGym.AddAthlete(boxer);

                        return $"Successfully added {athleteType} to {gymName}.";
                    }
                    else
                    {
                        return "The gym is not appropriate.";
                    }
                }
                if (athleteType == "Weightlifter")
                {
                    if (searchedGym.GetType().Name == "WeightliftingGym")
                    {
                        Weightlifter weightlifter = new Weightlifter
                            (athleteName, motivation, numberOfMedals);

                        searchedGym.AddAthlete(weightlifter);

                        return $"Successfully added {athleteType} to {gymName}.";
                    }
                    else
                    {
                        return "The gym is not appropriate.";
                    }
                }
                else
                {
                    throw new InvalidOperationException("Invalid athlete type.");
                }
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidGymName);
            }
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType == "BoxingGloves")
            {
                BoxingGloves boxingGloves = new BoxingGloves();
                equipment.Add(boxingGloves);

                return $"Successfully added {equipmentType}.";
            }
            else if (equipmentType == "Kettlebell")
            {
                Kettlebell kettlebell = new Kettlebell();
                equipment.Add(kettlebell);

                return $"Successfully added {equipmentType}.";
            }
            else
            {
                throw new InvalidOperationException("Invalid equipment type.");
            }
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType == "BoxingGym")
            {
                BoxingGym gym = new BoxingGym(gymName);
                gyms.Add(gym);

                return $"Successfully added {gymType}.";
            }
            else if (gymType == "WeightliftingGym")
            {
                WeightliftingGym gym = new WeightliftingGym(gymName);
                gyms.Add(gym);

                return $"Successfully added {gymType}.";
            }
            else
            {
                throw new InvalidOperationException("Invalid gym type.");
            }
        }

        public string EquipmentWeight(string gymName)
        {
            IGym searchedGym = gyms.Find(n => n.Name == gymName);

            return $"The total weight of the equipment in the gym {gymName} is {searchedGym.EquipmentWeight:f2} grams.";
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IGym searchedGym = gyms.FirstOrDefault(n => n.Name == gymName);
            IEquipment searchedEquipment = equipment.FindByType(equipmentType);

            if (searchedEquipment != null && searchedGym != null)
            {
                searchedGym.AddEquipment(searchedEquipment);
                equipment.Remove(searchedEquipment);

                return $"Successfully added {equipmentType} to {gymName}.";
            }
            else
            {
                throw new InvalidOperationException($"There isn’t equipment of type {equipmentType}.");
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().TrimEnd();   
        }

        public string TrainAthletes(string gymName)
        {
            IGym searchedGym = gyms.Find(n => n.Name == gymName);

            foreach (var athletes in searchedGym.Athletes)
            {
                athletes.Exercise();
            }

            return $"Exercise athletes: {searchedGym.Athletes.Count}.";
        }
    }
}
