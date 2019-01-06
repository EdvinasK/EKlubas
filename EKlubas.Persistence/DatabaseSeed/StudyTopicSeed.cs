using EKlubas.Domain.StudyTopic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Persistence.DatabaseSeed
{
    public static class StudyTopicSeed
    {
        public static List<StudyTopic> GetStudyTopicListSeed()
        {
            var cities = new List<StudyTopic>
            {
                new StudyTopic()
                {
                    Id = 1,
                    Name = "Lygu, daugiau arba mažiau",
                    Description = "Įvairaus sudėtingumo lygybių uždaviniai be kintamųjų",
                    Topic = "Math",
                    DifficultyLevel = 1,
                    Link = "Equality",
                    DurationInMinutes = 5
                },

                new StudyTopic()
                {
                    Id = 2,
                    Name = "Lygu, daugiau arba mažiau",
                    Description = "Įvairaus sudėtingumo lygybių uždaviniai be kintamųjų",
                    Topic = "Math",
                    DifficultyLevel = 2,
                    Link = "Equality",
                    DurationInMinutes = 10
                },

                new StudyTopic()
                {
                    Id = 3,
                    Name = "Lygu, daugiau arba mažiau",
                    Description = "Įvairaus sudėtingumo lygybių uždaviniai be kintamųjų",
                    Topic = "Math",
                    DifficultyLevel = 3,
                    Link = "Equality",
                    DurationInMinutes = 15
                },
                new StudyTopic()
                {
                    Id = 4,
                    Name = "Lygtys su vienu kintamuoju",
                    Description = "Įvairaus sudėtingumo lygčių uždaviniai su vienu kintamuoju x",
                    Topic = "Math",
                    DifficultyLevel = 1,
                    Link = "Equation",
                    DurationInMinutes = 5
                },

                new StudyTopic()
                {
                    Id = 5,
                    Name = "Lygtys su vienu kintamuoju",
                    Description = "Įvairaus sudėtingumo lygčių uždaviniai su vienu kintamuoju x",
                    Topic = "Math",
                    DifficultyLevel = 2,
                    Link = "Equation",
                    DurationInMinutes = 10
                },

                new StudyTopic()
                {
                    Id = 6,
                    Name = "Lygtys su vienu kintamuoju",
                    Description = "Įvairaus sudėtingumo lygčių uždaviniai su vienu kintamuoju x",
                    Topic = "Math",
                    DifficultyLevel = 3,
                    Link = "Equation",
                    DurationInMinutes = 15
                },
                new StudyTopic()
                {
                    Id = 7,
                    Name = "Lygybės su vienu kintamuoju",
                    Description = "Įvairaus sudėtingumo lygybių uždaviniai su vienu kintamuoju x",
                    Topic = "Math",
                    DifficultyLevel = 1,
                    Link = "EqualityWithVariable",
                    DurationInMinutes = 5
                },

                new StudyTopic()
                {
                    Id = 8,
                    Name = "Lygybės su vienu kintamuoju",
                    Description = "Įvairaus sudėtingumo lygybių uždaviniai su vienu kintamuoju x",
                    Topic = "Math",
                    DifficultyLevel = 2,
                    Link = "EqualityWithVariable",
                    DurationInMinutes = 10
                },

                new StudyTopic()
                {
                    Id = 9,
                    Name = "Lygybės su vienu kintamuoju",
                    Description = "Įvairaus sudėtingumo lygybių uždaviniai su vienu kintamuoju x",
                    Topic = "Math",
                    DifficultyLevel = 3,
                    Link = "EqualityWithVariable",
                    DurationInMinutes = 15
                }
            };

            return cities;
        }
    }
}
