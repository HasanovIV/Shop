using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Models;

namespace Shop.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            if (!content.Categories.Any())
            {
                content.Categories.AddRange(Categories().Select(cat => cat.Value));
            }

            if (!content.Chairs.Any())
            {
                content.AddRange(Chairs().Select(ch => ch.Value));
            }

        }

        private static Dictionary<string, Category> categoryDic;
        public static Dictionary<string, Category> Categories()
        {
            if (categoryDic == null)
            {
                var list = new List<Category>
                    {
                        new Category{Name = "Компьютерный", Desc = "Стулья для компьютерных столов." },
                        new Category{Name = "Кухонный", Desc = "Стулья для кухни." }
                    };

                categoryDic = new Dictionary<string, Category>();

                foreach (var item in list)
                {
                    categoryDic.Add(item.Name, item);
                }
            }

            return categoryDic;
        }

        private static Dictionary<string, Chair> chairDic;
        public static Dictionary<string, Chair> Chairs()
        {
            if (chairDic == null)
            {
                var list = new List<Chair>
                    {
                        new Chair
                            {
                                Name = "Супер гейм стул",
                                Desc = "Компьютерный стул по последним технологиям",
                                Img = "https://img.joomcdn.net/e9a1fdf4df8261c4429c57b06b907e56b87bab84_1024_1024.jpeg",
                                IsFavourite = true,
                                Price = 15000,
                                Category = categoryDic.ContainsKey("Компьютерный") ? categoryDic["Компьютерный"] : null
                            },

                        new Chair
                            {
                                Name = "Удобный стул для кухни",
                                Desc = "Очень удобный стул для обеденного стола.",
                                Img = "https://img.joomcdn.net/acfe1bcc3b1404c3060b39519102b0c09ba630a0_original.jpeg",
                                IsFavourite = false,
                                Price = 2000,
                                Category = categoryDic.ContainsKey("Кухонный") ? categoryDic["Кухонный"] : null
                            }
            };

                chairDic = new Dictionary<string, Chair>();

                foreach (var item in list)
                {
                    chairDic.Add(item.Name, item);
                }
            }

            return chairDic;
        }
    }
}
